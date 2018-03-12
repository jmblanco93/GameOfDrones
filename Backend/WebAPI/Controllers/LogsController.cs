using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class LogsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Log> _repoLog;

        public LogsController(IMapper mapper, IRepository<Log> repoLog)
        {
            _mapper = mapper;
            _repoLog = repoLog;
        }

        [HttpGet()]
        public async Task<IActionResult> GetLogs()
        {
            var logs = await _repoLog.GetEntitiesAsync();
            var logResources = _mapper.Map<List<Log>, List<LogResource>>(logs);
            return Ok(logResources);
        }
    }
}