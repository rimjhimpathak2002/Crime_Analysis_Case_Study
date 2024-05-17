-- create CARS database
create database CARS
drop database CARS;
use SISDB;

-- Create table for Incidents
CREATE TABLE Incidents (
    IncidentID INT PRIMARY KEY Identity(1,1),
    IncidentType VARCHAR(50) not null check(IncidentType in( 'Robbery', 'Homicide', 'Theft')),
    IncidentDate DATE not null,
    Location varchar(50),
    Description TEXT not null,
    Status VARCHAR(20) not null check(Status in('Open', 'Closed', 'Under Investigation')),
    VictimID INT not null,
    SuspectID INT not null,
    FOREIGN KEY (VictimID) REFERENCES Victims(VictimID),
    FOREIGN KEY (SuspectID) REFERENCES Suspects(SuspectID)
);

select * from Incidents

-- Create table for Victims
CREATE TABLE Victims (
    VictimID INT PRIMARY KEY Identity(100,1),
    FirstName VARCHAR(50) not null,
    LastName VARCHAR(50) not null,
    DateOfBirth DATE not null,
    Gender VARCHAR(10) not null,
    ContactInformation TEXT not null
);

-- Create table for Suspects
CREATE TABLE Suspects (
    SuspectID INT PRIMARY KEY Identity(10,1),
    FirstName VARCHAR(50) not null,
    LastName VARCHAR(50) not null,
    DateOfBirth DATE not null,
    Gender VARCHAR(10) not null,
    ContactInformation TEXT not null
);

-- Create table for Law Enforcement Agencies
CREATE TABLE LawEnforcementAgencies (
    AgencyID INT PRIMARY KEY Identity(1,1),
    AgencyName VARCHAR(100) not null,
    Jurisdiction VARCHAR(100) not null,
    ContactInformation TEXT not null,
    OfficerID INT not null,
);


-- Create table for Officers
CREATE TABLE Officers (
    OfficerID INT PRIMARY KEY Identity(100,1),
    FirstName VARCHAR(50) not null,
    LastName VARCHAR(50) not null,
    BadgeNumber VARCHAR(20) not null,
    Rank VARCHAR(50) not null,
    ContactInformation TEXT not null,
    AgencyID INT not null,
    FOREIGN KEY (AgencyID) REFERENCES LawEnforcementAgencies(AgencyID)
);

ALTER TABLE LawEnforcementAgencies
ADD CONSTRAINT fk_officer
FOREIGN KEY (OfficerID) REFERENCES Officers(OfficerID);

alter table LawEnforcementAgencies
drop constraint fk_officer

-- Create table for Evidence
CREATE TABLE Evidence (
    EvidenceID INT PRIMARY KEY Identity(200,1),
    Description TEXT not null,
    LocationFound VARCHAR(100) not null,
    IncidentID INT not null,
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID)
);

-- Create table for Reports
CREATE TABLE Reports (
    ReportID INT PRIMARY KEY Identity(24,1),
    IncidentID INT not null,
    ReportingOfficer INT not null,
    ReportDate DATE not null,
    ReportDetails TEXT not null,
    Status VARCHAR(20) not null check(Status in('Draft','Finalized')),
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID),
    FOREIGN KEY (ReportingOfficer) REFERENCES Officers(OfficerID)
);

select * from Reports

--Insert into Incidents 
-- Incident 1
INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES ('Robbery', '2024-04-30','Main Market', 'Convenience store robbery at gunpoint', 'Open', 100, 10);  

-- Incident 2
INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES ('Theft', '2024-05-01','Street 34', 'Car break-in, laptop stolen', 'Open', 101, 11);  

-- Incident 3
INSERT INTO Incidents (IncidentType, IncidentDate,Location , Description, Status, VictimID, SuspectID)
VALUES ('Homicide', '2024-05-02','Stree 562' , 'Domestic violence incident', 'Under Investigation', 102, 12);  

-- Incidents 4-10 
INSERT INTO Incidents (IncidentType, IncidentDate,Location, Description, Status, VictimID, SuspectID)
VALUES ('Robbery', '2024-05-03', 'Street 563, main market', 'Bank robbery', 'Open', 103, 13);

INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES ('Theft', '2024-05-03','Barwani', 'Shoplifting at department store', 'Closed', 104, 14);

INSERT INTO Incidents (IncidentType, IncidentDate,Location, Description, Status, VictimID, SuspectID)
VALUES ('Homicide', '2024-05-02', 'Rajwada' , 'Gang-related shooting', 'Under Investigation', 105, 15);

INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES ('Robbery', '2024-05-04','Jodhpur', 'Jewelry store robbery', 'Open', 106, 16);

INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES ('Theft', '2024-05-04','Indore', 'Identity theft', 'Open', 107, 17);

INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES ('Homicide', '2024-05-03','Pune', 'Random act of violence', 'Under Investigation', 108, 18);


INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES ('Homicide', '2024-05-05','Barwani', 'Random act of violence', 'Under Investigation', 109, 19);

