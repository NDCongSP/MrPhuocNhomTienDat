-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: sonthinhgiamsatloducnhom
-- ------------------------------------------------------
-- Server version	5.7.44-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `data`
--

DROP TABLE IF EXISTS `data`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `data` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DateTime` datetime DEFAULT CURRENT_TIMESTAMP,
  `MacNhom` varchar(10) DEFAULT '0',
  `DuongKinh` varchar(500) DEFAULT '0',
  `NhietDoNuocNhomTrongLo` float DEFAULT '0',
  `NhietDoNhomTruocKhuon` float DEFAULT '0',
  `NhietDoNhomCuoiKhuon` float DEFAULT '0',
  `NhietDoNuocGiaiNhietMam` float DEFAULT '0',
  `NhietDoNuocMatGieng` float DEFAULT '0',
  `NhietDoKhongKhiTrongLo` float DEFAULT '0',
  `ApLucNuocL1` float DEFAULT '0',
  `VanTocSoiTitan` float DEFAULT '0',
  `TocDoCayKhuay` float DEFAULT '0',
  `ApKhiArgon` float DEFAULT '0',
  `VanTocXuongMam` float DEFAULT '0',
  `ChieuDaiPhoi` float DEFAULT '0',
  `ThoiGianDongDac` float DEFAULT '0',
  `TanSoXuongMam` float DEFAULT '0',
  `TanSoBomNuoc` float DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `data`
--

LOCK TABLES `data` WRITE;
/*!40000 ALTER TABLE `data` DISABLE KEYS */;
INSERT INTO `data` VALUES (1,'2025-09-07 10:08:13','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(2,'2025-09-07 10:45:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(3,'2025-09-07 10:46:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(4,'2025-09-07 10:46:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(5,'2025-09-07 10:47:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(6,'2025-09-07 10:47:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(7,'2025-09-07 10:48:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(8,'2025-09-07 10:48:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(9,'2025-09-07 10:49:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(10,'2025-09-07 10:49:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(11,'2025-09-07 10:50:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(12,'2025-09-07 10:50:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(13,'2025-09-07 10:51:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(14,'2025-09-07 10:51:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(15,'2025-09-07 10:52:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(16,'2025-09-07 10:52:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(17,'2025-09-07 10:53:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(18,'2025-09-07 10:53:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(19,'2025-09-07 10:54:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(20,'2025-09-07 10:54:47','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(21,'2025-09-07 10:55:17','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(22,'2025-09-07 10:55:48','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(23,'2025-09-07 10:56:18','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(24,'2025-09-07 10:56:48','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(25,'2025-09-07 10:57:18','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(26,'2025-09-07 10:57:48','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(27,'2025-09-07 10:58:18','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(28,'2025-09-07 10:58:48','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(29,'2025-09-07 10:59:18','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(30,'2025-09-07 10:59:48','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(31,'2025-09-07 11:00:18','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0),(32,'2025-09-07 11:00:48','AAAA','rrrrr',32,31,30,33,34,35,0,0,0,0,4,0,0,25.09,0);
/*!40000 ALTER TABLE `data` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `limitsettings`
--

DROP TABLE IF EXISTS `limitsettings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `limitsettings` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Parametters` varchar(100) DEFAULT NULL,
  `Min` float DEFAULT NULL,
  `Max` float DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `limitsettings`
--

LOCK TABLES `limitsettings` WRITE;
/*!40000 ALTER TABLE `limitsettings` DISABLE KEYS */;
INSERT INTO `limitsettings` VALUES (1,'DuongKinh',2,10),(2,'NDNuocNhomTrongLo',2,11),(3,'NDNhomTruocKhuon',2,14),(4,'NDNhomTaiMiengLo',2,14),(5,'NDNuocGiaiNhietMam',2,10),(6,'NDNuocMatGieng',2,10),(7,'NDKhongKhiTrongLo',2,10),(8,'ApLucNuocL1',2,10),(9,'VanTocSoiTitan',2,10),(10,'TocDoCayKhuay',2,10),(11,'ApKhiArgon',2,10),(12,'VanTocXuongMam',2,10),(13,'ChieuDaiPhoi',2,10),(14,'ThoiGianDongDac',2,10),(15,'TanSoXuongMam',2,10),(16,'TanSoBomNuoc',2,10);
/*!40000 ALTER TABLE `limitsettings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `useraccount`
--

DROP TABLE IF EXISTS `useraccount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `useraccount` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `useraccount`
--

LOCK TABLES `useraccount` WRITE;
/*!40000 ALTER TABLE `useraccount` DISABLE KEYS */;
INSERT INTO `useraccount` VALUES (1,'operator1','67890');
/*!40000 ALTER TABLE `useraccount` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-09-07 11:00:58
