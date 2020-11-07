-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Nov 07. 07:55
-- Kiszolgáló verziója: 10.4.8-MariaDB
-- PHP verzió: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `teendoklista`
--
CREATE DATABASE IF NOT EXISTS `teendoklista` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `teendoklista`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ertekezlet`
--

CREATE TABLE `ertekezlet` (
  `id` int(11) NOT NULL,
  `nev` varchar(255) NOT NULL,
  `kezdet_datum` datetime NOT NULL,
  `veg_datum` datetime DEFAULT NULL,
  `leiras` text DEFAULT NULL,
  `letszam` int(3) DEFAULT NULL,
  `online` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- A tábla adatainak kiíratása `ertekezlet`
--

INSERT INTO `ertekezlet` (`id`, `nev`, `kezdet_datum`, `veg_datum`, `leiras`, `letszam`, `online`) VALUES
(1, 'MVC előadás', '2020-04-20 11:30:00', '2020-04-20 14:00:00', 'Előadás az ASP.NET MVC-ről', 24, 1),
(4, 'Tanári értekezlet', '2020-04-23 08:00:00', NULL, 'Év vizsgák átbeszélése', 20, 1),
(10, 'Utolsó óra', '2020-04-25 06:00:00', NULL, 'Tesztelés', 10, 1),
(11, 'ID teszt', '2020-04-25 08:00:00', NULL, 'mi az ID-m?', 2, 0),
(12, '12-es ID', '2020-04-26 06:00:00', NULL, '12-es ID-t kérek', 12, 1),
(13, '1 fős értekezlet', '2020-04-26 22:00:00', NULL, 'hibát kapok?', NULL, 0),
(14, 'teszt', '2020-04-29 22:00:00', NULL, 'asaaaa', NULL, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `feladat`
--

CREATE TABLE `feladat` (
  `id` int(11) NOT NULL,
  `cim` varchar(50) NOT NULL,
  `szoveg` text DEFAULT NULL,
  `letrehozas_datum` datetime NOT NULL,
  `teljesitve` tinyint(1) NOT NULL DEFAULT 0,
  `felhasznalo_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- A tábla adatainak kiíratása `feladat`
--

INSERT INTO `feladat` (`id`, `cim`, `szoveg`, `letrehozas_datum`, `teljesitve`, `felhasznalo_id`) VALUES
(8, 'Első feladat', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1038{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 els\\\'f5\\\'f5\\\'f5\\\'f5\\\'f5\\\'f5 \\b aaa\\b0\\par\r\n\\par\r\n}\r\n', '2020-11-07 07:45:46', 0, 1),
(11, 'Második feladat', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1038{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\b\\f0\\fs17 F\\\'e9lk\\\'f6v\\\'e9\\b0 r sz\\\'f6veg\\par\r\n\\i D\\\'f5lt\\i0\\par\r\n\\ul\\\'c1th\\\'fazott \\ulnone\\strike al\\\'e1h\\\'fazott\\strike0\\par\r\n}\r\n', '2020-11-07 07:52:00', 0, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalo`
--

CREATE TABLE `felhasznalo` (
  `id` int(11) NOT NULL,
  `felhasznalonev` varchar(255) NOT NULL,
  `jelszo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- A tábla adatainak kiíratása `felhasznalo`
--

INSERT INTO `felhasznalo` (`id`, `felhasznalonev`, `jelszo`) VALUES
(1, 'admin', '4489E5D29D8855EBA4A22E02513D96DF7E567F03038F1F49B4586551E918D5113095A32D1706156BE72F55BF1E5D72B0B1907E218D12179B5B04A130360890AB'),
(2, 'user', '5FECEB66FFC86F38D952786C6D696C79C2DBC239DD4E91B46729D73A27FB57E9');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `ertekezlet`
--
ALTER TABLE `ertekezlet`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `feladat`
--
ALTER TABLE `feladat`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Id` (`id`),
  ADD UNIQUE KEY `cim` (`cim`),
  ADD KEY `IX_FK_felhasznalofeladat` (`felhasznalo_id`);

--
-- A tábla indexei `felhasznalo`
--
ALTER TABLE `felhasznalo`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Id` (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `ertekezlet`
--
ALTER TABLE `ertekezlet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT a táblához `feladat`
--
ALTER TABLE `feladat`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT a táblához `felhasznalo`
--
ALTER TABLE `felhasznalo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `feladat`
--
ALTER TABLE `feladat`
  ADD CONSTRAINT `FK_felhasznalofeladat` FOREIGN KEY (`felhasznalo_id`) REFERENCES `felhasznalo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
