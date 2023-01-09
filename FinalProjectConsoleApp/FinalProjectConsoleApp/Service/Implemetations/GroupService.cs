using FinalProjectConsoleApp.Enums;
using FinalProjectConsoleApp.Models;
using FinalProjectConsoleApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp.Service.Implemetations
{
    internal class GroupService : IGroupService
    {
        public static List<Group> GroupsList { get; set; } = new List<Group>();
        public string CreateGroup(int GroupNo, GroupCategories Category, bool IsOnline)
        {
            Group group = new Group(GroupNo, Category, IsOnline);
            GroupsList.Add(group);
            return $"This group:{group.No} created";
            
        }

        public void EditGroup(int GroupNo, int NewGroupNo)
        {
            foreach (Group group in GroupsList)
            {
                if (GroupNo == group.No)
                {
                    group.No = NewGroupNo;

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

        public void ShowAllGroups()
        {
            foreach (Group group in GroupsList)
            {
                Console.WriteLine($"-GroupNo:{group.Category.ToString().Substring(0,1)}-{group.No} -GroupCategory:{group.Category} -GroupIsOnline:{group.IsOnline}");
            }
        }

        public void ShowAllStudents()
        {
            if (GroupsList.Count == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Your group list is empty.");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                foreach (Group group in GroupsList)
                {
                    if (group.StudentsList.Count == 0)
                    {
                        Console.WriteLine($"Your student list is empty in this group:{group.No}");
                    }
                    else
                    {
                        foreach (Student student in group.StudentsList)
                        {
                            Console.WriteLine($"Group-{group.No} FullName-{student.FullName} Student is zemanetli-{student.Type}");
                        }
                    }

                }
            }

        }

        public void ShowSpecificGroupStudents(int GroupNo)
        {

            foreach (Group group in GroupsList)
            {
                if (GroupNo == group.No)
                {
                    if (group.StudentsList.Count == 0)
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Your Student list empty in this group:{group.No}");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        foreach (Student student in group.StudentsList)
                        {
                            Console.WriteLine($"Student's FullName-{student.FullName} Student's Group-{student.GroupNo} Students is Zemanetli-{student.Type}");
                        }
                    }

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no such group.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}
