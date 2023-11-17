using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;
        private const string StudentsCacheKey = "studentsList";

        public StudentController(FakeDataService fakeDataService, ApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
        {
            _fakeDataService = fakeDataService;
            _applicationDbContext = applicationDbContext;

            _memoryCache = memoryCache;
            _cacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(30),
                Priority = CacheItemPriority.High,
            };  
        }

        [HttpPost("GenerateFakeData")]
        public async Task<IActionResult> GenerateFakeDataAsync(CancellationToken cancellationToken)
        {
            await _fakeDataService.GenerateStudentFakeDataAsync(cancellationToken);

            var students = await _applicationDbContext
                .Students.AsNoTracking()
                .ToListAsync(cancellationToken);

            _memoryCache.Set(StudentsCacheKey, students, _cacheEntryOptions);

            return Ok(students.Count);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFakeData(CancellationToken cancellationToken)
        {
            if(_memoryCache.TryGetValue(StudentsCacheKey, out var students)) {  return Ok(students); }

            students = await _applicationDbContext.Students.AsNoTracking().ToListAsync(cancellationToken);

            _memoryCache.Set(StudentsCacheKey, students, _cacheEntryOptions);

            return Ok(students);
        }
    }
}
