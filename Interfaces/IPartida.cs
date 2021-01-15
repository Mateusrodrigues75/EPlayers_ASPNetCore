using System.Collections.Generic;
using EPlayers_ASPNetCore.Models;

namespace EPlayers_ASPNetCore.Interfaces
{
    public interface IPartida
    {
        void Create(Partida p);
        List<Partida> ReadAll();
        void Update(Partida p);
        void Delete(int id);
    }
}