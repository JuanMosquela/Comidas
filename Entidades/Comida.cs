using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace Entidades
{
    public abstract class Comida
    {
        protected List<EIngredientes> ingredientes;
        private string nombre;

        protected Comida(string nombre, List<EIngredientes> ingredientes)
        { 
            this.ingredientes = ingredientes;
            this.nombre = nombre;
        }
        protected Comida(string nombre):this(nombre, new List<EIngredientes>())
        {
            
        }

        public double Costo
        {
            get { return this.CalcularCosto(); }
        }        

        public string Nombre
        {
            get { return this.nombre; } 
        }

        public string Descripcion { get { return this.MostrarDatos(); } }

        protected abstract double CalcularCosto();
        protected abstract string AgregarIngrediente(EIngredientes ingrediente);

        public override bool Equals(object? obj)
        {
            if(obj is Comida aux)
            {                
                if (aux.nombre == this.nombre) return true;
            }
            return false;
        }

        protected virtual string MostrarDatos() 
        {
            StringBuilder builder = new StringBuilder();         
            builder.AppendLine($"Nombre: {this.Nombre}");           
            builder.AppendLine($"Costo: {this.Costo.ToString()}");           
            return builder.ToString();
        }

        public static bool operator == (Comida c, EIngredientes ingrediente)
        {
            return c.ingredientes.Contains(ingrediente);          
        }

        public static bool operator !=(Comida c, EIngredientes ingrediente)
        {
            return !(c == ingrediente);
        }

        public static string operator +(Comida c, EIngredientes ingrediente)
        {
            return c.AgregarIngrediente(ingrediente);            
        }

    }

    public enum EIngredientes
    {
        ADHERESO, 
        LECHUGA = 7,
        CEBOLLA = 8,
        TOMATE = 9,
        QUESO = 10,
        JAMON = 12,
        HUEVO = 13,
        PANCETA = 15
    };
}