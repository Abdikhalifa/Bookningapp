using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace Bookningapp
{
    public class Program
    {
        private static List<Lokal> lokaler = new List<Lokal>();
        static void Main(string[] args)
        {
            //ladda in lokaler från fil vid programstart
            lokaler = FilHanterare.LäsFrånFil();

            {

                //List<> lokaler = new List<Lokal>();
                //Lägga utanför main? I klassen?
                //Vilka egenskaper finns i listan

                //List<> bokningar = new List<Bokningar>();
                //Bokningar finns inte som klass
                //Kan bokningar läggas in i lokallistan? Förstår det som att det är olika saker
                //eftersom det ska gå att söka på det ena eller det andra? Kanske bara kan rensa i listan med serializing
                //Är det bara interfacet som är kopplingen?


                //Console.WriteLine("Välkommen till bokningssidan för lokaler!");
                bool exit = false;
                while (!exit)

                {
                    Console.Clear(); 
                    Console.Write("Ange namn och tryck enter.");
                    //Om vi skulle lägga detta i meny på Omniway slipper man uppge namn och
                    //programmet skulle i så fall "automatiskt" veta om man är personal eller elev när man loggar in.
                    //Detta kan vara en beskrivning om hur man startar och använder programmet?

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

                    Console.WriteLine("1. Skapa en ny bokning");
                    //Enklare om man kan söka på lediga lokaler


                    Console.WriteLine("2. Uppdatera en befintlig bokning");
                    //Borde bara kunna uppdatera egna?
                    //Enklare om man får se sina egna bokningar (kan funka med alla men mindre användarvänlig)
                    //och välja vilken som ska uppdateras?


                    Console.WriteLine("3. Ta bort en befintlig bokning");
                    //Borde bara kunna ta bort egna?
                    //Enklare om man får se sina egna bokningar och välja vilken som tas bort


                    Console.WriteLine("4. Lista alla bokningar");
                    //Alla bokningar ska lagras? (Rebecka)
                    //Lägga in sortering på ett visst år som en eget menyval eller så kan man göra det när listan visas
                    //Mycket enklare att boka om denna lista (också) dyker upp när man ska boka


                    Console.WriteLine("5. Lista på alla lokaler"); //Med lämpliga egenskaper 
                                                                   //Alla lokaler ska lagras enligt uppgift genom att spara på fil,(Rebecka)
                                                                   //Enklare att boka om denna lista (också) dyker upp när man bokar ny
                                                                   //så man får det man vill ha och inte behöver kolla listan före?


                    Console.WriteLine("6. Lägga till en ny lokal");
                    //Borde väl inte kunna göras av elev egentligen?
                    //När ny sal skapas ska programmet säga till om salnamn redan finns


                    Console.WriteLine("7. Avsluta");

                    Console.WriteLine("Välj ett alternativ");
                    string choice = Console.ReadLine();


                    switch (choice)

                    {
                        case "1":

                            NyBokning(); //engelska?//Alexandra? August?
                            //Metod med interface  
                            //Interface ska implementeras i "relevanta" klasser
                            //Interface som returtyp
                            //DateTime
                            //TimeSpan

                            break;

                        case "2":

                            UppdateraBefintligBokning(); //Alexandra? August?
                            //Metod med interface 
                            //Interface ska implementeras i "relevanta" klasser
                            //Interface som returtyp
                            //DateTime
                            //TimeSpan

                            break;

                        case "3":
                            TaBortBokning(); //(Alexandra ? August ?)
                            //Metod med interface 
                            //Interface ska implementeras i "relevanta" klasser
                            //Interface som returtyp

                            break;

                        case "4":
                            ListaAllaBokningar(); //(August? Rebecka?)
                                                  //Använda List<T> för att lagra bokningar när program körs 

                            //Implementera operationer för filtrering och sökning
                            //Filtrering och sökning skulle kunna vara att bara se sina egna
                            //bokningar eller bara se lediga lokaler (som nämnts ovan) men även
                            //filtrering genom att bara se ett visst år
                            //Hantera sortering av bokningar (sortera på år, namn, lokal?)

                            break;

                        case "5":
                            ListaAllaLokaler(); //Rebecka?
                                                //Använda List<T> för att lagra bokningar när program körs 

                            //Implementera operationer för filtrering och sökning
                            //Filtrering och sökning skulle kunna vara att bara se sina egna
                            //bokningar eller bara se lediga lokaler (som nämnts ovan)

                            return;

                        case "6":
                            LäggaTillNyLokal(); //Rebecka?

                            break;


                        case "7":
                            exit = true;
                            FilHanterare.SparaTillFil(lokaler);//Spara lokaler till fil
                            Console.WriteLine("Lokaler och bokningar sparade. Programmet avslutas!");
                            break;

                        default:

                            Console.WriteLine("Ogiltigt val. Försök igen.");

                            break;

                            //Jag gör menyn färdig?
                            //Ska ha felhantering och kommentarer (överallt) + dokumentation?

                    }

                }
                //Metod för att lista alla lokaler (salar och grupprum)
                static void ListaAllaLokaler()
                    { 
                        if (lokaler.Count == 0)
                        {
                            Console.WriteLine("Inga lokaler finns att visa.");
                            return;
                        }

                    Console.WriteLine("Lista över alla lokaler:");
                    foreach (var lokal in lokaler) 
                    {
                        Console.WriteLine(lokal.VisaInfo());//eventuell fel
                    }
                }
            }


        }
    }
}
