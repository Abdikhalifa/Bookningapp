﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    public class BokningS
    {

        public static List<BokningS> Bokningar = new List<BokningS>();
        //public int Bokningsnummer { get; set; }
        public string Användarnamn { get; set; }
        public string Namn { get; set; }

        public DateTime StarttidBokning { get; set; }

        public DateTime SluttidBokning { get; set; }

        public int Bokningsnummer { get; set; }

        public TimeSpan TidslängdBokning => SluttidBokning - StarttidBokning;
        public BokningS()
        {

        }

        public BokningS(int bokningsnummer, String lokal, String användarnam, DateTime startTid, DateTime slutTid)
        {
            Bokningsnummer = Bokningar.Count + 1;
            Namn = lokal;
            Användarnamn = användarnam;
            StarttidBokning = startTid;
            SluttidBokning = slutTid;
        }
        public static void NyBokning(string lokal, string användarnamn)
        {
            DateTime önskadStarttidBokning;
            TimeSpan önskadBokningslängd = new TimeSpan();
            DateTime önskadSluttidBokning;

        //Etikett 
        beginning:
            //Tar in startdatum för bokningen
            while (true)
            {

                Console.WriteLine("Skriv in datum och tid som du vill boka i formatet yyyy-MM-dd HH:mm");
                string? strängdatum = Console.ReadLine();

                //Konvertera till DateTime, kontrollerar om det är rätt format och det får inte vara ett datum som passerat)
                try
                {
                    DateTime.TryParse(strängdatum, out önskadStarttidBokning);
                    if (önskadStarttidBokning < DateTime.Now)
                    {
                        Console.WriteLine("Du kan inte boka tider som redan passerats.");
                        continue;
                    }

                    break;
                }
                catch
                {
                    Console.WriteLine("Ogiltigt datumformat. Försök igen.");
                }

            }

            //Tar in tidslängd på bokning
            while (true)
            {
                double doubleBokningslängd;

                Console.WriteLine("Ange hur många timmar du vill boka lokalen (skriv till exempel 1,5 för en timme och 30 minuter)");
                //Kontrollera om siffror skrivits:
                try
                {
                    doubleBokningslängd = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du måste ange siffror");
                    continue;
                }

                //Kontroll ifall negativa siffror eller för högt tal angivits
                if (doubleBokningslängd <= 0)
                {
                    Console.WriteLine("Du får inte ange 0 eller en negativ tid");
                    continue;
                }
                else if (doubleBokningslängd > 24) //För lite?
                {
                    Console.WriteLine("Du får boka en lokal i max ett dygn i taget");
                    continue;
                }

                //Konvertera till TimeSpan 
                try
                {
                    önskadBokningslängd = TimeSpan.FromHours(doubleBokningslängd);
                    break;
                }
                catch
                {
                    Console.WriteLine("Ogiltigt format. Försök igen.");

                }
            }
            //Räknar ut sluttid på bokningen
            önskadSluttidBokning = önskadStarttidBokning.Add(önskadBokningslängd);

            //Kontrollerar om önskad tid krockar med befintlig bokning av lokalen
            foreach (var item in Bokningar)
            {
                if (önskadStarttidBokning < item.StarttidBokning && önskadSluttidBokning > item.SluttidBokning && item.Namn == lokal)
                {
                    Console.WriteLine("Den önskade lokalen är redan bokad under hela eller en del av den önskade tidperioden.");
                    Console.WriteLine("Tryck 1 för att välja ny tid för samma lokal, tryck på annan valfri knapp för att återgå till menyn och boka ny lokal.");

                    string? choice = Console.ReadLine(); //Erbjuda möjlighet att direkt uppge ny tid på vald lokal?

                    if (choice == "1")
                    {
                        goto beginning;  //Console.Clear?
                    }
                    Console.ReadKey(true);
                    Console.Clear();

                    return;
                }

            }
            //Skapar ny instans av bokningsklassen och lägger till i listan för bokningar
            //BokningS bokning = new BokningS(lokal, användarnamn, önskadStarttidBokning, önskadSluttidBokning);
            int nyttBokningsnummer = Bokningar.Count + 1;
            BokningS bokning = new BokningS(nyttBokningsnummer, lokal, användarnamn, önskadStarttidBokning, önskadSluttidBokning);
            Bokningar.Add(bokning);

            Console.WriteLine($"Lokalen {lokal} har bokats mellan {önskadStarttidBokning} och {önskadSluttidBokning}");
            Console.WriteLine("Tryck på valfri knapp för att återgå till menyn.");
            Console.ReadKey(true);
        }



        //lista alla bokningar i programmet / Rebecca
        public void ListaAllaBokningar()
        {
            if (Bokningar.Count == 0)
            {
                Console.WriteLine("Inga bokningar finns.");
                return;
            }

            foreach (var bokning in Bokningar)
                Console.WriteLine(bokning);
        }

        //Lista efter specifikt år /Rebecca
        public override string ToString()
        {
            return $"Bokningsnummer: {Bokningsnummer}, Lokal: {Namn}, " +
                   $"Användarnamn: {Användarnamn}, Starttid: {StarttidBokning}, " +
                   $"Sluttid: {SluttidBokning}, Tidslängd: {TidslängdBokning.TotalHours} timmar";
        }
        public void ListaBokningarEfterÅr(int år)
        {
            var årligBokning = Bokningar.Where(b => b.StarttidBokning.Year == år).ToList();

            if (årligBokning.Count == 0)
            {
                Console.WriteLine($"Inga bokningar finns för året {år}.");
                return;
            }

            foreach (var bokning in årligBokning)
                Console.WriteLine(bokning);

        }

        // Metod för att ta bort en bokning
        public void TaBortBokning()
        {
            Console.WriteLine("Ange bokningsnummer att ta bort: ");
            int bokningsNamn = int.Parse(Console.ReadLine());
            BokningS bokning = Bokningar.Find(b => b.Bokningsnummer == bokningsNamn); // Söker i listan efter bokningen med det angivna numret

            if (bokning != null) // Kollar om vi hittade en bokning
            {
                Bokningar.Remove(bokning); // Tar bort bokningen från listan
                Console.WriteLine($"Bokning {bokningsNamn} borttagen.");
            }
            else
            {
                Console.WriteLine("Bokning hittades inte."); // Om vi inte hittar bokningen, säg till användaren
            }
        }
        // Metod för att uppdatera en bokning
        public void UppdateraBokning()
        {
            Console.WriteLine("Ange bokningsnamn att uppdatera: ");
            int bokningsNamn = int.Parse(Console.ReadLine());
            BokningS bokning = Bokningar.Find(b => b.Bokningsnummer == bokningsNamn);

            if (bokning != null)
            {
                Console.WriteLine("Ange ny starttid (YYYY-MM-DD HH:MM): ");
                bokning.StarttidBokning = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Ange ny sluttid (YYYY-MM-DD HH:MM): ");
                bokning.SluttidBokning = DateTime.Parse(Console.ReadLine());

                Console.WriteLine($"Bokning {bokningsNamn} uppdaterad till {bokning.StarttidBokning} - {bokning.SluttidBokning}");
            }
            else
            {
                Console.WriteLine("Bokning hittades inte.");
            }
        }
    }
}

