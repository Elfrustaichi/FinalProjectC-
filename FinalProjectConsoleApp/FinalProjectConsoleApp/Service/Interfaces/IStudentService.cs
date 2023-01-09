using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp.Service.Interfaces
{
    internal interface IStudentService
    {
        public void CreateStudent(int GroupNo, bool Type, string Name, string Surname);
    }
}
