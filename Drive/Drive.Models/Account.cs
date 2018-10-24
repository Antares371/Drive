using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class Account : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public virtual Person Person { get; set; }
        public virtual IList<Fleet> Fleets { get; set; }

        public static OnEventBeforeChangePassword OnBeforeChangePassword;
        public static EventHandler OnPasswordChanged;

        public bool CheckPassword(string password)
        {
            if(this.Password == password)
                return true;
            return false;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if(!CheckPassword(oldPassword))
                return false;

            if(OnBeforeChangePassword != null)
            {
                ChangePasswordEventArgs e = new ChangePasswordEventArgs(newPassword, oldPassword);
                OnBeforeChangePassword(this, e);
                if(e.Cancel)
                    return false;
            }

            this.Password = newPassword;

            if(OnPasswordChanged != null)
            {
                OnPasswordChanged(this, EventArgs.Empty);
            }
            return true;
        }
    }

    public delegate void OnEventBeforeChangePassword(object sender, ChangePasswordEventArgs e);

    public class ChangePasswordEventArgs : CancelEventArgs
    {
        private string oldPassword;
        public string OldPassword { get { return oldPassword; } }

        private string newPassword;
        public string NewPassword { get { return newPassword; } }

        public ChangePasswordEventArgs(string newPassword, string oldPassword)
        {
            this.newPassword = newPassword;
            this.oldPassword = oldPassword;
        }
    }
}
