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
using Nop.Services.Catalog;
using Nop.Web.Framework.Controllers;
using SoapTest;

namespace Nop.Plugin.Widgets.Sandbox.Controllers
{
    public class SandboxPageController : BasePluginController
    {
        private readonly IRepository<SandboxPrescription> _prescriptionRepository;
        private readonly IRepository<SandboxPrescriptionItem> _prescriptionItemRepository;
        private readonly IProductService _productService;
        private readonly CartClient _cartClient;

        public SandboxPageController(IRepository<SandboxPrescription> prescriptionRepository, 
            IRepository<SandboxPrescriptionItem> prescriptionItemRepository, IProductService productService, CartClient cartClient)
        {
            _prescriptionRepository = prescriptionRepository;
            _prescriptionItemRepository = prescriptionItemRepository;
            _productService = productService;
            _cartClient = cartClient;
        }


        public IActionResult Index()
        {

            var products = _productService.GetLowStockProducts().ToList();


            return View("~/Plugins/Widgets.Sandbox/Views/SandboxPage/Index.cshtml", products);
        }

        [Route("Books")]
        [Route("Books/Search/{search}")]
        public async Task<IActionResult> Service([FromRoute]string search = "")
        {

            var response = await _cartClient.getItemByTitleAsync(search);

            var model = response.Result.Take(10).ToList();

            return View("~/Plugins/Widgets.Sandbox/Views/SandboxPage/Service.cshtml", model);
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
