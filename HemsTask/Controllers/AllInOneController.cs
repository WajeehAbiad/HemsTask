using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HemsTask.Model.Models;
using Dapper;
using HemsTask.DataAccess.Infrastructure.IInfrastructure;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HemsTask.Controllers
{
	[Route("[controller]")]
	public class AllInOneController : BaseController
	{
		public AllInOneController(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		// GET: ProductCategories/Create
		public IActionResult CreateAll()
		{
			var productCategoriesList = _unitOfWork.ProductCategories.Get("GetProductCategories").Result;

			ViewData["ProductCategoriesList"] = productCategoriesList;

			ViewData["ProductCategories"] = new SelectList(productCategoriesList, "SeqId", "ProductCategoryCode");

			ViewData["ProductTypes"] = new SelectList(_unitOfWork.ProductTypes.Get("GetProductTypes").Result, "SeqId", "ProductTypeCode");

			return View();
		}
	}
}
