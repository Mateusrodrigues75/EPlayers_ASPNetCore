using System.Collections.Generic;
using System.IO;
using EPlayers_ASPNetCore.Interfaces;

namespace EPlayers_ASPNetCore.Models
{
    public class Noticias : EplayersBase , INoticias
    {

        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/Noticias.csv";
        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }
        public string Prepare(Noticias n){
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }
        public void Create(Noticias n)
        {
            string[] linhas = {Prepare(n)};
            File.AppendAllLines(PATH,linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Noticias> ReadAll()
        {
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string item in linhas)
            {
                string[] linha = item.Split(";");

                Noticias novaNoticia = new Noticias();
                novaNoticia.IdNoticia = int.Parse(linha[0]);
                novaNoticia.Titulo = linha[1];
                novaNoticia.Texto = linha[2];
                novaNoticia.Imagem = linha[3];

                noticias.Add(novaNoticia);
            }
            return noticias;
        }

        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( Prepare(n) );
            RewriteCSV(PATH, linhas);
        }
    }
}