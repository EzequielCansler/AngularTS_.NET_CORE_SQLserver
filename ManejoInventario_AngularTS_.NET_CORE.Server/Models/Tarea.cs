using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Models
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; } 

        [DataType(DataType.Text)]
        public string Titulo { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        [Display(Description = "Que vas a hacer")]
        public string Descripcion { get; set; } = string.Empty;

        public bool EstaCompleto { get; set; }

        public int PrioID {  get; set; }  // "Alta", "Media", "Baja"
        [ForeignKey("PrioID")]
        public Prioridad? Prioridad { get; set; }
        
    }

}
