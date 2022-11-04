USE timestampmanagement
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteEmployeeById]
(
	@emp_id int
)
AS
BEGIN
	DELETE FROM tblEmployee WHERE emp_id=@emp_id
END