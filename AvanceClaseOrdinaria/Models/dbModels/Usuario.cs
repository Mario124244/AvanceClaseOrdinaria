using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

public partial class Usuario : IdentityUser
{
    [Key]
    [Column("UsuarioID")]
    public int UsuarioId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("RolID")]
    public int? RolId { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<ReservacionCubiculo> ReservacionCubiculos { get; set; } = new List<ReservacionCubiculo>();

    [InverseProperty("Usuario")]
    public virtual ICollection<ReservacionMesa> ReservacionMesas { get; set; } = new List<ReservacionMesa>();

    [ForeignKey("RolId")]
    [InverseProperty("Usuarios")]
    public virtual Role? Rol { get; set; }
}
