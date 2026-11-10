using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class VendingMachineUser
    {

        public string Name { get; set; } = "";
        public UserTypes UserType { get; set; }
        public bool IsActive { get; set; } = true;
        public int UserTimeOutInSeconds { get; set; }


    }
}
