using AutoMapper;

namespace ad_dotnet_core_7_2023.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static Character knight = new Character();
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character(){Id=1, Name="Sam"},
            new Character(){Id=2, Name="Arka", Description="Owner"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        // synchronous 
        public Character GetCharacter()
        {
            return knight;
        }

        public List<Character> GetCharacterList()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            Character? character = characters.FirstOrDefault(c => c.Id == id);

            if (character is not null)
            {
                return character;
            }

            throw new Exception("Character not found");
        }

        public List<Character> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        // asynchronous 
        public async Task<List<Character>> GetCharacterListAsync()
        {
            return characters;
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            Character? character = characters.FirstOrDefault(c => c.Id == id);

            if (character is not null)
            {
                return character;
            }

            throw new Exception("Character not found");
        }

        public async Task<List<Character>> AddCharacterAsync(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        // Using ServiceResponse 
        public async Task<ServiceResponse<List<Character>>> GetCharacterListSR()
        {
            ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterByIdSR(int id)
        {
            ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
            Character? character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = character;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> AddCharacterSR(Character newCharacter)
        {
            ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        // Using Dto 
        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetCharacterListDto()
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterByIdDto(int id)
        {
            ServiceResponse<GetCharacterResponseDto> serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            Character? character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacterDto(AddCharacterRequestDto newCharacter)
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacterDto(UpdateCharacterRequestDto updatedCharacter)
        {
            ServiceResponse<GetCharacterResponseDto> serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            try
            {
                Character? character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if (character is null)
                {
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found");
                }

                _mapper.Map(updatedCharacter, character);

                // character.HitPoints = updatedCharacter.HitPoints;
                // character.Strength = updatedCharacter.Strength;
                // character.Defense = updatedCharacter.Defense;
                // character.Intelligence = updatedCharacter.Intelligence;

                serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacterDto(int id)
        {
            ServiceResponse<List<GetCharacterResponseDto>> serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == id);
                if (character is null)
                {
                    throw new Exception($"Character with Id '{id}' not found");
                }

                characters.Remove(character);

                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}