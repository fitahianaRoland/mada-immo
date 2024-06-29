using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

[Table("proprietaire")]
public class Proprietaire
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Column("tel")]
    public string? Tel { get; set; }

}
