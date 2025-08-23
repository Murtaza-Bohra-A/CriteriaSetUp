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
        [HttpGet("GetCriteriaStatus")]
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
    }
}



