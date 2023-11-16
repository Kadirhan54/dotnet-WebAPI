using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.API.Services;
using WebApi.Domain.Entites;
using WebApi.Persistence.Contexts;

namespace WebApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly FakeDataService _fakeDataService;
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentController(FakeDataService fakeDataService, ApplicationDbContext applicationDbContext)
        {
            _fakeDataService = fakeDataService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("GenerateFakeData")]
        public async Task<IActionResult> GenerateFakeDataAsync(CancellationToken cancellationToken)
        {
            return Ok(await _fakeDataService.GenerateStudentFakeDataAsync(cancellationToken));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFakeData(CancellationToken cancellationToken)
        {
            return Ok(await _applicationDbContext.Students.AsNoTracking().ToListAsync(cancellationToken));
        }
    }
}
