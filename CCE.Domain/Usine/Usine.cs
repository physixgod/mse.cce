using System.ComponentModel.DataAnnotations;
using CCE.Domain.Usine.Entities;

namespace CCE.Domain.Usine;

public class Usine 
{
   
    public string Code { get; set; }
    public string? Libelle { get; set; }
    public ICollection<Atelier>? Ateliers { get; set; }

}