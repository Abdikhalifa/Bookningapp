using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    internal class Lokal
    {
        // Egenskaper för namn och kapacitet
        public string Namn { get; set; }
        public int Kapacitet { get; set; }

        // Lista över bokningar för att hålla reda på den periode lokalen är bokad
        private List<(DateTime StartTid, DateTime SlutTid)> bokningar = new List<(DateTime, DateTime)>();

        public Lokal(string namn, int kapacitet )
        {
            Namn = namn;
            Kapacitet = kapacitet;
            
        }
        public virtual void VisaInfo()
        {
            Console.WriteLine($"Namn: {Namn} Kapacitet: {Kapacitet}");

        }
        // Metod för att boka en tid
        public bool Boka(DateTime startTid, DateTime slutTid)
        {
            // Kontrollera om lokalen är tillgänglig under den tiden
            if (ÄrTillgänglig(startTid, slutTid))
            {
                // Lägg till bokningen i listan om lokalen är ledig
                bokningar.Add((startTid, slutTid));
                Console.WriteLine($"Bokning lyckades från {startTid} till {slutTid}");
                return true;
            }
            else
            {
                Console.WriteLine("Lokalen är upptagen under den valda tiden.");
                return false;
            }
        }
        // Metod för att avboka en tid baserat på starttiden
        public bool Avboka(DateTime startTid)
        {
            // Metod för att avboka en tid baserat på starttiden
            var bokning = bokningar.Find(b => b.StartTid == startTid);
            if (bokning != default)
            {
                // Ta bort bokningen om den finns
                bokningar.Remove(bokning);
                return true;
            }

            // Meddela om det inte finns någon bokning att avboka
            Console.WriteLine("Ingen bokning hittades för avbokning.");
            return false;
        }

        // Metod för att kontrollera tillgänglighet
        public bool ÄrTillgänglig(DateTime startTid, DateTime slutTid)
        {
            foreach (var bokning in bokningar)
            {
                if ((startTid < bokning.SlutTid) && (slutTid > bokning.StartTid))
                {
                    // Det finns en krock med en befintlig bokning
                    return false;
                }
            }
            return true; 
        }
    }
}



