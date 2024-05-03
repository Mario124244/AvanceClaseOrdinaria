using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

public partial class Mesa
{
    [Key]
    [Column("MesaID")]
    public int MesaId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("EstadoID")]
    public int? EstadoId { get; set; }

    [ForeignKey("EstadoId")]
    [InverseProperty("Mesas")]
    public virtual EstadoMesa? Estado { get; set; }

    [InverseProperty("Mesa")]
    public virtual ICollection<ReservacionMesa> ReservacionMesas { get; set; } = new List<ReservacionMesa>();
}
