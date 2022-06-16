using System;
using System.Globalization;

namespace KnyguKlase
{ 
    internal class Program
    {
        // Čia yra pastovūs kintamieji/reikšmės (konstantos), pvz.: failo pavadinimas
        const string FailoPavadinimas = "knygu sarasas2.csv";
        static void Main(string[] args)
        {
            Knyga knyga = new Knyga("95 - 6351 - 575 - 7", "El Sanción Creyente", "Turner Sandoval Loya", 1944, "Línea Editorial", "Chile", 56.8m);

            Console.WriteLine(knyga.ToString());


            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine("Išvestas knygų sarašas: ");

            List<Knyga> knygos = NuskaitoKnygasIsFailo();

            IsvestiVisasKnygas(knygos);

            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine("Visų knygų pavadinimai: ");
             
            IsvestiVisuKnyguPavadinimus(knygos);

            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine("Knygų kainų vidurkis: ");
            Console.WriteLine(KnyguKainuVidurkis(knygos));

            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine("Iš sarašo surasta seniausia knyga: ");
            Knyga seniausiaKnyga = SeniausiaKnyga(knygos);
            Console.WriteLine(seniausiaKnyga.ToStringPavadinimas() + seniausiaKnyga.ToStringKaina() + seniausiaKnyga.ToStringLeidimoMetai());

            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine("Atpigintos knygos kurios išleistos anksčiau nei 1960m.: ");
            AtpigintuKnygaKuriIsleistaAnksciau1960(knygos);
        }
        /// <summary>
        /// Nuskaito visas knygas iš tekstinio failo (naudojant dar papildomą konvertavimo eilutės į Knygos funkciją)
        /// </summary>
        /// <returns>Grąžina knygų sąrašą.</returns>
        static List<Knyga> NuskaitoKnygasIsFailo()
        {
            List<Knyga> knygos = new List<Knyga>();
            string[] eilutes = System.IO.File.ReadAllLines(FailoPavadinimas);

            foreach (string eilute in eilutes.Skip(1).ToArray())
            {
                knygos.Add(KonvertuojaEiluteKnygu(eilute));
            }
            return knygos;
        }
        /// <summary>
        /// Konvertuoja vieną tekstinę (String) eilutę į Knygos objektą
        /// </summary>
        /// <param name="eilute">String eilutė, kurią nuskaito iš tekstinio failo ir atsiunčia šitai funkcijai</param>
        /// <returns>Grąžina Knygos objektą</returns>
        static Knyga KonvertuojaEiluteKnygu(string eilute)
        {  
            Knyga knyga = new Knyga();

            string[] stulpeliai = eilute.Split(';');

            knyga.Isbn = stulpeliai[0];
            knyga.Pavadinimas = stulpeliai[1];
            knyga.Autorius = stulpeliai[2];
            knyga.LeidimoMetai = Convert.ToInt32(stulpeliai[3]);
            knyga.Leidejas = stulpeliai[4];
            knyga.Salis = stulpeliai[5];
            knyga.Kaina = Convert.ToDecimal(stulpeliai[6]);

            return knyga;
        }
        /// <summary>
        /// Išvedu visą knygų sarašą į konsolę
        /// </summary>
        /// <param name="listas"></param>
        static void IsvestiVisasKnygas(List<Knyga> listas)
        {
            foreach (Knyga elementas in listas)
            {
                Console.WriteLine(elementas);
            }
        }
        /// <summary>
        /// Išvedu iš knygos sarašo visų knygų pavadinimus
        /// </summary>
        /// <param name="knygos"></param>
        static void IsvestiVisuKnyguPavadinimus(List<Knyga> knygos)
        {
            foreach(Knyga knyga in knygos)
            {
                Console.WriteLine(knyga.ToStringPavadinimas());
            }
        }
        /// <summary>
        /// Suskaičiuoju knygų kainų sumą.
        /// </summary>
        /// <param name="knygos"></param>
        /// <returns>Grąžina kainų sumą</returns>
        static decimal KnyguSuma(List<Knyga> knygos)
        {
            decimal knyguSuma = 0;
            foreach(Knyga knyga in knygos)
            {
                knyguSuma += knyga.Kaina;
            }
            return knyguSuma;
        }
        /// <summary>
        /// Suskaičiuoju kainų vidurkį
        /// </summary>
        /// <param name="knygos"></param>
        /// <returns>Grąžina kainų vidurkį</returns>
        static double KnyguKainuVidurkis(List<Knyga> knygos)
        {
            double knyguVidurkis;
            knyguVidurkis = (double) KnyguSuma(knygos) / knygos.Count;
            return knyguVidurkis;
        }
        /// <summary>
        /// Ieškau seniausios knygos iš sarašo
        /// </summary>
        /// <param name="knygos"></param>
        /// <returns></returns>
        static Knyga SeniausiaKnyga (List<Knyga> knygos)
        {
            Knyga seniausiaKnyga = knygos[0];
            foreach (Knyga knyga in knygos)
            {
                if (knyga.LeidimoMetai < seniausiaKnyga.LeidimoMetai)
                {
                    seniausiaKnyga = knyga;
                }
            }
            return seniausiaKnyga;
        }
        static void AtpigintuKnygaKuriIsleistaAnksciau1960 (List<Knyga> knygos)
        {
            
            foreach (Knyga knyga in knygos)
            {
                if (knyga.LeidimoMetai < 1960)
                {
                    knyga.KainaPerPuse();
                    Console.WriteLine(knyga);

                }
            }
        }
    }
} 