-- Insert into Victims
INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES
  ('Aisha', 'Kapoor', '1980-01-31', 'Female', '+1 (555) 555-5555'),
  ('Rohan', 'Singh', '1975-08-22', 'Male', '+1 (222) 222-2222'),
  ('Priya', 'Sharma', '1990-07-14', 'Female', '+1 (333) 333-3333'),
  ('Dev', 'Patel', '1985-02-10', 'Male', '+1 (444) 444-4444'),
  ('Vikram', 'Mehta', '1995-09-25', 'Male', '+1 (555) 555-5556'),
  ('Riya', 'Das', '1982-03-18', 'Female', '+1 (222) 222-2223'),
  ('Arjun', 'Bose', '1978-11-07', 'Male', '+1 (333) 333-3334'),
  ('Sonia', 'Gupta', '1992-04-12', 'Female', '+1 (444) 444-4445'),
  ('Rahul', 'Kumar', '1987-05-04', 'Male', '+1 (555) 555-5557'),
  ('Priyanka', 'Yadav', '1997-12-16', 'Female', '+1 (222) 222-2224');


--Insert into Suspects 
INSERT INTO Suspects (FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES
  ('Amit', 'Kumar', '1980-01-31', 'Male', '+1 (555) 555-5555'),
  ('Rani', 'Singh', '1975-08-22', 'Female', '+1 (222) 222-2222'),
  ('Vijay', 'Patel', '1990-07-14', 'Male', '+1 (333) 333-3333'),
  ('Pooja', 'Sharma', '1985-02-10', 'Female', '+1 (444) 444-4444'),
  ('Sunil', 'Das', '1995-09-25', 'Male', '+1 (555) 555-5556'),
  ('Neha', 'Gupta', '1982-03-18', 'Female', '+1 (222) 222-2223'),
  ('Rajesh', 'Bose', '1978-11-07', 'Male', '+1 (333) 333-3334'),
  ('Seema', 'Mehta', '1992-04-12', 'Female', '+1 (444) 444-4445'),
  ('Mohan', 'Yadav', '1987-05-04', 'Male', '+1 (555) 555-5557'),
  ('Kavita', 'Rao', '1997-12-16', 'Female', '+1 (222) 222-2224');


--Insert into LawEnforcementAgencies
INSERT INTO LawEnforcementAgencies (AgencyName, Jurisdiction, ContactInformation, OfficerID)
VALUES
  ('Mumbai Police Department', 'Mumbai, Maharashtra', '+91 (22) 2260 0100', 101),
  ('Delhi Police', 'Delhi', '+91 (11) 2301 7474', 102),
  ('Chennai Police', 'Chennai, Tamil Nadu', '+91 (44) 2850 0100', 103),
  ('Kolkata Police Force', 'Kolkata, West Bengal', '+91 (33) 2214 6600', 104),
  ('Bangalore Police', 'Bangalore, Karnataka', '+91 (80) 2224 1200', 105),
  ('Hyderabad Police', 'Hyderabad, Telangana', '+91 (40) 2343 0100', 106),
  ('Ahmedabad City Police', 'Ahmedabad, Gujarat', '+91 (79) 2656 7100', 107),
  ('Pune Police', 'Pune, Maharashtra', '+91 (20) 2560 1000', 108),
  ('Surat Municipal Corporation Police', 'Surat, Gujarat', '+91 (261) 226 8500', 109),
  ('Lucknow Police', 'Lucknow, Uttar Pradesh', '+91 (522) 243 7100', 100);

Truncate Table LawEnforcementAgencies

--Insert into Officers 
INSERT INTO Officers (FirstName, LastName, BadgeNumber, Rank, ContactInformation, AgencyID)
VALUES
  ('Akash', 'Verma', '12345', 'Inspector', '+91 (987) 654-3210', 1),  -- Mumbai Police Department
  ('Kiara', 'Kaur', '54321', 'Sub-Inspector', '+91 (876) 543-2109', 2),  -- Delhi Police
  ('Arjun', 'Rao', '78901', 'Constable', '+91 (789) 012-3456',3),  -- Chennai Police
  ('Priya', 'Das', '21098', 'Sergeant', '+91 (678) 901-2345', 4),  -- Kolkata Police Force
  ('Vikram', 'Singh', '34567', 'Detective', '+91 (987) 654-1230', 5),  -- Bangalore Police
  ('Riya', 'Mehta', '89012', 'Corporal', '+91 (876) 543-0987', 6),  -- Hyderabad Police
  ('Rohan', 'Shah', '67890', 'Lieutenant', '+91 (789) 012-5678', 7),  -- Ahmedabad City Police
  ('Sonia', 'Gupta', '10987', 'Captain', '+91 (678) 901-5678', 8),  -- Pune Police
  ('Rahul', 'Kumar', '43210', 'Sergeant', '+91 (987) 654-7890', 9),  -- Surat Municipal Corporation Police
  ('Aisha', 'Yadav', '98765', 'Constable', '+91 (876) 543-4567', 10);  -- Lucknow Police


--Insert into Evidence 
INSERT INTO Evidence (Description, LocationFound, IncidentID)
VALUES
  ('Fingerprint lifted from the crime scene', 'Victim apartment', 1),
  ('Murder weapon (knife) recovered near the victim', 'Alleyway behind the crime scene', 2),
  ('Security camera footage from a nearby store', 'Convenience store on Main Street', 3),
  ('Witness testimony', 'Witness house', 4),
  ('Blood sample collected from the suspect', 'Suspect vehicle', 5),
  ('Tire tracks found at the scene', 'Dirt road near the abandoned warehouse', 6),
  ('Ballistic evidence (bullet casings)', 'Forensics lab', 7),
  ('DNA sample from the crime scene', 'Crime scene investigation', 8),
  ('Cell phone records of the victim and suspect', 'Victim phone', 9),
  ('Recovered stolen goods', 'Suspect residence', 10);

--Insert into Reports 
INSERT INTO Reports (IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status)
VALUES
  (1, 100, '2024-05-03', 'Initial report of a homicide at the victims apartment. Fingerprint evidence collected.', 'Draft'),
  (2, 101, '2024-05-03', 'Follow-up investigation at the crime scene. Murder weapon recovered.', 'Draft'),
  (3, 102, '2024-05-03', 'Witness interview conducted. Witness provided description of the suspect.', 'Draft'),
  (4, 103, '2024-05-04', 'Security camera footage obtained from nearby store. Suspect identified.', 'Draft'),
  (5, 104, '2024-05-04', 'Suspect apprehended. Blood sample collected for analysis.', 'Draft'),
  (1, 105, '2024-05-04', 'Completed forensics report. Fingerprint evidence matches suspect.', 'Finalized'),  -- Update Incident 1 with finalized report
  (2, 106, '2024-05-04', 'Ballistic analysis indicates recovered casings match suspects weapon.', 'Finalized'),  -- Update Incident 2 with finalized report
  (8, 107, '2024-05-04', 'DNA analysis in progress. Awaiting results.', 'Draft'),
  (9, 108, '2024-04-30', 'Cell phone records under investigation. Potential link between victim and suspect.', 'Draft'),
  (10,109, '2024-05-02', 'Recovered stolen goods identified. Further investigation ongoing.', 'Draft');



-- Create a case table 
CREATE TABLE Cases (
    CaseID INT PRIMARY KEY IDENTITY(1,1),
    CaseNumber VARCHAR(20) NOT NULL,
    CaseDescription TEXT,
    CaseStatus VARCHAR(20) NOT NULL CHECK (CaseStatus IN ('Open', 'Closed', 'Under Investigation')),
    IncidentID INT NOT NULL,
    OfficerID INT NOT NULL,
    CONSTRAINT FK_Incident_Case FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID),
    CONSTRAINT FK_Officer_Case FOREIGN KEY (OfficerID) REFERENCES Officers(OfficerID)
); 

