/*
 Navicat MySQL Data Transfer

 Source Server         : Local_MySql
 Source Server Type    : MySQL
 Source Server Version : 80021
 Source Host           : localhost:3307
 Source Schema         : testlibrary

 Target Server Type    : MySQL
 Target Server Version : 80021
 File Encoding         : 65001

 Date: 27/12/2020 04:50:48
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(95) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20201225114314_Init00', '3.1.10');
INSERT INTO `__efmigrationshistory` VALUES ('20201225120622_Init01', '3.1.10');
INSERT INTO `__efmigrationshistory` VALUES ('20201225125354_Init02', '3.1.10');

-- ----------------------------
-- Table structure for aspnetroleclaims
-- ----------------------------
DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE `aspnetroleclaims`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AspNetRoleClaims_RoleId`(`RoleId`) USING BTREE,
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetroleclaims
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE `aspnetroles`  (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `RoleNameIndex`(`NormalizedName`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetroles
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserclaims
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE `aspnetuserclaims`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AspNetUserClaims_UserId`(`UserId`) USING BTREE,
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetuserclaims
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserlogins
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE `aspnetuserlogins`  (
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`, `ProviderKey`) USING BTREE,
  INDEX `IX_AspNetUserLogins_UserId`(`UserId`) USING BTREE,
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetuserlogins
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles`  (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`, `RoleId`) USING BTREE,
  INDEX `IX_AspNetUserRoles_RoleId`(`RoleId`) USING BTREE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetuserroles
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetusers
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE `aspnetusers`  (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `user_id` int(8) UNSIGNED ZEROFILL NULL DEFAULT 00000000,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  `user_borrow_quantity` int UNSIGNED NULL DEFAULT NULL,
  `user_gender_Id` smallint(4) UNSIGNED ZEROFILL NULL DEFAULT NULL,
  `user_photo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL,
  `user_register_date` date NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `UserNameIndex`(`NormalizedUserName`) USING BTREE,
  INDEX `EmailIndex`(`NormalizedEmail`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetusers
-- ----------------------------
INSERT INTO `aspnetusers` VALUES ('9df4a6b6-1c10-4191-92aa-b1947f73dcae', 00000001, 'admin', 'ADMIN', 'Kianakiferi@outlook.com', 'KIANAKIFERI@OUTLOOK.COM', 0, 'AQAAAAEAACcQAAAAEBTDZOQzXw9o03gEsKCYOb/rHDqjbhMet/Qrie7Waa5tf9SKY7Cj644MQ9clLZ9Frw==', 'AQOAV6OKGHOYL2MZ2YN4R7APAYOAV5OI', '2f588d8c-169e-47a1-8fc6-f4c016bf91c8', NULL, 0, 0, NULL, 1, 0, 0, 0000, NULL, '2020-12-26');

-- ----------------------------
-- Table structure for aspnetusertokens
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE `aspnetusertokens`  (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`UserId`, `LoginProvider`, `Name`) USING BTREE,
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetusertokens
-- ----------------------------

-- ----------------------------
-- Table structure for book
-- ----------------------------
DROP TABLE IF EXISTS `book`;
CREATE TABLE `book`  (
  `book_id` int(12) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT COMMENT '图书序号',
  `book_code` varchar(24) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '图书编号或条码号',
  `book_name` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '书名',
  `book_name_sub` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '副书名',
  `book_isbn` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT 'ISBN 书号',
  `book_clccode` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT 'CLC 分类号',
  `book_status_id` smallint(4) UNSIGNED ZEROFILL NULL DEFAULT NULL COMMENT '图书状态ID',
  `book_author` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '作者',
  `book_publisher` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '出版社',
  `book_press_date` date NULL DEFAULT NULL COMMENT '出版日期',
  `book_language_id` smallint(4) UNSIGNED ZEROFILL NULL DEFAULT NULL COMMENT '语言ID',
  `book_pages` int UNSIGNED NULL DEFAULT NULL COMMENT '页数',
  `book_price` decimal(8, 2) NULL DEFAULT NULL COMMENT '价格',
  `book_purchase_date` date NOT NULL COMMENT '入馆时间',
  `book_brief` text CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL COMMENT '内容简介',
  `book_cover` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '封面',
  PRIMARY KEY (`book_id`) USING BTREE,
  INDEX `book_status_id`(`book_status_id`) USING BTREE,
  INDEX `book_language_id`(`book_language_id`) USING BTREE,
  CONSTRAINT `book_ibfk_1` FOREIGN KEY (`book_language_id`) REFERENCES `book_language` (`language_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `book_ibfk_2` FOREIGN KEY (`book_status_id`) REFERENCES `book_status` (`status_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of book
-- ----------------------------
INSERT INTO `book` VALUES (000000000005, '1900121889', '世界潜艇百科详解', NULL, '9787111589563', 'E925.66/23', 0000, '(美) 大卫·罗斯著，钱坤 译', '机械工业出版社', '2019-01-01', 0000, 203, 99.80, '2020-12-14', '本书涵盖了潜艇历史、潜艇种类，以及世界主要潜艇的基本情况，同时还以剖面的形式介绍了潜艇内部结构，以及工作原理。还在后半部分介绍了世界各国主要潜艇的装备情况，对于了解潜艇技术、潜艇分布，有着一定的参考价值。', NULL);
INSERT INTO `book` VALUES (000000000006, '1900124592', '克里米亚战争', '被遗忘的帝国博弈', '9787305207914 ', 'E509 ', 0000, '(英) 奥兰多·费吉斯 著，吕品，朱珠 译', '南京大学出版社', '2018-01-01', 0000, 717, 128.00, '2020-12-14', '	本书利用大量俄国、奥斯曼帝国以及欧洲国家的资料，不仅生动描述了这场旷日持久的鏖战，而且全面展现了战时的世界图景：从圣彼得堡的宫廷到耶路撒冷圣地，从书写塞瓦斯托波尔围城战的托尔斯泰到幻想拯救基督教徒的沙皇尼古拉一世，从战场上的普通士兵和护士到围城内的妇孺。战场上的种族清洗、西方与穆斯林世界的关系依然呼应着当今的时代问题。', NULL);
INSERT INTO `book` VALUES (000000000007, '1900119646', '屠夫之鸟', '二战德国空军Fw 190战斗机战史', '9787307202436', 'E926.31', 0000, '高智著', '武汉大学出版社', '2018-01-01', 0000, 812, 148.00, '2020-12-26', '绰号为“屠夫之鸟”的Fw 190战斗机, 被认为是二战德国整体性能最好的主战战斗机, 为德国空军争夺制空权立下了汗马功劳。在西线防空战中, 一直是对抗盟军战略轰炸的劲敌, 战绩极为突出, 被盟国空军视为主要的空战对手。Fw 190战斗机1939年6月首飞, 1941年装备部队, 共生产了20000架多。本书基于丰富的第一手相关史料, 从纯军事的角度, 系统、客观而生动地地讲述了Fw 190战机从设计、试飞、改进, 列装部队, 到其各种型号战机投入战场后的典型表现的全过程。', NULL);

-- ----------------------------
-- Table structure for book_language
-- ----------------------------
DROP TABLE IF EXISTS `book_language`;
CREATE TABLE `book_language`  (
  `language_id` smallint(4) UNSIGNED ZEROFILL NOT NULL,
  `language_name` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '语言类型',
  PRIMARY KEY (`language_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of book_language
-- ----------------------------
INSERT INTO `book_language` VALUES (0000, 'zh_CN');
INSERT INTO `book_language` VALUES (0001, 'en_US');
INSERT INTO `book_language` VALUES (0002, 'ja_JP');
INSERT INTO `book_language` VALUES (0003, 'ru_RU');
INSERT INTO `book_language` VALUES (0004, 'de_DE');
INSERT INTO `book_language` VALUES (0005, 'fr_FR');

-- ----------------------------
-- Table structure for book_status
-- ----------------------------
DROP TABLE IF EXISTS `book_status`;
CREATE TABLE `book_status`  (
  `status_id` smallint(4) UNSIGNED ZEROFILL NOT NULL,
  `status_name` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '图书状态',
  PRIMARY KEY (`status_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of book_status
-- ----------------------------
INSERT INTO `book_status` VALUES (0000, 'Normal');
INSERT INTO `book_status` VALUES (0001, 'Borrow');
INSERT INTO `book_status` VALUES (0002, 'Lost');
INSERT INTO `book_status` VALUES (0003, 'Sold');
INSERT INTO `book_status` VALUES (0004, 'Destroy');

-- ----------------------------
-- Table structure for borrow
-- ----------------------------
DROP TABLE IF EXISTS `borrow`;
CREATE TABLE `borrow`  (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `reader_id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `book_id` int UNSIGNED NOT NULL,
  `borrow_continue_times` int UNSIGNED NULL DEFAULT 0 COMMENT '续借次数',
  `lend_date` date NULL DEFAULT NULL COMMENT '借书日期',
  `expect_return_date` date NULL DEFAULT NULL COMMENT '应还日期',
  `delay_days` int NULL DEFAULT NULL COMMENT '超时天数',
  `delay_expense` decimal(8, 2) NULL DEFAULT NULL COMMENT '超时产生金额',
  `fine_expense` decimal(16, 2) NULL DEFAULT NULL COMMENT '罚款金额',
  `lend_operator_id` int UNSIGNED NULL DEFAULT NULL COMMENT '借书操作员',
  `return_operator_id` int NULL DEFAULT NULL COMMENT '还书操作员',
  PRIMARY KEY (`id`, `reader_id`, `book_id`) USING BTREE,
  INDEX `reader_id`(`reader_id`) USING BTREE,
  INDEX `book_id`(`book_id`) USING BTREE,
  CONSTRAINT `borrow_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `borrow_ibfk_2` FOREIGN KEY (`reader_id`) REFERENCES `aspnetusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of borrow
-- ----------------------------
INSERT INTO `borrow` VALUES (10, '9df4a6b6-1c10-4191-92aa-b1947f73dcae', 5, 0, '2020-12-27', '2021-03-27', 0, 0.00, NULL, 1, NULL);
INSERT INTO `borrow` VALUES (11, '9df4a6b6-1c10-4191-92aa-b1947f73dcae', 7, 0, '2020-12-27', '2021-01-27', 0, 0.00, NULL, 1, NULL);

-- ----------------------------
-- Table structure for reader
-- ----------------------------
DROP TABLE IF EXISTS `reader`;
CREATE TABLE `reader`  (
  `reader_id` int(8) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT COMMENT '读者ID',
  `reader_name` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '读者姓名',
  `reader_password` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL COMMENT '密码',
  `reader_type_id` smallint(4) UNSIGNED ZEROFILL NULL DEFAULT NULL COMMENT '读者类别',
  `reader_roles_id` smallint(4) UNSIGNED ZEROFILL NOT NULL DEFAULT 0000 COMMENT '角色权限',
  `reader_status_id` smallint(4) UNSIGNED ZEROFILL NULL DEFAULT NULL COMMENT '读者状态',
  `reader_borrow_quantity` int UNSIGNED NULL DEFAULT 0 COMMENT '借阅数量',
  `reader_gender_id` smallint(4) UNSIGNED ZEROFILL NULL DEFAULT NULL COMMENT '性别',
  `reader_phonenumber` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '电话号码',
  `reader_email` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '电子邮件',
  `reader_department` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '单位',
  `reader_register_date` date NULL DEFAULT NULL COMMENT '注册日期',
  `reader_photo` varchar(64) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NULL DEFAULT NULL COMMENT '读者照片',
  PRIMARY KEY (`reader_id`) USING BTREE,
  INDEX `reader_type_id`(`reader_type_id`) USING BTREE,
  INDEX `reader_roles_id`(`reader_roles_id`) USING BTREE,
  INDEX `reader_status_id`(`reader_status_id`) USING BTREE,
  INDEX `reader_gender_id`(`reader_gender_id`) USING BTREE,
  CONSTRAINT `reader_gender_id` FOREIGN KEY (`reader_gender_id`) REFERENCES `reader_gender` (`gender_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `reader_roles_id` FOREIGN KEY (`reader_roles_id`) REFERENCES `reader_role` (`role_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `reader_status_id` FOREIGN KEY (`reader_status_id`) REFERENCES `reader_status` (`status_id_r`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `reader_type_id` FOREIGN KEY (`reader_type_id`) REFERENCES `reader_type` (`type_id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of reader
-- ----------------------------

-- ----------------------------
-- Table structure for user_gender
-- ----------------------------
DROP TABLE IF EXISTS `user_gender`;
CREATE TABLE `user_gender`  (
  `gender_id` smallint(4) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT,
  `gender_name` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  PRIMARY KEY (`gender_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_bin ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user_gender
-- ----------------------------
INSERT INTO `user_gender` VALUES (0001, 'Male');
INSERT INTO `user_gender` VALUES (0002, 'Female');
INSERT INTO `user_gender` VALUES (0003, 'Inconvenience to disclose');
INSERT INTO `user_gender` VALUES (0004, 'Attack helicopter');

SET FOREIGN_KEY_CHECKS = 1;
