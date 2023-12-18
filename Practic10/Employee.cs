using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic10
{
    public class Employee 
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Firstname { get; set; }
        public int Pasport {  get; set; }
        public int Role { get; set; }
        public int Salary { get; set; }
        public int UserId {  get; set; }
        public DateOnly Date { get; set; }
    }
}
