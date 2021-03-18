using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private static IList<Tarefa> tarefas =
            new List<Tarefa>()
            {
                new Tarefa()
                {
                    ToDo = "Estudar .NET",
                    TarefaID = 1
                }
            };
        public IActionResult Index()
        {
            return View(tarefas.OrderBy(i => i.TarefaID));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarefa tarefa)
        {
            tarefas.Add(tarefa);
            tarefa.TarefaID = tarefas.Select(i => i.TarefaID).Max() + 1;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(tarefas.Where(i => i.TarefaID == id).First());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Details(long id)
        {
            return View(tarefas.Where(i => i.TarefaID == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tarefa tarefa)
        {
            tarefas.Remove(tarefas.Where(i => i.TarefaID == tarefa.TarefaID).First());
            tarefas.Add(tarefa);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
