USE TimesheetManagement;

SET ANSI_NULLS ON  
GO  
  
SET QUOTED_IDENTIFIER ON  
GO  
  
SET ANSI_PADDING ON  
GO  
  
CREATE TABLE[dbo]. [tblRoleformaccess](  
  [roleformaccess_id][int] IDENTITY(1,1) NOT NULL,  
  [role_id][int],  
  [form_id][varchar](50),
  CONSTRAINT[PK_tblRoleformaccess] PRIMARY KEY CLUSTERED(  
    [roleformaccess_id] ASC 
  ) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]  
) ON[PRIMARY]  
  
GO  
  
SET ANSI_PADDING OFF  
GO