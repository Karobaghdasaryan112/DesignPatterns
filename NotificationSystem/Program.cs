using NotificationSystem.Entities;
using NotificationSystem.Observer.Events;
using NotificationSystem.Observer.Handlers;
using NotificationSystem.Observer.Subscribers.PostNotifications;

public class Program
{
    public static void Main()
    {
        //Observable
        var engine = new SocialMediaProvider();
        
        //Observers
        var emailNotification = new EmailNotification();
        var pushNotification = new PushNotification();
        var smsNotification = new SmsNotification();
        
        
        //event

        var post = new Post(
            content: "This is my first post 🚀",
            title: "Hello World",
            createdBy: "karo",
            lastModifiedBy: "karo"
        )
        {
            Guid = Guid.NewGuid(),
            CreatedOn = DateTime.UtcNow,
            LastModifiedOn = DateTime.UtcNow,
            IsDeleted = false,

            User = new User
            {
                Guid = Guid.NewGuid(),
                Email = "test@mail.com",
                FirstName = "Karo",
                LastName = "Baghdasaryan",
                Username = "karo_dev",
                Password = "1234",
                ConfirmPassword = "1234",
                IsEmailConfirmed = true,
                IsActive = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Posts = new List<Post>()
            }
        };
        var postCreatedEvent = new PostCreatedEvent(post);
        
        engine.Subscribe(emailNotification);
        engine.Subscribe(pushNotification);
        engine.Subscribe(smsNotification);
        

        engine.Notify(postCreatedEvent);
        
    
    }
}


