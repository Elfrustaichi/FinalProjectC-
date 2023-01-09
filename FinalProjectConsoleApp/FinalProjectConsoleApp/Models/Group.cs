using FinalProjectConsoleApp.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp.Models
{
    internal class Group
    {
        public List<Student> StudentsList { get; set; } = new List<Student>();

        public int No { get; set; }

        public GroupCategories Category { get; set; }

        public bool IsOnline { get; set; }

        public int Limit { get; set; }

        public Group(int GroupNo, GroupCategories Category, bool IsOnline)
        {
            this.No = GroupNo;
            this.Category = Category;
            this.IsOnline = IsOnline;
            if (IsOnline == true)
            {
                this.Limit = 15;
            }
            else
            {
                this.Limit = 10;
            }
        }





    }
}
