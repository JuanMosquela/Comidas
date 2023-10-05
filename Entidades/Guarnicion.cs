using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Guarnicion : Comida
    {
        public enum Etipo
        {
            PAPAS_FRITAS =1000,
            ENSALADA_RUSA = 750,
            ENSALADA_MIXTA = 500
        }
        private Etipo tipo;

        public Guarnicion():this(Etipo.PAPAS_FRITAS){}

        private Guarnicion(Etipo tipo):base(tipo.ToString())
        {        
            this.tipo = tipo;            
        }

        protected override double CalcularCosto()
        {
            double costo = 0;
            double valorBase = 0;
            switch (this.tipo)
            {
                case Etipo.PAPAS_FRITAS:  valorBase = 1000; break;   
                case Etipo.ENSALADA_MIXTA: valorBase = 500; break;
                case Etipo .ENSALADA_RUSA: valorBase = 750; break;
            }

            foreach (var item in this.ingredientes)
            {
                costo += valorBase * (int)item / 100;
            }
            return costo;
        }

        protected override string AgregarIngrediente(EIngredientes ingrediente)
        {
            if (!this.ingredientes.Contains(ingrediente) && this == ingrediente)
            {
                this.ingredientes.Add(ingrediente);
                return $"Se agrego {this.ingredientes} a su guarnicion";
            }
            return $"No se pudo agregar {this.ingredientes} a su guarnicion";
        }

        protected override string MostrarDatos()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.MostrarDatos());
            builder.AppendLine(this.ToString());
            return builder.ToString();
        }

        public override string ToString()
        {
            return $"Guarnicion de tipo {this.tipo}";
        }

        public static bool operator == (Guarnicion guarnicion, EIngredientes ingrediente)
        {            
            return ingrediente == EIngredientes.PANCETA || ingrediente == EIngredientes.ADHERESO || ingrediente == EIngredientes.QUESO; 
        }
        public static bool operator !=(Guarnicion guarnicion, EIngredientes ingrediente)
        {
            return !(guarnicion == ingrediente);
        }



    }
}
