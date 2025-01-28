using System.ComponentModel.DataAnnotations.Schema;

namespace CCE.Domain.Usine.Entities;

public class SecteurAtelier
{
    public string Code { get; set; }
    public string? Libelle { get; set; }
    public int AtelierCode { get; set; }
    [ForeignKey("AtelierCode")]
    public Atelier? Atelier { get; set; }
    public ICollection<Ligne> Lignes { get; set; } = new List<Ligne>();

    
}