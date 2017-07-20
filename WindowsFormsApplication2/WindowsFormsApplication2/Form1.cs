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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public int z =0;
      
        private void eNCODEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
        }

        private void dECODEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.MdiParent = this;
            f4.Show();
        }

        private void rSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aBOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a C#.NET applicaion where you can encode and decode messages using public key cryptosystem and steganograhy\n\n\tIt uses RSA algorithen of public key cryptosystem in phase one encoding with desired public and private keys\n\n\tNext we use a (optional) new way of QR encrypion in phase 2 for a additional security\n\n\tFinally we use a enhansed LSB technique to encode cypher text into the desired QR/simple image\n\n\tThis program lets you upload desired textfile to encrypt or can wright one in app only, you can encrypt using RSA with desired key and can also check keys in RSA calculater, you can encrypt it into QR on any images of your wish.", "About");
        }

        private void hELPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RSA Calc: \n\t1)Enter 2 primes and press computeE button to find E,D keys\n\t2)Enter desired keys from choice and press Generate keys for keys\nEncode: \n\t1)Select advanced options to change default keys.\n\t2)Choose simple image or QR image\n\t3)Press encode button to encode text\n\t4)Press upload button to upload image\n\t5)Press combine button to combine img and cypher and save\n\t6)Press one step enc button to do 3-5 steps at once\nDecode: \n\t1)Choose simple image or QR image\n\t2)Select advanced options to change default keys.\n\t3)Press upload button to upload cypher image\n\t4)Press seperate button to seperate img and cypher\n\t5)Press decode button to decode text\n\t6)Press save button to save message to a text file\n\t7)Press one step dec button to do 3-6 steps at once\nAbout: \n\tExplanes functionalites of the app and features of it.\nHelp: \n\tExplanes how to work with application.", "Help");
        }

       

      
    }
}
