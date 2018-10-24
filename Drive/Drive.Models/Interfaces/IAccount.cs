using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IAccount : IEntity
    {
        string Email { get; set; }
        string Password { get; set; }
        IPerson Person { get; set; }
        IList<IFleet> Fleets { get; set; }

        bool ChangePassword(string newPassword);
        void ResetPassword();

    }
}
