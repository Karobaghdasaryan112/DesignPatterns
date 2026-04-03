using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;
using NotificationSystem.Entities;
using NotificationSystem.Observer.Events;
using NotificationSystem.Observer.EvetHandlers;
using NotificationSystem.Observer.Handlers;
using NotificationSystem.Observer.Subscribers.PostNotifications;
using System.Diagnostics.Tracing;
using static Program;

public class Program
{
    public static void Main()
    {
        var provider = new Provider();
        var email = new EmailNotification();
        provider._myEvent += email.MyMethod;
        Console.WriteLine(typeof(System.ValueType).BaseType);
        Console.WriteLine(typeof(Int32).BaseType);
        //Point p = new Point(1, 1);
        //Console.WriteLine(p);
        //p.Change(2, 2);
        //Console.WriteLine(p);

        //object o = p;
        //Console.WriteLine(o);

        //((Point)o).Change(3, 3);

        //Console.WriteLine(o);
        //Console.WriteLine(p);

        //((IChangeBoxedPoint)p).Change(4, 4);
        //Console.WriteLine(p);

        //((IChangeBoxedPoint)o).Change(5, 5);
        //Console.WriteLine(o);
        //var x = typeof(IChangeBoxedPoint);
        //Dictionary<Type, IEventHandler<BaseEvent>> Observers = new()
        //{
        //    [typeof(PostCreatedEvent)] = new PostCreatedEventHandler(),
        //    [typeof(PostLikedEvent)] = new PostLikedEventHandler(),
        //    [typeof(UserFollowedEvent)] = new UserFolowedEventHandler()
        //};

        ////Observable
        //var engine = new SocialMediaProvider();

        ////Observers
        //var emailNotification = new EmailNotification(Observers);
        //var pushNotification = new PushNotification(Observers);
        //var smsNotification = new SmsNotification(Observers);


        ////event

        //var post = new Post(
        //    content: "This is my first post 🚀",
        //    title: "Hello World",
        //    createdBy: "karo",
        //    lastModifiedBy: "karo"
        //)
        //{
        //    Guid = Guid.NewGuid(),
        //    CreatedOn = DateTime.UtcNow,
        //    LastModifiedOn = DateTime.UtcNow,
        //    IsDeleted = false,

        //    User = new User
        //    {
        //        Guid = Guid.NewGuid(),
        //        Email = "test@mail.com",
        //        FirstName = "Karo",
        //        LastName = "Baghdasaryan",
        //        Username = "karo_dev",
        //        Password = "1234",
        //        ConfirmPassword = "1234",
        //        IsEmailConfirmed = true,
        //        IsActive = true,
        //        IsDeleted = false,
        //        CreatedAt = DateTime.UtcNow,
        //        UpdatedAt = DateTime.UtcNow,
        //        Posts = new List<Post>()
        //    }
        //};
        //var postCreatedEvent = new PostCreatedEvent(post);

        //engine.Subscribe(emailNotification);
        //engine.Subscribe(pushNotification);
        //engine.Subscribe(smsNotification);


        //engine.Notify(postCreatedEvent);


    }
    public delegate void MyEventHandler<TEventArgs>(string musrid) where TEventArgs : EventArgs;
    public class Provider
    {
        public event MyEventHandler<EventArgs> _myEvent;

        public void Notify(string musrId)
        {
            _myEvent?.Invoke(musrId);
        }
    }
    public class EmailNotification
    {
        public void MyMethod(string musrid)
        {
            Console.WriteLine("MusrId from Email");
        }
    }
    internal interface IChangeBoxedPoint
    {
        void Change(int x, int y);
    }
    internal struct Point : IChangeBoxedPoint
    {
        public Point(int x,int y)
        {
            m_x = x; m_y = y;
        }
        private int m_x, m_y;
        public void Change(int x, int y)
        {
            m_x = x; m_y = y;
        }
        public override string ToString()
        {
            return String.Format("({0}.{1})", m_x, m_y);
        }
    }
}


