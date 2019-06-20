using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using Contracts;
using Entities;

namespace AccountOwnerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;

        public ValuesController(ILoggerManager logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
        }

        

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInfo("Here is info message from our values controller");
            _logger.LogDebug("Here is debug message from our values controller");
            _logger.LogWarn("Here is warn message from our values controller");
            _logger.LogError("Here is error message from out values controller");
            var domesticAccounts = _repoWrapper.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var list = domesticAccounts.ToList();
            for(int i = 0; i<list.Count; i++)
            {
                _logger.LogInfo("i=" + i + " account=" + ObjectDumper.Dump(list[i]));
            }
            _logger.LogInfo("Domestic=" + domesticAccounts.ToString());
            var owners = _repoWrapper.Owner.FindAll();
            var list2 = owners.ToList();
            for (int i = 0; i < list2.Count; i++)
            {
                _logger.LogInfo("i=" + i + " owner=" + ObjectDumper.Dump(list2[i]));
            }
            _logger.LogInfo("owners=" + owners.ToString());
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
