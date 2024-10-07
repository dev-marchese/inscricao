using Inscricao.Business;
using Inscricao.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Inscricao.Web.Controllers
{
    public class MatriculaController : Controller
    {
        private readonly AlunoMatriculaBs _alunoMatricula;
        private readonly CursoBs _curso;
        private readonly AlunoBs _aluno;

        public MatriculaController(AlunoMatriculaBs alunoMatricula, CursoBs curso, AlunoBs aluno)
        {
            _alunoMatricula = alunoMatricula;
            _curso = curso;
            _aluno = aluno;
        }

        [Route("/Matricula/Index/{alunoId:int=0}")]
        public IActionResult Index(int alunoId)
        {
            if (alunoId > 0)
            {
                var model = _aluno.Get(alunoId);
                model.Cursos = _curso.ListAll(alunoId);
                model.Matriculas = _alunoMatricula.Get(alunoId).ToList();

                return View(model);
            }

            return View(new Aluno());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Matricula/Create")]
        public IActionResult Create([FromBody] AlunoMatricula matricula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retorno = _alunoMatricula.Save(matricula.AlunoId, matricula.CursoId);
                    if (retorno != null)
                        return Json(new { status = true, alunoId = retorno.AlunoId });
                    else
                        return Json(new { status = false });
                }

                return Json(new { status = false });
            }
            catch (Exception ex)
            {
                return Json(new { status = false });
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        [Route("/Matricula/Delete")]
        public IActionResult Delete([FromBody] AlunoMatricula matricula)
        {
            try
            {
                var retorno = _alunoMatricula.Delete(matricula.AlunoId, matricula.Semestre, matricula.CursoId);
                return Json(new { status = retorno, alunoId = matricula.AlunoId });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
    }
}
