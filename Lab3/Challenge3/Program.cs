using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge3
{
    internal class Program
    {
        static void loginPage()
        {
            Console.WriteLine("\t \t \t \t \t \tLOGIN PAGE ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" 1. Sign In with your credentials.");
            Console.WriteLine(" 2. Sign Up your credentials");
            Console.WriteLine(" 3. Exit");
        }
        static bool ExistedUsername(string name, Sign[] users, int userCount)
        {
            for (int i = userCount - 1; i >= 0; i--)
            {
                if (name == users[i].name)
                {
                    return true;
                }
            }
            return false;
        }
        static bool CheckUserName(string word, Sign[] users, int userCount)
        {
            if (ExistedUsername(word, users, userCount))
            {
                Console.WriteLine("Username already taken. Please choose another.");
                return false;
            }

            if (word.Length > 5)
            {
                int letterCount = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];

                    if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                    {
                        letterCount++;
                    }
                    else if (!(c >= '0' && c <= '9'))
                    {
                        Console.WriteLine("Invalid character in username. Use only letters and numbers.");
                        return false;
                    }
                }

                if (letterCount >= 3)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username. Username must contain at least 3 letters.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid username. Username must be at least 6 characters long.");
                return false;
            }
        }
        static bool checkOptionValidation(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }
            return true;
        }
        static string SignIn(string name, string password, Sign[] users, int userCount)
        {
            for (int j = 0; j < userCount; j++)
            {
                if (name == users[j].name && password != users[j].password)
                {
                    return "You have entered the wrong password.";
                }
            }

            for (int j = 0; j < userCount; j++)
            {
                if (name != users[j].name && password == users[j].password)
                {
                    return "You have entered the wrong username.";
                }
            }

            for (int j = 0; j < userCount; j++)
            {
                if (name == users[j].name && password == users[j].password)
                {
                    Console.Clear();
                    return users[j].role;
                }
            }

            return "You are not registered yet.";
        }
        static void Main(string[] args)
        {
            Sign[] users = new Sign[100];
            int userCount = 0;
            string mName, mPassword, mRole, mAccount;
            ReadUserInfo(users, ref userCount);
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                int opt;
                string input;
                loginPage();
                Console.WriteLine("Enter the option...");
                input = Console.ReadLine();
                if (checkOptionValidation(input))
                {
                    opt = int.Parse(input);
                    if (opt == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("\t \t \t \t \t \t SIGN IN PAGE ");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");

                        string Name, Password;

                        while (true)
                        {
                            while (true)
                            {
                                Console.Write("Enter Username: ");
                                Name = Console.ReadLine();
                                if (string.IsNullOrEmpty(Name))
                                {
                                    Console.WriteLine("UserName cannot be empty.");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.Write("Enter Password: ");
                                Password = Console.ReadLine();
                                if (string.IsNullOrEmpty(Password))
                                {
                                    Console.WriteLine("Password cannot be empty.");
                                }
                                else
                                {
                                    break;
                                }
                            }

                            string userRole = SignIn(Name, Password, users, userCount);
                            string upperUserRole = userRole.ToUpper();

                            if (upperUserRole == "ADMIN")
                            {
                                Console.WriteLine("Signing in as an ADMIN.");
                                Thread.Sleep(1500);
                                break;
                            }
                            else if (upperUserRole == "CUSTOMER")
                            {
                                Console.WriteLine("Signing in as a Customer.");
                                Thread.Sleep(1500);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(userRole);
                            }
                        }
                    }
                    else if (opt == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("\t \t \t \t \t \t SIGN UP PAGE");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Instructions for Sign Up => \n Username must be at least 6 characters long and must not contain any special character and contain at least 3 letters \n Password must be at least 8 characters long\n");

                        while (true)
                        {
                            Console.Write("Enter Username: ");
                            mName = Console.ReadLine();
                            if (CheckUserName(mName, users, userCount))
                            {
                                break;
                            }
                        }

                        while (true)
                        {
                            Console.Write("Enter Password: ");
                            mPassword = Console.ReadLine();
                            if (mPassword.Length < 8)
                            {
                                Console.WriteLine("Invalid input. Password does not contain 8 characters.");
                                continue;
                            }
                            break;
                        }

                        while (true)
                        {
                            Console.Write("Enter your role (Admin/Customer): ");
                            mRole = Console.ReadLine().ToUpper();
                            if (mRole != "ADMIN" && mRole != "CUSTOMER")
                            {
                                Console.WriteLine("\nInvalid Role. Please select a valid role.");
                                continue;
                            }
                            break;
                        }

                        if (mRole == "CUSTOMER")
                        {
                            while (true)
                            {
                                Console.Write("Enter your Account Number (Must be 13 digits): ");
                                mAccount = Console.ReadLine();
                                if (mAccount.Length == 13 && checkOptionValidation(mAccount))
                                {
                                    users[userCount] = new Sign(mName, mPassword, mRole, mAccount);
                                    users[userCount].StoreUserInfo();
                                    Console.WriteLine("\nYou have successfully registered your credentials.");
                                    userCount++;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Account Number / Account Number must be 13 digits.");
                                }
                            }
                        }
                        else if (mRole == "ADMIN")
                        {
                            users[userCount].StoreUserInfo();
                            Console.WriteLine("\nYou have successfully registered your credentials.");
                            userCount++;
                        }
                    }
                    else if (opt == 3)
                    {
                        Console.Clear();

                        Console.WriteLine("Thanks for coming here.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option Selection.");
                        Thread.Sleep(750);
                        Console.Clear();
                        continue;
                    }

                    Console.WriteLine("\n\n\nPress any Key to go to Login Page...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please write valid input.");
                    Thread.Sleep(750);
                    Console.Clear();
                }
            }
        }
        static string ParseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";

            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[x];
                }
            }

            return item;
        }
        static void ReadUserInfo(Sign[] users, ref int userCount)
        {
            string record;
            StreamReader file = new StreamReader("Users.txt");
            while ((record = file.ReadLine()) != null)
            {
                string name = ParseData(record, 1);
                string password = ParseData(record, 2);
                string role = ParseData(record, 3);
                string accountNo = ParseData(record, 4);
                Sign newObj = new Sign(name, password, role, accountNo);
                users[userCount] = newObj;
                userCount++;
            }
            file.Close();
        }
    }
}
