using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MWeb1_2.Models;

namespace MWeb1_2.Controllers
{
    public class MarkerController : Controller
    {
        private IMarkerRepository repository;

        public MarkerController(IMarkerRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Markers);
    }
}
