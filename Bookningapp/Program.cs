using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace Bookningapp
{
    public class Program
    {
        private static BokningS bokningsHanterare = new BokningS();
        private static List<Lokal> lokaler = new List<Lokal>();
        static void Main(string[] args)
        {
            //Lokaler som finns med från start, när man startar programmet. /Rebecca
            //3 "skapade" salar från start
            Sal sal1 = new Sal("Sal 1", 42, true);
            Sal sal2 = new Sal("Sal 2", 35, false);
            Sal sal3 = new Sal("Sal 3",50, true);
            //3 "skapade" salar från start
            Grupprum grupprum1 = new Grupprum("Grupprum 1", 4, false);
            Grupprum grupprum2 = new Grupprum("Grupprum 2", 6, true);
            Grupprum grupprum3 = new Grupprum("Grupprum 3", 8, true);
            //Lägger in dem i listan "lokaler". 
            lokaler.Add(sal1);
            lokaler.Add(sal2); 
            lokaler.Add(sal3);
            lokaler.Add(grupprum1);
            lokaler.Add(grupprum2);
            lokaler.Add(grupprum3);

            //ladda in lokaler från fil vid programstart /Rebecca
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

                    Console.WriteLine("5. Lista bokningar från specifikt år");
                   


                    Console.WriteLine("6. Lista på alla lokaler"); //Med lämpliga egenskaper 
                                                                   //Alla lokaler ska lagras enligt uppgift genom att spara på fil,(Rebecka)
                                                                   //Enklare att boka om denna lista (också) dyker upp när man bokar ny
                                                                   //så man får det man vill ha och inte behöver kolla listan före?


                    Console.WriteLine("7. Lägga till en ny sal");
                    //Borde väl inte kunna göras av elev egentligen?
                    //När ny sal skapas ska programmet säga till om salnamn redan finns

                    Console.WriteLine("8. Lägga till ett nytt grupprum");


                    Console.WriteLine("9. Avsluta");


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
                            RaderaBefintligBokning(); //(Alexandra ? August ?)
                            //Metod med interface 
                            //Interface ska implementeras i "relevanta" klasser
                            //Interface som returtyp

                            break;


                        case "4":
                            bokningsHanterare.ListaAllaBokningar();
                             //(August? Rebecka?)
                            //Använda List<T> för att lagra bokningar när program körs 

                            //Implementera operationer för filtrering och sökning
                            //Filtrering och sökning skulle kunna vara att bara se sina egna
                            //bokningar eller bara se lediga lokaler (som nämnts ovan) men även
                            //filtrering genom att bara se ett visst år
                            //Hantera sortering av bokningar (sortera på år, namn, lokal?)

                            break;

                        case "5":
                            Console.WriteLine("Ange år vilket år du vill kolla bokningar:"); //Ber användaren om år vid sökning efter bokning efter år.
                            if (int.TryParse(Console.ReadLine(), out int år))                 //Rebecca
                                bokningsHanterare.ListaBokningarEfterÅr(år);
                            break;


                        case "6":
                                    ListaAllaLokaler(); //Rebecka?
                                                        //Använda List<T> för att lagra bokningar när program körs 

                                    //Implementera operationer för filtrering och sökning
                                    //Filtrering och sökning skulle kunna vara att bara se sina egna
                                    //bokningar eller bara se lediga lokaler (som nämnts ovan)

                                    return;

                                case "7":
                                    LäggaTillNySal(); //Rebecka?

                                    break;

                                case "8":
                                    LäggaTillNyttGrupprum(); //Rebecka?

                                    break;


                                case "9":
                                    exit = true;
                                    FilHanterare.SparaTillFil(lokaler);//Spara lokaler till fil /Rebecca
                                    Console.WriteLine("Lokaler och bokningar sparade. Programmet avslutas!");
                                    break;

                                default:

                                    Console.WriteLine("Ogiltigt val. Försök igen.");

                                    break;

                                    //Jag gör menyn färdig?
                                    //Ska ha felhantering och kommentarer (överallt) + dokumentation?

                                }
                            }

                }
                //metod för att skapa ny sal /Rebecca
                static void LäggaTillNySal()
                {
                    Console.WriteLine("Ange namn på salen: ");
                    String namn = Console.ReadLine();

                    //Kontrollera att namnet är unikt
                    if (lokaler.Any(l => l.Namn == namn))
                    {
                        Console.WriteLine("En sal med detta namn finns redan, vänligen välj ett annat namn.");
                        return;
                    }

                    Console.WriteLine("Ange kapacitet: ");
                    int kapacitet = int.Parse(Console.ReadLine());
                    Console.WriteLine(" salen en projektor? (ja/nej): ");
                    bool harProjektor = Console.ReadLine().ToLower() == "ja";

                    Sal nySal = new Sal(namn, kapacitet, harProjektor);
                    lokaler.Add(nySal);
                    Console.WriteLine("Ny sal skapad.");
                }

                //metod för att skapa nytt grupprum /Rebecca
                static void LäggaTillNyttGrupprum()
                {
                    Console.WriteLine("Ange namn på grupprummet: ");
                    String namn = Console.ReadLine();

                    //Kontrollera att namnet är unikt
                    if (lokaler.Any(l => l.Namn == namn))
                    {
                        Console.WriteLine("Ett grupprum med detta namn finns redan, vänligen välj ett annat namn.");
                        return;
                    }

                    Console.WriteLine("Ange kapacitet: ");
                    int kapacitet = int.Parse(Console.ReadLine());
                    Console.WriteLine("Har grupprummet en whiteboard? (ja/nej): ");
                    bool harWhiteboard = Console.ReadLine().ToLower() == "ja";

                    Grupprum nyttGrupprum = new Grupprum(namn, kapacitet, harWhiteboard);
                    lokaler.Add(nyttGrupprum);
                    Console.WriteLine("Nytt grupprum skapat.");
                }

                //Metod för att lista alla lokaler (salar och grupprum) / Rebecca
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
                        lokal.VisaInfo();
                    }
                }


            }


        }
    }

