using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemsTask.Model.Models;
using Dapper;
using HemsTask.DataAccess.Infrastructure.IInfrastructure;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HemsTask.Controllers
{
	[Route("[controller]")]
	public class ProductCategoriesController : BaseController
	{
		public ProductCategoriesController(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		// GET: ProductCategories
		[Route("")]
		public async Task<IActionResult> Index()
		{
			return View(await _unitOfWork.ProductCategories.Get("GetProductCategories"));
		}

		// GET: ProductCategories/Details/5
		[Route("Details")]
		public async Task<IActionResult> Details(long? seqId)
		{
			//throw Exception("message");

			if (seqId == null)
			{
				return NotFound();
			}

			var productCategory = await _unitOfWork.ProductCategories.GetById("GetProductCategoryById", new DynamicParameters(new { SeqId = seqId }));

			if (productCategory == null)
			{
				return NotFound();
			}

			return View(productCategory);
		}

		// GET: ProductCategories/Create
		[Route("Create")]
		public IActionResult Create()
		{
			return View();
		}

		// POST: ProductCategories/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create([Bind("ProductCategoryCode, CategoryName, CategoryDescription, Status")] ProductCategory productCategory)
		{
			var productCat = await _unitOfWork.ProductCategories.GetProductCategoryByCode("GetProductCategoryByCode", new DynamicParameters(new { Code = productCategory.ProductCategoryCode }));

			if (productCat != null)
			{
				throw new Exception("Product category code already exists");
			}

			if (ModelState.IsValid)
			{
				await _unitOfWork.ProductCategories.Add("InsertProductCategory", new DynamicParameters(new { productCategory.ProductCategoryCode, productCategory.CategoryName, productCategory.CategoryDescription, productCategory.Status }));

				_unitOfWork.Commit();
			}

			return View(productCategory);
		}

		// GET: ProductCategories/Edit/5
		[Route("Edit")]
		public async Task<IActionResult> Edit(long? seqId)
		{
			if (seqId == null)
			{
				return NotFound();
			}

			var productCategory = await _unitOfWork.ProductCategories.GetById("GetProductCategoryById", new DynamicParameters(new { SeqId = seqId }));

			if (productCategory == null)
			{
				return NotFound();
			}

			return View(productCategory);
		}

		// POST: ProductCategories/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("Edit")]
		public async Task<IActionResult> Edit(long seqId, [Bind("SeqId, ProductCategoryCode, CategoryName, CategoryDescription, Status")] ProductCategory productCategory)
		{
			if (seqId != productCategory.SeqId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _unitOfWork.ProductCategories.Add("UpdateProductCategory", new DynamicParameters(new { productCategory.ProductCategoryCode, productCategory.SeqId, productCategory.CategoryName, productCategory.CategoryDescription, productCategory.Status }));

					_unitOfWork.Commit();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductCategoryExists(productCategory.SeqId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}

			return View(productCategory);
		}

		// GET: ProductCategories/Delete/5
		[Route("Delete")]
		public async Task<IActionResult> Delete(long? seqId)
		{
			if (seqId == null)
			{
				return NotFound();
			}

			var productCategory = await _unitOfWork.ProductCategories.GetById("GetProductCategoryById", new DynamicParameters(new { SeqId = seqId }));

			if (productCategory == null)
			{
				return NotFound();
			}

			return View(productCategory);
		}

		// POST: ProductCategories/Delete/5
		[HttpPost]
		[Route("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long seqId)
		{
			var productCategory = _unitOfWork.ProductCategories.Get("GetProductCategoryById", new DynamicParameters(new { SeqId = seqId })).Result.FirstOrDefault();

			if (productCategory == null)
			{
				return NotFound();
			}

			await _unitOfWork.ProductCategories.Delete("DeleteProductCategory", new DynamicParameters(new { SeqId = productCategory.SeqId }));

			_unitOfWork.Commit();

			return RedirectToAction(nameof(Index));
		}

		private bool ProductCategoryExists(long seqId)
		{
			var productCategory = _unitOfWork.ProductCategories.GetById("GetProductCategoryById", new DynamicParameters(new { SeqId = seqId })).Result;

			return productCategory != null;
		}
	}
}
