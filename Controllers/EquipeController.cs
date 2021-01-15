using System.IO;
using EPlayers_ASPNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_ASPNetCore.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = int.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            
            //Upload início
            if(form.Files.Count > 0)
            {
                //Recebemos o arquivo que o usuário enviou e armazenamos na variável
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if(!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using(var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                novaEquipe.Imagem = file.FileName;
            }
            else
            {
                novaEquipe.Imagem   = "padrao.png";
            }

            equipeModel.Create(novaEquipe);//Salva a equipe no CSV
            ViewBag.Equipes = equipeModel.ReadAll();//Atualiza a lista de equipes na View
            return LocalRedirect("~/Equipe/Listar");
        }
        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            equipeModel.Delete(id);
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}