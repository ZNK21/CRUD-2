using CRUD.Context;
using CRUD.Entities;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CRUD.Controllers
{
    public class MantenedorController : Controller
    {
        public IActionResult Index()
        {
            return View(_Data.View_Carta.ToList());
        }

        public IActionResult Drop()
        {
            var t = new Table_TipoModels();
            t.ListTipo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Agua", Value = "1"},
                new SelectListItem { Text = "Aire", Value = "2"}
            };
            return PartialView("~/Views/Mantenedor/Drop.cshtml", t);
        }

        private readonly CrudContext _Data;

        public MantenedorController(CrudContext Data)
        {
            _Data = Data;
        }

        public JsonResult GetTipo()
        {
            List<Table_Tipo> tip = new List<Table_Tipo>();
            tip = _Data.Table_Tipo.Select(t => new Table_Tipo()
            {
                TipoID = t.TipoID,
                TipoTexto = t.TipoTexto,
            }).ToList();


            return Json(tip);
        }

        [HttpPost]
        public IActionResult Nuevo(Table_Carta c)
        {
            bool status = false;
            var result = new { status = status };

            try
            {
                Table_Carta ca = new Table_Carta
                {
                    CartaID = c.CartaID,
                    CartaNombre = c.CartaNombre,
                    TipoID = c.TipoID,
                    CartaFuerza = c.CartaFuerza,
                    CartaTexto = c.CartaTexto
                };

                _Data.Table_Carta.Add(ca);
                if (_Data.SaveChanges() > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            result = new { status };
            return Json(result);
        }

        public JsonResult Eliminar(int CartaID)
        {
            bool status = false;

            var result = new { status = status };

            var FindCarta = _Data.Table_Carta.Find(CartaID);

            try
            {
                if (FindCarta != null)
                {
                    _Data.Table_Carta.Remove(FindCarta);
                    if (_Data.SaveChanges() > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            result = new { status = status };
            return Json(result);
        }

        [HttpPost]
        public IActionResult Editar(Table_Carta c)
        {

            bool status = false;
            
            var result = new { status = status };

            try
            {
                Table_Carta model = new Table_Carta();
                model = _Data.Table_Carta.Find(c.CartaID);

                model.CartaNombre = c.CartaNombre;
                model.TipoID = c.TipoID;
                model.CartaFuerza = c.CartaFuerza;
                model.CartaTexto = c.CartaTexto;

                _Data.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                if (_Data.SaveChanges() >0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

                result = new { status = status};
                return Json(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;

        }

        public IActionResult EditarView(int CartaID)
        {
            try
            {
                if (CartaID > 0)
                {
                    View_Carta model = _Data.View_Carta.Find(CartaID);

                    return PartialView("~/Views/Mantenedor/EditarView.cshtml", model);


                }
            }
            catch
            {

            }

            return null;
        }
    }
}
