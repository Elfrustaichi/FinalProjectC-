using FinalProjectConsoleApp.Enums;
using FinalProjectConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp.Service.Implemetations
{
    internal static class MenuService
    {
        private static GroupService GroupService = new();
        private static StudentService StudentService = new();
        public static void CreateGroupMenu()
        {
        again:
            Console.Write("Add group no:");
            int.TryParse(Console.ReadLine(), out int GroupNo);
            if (GroupNo == 0 || GroupNo < 100)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid, group number must be number and must be more than 100.");
                Console.BackgroundColor = ConsoleColor.Black; 
                goto again;
            }
        restart:
            Console.WriteLine("Select Category:");
            foreach (var item in Enum.GetValues(typeof(GroupCategories)))
            {
                Console.WriteLine($"{(int)item}.{item}");
            }
            Console.Write("your selection-");

            int CategoriesLenght = Enum.GetValues(typeof(GroupCategories)).Length;

            int.TryParse(Console.ReadLine(), out int Selection);

            if (Selection <= 0 || Selection > CategoriesLenght)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid selection.");
                Console.BackgroundColor = ConsoleColor.Black;
                goto restart;
            }
        repeat:
            bool status;
            Console.WriteLine("Select Type of Group");
            Console.WriteLine("1.Online");
            Console.WriteLine("2.Offline");
            Console.Write("your selection-");
            int.TryParse(Console.ReadLine(), out int IsOnline);
            switch (IsOnline)
            {
                case 1:
                    status = true;
                    break;
                case 2:
                    status = false;
                    break;
                default:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter correct order");
                    Console.BackgroundColor = ConsoleColor.Black;
                    goto repeat;
            }
            Console.Clear();
            string result = GroupService.CreateGroup(GroupNo, (GroupCategories)Selection, status);
            Console.WriteLine(result);
        }

        public static void EditGroupMenu()
        {
        restart:
            Console.Write("Enter group no that you want to edit:");
            int.TryParse(Console.ReadLine(), out int GroupNo);
            Console.Write("Enter group no that you want to change to:");
            int.TryParse(Console.ReadLine(), out int NewGroupNo);
            if (GroupNo == 0 || NewGroupNo == 0 || GroupNo < 100 || NewGroupNo < 100)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid group numbers.Group numbers must be more than 100.");
                Console.BackgroundColor = ConsoleColor.Black;
                goto restart;
            }
            if (GroupService.GroupsList.Count == 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Group List is empty.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                foreach (Group group in GroupService.GroupsList)
                {

                    if (GroupNo == group.No)
                    {
                        Console.Clear();
                        GroupService.EditGroup(GroupNo, NewGroupNo);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Succesfully edited this group:{GroupNo}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is no such group.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    }


                }
            }




        }

        public static void ShowAllGroupsMenu()
        {
            if (GroupService.GroupsList.Count == 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Your group list is empty.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.Clear();
                GroupService.ShowAllGroups();
            }

        }

        public static void ShowSpecificGroupStudentsMenu()
        {
        again:
            Console.Write("Enter the group no:");
            int.TryParse(Console.ReadLine(), out int GroupNo);
            if (GroupNo == 0 || GroupNo < 100)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid group no.Group number must be more than 100.");
                Console.BackgroundColor = ConsoleColor.Black;
                goto again;
            }
            else
            {
                if (GroupService.GroupsList.Count == 0)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your group list is empty.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    foreach (Group group in GroupService.GroupsList)
                    {
                        if (group.No == GroupNo)
                        {
                            Console.Clear();
                            GroupService.ShowSpecificGroupStudents(GroupNo);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("There is no such group.");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                    }
                }

            }

        }

        public static void ShowAllStudentsMenu()
        {
            GroupService.ShowAllStudents();
        }

        public static void CreateStudentMenu()
        {
        again:
            bool type;
            Console.Write("Enter the group number that is student is in:");
            int.TryParse(Console.ReadLine(), out int GroupNo);
            if (GroupService.GroupsList.Count == 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Group List is empty.");
                Console.BackgroundColor = ConsoleColor.Black;


            }
            else
            {
                foreach (Group group in GroupService.GroupsList)
                {
                    if (GroupNo == group.No)
                    {
                        Console.WriteLine("Choose student's type:");
                        Console.WriteLine("1.Zemanetli");
                        Console.WriteLine("2.Zemanetsiz");
                        Console.Write("Your Choice-");
                        int.TryParse(Console.ReadLine(), out int choice);
                        if (GroupNo == 0)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid group number.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto again;
                        }
                        switch (choice)
                        {
                            case 1:
                                type = true;
                                break;
                            case 2:
                                type = false;
                                break;
                            default:
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice.");
                                Console.BackgroundColor = ConsoleColor.Black;
                                goto again;

                        }
                    repeat:
                        Console.Write("Enter the name of student:");
                        string name;
                        try
                        {
                            name = Console.ReadLine();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid name.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto repeat;
                        }

                        Console.Write("Enter the surname of student:");
                        string surname;
                        try
                        {
                            surname = Console.ReadLine();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid surname.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto repeat;
                        }
                        if (name.Length < 3 || surname.Length < 5)
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid name or surname.");
                            Console.BackgroundColor = ConsoleColor.Black;
                            goto repeat;
                        }
                        else
                        {
                            StudentService.CreateStudent(GroupNo, type, name, surname);
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is no such group.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    }
                }
            }




        }
    }

}
