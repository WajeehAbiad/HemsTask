using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemsTask.Model.Models
{
	[Table("ProductCategories")]

	public class ProductCategory
	{
		[Key]
		public long SeqId { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string ProductCategoryCode { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string CategoryName { get; set; }


		[Required(ErrorMessage = "This field is required")]
		public string CategoryDescription { get; set; }


		[Required(ErrorMessage = "This field is required")]
		[EnumDataType(typeof(ProductCategoryStatuses))]
		public ProductCategoryStatuses Status { get; set; }


		public DateTime CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }

		[InverseProperty("ProductCategory")]
		public virtual ICollection<ProductType> ProductTypes { get; set; }
	}

	public enum ProductCategoryStatuses
	{
		Active = 1,
		Inactive = 2
	}
}
