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
using SellPhones.Celulares.Web.ViewModels.Celular;
using SellPhones.Celulares.Web.ViewModels.Marca;

namespace SellPhones.Celulares.Web.Controllers
{
    public class CelularesController : Controller
    {
        private IRepositoryGeneric<Celular, int>
            repositoryCelulares = new CelularesRepository(new CelularDbContext());

        private IRepositoryGeneric<Marca, int>
           repositoryMarcas = new MarcasRepository(new CelularDbContext());

        // GET: Celulares
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Celular>, List<CelularIndexViewModel>>(repositoryCelulares.Select()));
        }

        // GET: Celulares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = repositoryCelulares.SelectById(id.Value);
            if (celular == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Celular, CelularIndexViewModel>(celular));
        }

        // GET: Celulares/Create
        public ActionResult Create()
        {
            List<MarcaIndexViewModel> marcas = Mapper.Map<List<Marca>,
                List<MarcaIndexViewModel>>(repositoryMarcas.Select());

            SelectList dropDownMarcas = new SelectList(marcas, "Id", "Nome");
            ViewBag.DropDownMarcas = dropDownMarcas;

            return View();
        }

        // POST: Celulares/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCelular,Modelo,IdMarca,Cor,Preco,Imei")] CelularViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Celular celular = Mapper.Map<CelularViewModel, Celular>(viewModel);
                repositoryCelulares.Insert(celular);
                return RedirectToAction("Index");
            }

            List<MarcaIndexViewModel> marcas = Mapper.Map<List<Marca>,
                List<MarcaIndexViewModel>>(repositoryMarcas.Select());

            SelectList dropDownMarcas = new SelectList(marcas, "Id", "Nome");
            ViewBag.DropDownMarcas = dropDownMarcas;

            return View(viewModel);
        }

        // GET: Celulares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = repositoryCelulares.SelectById(id.Value);
            if (celular == null)
            {
                return HttpNotFound();
            }

            List<MarcaIndexViewModel> marcas = Mapper.Map<List<Marca>,
                List<MarcaIndexViewModel>>(repositoryMarcas.Select());

            SelectList dropDownMarcas = new SelectList(marcas, "Id", "Nome");
            ViewBag.DropDownMarcas = dropDownMarcas;

            return View(Mapper.Map<Celular, CelularViewModel>(celular));
        }

        // POST: Celulares/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCelular,Modelo,IdMarca,Cor,Preco,Imei")] CelularViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Celular celular = Mapper.Map<CelularViewModel, Celular>(viewModel);
                repositoryCelulares.Update(celular);
                return RedirectToAction("Index");
            }

            List<MarcaIndexViewModel> marcas = Mapper.Map<List<Marca>,
                List<MarcaIndexViewModel>>(repositoryMarcas.Select());

            SelectList dropDownMarcas = new SelectList(marcas, "Id", "Nome");
            ViewBag.DropDownMarcas = dropDownMarcas;

            return View(viewModel);
        }

        // GET: Celulares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = repositoryCelulares.SelectById(id.Value);
            if (celular == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Celular, CelularIndexViewModel>(celular));
        }

        // POST: Celulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositoryCelulares.DeleteById(id);
            return RedirectToAction("Index");
        }

    }
}
