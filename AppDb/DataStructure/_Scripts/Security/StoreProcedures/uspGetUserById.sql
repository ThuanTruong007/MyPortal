CREATE PROCEDURE [Security].[uspGetUserById]
	@UserId int
AS
	set transaction isolation level read uncommitted;
	SET NOCOUNT ON;  
	SELECT 
		*
	from
		Security.[User]
	where
		UserId=@UserId;