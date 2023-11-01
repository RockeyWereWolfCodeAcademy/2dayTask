using Core.Models;
using System.Net.Sockets;

namespace TaskBookAuthor
{
    internal class Program
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static User LogedIn { get; set; } = null;

        public static void GetUsers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine(user.Username);
            }
        }
        static void Main(string[] args)
        {
            bool doLoop = true;
            while (doLoop == true)
            {
                int option;
                Console.WriteLine("What you want to do?\n1.Login/Logout(if user is logged in)\n2.Register\n3.Get all users\n4.Exit");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        if (LogedIn != null)
                        {
                            Console.WriteLine("User is logged in, logut(Yes/Y)?");
                            string response = Console.ReadLine().ToLower();
                            if (response == "yes" || response == "y")
                            {
                                Authorization.Logout();
                            }
                        } else
                        {
                            Console.Write("Enter username:");
                            string usernameToLogin = Console.ReadLine();
                            Console.Write("Enter password:");
                            string passwordToLogin = Console.ReadLine();
                            Authorization.Login(usernameToLogin, passwordToLogin);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter surname:");
                        string surname = Console.ReadLine();
                        Console.WriteLine("Enter username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("enter password:");
                        string password = Console.ReadLine();
                        Authorization.Register(name, surname, username, password);
                        break;
                    case 3:
                        GetUsers();
                        break;
                    case 4:
                        doLoop = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;

                }
            }
        }
    }
}