create database practice_1
use practice_1




CREATE TABLE Doctor (
    doctor_id VARCHAR(6) PRIMARY KEY,
    dr_first_name VARCHAR(15),
    dr_middle_name VARCHAR(15),
    dr_last_name VARCHAR(15)
);

-- Create Patient table (parent table for Appointment)
CREATE TABLE Patient (
    patient_id VARCHAR(6) PRIMARY KEY,
    p_first_name VARCHAR(15),
    p_middle_name VARCHAR(15),
    p_last_name VARCHAR(15),
    address VARCHAR(20),
    city VARCHAR(15),
    contact_number VARCHAR(10),
    p_app INT
);

-- Create Appointment table (references Doctor and Patient)
CREATE TABLE Appointment (
    app_number VARCHAR(6) PRIMARY KEY,
    app_date DATE,
    app_time VARCHAR(8),
    app_reason VARCHAR(20),
    doctor_id VARCHAR(6),
    patient_id VARCHAR(6),
    FOREIGN KEY (doctor_id) REFERENCES Doctor(doctor_id),
    FOREIGN KEY (patient_id) REFERENCES Patient(patient_id)
);

-- Create BIII table (references Appointment)
CREATE TABLE BIII (
    bil_number VARCHAR(6) PRIMARY KEY,
    bil_date DATE,
    bil_status VARCHAR(50),
    bil_amount DECIMAL(7, 2),
    app_number VARCHAR(6),
    FOREIGN KEY (app_number) REFERENCES Appointment(app_number)
);

-- Create Payment table (references BIII)
CREATE TABLE Payment (
    payment_id VARCHAR(6) PRIMARY KEY,
    pay_date DATE,
    Pay_node VARCHAR(30),
    pay_amount DECIMAL(7, 2),
    bil_number VARCHAR(6),
    FOREIGN KEY (bil_number) REFERENCES BIII(bil_number)
);

-- Insert sample data into Doctor table
INSERT INTO Doctor (doctor_id, dr_first_name, dr_middle_name, dr_last_name) VALUES
('DOC001', 'John', 'A.', 'Smith'),
('DOC002', 'Sarah', 'M.', 'Johnson'),
('DOC003', 'Michael', NULL, 'Williams'),
('DOC004', 'Emily', 'R.', 'Brown'),
('DOC005', 'David', 'K.', 'Jones'),
('DOC006', 'Jennifer', NULL, 'Garcia'),
('DOC007', 'Robert', 'T.', 'Miller'),
('DOC008', 'Lisa', 'P.', 'Davis'),
('DOC009', 'Thomas', 'E.', 'Rodriguez'),
('DOC010', 'Nancy', NULL, 'Martinez');

-- Insert sample data into Patient table
INSERT INTO Patient (patient_id, p_first_name, p_middle_name, p_last_name, address, city, contact_number, p_app) VALUES
('PAT001', 'James', 'B.', 'Wilson', '123 Main St', 'Boston', '6175550101', 3),
('PAT002', 'Mary', 'L.', 'Taylor', '456 Oak Ave', 'New York', '2125550202', 5),
('PAT003', 'William', NULL, 'Anderson', '789 Pine Rd', 'Chicago', '3125550303', 2),
('PAT004', 'Patricia', 'S.', 'Thomas', '321 Elm St', 'Houston', '7135550404', 1),
('PAT005', 'Richard', 'D.', 'Jackson', '654 Maple Dr', 'Phoenix', '6025550505', 4),
('PAT006', 'Jennifer', NULL, 'White', '987 Cedar Ln', 'Philadelphia', '2155550606', 3),
('PAT007', 'Charles', 'F.', 'Harris', '147 Birch Ct', 'San Antonio', '2105550707', 2),
('PAT008', 'Linda', 'G.', 'Martin', '258 Walnut Way', 'San Diego', '6195550808', 5),
('PAT009', 'Joseph', NULL, 'Thompson', '369 Spruce Pl', 'Dallas', '2145550909', 1),
('PAT010', 'Susan', 'H.', 'Robinson', '741 Aspen Blvd', 'San Jose', '4085551010', 4);

