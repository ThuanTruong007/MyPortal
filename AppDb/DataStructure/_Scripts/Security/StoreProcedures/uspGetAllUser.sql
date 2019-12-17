CREATE PROCEDURE [Security].[uspGetAllUser]
	@onlyActive int = 0
AS
	set transaction isolation level read uncommitted;
	SET NOCOUNT ON;  
	if @onlyActive=0
	begin
		select 
			* 
		from 
			Security.[User] 
	end 
	else
	begin
		select 
			* 
		from 
			Security.[User] 
		where
			isActive = 1
	end

