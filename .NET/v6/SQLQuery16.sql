USE [TimesheetManagement]
GO
/****** Object:  StoredProcedure [dbo].[AddRoleformaccess]    Script Date: 20-05-2021 11:47:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SelectAllRoleFormAccess]
AS
BEGIN
	SELECT tblRoleformaccess.roleformaccess_id, tblRoleformaccess.role_id, tblRoleformaccess.form_id, tblRole.Role_name
                    FROM (tblRoleformaccess
                    INNER JOIN tblRole ON tblRoleformaccess.role_id = tblRole.Role_id)

	SELECT rf.roleformaccess_id, 
		   rf.role_id, 
		   rf.form_id,
		   tblRole.Role_name,
		   form_name = STUFF((SELECT ',' + fd.Form_name
				FROM FormDetail AS fd
				INNER JOIN tblRoleformaccess AS rfa
				ON ',' + rfa.form_id + ',' LIKE '%,' + CONVERT(VARCHAR(12), fd.Form_id) + ',%'
				WHERE rfa.form_id = rf.form_id
				ORDER BY CHARINDEX( ',' + CONVERT(VARCHAR(12), fd.Form_id) + ',', ',' + rfa.form_id + ',')
				FOR XML PATH, TYPE).value('.[1]', 'nvarchar(max)'), 1, 1, '')
			FROM tblRoleformaccess AS rf
			INNER JOIN tblRole ON rf.role_id = tblRole.Role_id
			ORDER BY roleformaccess_id;
END