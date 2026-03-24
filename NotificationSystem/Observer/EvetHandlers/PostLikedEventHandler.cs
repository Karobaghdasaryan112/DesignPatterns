using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;
using NotificationSystem.Entities;
using NotificationSystem.Observer.Events;

namespace NotificationSystem.Observer.EvetHandlers;

public class PostLikedEventHandler : IEventHandler<PostLikedEvent>
{
    public void Handle(BaseEvent baseEvent)
    {
        if (baseEvent is not PostLikedEvent likeEvent)
            return;

        var post = likeEvent.GetData() as Post;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("========== [POST LIKED EVENT] ============");
        Console.ResetColor();

        Console.WriteLine($"Time: {likeEvent.GetDate():yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"Post ID: {post?.Guid}");
        Console.WriteLine($"Title: {post?.Title}");

        Console.WriteLine("Someone liked this post ❤️");

        Console.WriteLine("==========================================\n");
    }
}