USE timestampmanagement

	SELECT tblEmployee.emp_name, tblGender.gender_name
	FROM tblEmployee
	INNER JOIN tblGender ON tblEmployee.gender_id = tblGender.gender_id;

	SELECT tblEmployee.emp_id, tblEmployee.emp_name, tblEmployee.emp_dob, tblRole.role_name,
	tblGender.gender_name, tblEmployee.emp_email, tblEmployee.emp_phone, tblEmployee.emp_address
	FROM ((tblEmployee
	INNER JOIN tblGender ON tblEmployee.gender_id = tblGender.gender_id)
	INNER JOIN tblRole ON tblEmployee.role_id = tblRole.role_id);