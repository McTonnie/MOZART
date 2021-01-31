using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace MOZART
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] mfiler = new string[176];

            for (int i = 0; i < 176; i++)
            {
            mfiler[i] = @"C:\Users\Olive\Desktop\H1\Wave\M" + (i + 1).ToString() + ".wav";

            }
            string[] tfiler = new string[176];
            for (int i = 0; i < 96; i++)
            {
                tfiler[i] = @"C:\Users\Olive\Desktop\H1\Wave\T" + (i + 1).ToString() + ".wav";
            }
            SoundPlayer sp = new SoundPlayer();


            //foreach (string musik in tfiler)
            //{
            //Console.WriteLine("afspillern " + musik);
            //sp.SoundLocation = musik;
            //sp.Load();
            //sp.PlaySync();
            //}


            //minuetten
            int[,] minuetten = new int[11, 16];
            minuetten = tabelberegner(176, 11, 16);
            Console.WriteLine("Minuet tal");
            Console.WriteLine();
            //printer tal ud i minuetten
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(minuetten[i,j] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Trioen tal");
            int[,] trioen = new int[6, 16];
            trioen = tabelberegner(96, 6, 16);
            //printer talne ud der er i trioen
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(trioen[i, j] + " ");
                }
            }
            Console.ReadLine();
            //her afspiller jeg stykket
            Random rdn = new Random();
            for (int i = 0; i < 16; i++)
            {
                int tal = rdn.Next(1, 11);
                int minuettal = minuetten[tal, i];
                Console.WriteLine("afspillern " + mfiler[minuettal]);
                sp.SoundLocation = mfiler[minuettal];
                sp.Load();
                sp.PlaySync();
            }
            for (int i = 0; i < 16; i++)
            {
                int tal = rdn.Next(0, 6);
                int triotal = trioen[tal, i];
                Console.WriteLine("afspillern " + tfiler[triotal]);
                sp.SoundLocation = tfiler[triotal];
                sp.Load();
                sp.PlaySync();
            }





        }
        private static int[,] tabelberegner(int antaltal, int rækker, int kolonner)
        {

            Random rdn = new Random();

            int[] tal = new int[antaltal];

            //int forsøg = 1; //brugt til fejlfinding
            //der er 176 filer
            //her tjekker den om det alerede fides det tal den har trukket
            tal[0] = rdn.Next(0, antaltal + 1);
            for (int i = 1; i < antaltal; i++)
            {
                int temp;
                bool nyttal = true;
                do
                {
                    temp = rdn.Next(0, antaltal + 1);
                    foreach (int number in tal)
                    {


                        if (temp == number)
                        {
                            nyttal = false;
                            break;
                        }
                        else
                        {
                            nyttal = true;
                        }
                    }
                    //Console.WriteLine(" Den har prøvet igen " + forsøg.ToString() + " gange"); //brugt til fejlfinding
                    //forsøg++;
                } while (nyttal == false);
                tal[i] = temp;
            }
            //Array.Sort(tal); brugt til at teste at det samme tal ikke var der 2 gange

            int[,] talout = new int[rækker, kolonner];
            for (int i = 0; i < rækker; i++)
            {
                for (int j = 0; j < kolonner; j++)
                {
                    talout[i, j] = tal[(i * kolonner) +  j];
                }
            }
            return talout;
        }
    }
}
