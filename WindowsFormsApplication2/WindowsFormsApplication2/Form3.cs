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
    
    public partial class Form3 : Form
    {
        long p, q, n, t, flag,j,i;
        long [] e= new long[100];
        long [] d= new long[100];
      

           
        

    public int prime(long pr)
    {
    int i;
    j = (long)Math.Sqrt(pr);
    
    for (i = 2; i <= j; i++)
    {
        if (pr % i == 0)
            return 0;
    }
    return 1;
    }

    public void mains()
    {
        int z = 0;
        p = (long)numericUpDown1.Value;
        q = (long)numericUpDown2.Value;
        if (prime(p) == 0 || p==0)
        {
            MessageBox.Show("p1 not prime"); z++;
        }
        if (prime(q) == 0 || q == 0)
        {
            MessageBox.Show("p2 not prime"); z++;
        }
        if (p==q)
        {
            MessageBox.Show("p1 and p2 cannot be same"); z++;
        }
        if (z == 0)
        {
            n = p * q;
            t = (p - 1) * (q - 1);

            ce();
            Console.WriteLine("\nPOSSIBLE VALUES OF e AND d ARE\n");

            for (i = 0; i < j - 1; i++)
                richTextBox1.Text += e[i].ToString() + "\t" + d[i].ToString() + "\n";
            
        }
    }

    void ce()
    {

    int k;
    k = 0;
    for (i = 2; i < t; i++)
    {
       // try{
        if (t % i == 0)
            continue;
        flag = prime(i);
        if (flag == 1 && i != p && i != q)
        {
            
            e[k] = i;
            flag = cd(e[k]);
          

            
            if (flag > 0)
            {
                d[k] = flag;
                k++;
            }
            if (k == 99)
                break;

        }
        //}catch (Exception e)
        //{ MessageBox.Show("omg!"); }
    }
    }
long cd(long  x)
{
    long  k = 1;
    while (true)
    {
        k = k + t;
        if (k % x == 0)
            return (k / x);
    }
}



        public Form3()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            richTextBox1.Visible = true;
            label8.Text = "Acceped values of E and D";
           mains();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            label9.Text = numericUpDown3.Value.ToString() + "," + (p * q).ToString();
            label10.Text = numericUpDown4.Value.ToString() + "," + (p * q).ToString();
        }

        public void inis()
        {
            for (int h = 0; h < 100; h++)
            { e[h] = 0; }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please enter 2 desired prime numbers!");
            inis();
        }
      
    }
}
