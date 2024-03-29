USE [timestampmanagement]
GO
/****** Object:  StoredProcedure [dbo].[AddNewEmployeeDetails]    Script Date: 17-05-2021 20:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[AddNewEmployeeDetails]
(
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
	INSERT INTO tblEmployee VALUES(@emp_name , @emp_dob, @role_id, @gender_id, @emp_email, @emp_phone, @emp_address, @emp_password)
END