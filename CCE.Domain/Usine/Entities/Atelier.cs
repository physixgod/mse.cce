﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCE.Domain.Usine.Entities;

public class Atelier
{
    public int Code { get; set; }
    public string? Libelle { get; set; }
    public int? UsineCode { get; set; } 
    [ForeignKey("UsineCode")] 
    public Usine? Usine { get; set; } 
    public ICollection<SecteurAtelier> SecteurAteliers { get; set; } = new List<SecteurAtelier>();

}