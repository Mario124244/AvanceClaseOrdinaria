using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

public partial class ReservacionMesa
{
    [Key]
    [Column("ReservacionID")]
    public int ReservacionId { get; set; }

    [Column("MesaID")]
    public int? MesaId { get; set; }

    [Column("UsuarioID")]
    public int? UsuarioId { get; set; }

    [Column("PeriodoID")]
    public int? PeriodoId { get; set; }

    [InverseProperty("ReservacionIdmesaNavigation")]
    public virtual ICollection<HistorialReservacione> HistorialReservaciones { get; set; } = new List<HistorialReservacione>();

    [ForeignKey("MesaId")]
    [InverseProperty("ReservacionMesas")]
    public virtual Mesa? Mesa { get; set; }

    [ForeignKey("PeriodoId")]
    [InverseProperty("ReservacionMesas")]
    public virtual PeriodoDeReserva? Periodo { get; set; }

    [ForeignKey("UsuarioId")]
    [InverseProperty("ReservacionMesas")]
    public virtual Usuario? Usuario { get; set; }
}
