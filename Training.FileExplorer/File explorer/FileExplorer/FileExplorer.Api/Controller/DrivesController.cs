using AutoMapper;
using FileExplorer.Api.Models.Dtos;
using FileExplorer.Application.FileStorage.Broker;
using FileExplorer.Application.FileStorage.Models;
using FileExplorer.Application.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorer.Api.Controller
{
    [ApiController]
    [Route("api/drives")]
    public class DrivesController : ControllerBase
    {
        private readonly IMapper _mapper;

        public DrivesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetDriveInfos([FromServices] IDriveService driveService)
        {
            var data = await driveService.GetAsync();
            var result = _mapper.Map<IEnumerable<StorageDriveDto>>(data);
            
            return result.Any() ? Ok(result) : NoContent();
        }
    }
}

