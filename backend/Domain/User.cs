namespace Domain;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public string HasedPassword { get; set; }
}