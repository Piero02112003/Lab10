using Business;
using Demo09.Models;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Demo09.Controllers
{
    public class InvoiceModelController : Controller
    {
        // GET: InvoiceModelController
        public ActionResult Index()
        {

            BInvoice bInvoice = new BInvoice();
            List<Invoice> invoicesEntity = bInvoice.GetInvoiceActives();

            List<InvoiceModel> invoices = invoicesEntity.Select(x => new InvoiceModel
            {
                Id = x.invoice_id,
                Total = x.total,
                Igv = x.total*18/100//Restar fechas para calcular edad

            }).ToList();


            return View(invoices);
        }

        // GET: InvoiceModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceModel invoice)
        {
            try
            {
                BInvoice bInvoice = new BInvoice();
                InvoiceModel invoice1 = new InvoiceModel 
                {
                    Id = invoice.Id,
                    Total = invoice.Total,
                    Igv = invoice.Igv,
                };
                BInvoice.insert(invoice1);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection model)
        {
            try
            {
                BInvoice bInvoice = new BInvoice();
                InvoiceModel invoice = new InvoiceModel
                {
                    Id = id,
                };
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
