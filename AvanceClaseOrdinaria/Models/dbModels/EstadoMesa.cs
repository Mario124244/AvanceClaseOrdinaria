using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

public partial class EstadoMesa
{
    [Key]
    [Column("EstadoID")]
    public int EstadoId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [InverseProperty("Estado")]
    public virtual ICollection<Mesa> Mesas { get; set; } = new List<Mesa>();
}
