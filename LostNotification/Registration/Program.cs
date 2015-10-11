using System;

namespace Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To register, please provide the following info:");
            Console.Write(" email address:");
            var email = Console.ReadLine();
            Console.Write(" password: ");
            var password = Console.ReadLine();

            var notificationCenter = new NotificationCenter();
            notificationCenter.Notify(email, "welcome", "Great to have you with us!");

            Console.WriteLine("Thank you for registration");
            Console.ReadLine();
        }
    }
}
