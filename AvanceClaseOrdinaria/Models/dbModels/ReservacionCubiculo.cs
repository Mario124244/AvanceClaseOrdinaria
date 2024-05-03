using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

public partial class ReservacionCubiculo
{
    [Key]
    [Column("ReservacionID")]
    public int ReservacionId { get; set; }

    [Column("CubiculoID")]
    public int? CubiculoId { get; set; }

    [Column("UsuarioID")]
    public int? UsuarioId { get; set; }

    [Column("PeriodoID")]
    public int? PeriodoId { get; set; }

    [ForeignKey("CubiculoId")]
    [InverseProperty("ReservacionCubiculos")]
    public virtual Cubiculo? Cubiculo { get; set; }

    [InverseProperty("ReservacionIdcubiculoNavigation")]
    public virtual ICollection<HistorialReservacione> HistorialReservaciones { get; set; } = new List<HistorialReservacione>();

    [ForeignKey("PeriodoId")]
    [InverseProperty("ReservacionCubiculos")]
    public virtual PeriodoDeReserva? Periodo { get; set; }

    [ForeignKey("UsuarioId")]
    [InverseProperty("ReservacionCubiculos")]
    public virtual Usuario? Usuario { get; set; }
}
