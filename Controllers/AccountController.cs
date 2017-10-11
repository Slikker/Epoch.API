using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.EPOCH.BACKEND
{
    [Route("api/[controller]")]
    public class AccountController : BaseController<AccountController>
    {
        private readonly IRepositoryAccount<Account> _repo;

        /// <summary>
        /// Get a list of account
        /// </summary>
        /// <returns>List of account</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogDebug("Retrieving list of Accounts ...");

            try
            {
                var obj = await _repo.GetListAsync(x => x.RecStatus == RecStatus.Active);

                if (obj == null)
                {
                    _logger.LogDebug("No Accounts found");
                    return CustomObjectResult.NotFoundObjectResult(ResponseType.NotFound);
                }

                _logger.LogDebug("Successfully returned list of Accounts...");
                return CustomObjectResult.OkRequestObjectResult(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return CustomObjectResult.ErrorObjectResult(ResponseType.Error);
            }
        }

        /// <summary>
        /// Get a spesific account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>Spesific account</returns>
        [HttpGet("{accountName},{password}")]
        public async Task<IActionResult> Get(string accountName, string password)
        {
            //if(accountName == "Slikker" && password == "Password")
            //{
            //    return Ok("Success");
            //}
            //return NotFound("Failed");


            var obj = await _repo.GetAsync(x => x.AccountName == accountName && x.Password == password);

            try
            {
                if (obj == null)
                {
                    _logger.LogDebug("There is no account with that details ");
                    return CustomObjectResult.NotFoundObjectResult(ResponseType.NotFound);
                }
                _logger.LogDebug("Successfully returned Account...");
                return CustomObjectResult.OkRequestObjectResult(obj);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return CustomObjectResult.ErrorObjectResult(ResponseType.Error);
            }
        }

        /// <summary>
        /// Create a new account
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(Account obj)
        {
            _logger.LogDebug("Creating a new Account...");

            try
            {
                //0 = active
                obj.RecStatus = 0;
                var newobj = await _repo.DataAddAsync(obj);
                _logger.LogDebug("Successfully Created a new Account");
                return CustomObjectResult.CreatedObjectResult(obj);//Todo Return Created Object
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return CustomObjectResult.ErrorObjectResult(ResponseType.Error);

            }
        }


        public AccountController(IRepositoryAccount<Account> repo, ILogger<AccountController> logger) : base(logger)
        {
            _repo = repo;
        }
    }
}