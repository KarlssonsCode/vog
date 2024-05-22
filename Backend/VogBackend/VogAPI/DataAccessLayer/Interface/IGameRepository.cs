using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace DataAccessLayer.Interface
{
    public interface IGameRepository
    {
        Task<Game> AddGame(Game game);
        Task<List<Game>> GetAllGamesAsync();
    }
}

