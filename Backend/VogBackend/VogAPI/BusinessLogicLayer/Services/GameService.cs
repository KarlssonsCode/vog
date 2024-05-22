using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VogAPI.Models;

namespace BusinessLogicLayer.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> AddGame(Game game)
        {
            return await _gameRepository.AddGame(game);
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return await _gameRepository.GetAllGamesAsync();
        }
    }
}