-- Insert sample data into Appointment table
INSERT INTO Appointment (app_number, app_date, app_time, app_reason, doctor_id, patient_id) VALUES
('APP001', '2023-01-10', '09:00 AM', 'Annual Checkup', 'DOC001', 'PAT001'),
('APP002', '2023-01-11', '10:30 AM', 'Flu Symptoms', 'DOC002', 'PAT002'),
('APP003', '2023-01-12', '02:15 PM', 'Back Pain', 'DOC003', 'PAT003'),
('APP004', '2023-01-13', '11:00 AM', 'Vaccination', 'DOC004', 'PAT004'),
('APP005', '2023-01-14', '03:45 PM', 'Allergy Consult', 'DOC005', 'PAT005'),
('APP006', '2023-01-15', '08:30 AM', 'Follow-up', 'DOC006', 'PAT006'),
('APP007', '2023-01-16', '01:00 PM', 'Skin Rash', 'DOC007', 'PAT007'),
('APP008', '2023-01-17', '04:30 PM', 'Blood Test', 'DOC008', 'PAT008'),
('APP009', '2023-01-18', '09:45 AM', 'Physical Exam', 'DOC009', 'PAT009'),
('APP010', '2023-01-19', '10:15 AM', 'Headache', 'DOC010', 'PAT010');

-- Insert sample data into BIII table
INSERT INTO BIII (bil_number, bil_date, bil_status, bil_amount, app_number) VALUES
('BIL001', '2023-01-10', 'Paid', 150.00, 'APP001'),
('BIL002', '2023-01-11', 'Pending', 200.00, 'APP002'),
('BIL003', '2023-01-12', 'Paid', 175.50, 'APP003'),
('BIL004', '2023-01-13', 'Pending', 120.00, 'APP004'),
('BIL005', '2023-01-14', 'Paid', 90.75, 'APP005'),
('BIL006', '2023-01-15', 'Pending', 250.00, 'APP006'),
('BIL007', '2023-01-16', 'Paid', 180.25, 'APP007'),
('BIL008', '2023-01-17', 'Pending', 300.00, 'APP008'),
('BIL009', '2023-01-18', 'Paid', 150.00, 'APP009'),
('BIL010', '2023-01-19', 'Pending', 125.50, 'APP010');

-- Insert sample data into Payment table
INSERT INTO Payment (payment_id, pay_date, Pay_node, pay_amount, bil_number) VALUES
('PAY001', '2023-01-10', 'Credit Card', 150.00, 'BIL001'),
('PAY002', '2023-01-12', 'Cash', 175.50, 'BIL003'),
('PAY003', '2023-01-14', 'Insurance', 90.75, 'BIL005'),
('PAY004', '2023-01-16', 'Credit Card', 180.25, 'BIL007'),
('PAY005', '2023-01-18', 'Check', 150.00, 'BIL009'),
('PAY006', '2023-01-20', 'Credit Card', 100.00, 'BIL002'),
('PAY007', '2023-01-21', 'Cash', 120.00, 'BIL004'),
('PAY008', '2023-01-22', 'Insurance', 125.00, 'BIL006'),
('PAY009', '2023-01-23', 'Credit Card', 200.00, 'BIL008'),
('PAY010', '2023-01-24', 'Check', 125.50, 'BIL010');

select * from Payment
select * from Doctor 
select * from Patient 
select * from Appointment
select * from BIII

--1.  Find all patients who live in either 'Boston', 'New York', or 'Chicago'.
select * from Patient where city = 'boston' or city=  'New York' or city = 'Chicago';

