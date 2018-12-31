DROP PROCEDURE IF EXISTS spCheckDocument;
delimiter $$
CREATE PROCEDURE spCheckDocument(IN DocumentParameter VARCHAR(11))
BEGIN
	
	select CASE WHEN EXISTS(
		SELECT *
		FROM Customer
		WHERE Document = DocumentParameter
	)
	THEN true ELSE false END;
	
end $$
delimiter ;
-- CALL spCheckDocument('10468306005');
