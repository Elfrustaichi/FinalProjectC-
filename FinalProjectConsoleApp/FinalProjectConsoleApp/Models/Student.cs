using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp.Models
{
    internal class Student
    {
        public string FullName { get; set; }

        public int GroupNo { get; set; }

        public bool Type { get; set; }

        public Student(int GroupNo, bool Type, string Name, string Surname)
        {
            this.GroupNo = GroupNo;
            this.Type = Type;
            FullName = $"{Name} {Surname}";
        }


    }
}