using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Security.Claims;

namespace Notes.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController: ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                IMediator? mediator = _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
                return mediator;
            }
        }

        internal Guid UserId => !User.Identity.IsAuthenticated 
            ? Guid.Empty 
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
