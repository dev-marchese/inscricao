using Inscricao.Business;
using Inscricao.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Inscricao.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AlunoBs _aluno;
        private readonly AlunoMatriculaBs _alunoMatricula;

        public AlunoController(AlunoBs aluno, AlunoMatriculaBs alunoMatricula)
        {
            _aluno = aluno;
            _alunoMatricula = alunoMatricula;
        }

        [Route("/Aluno/Index/{alunoId:int=0}")]
        public IActionResult Index(int alunoId)
        {
            if (alunoId > 0)
            {
                var model = _aluno.Get(alunoId);
                return View(model);
            }

            return View(new Aluno());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Aluno/Create")]
        public IActionResult Create([FromBody] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int alunoId = _aluno.Save(aluno);
                    return Json(new { status = aluno.AlunoId > 0, alunoId });
                }

                return Json(new { status = false, alunoId = 0 });
            }
            catch (Exception ex)
            {
                return Json(new { status = false, alunoId = 0 });
            }
        }
    }
}
