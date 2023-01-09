using FinalProjectConsoleApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp.Service.Interfaces
{
    internal interface IGroupService
    {
        public string CreateGroup(int GroupNo, GroupCategories Category, bool IsOnline);

        public void ShowAllGroups();

        public void EditGroup(int GroupNo, int NewGroupNo);

        public void ShowSpecificGroupStudents(int GroupNo);

        public void ShowAllStudents();


    }
}