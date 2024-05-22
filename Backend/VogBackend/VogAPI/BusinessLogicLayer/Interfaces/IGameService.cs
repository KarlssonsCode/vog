using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGameService
    {
        Task<Game> AddGame(Game game);
        Task<List<Game>> GetAllGamesAsync();
    }
}
