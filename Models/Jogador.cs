using System.Collections.Generic;
using System.IO;
using EPlayers_ASPNetCore.Interfaces;

namespace EPlayers_ASPNetCore.Models
{
    public class Jogador : EplayersBase , IJogador
    {
        public int IdJogador { get; set; }
        
        public string Nome { get; set; }
        
        // Login
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdEquipe { get; set; }

        private const string PATH = "Database/Jogadores.csv";
        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }
        public string Prepare(Jogador j){
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe};{j.Email};{j.Senha}";
        }

        public void Create(Jogador j)
        {
            string[] linhas = {Prepare(j)};
            File.AppendAllLines(PATH,linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach(string item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador novoJogador = new Jogador();
                novoJogador.IdJogador = int.Parse(linha[0]);
                novoJogador.Nome = linha[1];
                novoJogador.IdEquipe = int.Parse(linha[2]);
                novoJogador.Email = linha[3];
                novoJogador.Senha = linha[4];

                jogadores.Add(novoJogador);
            }
            return jogadores;
        }

        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add( Prepare(j) );
            RewriteCSV(PATH, linhas);
        }
    }
}