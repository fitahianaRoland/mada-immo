using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

[Table("bien")]
public class Bien
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Column("nom")]
    public string? Nom { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("loyer")]
    public double Loyer { get; set; }

    // [Column("photos")]
    // public string? Photos { get; set; }

    [Column("id_proprietaire")]
    public string? IdProprietaire { get; set; }
    public Proprietaire Proprietaire { get; set; }

    [Column("id_region")]
    public string? IdRegion { get; set; }
    public Region Region { get; set;}

    [Column("id_type_de_bien")]
    public string? IdTypeDeBien { get; set; }
    public TypeDeBien TypeDeBien { get; set; }

}
