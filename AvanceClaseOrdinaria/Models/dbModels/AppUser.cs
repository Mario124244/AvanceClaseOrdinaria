using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AvanceClaseOrdinaria.Models.dbModels
{
    public class AppUser : IdentityUser <int>
    {
        

        [StringLength(50)]
        [Unicode(false)]
        public string? Nombre { get; set; }

       
        

        [InverseProperty("Usuario")]
        public virtual ICollection<ReservacionCubiculo> ReservacionCubiculos { get; set; } = new List<ReservacionCubiculo>();

        [InverseProperty("Usuario")]
        public virtual ICollection<ReservacionMesa> ReservacionMesas { get; set; } = new List<ReservacionMesa>();

       
    }
}
