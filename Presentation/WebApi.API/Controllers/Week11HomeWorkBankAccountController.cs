using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApi.API.Models;
using WebApi.Persistence.Contexts;

namespace WebApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Week11HomeWorkBankAccountController : ControllerBase
    {
        private readonly Week11DbContext _context;

        public Week11HomeWorkBankAccountController(Week11DbContext context)
        {
            _context = context;
        }

        public GetBankAccountDataResponseModel GetBankAccountData(Guid id) 
        {
            var bankAccount = _context.People.FirstOrDefault(x=>x.Id == id);

            var response = new GetBankAccountDataResponseModel()
            {
                FirstName = bankAccount.FirstName,
                LastName = bankAccount.LastName,
                Balance = bankAccount.Balance,
            };

            return response;
        }
    }
}
