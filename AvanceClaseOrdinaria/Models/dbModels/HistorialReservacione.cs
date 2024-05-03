using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

public partial class HistorialReservacione
{
    [Key]
    [Column("HistorialID")]
    public int HistorialId { get; set; }

    [Column("ReservacionIDCubiculo")]
    public int? ReservacionIdcubiculo { get; set; }

    [Column("ReservacionIDMesa")]
    public int? ReservacionIdmesa { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [ForeignKey("ReservacionIdcubiculo")]
    [InverseProperty("HistorialReservaciones")]
    public virtual ReservacionCubiculo? ReservacionIdcubiculoNavigation { get; set; }

    [ForeignKey("ReservacionIdmesa")]
    [InverseProperty("HistorialReservaciones")]
    public virtual ReservacionMesa? ReservacionIdmesaNavigation { get; set; }
}
