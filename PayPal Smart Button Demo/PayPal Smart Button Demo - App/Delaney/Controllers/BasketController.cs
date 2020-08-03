/*********************************************************
       Code Generated By  .  .  .  .  Delaney's Script Bot
       WWW .  .  .  .  .  .  .  .  .  www.scriptbot.io
       Version.  .  .  .  .  .  .  .  10.0.0.14 
       Build  .  .  .  .  .  .  .  .  20191113 216
       Template Name.  .  .  .  .  .  Project Green 2.0
       Template Version.  .  .  .  .  20200529 002
       Author .  .  .  .  .  .  .  .  Delaney

                      ,        ,--,_
                       \ _ ___/ /\|
                       ( )__, )
                      |/_  '--,
                        \ `  / '

 *********************************************************/

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delaney.Areas.Controllers
{
    public partial class BasketController : Delaney.Controllers.Abstract
    {
        public BasketController(Delaney.Services.Data.Core.IUnitOfWork unitOfWork) : base(unitOfWork) {}


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                IEnumerable<Services.Data.Core.Domain.Basket> baskets = null;

                baskets = _unitOfWork.Baskets.GetAll();

                var Models = new List<Models.Basket>();

                if(baskets != null)
                    foreach(var core in baskets)
                    {
                        var model = new Models.Basket(core);
                        Models.Add(model);
                    }

                var summary = new Models.Summary<Models.Basket>
                {
                    Models = Models,
                    Count = Models.Count,
                };
                
                return View(summary);
            }
            catch
            {              
                ModelState.AddModelError(
                        "Error",
                        "Cannot get the baskets");
                
                return View();
            }
        }

        [HttpGet]
        public IActionResult Detail (int? id)
        {
            if (id == null)
                return Redirect("~/basket");

            var basket = _unitOfWork.Baskets.GetWithParents((int)id);

            if (basket == null)
                return Redirect(
                    "/../Basket");
            else
            {
                var model = new Models.Basket(basket);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete (int? id)
        {
            if (id == null)
                return Redirect("~/basket");

            var basket = _unitOfWork.Baskets.Get(id);

            if (basket == null)
                return Redirect("/../Basket");
            else
            {
                var model = new Models.Basket(basket);
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult Delete(Models.Basket model)
        {
            if (ModelState.IsValid)
            {
                if(model == null)
                    return View(model);

                if(model.Id == null)
                    return View(model);

                try
                {
                    if (_unitOfWork.Baskets
                                   .Remove((int)model.Id,
                                           out string errorMessage) != Services.Data.DataStoreResult.Success)
                    {
                        ModelState.AddModelError("Error",
                                                 errorMessage);
                        return View(model);
                    }
                

                    _unitOfWork.Complete();

                    return Redirect(
                        "/../Basket");
                }
                catch
                {
                    ModelState.AddModelError("Error",
                                             "Cannot delete the Basket.");
                    return View(model);
                }

            }
            else
                return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            Services.Data.Core.Domain.Basket basket;

            if (Id == null)
                basket = new Services.Data.Core.Domain.Basket();
            else
            {
                basket = _unitOfWork.Baskets.Get((int)Id);

                if (basket == null)
                    return Redirect(
                        "/../Basket");
            }

            var model = new Models.Basket(basket);

            // Model parents and children
            //model.PopulateChilden();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Models.Basket model)
        {
            if (model != null)
            {
                // Temporary remove many to many selected collections,
                // as they will cause invalid model state if there are any required fields on the many to many selected.
                ModelState.Clear();
                TryValidateModel(model);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Baskets.Add(model.GetCore());

                    return View(model);
                }
                catch
                {
                    ModelState.AddModelError(
                        "Error",
                        "Problem saving the basket.");

                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Cancel()
        {
            return Redirect(
                "/../Basket");
        }
    }
}