
CREATE DATABASE PostGradOffice;
go
use PostGradOffice;

CREATE TABLE PostGradUser(
id int primary key identity(1,1),
email varchar(50) not null,
password varchar(30) not null
)
CREATE TABLE Admin(
id int primary key foreign key references PostGradUser on delete cascade
on update cascade
)
CREATE TABLE GucianStudent(
id int primary key foreign key references PostGradUser on delete cascade
on update cascade,
firstName varchar(20),
lastName varchar(20),
type varchar(3),
faculty varchar(30),
address varchar(50),
GPA decimal(3,2),
undergradID int
)
CREATE TABLE NonGucianStudent(
id int primary key foreign key references PostGradUser on delete cascade
on update cascade,
firstName varchar(20),
lastName varchar(20),
type varchar(3),
faculty varchar(30),
address varchar(50),
GPA decimal(3,2),
)
CREATE TABLE GUCStudentPhoneNumber(
phone varchar(50),
id int,
primary key(id, phone),
foreign key(id) references GucianStudent on delete cascade
on update cascade
)

CREATE TABLE NonGUCStudentPhoneNumber(
phone varchar(50),
id int,
primary key(id, phone),
foreign key(id) references NonGucianStudent on delete
cascade on update cascade
)
CREATE TABLE Course(
id int primary key identity(1,1),
fees int,
creditHours int,
code varchar(10)
)
CREATE TABLE Supervisor(
id int primary key foreign key references PostGradUser,
name varchar(20),
faculty varchar(30)
);
CREATE TABLE Examiner(
id int primary key foreign key references PostGradUser on delete cascade
on update cascade,
name varchar(20),
fieldOfWork varchar(100),
isNational BIT
)
CREATE TABLE Payment(
id int primary key identity(1,1),
amount decimal(7,2),
noOfInstallments int,
fundPercentage decimal(4,2)
)
CREATE TABLE Thesis(
serialNumber int primary key identity(1,1),
field varchar(20),
type varchar(3) not null,
title varchar(100) not null,
startDate date not null,
endDate date not null,
defenseDate date,
years as (year(endDate)-year(startDate)),
grade decimal(4,2),
payment_id int foreign key references payment on delete cascade on update
cascade,
noOfExtensions int
)
CREATE TABLE Publication(
id int primary key identity(1,1),
title varchar(100) not null,
dateOfPublication date,
place varchar(100),
accepted BIT,
host varchar(100)
);
Create table Defense (serialNumber int,
date datetime,
location varchar(15),
grade decimal(4,2),
primary key (serialNumber, date),
foreign key (serialNumber) references Thesis on delete cascade on update
cascade)
Create table GUCianProgressReport (
sid int foreign key references GUCianStudent on delete cascade on update
cascade
, no int
, date datetime
, eval int
, state int
, description varchar(200)
, thesisSerialNumber int foreign key references Thesis on delete cascade
on update cascade
, supid int foreign key references Supervisor
, primary key (sid, no) )
Create table NonGUCianProgressReport (sid int foreign key references
NonGUCianStudent on delete
cascade on update cascade,
no int
, date datetime
, eval int
, state int
, description varchar(200)
, thesisSerialNumber int foreign key references Thesis on delete cascade
on update cascade
, supid int foreign key references Supervisor
, primary key (sid, no) )
Create table Installment (date datetime,
paymentId int foreign key references Payment on delete cascade on update
cascade
, amount decimal(8,2)
, done bit
, primary key (date, paymentId))
Create table NonGucianStudentPayForCourse(sid int foreign key references
NonGucianStudent on
delete cascade on update cascade,
paymentNo int foreign key references Payment on delete cascade on update
cascade,
cid int foreign key references Course on delete cascade on update cascade,
primary key (sid, paymentNo, cid))
Create table NonGucianStudentTakeCourse (sid int foreign key references
NonGUCianStudent on delete
cascade on update cascade
, cid int foreign key references Course on delete cascade on update
cascade
, grade decimal (4,2)
, primary key (sid, cid) )
Create table GUCianStudentRegisterThesis (sid int foreign key references
GUCianStudent on delete
cascade on update cascade,
supid int foreign key references Supervisor
, serial_no int foreign key references Thesis on delete cascade on update
cascade
, primary key(sid, supid, serial_no))
Create table NonGUCianStudentRegisterThesis (sid int foreign key
references NonGUCianStudent on
delete cascade on update cascade,
supid int foreign key references Supervisor,
serial_no int foreign key references Thesis on delete cascade on update
cascade ,
primary key (sid, supid, serial_no))
Create table ExaminerEvaluateDefense(date datetime,
serialNo int,
examinerId int foreign key references Examiner on delete cascade on update
cascade,
comment varchar(300),
primary key(date, serialNo, examinerId),
foreign key (serialNo, date) references Defense (serialNumber, date) on
delete cascade on update
cascade)
Create table ThesisHasPublication(serialNo int foreign key references
Thesis on delete cascade on
update cascade,
pubid int foreign key references Publication on delete cascade on update
cascade,
primary key(serialNo,pubid))
go
create proc studentRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@faculty varchar(20),
@Gucian bit,
@email varchar(50),
@address varchar(50)
as
begin
insert into PostGradUser(email,password)
values(@email,@password)
declare @id int
SELECT @id=SCOPE_IDENTITY()
if(@Gucian=1)
insert into GucianStudent(id,firstName,lastName,faculty,address)
values(@id,@first_name,@last_name,@faculty,@address)
else
insert into NonGucianStudent(id,firstName,lastName,faculty,address)
values(@id,@first_name,@last_name,@faculty,@address)
end
go
create proc supervisorRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@faculty varchar(20),
@email varchar(50)
as
begin
insert into PostGradUser(email,password)
values(@email,@password)
declare @id int
SELECT @id=SCOPE_IDENTITY()
declare @name varchar(50)
set @name = CONCAT(@first_name,@last_name)
insert into Supervisor(id,name,faculty) values(@id,@name,@faculty)
end
go


