using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemsTask.Model.Models;
using Dapper;
using HemsTask.DataAccess.Infrastructure.IInfrastructure;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HemsTask.Controllers
{
	[Route("[controller]")]
	public class ProductsController : BaseController
	{
		public ProductsController(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		// GET: Products
		[Route("")]
		public async Task<IActionResult> Index()
		{
			return View(await _unitOfWork.Products.Get("GetProducts"));
		}

		// GET: Products/Details/5
		[Route("Details")]
		public async Task<IActionResult> Details(long? seqId)
		{
			//throw Exception("message");

			if (seqId == null)
			{
				return NotFound();
			}

			var product = await _unitOfWork.Products.GetById("GetProductById", new DynamicParameters(new { SeqId = seqId }));

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Products/Create
		[Route("Create")]
		public IActionResult Create()
		{
			ViewData["ProductTypes"] = new SelectList(_unitOfWork.ProductTypes.Get("GetProductTypes").Result, "SeqId", "ProductTypeCode");

			return View();
		}

		// POST: Products/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create([Bind("ProductCode, ProductTypeSeqId, ProductName, ProductDescription, Status")] Product product)
		{
			var prod = await _unitOfWork.Products.GetProductByCode("GetProductByCode", new DynamicParameters(new { Code = product.ProductCode }));

			if (prod != null)
			{
				throw new Exception("Product code already exists");
			}

			if (ModelState.IsValid)
			{
				await _unitOfWork.Products.Add("InsertProduct", new DynamicParameters(new { product.ProductCode, product.ProductTypeSeqId, product.ProductName, product.ProductDescription, product.Status }));

				_unitOfWork.Commit();
			}

			return View(product);
		}

		// GET: Products/Edit/5
		[Route("Edit")]
		public async Task<IActionResult> Edit(long? seqId)
		{
			if (seqId == null)
			{
				return NotFound();
			}

			var product = await _unitOfWork.Products.GetById("GetProductById", new DynamicParameters(new { SeqId = seqId }));

			if (product == null)
			{
				return NotFound();
			}

			ViewData["ProductTypes"] = new SelectList(_unitOfWork.ProductTypes.Get("GetProductTypes").Result, "SeqId", "ProductTypeCode");

			return View(product);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Route("Edit")]
		public async Task<IActionResult> Edit(long seqId, [Bind("SeqId, ProductCode, ProductTypeSeqId, ProductName, ProductDescription, Status")] Product product)
		{
			if (seqId != product.SeqId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _unitOfWork.Products.Add("UpdateProduct", new DynamicParameters(new { product.ProductCode, product.ProductTypeSeqId, product.SeqId, product.ProductName, product.ProductDescription, product.Status }));

					_unitOfWork.Commit();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductExists(product.SeqId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}

			return View(product);
		}

		// GET: Products/Delete/5
		[HttpPost]
		[Route("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(long? seqId)
		{
			if (seqId == null)
			{
				return NotFound();
			}

			var product = await _unitOfWork.Products.GetById("GetProductById", new DynamicParameters(new { SeqId = seqId }));

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long seqId)
		{
			var product = _unitOfWork.Products.Get("GetProductById", new DynamicParameters(new { SeqId = seqId })).Result.FirstOrDefault();

			if (product == null)
			{
				return NotFound();
			}

			await _unitOfWork.Products.Delete("DeleteProduct", new DynamicParameters(new { SeqId = product.SeqId }));

			_unitOfWork.Commit();

			return RedirectToAction(nameof(Index));
		}

		private bool ProductExists(long seqId)
		{
			var product = _unitOfWork.Products.GetById("GetProductById", new DynamicParameters(new { SeqId = seqId })).Result;

			return product != null;
		}
	}
}
