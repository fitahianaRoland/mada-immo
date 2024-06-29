using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;

[Table("location")]
public class Location
{
    [Key]
    [Column("id")]
    public string? Id { get; set; }

    [Column("id_bien")]
    public string? IdBien { get; set; }
    public Bien Bien { get; set; }

    [Column("id_client")]
    public string? IdClient { get; set; }
    public Client Client { get; set; }

    [Column("duree")]
    public int? Duree { get; set; }

    [Column("date_debut")]
    public DateTime? DateDebut { get; set; }

}
