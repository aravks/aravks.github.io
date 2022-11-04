USE timestampmanagement
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployees]
AS
BEGIN
	SELECT emp_id, emp_name, emp_dob, role_id, gender_id, emp_email, emp_phone, emp_address, emp_password FROM tblEmployee
END