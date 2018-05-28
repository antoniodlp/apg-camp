using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Data;
using Nop.Plugin.Widgets.Sandbox.Domain;
using Nop.Plugin.Widgets.Sandbox.Models;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.Sandbox.Controllers
{
    public class SandboxPageController : BasePluginController
    {
        private readonly IRepository<SandboxPrescription> _prescriptionRepository;
        private readonly IRepository<SandboxPrescriptionItem> _prescriptionItemRepository;

        public SandboxPageController(IRepository<SandboxPrescription> prescriptionRepository, IRepository<SandboxPrescriptionItem> prescriptionItemRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _prescriptionItemRepository = prescriptionItemRepository;
        }


        public IActionResult Index()
        {
            return View("~/Plugins/Widgets.Sandbox/Views/SandboxPage/Index.cshtml");
        }

        public IActionResult Prescriptions()
        {

            var prescriptions = _prescriptionRepository.TableNoTracking
                .Select(x => new PrescriptionModel() {
                        Id = x.Id,
                        Date = x.Date,
                        Patient = x.Patient,
                        Diagnosis = x.Diagnosis,
                        ItemsCount = x.Items.Count()
                    }).ToList();

            var model = new PrescriptionsModel()
            {
                Prescriptions = prescriptions
            };

            return View("~/Plugins/Widgets.Sandbox/Views/SandboxPage/Prescriptions.cshtml", model);
        }

        public IActionResult Prescription(int id)
        {
            var model = _prescriptionRepository.TableNoTracking
                .Where(x => x.Id == id)
                .Select(x => new PrescriptionModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    Patient = x.Patient,
                    Diagnosis = x.Diagnosis,
                    ItemsCount = x.Items.Count(),
                    Items = x.Items.Select(y => new PrescriptionItemModel()
                    {
                        Id = y.Id,
                        Item = y.Item,
                        IsAvailable = y.IsAvailable
                    }).ToList()


                }).FirstOrDefault();


            return View("~/Plugins/Widgets.Sandbox/Views/SandboxPage/Prescription.cshtml", model);
        }

        public IActionResult Dispatch(int id)
        {

            var prescription = _prescriptionRepository.Table
                                    .Include(x => x.Items)
                                    .SingleOrDefault(x => x.Id == id);

            if (prescription != null)
            {
                var items = prescription.Items.ToList();

                _prescriptionItemRepository.Delete(items);
                
                _prescriptionRepository.Delete(prescription);

                SuccessNotification($"Prescription {id} has been dispatched", true);
            }

            return RedirectToAction("Prescriptions");

        }

    }
}
