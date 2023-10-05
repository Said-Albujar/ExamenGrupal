using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGrupal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pName = "";
            int pStrength = 0;
            int pDexterity = 0;
            int pHealth = 0;
            int PuntosStats = 100;
            bool Inicio = true;
            bool loop = false;
            bool escenario1 = false;
            bool escenario2 = false;
            bool escenario3 = false;

            while (Inicio)
            {
                //bool loop = false;
                Console.Write("What is your name? ");
                pName = Console.ReadLine();
                loop = true;
                while (loop)
                {
                    Console.Write("What is your strength? (" + PuntosStats + " points remaining) ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice > PuntosStats)
                    {
                        Console.WriteLine("You don't have that many points! Try again.");
                    }
                    else
                    {
                        pStrength = choice;
                        PuntosStats -= pStrength;

                        Console.Write("How much dexterity would you say you have? (" + PuntosStats + " points remaining) ");
                        int choice2 = int.Parse(Console.ReadLine());
                        if (choice2 > PuntosStats)
                        {
                            Console.WriteLine("You don't have that many points! Try again.");
                        }
                        else
                        {
                            pDexterity = choice2;
                            PuntosStats -= pDexterity;

                            Console.Write("How much health do you want? (" + PuntosStats + " points remaining) ");
                            int choice3 = int.Parse(Console.ReadLine());
                            if (choice3 > PuntosStats)
                            {
                                Console.WriteLine("You don't have that many points! Try again.");
                            }
                            else
                            {
                                pHealth = choice3;
                                PuntosStats -= pHealth;
                                loop = false;
                            }
                        }
                    }
                }
               // Jugador player = new Jugador(pName, pStrength, pDexterity, pHealth);
               // Console.WriteLine("Perfect! You are:\n" + player.ShowStats());

                Console.WriteLine("[Presentación de la aventura]");
                loop = true;
                while (loop)
                {
                    if (!escenario1)
                    {
                        Console.WriteLine("Tienes tres opciones/caminos/lo que sea. A/B/C");
                        string choice = Console.ReadLine().ToLower();
                        switch (choice)
                        {
                            case "a":
                                Situacion("[Consecuencia A]");
                                break;
                            case "b":
                                Situacion("[Consecuencia B]");
                                escenario1 = true;
                                break;
                            case "c":
                              //  SituacionMala("[Consecuencia C]", ref player.health, "Health", 5);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (!escenario2)
                        {
                            Console.WriteLine("Tienes otros tres opciones/caminos/lo que sea. A/B/C");
                            string choice = Console.ReadLine().ToLower();
                            switch (choice)
                            {
                                case "a":
                                    Situacion("[Consecuencia A]");
                                    escenario2 = true;
                                    break;
                                case "b":
                                    Situacion("[Consecuencia B]");
                                    break;
                                case "c":
                                  //  SituacionMala("[Consecuencia C]", ref player.health, "Health", 5);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            if (!escenario3)
                            {
                                Console.WriteLine("Tienes OTROS OTROS tres opciones/caminos/lo que sea. A/B/C");
                                string choice = Console.ReadLine().ToLower();
                                switch (choice)
                                {
                                    case "a":
                                        Situacion("[Consecuencia A]");
                                        break;
                                    case "b":
                                        Situacion("[Consecuencia B]");
                                        escenario3 = true;
                                        break;
                                    case "c":
                                   //     SituacionMala("[Consecuencia C]", ref player.health, "Health", 5);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                bool quit = true;
                                while (quit)
                                {
                                    Console.WriteLine("You died trying to escape this place. GAME OVER\nRetry? [Y/N]");
                                    string choice = Console.ReadLine().ToLower();
                                    switch (choice)
                                    {
                                        case "y":
                                            escenario1 = false;
                                            escenario2 = false;
                                            escenario3 = false;
                                            loop = false;
                                            quit = false;
                                            PuntosStats = 100;
                                            break;
                                        case "n":
                                            quit = false;
                                            loop = false;
                                            Inicio = false;
                                            break;
                                        default:
                                            Console.WriteLine("Please select a valid option.");
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                void Situacion(string efecto)
                {
                    Console.WriteLine(efecto);
                }
                void SituacionMala(string efecto, ref int stat, string statName, int resultado)
                {
                    /* stat -= resultado;
                     if (player.IsAlive(player.health))
                     {
                         Console.WriteLine(efecto + "\nConsequence: -" + resultado + " " +
                         statName + "\n" + player.ShowStats()); ;
                     }
                     else
                     {
                         Console.WriteLine("Tu personaje murio! Perdiste.");
                         loop = false;

                     }*/
                }
            }
        }
    }
}
