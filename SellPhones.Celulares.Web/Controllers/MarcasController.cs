using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SellPhones.Celulares.Business;
using SellPhones.Celulares.Data.Entity.Context;
using SellPhones.Celulares.Repositories.Common;
using SellPhones.Celulares.Repositories.Entity;
using SellPhones.Celulares.Web.Filters;
using SellPhones.Celulares.Web.ViewModels.Marca;

namespace SellPhones.Celulares.Web.Controllers
{
    [Authorize]
    [LogActionFilter]
    public class MarcasController : Controller
    {
        private IRepositoryGeneric<Marca, int>
           repositoryMarcas = new MarcasRepository(new CelularDbContext());

        // GET: Marcas
        
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Marca>, List<MarcaIndexViewModel>>(repositoryMarcas.Select()));
        }

        public ActionResult FilterByName(string search)
        {
            List<Marca> marcas = repositoryMarcas
                .Select()
                .Where(a => a.Nome.Contains(search)).ToList();

            List<MarcaIndexViewModel> viewModels = Mapper
                .Map<List<Marca>, List<MarcaIndexViewModel>>(marcas);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Marcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = repositoryMarcas.SelectById(id.Value);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Marca, MarcaIndexViewModel>(marca));
        }

        // GET: Marcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] MarcaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Marca marca = Mapper.Map<MarcaViewModel, Marca>(viewModel);
                repositoryMarcas.Insert(marca);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Marcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = repositoryMarcas.SelectById(id.Value);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Marca, MarcaViewModel>(marca));
        }

        // POST: Marcas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] MarcaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Marca marca = Mapper.Map<MarcaViewModel, Marca>(viewModel);
                repositoryMarcas.Update(marca);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Marcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marca marca = repositoryMarcas.SelectById(id.Value);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Marca, MarcaIndexViewModel>(marca));
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositoryMarcas.DeleteById(id);
            return RedirectToAction("Index");
        }

    }
}
