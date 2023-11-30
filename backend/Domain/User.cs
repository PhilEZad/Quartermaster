﻿namespace Domain;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public DateTime dateCreated { get; set; }
    public DateTime dateModified { get; set; }
    public string HashedPassword { get; set; }
    public string Salt { get; set; }
}