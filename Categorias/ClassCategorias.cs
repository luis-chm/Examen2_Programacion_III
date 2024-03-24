using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2_Programacion_III.Categorias
{
    internal class ClassCategorias
    {
        private List<Categoria> categorias = new List<Categoria>();
        public List<Categoria> ListadoCategorias()
        {
            return categorias;
        }
        public void AllCategorias()
        {
            foreach (var categoria in ListadoCategorias())
            {
                Console.WriteLine(categoria.GetType().Name);
            }
        }
        //Inicializador del metod agregar
        public void AgregarCategoria()
        {
            categorias.Add(new Tech());
            categorias.Add(new Ropa());
            categorias.Add(new Hogar());
        }
        public void ValidarCategoria(string nombreCategoria)
        {
            new Categoria().Promocion();
            Categoria categoria = null;

            switch (nombreCategoria)
            {
                case "Tech":
                    categoria = new Tech();
                    break;
                case "Ropa":
                    categoria = new Ropa();
                    break;
                case "Hogar":
                    categoria = new Hogar();
                    break;
                default:
                    Console.WriteLine($"'{nombreCategoria}' no es válida. Por favor, ingrese una categoría valida.");
                    return;
            }
            categoria.Promocion();
        }
    }//fin classCategorias
    class Categoria
    {
        public virtual void Promocion()
        {
            Console.WriteLine("Descuentos y promociones\n");
        }
    }//fin class cateogoria
    class Tech : Categoria
    {
        public override void Promocion()
        {
            Console.WriteLine("Descuento de 15%");
        }
    }//fin class cateogoria1
    class Ropa : Categoria 
    {
        public override void Promocion()
        {
            Console.WriteLine("Promoción dos por 1");
        }
    }//fin class cateogoria2
    class Hogar : Categoria
    {
        public override void Promocion()
        {
            Console.WriteLine("Todo a mitad de precio.");
        }
    }//fin class cateogoria3
}//fin namespace
