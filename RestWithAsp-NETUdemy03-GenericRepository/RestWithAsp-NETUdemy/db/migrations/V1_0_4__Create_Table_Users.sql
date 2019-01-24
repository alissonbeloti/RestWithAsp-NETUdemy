Create Table IF NOT EXISTS `Users`  (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Login` varchar(50) NOT NULL,
	`AccessKey` longtext NOT NULL,
	Primary Key (`Id`)
	) Engine = InnoDB Default charset=latin1;
	