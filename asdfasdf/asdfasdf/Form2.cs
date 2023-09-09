using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace asdfasdf
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string acces
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
