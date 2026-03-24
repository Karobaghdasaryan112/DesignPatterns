using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;
using NotificationSystem.Entities;
using NotificationSystem.Observer.Events;

namespace NotificationSystem.Observer.EvetHandlers;

public class UserFolowedEventHandler : IEventHandler<UserFollowedEvent>
{
    public void Handle(BaseEvent baseEvent)
    {
        if (baseEvent is not UserFollowedEvent followEvent)
            return;

        var user = followEvent.GetData() as User;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========== [USER FOLLOWED EVENT] =========");
        Console.ResetColor();

        Console.WriteLine($"Time: {followEvent.GetDate():yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"User ID: {user.Guid}");
        Console.WriteLine($"User Name: {user?.FirstName} {user?.LastName}");

        Console.WriteLine("🔥 New follower added!");

        Console.WriteLine("==========================================\n");
    }
}