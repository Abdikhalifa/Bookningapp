using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    public class BokningS
    {
        //Lista för att spara bokningar (Alexandra)
        public static List<BokningS> Bokningar = new List<BokningS>();
        
        //(August)
        public string Användarnamn { get; set; }
        public string Namn { get; set; }

        public DateTime StarttidBokning { get; set; }

        public DateTime SluttidBokning { get; set; }

        public int Bokningsnummer { get; set; }

        public TimeSpan TidslängdBokning => SluttidBokning - StarttidBokning;
        public BokningS()
        {

        }

        // Konstruktor (Rebecca och August)
        public BokningS(int bokningsnummer, String lokal, String användarnam, DateTime startTid, DateTime slutTid)
        {
            Bokningsnummer = Bokningar.Count + 1;
            Namn = lokal;
            Användarnamn = användarnam;
            StarttidBokning = startTid;
            SluttidBokning = slutTid;
        }
        // Metod för att göra nya bokningar (Alexandra)
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
                try
                {
                    Console.Clear();
                    Console.WriteLine("Skriv in datum och tid som du vill boka i formatet yyyy-MM-dd HH:mm");
                    string? strängdatum = Console.ReadLine();
                    // Bestämmer format för datumsträngen
                    string format = "yyyy-MM-dd HH:mm";

                    önskadStarttidBokning = DateTime.ParseExact(strängdatum, format, null);

                    if (önskadStarttidBokning < DateTime.Now)
                    {
                        Console.WriteLine("Du kan inte boka en tid som redan passerat. Tryck på valfri knapp för att välja en ny tid.");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Du har angett ett felaktigt datumformat. Tryck på valfri knapp för att försöka igen.");
                    Console.ReadKey(true);
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
                else if (doubleBokningslängd > 24)
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
                if (item.Namn == lokal)
                {
                    if (önskadStarttidBokning >= item.StarttidBokning && önskadSluttidBokning <= item.SluttidBokning)
                    {
                        Console.WriteLine("Den önskade lokalen är redan bokad under den önskade tidperioden.");
                        Console.WriteLine("Tryck 1 för att välja ny tid för samma lokal, tryck på annan valfri knapp för att återgå till menyn och boka ny lokal.");

                        string? choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            goto beginning;
                        }
                        Console.ReadKey(true);
                        Console.Clear();

                        return;
                    }
                    else if (önskadStarttidBokning < item.StarttidBokning && önskadSluttidBokning > item.StarttidBokning)
                    {
                        Console.WriteLine("Den önskade lokalen är redan bokad under en del av den önskade tidperioden.");
                        Console.WriteLine("Tryck 1 för att välja ny tid för samma lokal, tryck på annan valfri knapp för att återgå till menyn och boka ny lokal.");
                        Console.ReadKey(true);
                        string? choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            goto beginning;
                        }

                        Console.Clear();

                        return;
                    }
                    else if (önskadStarttidBokning > item.StarttidBokning && önskadStarttidBokning < item.SluttidBokning)
                    {
                        Console.WriteLine("Den önskade lokalen är redan bokad under en del av den önskade tidperioden.");
                        Console.WriteLine("Tryck 1 för att välja ny tid för samma lokal, tryck på annan valfri knapp för att återgå till menyn och boka ny lokal.");

                        string? choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            goto beginning;
                        }
                        Console.ReadKey(true);
                        Console.Clear();

                        return;
                    }
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




        //lista alla bokningar i programmet (Rebecca)
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

        //Lista efter specifikt år (Rebecca)
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

        //Metod för att ta bort en bokning(Abdikani)
        public static void TaBortBokning() 
        {
            Console.WriteLine("Ange bokningsnummer att ta bort: ");
            string inputBokningsNr = Console.ReadLine();
            int bokningsNummer;

            // Kollar om användaren faktiskt skriver ett giltigt nummer
            if (!int.TryParse(inputBokningsNr, out bokningsNummer))
            {
                Console.WriteLine("Det var inte ett giltigt bokningsnummer.Ösäker bokningnummer? kolla på nr4. Försök igen.");
                return;
            }

            // Hitta bokningen med det numret
            BokningS bokning = Bokningar.Find(b => b.Bokningsnummer == bokningsNummer);

            if (bokning != null)
            {
                // Om vi hittar bokningen, ta bort den
                Bokningar.Remove(bokning);
                Console.WriteLine($"Bokning {bokningsNummer} borttagen.");
            }
            else
            {
                // Om vi inte hittar bokningen
                Console.WriteLine("Den bokningen finns inte, försök med ett annat nummer.");
            }
        }

        // Metod för att uppdatera en bokning (Abdikani)
        //public static void UppdateraBokning()
        //{
        //    Console.WriteLine("Ange bokningsnummer att uppdatera: ");
        //    string inputBokningsNr = Console.ReadLine();
        //    int bokningsNummer;

        //    // Kollar om användaren har skrivit ett giltigt bokningsnummer
        //    if (!int.TryParse(inputBokningsNr, out bokningsNummer))
        //    {
        //        Console.WriteLine("Det där var inte ett giltigt bokningsnummer. Ösäker bokningnummer? kolla på nr4. Försök igen.");
        //        return;
        //    }

        //    // Hitta bokningen med det numret
        //    BokningS bokning = Bokningar.Find(b => b.Bokningsnummer == bokningsNummer);

        //    if (bokning != null)
        //    {
        //        // Om vi hittar bokningen, fråga efter ny starttid
        //        DateTime nyStarttid;
        //        Console.WriteLine("Ange ny starttid (YYYY-MM-DD HH:MM): ");
        //        string inputStarttid = Console.ReadLine();
        //        if (!DateTime.TryParse(inputStarttid, out nyStarttid))
        //        {
        //            Console.WriteLine("Det där var inte ett giltigt datumformat. Försök igen.");
        //            return;
        //        }


        //        bokning.StarttidBokning = nyStarttid;

        //        // Fråga efter ny sluttid
        //        DateTime nySluttid;
        //        Console.WriteLine("Ange ny sluttid (YYYY-MM-DD HH:MM): ");
        //        string inputSluttid = Console.ReadLine();
        //        if (!DateTime.TryParse(inputSluttid, out nySluttid))
        //        {
        //            Console.WriteLine("Det där var inte ett giltigt datumformat. Försök igen.");
        //            return;
        //        }
        //        bokning.SluttidBokning = nySluttid;

        //        // Bekräfta att bokningen har uppdaterats
        //        Console.WriteLine($"Bokning {bokningsNummer} uppdaterad till {bokning.StarttidBokning} - {bokning.SluttidBokning}");
        //    }
        //    else
        //    {
        //        // Om vi inte hittar bokningen
        //        Console.WriteLine("Den bokningen finns inte, dubbelkolla numret och försök igen.");
        //    }
        //}
        public static void UppdateraBokning()
        {
            Console.WriteLine("Ange bokningsnummer att uppdatera: ");
            string inputBokningsNamn = Console.ReadLine();
            int bokningsNamn;

            // Kollar om användaren har skrivit ett giltigt bokningsnummer
            if (!int.TryParse(inputBokningsNamn, out bokningsNamn))
            {
                Console.WriteLine("Oj, det där var inte ett giltigt bokningsnummer. Försök igen.");
                return;
            }

            // Hitta bokningen med det numret
            BokningS bokning = Bokningar.Find(b => b.Bokningsnummer == bokningsNamn);

            if (bokning != null)
            {
                // Fråga efter ny starttid och kontrollera krock med andra bokningar
                DateTime nyStarttid;
                Console.WriteLine("Ange ny starttid ");
                string inputStarttid = Console.ReadLine();
                if (!DateTime.TryParse(inputStarttid, out nyStarttid))
                {
                    Console.WriteLine("Oj, det där var inte ett giltigt datumformat. Försök igen.");
                    return;
                }

                // Fråga efter ny sluttid och kontrollera krock med andra bokningar
                DateTime nySluttid;
                Console.WriteLine("Ange ny sluttid  ");
                string inputSluttid = Console.ReadLine();
                if (!DateTime.TryParse(inputSluttid, out nySluttid))
                {
                    Console.WriteLine("Oj, det där var inte ett giltigt datumformat. Försök igen.");
                    return;
                }

                // Kolla om den nya tiden krockar med en annan bokning
                bool tidKrockar = Bokningar.Any(b => b.Bokningsnummer != bokning.Bokningsnummer &&
                                                      b.StarttidBokning < nySluttid &&
                                                      b.SluttidBokning > nyStarttid);

                if (tidKrockar)
                {
                    Console.WriteLine("Den nya tiden krockar med en annan bokning. Försök med en annan tid.");
                    return;
                }

                // Uppdatera bokningen om ingen krock
                bokning.StarttidBokning = nyStarttid;
                bokning.SluttidBokning = nySluttid;

                Console.WriteLine($"Bokning {bokningsNamn} uppdaterad till {bokning.StarttidBokning} - {bokning.SluttidBokning}");
            }
            else
            {
                Console.WriteLine("Den bokningen finns inte, dubbelkolla numret och försök igen.");
            }
        }






    }
}