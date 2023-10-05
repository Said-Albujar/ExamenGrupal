using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenGrupal
{
    internal class Jugador
    {
        public string nombre;
        public int fuerza;
        public int destreza;
        public int salud;

        public Jugador(string nombre, int fuerza, int destreza, int salud)
        {
            this.nombre = nombre;
            this.fuerza = fuerza;
            this.destreza = destreza;
            this.salud = salud;
        }

        public string MostrarEstadisticas()
        {
            return "Nombre: " + nombre + "\nTus estadísticas:\nFuerza: " + fuerza
                 + "\nDestreza: " + destreza + "\nSalud: " + salud;
        }

        public bool EstaVivo(int estadistica)
        {
            if (estadistica <= 0)
            {
                return false;
            }
            return true;
        }
    }

}
