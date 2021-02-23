CREATE PROCEDURE [dbo].[spProduct_GetById]
	@Id int
AS
begin
	set nocount on;
	SELECT Id, ProductName, ProductDescription, RetailPrice, CreateDate, LastModified
	from [dbo].[Product]
	where Id = @Id;
end
