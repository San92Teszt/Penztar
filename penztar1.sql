-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Sze 25. 17:50
-- Kiszolgáló verziója: 10.4.17-MariaDB
-- PHP verzió: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `penztar`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `eladarf`
--

CREATE TABLE `eladarf` (
  `eur` double NOT NULL,
  `usd` double NOT NULL,
  `psorszam` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `eladarf`
--

INSERT INTO `eladarf` (`eur`, `usd`, `psorszam`) VALUES
(377.01, 370.07, 1),
(377.01, 370.07, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felh`
--

CREATE TABLE `felh` (
  `nev` varchar(10) NOT NULL,
  `jelszo` varchar(100) NOT NULL,
  `admin` bit(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `felh`
--

INSERT INTO `felh` (`nev`, `jelszo`, `admin`) VALUES
('abc', '45dd7d16405a3b749ff227590fa48e9731f689f4', b'0'),
('valaki', '9d4e1e23bd5b727046a9e3b4b7db57bd8d6ee684', b'1');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jogiszemely`
--

CREATE TABLE `jogiszemely` (
  `ufszam` int(11) NOT NULL,
  `cegnev` varchar(50) NOT NULL,
  `adoszam` varchar(20) NOT NULL,
  `cegjegyzek` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `jogiszemely`
--

INSERT INTO `jogiszemely` (`ufszam`, `cegnev`, `adoszam`, `cegjegyzek`) VALUES
(2, 'xyz kft', '1234-13-14', '3241-1-32'),
(4, 'Digital Tech Zrt', '3625-12-213', '321-4-3214');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kozeparf`
--

CREATE TABLE `kozeparf` (
  `eur` double NOT NULL,
  `usd` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `kozeparf`
--

INSERT INTO `kozeparf` (`eur`, `usd`) VALUES
(355.21, 347.65);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `maganszemely`
--

CREATE TABLE `maganszemely` (
  `ufszam` int(11) NOT NULL,
  `veznev` varchar(50) NOT NULL,
  `kernev` varchar(50) NOT NULL,
  `igszam` varchar(20) NOT NULL,
  `lakcimszam` varchar(20) NOT NULL,
  `szulhely` varchar(30) NOT NULL,
  `szulido` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `maganszemely`
--

INSERT INTO `maganszemely` (`ufszam`, `veznev`, `kernev`, `igszam`, `lakcimszam`, `szulhely`, `szulido`) VALUES
(1, 'Szendrényi', 'András', '502617ra', '473627CI', 'Budapest', '1992-05-19'),
(3, 'Kiss', 'Gyuláné', '382771TA', '388892CI', 'Szeged', '1967-01-14'),
(5, 'Takács', 'József', '437266TA', '473392 NU', 'Szentendre', '1977-06-14'),
(6, 'Kiss', 'Helga', '437726TA', '7446633CI', 'Pomáz', '1994-12-07'),
(7, 'Kerekes', 'Ernő', '333333aa', '548966IO', 'Visegrád', '1986-04-11');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `penztar`
--

CREATE TABLE `penztar` (
  `sorszam` int(11) NOT NULL,
  `cim` varchar(100) NOT NULL,
  `rovidnev` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `penztar`
--

INSERT INTO `penztar` (`sorszam`, `cim`, `rovidnev`) VALUES
(1, '1039 Budapest Áldomás utca 5/C', 'Békás'),
(2, '2120 Dunakeszi Fő út 2', 'Keszi'),
(3, 'Szentendre, Veres Lajos utca 18', 'Szentendre');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `penztaregyenleg`
--

CREATE TABLE `penztaregyenleg` (
  `psorszam` int(11) NOT NULL,
  `huf` int(11) NOT NULL,
  `eur` int(11) NOT NULL,
  `usd` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `penztaregyenleg`
--

INSERT INTO `penztaregyenleg` (`psorszam`, `huf`, `eur`, `usd`) VALUES
(1, 1870641, 3025, 1500),
(2, 4500000, 1500, 4999);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tranzakcio`
--

CREATE TABLE `tranzakcio` (
  `psorszam` int(11) NOT NULL,
  `trsorszam` varchar(20) NOT NULL,
  `datum` datetime NOT NULL,
  `vetel` bit(1) NOT NULL,
  `forint` int(11) NOT NULL,
  `valuta` int(11) NOT NULL,
  `valutatipus` int(11) NOT NULL,
  `arf` double NOT NULL,
  `storno` bit(1) NOT NULL,
  `ufszam` int(11) DEFAULT NULL,
  `felhasznalo` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `tranzakcio`
--

INSERT INTO `tranzakcio` (`psorszam`, `trsorszam`, `datum`, `vetel`, `forint`, `valuta`, `valutatipus`, `arf`, `storno`, `ufszam`, `felhasznalo`) VALUES
(1, 'VV1-001/2020-12-13', '2020-12-13 00:00:00', b'1', 349730, 1000, 0, 349.73, b'0', 1, NULL),
(1, 'VE1-001/2020-12-13', '2020-12-13 00:00:00', b'0', 185035, 500, 1, 370.07, b'0', 1, NULL),
(1, 'VE1-002/2020-12-13', '2020-12-13 00:00:00', b'0', 1295245, 3500, 1, 370.07, b'0', 1, NULL),
(1, 'VE1-003/2020-12-13', '2020-12-13 00:00:00', b'0', 1508040, 4000, 0, 377.01, b'0', 1, NULL),
(1, 'VV1-002/2020-12-13', '2020-12-13 00:00:00', b'1', 3497300, 10000, 0, 349.73, b'0', 1, NULL),
(1, 'VV1-003/2020-12-13', '2020-12-13 00:00:00', b'1', 1356640, 4000, 1, 339.16, b'0', 1, NULL),
(1, 'VE1-004/2020-12-13', '2020-12-13 00:00:00', b'0', 2639070, 7000, 0, 377.01, b'0', 1, NULL),
(1, 'VE1-005/2020-12-13', '2020-12-13 00:00:00', b'0', 1131030, 3000, 0, 377.01, b'0', 1, NULL),
(1, 'VV1-004/2020-12-13', '2020-12-13 00:00:00', b'1', 1049190, 3000, 0, 349.73, b'0', 1, NULL),
(1, 'VE1-006/2020-12-13', '2020-12-13 00:00:00', b'0', 1480280, 4000, 1, 370.07, b'0', 1, NULL),
(1, 'VV1-005/2020-12-13', '2020-12-13 00:00:00', b'1', 1356640, 4000, 1, 339.16, b'0', 1, NULL),
(1, 'VV1-006/2020-12-13', '2020-12-13 00:00:00', b'1', 1356640, 4000, 1, 339.16, b'0', 1, NULL),
(1, 'VV1-007/2020-12-13', '2020-12-13 00:00:00', b'1', 2255758, 6450, 0, 349.73, b'0', 1, NULL),
(1, 'VE1-007/2020-12-13', '2020-12-13 00:00:00', b'0', 2431714, 6450, 0, 377.01, b'0', 1, NULL),
(1, 'VE1-008/2020-12-13', '2020-12-13 00:00:00', b'0', 2431714, 6450, 1, 370.07, b'0', 1, NULL),
(1, 'VV1-001/2020-12-16', '2020-12-16 00:00:00', b'1', 1189082, 3400, 0, 349.73, b'0', 1, NULL),
(1, 'VV1-002/2020-12-16', '2020-12-16 00:00:00', b'1', 339160, 1000, 1, 339.16, b'0', 1, NULL),
(1, 'VE1-001/2020-12-16', '2020-12-16 00:00:00', b'0', 169654, 450, 0, 377.01, b'0', 4, NULL),
(1, 'VE1-002/2020-12-16', '2020-12-16 00:00:00', b'0', 169654, 450, 0, 377.01, b'0', 4, NULL),
(1, 'VE1-003/2020-12-16', '2020-12-16 00:00:00', b'0', 942525, 2500, 0, 377.01, b'0', 4, NULL),
(1, 'VV1-003/2020-12-16', '2020-12-16 00:00:00', b'1', 507108, 1450, 0, 349.73, b'0', 4, NULL),
(1, 'VE1-004/2020-12-16', '2020-12-16 00:00:00', b'0', 546664, 1450, 0, 377.01, b'0', 4, NULL),
(1, 'VV1-004/2020-12-16', '2020-12-16 00:00:00', b'1', 507108, 1450, 1, 339.16, b'0', 4, NULL),
(1, 'VE1-005/2020-12-16', '2020-12-16 00:00:00', b'0', 370, 1, 1, 370.07, b'0', 1, NULL),
(1, 'VE1-001/2020-12-19', '2020-12-19 00:00:00', b'0', 56552, 150, 0, 377.01, b'0', 1, NULL),
(1, 'VE1-002/2020-12-19', '2020-12-19 00:00:00', b'0', 37701, 100, 0, 377.01, b'0', 4, NULL),
(1, 'VV1-001/2020-12-26', '2020-12-26 00:00:00', b'1', 34973, 100, 0, 349.73, b'0', 1, NULL),
(1, 'VV1-002/2020-12-26', '2020-12-26 00:00:00', b'1', 41968, 120, 0, 349.73, b'0', 4, 'abc'),
(1, 'VV1-003/2020-12-26', '2020-12-26 00:00:00', b'1', 169580, 500, 1, 339.16, b'0', 4, 'valaki'),
(1, 'VV1-001/2021-1-23', '2021-01-23 00:00:00', b'1', 454649, 1300, 0, 349.73, b'0', 1, 'abc'),
(1, 'VV1-001/2021-9-23', '2021-09-23 00:00:00', b'1', 69946, 200, 0, 349.73, b'0', 1, 'abc');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ugyfel`
--

CREATE TABLE `ugyfel` (
  `ufszam` int(11) NOT NULL,
  `irsz` int(11) NOT NULL,
  `helyseg` varchar(50) NOT NULL,
  `utcahaz` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `ugyfel`
--

INSERT INTO `ugyfel` (`ufszam`, `irsz`, `helyseg`, `utcahaz`) VALUES
(1, 2011, 'Budakalász', 'Batthyány utca 1'),
(2, 2000, 'Szentendre', 'Kecske utca 6'),
(3, 4033, 'Debrecen', 'Sámsoni út 13'),
(4, 1039, 'Budapest', 'Szobor utca 2/A'),
(5, 1039, 'Budapest', 'Fal utca 17/B'),
(6, 2000, 'Szentendre', 'Fő tér 6'),
(7, 2009, 'Pilisszentlászló', 'Béke u 4');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `varakozo`
--

CREATE TABLE `varakozo` (
  `Kuldo` int(11) NOT NULL,
  `Fogado` int(11) NOT NULL,
  `Penznem` varchar(3) NOT NULL,
  `Arfolyam` double NOT NULL,
  `Sorszam` varchar(20) NOT NULL,
  `atvette` bit(1) DEFAULT NULL,
  `datum` date DEFAULT NULL,
  `kiadas` bit(1) DEFAULT NULL,
  `megjegyzes` varchar(150) DEFAULT NULL,
  `osszeg` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vetelarf`
--

CREATE TABLE `vetelarf` (
  `eur` double NOT NULL,
  `usd` double NOT NULL,
  `psorszam` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `vetelarf`
--

INSERT INTO `vetelarf` (`eur`, `usd`, `psorszam`) VALUES
(349.73, 339.16, 1),
(349.73, 339.16, 2);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
