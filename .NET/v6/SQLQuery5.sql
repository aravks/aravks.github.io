USE [timestampmanagement]
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployeeDetails]    Script Date: 17-05-2021 20:37:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[UpdateEmployeeDetails]
(
	@emp_id int,
	@emp_name varchar (50),
	@emp_dob date,
	@role_id int,
	@gender_id int,
	@emp_email varchar(50),
	@emp_phone varchar(20),
	@emp_address varchar(100),
	@emp_password varchar (20)
)
AS
BEGIN
	UPDATE tblEmployee
	SET emp_name=@emp_name,
	emp_dob=@emp_dob,
	role_id=@role_id,
	gender_id=@gender_id,
	emp_email=@emp_email,
	emp_phone=@emp_phone,
	emp_address=@emp_address,
	emp_password=@emp_password
	WHERE emp_id=@emp_id
END