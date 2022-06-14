using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemsTask.Model.Models
{
	[Table("ProductTypes")]

	public class ProductType
	{
		[Key]
		public long SeqId { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string ProductTypeCode { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public long ProductCategorySeqId { get; set; }

		[NotMapped]
		public string ProductCategoryCode { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string TypeName { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string TypeDescription { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[EnumDataType(typeof(ProductTypeStatuses))]
		public ProductTypeStatuses Status { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }

		public virtual ProductCategory ProductCategory { get; set; }

		[InverseProperty("ProductType")]
		public virtual ICollection<Product> Products { get; set; }
	}

	public enum ProductTypeStatuses
	{
		Enabled = 1,
		Disabled = 2
	}
}
