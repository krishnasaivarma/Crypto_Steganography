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
    public partial class Form2 : Form
    {
        
       public long p, q, n, t, flag,j,i,pt, ct, k, len, key;
       Bitmap image;
        long [] temp= new long[1000];
        long [] m= new long[1000];
        long [] en= new long[1000];
        long[] mn = new long[1000];
        char [] msg= new char[1000];
        char[] hi = new char[1000];
        string msgs = "", skey, kkr, info, info2;

        public void xoring()
        {
            string input = msgs;
            string key = skey;
           // MessageBox.Show(skey);
            String result;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            { sb.Append((char)(input[i] ^ key[(i % key.Length)])); }
            result = sb.ToString();
            msgs = result;
        }


        public void save()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Image Files (*.png, *.jpg) | *.png; *.jpg";
            saveFile.InitialDirectory = @"C:\Users\metech\Desktop";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = saveFile.FileName.ToString();
                pictureBox1.ImageLocation = textBoxFilePath.Text;

              image.Save(textBoxFilePath.Text);
            }
            progressBar1.Value =100;
        }


        public void qrscaner()
        {

            
            Bitmap img = new Bitmap(textBoxFilePath.Text);

            int div = img.Width / 20;
            int s11 = (int)numericUpDown3.Value * div;
            int s12 = (int)numericUpDown4.Value * div;
            int s21 = (int)numericUpDown5.Value * div;
            int s22 = (int)numericUpDown6.Value * div;

            for (int i = s11; i < s21; i++)
            {
                for (int j = s21; j < s22; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (pixel.R>127&&pixel.G>127&&pixel.B>127)
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
                string ss = info.Substring(0,8);
                string ss2 = info.Substring(8,info.Length-8);
                info2 += convertbyte(ss);
                ss=ss2;
            }


        }

        public void textuploader()
        {
            ofd.Filter = "Text Files (*.txt) | *.txt";
            
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ofdtxt = ofd.FileName;
                textBox1.Text = ofdtxt;
            }
            progressBar1.Value = 10;
        }
        
        public void imguploader()
               {
            ofd.Filter = "Image Files (*.png, *.jpg) | *.png; *.jpg";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ofdimg = ofd.FileName;
                textBoxFilePath.Text = ofdimg;
            }
            progressBar1.Value = 60;
            Image i1 = Image.FromFile(textBoxFilePath.Text);
            pictureBox1.Image = i1;
        }

        public void combine()
        {
            int ass = 0,l = 0;

            ///*
            hi = msgs.ToCharArray();
            foreach (char cv in hi)
            { en[l] = Convert.ToInt32(cv); l++; }

            // */
            Bitmap img = new Bitmap(textBoxFilePath.Text);
            

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    if (i < 1 && j < textBoxMessage.TextLength)
                    {
                        Console.WriteLine("R = [" + i + "][" + j + "] = " + pixel.R);
                        Console.WriteLine("G = [" + i + "][" + j + "] = " + pixel.G);
                        Console.WriteLine("G = [" + i + "][" + j + "] = " + pixel.B);

                      //  char letter = Convert.ToChar(textBoxMessage.Text.Substring(j, 1));
                      //  int value = Convert.ToInt32(letter);
                        int value = (int)en[ass];
                        ass++;


                        int red, green, blue;
                        rgbseperator(out red, out green, out blue, pixel.R, pixel.G, pixel.B, value);

                        // Console.WriteLine("letter : " + letter + " value : " + value);

                        img.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }

                    if (i == img.Width - 1 && j == img.Height - 1)
                    {
                        int red, green, blue, value = textBoxMessage.TextLength;
                        rgbseperator(out red, out green, out blue, pixel.R, pixel.G, pixel.B, value);
                        img.SetPixel(i, j, Color.FromArgb(red, green, blue));
                       // MessageBox.Show("Done!");
                    }

                }
            }
            image = img;

            
        }

    public void encrypt()
        {
            int l = 0;
            foreach (char cv in msg)
            { m[l] = Convert.ToInt32(cv); l++; }
    
    Console.WriteLine("done2");
    i = 0;
    len = msg.Length;

  
    while (i != len)
    {
        pt = m[i];
        pt = pt - 96;
        k = 1;
        for (j = 0; j < key; j++)
        {
            k = k * pt;
            k = k % n;
        }


        en[i] = k + 96;
        
        i++;
     }
    
    Console.WriteLine("done3");
        en[i] = -1;
        //THE ENCRYPTED MESSAGE
        for (i = 0; en[i] != -1; i++)
        {
            Console.WriteLine(en[i].ToString());
            msgs += (char) en[i];
        }
       //Console.WriteLine("done4");
       // textBoxMessage.Text = msgs;

       
       // for(int ass=0;en[ass]!=-1;ass++)
        //{ Console.WriteLine(en[ass].ToString()); }

    }
        
        public void seperator(out int a, out int b, out int c, int n)
        {
            a = (n - (n % 100)) / 100;
            n %= 100;
            b = (n - (n % 10)) / 10;
            n %= 10;
            c = n;
        }

        public string convertbyte(string ss)
        {
            List<Byte> bytelist = new List<Byte>();
            bytelist.Add(Convert.ToByte(ss));
            return ss;
        }

        public void rgbseperator(out int red, out int green, out int blue, int rr, int gg, int bb, int value)
        {
            int a, b, c;
            seperator(out a, out b, out c, value);
            red = rr - (rr % 10) + a;
            if (red > 255)
                red -= 10;
            green = gg - (gg % 10) + b;
            if (green > 255)
                green -= 10;
            blue = bb - (bb % 10) + c;
            if (blue > 255)
                blue -= 10;
        }

        public OpenFileDialog ofd = new OpenFileDialog();
        public string ofdtxt, ofdimg;
        public Form2()
        {
            InitializeComponent();
        }
     

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = checkBox1.Checked;

        }
        private void encodebutton()
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            button2.Enabled = true;
            key = (long)numericUpDown1.Value;
            n = (long)numericUpDown2.Value;
            msg = textBoxMessage.Text.ToCharArray();
            Console.WriteLine("done1");
            encrypt();
            
            if (radioButton2.Checked == true)
            {
                skey = numericUpDown3.Value.ToString();
                skey += numericUpDown4.Value.ToString();
                skey += numericUpDown5.Value.ToString();
                skey += numericUpDown6.Value.ToString();
                xoring();
                qrpoints();
            }
            kkr=msgs;
            textBoxMessage.Text = msgs;
            progressBar1.Value = 50;
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            encodebutton();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = numericUpDown2.Value = 0;
        }


        private void button9_Click(object sender, EventArgs e)
        {
           //need to click button 6 if textbox 1 is empty and error if not an address
            textBoxMessage.LoadFile(@textBox1.Text, RichTextBoxStreamType.PlainText);
        }

 

        

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 13;
            numericUpDown2.Value = 77;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            panel1.Visible = checkBox1.Checked;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            imguploader();

            button4.Enabled = true;
        }
        public void qrscanner() { }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            combine();
            progressBar1.Value = 90;
            save();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            textuploader();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please select img type, advanced opions beforehand!");
        }

        private void button11_Click(object sender, EventArgs e)
        {
                MessageBox.Show("Please upload any text file!");
                textuploader();
                encodebutton();
                qrscanner();
                MessageBox.Show("Please upload any image!");
                imguploader();
                combine();
                progressBar1.Value = 90;
                MessageBox.Show("Please enter a name to save file!");
                save();
            
         
        }


        public void qrpoints()
        {
            
            msg = skey.ToCharArray();
            encrypt();
            kkr += msgs;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = radioButton2.Checked;
            Random rnd = new Random();
            numericUpDown3.Value = rnd.Next(1, 10);
            numericUpDown4.Value = rnd.Next(1, 10);
            numericUpDown5.Value = rnd.Next(10, 21);
            numericUpDown6.Value = rnd.Next(10, 21);
            
        }

     

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

      



        
      





      

    }

    
}
