using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HemsTask.Model.Models
{
	[Table("Products")]

	public class Product
	{
		[Key]
		public long SeqId { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string ProductCode { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public long ProductTypeSeqId { get; set; }

		[NotMapped]
		public string ProductTypeCode { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string ProductName { get; set; }

		[Required(ErrorMessage = "This field is required")]
		public string ProductDescription { get; set; }

		[Required(ErrorMessage = "This field is required")]
		[EnumDataType(typeof(ProductStatuses))]
		public ProductStatuses Status { get; set; }

		public DateTime CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }

		public virtual ProductType ProductType { get; set; }
	}

	public enum ProductStatuses
	{
		Available = 1,
		Unavailable = 2
	}
}
