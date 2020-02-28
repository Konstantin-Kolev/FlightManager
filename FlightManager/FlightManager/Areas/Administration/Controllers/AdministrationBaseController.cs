using FlightManager.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightManager.Areas.Administration.Controllers
{
    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.Roles.Administrator)]
    public class AdministrationBaseController : Controller
    {
    }
}
