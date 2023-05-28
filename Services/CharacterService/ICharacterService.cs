namespace ad_dotnet_core_7_2023.Services.CharacterService
{
    public interface ICharacterService
    {
        // synchronous 
        Character GetCharacter();
        List<Character> GetCharacterList();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character newCharacter);

        // asynchronous 
        Task<List<Character>> GetCharacterListAsync();
        Task<Character> GetCharacterByIdAsync(int id);
        Task<List<Character>> AddCharacterAsync(Character newCharacter);

        // Using ServiceResponse 
        Task<ServiceResponse<List<Character>>> GetCharacterListSR();
        Task<ServiceResponse<Character>> GetCharacterByIdSR(int id);
        Task<ServiceResponse<List<Character>>> AddCharacterSR(Character newCharacter);

        // Using Dto 
        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetCharacterListDto();
        Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterByIdDto(int id);
        Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacterDto(AddCharacterRequestDto newCharacter);
        Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacterDto(UpdateCharacterRequestDto updatedCharacter);
        Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacterDto(int id);
    }
}