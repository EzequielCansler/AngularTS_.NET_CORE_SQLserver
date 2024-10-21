using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ManejoInventario_AngularTS_.NET_CORE.Server.Models
{
    public class Prioridad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrioID { get; set; }

        [DataType(DataType.Text)]
        public string Nombre { get; set; } = string.Empty;
    }
}
