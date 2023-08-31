using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PanicoAPIWeb.Models;

[Table("tbUser")]
public partial class TbUser
{
    [Key]
    [Column("idUser")]
    public int IdUser { get; set; }

    [Column("nome")]
    [StringLength(50)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("senha")]
    [StringLength(50)]
    [Unicode(false)]
    public string Senha { get; set; } = null!;
}
