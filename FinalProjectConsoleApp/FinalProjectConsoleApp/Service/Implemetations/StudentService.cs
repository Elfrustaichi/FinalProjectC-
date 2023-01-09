using FinalProjectConsoleApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FinalProjectConsoleApp.Models;

namespace FinalProjectConsoleApp.Service.Implemetations
{
    internal class StudentService : IStudentService
    {
        public void CreateStudent(int GroupNo, bool Type, string Name, string Surname)
        {
            foreach (Models.Group group in GroupService.GroupsList)
            {
                if (group.Limit < GroupService.GroupsList.Count)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your group is full.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    if (GroupNo == group.No)

                    {
                        Student student = new Student(GroupNo, Type, Name, Surname);
                        group.StudentsList.Add(student);
                        Console.WriteLine($"In this group:{group.No} student created.");

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("There is no such Group.");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }

            }
        }
    }
}
