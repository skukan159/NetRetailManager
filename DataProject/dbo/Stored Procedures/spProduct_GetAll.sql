CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
begin
	set nocount on;

	SELECT Id, ProductName, ProductDescription, RetailPrice, CreateDate, LastModified
	from [dbo].[Product]
	order by ProductName;
end
