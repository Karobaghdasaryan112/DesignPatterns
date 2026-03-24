using NotificationSystem.Contracts;

namespace NotificationSystem.Entities;

public class Post(string content, string title, string createdBy, string lastModifiedBy)
    : IEntity
{
    public Guid Guid { get; set; }
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; } = createdBy;
    public DateTime LastModifiedOn { get; set; }
    public string LastModifiedBy { get; set; } = lastModifiedBy;
    public bool IsDeleted { get; set; }

    //Navigation Property
    public virtual User User { get; set; }


}