Create proc userLogin
@id int,
@password varchar(20),
@success bit output,
@type int output
as
begin
if exists(
select ID,password
from PostGradUser
where id=@id and password=@password)
begin
set @success =1
-- check user type 0-->Student,1-->Admin,2-->Supervisor ,3-->Examiner
if exists(select id from GucianStudent where id=@id union select id from
NonGucianStudent where id=@id )
set @type=0
if exists(select id from Admin where id=@id)
set @type=1
if exists(select id from Supervisor where id=@id)
set @type=2
if exists(select id from Examiner where id=@id)
set @type=3
end
else
set @success=0
end
go




create proc addMobile
@ID int,
@mobile_number varchar(20)
as
begin
if @ID is not null and @mobile_number is not null
begin
--check Gucian student or not
if(exists(select * from GucianStudent where id=@ID))
insert into GUCStudentPhoneNumber values(@mobile_number,@ID)
if(exists(select * from NonGucianStudent where id=@ID))
insert into NonGUCStudentPhoneNumber values(@mobile_number,@ID)
end
end
--checks if there is an ongoing thesis for the serial Num input
go


create procedure isThesisValid
@serialNum int
as
select * 
from Thesis
where serialNumber=@serialNum and endDate > Convert(Date,CURRENT_TIMESTAMP)
go
CREATE Proc AdminListSup
As
Select u.id,u.email,u.password,s.name, s.faculty
from PostGradUser u inner join Supervisor s on u.id = s.id
go



CREATE Proc AdminViewSupervisorProfile
@supId int  
As
Select u.id,u.email,u.password,s.name, s.faculty
from PostGradUser u inner join Supervisor s on u.id = s.id
WHERE @supId = s.id

go


CREATE Proc AdminViewAllTheses
As
Select
serialNumber,field,type,title,startDate,endDate,defenseDate,years,grade,payment_id,noOfExtensions
From Thesis


go


