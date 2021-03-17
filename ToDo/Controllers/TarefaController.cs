using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class TarefaController : Controller
    {
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

    }
}
