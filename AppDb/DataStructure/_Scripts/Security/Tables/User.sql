create table [Security].[User](  
    [UserId][int] IDENTITY(1, 1) NOT NULL constraint PK_UserId primary key clustered
    ,[UserName][varchar](50) NULL
    , [UserMobile][varchar](50) NULL
    , [UserEmail][varchar](50) NULL
    , [FaceBookUrl][varchar](50) NULL
    , [LinkedInUrl][varchar](50) NULL
    , [TwitterUrl][varchar](50) NULL
    , [PersonalWebUrl][varchar](50) NULL
    , [IsDeleted][bit] NULL constraint [DF_User_IsDeleted] DEFAULT(0)
    , [IsActive][bit] NULL constraint [DF_User_IsActive] DEFAULT(1)
    ); 