CREATE Proc AdminViewOnGoingTheses
@thesesCount int output
As
Select @thesesCount=Count(*)
From Thesis
where endDate > Convert(Date,CURRENT_TIMESTAMP)


go




CREATE Proc AdminViewStudentThesisBySupervisor
As
Select s.name,t.title,gs.firstName
From Thesis t inner join GUCianStudentRegisterThesis sr on t.serialNumber=sr.serial_no
inner join Supervisor s on s.id=sr.supid inner join GucianStudent gs on sr.sid=gs.id
where t.endDate > Convert(Date,CURRENT_TIMESTAMP)
union
Select s.name,t.title,gs.firstName
From Thesis t inner join NonGUCianStudentRegisterThesis sr on t.serialNumber=sr.serial_no
inner join Supervisor s on s.id=sr.supid inner join NonGucianStudent gs on sr.sid=gs.id
where t.endDate > Convert(Date,CURRENT_TIMESTAMP)





go

go


CREATE Proc AdminListNonGucianCourse
@courseID int
As
if(exists(select * from Course where id=@courseID))
Select ng.firstName,ng.lastName,c.code,n.grade
From NonGucianStudentTakeCourse n inner join Course c on n.cid=c.id inner join NonGucianStudent ng
on ng.id=n.sid
where n.cid=@courseID


go


CREATE Proc AdminUpdateExtension
@ThesisSerialNo int
As
if(exists(select * from Thesis where serialNumber=@ThesisSerialNo))
begin
declare @noOfExtensions int
select @noOfExtensions=noOfExtensions from Thesis where serialNumber=@ThesisSerialNo
update Thesis
set noOfExtensions=@noOfExtensions+1
where serialNumber=@ThesisSerialNo
end


go


CREATE Proc AdminIssueThesisPayment
@ThesisSerialNo int,
@amount decimal,
@noOfInstallments int,
@fundPercentage decimal
As
if(exists(select * from Thesis where serialNumber=@ThesisSerialNo))
begin
insert into Payment(amount,noOfInstallments,fundPercentage)
values(@amount,@noOfInstallments,@fundPercentage)
declare @id int
SELECT @id=SCOPE_IDENTITY()
update Thesis
set payment_id=@id
where serialNumber=@ThesisSerialNo
end


go


CREATE Proc AdminViewStudentProfile
@sid int
As
if(exists(select * from GucianStudent where id=@sid))
Select u.id,u.email,u.password,s.firstName,s.lastName,s.type,s.faculty,s.address,s.GPA
from PostGradUser u inner join GucianStudent s on u.id=s.id
WHERE @sid = s.id
else if(exists(select * from NonGucianStudent where id=@sid))
Select u.id,u.email,u.password,s.firstName,s.lastName,s.type,s.faculty,s.address,s.GPA
from PostGradUser u inner join NonGucianStudent s on u.id=s.id
WHERE @sid = s.id


go


create procedure AdminIssueInstallPayment
@paymentID int, @InstallStartDate date
AS
Declare @tobePaid decimal, @cntInstallments INT
select @tobePaid=amount, @cntInstallments=noOfInstallments
from Payment
where id=@paymentID

set @tobePaid=@tobePaid/@cntInstallments

while @cntInstallments <>0
BEGIN
insert into Installment values (@InstallStartDate,@paymentID,@tobePaid,0)
Select @InstallStartDate=Dateadd(month,6,@InstallStartDate)
Set @cntInstallments=@cntInstallments-1
end


select * from Installment


go



CREATE Proc AdminListAcceptPublication
As
select t.serialNumber,p.title
from ThesisHasPublication tp inner join Thesis t on tp.serialNo=t.serialNumber
inner join Publication p on p.id=tp.pubid
where p.accepted=1




go


CREATE Proc AddCourse
@courseCode varchar(10),
@creditHrs int,
@fees decimal
As
insert into Course values(@fees,@creditHrs,@courseCode)


go


CREATE Proc linkCourseStudent
@courseID int,
@studentID int
As
if(exists(select * from Course where id=@courseID ) and exists(select * from NonGucianStudent where id=@studentID))
insert into NonGucianStudentTakeCourse(sid,cid,grade)values(@studentID,@courseID,null)


