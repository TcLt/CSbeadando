using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileOk += (sender, e) =>
            {
                try
                {
                    using (var sr = new StreamReader(openFileDialog1.FileName))
                    {
                        listBox1.Items.Clear();
                        string sor = sr.ReadLine();
                        textBox1.Text = sr.ReadLine();
                        string sor1 = sr.ReadLine();
                        textBox2.Text = sr.ReadLine();
                        string sor2 = sr.ReadLine();
                        if (sr.ReadLine() == "Nő")
                        {
                            radioButton2.Checked = true;
                            radioButton1.Checked = false;
                        }
                        else
                        {
                            radioButton1.Checked = true;
                            radioButton2.Checked = false;
                        }
                        string sor3 = sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            listBox1.Items.Add(sr.ReadLine());
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Hiba! Nem sikerült a betöltés!");
                }
            };
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox3.Text);
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ez a program tagolva olvassa be a txt-t.\nAz 1, 3, 5, 7. sorokban nem olvas szöveget, mert azokat a kategóriának tartja fent.\nBruh.", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            openFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                saveFileDialog1.ShowDialog();
            }
            else if (textBox1.Text.Length > 0 && textBox2.Text.Length == 0)
            {
                MessageBox.Show("Írja be a nevét!");
            }
            else if (textBox1.Text.Length == 0 && textBox2.Text.Length < 0)
            {
                MessageBox.Show("Írja be a születési dátumát!");
            }
            else if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                MessageBox.Show("Írja be a nevét!");
                MessageBox.Show("Írja be a születési dátumát!");
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                //File.WriteAllLines(openFileDialog1.FileName, lista.Items.Cast<string>().ToArray())
                using (var sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("Név:");
                    sw.WriteLine(textBox1.Text);
                    sw.WriteLine("Születési dátum:");
                    sw.WriteLine(textBox2.Text);
                    if (radioButton1.Checked)
                    {
                        sw.WriteLine("Nem:\nFérfi");
                    }
                    else
                    {
                        sw.WriteLine("Nem:\nNő");
                    }
                    sw.WriteLine("Hobbi:");
                    foreach (var item in listBox1.Items)
                    {
                        
                        sw.WriteLine(item);
                        
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Hiba. Sikertelen mentés!");
            }
        }
    }
}
