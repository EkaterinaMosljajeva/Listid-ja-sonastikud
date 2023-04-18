using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listid_ja_sõnastikud
{
    public class StartClass
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();

            List<int> list = new List<int>();
            List<int> list1 = new List<int>();
            for (int i =0;i<rnd.Next(1,100);i++)
            {
                int a = rnd.Next(1,100);
                list.Add(a);
            }
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            list.Insert(0, list[list.Count-1]);
            list.Insert(list.Count, list[1]);
            Console.WriteLine();
            for (int i = 1; i < list.Count-1; i++)
            {
                list1.Insert(i - 1, list[i - 1] + list[i + 1]);
            }
            foreach (int i in list1)
            {
                Console.Write(i + " ");
            }







            while (true)
            {
                Console.WriteLine("\n1-Vaadake maakondi ja pealinnu\n2-Lisa maakond ja linnˇ\n3-Leia pealinn või maakond");
                int o = int.Parse(Console.ReadLine());

                if (o == 0)
                {
                    break;
                }
                else if (o == 1)
                {
                    List<string> list_failist = new List<string>();
                    try
                    {
                        foreach (string rida in File.ReadAllLines(@"..\..\..\TextFile.txt"))
                        {
                            list_failist.Add(rida);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Viga failiga");
                    }
                    string key;
                    string value;
                    Dictionary<string, string> maakond_linn = new Dictionary<string, string>();
                    foreach (var rida in list_failist)
                    {
                        key = rida.Split('-')[0];
                        value = rida.Split('-')[1];
                        maakond_linn.Add(key, value);
                    }
                    foreach (KeyValuePair<string, string> keyValue in maakond_linn)
                    {
                        Console.WriteLine(keyValue.Key + " pealinn on " + keyValue.Value);
                    }
                }
                else if (o==2)
                {
                    try
                    {
                        StreamWriter text = new StreamWriter(@"..\..\..\TextFile.txt", true);
                        Console.WriteLine("Sisesta maakonda nimetus: ");
                        string maakond = Console.ReadLine();
                        Console.WriteLine("Sisesta linn nimetus: ");
                        string linn = Console.ReadLine();
                        string lause = maakond + " - " + linn;
                        text.WriteLine(lause);
                        text.Close();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Viga failiga!");
                    }
                }
                else if (o==3)
                {
                    Console.WriteLine("Sisesta maakond või pealinn");
                    string l = Console.ReadLine();
                }
            }
        }
    }
}
