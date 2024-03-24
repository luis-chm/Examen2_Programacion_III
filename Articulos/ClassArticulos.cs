using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Examen2_Programacion_III.Articulos
{
    internal class ClassArticulos
    {
        #region ATRIBUTOS Y CONSTRUCTORES
        //arreglo
        public static int cantArt = 5;
        protected string[] codigo = new string[cantArt];
        protected string[] nombre = new string[cantArt];
        protected double[] precio = new double[cantArt];
        protected int indice = 0;
        //constructor vacio
        public ClassArticulos()
        {

        }
        //constructor
        public ClassArticulos(string[] Codigo, string[] Nombre, double[] Precio)
        {
            codigo = Codigo;
            nombre = Nombre;
            precio = Precio;
        }
        //get and set
        public string GetCodigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        #endregion FIN ATRIBUTOS

        #region METODOS NO ESTATICOS
        public void AgregarArticulo()
        {
            char r = 'N';
            bool continua;
            do
            {
                continua = false;
                do
                {
                    try
                    {
                        if (indice < cantArt)
                        {
                            Console.Clear();
                            Console.WriteLine("\nIngrese los datos del artículo:");


                            Console.Write("Código: ");
                            int cod = int.Parse(Console.ReadLine());
                            codigo[indice] = cod.ToString();
                            nombre[indice] = obtenerTexto("Nombre: ");
                            Console.WriteLine("Precio:");
                            precio[indice] = double.Parse(Console.ReadLine());

                            Console.WriteLine($"\nArticulo ({indice}) agregado correctamente.\n");
                            Console.WriteLine("Desea ingresar otro empleado (S/N)");
                            while (!char.TryParse(Console.ReadLine(), out r) || (r = char.ToUpper(r)) != 'S' && r != 'N')
                            {
                                Console.Write("Por favor, ingrese 'S' o 'N': ");
                            }
                            Console.Clear();
                        }//fin if
                        else
                        {
                            Console.WriteLine("El arreglo se encuentra lleno. No se pueden agregar mas.");
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Digite un formato valido.");
                        Thread.Sleep(1000);
                        continua = true;
                    }
                    indice++;
                } while (continua);
            } while (r != 'N');
        }//fin metodo Agregar
        public void ConsultarArticulo()
        {
            char r2 = 'N';
            bool continua;
            do
            {
                continua = false;
                do
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("\n------------- Consultar Artículo -------------");
                        Console.WriteLine("\nDigite el código del artículo que desea buscar:");
                        string idConsulta = Console.ReadLine();

                        bool codigoEncontrado = false;
                        for (int i = 0; i < indice; i++)
                        {
                            if (codigo[i] == idConsulta)
                            {
                                Console.WriteLine($"\nDatos del artículo encontrado en la posición del vector ({i}).\n");
                                Console.WriteLine($"\nCódigo: {codigo[i]}");
                                Console.WriteLine($"Nombre: {nombre[i]}");
                                Console.WriteLine($"Precio: {precio[i]}");
                                codigoEncontrado = true;
                                break;
                            }
                        }
                        if (!codigoEncontrado)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nArtículo no encontrado.");
                            Console.ResetColor();
                        }
                        Console.WriteLine("\nDesea realizar otro consulta (S/N)");
                        while (!char.TryParse(Console.ReadLine(), out r2) || (r2 = char.ToUpper(r2)) != 'S' && r2 != 'N')
                        {
                            Console.WriteLine("Por favor, ingrese 'S' o 'N'.");
                        }
                        Console.Clear();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor, digite el formato correcto.");
                        Thread.Sleep(2000);
                        continua = true;
                    }
                } while (continua);
            } while (r2 != 'N');
        }//fin metodo consultar
        public void BorrarArticulo()
        {
            char respuesta = 'N';
            bool continua;
            do
            {
                continua = false;
                do
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("\n------------- Eliminar Artículo -------------");
                        Console.WriteLine("\nDigite el código del artículo que desea eliminar:");
                        string codigoBorrar = Console.ReadLine();

                        bool codigoEncontrado = false;
                        for (int i = 0; i < indice; i++)
                        {
                            if (codigo[i] == codigoBorrar)
                            {
                                Console.WriteLine($"\nDatos del artículo encontrado en la posición del vector ({i}).\n");
                                Console.WriteLine($"\nCódigo: {codigo[i]}");
                                Console.WriteLine($"Nombre: {nombre[i]}");
                                Console.WriteLine($"Precio: {precio[i]}");

                                Console.WriteLine("\n¿Está seguro de eliminar el artículo? (S/N)");
                                while (!char.TryParse(Console.ReadLine(), out respuesta) || (respuesta = char.ToUpper(respuesta)) != 'S' && respuesta != 'N')
                                {
                                    Console.Write("Por favor, ingrese 'S' o 'N': ");
                                }
                                Console.WriteLine();

                                if (respuesta.ToString().ToUpper() == "S")
                                {
                                    codigo[i] = null;
                                    nombre[i] = null;
                                    precio[i] = 0.0;

                                    Console.WriteLine($"Artículo con código {codigoBorrar} borrado exitosamente.");
                                    indice--;
                                    codigoEncontrado = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Eliminación de artículo cancelada.");
                                }
                                codigoEncontrado = true;
                                break;
                            }
                        }
                        if (!codigoEncontrado)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nArtículo no encontrado.");
                            Console.ResetColor();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Por favor, digite el formato correcto.");
                        Thread.Sleep(2000);
                        continua = true;
                    }
                } while (continua);
            } while (respuesta != 'N');
        }// fin metodo borrar

        public void ListadoArticulos()
        {
            for (int i = 0; i < indice; i++)
            {
                Console.WriteLine($"\nCódigo Articulo: {codigo[i]}");
                Console.WriteLine($"Nombre Articulo: {nombre[i]}");
                Console.WriteLine($"Precio Articulo: {precio[i]}");
            }
        }
        public double[] ObtenerPrecios()
        {
            return precio.Take(indice).ToArray();
        }

        #endregion FIN METODOS
        #region METODOS HELPER
        public static string obtenerTexto(string mensaje)
        {
            string texto;
            do
            {
                Console.WriteLine(mensaje);
                texto = Console.ReadLine();
                if (!validarLetras(texto))
                {
                    Console.WriteLine("Por favor, digite solamente letras.");
                }
            } while (!validarLetras(texto));

            return texto;
        }//fin metodo get text
        public static bool validarLetras(string texto)
        {
            return Regex.IsMatch(texto, "^[a-zA-Z]+$");// valida si el texto ingresado hace match con la expresion ^[a-zA-Z]+$
            //^ inicio cadena, a-zA-Z: letras desde mayus a minus, $ fin cadena
            //REGEX: es una secuencia de caracteres que define un patrón de búsqueda
        }//fin metodo check text
        public bool ValidarArticulo(string codigo)
        {
            foreach (string cod in this.codigo)
            {
                if (cod == codigo)
                {
                    return true;
                }
            }
            return false;
        }//fin metodo validar articulo
        #endregion METODOS HELPER
    }//fin clase
}//fin namespace