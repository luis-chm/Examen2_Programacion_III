using Examen2_Programacion_III.Articulos;
using Examen2_Programacion_III.Categorias;
using Examen2_Programacion_III.Vendedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen2_Programacion_III.Menu
{
    internal class ClassMenu
    {
        private static ClassArticulos articulos = new ClassArticulos();
        private static ClassCategorias categorias = new ClassCategorias();
        private static ClassVendedores vendedores = new ClassVendedores();
        public static void MenuPrincipal()
        {
            vendedores.LlenarDictionary();
            categorias.AgregarCategoria();
            int opcion1 = 0;
            do
            {
                Console.WriteLine("\t      Examen 2 \t\n");
                Console.WriteLine("-------------Menu Principal-------------");
                Console.WriteLine("Opcion 1:  Articulos.");
                Console.WriteLine("Opcion 2:  Facturación.");
                Console.WriteLine("Opcion 3:  Reportes");
                Console.WriteLine("Opcion 4:  Salir");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Seleccione su opcion: ");
                int.TryParse(Console.ReadLine(), out opcion1);// si ingresa una letra no va a dejar continuar
                switch (opcion1)
                {
                    case 1: SubMenuArticulos(); break;
                    case 2: Facturacion(); break;
                    case 3: MostrarReporte(); break;
                    case 4:
                        Console.WriteLine("¡Hasta pronto! Gracias");
                        Thread.Sleep(1500);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("+------------------------------------------+\r\n| ¡Opcion no valida! Elige una entre 1 y 4 |\r\n+------------------------------------------+");
                        break;
                }// fin switch
            } while (opcion1 != 4);
        }//fin metodo static Menu Main

        public static void SubMenuArticulos()
        {


            Console.Clear();
            int opcion2 = 0;
            do
            {
                Console.WriteLine("-------------Submenu Articulos-------------");
                Console.WriteLine("Opcion 1:  Agregar Articulo.");
                Console.WriteLine("Opcion 2:  Eliminar Articulo.");
                Console.WriteLine("Opcion 3:  Consultar Articulo.");
                Console.WriteLine("Opcion 4:  Regresar al Menu Principal.");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Seleccione su opcion: ");
                int.TryParse(Console.ReadLine(), out opcion2);// si ingresa una letra no va a dejar continuar
                switch (opcion2)
                {
                    case 1:
                        articulos.AgregarArticulo();
                        break;
                    case 2:
                        articulos.BorrarArticulo();
                        break;
                    case 3:
                        articulos.ConsultarArticulo();
                        break;
                    case 4:
                        Console.WriteLine("Regresando...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("+------------------------------------------+\r\n| ¡Opcion no valida! Elige una entre 1 y 4 |\r\n+------------------------------------------+");
                        break;
                }//fin switch

            } while (opcion2 != 4);

        }//Fin metodo sub menu articulso

        public static void Facturacion()
        {
            Console.Clear();
            //articulo
            Console.WriteLine("Ingrese el código del artículo:");
            string codigoArticulo = Console.ReadLine();
            if (!articulos.ValidarArticulo(codigoArticulo))
            {
                Console.WriteLine("El artículo no existe.");
                return;
            }
            articulos.ListadoArticulos();
            
            //categoría
            Console.WriteLine("\nListado de categorias disponibles.");
            Console.WriteLine("\n1 - Tech.\n2 - Ropa.\n3 - Hogar");
            Console.WriteLine("\nEscriba la categoría del artículo:");
            string nombreCategoria = Console.ReadLine();
            categorias.ValidarCategoria(nombreCategoria);
            //Vendedor
            Console.WriteLine("\nIngrese el código del vendedor:");
            string codigoVendedor = Console.ReadLine();
            vendedores.ValidarVendedor(codigoVendedor);
            string nombreVendedor = vendedores.ObtenerNombreVendedor(codigoVendedor);
            //Factura final
            Console.WriteLine("Generando su factura...");
            Thread.Sleep(1500);
            Console.Clear();
            double[] price = articulos.ObtenerPrecios(); // Guardar el arreglo de precios en la variable price
            double total;
            double precioFinal = 0;
            string txt = "";
            for (int i = 0; i < price.Length; i++)
            {
                
                precioFinal = price[i];
                txt = "Se ha aplicado el 15% de descuento";
            }

            if (nombreCategoria == "Tech")
            {
                total = precioFinal * 0.15;
            }
            else if (nombreCategoria == "Ropa")
            {
                txt = "Has obtenido un 2 por 1";
            }
            else
            {
                precioFinal = precioFinal / 2;
                txt = "Articulo a mitad de precio";
            }
            Console.Clear();
            Console.WriteLine("\r\n ==================================== \r\n  Factura  \r\n ====================================");
            Console.WriteLine($"\r\n  N° Articulo: {codigoArticulo}               ");
            Console.WriteLine("\r\n+------------------------------------+");
            articulos.ListadoArticulos();
            Console.WriteLine($"\r\n Categoria Articulo: {nombreCategoria}");
            Console.WriteLine($"\r\n Vendedor: {nombreVendedor}");
            Console.WriteLine("\r\n+------------------------------------+");
            Console.WriteLine($"\r\n  {txt}");
            Console.WriteLine("\r\n+------------------------------------+");
            Console.WriteLine($"\r\n  Monto Total: {precioFinal}  ");
            Console.WriteLine("\r\n ==================================== \r\n\r\n");
            Console.WriteLine("\t\t <PULSE ENTER PARA SALIR DEL REPORTE>");
            Console.ReadLine();
            Console.Clear();

        }//fin metodo factura
        public static void MostrarReporte()
        {
            Console.Clear();
            Console.WriteLine("Reporte de vendedores:");
            foreach (var ven in vendedores.ListadoVendedores())//acceder al diccionario y traer los datos
            {
                Console.WriteLine($"Código: {ven.Key}, Nombre: {ven.Value.Nombre}");
            }
            Console.WriteLine("\nListado de Categorías:");
            categorias.AllCategorias();


            Console.WriteLine("\nListado de Articulos:");
            articulos.ListadoArticulos();
        }//fin metodo reportes 

    }//fin clase menu
}//fin namespace
