using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Location")]

public class Loyer
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    // [Column("id_loyer")]
    // public string? IdLoyer { get; set; }
    // public Loyer Loyer { get; set; }
}