USE timestampmanagement;

SET ANSI_NULLS ON  
GO  
  
SET QUOTED_IDENTIFIER ON  
GO  
  
SET ANSI_PADDING ON  
GO  
  
CREATE TABLE[dbo]. [tblEmployee](  
  [emp_id][int] IDENTITY(1,1) NOT NULL,  
  [emp_name][varchar](50),
  [emp_dob][date],
  [role_id][int],  
  [gender_id][int],
  [emp_email][varchar](50),
  [emp_phone][varchar](20),
  [emp_address][varchar](100),
  [emp_password][varchar](20),
  CONSTRAINT[PK_tblEmployee] PRIMARY KEY CLUSTERED(  
    [emp_id] ASC 
  ) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]  
) ON[PRIMARY]  
  
GO  
  
SET ANSI_PADDING OFF  
GO