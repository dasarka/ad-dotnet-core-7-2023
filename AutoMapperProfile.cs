
using AutoMapper;

namespace ad_dotnet_core_7_2023
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterResponseDto>();
            CreateMap<AddCharacterRequestDto, Character>();
            CreateMap<UpdateCharacterRequestDto, Character>();
        }
    }
}