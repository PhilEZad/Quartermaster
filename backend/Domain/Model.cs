namespace Domain;

public class Model
{
    // General
    public int Id { get; set; }
    public string Name { get; set; }

    // Stats
    public int Movement { get; set; }
    public int WeaponSkill { get; set; }
    public int BallisticSkill { get; set; }
    public int Strength { get; set; }
    public int Toughness { get; set; }
    public int Wounds { get; set; }
    public int Attacks { get; set; }
    public int Leadership { get; set; }
    public int Save { get; set; }
    
    public int UnitId { get; set; }
    public Unit Unit { get; set; }
    
    public int Points { get; set; }
}