go


CREATE Proc addStudentCourseGrade
@courseID int,
@studentID int,
@grade decimal
As
if(exists(select * from NonGucianStudentTakeCourse where sid=@studentID and cid=@courseID))
update NonGucianStudentTakeCourse
set grade =@grade
where cid=@courseID and sid=@studentID


go


CREATE Proc ViewExamSupDefense
@defenseDate datetime
As
select s.serial_no,ee.date,e.name 'ename',sup.name 'supname'
from ExaminerEvaluateDefense ee inner join examiner e on ee.examinerId=e.id and ee.date=@defenseDate

inner join GUCianStudentRegisterThesis s on ee.serialNo=s.serial_no
inner join Supervisor sup on sup.id=s.supid
go
CREATE Proc EvaluateProgressReport
@supervisorID int,
@thesisSerialNo int,
@progressReportNo int,
@evaluation int,
@NoThesis bit output,
@NoStudent bit output,
@NoProgress bit output
As
set @NoProgress =0
set @NoStudent=0
set @NoThesis=0
if(exists(select * from Thesis where serialNumber=@thesisSerialNo ) and
@evaluation in(0,1,2,3) )
begin
if(exists(select * from GUCianStudentRegisterThesis where
serial_no=@thesisSerialNo and
supid=@supervisorID))
begin
declare @gucSid int
select @gucSid=sid
from GUCianStudentRegisterThesis
where serial_no=@thesisSerialNo
if(exists(select * from GUCianProgressReport where sid=@gucSid and thesisSerialNumber=@thesisSerialNo and no=@progressReportNo))
begin
update GUCianProgressReport
set eval=@evaluation
where sid=@gucSid and thesisSerialNumber=@thesisSerialNo and
no=@progressReportNo
end
else
set @NoProgress =1
end
else if(exists(select * from NonGUCianStudentRegisterThesis where
serial_no=@thesisSerialNo and
supid=@supervisorID))
begin
declare @nonGucSid int
select @nonGucSid=sid
from NonGUCianStudentRegisterThesis
where serial_no=@thesisSerialNo
if(exists(select * from NonGUCianProgressReport where sid=@nonGucSid and thesisSerialNumber=@thesisSerialNo and no=@progressReportNo))
begin
update NonGUCianProgressReport
set eval=@evaluation
where sid=@nonGucSid and thesisSerialNumber=@thesisSerialNo and
no=@progressReportNo
end
else
set @NoProgress=1;
end
else
begin
set @NoStudent=1;
end
end
else 
begin
set @NoThesis =1
end
go
CREATE Proc ViewSupStudentsYears
@supervisorID int
As
if(exists(select * from Supervisor where id=@supervisorID))
begin
select s.firstName,s.lastName,t.years
from GUCianStudentRegisterThesis sr inner join GucianStudent s on
sr.sid=s.id
inner join Thesis t on t.serialNumber=sr.serial_no
where sr.supid=@supervisorID
union
select s.firstName,s.lastName,t.years
from NonGUCianStudentRegisterThesis sr inner join NonGucianStudent s on
sr.sid=s.id
inner join Thesis t on t.serialNumber=sr.serial_no
where sr.supid=@supervisorID
end
go
CREATE Proc SupViewProfile
@supervisorID int
As
if(exists(select * from Supervisor where id=@supervisorID))
begin
select u.id,u.email,u.password,s.name,s.faculty
from PostGradUser u inner join Supervisor s on u.id=s.id
where s.id=@supervisorID
end
go
---------------------------------------
create proc UpdateSupProfile
@supervisorID int, @name varchar(20), @faculty varchar(20)
as
update Supervisor
set name = @name, faculty = @faculty
where id = @supervisorID
go
create proc ViewAStudentPublications
@StudentID int
as
select P.*
from GUCianStudentRegisterThesis GUC
inner join Thesis T
on GUC.serial_no = T.serialNumber
inner join ThesisHasPublication TP
on T.serialNumber = TP.serialNo
inner join Publication P
on P.id = TP.pubid
where GUC.sid = @StudentID
union all
select P.*
from NonGUCianStudentRegisterThesis NON
inner join Thesis T
on NON.serial_no = T.serialNumber
inner join ThesisHasPublication TP
on T.serialNumber = TP.serialNo
inner join Publication P
on P.id = TP.pubid
where NON.sid = @StudentID
go
create proc AddDefenseGucian
@ThesisSerialNo int , @DefenseDate Datetime , @DefenseLocation varchar(15)
, @available bit output , @notValid bit output
as
set @available=0
set @notValid=0
if(not exists(select * from GUCianStudentRegisterThesis g where g.serial_no=@ThesisSerialNo))
set @notValid=1
else if(exists (select * from Defense d where d.serialNumber=@ThesisSerialNo))
set @available=1
else
insert into Defense
values(@ThesisSerialNo,@DefenseDate,@DefenseLocation,null)
go
CREATE proc AddDefenseNonGucian
@ThesisSerialNo int , @DefenseDate Datetime , @DefenseLocation varchar(15)
, @available bit output ,@cannot bit output, @notValid bit output
as
set @notValid =0;
set @available=0;
set @cannot=0;
if(not exists (select sid
from NonGUCianStudentRegisterThesis
where serial_no = @ThesisSerialNo))
set @notValid =1;
else 
begin
declare @idOfStudent int
select @idOfStudent = sid
from NonGUCianStudentRegisterThesis
where serial_no = @ThesisSerialNo
if(not exists(select grade
from NonGucianStudentTakeCourse
where sid = @idOfStudent and grade < 50))
begin
if(exists (select * from Defense d where d.serialNumber=@ThesisSerialNo ))
set @available=1
insert into Defense
values(@ThesisSerialNo,@DefenseDate,@DefenseLocation,null)
end
else
set @cannot=1
end
go
create proc AddExaminer
@ThesisSerialNo int , @DefenseDate Datetime , @ExaminerName
varchar(20),@Password varchar(30),
@National bit, @fieldOfWork varchar(20),@notValid bit output
as
set @notValid=0
if(exists(select * from Defense d where d.date=@DefenseDate and d.serialNumber=@ThesisSerialNo))
begin
insert into PostGradUser values(@ExaminerName,@Password)
declare @id int
set @id = SCOPE_IDENTITY()
insert into Examiner values(@id,@ExaminerName,@fieldOfWork,@National)
insert into ExaminerEvaluateDefense
values(@DefenseDate,@ThesisSerialNo,@id,null)
end
else
set @notValid=1
go
create proc CancelThesis
@ThesisSerialNo int,@cannot bit output, @notValid bit output
as
set @notValid=0
set @cannot=0
if(exists(
select *
from GUCianProgressReport
where thesisSerialNumber = @ThesisSerialNo
))
begin
declare @gucianEval int
set @gucianEval = (
select top 1 eval
from GUCianProgressReport
where thesisSerialNumber = @ThesisSerialNo
order by no desc
)
if(@gucianEval = 0)
begin
delete from Thesis where serialNumber = @ThesisSerialNo
end
else
set @cannot =1
end
else if(exists(
select *
from NonGUCianProgressReport
where thesisSerialNumber = @ThesisSerialNo
))
begin
declare @nonGucianEval int
set @nonGucianEval = (
select top 1 eval
from NonGUCianProgressReport
where thesisSerialNumber = @ThesisSerialNo
order by no desc
)
if(@nonGucianEval = 0)
begin
delete from Thesis where serialNumber = @ThesisSerialNo
end
else
set @cannot =1
end
else
set @notValid =1
go
create proc AddGrade
@ThesisSerialNo int,
@notAvailable bit output
as
set @notAvailable =0
declare @grade decimal(5,2)
if(exists (select grade
from Defense
where serialNumber = @ThesisSerialNo and grade is not null))
begin
select @grade = grade
from Defense
where serialNumber = @ThesisSerialNo
update Thesis
set grade = @grade
where serialNumber = @ThesisSerialNo
end
else
set @notAvailable=1
go

