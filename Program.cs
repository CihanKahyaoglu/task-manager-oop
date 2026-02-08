using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Threading;

namespace TaskManager_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\cihan\OneDrive\Desktop\\";
            string file = @"List.txt";
            string full = path + file;
            if(!File.Exists(full))
            {
                Console.WriteLine("LİSTE BULUNAMADI...");
                Thread.Sleep(1000);
                File.Create(full).Close();
                Console.WriteLine("LİSTE OLUŞTURULDU");
            }
            else
                Console.WriteLine("LİSTE BULUNDU");

            List<Task> görevler = new List<Task>();
            while(true)
            {
                Console.WriteLine("----------\n1.Görev Ekle\n2.Listeyi Gör\n3.Düzenle\n4.Çıkış\n----------");
                Console.Write("Hangi İşlem ise Sayısını Giriniz: ");
                int cevap = Int32.Parse(Console.ReadLine());
                if (cevap == 1)
                {
                    Console.Write("Görev Giriniz: ");
                    string baslik = Console.ReadLine();
                    Task yeni = new Task(baslik);
                    görevler.Add(yeni);
                    File.AppendAllText(full, baslik + "-False" + Environment.NewLine);
                }
                else if (cevap == 2)
                {
                    Console.WriteLine("İlk Oturumu: ");
                    string cevap4 = Console.ReadLine().ToLower();
                    if(cevap4 == "evet")
                    {
                        int i = 0;
                        Console.WriteLine("----------");
                        foreach (var görev in görevler)
                        {
                            Console.WriteLine(i + "-" + görev.Baslik + "-" + görev.Tamamlandi);
                            i++;
                        }
                        Console.WriteLine("----------");
                    }
                    else
                    {
                        Console.WriteLine("----------");
                        string list = File.ReadAllText(full);
                        Console.WriteLine(list);
                        Console.WriteLine("----------");
                    }
                }
                else if (cevap == 3)
                {
                    int i = 0;
                    foreach (var görev in görevler)
                    {
                        Console.WriteLine(i + "-" + görev.Baslik + "-" + görev.Tamamlandi);
                        i++;
                    }
                    Console.Write("Hangisini İstiyorsanız Sırasını Yazınız: ");
                    int cevap2 = Int32.Parse(Console.ReadLine());
                    Console.Write("Peki Ne Duruma: ");
                    bool cevap3 = Boolean.Parse(Console.ReadLine());
                    görevler[cevap2].Tamamlandi = cevap3;

                    List<string> satirlar = new List<string>();

                    foreach (var görev in görevler)
                    {
                        satirlar.Add(görev.Baslik + "-" + görev.Tamamlandi);
                    }

                    File.WriteAllLines(full, satirlar);
                }
                else if (cevap == 4)
                    break;
                else
                    Console.WriteLine("TANIMLANAMADI");
            }

        }
    }
}
