using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki2017
{
    class Helsinki2017
    {
        static List<Korcsolya> rovidprog = new List<Korcsolya>();
        static List<Korcsolya> donto = new List<Korcsolya>();

        static void Main(string[] args)
        {
            Console.WriteLine("\nA program kezdődik...");

            #region 1.feladat
            StreamReader sr = new StreamReader("rovidprogram.csv", Encoding.Default);
            string fejlec = sr.ReadLine();
            while (!sr.EndOfStream)
            {

                rovidprog.Add(new Korcsolya(sr.ReadLine()));

            }
            sr.Close();

            StreamReader sr1 = new StreamReader("donto.csv", Encoding.Default);
            fejlec = sr1.ReadLine();
            while (!sr1.EndOfStream)
            {

                donto.Add(new Korcsolya(sr1.ReadLine()));

            }
            sr1.Close();

            #endregion

            #region 2.feladat

            Console.WriteLine("\n2.feladat");
            Console.WriteLine($"\tA rövidprogramban {rovidprog.Count} induló volt");

            #endregion

            #region 3.feladat

            Console.WriteLine("\n3.feladat");
            bool bejutott = false;
            for (int i = 0; i < donto.Count; i++)
            {

                if (donto[i]._orszag == "HUN")
                {

                    bejutott = true;

                }

            }
            if (bejutott == true)
            {

                Console.WriteLine("\tA magyar versenyző bejutott a kürbe");

            }
            else
            {

                Console.WriteLine("\tA magyar versenyző nem jutott be a kürbe");

            }

            #endregion

            #region 5.feladat

            Console.WriteLine("5.feladat");

            Console.Write("\tKérem a versenyző nevét: ");
            string bekertnev = Console.ReadLine();
            bool voltilyen = false;
            for (int i = 0; i < rovidprog.Count; i++)
            {

                if (bekertnev == rovidprog[i]._nev)
                {

                    voltilyen = true;

                }

            }
            if (voltilyen == false)
            {

                Console.WriteLine("\tIlyen nevű induló nem volt");

            }

            #endregion

            #region 6.feladat

            Console.WriteLine("6.feladat");
            double osszpont = osszPontSzam(bekertnev);
            Console.WriteLine($"\tA versenyző összpontszáma: {osszpont}");

            #endregion

            #region 7.feladat

            Console.WriteLine("7.feladat");
            List<string> orszag = new List<string>();
            for (int i = 0; i < donto.Count; i++)
            {

                bool szerepel = false;
                for (int j = 0; j < orszag.Count; j++)
                {

                    if (donto[i]._orszag == orszag[j])
                    {

                        szerepel = true;

                    }

                }
                if (szerepel == false)
                {

                    orszag.Add(donto[i]._orszag);

                }

            }

            int[] orszagseged = new int[orszag.Count];
            for (int i = 0; i < donto.Count; i++)
            {

                for (int j = 0; j < orszag.Count; j++)
                {

                    if (donto[i]._orszag == orszag[j])
                    {

                        orszagseged[j]++;

                    }

                }


            }
            for (int i = 0; i < orszagseged.Length; i++)
            {

                if (orszagseged[i] > 1)
                {

                    Console.WriteLine($"\t{orszag[i]} : {orszagseged[i]} versenyző");

                }

            }

            #endregion

            #region 8.feladat

            Console.WriteLine("8.feladat: vegeredmeny.csv");
            StreamWriter sa = new StreamWriter("vegeredmeny.csv", false, Encoding.Default);
            for (int i = 0; i < donto.Count; i++)
            {

                Korcsolya ujkorcsolya = donto[i];
                ujkorcsolya._osszpont = osszPontSzam(donto[i]._nev);
                donto[i] = ujkorcsolya;

            }
            donto = donto.OrderBy(versenyzo => versenyzo._osszpont).ToList();
            donto.Reverse();

            int hely = 1;
            foreach (Korcsolya i in donto)
            {

                sa.WriteLine($"{hely};{i._nev};{i._orszag};{i._osszpont}");
                hely++;
            }
            sa.Close();

            #endregion

            Console.WriteLine("\nA program vége!");
            Console.ReadKey();
        }

        #region 4.feladat

        static double osszPontSzam(string nev)
        {

            double osszPont = 0;
            foreach (Korcsolya i in rovidprog)
            {

                if (i._nev == nev)
                {

                    osszPont += i._techpontszam + i._komppontszam - i._levonas; 

                }

            }

            return osszPont;
        }

        #endregion

    }
}
