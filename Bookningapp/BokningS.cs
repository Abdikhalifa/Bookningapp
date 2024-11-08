using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bookningapp
{
    public class BokningS //: IBookable //Behöver ev lokal som moderklass för att komma åt lokalnamnspropertyn?
    {
        // Lista för att hålla alla bokningar (med start- och sluttid för varje bokning)
        //private List<(DateTime StartTid, DateTime SlutTid)> bokningar;

        public static List<BokningS> Bokningar  = new List<BokningS>();
        //public int Bokningsnummer { get; set; }
        public string Användarnamn { get; set; }
        public string Namn {  get; set; }

        public DateTime StarttidBokning { get; set; }

        public DateTime SluttidBokning { get; set; }

        public TimeSpan TidslängdBokning => SluttidBokning - StarttidBokning;
        public BokningS()
        {
            
        }

        public BokningS(/*int bokningsnummer,*/ string namn, string användarnamn, DateTime starttid, DateTime sluttid)
        {
            //Bokningsnummer = bokningsnummer;
            Namn = namn;
            Användarnamn = användarnamn;
            StarttidBokning = starttid;
            SluttidBokning = sluttid;

        }
        public void NyBokning(Lokal namn)  //Här körs alternativet att ta in lokalnamnet i Program innan metodanropet istället för i metoden
        {
            /*while (true)
            {
                //Visa lista på alla befintliga bokningar (Förslagsvis framgår av lokalnamnet om det är sal eller grupprum) 
                //Ska denna del läggas utanför whileloop?:
                foreach (BokningS bokning in Bokningar) //Ska vara lista för lokaler
                {
                    Console.WriteLine($"{bokning.Namn} "); //Antal platser och andra egenskaper

                }
                Console.WriteLine();
                Console.WriteLine("Skriv in namnet på den lokal du vill boka: ");  //Ha en siffra vid lokalnamnet som kan anges istället?
                string? stringÖnskadLokal = Console.ReadLine();
                BokningS önskadLokal = 
                
                //Konvertera sträng till Bokning (Lokal?)
                BokningS lokal = Bokningar.Find(lokal => lokal == önskadLokal);

                if (lokal != null)
                {*/
                    
                    DateTime önskadStarttidBokning;
                    while (true)
                    {
                        Console.WriteLine("Skriv in datum och tid som du vill boka i formatet yyyy-MM-dd HH:mm");
                        string strängdatum = Console.ReadLine();
                       
                        //Konvertera till DateTime (kontrollera om det är rätt format, det får inte heller vara ett datum som passerat(?))
                        try
                        {
                            DateTime.TryParse(strängdatum, out önskadStarttidBokning);

                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Ogiltigt datumformat. Försök igen.");
                        }

                    }

                    Console.WriteLine("Ange hur många timmar du vill boka lokalen (skriv till exempel 1,5 för en timme och 30 minuter)");
                    double doubleBokningslängd = Convert.ToDouble(Console.ReadLine());
                    TimeSpan önskadBokningslängd = new TimeSpan();

                    //Konvertera till TimeSpan (kontrollera om rätt format och inte för lång tid eller minustid)
                    try
                    {
                        önskadBokningslängd = TimeSpan.FromHours(doubleBokningslängd);
                    }
                    catch
                    {
                        Console.WriteLine("Ogiltigt format. Försök igen.");

                    }
                    

                    DateTime önskadSluttidBokning = önskadStarttidBokning.Add(önskadBokningslängd);


                     //Kontrollera om lokalen har bokad under den tiden
            //            BokningS lokal = Bokningar.Where(lokal => lokal.Namn == strängÖnskadLokal).FirstOrDefault();
    
            {
                foreach (var item in Bokningar)
                {
                    if (önskadStarttidBokning < item.StarttidBokning && önskadSluttidBokning > item.SluttidBokning && item.Namn  != namn.Namn) ;
                    {
                        Console.WriteLine("Den önskade lokalen är redan bokad under hela eller en del av den önskade tidperioden.\nVälj ny lokal eller försök boka lokalen under en annan tid.");
                        break;
                    }
                else
                    {

                    }   //Om en bokning hittas som går in i nya bokningen avbryts loopen och 
                        // Användaren får välja på att boka annan tid eller annan lokal (kräver fler loopar?)

               }
            }
               

                    //(if (starttid ny >= sluttid befintlig || sluttid ny <= starttid befintlig) kan bokningen läggas till i listan)

                }
                //Om användaren skriver in en lokal som inte finns
                /*else
                {
                    Console.WriteLine("Tyvärr, den lokal du angivit finns inte. Tryck på valfri knapp för att försöka igen.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
            Console.WriteLine("Lokalen --- har bokats mellan ... och ....");
        }
        public void UppdateraBokning()
        {

        }

        public void TaBortBokning()
        {
            Console.WriteLine($"Bokning med bokningsnummer {Bokningsnummer} har tagits bort.");
        }

        // Konstruktor som skapar en tom lista för bokningar

        /*public BokningS()
        {
            bokningar = new List<(DateTime StartTid, DateTime SlutTid)> ();
        }


        // Kontrollerar om lokalen är ledig under en viss period
        public bool ÄrTillgänglig(DateTime startTid, DateTime slutTid)
        {
            foreach (var bokning in bokningar)
            {
                if((startTid < bokning.SlutTid) && (slutTid > bokning.StartTid))
                {
                    return false;
                }
            }
            return true;
        }

        // Lägger till en bokning om lokalen är ledig under den angivna tiden
        public bool läggTillBokning(DateTime startTid, DateTime slutTid)
        {
            if (ÄrTillgänglig (startTid, slutTid))
            {
                bokningar.Add((startTid, slutTid));
                Console.WriteLine($"boknig lyckades från {startTid} till {slutTid}");
                return true;
            }
            Console.WriteLine($"lokalen är upptagen under den tiden");
            return false;
        }
        */
        // Tar bort en bokning baserat på starttid
        /*public bool TaBortBokning(DateTime startTid)
        {
            var bokning = bokningar.Find(b => b.StartTid == startTid);
            if (bokning != default)
            {
                bokningar.Remove(bokning);
                Console.WriteLine("bokning avbokad");
                return true;
            }
            Console.WriteLine($"Ingen bokning hittades ");
            return false;
        }*/
        // Skapa en ny bokning
        /*public void NyBokning()
        {
            Console.WriteLine($"Bokning skapad: {Användarnamn} | Bokningsnummer: {Bokningsnummer} | Starttid: {StarttidBokning} | Sluttid: {SluttidBokning}");
        }
        */
        // Ta bort en bokning


    
    

    }
}
