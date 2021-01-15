using System.Collections.Generic;
using EPlayers_ASPNetCore.Models;

namespace EPlayers_ASPNetCore.Interfaces
{
    public interface INoticias
    {
         void Create(Noticias n);
        List<Noticias> ReadAll();
        void Update(Noticias n);
        void Delete(int id);
    }
}