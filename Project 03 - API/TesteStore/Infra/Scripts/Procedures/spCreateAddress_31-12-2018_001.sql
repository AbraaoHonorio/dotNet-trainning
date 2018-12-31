DROP PROCEDURE IF EXISTS spCreateAddress;
DELIMITER $$
CREATE PROCEDURE spCreateAddress
 (	IN IdP INT, 
	IN CustomerIdP INT,
	IN NumberP VARCHAR(10),
	IN ComplementP VARCHAR(40), 
	IN DistrictP  VARCHAR(60),
	IN CityP   VARCHAR(60),
	IN StateP  VARCHAR(2),
	IN CountryP VARCHAR(2),
	IN ZipCodeP   VARCHAR(8),
	IN TypeP INT)
BEGIN
    INSERT INTO Address (
		Id,
        CustomerId,
        Number,
        Complement,
        District,
        City,
        State,
        Country,
        ZipCode,
        Type
    ) VALUES (
        IdP,
        CustomerIdP,
        NumberP,
        ComplementP,
        DistrictP,
        CityP,
        StateP,
        CountryP,
        ZipCodeP,
        TypeP );
END $$
DELIMITER ;


-- CALL spCreateAddress(1,1,'333','perto do geo', '','João Pessoa', 'PB', 'BR','58052280',1);


