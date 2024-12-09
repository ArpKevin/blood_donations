CREATE TABLE `donors` (
  `DonorID` integer PRIMARY KEY,
  `ID_card` varchar(255),
  `Name` varchar(255),
  `Age` integer,
  `BloodTypeID` integer,
  `Gender` boolean,
  `Registration_date` date,
  `Is_eligible` boolean,
  `Disqualifying_factors` varchar(255)
);

CREATE TABLE `blood_stations` (
  `StationID` integer PRIMARY KEY,
  `StationName` varchar(255),
  `Address` varchar(255),
  `Phone_no` varchar(255)
);

CREATE TABLE `donations` (
  `DonationID` integer PRIMARY KEY,
  `DonorID` integer,
  `StationID` integer,
  `DonationDate` date,
  `AmountDonated` integer
);

CREATE TABLE `blood_types` (
  `BloodTypeID` integer PRIMARY KEY,
  `BloodTypeName` varchar(255)
);

ALTER TABLE `donations` ADD FOREIGN KEY (`DonorID`) REFERENCES `donors` (`DonorID`);

ALTER TABLE `donations` ADD FOREIGN KEY (`StationID`) REFERENCES `blood_stations` (`StationID`);

ALTER TABLE `donors` ADD FOREIGN KEY (`BloodTypeID`) REFERENCES `blood_types` (`BloodTypeID`);