create proc EditExaminerProfile
@id int, @name varchar(50), @fieldOfWork varchar(50)
AS
Update Examiner
set name = @name, fieldOfwork = @fieldOfWork
where id = @id
go

create proc AddDefenseGrade
@ThesisSerialNo int , @DefenseDate Datetime , @grade decimal(4,2)
as
update Defense
set grade = @grade
where serialNumber = @ThesisSerialNo and date = @DefenseDate
go

create proc AddCommentsGrade
@ThesisSerialNo int , @DefenseDate Datetime , @comments varchar(300)
as
update ExaminerEvaluateDefense
set comment = @comments
where serialNo = @ThesisSerialNo and date = @DefenseDate
go
create proc viewMyProfile
@studentId int
as
if(exists(
select * from GucianStudent where id = @studentId
))
begin
select G.*,P.email
from GucianStudent G
inner join PostGradUser P
on G.id = P.id
where G.id = @studentId
end
else
begin
select N.*,P.email
from NonGucianStudent N
inner join PostGradUser P
on N.id = P.id
where N.id = @studentId
end
go
create proc editMyProfile
@studentID int, @firstName varchar(20), @lastName varchar(20), @password 
varchar(30), @email
varchar(50)
, @address varchar(50), @type varchar(3)
as
update GucianStudent
set firstName = @firstName, lastName = @lastName, address = @address, type 
= @type
where id = @studentID
update NonGucianStudent
set firstName = @firstName, lastName = @lastName, address = @address, type 
= @type
where id = @studentID
update PostGradUser
set email = @email, password = @password
where id = @studentID
go
create proc addUndergradID
@studentID int, @undergradID varchar(10)
as
update GucianStudent
set undergradID = @undergradID
where id = @studentID
go
create proc ViewCoursesGrades
@studentID int
as
select grade
from NonGucianStudentTakeCourse
where sid = @studentID
go
create proc ViewCoursePaymentsInstall
@studentID int
as
select P.id as 'Payment Number', P.amount as 'Amount of 
Payment',P.fundPercentage as 'Percentage of
fund for payment', P.noOfInstallments as 'Number of installments',
I.amount as 'Installment Amount',I.date as 'Installment date', I.done as 
'Installment done or not'
from NonGucianStudentPayForCourse NPC
inner join Payment P
on NPC.paymentNo = P.id and NPC.sid = @studentID
inner join Installment I
on I.paymentId = P.id
go
create proc ViewThesisPaymentsInstall
@studentID int
as
select P.id as 'Payment Number', P.amount as 'Amount of Payment', 
P.fundPercentage as
'Fund',P.noOfInstallments as 'Number of installments',
I.amount as 'Installment amount',I.date as 'Installment date', I.done as 
'Installment done or not'
from GUCianStudentRegisterThesis G
inner join Thesis T
on G.serial_no = T.serialNumber and G.sid = @studentID
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
union
select P.id as 'Payment Number',P.amount as 'Amount of Payment', 
P.fundPercentage as
'Fund',P.noOfInstallments as 'Number of installments',
I.amount as 'Installment amount',I.date as 'Installment date', I.done as 
'Installment done or not'
from NonGUCianStudentRegisterThesis NG
inner join Thesis T
on NG.serial_no = T.serialNumber and NG.sid = @studentID
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
go
create proc ViewUpcomingInstallments
@studentID int
as
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Installment I
inner join NonGucianStudentPayForCourse NPC
on I.paymentId = NPC.paymentNo and NPC.sid = @studentID and I.date > 
CURRENT_TIMESTAMP
union
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Thesis T
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
inner join GUCianStudentRegisterThesis G
on G.serial_no = T.serialNumber and G.sid = @studentID
where I.date > CURRENT_TIMESTAMP
union
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Thesis T
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
inner join NonGUCianStudentRegisterThesis G
on G.serial_no = T.serialNumber and G.sid = @studentID
where I.date > CURRENT_TIMESTAMP
go
create proc ViewMissedInstallments
@studentID int
as
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Installment I
inner join NonGucianStudentPayForCourse NPC
on I.paymentId = NPC.paymentNo and NPC.sid = @studentID and I.date < 
CURRENT_TIMESTAMP and
I.done = '0'
union
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Thesis T
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
inner join GUCianStudentRegisterThesis G
on G.serial_no = T.serialNumber and G.sid = @studentID
where I.date < CURRENT_TIMESTAMP and I.done = '0'
union
select I.date as 'Date of Installment' ,I.amount as 'Amount'
from Thesis T
inner join Payment P
on T.payment_id = P.id
inner join Installment I
on I.paymentId = P.id
inner join NonGUCianStudentRegisterThesis G
on G.serial_no = T.serialNumber and G.sid = @studentID
where I.date < CURRENT_TIMESTAMP and I.done = '0'
go
create proc AddProgressReport
@thesisSerialNo int, @progressReportDate date, @studentID 
int,@progressReportNo int
as
declare @gucian int
if(exists(
select id
from GucianStudent
where id = @studentID
))
begin
set @gucian = '1'
end
else
begin
set @gucian = '0'
end
if(@gucian = '1')
begin
insert into GUCianProgressReport
values(@studentID,@progressReportNo,@progressReportDate,null,null,null,@thesisSerialNo,null)
end
else
begin
insert into NonGUCianProgressReport
values(@studentID,@progressReportNo,@progressReportDate,null,null,null,@thesisSerialNo,null)
end
go
create proc FillProgressReport
@thesisSerialNo int, @progressReportNo int, @state int, @description 
varchar(200),@studentID int
as
declare @gucian bit
if(exists(
select * from GucianStudent
where id = @studentID
))
begin
set @gucian = '1'
end
else
begin
set @gucian = '0'
end
if(@gucian = '1')
begin
update GUCianProgressReport
set state = @state, description = @description, date = CURRENT_TIMESTAMP
where thesisSerialNumber = @thesisSerialNo and sid = @studentID and no = 
@progressReportNo
end
else
begin
update NonGUCianProgressReport
set state = @state, description = @description, date = CURRENT_TIMESTAMP
where thesisSerialNumber = @thesisSerialNo and sid = @studentID and no = 
@progressReportNo
end
go
create proc ViewEvalProgressReport
@thesisSerialNo int, @progressReportNo int,@studentID int
as
select eval
from GUCianProgressReport
where sid = @studentID and thesisSerialNumber = @thesisSerialNo and no = 
@progressReportNo
union
select eval
from NonGUCianProgressReport
where sid = @studentID and thesisSerialNumber = @thesisSerialNo and no = 
@progressReportNo
go
create proc addPublication
@title varchar(50), @pubDate datetime, @host varchar(50), @place 
varchar(50), @accepted bit
as
insert into Publication values(@title,@pubDate,@place,@accepted,@host)
go
create proc addPublication1
@title varchar(50), @pubDate datetime, @host varchar(50), @place 
varchar(50), @accepted int
as
insert into Publication values(@title,@pubDate,@place,@accepted,@host)
go
create proc linkPubThesis
@PubID int, @thesisSerialNo int
as
insert into ThesisHasPublication values(@thesisSerialNo,@PubID)
go
create proc viewtheses
@studentId int
As
if exists(select * from GucianStudent where id=@studentId)
begin
(select T.* 
from GucianStudentRegisterThesis g , Thesis T
where g.sid=@studentId and T.serialNumber = g.serial_no)
end
else 
begin
(select T.* 
from NonGucianStudentRegisterThesis g , Thesis T
where g.sid=@studentId and T.serialNumber = g.serial_no)
end

