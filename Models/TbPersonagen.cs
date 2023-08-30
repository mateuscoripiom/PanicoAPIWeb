using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PanicoAPIWeb.Models;

[Table("tbPersonagens")]
public partial class TbPersonagen
{
    [Key]
    [Column("idPerson")]
    public int IdPerson { get; set; }

    [Column("nomePerson")]
    [StringLength(1)]
    [Unicode(false)]
    public string NomePerson { get; set; } = null!;

    [Column("descricaoPerson")]
    [StringLength(1)]
    [Unicode(false)]
    public string DescricaoPerson { get; set; } = null!;

    [Column("imagemPerson")]
    [StringLength(1)]
    [Unicode(false)]
    public string ImagemPerson { get; set; } = null!;

    [Column("situacao")]
    public int Situacao { get; set; }

    [ForeignKey("IdPerson")]
    [InverseProperty("IdPeople")]
    public virtual ICollection<TbAtor> IdAtors { get; set; } = new List<TbAtor>();

    [ForeignKey("IdPerson")]
    [InverseProperty("IdPeople")]
    public virtual ICollection<TbObra> IdObras { get; set; } = new List<TbObra>();
}
