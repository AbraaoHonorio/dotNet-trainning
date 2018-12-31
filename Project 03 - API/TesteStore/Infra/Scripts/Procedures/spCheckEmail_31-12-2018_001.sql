DROP PROCEDURE IF EXISTS spCheckEmail;
delimiter $$
CREATE PROCEDURE spCheckEmail(IN EmailParameter VARCHAR(160))
BEGIN
	
	select CASE WHEN EXISTS(
		SELECT *
		FROM Customer
		WHERE Email = EmailParameter
	)
	THEN true ELSE false END;
	
end $$
delimiter ;
-- CALL spCheckEmail('abraao@gmail.com');