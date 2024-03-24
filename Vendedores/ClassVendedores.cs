using Examen2_Programacion_III.Categorias;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2_Programacion_III.Vendedores
{
    internal class ClassVendedores
    {
        private Dictionary<string, Vendedor> vendedores = new Dictionary<string, Vendedor>();

        public ClassVendedores() { }

        public Dictionary<string, Vendedor> ListadoVendedores()
        {
            return vendedores;
        }
        public string GetName(string codigo)
        {
            if (vendedores.ContainsKey(codigo))
            {
                return vendedores[codigo].Nombre;
            }
            else
            {
                return "El vendedor no existe.";
            }
        }
        public void LlenarDictionary()
        {
            vendedores.Add("001", new Vendedor1("Luis Chaves"));
            vendedores.Add("002", new Vendedor2("Angel Mora"));
        }
        public void ValidarVendedor(string codigoVendedor)
        {
            bool vendedorEncontrado = false;

            foreach (var v in vendedores)
            {
                if (v.Key == codigoVendedor)
                {
                    Console.WriteLine($"El vendedor con código {codigoVendedor} es {v.Value.Nombre}");
                    vendedorEncontrado = true;
                    break;
                }
            }

            if (!vendedorEncontrado)
            {
                Console.WriteLine($"El vendedor con código {codigoVendedor} no existe.");
            }
        }
        public string ObtenerNombreVendedor(string codigoVendedor)
        {
            foreach (var v in vendedores)
            {
                if (v.Key == codigoVendedor)
                {
                    return v.Value.Nombre;
                }
            }

            return null; // Retorna null si el vendedor no se encuentra
        }

    }//fin internal class
    abstract class Vendedor
    {
        public string Nombre { get; set; }

        public Vendedor(string nombre)
        {
            Nombre = nombre;
        }
    }
    class Vendedor1 : Vendedor, IVendedor1
    {
        public Vendedor1(string nombre) : base(nombre)
        {
        }
    }
    class Vendedor2 : Vendedor, IVendedor2
    {
        public Vendedor2(string nombre) : base(nombre)
        {
        }
    }
    internal interface IVendedor1
    {
    }
    internal interface IVendedor2
    {
    }
}//fin namespace