go 
create proc linkTheses2
@studentId int , @serialNo int , @success bit output 
as
if exists (select *
           from  GUCianStudentRegisterThesis g inner join Thesis t on g.serial_no = t.serialNumber
           where g.sid = @studentId and g.serial_no=@serialNo and t.startDate < Convert(Date,CURRENT_TIMESTAMP) and t.endDate > Convert(Date,CURRENT_TIMESTAMP))
begin set @success = 1
     select @success
end


else
if exists (select *
           from  NonGUCianStudentRegisterThesis g inner join Thesis t on g.serial_no = t.serialNumber
           where g.sid = @studentId and g.serial_no=@serialNo and t.startDate < Convert(Date,CURRENT_TIMESTAMP) and t.endDate > Convert(Date,CURRENT_TIMESTAMP))
begin set @success = 1
select @success
end
else 
set @success = 0
select @success
go


go
create proc courses
@studentId int , @success bit output 
as
if exists (select *
           from NonGucianStudentTakeCourse g
           where g.sid = @studentId )
begin select *
           from NonGucianStudentTakeCourse g
           where g.sid = @studentId 
 set @success = 1
 SELECT @success
 end
else 
set @success = 0
SELECT @success
 
 go

create procedure ExaminerRegister 
@name varchar(50), @fieldOfWork varchar(50),@isNational bit,@email varchar(50),@password varchar(50)
as 
INSERT INTO PostGradUser VALUES  (@email,@password)
declare @temp int 
select @temp=max(id)
from PostGradUser

