using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

[Table("PeriodoDeReserva")]
public partial class PeriodoDeReserva
{
    [Key]
    [Column("PeriodoID")]
    public int PeriodoId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaInicio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaFin { get; set; }

    [InverseProperty("Periodo")]
    public virtual ICollection<ReservacionCubiculo> ReservacionCubiculos { get; set; } = new List<ReservacionCubiculo>();

    [InverseProperty("Periodo")]
    public virtual ICollection<ReservacionMesa> ReservacionMesas { get; set; } = new List<ReservacionMesa>();
}
