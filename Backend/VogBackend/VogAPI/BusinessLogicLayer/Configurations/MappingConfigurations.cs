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

            TypeAdapterConfig<UserReview, GetUserReviewResponse>
             .NewConfig()
             .Map(dest => dest.Id, src => src.Id)
             .Map(dest => dest.UserId, src => src.UserId)
             .Map(dest => dest.GameId, src => src.GameId)
             .Map(dest => dest.Title, src => src.Game != null ? src.Game.Title : null)
             .Map(dest => dest.Username, src => src.User.Username)
             .Map(dest => dest.BackgroundImage, src => src.Game != null ? src.Game.BackgroundImage : null)
             .Map(dest => dest.ReleaseDate, src => src.Game != null ? src.Game.ReleaseDate : default)
             .Map(dest => dest.Description, src => src.Game != null ? src.Game.Description : null)
             .Map(dest => dest.Metacritic, src => src.Game != null ? src.Game.Metacritic : null)
             .MaxDepth(1);

            TypeAdapterConfig<CustomUserListGame, GetCustomUserListGameResponse>
                .NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.CustomUserListId, src => src.CustomUserListId)
                .Map(dest => dest.GameId, src => src.GameId)
                .Map(dest => dest.Title, src => src.Game.Title)
                .Map(dest => dest.BackgroundImage, src => src.Game.BackgroundImage)
                .Map(dest => dest.ReleaseDate, src => src.Game.ReleaseDate)
                .Map(dest => dest.Description, src => src.Game.Description)
                .Map(dest => dest.Metacritic, src => src.Game.Metacritic);
        }
    }
}
