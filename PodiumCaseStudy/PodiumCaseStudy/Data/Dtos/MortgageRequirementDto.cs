﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Data.Dtos
{
    public class MortgageRequirementDto
    {
        public string Id { get; set; }
        public int PropertyValue { get; set; }
        public int DepositAmount { get; set; }
    }
}