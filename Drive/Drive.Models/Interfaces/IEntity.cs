using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IEntity
    {
        int ID { get; set; }
        string DisplayName { get; }
        DateTime Modyfication { get; set; }
        DateTime Create { get; set; }
    }
}
