using Microsoft.AspNetCore.Mvc;
using HemsTask.DataAccess.Infrastructure.IInfrastructure;

namespace HemsTask.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork = null)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
