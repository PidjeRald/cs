namespace lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            tuskToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            данТекстовыйФайлСодержащийСловаРазделенныеОднимИлиToolStripMenuItem = new ToolStripMenuItem();
            несколькимиПробеламиСоздатьНаЕгоОсновеНовыйФайлСостоящийToolStripMenuItem = new ToolStripMenuItem();
            толькоИзТехСтрокПервогоФайлаКоторыеНеСодержатЗаданноеСловоToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            textBox3 = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, tuskToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, clearToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(141, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(141, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeyDisplayString = "ctrl + s";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(141, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(141, 22);
            saveAsToolStripMenuItem.Text = "SaveAs";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(141, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // tuskToolStripMenuItem
            // 
            tuskToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { runToolStripMenuItem });
            tuskToolStripMenuItem.Name = "tuskToolStripMenuItem";
            tuskToolStripMenuItem.Size = new Size(43, 20);
            tuskToolStripMenuItem.Text = "Tusk";
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(95, 22);
            runToolStripMenuItem.Text = "Run";
            runToolStripMenuItem.Click += runToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { данТекстовыйФайлСодержащийСловаРазделенныеОднимИлиToolStripMenuItem, несколькимиПробеламиСоздатьНаЕгоОсновеНовыйФайлСостоящийToolStripMenuItem, толькоИзТехСтрокПервогоФайлаКоторыеНеСодержатЗаданноеСловоToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // данТекстовыйФайлСодержащийСловаРазделенныеОднимИлиToolStripMenuItem
            // 
            данТекстовыйФайлСодержащийСловаРазделенныеОднимИлиToolStripMenuItem.Name = "данТекстовыйФайлСодержащийСловаРазделенныеОднимИлиToolStripMenuItem";
            данТекстовыйФайлСодержащийСловаРазделенныеОднимИлиToolStripMenuItem.Size = new Size(484, 22);
            данТекстовыйФайлСодержащийСловаРазделенныеОднимИлиToolStripMenuItem.Text = "Дан текстовый файл, содержащий слова, разделенные одним или";
            // 
            // несколькимиПробеламиСоздатьНаЕгоОсновеНовыйФайлСостоящийToolStripMenuItem
            // 
            несколькимиПробеламиСоздатьНаЕгоОсновеНовыйФайлСостоящийToolStripMenuItem.Name = "несколькимиПробеламиСоздатьНаЕгоОсновеНовыйФайлСостоящийToolStripMenuItem";
            несколькимиПробеламиСоздатьНаЕгоОсновеНовыйФайлСостоящийToolStripMenuItem.Size = new Size(484, 22);
            несколькимиПробеламиСоздатьНаЕгоОсновеНовыйФайлСостоящийToolStripMenuItem.Text = "несколькими пробелами. Создать на его основе новый файл, состоящий ";
            // 
            // толькоИзТехСтрокПервогоФайлаКоторыеНеСодержатЗаданноеСловоToolStripMenuItem
            // 
            толькоИзТехСтрокПервогоФайлаКоторыеНеСодержатЗаданноеСловоToolStripMenuItem.Name = "толькоИзТехСтрокПервогоФайлаКоторыеНеСодержатЗаданноеСловоToolStripMenuItem";
            толькоИзТехСтрокПервогоФайлаКоторыеНеСодержатЗаданноеСловоToolStripMenuItem.Size = new Size(484, 22);
            толькоИзТехСтрокПервогоФайлаКоторыеНеСодержатЗаданноеСловоToolStripMenuItem.Text = "только из тех строк первого файла, которые не содержат заданное слово.";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(textBox3);
            splitContainer1.Panel1.Controls.Add(textBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBox2);
            splitContainer1.Size = new Size(800, 426);
            splitContainer1.SplitterDistance = 347;
            splitContainer1.TabIndex = 1;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(0, 0);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(347, 426);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(0, 0);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(449, 426);
            textBox2.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(244, 400);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private SplitContainer splitContainer1;
        private TextBox textBox1;
        private TextBox textBox2;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem tuskToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem данТекстовыйФайлСодержащийСловаРазделенныеОднимИлиToolStripMenuItem;
        private ToolStripMenuItem несколькимиПробеламиСоздатьНаЕгоОсновеНовыйФайлСостоящийToolStripMenuItem;
        private ToolStripMenuItem толькоИзТехСтрокПервогоФайлаКоторыеНеСодержатЗаданноеСловоToolStripMenuItem;
        private TextBox textBox3;
    }
}