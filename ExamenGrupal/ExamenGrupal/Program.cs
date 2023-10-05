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
            bool banana = false;

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

                Console.WriteLine("¡Oh no! ¡Has sido capturado por los marcianos! Te encuentras dentro de un platillo volador... En frente tuyo puedes ver un escritorio cromado dónde descansan tres herramientas...");
                loop = true;
                while (loop)
                {
                    if (!escenario1)
                    {
                        Console.WriteLine("A. Una Banana B. Un bisturí C. Una pistola laser. ¿Cuál recogerás?");

                        string choice = Console.ReadLine().ToLower();
                        switch (choice)
                        {
                            case "a":
                                Situacion("[¡Has conseguido una banana! Una merienda muy rica en potasio.]");
                                banana = true;
                                escenario1 = true;
                                break;
                            case "b":
                                Situacion("[Has conseguido un bisturí. ¿Para que quieres eso? Mira, hasta está roto. Creo que eres un poco tonto.]");
                                escenario1 = true;
                                break;
                            case "c":

                                SituacionMala("[Cuando tomas la pistola láser, te das cuenta de lo complicada que es. Una maquinación inhumana, que parece no tener ni principio ni final. Te confundes, te confundes muchísimo]", ref player.salud, "Health", 20);
                                escenario1 = true;

                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (!escenario2)
                        {
                            Console.WriteLine("Consigues tu fiel herramienta. Ahora... Hay tres puertas por las que puedes ir. Una roja... Una azul... Y una verde. ¿Los marcianos tienen sentido del color? Eso es definitivamente interesante... Ahora... ¿A qué puerta irás? A.La roja B.La azul C.La verde. ");

                            string choice = Console.ReadLine().ToLower();
                            switch (choice)
                            {
                                case "a":
                                    Situacion("[Pasas a un laboratorio... Este parece estar vacio. Si no fuera por los cadáveres horripilantes en cada una de las mesas cromadas... Y eso... ¿Sangre? No. Jugo de tomate. Y esos no son cadáveres, son muñecos de hule. Increíble. Los marcianos son una raza superior. definitivamente... ]");
                                    escenario2 = true;
                                    break;
                                case "b":
                                    Situacion("[Te encuentras en un salón lleno de globos y luces. ¿Una pista de baile? Increíble. Los marcianos te capturaron ya... Y lo hicieron bailando rica chá. ¿Sabías que así llaman en Marte al Chachachá?]");
                                    escenario2 = true;
                                    break;
                                case "c":
                                    if (banana == true)
                                    {
                                        Situacion("[Pasas por la puerta y te encuentras con una sala de operaciones. Aquí, un marciano de espaldas, se voltea a verte. Puedes ver sus enormes y negros ojos... Su escuálido cuerpo... Sientes terror... Y sin embargo... ¡Eureka! Una idea. Sacas de tu bolsillo la banana y la apuntas al marciano. El marciano grita de terror y explota en mil pedazos de... ¿Confetti? Te has salvado... Por poco.]");
                                        escenario2 = true;
                                    }
                                    else
                                    {
                                        Situacion("[Pasas por la puerta y te encuentras con una sala de operaciones. Aquí, un marciano de espaldas, se voltea a verte. Puedes ver sus enormes y negros ojos... Su escuálido cuerpo... Sientes terror... El terror de que tu muerte se avecina... El marciano mira directamente hacia tus ojos... Puedes sentir tu interior quemando... Y de repente... ¡Pum! Explotas en mil y un pedacitos de confetti]");
                                        SituacionMala("..." , ref player.salud, "Health", 100);

                                    }

                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            if (!escenario3)
                            {
                                Console.WriteLine("[Tras haber sobrevivido a tal intensa interacción, llegas a una habitación. Detrás tuyo ves las mismas puertas que antes. Al parecer todas llevaban al mismo lado. Qué diseñadores y programadores tan listos. Sigues por delante. Encuentras una máquina carnosa y llena de tentáculos. No hay opción mas que entrar a esta. Así lo haces, dándote cuenta que esta estaba cubierta en una sustancia babosa. Ew. Dentro de este teletransportador encuentras tres botones. El botón A. tiene la silueta de una vaca. El botón B. tiene la silueta de un chimpancé. El botón C. tiene la silueta de un tiburón. ¿Cuál botón apretarás?]");

                                string choice = Console.ReadLine().ToLower();
                                switch (choice)
                                {
                                    case "a":
                                        Situacion("[El teletransportador te teletransporta... (Qué cliché) a una habitación completamente blanca y repleta de vacas hasta el techo. Casi ni te puedes mover. Lo único que ves son vacas. Lo único que hueles son vacas. Lo único que sientes son vacas.]");
                                        break;
                                    case "b":
                                        if (banana == true)
                                        {
                                            Situacion("[El teletransportador te teletransporta... (Qué cliché) a una habitación completamente blanca. Los huéspedes de esta eran un grupo de chimpancés. Los cuáles te miran fijamente. Sus ojos se dilatan. Saben lo que tienes contigo. Los primates se abalanzan en tu contra. ¿Tengo que describir lo que pasa después?]");
                                            SituacionMala("...", ref player.salud, "Health", 100);
                                        }
                                        else
                                        {
                                            Situacion("[El teletransportador te teletransporta... (Qué cliché) a una habitación completamente blanca. Los huéspedes de esta eran un grupo de chimpancés. Los cuáles te miran fijamente. Estos se acercan a ti, de manera relajada. Empiezan a toquetearte el pelo y a sacarte uno que otro piojo para después comérselo. Qué criaturas tan amigables ¿no crees?]");
                                                escenario3 = true;
                                        }
                                        break;
                                    case "c":

                                        Situacion("[El teletransportador te teletransporta... (Qué cliché) a una habitación completamente blanca y llena de agua... Puedes ver delante tuyo a un tiburón... Un animal que Hollywood te ha vendido como una máquina de matar al acecho... Pero en realidad los tiburones son bastante amigables. Es más, me atrevería a apostar que tenías menos posibilidades con las vacas y los chimpancés. No molestas al tiburón y el no te molesta a ti... Pasas de largo]");

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
                        Console.WriteLine("Has muerto... Tu aventura ha llegado a su fin... Y sin embargo... Tanto pudo haber cambiado... Solo te queda preguntarte... ¿Serías capaz de escapar del platillo si tuvieras otra oportunidad?");
                         loop = false;

                     }
                }
            }
        }
    }
}
