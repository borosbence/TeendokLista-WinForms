-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Nov 14. 14:02
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
(1, 'Első feladat', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1038{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 els\\\'f5\\\'f5\\\'f5\\\'f5\\\'f5\\\'f5 \\b aaa\\b0\\par\r\n\\par\r\n}\r\n', '2020-11-07 07:45:46', 0, 1),
(2, 'Második feladat', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1038{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\b\\f0\\fs17 F\\\'e9lk\\\'f6v\\\'e9\\b0 r sz\\\'f6veg\\par\r\n\\i D\\\'f5lt\\i0\\par\r\n\\ul\\\'c1th\\\'fazott \\ulnone\\strike al\\\'e1h\\\'fazott\\strike0\\par\r\n}\r\n', '2020-11-07 07:52:00', 0, 1);

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
(1, 'admin', '58B5444CF1B6253A4317FE12DAFF411A78BDA0A95279B1D5768EBF5CA60829E78DA944E8A9160A0B6D428CB213E813525A72650DAC67B88879394FF624DA482F'),
(2, 'user', '661BB43140229AD4DC3E762E7BDD68CC14BB9093C158C386BD989FEA807ACD9BD7F805CA4736B870B6571594D0D8FCFC57B98431143DFB770E083FA9BE89BC72');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `feladat`
--
ALTER TABLE `feladat`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Id` (`id`),
  ADD KEY `IX_FK_felhasznalofeladat` (`felhasznalo_id`);

--
-- A tábla indexei `felhasznalo`
--
ALTER TABLE `felhasznalo`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Id` (`id`),
  ADD UNIQUE KEY `felhasznalonev` (`felhasznalonev`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `feladat`
--
ALTER TABLE `feladat`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

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
