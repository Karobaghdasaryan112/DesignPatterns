using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;
using NotificationSystem.Entities;
using NotificationSystem.Observer.Events;

namespace NotificationSystem.Observer.EvetHandlers;

public class PostCreatedEventHandler : IEventHandler<PostCreatedEvent>
{
    public void Handle(BaseEvent baseEvent)
    {
        if (baseEvent is not PostCreatedEvent postEvent)
            return;

        var post = postEvent.GetData() as Post;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("========== [POST CREATED EVENT] ==========");
        Console.ResetColor();

        Console.WriteLine($"Time: {postEvent.GetDate():yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"Post ID: {post?.Guid}");
        Console.WriteLine($"Title: {post?.Title}");
        Console.WriteLine($"Created By: {post?.CreatedBy}");

        Console.WriteLine("==========================================\n");
    }
}