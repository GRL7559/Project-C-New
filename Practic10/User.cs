
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Practic10
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role {  get; set; }
        public enum Roles
        {
            Administrator,
            Manager,
            Accountant,
            Warehouse,
            Cashier
        }
    }
}
