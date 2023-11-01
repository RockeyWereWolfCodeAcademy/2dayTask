using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace TaskBookAuthor
{
    public static class Authorization
    {
        public static void Register(string name, string surname, string username, string password)
        {
            CheckExists:
            //if (Program.Users.Find(user => user.Username.Contains(username)) != default)
            //{
            //    Console.WriteLine("User with this username is already exists, Try again?(Yes/Y):");
            //    string response = Console.ReadLine().ToLower();
            //    if (response == "y" || response == "yes")
            //    {
            //        username = Console.ReadLine();
            //        goto CheckExists;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            foreach (var user in Program.Users)
            {
                if (user.Username == username)
                {
                    Console.WriteLine("User with this username is already exists, Try again?(Yes/Y):");
                    string response = Console.ReadLine().ToLower();
                    if (response == "y" || response == "yes")
                    {
                        username = Console.ReadLine();
                        goto CheckExists;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            CheckUsername:
            if (username.Length <= 4)
            {
                Console.WriteLine("Username must be longer than 4 symbols, Try again?(Yes/Y):");
                string response = Console.ReadLine().ToLower();
                if (response == "y" || response == "yes")
                {
                    username = Console.ReadLine();
                    goto CheckUsername;
                }
                else
                {
                    return;
                }
            }
            CheckPassword:
            if (password.Length <= 6)
            {
                Console.WriteLine("Password must be longer than 6 symbols, Try again(Yes/Y):");
                string response = Console.ReadLine().ToLower();
                if (response == "y" || response == "yes")
                {
                    username = Console.ReadLine();
                    goto CheckPassword;
                }
                else
                {
                    return;
                }
            }
            User newUser = new User()
            {
                Name = name,
                Surname = surname,
                Username = username,
                Password = password
            };
            Program.Users.Add(newUser);
        }

        public static void Login(string username, string password)
        {
            CheckUsername:
            foreach (var user in Program.Users)
            {
                if (user.Username != username)
                {
                    Console.WriteLine("User with this username does not exist, Try again?(Yes/Y):");
                    string response = Console.ReadLine().ToLower();
                    if (response == "y" || response == "yes")
                    {
                        username = Console.ReadLine();
                        goto CheckUsername;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        
            //if (Program.Users.Find(user => user.Username.Contains(username)).Password == password)
            //{
            //    Console.WriteLine($"User {username} is logged in");
            //    Program.LogedIn = Program.Users.Find(user => user.Username.Contains(username));
            //    return;
            //} else
            //{
            //    Console.WriteLine("Password is wrong. Try again(Yes/Y)");
            //    string response = Console.ReadLine().ToLower();
            //    if (response == "y" || response == "yes")
            //    {
            //        password = Console.ReadLine();
            //        goto CheckPass;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            foreach (var user in Program.Users)
            {
                if (user.Username == username)
                {
                CheckPass:
                    if (user.Password == password)
                    {
                        Console.WriteLine("User is logged in");
                        Program.LogedIn = user;
                    } else
                    {
                        Console.WriteLine("Password is wrong. Try again(Yes/Y)");
                        string response = Console.ReadLine().ToLower();
                        if (response == "y" || response == "yes")
                        {
                            password = Console.ReadLine();
                            goto CheckPass;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        public static void Logout ()
        {
            if (Program.LogedIn != null)
            {
                Console.WriteLine($"User {Program.LogedIn.Username} is loged out");
                Program.LogedIn = null;
            }
            else
            {
                Console.WriteLine("User is not logged in");
            }
        }
    }
}
