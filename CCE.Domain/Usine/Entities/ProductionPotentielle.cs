using System.ComponentModel.DataAnnotations.Schema;

namespace CCE.Domain.Usine.Entities;

public class ProductionPotentielle
{
    public string Code { get; set; }
    public string? CodeLigne { get; set; }  
    public string? Format { get; set; }
    public long? Cadence { get; set; }
    public long? CadenceNominale { get; set; }

    [ForeignKey("CodeLigne")]
    public Ligne? Ligne { get; set; }  
}