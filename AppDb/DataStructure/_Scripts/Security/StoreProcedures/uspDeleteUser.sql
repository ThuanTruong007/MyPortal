CREATE PROCEDURE [Security].[uspDeleteUser]
(
	@UserId int  
)
AS  
BEGIN  
	SET NOCOUNT ON;  
	update Security.[User] set IsDeleted = 1, IsActive=0 where UserId = @UserId  
END  
