USE timestampmanagement
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetEmployeesById]
(
	@emp_id int
)
AS
BEGIN
	SELECT emp_id, emp_name, emp_dob, role_id, gender_id, emp_email, emp_phone, emp_address, emp_password FROM tblEmployee WHERE emp_id=@emp_id
END