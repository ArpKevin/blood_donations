-- Insert dummy data into `blood_types`
INSERT INTO `blood_types` (`BloodTypeID`, `BloodTypeName`) VALUES
(1, 'A+'),
(2, 'A-'),
(3, 'B+'),
(4, 'B-'),
(5, 'O+'),
(6, 'O-'),
(7, 'AB+'),
(8, 'AB-');

-- Insert dummy data into `blood_stations`
INSERT INTO `blood_stations` (`StationID`, `StationName`, `Address`, `Phone_no`) VALUES
(1, 'Central Blood Bank', '123 Blood St, City', '555-0001'),
(2, 'East Side Clinic', '456 Health Ave, City', '555-0002'),
(3, 'West Hospital Blood Bank', '789 West Rd, City', '555-0003'),
(4, 'North Clinic', '321 North St, City', '555-0004');

-- Insert dummy data into `donors`
INSERT INTO `donors` (`DonorID`, `ID_card`, `Name`, `Age`, `BloodTypeID`, `Gender`, `Registration_date`, `Is_eligible`, `Disqualifying_factors`) VALUES
(1, 'ID123', 'John Doe', 30, 1, TRUE, '2022-05-10', TRUE, NULL),
(2, 'ID124', 'Jane Smith', 25, 2, FALSE, '2021-11-15', TRUE, 'Diabetes'),
(3, 'ID125', 'Alice Johnson', 35, 3, TRUE, '2020-08-01', TRUE, NULL),
(4, 'ID126', 'Bob Brown', 40, 4, FALSE, '2023-03-10', TRUE, 'Pregnancy'),
(5, 'ID127', 'Charlie Davis', 50, 5, TRUE, '2019-07-20', FALSE, 'High Blood Pressure'),
(6, 'ID128', 'David Wilson', 60, 6, TRUE, '2020-12-25', TRUE, NULL),
(7, 'ID129', 'Eva Clark', 28, 7, FALSE, '2022-06-05', TRUE, NULL),
(8, 'ID130', 'Frank Moore', 45, 8, TRUE, '2021-04-10', TRUE, 'Chronic Illness');

-- Insert dummy data into `donations`
INSERT INTO `donations` (`DonationID`, `DonorID`, `StationID`, `DonationDate`, `AmountDonated`) VALUES
(1, 1, 1, '2022-05-10', 500),
(2, 2, 2, '2021-11-15', 450),
(3, 3, 3, '2020-08-01', 400),
(4, 4, 4, '2023-03-10', 350),
(5, 5, 1, '2019-07-20', 600),
(6, 6, 2, '2020-12-25', 450),
(7, 7, 3, '2022-06-05', 500),
(8, 8, 4, '2021-04-10', 400);