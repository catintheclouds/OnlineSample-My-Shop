﻿using MyShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;
        public BasketController (IBasketService BasketService)
        {
            this.basketService = BasketService;
        }
        // GET: Basker
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }
        public ActionResult AddToBasket (string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);
            return Redirect("~/Home/Index/"); //woot I did it!
        }
        public ActionResult RemoveFromBasket (string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveAllFromBasket(string Id)
        {
            basketService.RemoveAllFromBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);
            return PartialView(basketSummary);
        }
    }
}