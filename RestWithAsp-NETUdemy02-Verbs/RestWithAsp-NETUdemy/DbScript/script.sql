use rest_aspnet_udemy;

Create Table Persons  (
	Id int(10) UNSIGNED NULL DEFAULT NULL,
	FirstName Varchar(50) NULL DEFAULT NULL,
	LastName Varchar(50) NULL DEFAULT NULL,
	Address Varchar(100) NULL DEFAULT NULL,
	Gender varchar(10) NULL DEFAULT NULL
	)
	ENGINE = InnoDB;
	