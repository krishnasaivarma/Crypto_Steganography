using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {
        public long p, q, n, t, flag, j, i, pt, ct, k, len, key,asa;
        int msgLength,zz=0;
        long tlen;
        int S11, S12, S21, S22;
        long[] temp = new long[1000];
        long[] m = new long[1000];
        char[] hi = new char[1000];
        long[] en = new long[1000];
        char[] msg = new char[1000];
        char[] msgk = new char[1000];
        string msgs = "", message = "", kkr, qrmessage, qrkey, info, info2;


        public void xoring()
        {
            
            string input = message;
            //MessageBox.Show(input);
            string key = qrkey;
           // MessageBox.Show(qrkey);
           // string key = "681016";

            String result;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            { sb.Append((char)(input[i] ^ key[(i % key.Length)])); }
            result = sb.ToString();
            //MessageBox.Show(result);
            message = result;
        }

        public void save()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files (*.txt) | *.txt";
           
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                textBoxMessage.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
            }
            progressBar1.Value = 100;
        }

        public void ss()
        {
            s11 = qrkey.Substring(0, 1);
            s12 = qrkey.Substring(1, 1);
            s21 = qrkey.Substring(2, 2);
            s22 = qrkey.Substring(2, 2);
        }

        public void qrscaner()
        {


            Bitmap img = new Bitmap(textBoxFilePath.Text);

            int div = img.Width / 20;
            ss();

            for (int i = S11; i < S21; i++)
            {
                for (int j = S21; j < S22; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (pixel.R > 127 && pixel.G > 127 && pixel.B > 127)
                    {
                        info += "1";
                    }
                    else if (pixel.R < 127 && pixel.G < 127 && pixel.B < 127)
                    {
                        info += "0";
                    }

                }
            }

            int ll1 = info.Length % 8;
            for (i = 0; i < ll1; i++)
            {
                info += "0";
            }
            int ll2 = info.Length / 8;
            for (i = 0; i < ll2; i++)
            {
                string sss = info.Substring(0, 8);
                string ss2 = info.Substring(8, info.Length - 8);
                info2 += convertbyte(sss);
                sss = ss2;
            }

            qrkey=info2;
        }

        public string convertbyte(string ss)
        {
            List<Byte> bytelist = new List<Byte>();
            bytelist.Add(Convert.ToByte(ss));
            return ss;
        }

        public void imguploader()
        {
            ofd.Filter = "Image Files (*.png, *.jpg) | *.png; *.jpg";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ofdimg = ofd.FileName;
                textBoxFilePath.Text = ofdimg;
            }
            if (textBoxFilePath.Text != "")
            {
                button4.Enabled = true;
                progressBar1.Value = 10;
                Image i1 = Image.FromFile(textBoxFilePath.Text);
                pictureBox1.Image = i1;
            }
        }
        string s11, s12, s21, s22;
        public void seperate()
        {
            button1.Enabled = true;
            for (int dsd = 0; dsd < 1000; dsd++)
                en[dsd] = 0;
            int cvc = 0;
            Bitmap img = new Bitmap(textBoxFilePath.Text);
            

            Color lastpixel = img.GetPixel(img.Width - 1, img.Height - 1);
            //need to tweak this one
            msgLength = numberseperator(lastpixel.R, lastpixel.G, lastpixel.B);
            asa = (long)msgLength;


            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (i < 1 && j < msgLength)
                    {
                        int value = numberseperator(pixel.R, pixel.G, pixel.B);
                        en[cvc] = value;
                        cvc++;
                        char c = Convert.ToChar(value);
                        message += c;

                    }
                }
            }

            textBoxMessage.Text = message;
        }

// put data to en[]
       public void decrypt()
    {
        int l = 0;
        //en = null;
        //GC.Collect();
    
        // /*
        l = 0;
        hi = message.ToCharArray();
        foreach (char cv in hi)
        { en[l] = Convert.ToInt32(cv); l++; }
           // */
        
        if (radioButton2.Checked == true && zz == 0)
        {
            asa = 6;
        }
        else if (radioButton2.Checked == true && zz == 1)
        {
            asa = tlen - 6;
            
        }

       for(long q=0;q<asa;q++)
     {     temp[q]=  en[q] - 96;     }

       
    i = 0;
    for (long q = 0; q < asa; q++)
    {
        ct = temp[i];
        k = 1;
        for (j = 0; j < key; j++)
        {
            k = k * ct;
            k = k % n;
        }

       pt = k + 96;
        m[i] = pt;
        i++;
    }
    m[i] = -1;
    //THE DECRYPTED MESSAGE
    for (i = 0; m[i] != -1; i++)
     {
       msgk[i]=(char)m[i];
       if (m[i] == 87)
           msgs += "\n";
       else
         msgs+= msgk[i];
     }
    textBoxMessage.Text = msgs;
    msgs = "";
    }

        public int numberseperator(int r, int g, int b)
        {
            int value = (r % 10) * 100 + (g % 10) * 10 + (b % 10);
            return value;
        }

        public OpenFileDialog ofd = new OpenFileDialog();
        public string ofdtxt, ofdimg;

        public Form4()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = checkBox1.Checked;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = numericUpDown2.Value = 0;
        }
        public void qrscanner() { }
        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imguploader();
        }
        public void seperatebutton()
        {
            
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            seperate();
            kkr = message;
            progressBar1.Value = 50;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            seperatebutton();
        }
        public void qrseperater()
        {

            qrkey = message.Substring(kkr.Length - 6, 6);
            qrmessage = message.Substring(0, kkr.Length - 6);
            message = qrkey;
           
            decrypt();
            qrkey=textBoxMessage.Text;
            textBox1.Text = "(" + qrkey.Substring(0, 1) + "," +qrkey.Substring(1, 1)+ ")";
            textBox2.Text = "(" + qrkey.Substring(2, 2) + "," + qrkey.Substring(4, 2) + ")";
            textBoxMessage.Text="";
            message = qrmessage;
            
            zz = 1;
            
        }

        private void docodeclick()
        {
            panel2.Visible = radioButton2.Checked;
            button1.Enabled = false;
            key = (long)numericUpDown1.Value;
            n = (long)numericUpDown2.Value;
            Console.WriteLine("done1");
            textBoxMessage.Text = null;
            if (radioButton2.Checked == true)
            {
                tlen = asa;
                qrseperater();
                xoring();
            }
            qrscanner();
            decrypt();
            button10.Enabled = true;
            progressBar1.Value = 90;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            docodeclick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 37;
            numericUpDown2.Value = 77;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            save();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please upload crypto image!");
            imguploader();
            seperatebutton();
            docodeclick();
            MessageBox.Show("Please enter a name to save file!");
            save();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please select img type, advanced opions beforehand!");
        }

    }
}
