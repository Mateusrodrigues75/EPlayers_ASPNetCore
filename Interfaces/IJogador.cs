using System.Collections.Generic;
using EPlayers_ASPNetCore.Models;

namespace EPlayers_ASPNetCore.Interfaces
{
    public interface IJogador
    {
        void Create(Jogador j);
        List<Jogador> ReadAll();
        void Update(Jogador j);
        void Delete(int id);
    }
}