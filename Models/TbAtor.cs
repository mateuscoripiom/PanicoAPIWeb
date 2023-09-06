using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PanicoAPIWeb.Models;

[Table("tbAtor")]
public partial class TbAtor
{
    [Key]
    [Column("idAtor")]
    public int IdAtor { get; set; }

    [Column("nomeElenco")]
    [StringLength(50)]
    [Unicode(false)]
    public string NomeElenco { get; set; } = null!;

    [Column("descricaoElenco")]
    [StringLength(500)]
    [Unicode(false)]
    public string DescricaoElenco { get; set; } = null!;

    [Column("imagemElenco")]
    [StringLength(100)]
    [Unicode(false)]
    public string ImagemElenco { get; set; } = null!;

    [ForeignKey("IdAtor")]
    [InverseProperty("IdAtors")]
    public virtual ICollection<TbPersonagen> IdPeople { get; set; } = new List<TbPersonagen>();
}
