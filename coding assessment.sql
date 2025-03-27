create database coding_test_1
use coding_test_1


CREATE TABLE Crime (
CrimeID INT PRIMARY KEY,
IncidentType VARCHAR(255),
IncidentDate DATE,
age int,
Location VARCHAR(255),
Description TEXT,
Status VARCHAR(20)
);

CREATE TABLE Victim (
VictimID INT PRIMARY KEY,
CrimeID INT,
v_age int,
Name VARCHAR(255),
ContactInfo VARCHAR(255),
Injuries VARCHAR(255),
FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);

CREATE TABLE Suspect (
SuspectID INT PRIMARY KEY,
CrimeID INT,
s_age int,
Name VARCHAR(255),
Description TEXT,
CriminalHistory TEXT,
FOREIGN KEY (CrimeID) REFERENCES Crime(CrimeID)
);

INSERT INTO Crime (CrimeID, IncidentType, IncidentDate,age, Location, Description, Status)
VALUES
(1, 'Robbery', '2023-09-15', 31,'123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'),
(2, 'Homicide', '2023-09-20',32, '456 Elm St, Townsville', 'Investigation into a murder case', 'UnderInvestigation'),
(3, 'Theft', '2023-09-10', 33,'789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed'),
(4,'assault','2024-10-18',34,'145 gandhi st,cdm','chain_snatch at road','open'),
(5,'harasment','2023-06-21',35,'541 jam st,gujarat','harasment in public','closed'),
(6,'murder','2023-10-24',36,'132 eliot st,assam','murder in house','open'),
(7,'bully','2025-12-24',37,'154 basin st,delhi','bully girls','closed'),
(8,'intrusion','2023-06-05',38,'134 rahul st,chennai','intrusion  of house','open'),
(9,'phone snatch','2022-04-14',39,'122 ash st,chepauk','phone snatch at railway station','open'),
(10,'double_murder','2021-03-13',40,'189 me st,tambaram','double_murder in cross road','closed');


INSERT INTO Victim (VictimID, CrimeID,v_age, Name, ContactInfo, Injuries)
VALUES
(1, 1, 41,'John Doe', 'johndoe@example.com', 'Minor injuries'),
(2, 2, 42,'Jane Smith', 'janesmith@example.com', 'Deceased'),
(3, 3, 43,'Alice Johnson', 'alicejohnson@example.com', 'None'),
(4,4,44,'ken thomson','ken@mail.com','deceased'),
(5,5,45,'bob','bob@mail.com','none'),
(6,6,46,'alice','alice@mail.com','minor injuries'),
(7,7,47,'sam','sam@mail.com','deceased'),
(8,8,48,'kumar','k@mail.com','none'),
(9,9,49,'siv','s@mail.com','none'),
(10,10,50,'nim','n@mail.com','minor injuries');


INSERT INTO Suspect (SuspectID, CrimeID,s_age, Name, Description, CriminalHistory)
VALUES
(1, 1,21, 'Robber 1', 'Armed and masked robber', 'Previous robbery convictions'),
(2, 2, 22,'Unknown', 'Investigation ongoing', NULL),
(3, 3, 23,'Suspect 1', 'Shoplifting suspect', 'Prior shoplifting arrests'),
(4,4,24,'suspect 2','assault suspect','prior assault arrests'),
(5,5,25,'harraster','harasment suspect',null),
(6,6,26,'murderer','murder suspect','prior murder arrests'),
(7,7,27,'bullier','bully_suspect','prior bully records'),
(8,8,28,'intruder','intrusion_suspect',null),
(9,9,29,'phone snatcher','snatch_suspect','prior snatch records'),
(10,10,30,'double murderer','double murder suspect','prior murder records');



--1. Select all open incidents.
select * from crime where status = 'open'

--2. Find the total number of incidents.
select count(IncidentType) as total_number_incident from Crime

--3. List all unique incident types.
select distinct IncidentType from Crime

--4. Retrieve incidents that occurred between '2023-09-01' and '2023-09-10'.
select * from crime where IncidentDate between '2023-09-01' and '2023-09-10'

--5. List persons involved in incidents in descending order of age.
select s_age from Suspect order by s_age desc;

--6. Find the average age of persons involved in incidents.
select avg(s_age) as average_age from Suspect ;

--7. List incident types and their counts, only for open cases.
select IncidentType,count(IncidentType) as INCIDENT_count from Crime  group by IncidentType,status having status = 'open'

--8. Find persons with names containing 'Doe'.
select* from Victim  group by name,VictimID,CrimeID,ContactInfo,Injuries,v_age having name like '%doe'

--9. Retrieve the names of persons involved in open cases and closed cases.
select s.Name from Suspect s join crime c on c.CrimeID = s.CrimeID where status = 'open' or  status = 'closed'

--10. List incident types where there are persons aged 30 or 35 involved.
select c.incidenttype from crime c join Suspect s on c.CrimeID = s.CrimeID where s_age = '30' or c.CrimeID = '35';

--11. Find persons involved in incidents of the same type as 'Robbery'.
select s.name from Suspect s join crime c on c.CrimeID = s.CrimeID where IncidentType = 'Robbery'

--12. List incident types with more than one open case.
select c.incidenttype from crime c  where c.status in (select c.open_case as oc_count count(status)>1 from crime c

--13. List all incidents with suspects whose names also appear as victims in other incidents.
select c.incidenttype,c.crimeid,s.name from Crime c 
join Suspect s on c.CrimeID = s.CrimeID 
join victim v on  v.CrimeID = c.CrimeID where s.Name = v.Name

--14. Retrieve all incidents along with victim and suspect details.
select c.incidenttype,c.incidentdate,v.victimID,v.crimeId,v.name ,s.suspectID,s.crimeID,s.name from crime c 
join Victim v on v.crimeId = c.CrimeID
join  Suspect s on s.CrimeID = v.CrimeID

 --15. Find incidents where the suspect is older than any victim.
 select c.incidenttype from crime c join Suspect s on c.crimeid = s.crimeid 
 join victim v on v.CrimeID = s.CrimeID  group by s_age,v_age,c.IncidentType having s_age > v_age ;

 --16. Find suspects involved in multiple incidents:
 select s.name from Suspect s join crime c on c.CrimeID = s.crimeid  group by s.Name having count(c.CrimeID)>1;

 --17. List incidents with no suspects involved.
 select c.incidenttype from crime c join Suspect s on c.CrimeID = s.CrimeID  group by c.IncidentType,s.Name having s.Name is null

 --18. List all cases where at least one incident is of type 'Homicide' and all other incidents are of type 'Robbery'.
 select c.crimeId from crime c where c.IncidentType = 'robbery'  where  c.IncidentType ='homicide' having (select count(c.IncidentType) >= 1 )
 .
 --19. Retrieve a list of all incidents and the associated suspects, showing suspects for each incident, or 'No Suspect' if there are none.
 select c.crimeid ,c.incidenttype ,s.name as suspect from Crime c 
 join Suspect s on s.crimeid = c.CrimeID where isnull('null',no_suspect);
 
 --20. List all suspects who have been involved in incidents with incident types 'Robbery' or 'Assault'
 select s.suspectid,s.crimeid,s.name,c.incidenttype from Suspect s 
 join crime c on c.CrimeID = s.CrimeID where c.IncidentType = 'robbery' or c.IncidentType = 'assault'