insert into Examiner VALUES (@temp,@name,@fieldOfWork,@isNational)
go



--a proc to display Name and fieldOfWork of an Examiner
create proc DisplayData
@id int
As
Select name, fieldOfWork
from Examiner
where id = @id
go

create proc ListAllDefensePersonell
@examId int
AS
Select Distinct T.title, S.name , G.firstName, G.lastName
From Examiner E inner join ExaminerEvaluateDefense EED on E.id = EED.examinerId
                inner join Defense D on EED.date = D.date and EED.serialNo = D.serialNumber
                inner join Thesis T on D.serialNumber = T.serialNumber
                inner join GUCianStudentRegisterThesis GRT on GRT.serial_no = T.serialNumber
                inner join GucianStudent G on G.id = GRT.sid
                inner join Supervisor S on GRT.supid = S.id
where E.id = @examId
Union
Select T.title, S.name , NG.firstName, NG.lastName
From Examiner E inner join ExaminerEvaluateDefense EED on E.id = EED.examinerId
                inner join Defense D on EED.date = D.date and EED.serialNo = D.serialNumber
                inner join Thesis T on D.serialNumber = T.serialNumber
                inner join NonGUCianStudentRegisterThesis NGRT on NGRT.serial_no = T.serialNumber
                inner join NonGucianStudent NG on NG.id = NGRT.sid
                inner join Supervisor S on NGRT.supid = S.id
