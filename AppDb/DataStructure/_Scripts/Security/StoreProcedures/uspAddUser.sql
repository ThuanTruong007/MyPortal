create procedure [Security].[uspAddUser]  (
    @UserName varchar(50),  
    @UserMobile varchar(50),  
    @UserEmail varchar(50),  
    @FaceBookUrl varchar(50),  
    @LinkedInUrl varchar(50),  
    @TwitterUrl varchar(50),  
    @PersonalWebUrl varchar(50)  
    )
AS  
BEGIN  
    SET NOCOUNT ON;  
    declare @id table (Id int)
    insert into Security.[User] (UserName,UserMobile, UserEmail, FaceBookUrl, LinkedInUrl, TwitterUrl, PersonalWebUrl)  
    output inserted.UserId into @id(Id)
    values(@UserName, @UserMobile, @UserEmail, @FaceBookUrl, @LinkedInUrl, @TwitterUrl, @PersonalWebUrl) 
    select * from @id;
END  
GO  