using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models.Interfaces
{
    public interface IUnit : IEntity
    {
        string Name { get; set; }
        string Short { get; set; }
        decimal Exponent { get; set; }
        int BaseValue { get; }
    }
}
