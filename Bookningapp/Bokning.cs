using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    class Bokning : IBookable
    {
        public int Bokningsnummer {  get; set; }
        public string Användarnamn { get; set; }

        public DateTime StarttidBokning { get; set; }

        public DateTime SluttidBokning { get; set; }

        public TimeSpan TidslängdBokning => SluttidBokning - StarttidBokning;

        public Bokning(int bokningsnummer, string användarnamn, DateTime starttid, DateTime sluttid)
        { 
            Bokningsnummer = bokningsnummer;   
            Användarnamn = användarnamn;
            StarttidBokning = starttid;
            SluttidBokning = sluttid;
        
        }

        // Skapa en ny bokning
        public void NyBokning()
        {
            Console.WriteLine($"Bokning skapad: {Användarnamn} | Bokningsnummer: {Bokningsnummer} | Starttid: {StarttidBokning} | Sluttid: {SluttidBokning}");
        }

        // Ta bort en bokning
        public void TaBortBokning()
        {
            Console.WriteLine($"Bokning med bokningsnummer {Bokningsnummer} har tagits bort.");
        }

        //Behövs fortfarande en metod för att uppdatera bokning, vet dock inte hur men nånting vi kan lösa på torsdagen kanske


    }
}
