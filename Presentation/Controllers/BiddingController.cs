using Application.Interfaces;
using Application.ViewModels;
using Domain.DTOs;
using Domain.Util;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Presentation.Controllers
{
    public class BiddingController : Controller
    {
        private readonly IBiddingAppService _biddingAppService;
        private readonly IToastNotification _toastNotification;
        private List<string> _errors = new List<string>();

        public BiddingController(IBiddingAppService biddingAppService, IToastNotification toastNotification)
        {
            _biddingAppService = biddingAppService;
            _toastNotification = toastNotification;
        }

        public JsonResult GetBiddings(BiddingPaginatedDTO biddingPaginated)
        {
            var (total, biddings) = _biddingAppService.GetPaginated(biddingPaginated);

            return this.Json(new { total, totalNotFilted = total, rows = biddings });
        }

        // GET: BiddingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BiddingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BiddingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BiddingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BiddingCreateVM bidding)
        {
            if (ModelState.IsValid)
            {
                _errors = _biddingAppService.Insert(bidding);
                if (_errors.Count == 0)
                {
                    _toastNotification.AddSuccessToastMessage("Nova Licitação cadastrada com sucesso", new ToastrOptions() { TimeOut = 10000 });
                    return RedirectToAction("Index");
                }
            }
            ModelStateMessage.AddModelStateError(_errors, string.Empty, ModelState);
            _toastNotification.AddErrorToastMessage("Falha ao cadastrar licitação");

            return View(bidding);
        }

        // GET: BiddingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BiddingController/Edit/5
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

        // GET: BiddingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BiddingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
