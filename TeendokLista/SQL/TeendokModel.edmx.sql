-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 11/21/2019 11:34:43

-- Generated from EDMX file: C:\Users\bo015833\Documents\Visual Studio 2017\Repos\Vasvári\TeendokLista\TeendokLista\Models\TeendokModel.edmx
-- Target version: 3.0.0.0
-- --------------------------------------------------

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


CREATE TABLE `feladat`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE,
	`Cim` varchar (50) NOT NULL, 
	`Szoveg` varchar (255), 
	`LetrehozasDatum` datetime NOT NULL, 
	`Teljesitve` bool NOT NULL, 
	`felhasznaloId` int NOT NULL,
	PRIMARY KEY (`Id`));

--ALTER TABLE `feladat` ADD PRIMARY KEY (`Id`);



CREATE TABLE `felhasznalo`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`FelhasznaloNev` varchar (255) NOT NULL, 
	`Jelszo` varchar (255) NOT NULL,
	PRIMARY KEY (`Id`));

--ALTER TABLE `felhasznalo` ADD PRIMARY KEY (`Id`);


CREATE TABLE `felhasznalo`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`FelhasznaloNev` longtext NOT NULL, 
	`Jelszo` longtext NOT NULL,
	PRIMARY KEY(`Id`));



-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------


-- Creating foreign key on `felhasznaloId` in table 'feladat'

ALTER TABLE `feladat`
ADD CONSTRAINT `FK_felhasznalofeladat`
    FOREIGN KEY (`felhasznaloId`)
    REFERENCES `felhasznalo`
        (`Id`)
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_felhasznalofeladat'

CREATE INDEX `IX_FK_felhasznalofeladat`
    ON `feladat`
    (`felhasznaloId`);



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
