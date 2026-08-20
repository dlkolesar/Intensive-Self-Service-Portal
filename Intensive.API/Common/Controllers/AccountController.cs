using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Intensive.API.Global;
using Intensive.Services.Common;

using Intensive.Data.EBIDataMart;
using System.Threading.Tasks;
using System.Collections.Generic;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using Intensive.Services.CTKAPIWrapper;
using Intensive.Services.CTKAPIWrapper.CTKObjects;
using Intensive.Services.CTKAPIWrapper.Exceptions;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Common.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private ILogger<AccountController> log;
        private Account acct;
        private CTKAPI core;

        public AccountController(ILogger<AccountController> logger,
                                Account acctsvc,
                                CTKAPI ctkapi
                                )
        {
            log = logger;
            acct = acctsvc;
            core = ctkapi;
        }


        [HttpGet("{acctNumber}")]
        public IActionResult Get(int acctNumber)
        {
            //validation
            if (acctNumber <= 0) { return BadRequest(); }

            try
            {
                //acct.Load(acctNumber);
                //if (acct.Number == 0)
                //    return NotFound();
                //else
                //    return Ok(acct);
                CTKAccount ctkAcct = new CTKAccount(core, acctNumber);
                acct.Name = ctkAcct.Name;
                acct.Number = ctkAcct.Number;
                return Ok(acct);
            }
            catch (CTKNotFoundException)
            {
                return NotFound($"CORE account {acctNumber} not found");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 201, $"Unable to load CORE account {acctNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }
    }
}
