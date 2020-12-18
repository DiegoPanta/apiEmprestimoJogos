using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEmprestimoJogos.Controllers
{
    [ApiController]
    [Authorize ()]
    public class EmprestimoJogosBaseController : ControllerBase
    {
        protected StatusCodeResult Created()
        {
            return StatusCode(201);
        }
    }
}