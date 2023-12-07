using Domain;

namespace Application.DTOs.Requests;

public class WeaponRequest
{
    public string Name { get; set; }
    
    public int Range { get; set; }
    public string Type { get; set; }
    public int Strength { get; set; }
    public int ArmourPenetration { get; set; }
    public int Damage { get; set; }
    
    public List<Ability> Abilities { get; set; }

    public int Points { get; set; }
}