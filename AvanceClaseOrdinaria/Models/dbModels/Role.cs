using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

public partial class Role
{
    [Key]
    [Column("RolID")]
    public int RolId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [InverseProperty("Rol")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
