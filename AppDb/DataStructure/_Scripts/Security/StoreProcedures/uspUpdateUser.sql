CREATE PROCEDURE [Security].[uspUpdateUser]  
(
    @UserId int,  
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
    update Security.[User] set  
    UserName = @UserName,  
        UserMobile = @UserMobile,  
        UserEmail = @UserEmail,  
        FaceBookUrl = @FaceBookUrl,  
        LinkedInUrl = @LinkedInUrl,  
        TwitterUrl = @TwitterUrl,  
        PersonalWebUrl = @PersonalWebUrl  
    where UserId = @UserId  
END  
GO  