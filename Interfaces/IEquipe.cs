using System.Collections.Generic;
using EPlayers_ASPNetCore.Models;

namespace EPlayers_ASPNetCore.Interfaces
{
    public interface IEquipe
    {
        //Métodos CRUD -> Contrato
        void Create(Equipe e);
        List<Equipe> ReadAll();
        void Update(Equipe e);
        void Delete(int id);
    }
}