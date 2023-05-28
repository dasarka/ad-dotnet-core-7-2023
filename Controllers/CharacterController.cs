using ad_dotnet_core_7_2023.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace ad_dotnet_core_7_2023.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        // synchronous 
        [HttpGet]
        public ActionResult<Character> Get()
        {
            return Ok(_characterService.GetCharacter());
        }

        [HttpGet("list")]
        public ActionResult<List<Character>> GetCharacterList()
        {
            return Ok(_characterService.GetCharacterList());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacter(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }

        // asynchronous 
        [HttpGet("async/list")]
        public async Task<ActionResult<List<Character>>> GetCharacterListAsync()
        {
            return Ok(await _characterService.GetCharacterListAsync());
        }

        [HttpGet("async/{id}")]
        public async Task<ActionResult<Character>> GetCharacterAsync(int id)
        {
            return Ok(await _characterService.GetCharacterByIdAsync(id));
        }

        [HttpPost("async/create")]
        public async Task<ActionResult<List<Character>>> AddCharacterAsync(Character newCharacter)
        {
            return Ok(await _characterService.AddCharacterAsync(newCharacter));
        }

        // Using ServiceResponse 
        [HttpGet("service-response/list")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> GetCharacterListSR()
        {
            return Ok(await _characterService.GetCharacterListSR());
        }

        [HttpGet("service-response/{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetCharacterSR(int id)
        {
            return Ok(await _characterService.GetCharacterByIdSR(id));
        }

        [HttpPost("service-response/create")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacterSR(Character newCharacter)
        {
            return Ok(await _characterService.AddCharacterSR(newCharacter));
        }

        // Using Dto 
        [HttpGet("dto/list")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> GetCharacterListDto()
        {
            return Ok(await _characterService.GetCharacterListDto());
        }

        [HttpGet("dto/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetCharacterDto(int id)
        {
            return Ok(await _characterService.GetCharacterByIdDto(id));
        }

        [HttpPost("dto/create")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> AddCharacterDto(AddCharacterRequestDto newCharacter)
        {
            return Ok(await _characterService.AddCharacterDto(newCharacter));
        }

        [HttpPut("dto/update")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> UpdateCharacterDto(UpdateCharacterRequestDto updatedCharacter)
        {
            ServiceResponse<GetCharacterResponseDto> response = await _characterService.UpdateCharacterDto(updatedCharacter);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("dto/delete")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> DeleteCharacterDto(int id)
        {
            ServiceResponse<List<GetCharacterResponseDto>> response = await _characterService.DeleteCharacterDto(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}