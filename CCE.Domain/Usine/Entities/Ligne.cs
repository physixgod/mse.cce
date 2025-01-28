using System.ComponentModel.DataAnnotations.Schema;

namespace CCE.Domain.Usine.Entities;

public class Ligne
{
    public string Code { get; set; }
    public string? Libelle { get; set; }
    public string? Computer_Input { get; set; }
    public string? Computer_Output { get; set; }
    public string? Equation { get; set; }
    public string SecteurAtelierCode { get; set; }

    [ForeignKey("SecteurAtelierCode")]
    public SecteurAtelier? SecteurAtelier { get; set; }
}