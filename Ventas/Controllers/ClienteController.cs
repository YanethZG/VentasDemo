using Microsoft.AspNetCore.Mvc;
using Ventas.Data;
using Ventas.Models;

namespace Ventas.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            ClienteData clienteData = new ClienteData();
            return View(clienteData.GetAll());
        }
        [HttpGet]
        public IActionResult Create() { 
        return View();
        }
        [HttpPost]
        public IActionResult Create(ClienteModel clienteModel)
        {
            try
            {
                ClienteData clienteData = new ClienteData();
                clienteData.Add(clienteModel);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(clienteModel);
            }
           
        }
        [HttpGet]
        public IActionResult Edit(int id) {
        ClienteData clienteData=new ClienteData();
            var cliente = clienteData.GetById(id);
            if (cliente == null) {
            return NotFound();
            }                                                    
            return View (cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClienteModel clienteModel)
        {
            try
            {
                ClienteData clienteData = new ClienteData();
                clienteData.Edit(clienteModel);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(clienteModel);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ClienteData clienteData = new ClienteData();
            var cliente = clienteData.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        public  IActionResult Delete(ClienteModel clienteModel)
        {
            try
            {
                ClienteData clienteData = new ClienteData();
                clienteData.Delete(clienteModel.IdCliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(clienteModel);
            }
        }

    }
}
