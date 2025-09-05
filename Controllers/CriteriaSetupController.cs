using Microsoft.AspNetCore.Mvc;
using CriteriaSetUp_BE.BusinessLogic;
using CriteriaSetUp_BE.Models;

namespace CriteriaSetUp_BE.Controllers
{
    public class CriteriaSetupController : ControllerBase
    {
        private readonly appDbContext _context;
        private readonly AdministrationBAL _administrationBAL;

        public CriteriaSetupController(appDbContext context, AdministrationBAL administrationBAL)
        {
            _context = context;
            _administrationBAL = administrationBAL;
        }

        // Getting Avail Modules
        [HttpPost("MurtazaAPI/GetCriteriaStatus")]
        public IActionResult GetCriteriaStatus(CriteriaStatus req)
        {
            try
            {
                return  Ok(_administrationBAL.GetCriteriaStatus(req));
            }
            catch (Exception ex) 
            {
                // Log the exception or handle it as needed
                return BadRequest(new Result<object> { Status = false, Message = ex.Message });
            }
        }

        [HttpPost("MurtazaAPI/GetCriteriaStatuses")]
        public IActionResult GetCriteriaStatuses([FromBody] CriteriaStatuses req)
        {
            try
            {
                return Ok(_administrationBAL.GetCriteriaStatuses(req));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return BadRequest(new Result<object> { Status = false, Message = ex.Message });
            }
        }

        [HttpPost("MurtazaAPI/GetCriteriaModule")]
        public IActionResult GetAvailModule(CriteriaModule req)
        {
            try
            {
                return Ok(_administrationBAL.GetAvailModule(req));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return BadRequest(new Result<object> { Status = false, Message = ex.Message });
            }
        }
    }
}



