using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController: ControllerBase
    {
        
    }
}