INSERT INTO Cases (CaseNumber, CaseDescription, CaseStatus, IncidentID, OfficerID)
VALUES 
    ('CASE001', 'Robbery at convenience store', 'Open', 1, 100),
    ('CASE002', 'Car break-in, laptop stolen', 'Closed', 2, 101),
    ('CASE003', 'Domestic violence incident', 'Under Investigation', 3, 102),
    ('CASE004', 'Bank robbery', 'Open', 4, 103),
    ('CASE005', 'Shoplifting at department store', 'Closed', 5, 104),
    ('CASE006', 'Gang-related shooting', 'Under Investigation', 6, 105),
    ('CASE007', 'Jewelry store robbery', 'Open', 7, 106),
    ('CASE008', 'Identity theft', 'Open', 8, 107),
    ('CASE009', 'Random act of violence', 'Under Investigation', 9, 108),
    ('CASE010', 'Random act of violence', 'Under Investigation', 10, 109);


ALTER TABLE Incidents
ADD CONSTRAINT fk_caseID
FOREIGN KEY (CaseID) REFERENCES Cases(CaseID);

alter table Incidents
add CaseID INT default 1 

ALTER TABLE Incidents 
ADD CONSTRAINT fk_CaseID
FOREIGN KEY (CaseID) REFERENCES Cases(CaseID);

ALTER TABLE Incidents
DROP COLUMN CaseID;

alter table Incidents
drop constraint fk_caseID


alter table Cases
drop constraint fk_Incident_Case

select Incidents.IncidentID, IncidentType, IncidentDate, Description, Incidents.Status, ReportingOfficer, FirstName, LastName from Incidents join Reports on Incidents.IncidentID = Reports.IncidentID join Officers on Reports.ReportingOfficer = Officers.OfficerID

select * from Victims 
select * from Suspects 
select * from Incidents
select * from LawEnforcementAgencies 
select * from Officers 
select * from Evidence 
select * from Reports 
select * from Cases   