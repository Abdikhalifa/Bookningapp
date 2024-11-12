using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO; 

namespace Bookningapp
{
    public static class FilHanterare // (Rebecca)
    {
        private static String sökVäg = "lokaler.json"; // Definerar sökvägen till json-filen där lokaler ska sparas
        private static String bokningarFilVäg = "bokningar.json"; // Filen för att spara bokningar

        //metod för att spara lokaler till en json-fil
        public static void SparaTillFil(List<Lokal> lokaler)
        {
            //konverterar listan av "lokal"-objekt till en såkallad json-sträng
            var json = JsonSerializer.Serialize(lokaler);
            
            //Skriver jason-strängen till filen som anges i sökvägen
            File.WriteAllText(sökVäg, json);
        }

        //metod för att läsa in lokaler från json-fil
        public static List<Lokal> LäsFrånFil()
        {
            
            //kontrollera om filen finns, om inte, retunera en tom lista
            if (!File.Exists(sökVäg)) 
                return new List<Lokal>();  

            //läser in hela json-filen som en sträng
            var json = File.ReadAllText(sökVäg);

            //konverterar json-strängen tillbaka till en lista av "lokaala" objekt och retunerar den
            return JsonSerializer.Deserialize<List<Lokal>>(json);

        }

        // Metod för att spara bokningar till en JSON-fil

        public static void SparaBokningTillFil(List<BokningS> Bokningar)
        {
            //konverterar listan av "lokal"-objekt till en såkallad json-sträng
            var json = JsonSerializer.Serialize(Bokningar);

            //Skriver jason-strängen till filen som anges i sökvägen
            File.WriteAllText(bokningarFilVäg, json);
        }

        //metod för att läsa in bokningar från json-fil
        public static List<BokningS> LäsBokningFrånFil()
        {

            //kontrollera om filen finns, om inte, retunera en tom lista
            if (!File.Exists(bokningarFilVäg))
                return new List<BokningS>();

            //läser in hela json-filen som en sträng
            var json = File.ReadAllText(bokningarFilVäg);

            //konverterar json-strängen tillbaka till en lista av "lokaala" objekt och retunerar den
            return JsonSerializer.Deserialize<List<BokningS>>(json);

        }

    }
    



}

