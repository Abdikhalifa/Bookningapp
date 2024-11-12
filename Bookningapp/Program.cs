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
            //ladda in lokaler från fil vid programstart (Rebecca)
            lokaler = FilHanterare.LäsFrånFil();
            //ladda in bokningar från fil vid programstart (August)
            BokningS.Bokningar = FilHanterare.LäsBokningFrånFil();

            //Lokaler som finns med från start, när man startar programmet. (Rebecca)
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

            {

                bool exit = false;
                while (!exit)

                {
                    Console.WriteLine("Meny för lokalbokning");

                    Console.WriteLine("1. Skapa en ny bokning");

                    Console.WriteLine("2. Uppdatera en befintlig bokning");

                    Console.WriteLine("3. Ta bort en befintlig bokning");

                    Console.WriteLine("4. Lista alla bokningar");

                    Console.WriteLine("5. Lista bokningar från specifikt år");

                    Console.WriteLine("6. Lista på alla lokaler");

                    Console.WriteLine("7. Lägga till en ny sal");

                    Console.WriteLine("8. Lägga till ett nytt grupprum");

                    Console.WriteLine("9. Avsluta");
                    Console.WriteLine();

                    Console.WriteLine("Välj ett alternativ");

                    string? choice = Console.ReadLine();

                    Console.Clear();

                    switch (choice)

                    {
                        case "1": //(Alexandra)

                            Console.Write("Ange ditt namn och tryck enter: ");
                            string? användarNamn = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(användarNamn))
                            {
                                Console.WriteLine("Ett namn måste anges för att kunna boka en lokal.");
                                Console.WriteLine("Tryck på valfri knapp för att komma tillbaka till menyn.");
                                Console.ReadKey(true);
                                Console.Clear();
                                break;
                            }

                            while (true)
                            {
                                ListaAllaLokaler();
                                Console.WriteLine();
                                Console.WriteLine("Skriv in namnet på den lokal du vill boka: ");
                                string? strängÖnskadLokal = Console.ReadLine();
                                Lokal? lokal = lokaler.Where(lokal => lokal.Namn == strängÖnskadLokal).FirstOrDefault();

                                if (lokal != null)
                                {
                                    BokningS.NyBokning(strängÖnskadLokal, användarNamn);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Tyvärr, den lokalen hittades inte.");
                                    Console.WriteLine("Tryck på valfri knapp för att försöka igen.");
                                    Console.ReadKey(true);
                                    Console.Clear();

                                }

                            }

                            Console.Clear();
                            break;

                        case "2": //(Abdikani)
                            BokningS.UppdateraBokning();

                            break;

                        case "3": //(Abdikani)
                            BokningS.TaBortBokning();

                            break;


                        case "4": //(Rebecca)
                            bokningsHanterare.ListaAllaBokningar();

                            break;

                        case "5": //(Rebecca)
                            Console.WriteLine("Ange år vilket år du vill kolla bokningar:"); //Ber användaren om år vid sökning efter bokning efter år.
                            if (int.TryParse(Console.ReadLine(), out int år))                 //Rebecca
                                bokningsHanterare.ListaBokningarEfterÅr(år);
                            break;


                        case "6":
                            ListaAllaLokaler(); //(Rebecca)

                            break;

                        case "7":
                            LäggaTillNySal(); //(Rebecca)

                            break;

                        case "8":
                            LäggaTillNyttGrupprum(); //(Rebecca)

                            break;


                        case "9":
                            exit = true;
                            FilHanterare.SparaTillFil(lokaler);//Spara lokaler till fil (Rebecca)
                            FilHanterare.SparaBokningTillFil(BokningS.Bokningar); //Spara bokningar till fil (August)
                            Console.WriteLine("Lokaler och bokningar sparade. Programmet avslutas!");
                            break;

                        default:

                            Console.WriteLine("Ogiltigt val. Försök igen.");

                            break;
                    }
                }

            }

            //metod för att skapa ny sal (Rebecca)
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

                //metod för att skapa nytt grupprum (Rebecca)
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

                //Metod för att lista alla lokaler (salar och grupprum) (Rebecca)
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

