using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Widgets.Sandbox.Domain
{
    public class SandboxPrescription : BaseEntity 
    {
        public string Patient { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public List<SandboxPrescriptionItem> Items { get; set; }

    }
}
