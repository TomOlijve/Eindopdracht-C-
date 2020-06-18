-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 15 jun 2020 om 15:38
-- Serverversie: 10.4.11-MariaDB
-- PHP-versie: 7.4.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `csharp`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `weergegevens`
--

CREATE TABLE `weergegevens` (
  `temperatuur` double NOT NULL,
  `plaats` varchar(128) NOT NULL,
  `datum` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Gegevens worden geëxporteerd voor tabel `weergegevens`
--

INSERT INTO `weergegevens` (`temperatuur`, `plaats`, `datum`) VALUES
(27, 'Emmen', '2020-06-14'),
(24, 'Emmen', '2020-06-13'),
(15, 'Emmen', '2020-06-12'),
(21, 'Emmen', '2020-06-11'),
(22, 'Emmen', '2020-06-10'),
(20, 'Emmen', '2020-06-15');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
