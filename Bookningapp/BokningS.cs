using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    public class BokningS
    {
        // Lista för att hålla alla bokningar (med start- och sluttid för varje bokning)
        private List<(DateTime StartTid, DateTime SlutTid)> bokningar;

        // Konstruktor som skapar en tom lista för bokningar
        public BokningS()
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

        // Tar bort en bokning baserat på starttid
        public bool TaBortBokning(DateTime startTid)
        {
            var bokning = bokningar.Find(b => b.StartTid == startTid);
            if(bokning != default)
            {
                bokningar.Remove(bokning);
                Console.WriteLine("bokning avbokad");
                return true;
            }
            Console.WriteLine($"Ingen bokning hittades ");
            return false;
        }

        //lista alla bokningar i programmet
        public void ListaAllaBokningar()
        {
            if (bokningar.Count == 0)
            {
                Console.WriteLine("Inga bokningar finns.");
                return;
            }

            foreach (var bokning in bokningar)
                Console.WriteLine(bokning);
        }

        //Lista efter specifikt år 
        public void ListaBokningarEfterÅr(int år)
        {
            var årligBokning = bokningar.Where(b => b.StartTid.Year == år).ToList();

            if (årligBokning.Count == 0)
            {
                Console.WriteLine($"Inga bokningar finns för året {år}.");
                return;
            }

            foreach (var bokning in årligBokning) 
                Console.WriteLine(bokning);
        }
    }
}
