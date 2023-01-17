SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for Cost
-- ----------------------------
DROP TABLE IF EXISTS `Cost`;
CREATE TABLE `Cost`  (
  `CostId` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Amount` decimal(6, 2) NULL DEFAULT NULL,
  `StartDate` datetime NULL DEFAULT NULL,
  `EndDate` datetime NULL DEFAULT NULL,
  `ResourceId` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Service` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Currency` varchar(20) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `ExchangeRate` decimal(8, 2) NULL DEFAULT NULL,
  `OriginalCurrency` varchar(10) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `OriginalAmount` decimal(8, 2) NULL DEFAULT NULL,
  PRIMARY KEY (`CostId`) USING BTREE,
  INDEX `ResourceCost`(`ResourceId`) USING BTREE,
  CONSTRAINT `ResourceCost` FOREIGN KEY (`ResourceId`) REFERENCES `Resources` (`ResourceId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for Owner
-- ----------------------------
DROP TABLE IF EXISTS `Owner`;
CREATE TABLE `Owner`  (
  `OwnerId` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Firstname` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Lastname` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  PRIMARY KEY (`OwnerId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for Ownership
-- ----------------------------
DROP TABLE IF EXISTS `Ownership`;
CREATE TABLE `Ownership`  (
  `OwnerId` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `ResourceId` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `StartDateTime` datetime NOT NULL,
  `EndDateTime` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`OwnerId`, `ResourceId`) USING BTREE,
  INDEX `Resource_FK`(`ResourceId`) USING BTREE,
  CONSTRAINT `Owner_FK` FOREIGN KEY (`OwnerId`) REFERENCES `Owner` (`OwnerId`) ON DELETE NO ACTION ON UPDATE CASCADE,
  CONSTRAINT `Resource_FK` FOREIGN KEY (`ResourceId`) REFERENCES `Resources` (`ResourceId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Dynamic;


-- ----------------------------
-- Table structure for Resources
-- ----------------------------
DROP TABLE IF EXISTS `Resources`;
CREATE TABLE `Resources`  (
  `ResourceId` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Service` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Description` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `UnitId` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  PRIMARY KEY (`ResourceId`) USING BTREE,
  INDEX `ResourceUnit`(`UnitId`) USING BTREE,
  CONSTRAINT `ResourceUnit` FOREIGN KEY (`UnitId`) REFERENCES `Units` (`UnitId`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
