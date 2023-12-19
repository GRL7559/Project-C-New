using Practic5;

namespace Practic10
{
    internal class Program
    {
        static void Main()
        {
            while (true) 
            {
                User user = Auth.AuthUser();
                switch (user.Role)
                {
                    case (int)User.Roles.Administrator:
                        Administrator emp = new(user.Id);
                        break;
                    case (int)User.Roles.Manager:
                        Manager emp1 = new(user.Id);
                        break;
                    case (int)User.Roles.Accountant:
                        Accountant emp2 = new(user.Id);
                        break;
                    case (int)User.Roles.Warehouse:
                        Warehouse emp3 = new(user.Id);
                        break;
                    case (int)User.Roles.Cashier:
                        Cashier emp4 = new(user.Id);
                        break;
                }
            }
        }
    }
}