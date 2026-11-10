using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class VendingMachineUser
    {
        private string _name;
        private UserTypes _type = UserTypes.Employee;
        private bool _isActive;
        private VendingMachine vendingMachine;
    }
}
