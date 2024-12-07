using Microsoft.AspNetCore.Mvc;

namespace FreETarget.NET.Web.Controllers
{
    public class FreETargetControllerBase : ControllerBase
    {
        protected ActionResult SaveResultActionResult(Data.Enums.SaveResult saveResult)
        {
            switch (saveResult)
            {
                case Data.Enums.SaveResult.Ok:
                    return NoContent();
                case Data.Enums.SaveResult.NotFound:
                    return NotFound();
                case Data.Enums.SaveResult.BadRequest:
                    return BadRequest();
                default:
                    return BadRequest();
            }
        }
    }
}
