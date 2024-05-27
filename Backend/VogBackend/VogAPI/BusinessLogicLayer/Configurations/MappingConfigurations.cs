using BusinessLogicLayer.Contracts.Responses;
using Mapster;
using VogAPI.Models;


namespace BusinessLogicLayer.Configurations
{
    public class MappingConfigurations : TypeAdapterConfig
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Backlog, GetBacklogResponse>
             .NewConfig()
             .Map(dest => dest.Id, src => src.Id)
             .Map(dest => dest.UserId, src => src.UserId)
             .Map(dest => dest.GameId, src => src.GameId)
             .Map(dest => dest.Title, src => src.Game != null ? src.Game.Title : null)
             .Map(dest => dest.BackgroundImage, src => src.Game != null ? src.Game.BackgroundImage : null)
             .Map(dest => dest.ReleaseDate, src => src.Game != null ? src.Game.ReleaseDate : default)
             .Map(dest => dest.Description, src => src.Game != null ? src.Game.Description : null)
             .Map(dest => dest.Metacritic, src => src.Game != null ? src.Game.Metacritic : null)
             .MaxDepth(1);
        }
    }
}
