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
