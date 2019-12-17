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
    insert into Security.[User] (UserName,UserMobile, UserEmail, FaceBookUrl, LinkedInUrl, TwitterUrl, PersonalWebUrl)  
    values(@UserName, @UserMobile, @UserEmail, @FaceBookUrl, @LinkedInUrl, @TwitterUrl, @PersonalWebUrl)  
END  
GO  