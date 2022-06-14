using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemsTask.Model.Models;
using Dapper;
using HemsTask.DataAccess.Infrastructure.IInfrastructure;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HemsTask.Controllers
{
	[Route("[controller]")]
	public class ProductTypesController : BaseController
	{
		public ProductTypesController(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		// GET: ProductTypes
		[Route("")]
		public async Task<IActionResult> Index()
		{
			return View(await _unitOfWork.ProductTypes.Get("GetProductTypes"));
		}

		// GET: ProductTypes/Details/5
		[Route("Details")]
		public async Task<IActionResult> Details(long? seqId)
		{
			//throw Exception("message");

			if (seqId == null)
			{
				return NotFound();
			}

			var productType = await _unitOfWork.ProductTypes.GetById("GetProductTypeById", new DynamicParameters(new { SeqId = seqId }));

			if (productType == null)
			{
				return NotFound();
			}

			return View(productType);
		}

		// GET: ProductTypes/Create
		[Route("Create")]
		public IActionResult Create()
		{
			ViewData["ProductCategories"] = new SelectList(_unitOfWork.ProductCategories.Get("GetProductCategories").Result, "SeqId", "ProductCategoryCode");

			return View();
		}

		// POST: ProductTypes/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create([Bind("ProductTypeCode, ProductCategorySeqId, TypeName, TypeDescription, Status")] ProductType productType)
		{
			var productTyp = await _unitOfWork.ProductTypes.GetProductTypeByCode("GetProductTypeByCode", new DynamicParameters(new { Code = productType.ProductTypeCode }));

			if (productTyp != null)
			{
				throw new Exception("Product type code already exists");
			}

			if (ModelState.IsValid)
			{
				await _unitOfWork.ProductTypes.Add("InsertProductType", new DynamicParameters(new { productType.ProductTypeCode, productType.ProductCategorySeqId, productType.TypeName, productType.TypeDescription, productType.Status }));

				_unitOfWork.Commit();
			}

			return View(productType);
		}

		// GET: ProductTypes/Edit/5
		[Route("Edit")]
		public async Task<IActionResult> Edit(long? seqId)
		{
			if (seqId == null)
			{
				return NotFound();
			}

			var productType = await _unitOfWork.ProductTypes.GetById("GetProductTypeById", new DynamicParameters(new { SeqId = seqId }));

			if (productType == null)
			{
				return NotFound();
			}

			ViewData["ProductCategories"] = new SelectList(_unitOfWork.ProductCategories.Get("GetProductCategories").Result, "SeqId", "ProductCategoryCode");

			return View(productType);
		}

		// POST: ProductTypes/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("Edit")]
		public async Task<IActionResult> Edit(long seqId, [Bind("SeqId, ProductTypeCode, ProductCategorySeqId, TypeName, TypeDescription, Status")] ProductType productType)
		{
			if (seqId != productType.SeqId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _unitOfWork.ProductTypes.Add("UpdateProductType", new DynamicParameters(new { productType.ProductTypeCode, productType.ProductCategorySeqId, productType.SeqId, productType.TypeName, productType.TypeDescription, productType.Status }));

					_unitOfWork.Commit();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductTypeExists(productType.SeqId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}

			return View(productType);
		}

		// GET: ProductTypes/Delete/5
		[Route("Delete")]
		public async Task<IActionResult> Delete(long? seqId)
		{
			if (seqId == null)
			{
				return NotFound();
			}

			var productType = await _unitOfWork.ProductTypes.GetById("GetProductTypeById", new DynamicParameters(new { SeqId = seqId }));

			if (productType == null)
			{
				return NotFound();
			}

			return View(productType);
		}

		// POST: ProductTypes/Delete/5
		[HttpPost]
		[Route("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long seqId)
		{
			var productType = _unitOfWork.ProductTypes.Get("GetProductTypeById", new DynamicParameters(new { SeqId = seqId })).Result.FirstOrDefault();

			if (productType == null)
			{
				return NotFound();
			}

			await _unitOfWork.ProductTypes.Delete("DeleteProductType", new DynamicParameters(new { SeqId = productType.SeqId }));

			_unitOfWork.Commit();

			return RedirectToAction(nameof(Index));
		}

		private bool ProductTypeExists(long seqId)
		{
			var productType = _unitOfWork.ProductTypes.GetById("GetProductTypeById", new DynamicParameters(new { SeqId = seqId })).Result;

			return productType != null;
		}
	}
}
