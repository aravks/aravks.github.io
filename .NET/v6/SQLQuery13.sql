USE [TimesheetManagement]
GO
/****** Object:  StoredProcedure [dbo].[AddNewEmployeeDetails]    Script Date: 17-05-2021 20:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddRoleformaccess]
(
	@roleformaccess_id varchar (50),
	@role_id int,
	@form_id varchar(50)
)
AS
BEGIN
	INSERT INTO tblRoleformaccess VALUES(@roleformaccess_id, @role_id, @form_id)
END