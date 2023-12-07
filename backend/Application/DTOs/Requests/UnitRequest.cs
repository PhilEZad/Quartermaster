using Domain;

namespace Application.DTOs;

public class UnitRequest
{
    public string Name { get; set; }
    public Domain.Faction Faction { get; set; }
    public int Power { get; set; }

    public List<Model> Models { get; set; }
    public List<Weapon> Weapons { get; set; }
    public List<Ability> Abilities { get; set; }
    public List<Wargear> Wargear { get; set; }
    
    
    public List<string> FactionKeywords { get; set; }
    public List<string> Keywords { get; set; }
}