Create Table IF NOT EXISTS `Books`  (
	`Id` varchar(127) NOT NULL,
	`Author` longtext,
	`LaunchDate` datetime(6) NOT NULL,
	`Price` decimal(65,2) NOT NULL,
	`Title` longtext,
	Primary Key (`Id`)
	) Engine = InnoDB Default charset=latin1;
	