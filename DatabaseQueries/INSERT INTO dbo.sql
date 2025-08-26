Insert Into PracticeGroup(GROUPNAME)
VALUES('MsbPro 1')

INSERT INTO dbo.Patient
(
    GID, PATID, FirstName, LastName, DateOfBirth, Gender,
    PhoneNumber, Email, Address, City, State, PostalCode, Country,
    BloodType, Allergies, MedicalHistory, CreatedAt, UpdatedAt
)
VALUES
(1, 1001, 'John', 'Doe', '1985-05-15', 'Male',
 '01712345678', 'john.doe@example.com', '123 Main St', 'Dhaka', 'Dhaka', '1207', 'Bangladesh',
 'O+', 'Peanuts', 'Diabetes Type 2', GETDATE(), GETDATE()),

(1, 1002, 'Jane', 'Smith', '1990-09-25', 'Female',
 '01898765432', 'jane.smith@example.com', '45 Park Avenue', 'Chattogram', 'Chattogram', '4000', 'Bangladesh',
 'A-', NULL, 'Asthma', GETDATE(), GETDATE()),

(2, 2001, 'Rahim', 'Khan', '1978-12-10', 'Male',
 '01911223344', 'rahim.khan@example.com', '77 Bazar Road', 'Sylhet', 'Sylhet', '3100', 'Bangladesh',
 'B+', 'Dust', 'Hypertension', GETDATE(), GETDATE()),

(2, 2002, 'Ayesha', 'Begum', '2001-03-05', 'Female',
 '01699887766', 'ayesha.begum@example.com', 'House #22, Lane #4', 'Rajshahi', 'Rajshahi', '6000', 'Bangladesh',
 'AB+', NULL, NULL, GETDATE(), GETDATE());


INSERT INTO dbo.TKey
(
    GID,
    TNAME,
    LASTID
)
VALUES
(
    1,
    'Patient',
    1003
),
(
    2,
    'Patient',
    2003
),
(
    1,
    'User',
    1002
)