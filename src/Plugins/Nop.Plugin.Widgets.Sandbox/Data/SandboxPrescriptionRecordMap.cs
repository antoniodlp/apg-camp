﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data.Mapping;
using Nop.Plugin.Widgets.Sandbox.Domain;

namespace Nop.Plugin.Widgets.Sandbox.Data
{
    public class SandboxPrescriptionRecordMap : NopEntityTypeConfiguration<SandboxPrescription>
    {
        public SandboxPrescriptionRecordMap()
        {
            ToTable("SandboxPrescription");
        }
    }
}
