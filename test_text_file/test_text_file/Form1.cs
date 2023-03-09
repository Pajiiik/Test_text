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

namespace test_text_file
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int CZK(int input)
        {
            return input * 22;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog otevirac = new OpenFileDialog();
            File.Create("best.txt");
            if (otevirac.ShowDialog() == DialogResult.OK && otevirac.CheckPathExists)
            {
                int counter = 0;
                using (StreamReader sr = new StreamReader(otevirac.FileName))
                {
                    int nejlepsi = 0;
                    int zeny = 0;
                    string text;   
                    int y = 0;
                    int pocet = 0;
                    int soucet = 0;
                    while (!sr.EndOfStream)
                    {    
                        int position = 0;
                            
                        string number = "";
                    text = sr.ReadLine();
                    if (counter != 0)
                    { 
                        text = string.Join(" ", text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                         
                        for (int i = 0; i < 4;)
                        {
                            
                            if (text[position].ToString() == " ")
                            {
                                i++;
                                   
                                if (i == 2)
                                {
                                        if (text[position + 1] == 'F')
                                        {
                                            zeny++;
                                        }
                                }
                                if (i == 3)
                                {
                                        pocet++;
                                        soucet = soucet + int.Parse((text[position + 1] + (text[position + 2]).ToString()));
                                }
                                if (i == 4)
                                {
                                    while(position < text.Length)
                                    {
                                      number = number + text[position].ToString();
                                      
                                      position++;
                                    }
                                        if (y == 0)
                                        {
                                            nejlepsi = CZK(int.Parse(number));
                                            y++;
                                        }
                                        else if (CZK(int.Parse(number)) > nejlepsi)
                                        {
                                            nejlepsi = CZK(int.Parse(number));
                                        }
                                        //MessageBox.Show(CZK(int.Parse(number)).ToString() + "CZK");

                                }
                            }                      
                             position++;
                            }    
                            
                    }
                    counter++;
                    }
                    MessageBox.Show(zeny.ToString());
                    using (StreamWriter sw = new StreamWriter("../best.txt"))
                    {
                        sw.WriteLine(nejlepsi);
                        sw.WriteLine(soucet / pocet);
                    }
                }

            }
        }
    }
}
