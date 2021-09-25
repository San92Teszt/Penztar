-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Dec 04. 17:47
-- Kiszolgáló verziója: 10.4.16-MariaDB
-- PHP verzió: 7.4.12

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
(375.37, 349.52, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felh`
--

CREATE TABLE `felh` (
  `nev` varchar(10) NOT NULL,
  `jelszo` varchar(100) NOT NULL,
  `admin` bit(2) NOT NULL,
  `penztar` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
(371.85, 344.74);

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

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `penztar`
--

CREATE TABLE `penztar` (
  `sorszam` int(11) NOT NULL,
  `cim` varchar(100) NOT NULL,
  `rovidnev` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
(1, 2500000, 3000, 4000);

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
  `ufszam` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `tranzakcio`
--

INSERT INTO `tranzakcio` (`psorszam`, `trsorszam`, `datum`, `vetel`, `forint`, `valuta`, `valutatipus`, `arf`, `storno`, `ufszam`) VALUES
(1, 'abc123', '2020-12-05 00:00:00', b'1', 2000, 10, 0, 321.54, b'0', 2),
(1, 'ddd333', '2020-12-04 00:00:00', b'1', 56000, 130, 1, 316.76, b'0', 4);

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
(365.45, 335.19, 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
