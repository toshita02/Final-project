-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 15, 2023 at 05:43 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_room_mgmt_system`
--
CREATE DATABASE IF NOT EXISTS `db_room_mgmt_system` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `db_room_mgmt_system`;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_customer_det`
--

DROP TABLE IF EXISTS `tbl_customer_det`;
CREATE TABLE IF NOT EXISTS `tbl_customer_det` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `FirstName` varchar(100) DEFAULT NULL,
  `LastName` varchar(100) DEFAULT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `Phone` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `City` varchar(100) DEFAULT NULL,
  `Address` varchar(200) DEFAULT NULL,
  `Roles` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_payment_detail`
--

DROP TABLE IF EXISTS `tbl_payment_detail`;
CREATE TABLE IF NOT EXISTS `tbl_payment_detail` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Cust_id` int(11) DEFAULT NULL,
  `Room_id` int(11) DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `PayAmount` decimal(10,2) DEFAULT 0.00,
  `DueAmount` decimal(10,2) DEFAULT 0.00,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_payment_detail`
--

INSERT INTO `tbl_payment_detail` (`ID`, `Cust_id`, `Room_id`, `StartDate`, `PayAmount`, `DueAmount`) VALUES
(1, 1, 1, '2023-04-14', '6600.00', '0.00'),
(2, 2, 1, '2023-04-15', '6600.00', '0.00');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_rooms_det`
--

DROP TABLE IF EXISTS `tbl_rooms_det`;
CREATE TABLE IF NOT EXISTS `tbl_rooms_det` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Image` varchar(100) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Rent_ID` varchar(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_rooms_details`
--

DROP TABLE IF EXISTS `tbl_rooms_details`;
CREATE TABLE IF NOT EXISTS `tbl_rooms_details` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RoomCopacity` int(11) DEFAULT NULL,
  `Rant` decimal(10,2) DEFAULT 0.00,
  `Electricity` decimal(10,2) DEFAULT 0.00,
  `WaterSupply` decimal(10,2) DEFAULT 0.00,
  `Total` decimal(10,2) DEFAULT 0.00,
  `Image` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `tbl_rooms_details`
--

INSERT INTO `tbl_rooms_details` (`ID`, `RoomCopacity`, `Rant`, `Electricity`, `WaterSupply`, `Total`, `Image`) VALUES
(1, 4, '6000.00', '200.00', '400.00', '6600.00', '/Images/Room/Room_1.jpg'),
(2, 8, '4500.00', '200.00', '400.00', '5100.00', '/Images/Room/Room_2.jpg'),
(3, 3, '8000.00', '200.00', '400.00', '8600.00', '/Images/Room/Room_3.jpg');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
