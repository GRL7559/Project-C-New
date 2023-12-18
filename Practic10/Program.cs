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
                        break;
                    case (int)User.Roles.Warehouse:
                        break;
                    case (int)User.Roles.Cashier:
                        break;
                }
            }
        }
    }
}