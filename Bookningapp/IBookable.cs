using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookningapp
{
    internal interface IBookable
    {
        string Användarnamn { get; set; }  //Ska detta tas in varje gång eller räcker det med en gång innan menyn
                                          
        int Bokningsnummer { get; } //Behöver vara unikt och inte random(?). 

        //När kan det vara lämpligt att interface används som returtyp? (Tekniskt krav på användning)
        //Vilka klasser implementerar interface, är det bara Bokning (om vi har en sån klass)
        //Lista 

        //Lokalnamn från Lokal  //Namn i Lokal ändras till Lokalnamn?
        //Tillgänglighet från Lokal?

        DateTime StarttidBokning { get; set; }
        DateTime SluttidBokning { get; set; } //inget set om det räknas ut i programmet

        TimeSpan TidslängdBokning { get; set; } //inget set om det räknas ut i programmet
        
        void NyBokning();
        //Listan på bokningar visas? (annan metod) Det bör framgå i listan vilken lokaltyp som bokats
        //Uppgifter om vilken lokal (först namn? välja grupprum/sal först?) +
        //Start och sluttid (eller start + längd på bokning?) tas in i metoden (+ ev. Användarnamn)
        //Datum och tid ska "formateras på användarvänligt sätt",
        //längden på bokningen ska användas på något sätt
        //Kontroll sker mot lista med bokningar/lokaler (ska tillgänglighet ligga under Lokal?)
        //Om tiden är bokad meddelas det och användaren får göra en ny bokning
        //Bokningen sparas i listan och ges ett bokningsnummer?,
        //inget returneras mer än text som bekräftar att bokningen skett (inkl. bokningsnummer?)

        void UppdateraBokning(); //OBS! Tagit bort "befintlig", kolla vad Rebecka gjort?
        //Namn tas in? (behövs inte om det sker innan menyn)
        //Visar lista på egna (alla?) bokningar med nummer på bokningen, lokalnamn och datum/tid
        //Användare uppger bokningsnummer på det som ska ändras
        //Användare får knappa in sal, start och sluttid igen.
        //Kontroll sker mot lista med bokningar/lokaler (tillgänglighet ligger under Lokal?)
        //Om tiden är bokad meddelas detta och användaren väljer ny
        //Bokningen uppdateras i listan,
        //text bekräftar att bokningen ändrats
        
        void TaBortBokning();
        //Namn tas in? (behövs inte om det sker innan menyn)
        //Visar lista på egna (eller alla?) bokningar med nummer på bokningen, lokalnamn och datum/tid
        //Användare uppger bokningsnummer på det som ska tas bort
        //Bokningen raderas i listan 
        //text bekräftar att bokning raderats

        //Metod för lista med bokningar?
        //Bokningslista är en lista av lokaler(basklassen) som vardera har en lista av typen Bokning?

    }

}
