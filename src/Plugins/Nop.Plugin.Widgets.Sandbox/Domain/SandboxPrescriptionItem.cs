using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Widgets.Sandbox.Domain
{
    public class SandboxPrescriptionItem : BaseEntity 
    {
        public int SandboxPrescriptionId { get; set; }
        public string Item { get; set; }
        public bool IsAvailable { get; set; }
        public SandboxPrescription SandboxPrescription { get; set; }
    }
}
