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
                Console.Write("Cual es tu nombre? ");
                pName = Console.ReadLine();
                loop = true;
                while (loop)
                {
                    Console.Write("Cuanta fuerza tiene tu personaje? (" + PuntosStats + " puntos restantes) ");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice > PuntosStats)
                    {
                        Console.WriteLine("No tienes puntos suficientes! Intentalo denuevo.");
                    }
                    else
                    {
                        pStrength = choice;
                        PuntosStats -= pStrength;

                        Console.Write("Cuanta agilidad tiene tu personaje? (" + PuntosStats + " puntos restantes) ");
                        int choice2 = int.Parse(Console.ReadLine());
                        if (choice2 > PuntosStats)
                        {
                            Console.WriteLine("No tienes puntos suficientes! Intentalo denuevo.");
                        }
                        else
                        {
                            pDexterity = choice2;
                            PuntosStats -= pDexterity;

                            Console.Write("Cuanta vida tiene tu personaje? (" + PuntosStats + " puntos restantes) ");
                            int choice3 = int.Parse(Console.ReadLine());
                            if (choice3 > PuntosStats)
                            {
                                Console.WriteLine("No tienes puntos suficientes! Intentalo denuevo.");
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
                Jugador player = new Jugador(pName, pStrength, pDexterity, pHealth);
                Console.WriteLine("Perfecto! Tu eres:\n" + player.MostrarEstadisticas());

                Console.WriteLine("[Presentación de la aventura]");
                loop = true;
                while (loop)
                {
                    if (!escenario1)
                    {
                        Console.WriteLine("Tienes tres opciones/caminos. A/B/C");
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
                                SituacionMala("[Consecuencia C]", ref player.salud, "de Vida", 5);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (!escenario2)
                        {
                            Console.WriteLine("Tienes otras tres opciones/caminos. A/B/C");
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
                                    SituacionMala("[Consecuencia C]", ref player.salud, "de Vida", 5);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            if (!escenario3)
                            {
                                Console.WriteLine("Tienes otras tres opciones/caminos mas. A/B/C");
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
                                        SituacionMala("[Consecuencia C]", ref player.salud, "de Vida", 5);
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
                                    Console.WriteLine("Moriste tratando de escapar de este lugar. PERDISTE\n Quieres intentarlo denuevo? [Y/N]");
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
                                            Console.WriteLine("Por favor selecciona una opcion valida.");
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
                     stat -= resultado;
                     if (player.EstaVivo(player.salud))
                     {
                         Console.WriteLine(efecto + "\nConsequence: -" + resultado + " " +
                         statName + "\n" + player.MostrarEstadisticas()); ;
                     }
                     else
                     {
                         Console.WriteLine("Tu personaje murio! Perdiste.");
                         loop = false;

                     }
                }
            }
        }
    }
}
