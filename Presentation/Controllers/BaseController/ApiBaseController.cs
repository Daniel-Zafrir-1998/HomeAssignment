using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers.BaseController;

public abstract class ApiBaseController(ISender sender) : ControllerBase
{
    protected readonly ISender _sender = sender;
}
