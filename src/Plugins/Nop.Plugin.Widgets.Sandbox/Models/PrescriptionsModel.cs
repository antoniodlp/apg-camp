using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.Sandbox.Domain;

namespace Nop.Plugin.Widgets.Sandbox.Models
{

    public class PrescriptionModel
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public int ItemsCount{ get; set; }
        public List<PrescriptionItemModel> Items { get; set; }
    }

    public class PrescriptionItemModel
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class PrescriptionsModel
    {
        public List<PrescriptionModel> Prescriptions { get; set; }
    }
}
