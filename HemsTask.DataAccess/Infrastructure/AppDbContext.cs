using HemsTask.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HemsTask.DataAccess.Infrastructure
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			//System.Diagnostics.Debugger.Launch();
		}

		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<Product> Products { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			#region ProductCategories
			builder.Entity<ProductCategory>(entity =>
			{
				entity.HasKey(e => e.SeqId);

				entity.Property(entity => entity.SeqId)
				.ValueGeneratedOnAdd();

				entity.Property(entity => entity.CreateDate).HasDefaultValueSql("GETDATE()");
			});
			#endregion

			#region ProductTypes
			builder.Entity<ProductType>(entity =>
			{
				entity.HasKey(e => e.SeqId);

				entity.Property(entity => entity.SeqId)
				.ValueGeneratedOnAdd();

				entity.Property(entity => entity.CreateDate).HasDefaultValueSql("GETDATE()");
			});
			#endregion

			#region Products
			builder.Entity<Product>(entity =>
			{
				entity.HasKey(e => e.SeqId);

				entity.Property(entity => entity.SeqId)
				.ValueGeneratedOnAdd();

				entity.Property(entity => entity.CreateDate).HasDefaultValueSql("GETDATE()");
			});
			#endregion
		}
	}
}
