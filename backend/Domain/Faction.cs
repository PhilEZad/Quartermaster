﻿namespace Domain;

public class Faction
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<Unit> Units { get; set; }
}