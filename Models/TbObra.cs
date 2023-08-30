using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PanicoAPIWeb.Models;

[Table("tbObra")]
public partial class TbObra
{
    [Key]
    [Column("idObra")]
    public int IdObra { get; set; }

    [Column("nome")]
    [StringLength(1)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("descricao")]
    [StringLength(1)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [Column("imagem")]
    [StringLength(1)]
    [Unicode(false)]
    public string Imagem { get; set; } = null!;

    [Column("diretores")]
    [StringLength(1)]
    [Unicode(false)]
    public string Diretores { get; set; } = null!;

    [Column("avaliacao")]
    public int? Avaliacao { get; set; }

    [ForeignKey("IdObra")]
    [InverseProperty("IdObras")]
    public virtual ICollection<TbPersonagen> IdPeople { get; set; } = new List<TbPersonagen>();
}
