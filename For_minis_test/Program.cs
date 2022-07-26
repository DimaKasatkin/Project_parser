using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_minis_test
{
    class Program
    {
        static void Main(string[] args)
        {
            test_srav_str();
            Console.ReadKey();
        }

        void con()
        {
            string s1 = "Начните обсуждение!";
            string s2 = "обсуж";
            if (s1.Contains(s2))
                Console.WriteLine("include!");
            else
                Console.WriteLine("not include!");

            // Console.ReadKey();
        }

        static void test_eq()
        {
            string s1 = "Электрочайник Tefal KI760D30";
            string s2 = "Электрочайник Hotpoint-Ariston WK 22M DC0";
            if (s1.Equals(s2))
                Console.WriteLine("eq!");
            else
                Console.WriteLine("not eq!");
            Console.WriteLine(s1[2]);
 

        }

        static void test_srav_str()
        {
            string s1 = "Электрочайник Braun WK 300 Cream";
            string s2 = "Электрочайник Braun WK 300 Onyx";
            Double l = 0;
            Double s = s1.Length > s2.Length ? s2.Length : s1.Length;
            for (int i =0;i< (s1.Length > s2.Length ? s2.Length : s1.Length) ;i++)
            {
                if (s1[i] == s2[i])
                {
                    l++;
                    Console.WriteLine(s1[i]);
                }
                }
            Console.WriteLine("l= " + l + " S=" + s);
            Double y;
y = l / s;
            Console.WriteLine(y);
        }
    }
}/*




         try
            {
                for (int i = 0; i<prods.Count; i++)
                {
                    if (prods[i].Text.Contains("предложен")|| prods[i].Text.Contains("отзы") || prods[i].Text.Contains("объяв"))
                    // if ( prods[i].Text.Contains("обсуж"))
                    {
                        // textBox1.AppendText(prods[i].Text + "\r\n");
                        prods.RemoveAt(i);
                    }
                    if (prods[i].Text.Contains("бсужд"))
                    {
                        // textBox1.AppendText(prods[i].Text + "\r\n");
                        prods.RemoveAt(i);
                    }

                }
                textBox1.AppendText("1 prohod\r\n");
                for (int i = 0; i<prods.Count; i++)
                {

                    if (prods[i].Text.Contains("от"))
                    {
                        // textBox1.AppendText(prods[i].Text + "\r\n");
                        prods.RemoveAt(i);
                    }

                }
                textBox1.AppendText("2 prohod\r\n");
                for (int i = 0; i<prods.Count; i++)
                {

                    if (prods[i].Text.Contains("от"))
                    {
                        // textBox1.AppendText(prods[i].Text + "\r\n");
                        prods.RemoveAt(i);
                    }

                }
                textBox1.AppendText("3 prohod\r\n");
            }
            catch
            {
                MessageBox.Show("Исключение!!!!!!!!!!!!!!!!!");
                //textBox1.AppendText("Исключение!!!!!!!!!!!!!!!!!");              
            }

    */
