using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        private int dni;
        private List<Comida> menu;
        
        private Cliente(int dni)
        {
            this.dni = dni;
            this.menu = new List<Comida>();
        }

        private double TotalAPagar
        {
            get { return 1; }
        }

        public static Cliente GetCliente(int dni)
        {
            return (Cliente)dni;
        }

        public Comida BuscarComida(Comida comida)
        {          
            Comida findFood = this.menu.FirstOrDefault(comida);            
            return findFood;           
        }

        public static string ImprimirTicket(Cliente cliente)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Comida comida in cliente.menu)
            {
                builder.AppendLine(comida.Descripcion);                
            }
            builder.AppendLine(cliente.dni.ToString());           
            return builder.ToString();
        }

        public static implicit operator Cliente(int dni)
        {
            return new Cliente(dni);
        }

        public static Cliente operator +(Cliente cliente, Comida comida)
        {
            cliente.menu.Add(comida);
            return cliente;
            
        }




    }
}
