using System.Security.Principal;

namespace Bookningapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Grupprum grupprum = new Grupprum("Grupprun A", 5, false);
            Sal sal = new Sal("Aulan", 50, true);
            grupprum.VisaInfo();
            sal.VisaInfo();

            // Metod för att uppdatera en bokning
            public void UppdateraBokning()
            {
                Console.WriteLine("Ange bokningsnamn att uppdatera: ");
                int bokningsNamn = int.Parse(Console.ReadLine());
                Bokning bokning = bokningar.Find(b => b.Bokningsnamn == bokningsNamn);

                if (bokning != null)
                {
                    Console.WriteLine("Ange ny starttid (YYYY-MM-DD HH:MM): ");
                    bokning.Starttid = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Ange ny sluttid (YYYY-MM-DD HH:MM): ");
                    bokning.Sluttid = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine($"Bokning {bokningsNamn} uppdaterad till {bokning.Starttid} - {bokning.Sluttid}");
                }
                else
                {
                    Console.WriteLine("Bokning hittades inte.");
                }
            }

            //List<Lokal> bokning = new List<Lokal>();

            //Console.WriteLine("Välkommmen till bokningappen ");

            //string val = " ";

            //while (true)
            //{
            //    Console.WriteLine("1. Lista lokar ");
            //    Console.WriteLine("2. skapa bokning ");
            //    Console.WriteLine("3. Visa alla bokningar för Grupprum ");
            //    Console.WriteLine(" \nVälj ett alternativ:");
            //    val = Console.ReadLine();

            //    if (val == "1")
            //    {
            //        ListaLokaler();
            //    }
            //    else if (val == "2")
            //    {
            //        SkapaBokning();

            //    }
            //    else if (val == "3")
            //    {
            //        VisaBokningar();
            //    }

            //}
            //static void ListaLokaler()
            //{
            //    Console.WriteLine("Här listar vi alla lokaler.");
            //    // Implementera kod för att lista alla skapade lokaler
            //}

            //static void SkapaBokning()
            //{
            //    Console.WriteLine("Här skapas en ny bokning.");
            //    // Implementera kod för att skapa en ny bokning
            //}

            //static void VisaBokningar()
            //{
            //    Console.WriteLine("Här visas alla bokningar.");
            //    // Implementera kod för att visa alla bokningar
            //}

        }
    }
}
