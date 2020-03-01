using SistemaWebCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebCursos.Data
{
    public class DbInitializer
    {
        /**
        * Metodo inicializador de la Base de Datos
        * Recibe un parametro contexto vacio y le 
        * asigna los valores de la BD
        * **/
        public static void Initialize(SistemaWebCursosContext context)
        {
            context.Database.EnsureCreated();//Crea la Base de Datos

            //Buscar si existen registros en la tabla categoria
            if (context.Categoria.Any())
            {
                return;
            }
            var categorias = new Categoria[] //Crea un arreglo con los registros de la tabla Categoria
            {
                new Categoria{Nombre="Programación",Descripcion="Cursos de programación",Estado=true },
                new Categoria{Nombre="Diseño grafico",Descripcion="Cursos de diseño grafico",Estado=true },
            };

            foreach (Categoria c in categorias) //Asigna los valores del arreglo a la base de datos
            {
                context.Categoria.Add(c);
            }
            context.SaveChanges();//Guarda los cambios realizados

        }
    }
}
