using NotificationSystem.Contracts;

namespace NotificationSystem.Entities;

public class User : IEntity
{
    public Guid Guid { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //Navigation Property
    public virtual IReadOnlyCollection<Post> Posts { get; set; }
}