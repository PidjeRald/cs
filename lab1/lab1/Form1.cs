namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private string name = "NAN";

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (name != "NAN")
            {
                StreamWriter tw = new StreamWriter(name);
                tw.Write(textBox1.Text);
                tw.Close();
            }
            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox1.Text = File.ReadAllText(name);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (name != "NAN")
            {
                string word;
                if (textBox3.Text == "")
                {
                    word = "apple";
                }
                else
                {
                    word = textBox3.Text;
                }
                // ��������� ��� ������ �� ��������� �����
                string[] lines = File.ReadAllLines(name);
                // ������� ����� ���� ��� ������
                string outputFilePath = "output";
                StreamWriter writer = new StreamWriter(outputFilePath);
                // �������� �� ������ ������ ��������� �����
                foreach (string line in lines)
                {
                    // ���� ������ �� �������� �������� �����, �� ���������� �� � ����� ����
                    if (!line.Contains(word))
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.Close();
                textBox2.Text = File.ReadAllText(outputFilePath);
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}