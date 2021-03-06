﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pis_c.ViewModels
{
    public class CarFilter
    {
        public double? CostFrom { get; set; }
        public double? CostTo { get; set; }
        public int? Year { get; set; }
        public bool DriverAirbag { get; set; }
        public bool PassangerAirbag { get; set; }
        public bool Abs { get; set; }
        public bool Asc { get; set; }
        public bool Esp { get; set; }
        public bool Climate { get; set; }
        public bool Ac { get; set; }
        public bool Cruise { get; set; }
        public int? SeatsAmmount { get; set; }
        public float? EngineVol { get; set; }
        public int? Power { get; set; }
        public int? CarClassId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? FuelTypeId { get; set; }
        public int? BodyTypeId { get; set; }
        public int? DriveTypeId { get; set; }
        public int? GearBoxId { get; set; }
        public string SortColumn { get; set; }
        public string SortRule { get; set; }
    }
}