where E.id = @examId
go

create proc ExaminerSearchThesis
@Thesistitle varchar(50)
AS
select serialNumber, field, type, title, startDate, endDate, defenseDate, years, grade
from Thesis
where title like  '%' +@Thesistitle + '%'
go

create proc searchForPrimaryKeysDefenseComment
@x int,@y datetime, @z int,@temp1 int output, @temp2 datetime output, @temp3 int output
As
Select @temp1=EED.serialNo, @temp2=EED.date, @temp3 = EED.examinerId
from Defense D inner join ExaminerEvaluateDefense EED on D.date = EED.date and D.serialNumber = EED.serialNo
where EED.serialNo=@x and EED.date=@y and EED.examinerId = @z
go

create proc searchForPrimaryKeysDefense
@x int,@y datetime, @z int,@temp1 int output, @temp2 datetime output, @temp3 int output
As
Select @temp1=EED.serialNo, @temp2=EED.date, @temp3 = EED.examinerId
from Defense D inner join ExaminerEvaluateDefense EED on D.date = EED.date and D.serialNumber = EED.serialNo
where EED.serialNo=@x and EED.date=@y and EED.examinerId = @z
go



create proc editPersonalInformation
@id int, @email varchar(50), @password varchar(30)
As
Update PostGradUser
set email = @email, password = @password
where id = @id

