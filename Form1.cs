using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab1_Task1
{
    public partial class Form1 : Form
    {
        private CipherCore cipherCore = new CipherCore();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFile(richTextBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFile(richTextBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = cipherCore.Encrypt(richTextBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = cipherCore.Decrypt(richTextBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cipherCore.CopyAlphabet(cipherCore.alphabet);
            cipherCore.ShuffleAlphabet(cipherCore.newAlphabet);

            GenerateGrid();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.FileName = "key";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(dlg.FileName, Encoding.UTF8);
                cipherCore.CopyAlphabet(reader.ReadToEnd().ToCharArray());
                reader.Close();
            }

            dlg.Dispose();

            GenerateGrid();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.FileName = "key";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName, false, Encoding.UTF8);
                writer.Write(cipherCore.newAlphabet);
                writer.Close();
            }

            dlg.Dispose();
        }

        private void OpenFile(RichTextBox textField)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.FileName;
                StreamReader reader = new StreamReader(dlg.FileName, Encoding.UTF8);
                textField.Text = reader.ReadToEnd();
                reader.Close();
            }

            dlg.Dispose();
        }

        private void SaveFile(RichTextBox textField)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName, false, Encoding.UTF8);
                writer.Write(textField.Text);
                writer.Close();
            }

            dlg.Dispose();
        }

        private void GenerateGrid()
        {
            dataGridView1.RowCount = cipherCore.alphabet.Length;
            dataGridView1.ColumnCount = 2;
            for (int i = 0; i < cipherCore.newAlphabet.Length; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = cipherCore.alphabet[i];
                dataGridView1.Rows[i].Cells[1].Value = cipherCore.newAlphabet[i];
            }
        }
    }
}