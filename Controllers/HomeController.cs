using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inscricao.Data;
using Inscricao.Dto;
using Inscricao.Business;

namespace Inscricao.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlunoBs _aluno;
        private readonly AlunoMatriculaBs _alunoMatricula;

        public HomeController(AlunoBs aluno, AlunoMatriculaBs alunoMatricula)
        {
            _aluno = aluno;
            _alunoMatricula = alunoMatricula;
        }

        public IActionResult Index()
        {
            var model = _aluno.ListAll();
            return View(model);
        }
    }
}
