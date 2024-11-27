using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class Categoria
    {
        [Key]
        public int id { get; init; }

        [Required(ErrorMessage ="Ingrese un nombre de la categoria")]
        [Display(Name="Nombre de Categoría")]
        public String Nombre { get; set; }

        [Display(Name ="Orden de visualización")]
        public int Orden { get; set; }




    }
}
