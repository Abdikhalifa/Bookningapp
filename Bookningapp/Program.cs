﻿using System.Security.Principal;

namespace Bookningapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {                             
               
                List<> lokaler = new List<Lokal>();
                //Lägga utanför main? I klassen?
                //Vilka egenskaper finns i listan

                List<> bokningar = new List<Bokningar>();
                //Bokningar finns inte som klass
                //Kan bokningar läggas in i lokallistan? Förstår det som att det är olika saker
                //eftersom det ska gå att söka på det ena eller det andra? Kanske bara kan rensa i listan
                //Är det bara interfacet som är kopplingen?
                

                //Console.WriteLine("Välkommen till bokningssidan för lokaler!");
                                             
                while (true)

                {
                    Console.Clear();
                    Console.Write("Ange namn och tryck enter.");
                    //Om vi skulle lägga detta i meny på Omniway slipper man uppge namn och
                    //programmet skulle i så fall "automatiskt" veta om man är personal eller elev när man loggar in.
                    //Detta kan vara en beskrivning om hur man startar och använder programmet?


                    Console.WriteLine("\nVälj vad du vill göra:");

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
                    //När ny sal skapas ska programmet säga till om sal namn redan finns
                    
                    
                    Console.WriteLine("7. Avsluta");


                    string choice = Console.ReadLine();

                    switch (choice)

                    {
                        case "1":

                            AddReservation(); //engelska?//Alexandra? August?
                            //Metod med interface  
                            //Interface ska implementeras i "relevanta" klasser
                            //Interface som returtyp
                            //DateTime
                            //TimeSpan

                            break;

                        case "2":

                            UppdateExistingReservation(); //Alexandra? August?
                            //Metod med interface 
                            //Interface ska implementeras i "relevanta" klasser
                            //Interface som returtyp
                            //DateTime
                            //TimeSpan

                            break;

                        case "3":
                            DeleteExistingReservation(); //(Alexandra ? August ?)
                            //Metod med interface 
                            //Interface ska implementeras i "relevanta" klasser
                            //Interface som returtyp

                            break;

                        case "4":
                            ListAllReservations(); //(August? Rebecka?)
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
                            LäggaTillEnNyLokal(); //Rebecka?

                            break;

                            
                        case "7";
                            Avsluta

                        default:

                            Console.WriteLine("Ogiltigt val. Försök igen.");

                            break;

                            //Jag gör menyn färdig?
                            //Ska ha felhantering och kommentarer (överallt) + dokumentation?

                    }

                }

            }
            static void LäggTillProdukt()

            {
                // TODO: Implementera metod för att lägga till produkt 
                Console.Write("Ange produktnamn: ");
                inventory.Add(Console.ReadLine());
                Console.WriteLine("Produkten har lagts till i inventariet.");
            }

            static void VisaInventarie(List<string> inventory)

            {
                foreach (var item in inventory)
                {
                    Console.WriteLine(item);
                }
                // TODO: Implementera metod för att visa inventarie 

            }

            static void TaBortProdukt()
            {
                Console.Clear();
                string produktToRemove = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(produktToRemove))
                {
                    produktToRemove = produktToRemove.ToLower();
                    inventory.Remove(produktToRemove);
                    Console.WriteLine("Removed: " + produktToRemove);
                }
                else
                {
                    Console.WriteLine("Invalid entry");
                }
            }

            static void SökProdukt()
            {
                bool searchResult = false;
                Console.WriteLine("Skriv in sökord");
                String userSearch = Console.ReadLine();

                while (String.IsNullOrEmpty(userSearch))
                {
                    Console.Clear();
                    Console.WriteLine("Ogiltlig inmatning\n Skriv in sökord");
                    userSearch = Console.ReadLine();
                }
                if (!String.IsNullOrEmpty(userSearch))
                {
                    Console.WriteLine("Resultat:");
                    foreach (var product in inventory)
                    {
                        if (userSearch.ToLower() == product || product.Contains(userSearch))
                        {
                            Console.WriteLine($"Produkt: {product}");
                            searchResult = true;
                        }
                    }
                    if (searchResult == false)
                    {
                        Console.WriteLine("Din sökning gav inget resultat");
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
