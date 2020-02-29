using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebCursos.Models
{
    /**
     * Clase de referencia el diseño de la tabla 
     * Categoria de la base de datos
     * **/
    public class Categoria
    {
        [Key] //Llave primaria
        public int CategoriaID { get; set; }

        /**Propiedades del campo nombre
         * Campo requerido para el registro
         * Longitud minima y maxima del campo
         * Mensajes de error en caso de no cumplir los requerimientos
         * **/
        [Required(ErrorMessage ="El nombre es requerido")] 
        [StringLength(50, MinimumLength =3,ErrorMessage ="El nombre debe contar con mas de 3 caracteres y no puede exceder de 50 caracteres")] 
        public String Nombre { get; set; }

        /**Propiedades del campo descripcion
         * Longitud maxima del campo
         * Mensajes de error en caso de no cumplir los requerimientos
         * **/
        [StringLength(256, ErrorMessage = "La descripción no puede exceder de 256 caracteres")]
        [Display(Name ="Descripción")]
        public String Descripcion { get; set; }

        //True = Activo, False = Inactivo
        public Boolean Estado { get; set; }

        /**
        public Categoria(string p1, string p2, Boolean p3)
        {
            this.Nombre = p1;
            this.Descripcion = p2;
            this.Estado = p3;
        }**/
    }
}
