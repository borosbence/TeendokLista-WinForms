-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 11/19/2019 20:19:03

-- Generated from EDMX file: H:\Vasvári\Programozási nyelvek\09\TeendokLista-master\TeendokLista\Models\TeendokModel.edmx
-- Target version: 3.0.0.0

-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------



-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;

    DROP TABLE IF EXISTS `feladat`;

SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


CREATE TABLE `feladat`(
	`Id` int NOT NULL AUTO_INCREMENT UNIQUE,
	`Cim` varchar (50) NOT NULL, 
	`Szoveg` varchar (255), 
	`LetrehozasDatum` datetime NOT NULL, 
	`Teljesitve` boolean NOT NULL, 
	`felhasznaloId` int NOT NULL,
    PRIMARY KEY (`Id`));




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
