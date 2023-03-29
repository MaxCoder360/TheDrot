-- MySQL dump 10.13  Distrib 8.0.28, for macos11 (x86_64)
--
-- Host: 127.0.0.1    Database: TheDrot
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admins` (
  `id_admin` int unsigned NOT NULL,
  `name` varchar(45) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `passport` blob NOT NULL,
  `phone_number` varchar(45) NOT NULL,
  `password` binary(32) NOT NULL,
  PRIMARY KEY (`id_admin`),
  UNIQUE KEY `id_admins_UNIQUE` (`id_admin`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `computers`
--

DROP TABLE IF EXISTS `computers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `computers` (
  `id_computer` int unsigned NOT NULL,
  `type` varchar(45) NOT NULL,
  `manufacturer` varchar(45) NOT NULL,
  `serial_number` varchar(45) NOT NULL,
  `CPU` varchar(45) NOT NULL,
  `GPU` varchar(45) NOT NULL,
  `RAM` varchar(45) NOT NULL,
  `Storage` varchar(45) NOT NULL,
  PRIMARY KEY (`id_computer`),
  UNIQUE KEY `id_computer_UNIQUE` (`id_computer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sessions`
--

DROP TABLE IF EXISTS `sessions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sessions` (
  `id_sessions` int unsigned NOT NULL,
  `id_admin` int unsigned NOT NULL,
  `id_user` int unsigned NOT NULL,
  `id_computer` int unsigned NOT NULL,
  `start_time_rent` datetime DEFAULT NULL,
  `end_time_rent` datetime DEFAULT NULL,
  PRIMARY KEY (`id_sessions`),
  UNIQUE KEY `id_sessions_UNIQUE` (`id_sessions`),
  KEY `key_for_session_id_users_idx` (`id_user`),
  KEY `key_for_session_id_computers_idx` (`id_computer`),
  KEY `key_for_session_id_admin_idx` (`id_admin`),
  CONSTRAINT `key_for_session_id_admin` FOREIGN KEY (`id_admin`) REFERENCES `admins` (`id_admin`),
  CONSTRAINT `key_for_session_id_computers` FOREIGN KEY (`id_computer`) REFERENCES `computers` (`id_computer`),
  CONSTRAINT `key_for_session_id_users` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_user` int unsigned NOT NULL,
  `name` varchar(45) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `passport` blob NOT NULL,
  `phone_number` varchar(45) NOT NULL,
  `password` binary(32) NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE KEY `id_users_UNIQUE` (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-29  3:23:35
