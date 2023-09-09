using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asdfasdf
{
    public partial class Form1 : Form
    {
        Form2 frm2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            frm2.acces = textBox1.Text;
            frm2.ShowDialog();
            textBox1.Text = frm2.acces;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
