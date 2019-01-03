DROP PROCEDURE IF EXISTS spCreateCustomer;
DELIMITER $$
CREATE PROCEDURE spCreateCustomer
 (	IN IdP char(36), 
	IN FirstNameP VARCHAR(40),
	IN LastNameP VARCHAR(160),
	IN DocumentP CHAR(11), 
	IN EmailP   VARCHAR(160),
	IN PhoneP VARCHAR(13)
    )
	
BEGIN
    INSERT INTO Customer (
		Id,
        FirstName,
        LastName,
        Document,
        Email,
        Phone
    ) VALUES (
		IdP,
		FirstNameP,
		LastNameP, 
		DocumentP, 
		EmailP,  
		PhoneP );
END $$
DELIMITER ;


-- CALL spCreateCustomer(1,'Abraao','Allysson', '29164978036','conta@abraao.com.br', '83987654321');