--2. List all doctors who are NOT assigned to any appointments (their doctor_id doesn't appear in the Appointment table).
select dr_first_name from Doctor  where doctor_id not in ( select doctor_id from Appointment group by doctor_id)

--3.  Find all patients who don't have a middle name (where p_middle_name is NULL).
select p.patient_id,p.P_first_name  from Patient p where p.p_middle_name is null

--4.  Display all bills that have a status assigned (bil_status is not NULL).
select * from BIII where bil_status is not null

--5.  Show all appointments and replace NULL doctor_id with 'UNASSIGNED'.
select * , isnull(doctor_id,'unassigned') as replace_id from Appointment

--6. Find all payments made between January 12, 2023 and January 18, 2023.
select * from payment where pay_date between '2023-01-12' and '2023-01-18' group by pay_date ,payment_id,Pay_node,pay_amount,bil_number

--7.  List all unique cities where patients live (without duplicates).
select city from patient group by city having count(city) = 1;

--8.  Combine the list of all doctor last names with all patient last names into a single result.
select dr_last_name  from Doctor union all select p_last_name  from Patient 

--9.  (using INNER JOIN): Find patients who have both appointments and bills (patient_id exists in both Patient and BIII tables via Appointment).
 select  p.patient_id from patient p  join Appointment a  on  a.patient_id = p.patient_id
 join BIII b on a.app_number = b.app_number group by p.patient_id;

 --10.  List doctors who have no appointments (doctors that exist in Doctor table but not in Appointment table).
 select d.doctor_id from Doctor d where d.doctor_id not in (select a.doctor_id from Appointment a);

 --1.  Display all appointments with the full names of both the doctor and patient (combine first, middle, and last names).
 select concat(dr_first_name,'', dr_middle_name,'', dr_last_name) as doctor_detail ,concat(p_first_name,'',p_middle_name,'',p_last_name) as pat_details,
 a.app_number,a.app_date  from doctor d
 join Appointment a on a.doctor_id = d.doctor_id
 join Patient p on  p.patient_id = a.patient_id;

 --2. List all bills with their corresponding payment details (if any), showing bil_number, bil_amount, payment_id, and pay_amount.
 select p.payment_id,p.pay_amount,b.bil_number,b.bil_amount from payment p  join BIII b  on b. bil_number = p.bil_number

 --3. Show all patients and their appointments (if any), including patients who haven't had any appointments.
 select p.patient_id,p.p_first_name,p.p_last_name,a.app_number,a.app_date,a.app_time from Patient p left join Appointment a on  a.patient_id = p.patient_id;

 --4.  Find pairs of doctors who share the same last name (excluding pairs where doctor_id is the same).
 select d1.doctor_id as d1_id,
 d1.dr_first_name as d1_f,
 d1.dr_middle_name as d1_m,
 d2.doctor_id as d2_id,
 d2.dr_first_name as d2_f ,
 d2.dr_middle_name as d2_m from Doctor d1
 join doctor d2 on d1.dr_last_name = d2.dr_last_name
 where d1.doctor_id != d2.doctor_id 

 --5. Display the total amount paid by each patient (sum of all payments through their bills), along with patient names.
 select p_first_name,sum(pa.pay_amount) as total_amt_paid from Patient p
 join Appointment a on p.patient_id = a.patient_id
 join BIII b on b.app_number = a.app_number
 join Payment pa  on pa.bil_number = b.bil_number
 group by p_first_name


--## Subquery Questions
 
--6. Find all doctors who have more than 3 appointments.
select * from Doctor d where d.doctor_id in (select a.doctor_id from Appointment a Group by a.doctor_id having count(app_number)>3);

--7.  List patients who have at least one bill with an amount greater than the average bill amount.
 select p.p_first_name ,p.p_last_name,p.p_middle_name,avg(b.bil_amount) as avg_bil_amt 
 from Patient p  
 where p.patient_id in(select a.patient_id from Appointment a where a.app_number in(select b.app_number from BIII b group by b.app_number having b.bil_amount > (select AVG(bil_amount) from BIII  )));

 --8.  Display all bills that don't have any associated payments.
 select * from BIII b where b.bil_number not in (select p.bil_number from Payment p )

 --9.  Find all appointments for patients who live in cities where mrore than one patient resides.
 select a.app_number,a.app_date,a.app_time from Appointment a
 where a.patient_id in (select p.patient_id from Patient p group by p.patient_id having count(city)>1);

 --10. Show the doctor(s) with the highest number of appointments.
 select * from Doctor d where d.doctor_id in (select a.doctor_id from Appointment a group by a.doctor_id having count(a.app_number) = (select max(count(a.app_number)) as high_num))



