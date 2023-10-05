using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Hamburguesa : Comida
    {

        private static double costoBase;
        private bool esDoble;

        static Hamburguesa()
        {
            Hamburguesa.costoBase = 1500;
        }        

        public Hamburguesa(string nombre) : base(nombre)
        {

        }

        protected override string AgregarIngrediente(EIngredientes ingrediente)
        {
            if (!this.ingredientes.Contains(ingrediente))
            {
                this.ingredientes.Add(ingrediente);
                return $"{ingrediente} agregado a hamburguesa";
            }
            return "Ingrediente ya esta en hamburguesa";
        }

        public override string ToString()
        {
            return this.esDoble ? "Hamburguesa - doble" : "Hamburguesa - simple";
        }

        protected override string MostrarDatos()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.MostrarDatos());
            builder.AppendLine(this.ToString());
            return builder.ToString();
        }

        protected override double CalcularCosto()
        {
            double costoBase = Hamburguesa.costoBase;
            foreach (var item in this.ingredientes)
            {
                costoBase += costoBase * (int)item / 100;                
            }
            return this.esDoble ? costoBase + 500 : costoBase;
        }

        

    }
}
