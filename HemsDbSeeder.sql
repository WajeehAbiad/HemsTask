use HemsTask

insert into ProductCategories (ProductCategoryCode, CategoryName, CategoryDescription, Status)
values
('PC-01', 'Category-01', 'PC-Des-01', 1),
('PC-02', 'Category-02', 'PC-Des-02', 1),
('PC-03', 'Category-03', 'PC-Des-03', 1),
('PC-04', 'Category-04', 'PC-Des-04', 1),
('PC-05', 'Category-05', 'PC-Des-05', 1),
('PC-06', 'Category-06', 'PC-Des-06', 1),
('PC-07', 'Category-07', 'PC-Des-07', 1),
('PC-08', 'Category-08', 'PC-Des-08', 1),
('PC-09', 'Category-09', 'PC-Des-09', 1),
('PC-10', 'Category-10', 'PC-Des-10', 1),
('PC-11', 'Category-11', 'PC-Des-11', 2),
('PC-12', 'Category-12', 'PC-Des-12', 2),
('PC-13', 'Category-13', 'PC-Des-13', 2),
('PC-14', 'Category-14', 'PC-Des-14', 2),
('PC-15', 'Category-15', 'PC-Des-15', 2),
('PC-16', 'Category-16', 'PC-Des-16', 2),
('PC-17', 'Category-17', 'PC-Des-17', 2),
('PC-18', 'Category-18', 'PC-Des-18', 2),
('PC-19', 'Category-19', 'PC-Des-19', 2),
('PC-20', 'Category-20', 'PC-Des-20', 2)

insert into ProductTypes(ProductTypeCode, ProductCategorySeqId, TypeName, TypeDescription, Status)
values
('PT-01', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-01', 'PT-Des-01', 1),
('PT-02', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-02', 'PT-Des-02', 1),
('PT-03', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-03', 'PT-Des-03', 1),
('PT-04', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-04', 'PT-Des-04', 1),
('PT-05', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-05', 'PT-Des-05', 1),
('PT-06', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-06', 'PT-Des-06', 1),
('PT-07', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-07', 'PT-Des-07', 1),
('PT-08', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-08', 'PT-Des-08', 1),
('PT-09', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-09', 'PT-Des-09', 1),
('PT-10', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-10', 'PT-Des-10', 1),
('PT-11', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-11', 'PT-Des-11', 2),
('PT-12', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-12', 'PT-Des-12', 2),
('PT-13', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-13', 'PT-Des-13', 2),
('PT-14', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-14', 'PT-Des-14', 2),
('PT-15', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-15', 'PT-Des-15', 2),
('PT-16', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-16', 'PT-Des-16', 2),
('PT-17', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-17', 'PT-Des-17', 2),
('PT-18', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-18', 'PT-Des-18', 2),
('PT-19', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-19', 'PT-Des-19', 2),
('PT-20', (SELECT TOP 1 SeqId FROM ProductCategories ORDER BY NEWID()), 'Type-20', 'PT-Des-20', 2)

insert into Products(ProductCode, ProductTypeSeqId, ProductName, ProductDescription, Status)
values
('P-01', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-01', 'P-Des-01', 1),
('P-02', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-02', 'P-Des-02', 1),
('P-03', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-03', 'P-Des-03', 1),
('P-04', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-04', 'P-Des-04', 1),
('P-05', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-05', 'P-Des-05', 1),
('P-06', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-06', 'P-Des-06', 1),
('P-07', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-07', 'P-Des-07', 1),
('P-08', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-08', 'P-Des-08', 1),
('P-09', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-09', 'P-Des-09', 1),
('P-10', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-10', 'P-Des-10', 1),
('P-11', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-11', 'P-Des-11', 2),
('P-12', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-12', 'P-Des-12', 2),
('P-13', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-13', 'P-Des-13', 2),
('P-14', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-14', 'P-Des-14', 2),
('P-15', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-15', 'P-Des-15', 2),
('P-16', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-16', 'P-Des-16', 2),
('P-17', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-17', 'P-Des-17', 2),
('P-18', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-18', 'P-Des-18', 2),
('P-19', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-19', 'P-Des-19', 2),
('P-20', (SELECT TOP 1 SeqId FROM ProductTypes ORDER BY NEWID()), 'Product-20', 'P-Des-20', 2)
