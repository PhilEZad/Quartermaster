namespace Domain;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Faction Faction { get; set; }
    public int Power { get; set; }

    public List<Model> Models { get; set; }
    public List<Weapon> Weapons { get; set; }
    public List<Ability> Abilities { get; set; }
    public List<Wargear> Wargear { get; set; }
}