//// Lista för att hålla alla bokningar (med start- och sluttid för varje bokning)
//private List<(DateTime StartTid, DateTime SlutTid)> bokningar;


//// Konstruktor som skapar en tom lista för bokningar
//public BokningS()
//{
//    bokningar = new List<(DateTime StartTid, DateTime SlutTid)> ();
//}


//// Kontrollerar om lokalen är ledig under en viss period
//public bool ÄrTillgänglig(DateTime startTid, DateTime slutTid)
//{
//    foreach (var bokning in bokningar)
//    {
//        if((startTid < bokning.SlutTid) && (slutTid > bokning.StartTid))
//        {
//            return false;
//        }
//    }
//    return true;
//}

//// Lägger till en bokning om lokalen är ledig under den angivna tiden
//public bool läggTillBokning(DateTime startTid, DateTime slutTid)
//{
//    if (ÄrTillgänglig (startTid, slutTid))
//    {
//        bokningar.Add((startTid, slutTid));
//        Console.WriteLine($"boknig lyckades från {startTid} till {slutTid}");
//        return true;
//    }
//    Console.WriteLine($"lokalen är upptagen under den tiden");
//    return false;
//}

////Tar bort en bokning baserat på starttid
//public bool TaBortBokning(DateTime startTid)
//{
//    var bokning = bokningar.Find(b => b.StartTid == startTid);
//    if (bokning != default)
//    {
//        bokningar.Remove(bokning);
//        Console.WriteLine("bokning avbokad");
//        return true;
//    }
//    Console.WriteLine($"Ingen bokning hittades ");
//    return false;
//}