using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Task_8._1_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string addmin(string s, int n)
        {
            int k = s.IndexOf(":");
            int has = Convert.ToInt32(s.Substring(0, k));
            int min = Convert.ToInt32(s.Substring(k + 1, 2));
            min = min + n;
            if (min >= 60)
            {
                has = has + (min / 60);
                min = min % 60;
            }
            if (has >= 24)
            {
                has = 0;
            }
            string h, m;
            if (has < 10)
            {
                h = "0" + has.ToString();
            }
            else
                h = has.ToString();

            if (min < 10)
            {
                m = "0" + min.ToString();
            }
            else
                m = min.ToString();

            string w = h + ":" + m;
            return w;
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                string s = "Мальчик проснулся в 11:50, а должен был проснуться в 09:00.";
                Regex r = new Regex("[0-2][0-9]:[0-6][0-9]");
                MatchCollection h = r.Matches(s);
                foreach (Match u in h)
                {
                    string s2 = addmin(u.Value, n);
                    s = s.Replace(u.Value, s2);
                }
                textBox2.Text += s;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }
    }
}
