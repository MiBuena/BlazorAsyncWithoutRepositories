using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListGenerator.Server.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListGenerator.Server.Controllers
{
    public abstract class IdentityController : ControllerBase
    {
        protected string UserId => this.User.GetId();
    }
}
