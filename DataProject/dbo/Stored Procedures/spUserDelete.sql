CREATE PROCEDURE [dbo].[spUserDelete]
	@Id int
AS
begin
	delete
	from dbo.[User]
	where Id = @Id;
end
