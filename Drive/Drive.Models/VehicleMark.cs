﻿using Drive.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Models
{
    public class VehicleMark : IEntity
    {
        public int ID { get; set; }
        public string DisplayName { get; }
        [Column(TypeName = "Date")]
        public DateTime Create { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Modyfication { get; set; }

        public string Name { get; set; }
        public virtual IList<VehicleModel> Models { get; set; }

        public VehicleMark()
        {
            Models = new List<VehicleModel>();
        }

        public VehicleMark(string markName) : this()
        {
            Name = markName;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
