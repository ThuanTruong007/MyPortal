CREATE PROCEDURE [Security].[uspDeleteUser]
(
	@UserId int  
)
AS  
BEGIN  
	SET NOCOUNT ON;  
	declare @id table (Id int)
	update Security.[User] set IsDeleted = 1, IsActive=0 
	output inserted.UserId into @id(Id)
	where UserId = @UserId  
	
	select top 1 id from @id
END  
