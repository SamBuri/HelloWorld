

use XXXMaster
go

---------------------------------------------------------------------------------
---------------Logins------------------------------------------------------------
---------------------------------------------------------------------------------
/**
alter table Logins
alter column LoginPassword nvarchar(200) not null 

---------------------------------------------------------------------------------
---------------LabRequestTests---------------------------------------------------
---------------------------------------------------------------------------------

sp_depends LabRequestTests

drop function GetTotalLabRequestTests

drop proc uspGetLabRequestTests
drop proc uspInsertLabRequestTests
drop proc uspInsertLabResults
drop proc uspUpdateLabResults

---------------------------------------------------------------------------------------
exec sp_rename 'LabRequestTests', 'LabRequestDetails'

-----------First Open the application to keep login roles-------------------------------
delete from SearchColumns
delete from SearchObjects

delete from ObjectRoles
delete from Roles 

-----------After Clearing Search Columns-----------------------------------------------
delete from AccessObjects where ObjectName = 'LabRequestTests'

-----------Patients-----------------------------------------------------------------
alter table Patients add
LoginID varchar(20) 
constraint fkLoginIDPatients references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimePatients default getdate()

-----------Visits-----------------------------------------------------------------
alter table Visits add
RecordDateTime smalldatetime constraint dfRecordDateTimeVisits default getdate()

-----------Items-----------------------------------------------------------------
alter table Items add
RecordDateTime smalldatetime constraint dfRecordDateTimeItems default getdate()

-----------Payments-----------------------------------------------------------------
alter table Payments add
RecordDateTime smalldatetime constraint dfRecordDateTimePayments default getdate(),

-----------Accounts-----------------------------------------------------------------
alter table Accounts add
RecordDateTime smalldatetime constraint dfRecordDateTimeAccounts default getdate(),

-----------DoctorVisits----------------------------------------------------------

exec sp_rename 'DoctorVisits.RecordDate', 'RecordDateTime', 'COLUMN'

alter table DoctorVisits add
LoginID varchar(20) 
constraint fkLoginIDDoctorVisits references Logins (LoginID)

------Manually add the default i.e (getdate()) to complete-------------------

-----------ClinicalFindings-----------------------------------------------------------------
alter table ClinicalFindings add
LoginID varchar(20) 
constraint fkLoginIDClinicalFindings references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeClinicalFindings default getdate()

-----------ExternalLabResults-----------------------------------------------------------------
alter table ExternalLabResults add
LoginID varchar(20) 
constraint fkLoginIDExternalLabResults references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeExternalLabResults default getdate()

-----------LabRequests----------------------------------------------------------

exec sp_rename 'LabRequests.RecordDate', 'RecordDateTime', 'COLUMN'

------Manually add the default i.e (getdate()) to complete----------------------

-----------LabResults-----------------------------------------------------------------
alter table LabResults add
LoginID varchar(20) 
constraint fkLoginIDLabResults references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeLabResults default getdate()

-----------Appointments-----------------------------------------------------------------
alter table Appointments add
LoginID varchar(20) 
constraint fkLoginIDAppointments references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeAppointments default getdate()

-----------Allergies-----------------------------------------------------------------
alter table Allergies add
LoginID varchar(20) 
constraint fkLoginIDAllergies references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeAllergies default getdate()

-----------Illnesses-----------------------------------------------------------------
alter table Illnesses add
LoginID varchar(20) 
constraint fkLoginIDIllnesses references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeIllnesses default getdate()

-----------Hospitalizations-----------------------------------------------------------------
alter table Hospitalizations add
LoginID varchar(20) 
constraint fkLoginIDHospitalizations references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeHospitalizations default getdate()

-----------Inventory-----------------------------------------------------------------
alter table Inventory add
RecordDateTime smalldatetime constraint dfRecordDateTimeInventory default getdate()

-----------ARTRegimen-----------------------------------------------------------------
alter table ARTRegimen add
LoginID varchar(20) 
constraint fkLoginIDARTRegimen references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeARTRegimen default getdate()

-----------ARTStopped-----------------------------------------------------------------
alter table ARTStopped add
LoginID varchar(20) 
constraint fkLoginIDARTStopped references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeARTStopped default getdate()

-----------Deaths-----------------------------------------------------------------
alter table Deaths add
LoginID varchar(20) 
constraint fkLoginIDDeaths references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeDeaths default getdate()

-----------Expenditure-----------------------------------------------------------------
alter table Expenditure add
RecordDateTime smalldatetime constraint dfRecordDateTimeExpenditure default getdate()

-----------OtherIncome-----------------------------------------------------------------
alter table OtherIncome add
RecordDateTime smalldatetime constraint dfRecordDateTimeOtherIncome default getdate()

-----------Others-----------------------------------------------------------------
drop proc uspDeleteStaff
drop proc uspDeletePatients
drop proc uspDeleteVisits
drop proc uspDeleteDrugs
drop proc uspDeleteServices
drop proc uspDeleteExternalLabResult
drop proc uspDeleteLabTests
--drop proc uspDeleteLabResults
drop proc uspInsertClinicalFindings
drop proc uspInsertExternalLabResults
drop proc uspInsertLabRequestDetails
drop proc uspInsertIllnesses
drop proc uspInsertARTRegimenDetails
drop proc uspUpdateARTRegimenDetails

---------------------------------------------------------------------------------
---------------Added update on Mon 09-06-08 -------------------------------------
---------------------------------------------------------------------------------

-----------AccessObjects----------------------------------------------------------

alter table AccessObjects
drop constraint ckObjectType

alter table AccessObjects
add constraint ckObjectType check (ObjectType in ('T','V','R','F','D'))--,T-Table, V-View, R-Report, F-Form, D-Data File

-----------LabResults-----------------------------------------------------------------
alter table LabResults add
LabTechnologist varchar(10) 
constraint fkLabTechnologistLabResults references Staff (StaffNo)
-- add  staff (Lab Technologist) with StaffNo: LAB
update LabResults set LabTechnologist = 'LAB' where LabTechnologist is null
---------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Mon 30-06-08 -------------------------------------
---------------------------------------------------------------------------------

-----------LabResults------------------------------------------------------------
exec sp_rename 'LabResults.TestDate', 'TestDateTime', 'COLUMN'
---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Mon 03-07-08 -------------------------------------
---------------------------------------------------------------------------------

-----------LabTests--------------------------------------------------------------
alter table LabTests add
ResultDataTypeID varchar(10)
constraint fkResultDataTypeIDLabTests references LookupData (DataID)
-- add  LookupData (SearchDataType) with DataID: 3STR
update LabTests set ResultDataTypeID = '3STR' where ResultDataTypeID is null
update LabTests set ResultDataTypeID = '3DEC'where len(NormalRange)> 0 and ResultDataTypeID = '3STR' 

---------------------------------------------------------------------------------
---------------Added update on Sun 06-07-08 -------------------------------------
---------------------------------------------------------------------------------

alter table LabResults
alter column Result varchar(200)
----------------------------------------------------------------------------------
alter table LabResults
alter column Report varchar(2000)

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Mon 28-07-08 -------------------------------------
---------------------------------------------------------------------------------
update LookupData set DataDes = 'Missed' where DataID = '21NV'
---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Tue 29-07-08 -------------------------------------
---------------------------------------------------------------------------------

-----------ARTRegimen------------------------------------------------------------
alter table ARTRegimen add
RefillDuration smallint

update ARTRegimen set RefillDuration = 0 where RefillDuration is null
---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Tue 01-08-08 -------------------------------------
---------------------------------------------------------------------------------

create table LabTestsEXT
(TestCode varchar(10)
constraint fkTestCodeLabTestsEXT references LabTests(TestCode)
on delete cascade on update cascade,
SubTestCode varchar(10) constraint uqSubTestCodeLabTestsEXT unique,
constraint pkTestCodeSubTestCode primary key (TestCode, SubTestCode),
SubTestName varchar(40),
NormalRange varchar(20),
UnitMeasureID varchar(10)
constraint fkUnitMeasureIDLabTestsEXT references LookupData (DataID),
ResultDataTypeID varchar(10)
constraint fkResultDataTypeIDLabTestsEXT references LookupData (DataID)
)
go

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Tue 01-08-08 -------------------------------------
---------------------------------------------------------------------------------

create table LabResultsEXT
(SpecimenNo varchar(20),
TestCode varchar(10),
constraint fkSpecimenNoTestCode foreign key (SpecimenNo, TestCode)
references LabResults (SpecimenNo, TestCode)
on delete cascade on update cascade,
SubTestCode varchar(10),
constraint fkTestCodeSubTestCode foreign key (TestCode, SubTestCode)
references LabTestsEXT (TestCode, SubTestCode),
constraint pkSpecimenNoTestCodeSubTestCode primary key (SpecimenNo, TestCode, SubTestCode),
Result varchar(200),
Report varchar(2000)	
)
go

----------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------
---------------Added update on Tue 06-08-08 --------------------------------------------
----------------------------------------------------------------------------------------

-----------Patients---------------------------------------------------------------------

alter table Patients add
DefaultAccountNo varchar(20) 
constraint fkDefaultAccountNoPatients references BillCustomers(AccountNo)

update Patients set DefaultAccountNo = 'CASH' where DefaultAccountNo is null

--update Patients set DefaultAccountNo = 'CT' where DefaultAccountNo is null and Location like 'T%'
--Add MOH onto the Bill Customers
--update Patients set DefaultAccountNo = 'MOH' where DefaultAccountNo is null and Location like 'M%'

----------------------------------------------------------------------------------------
alter table Patients add
EnforceDefaultAccountNo bit not null constraint dfEnforceDefaultAccountNo default 0

----------------------------------------------------------------------------------------

alter table Patients add
MiddleName varchar(20)

update Patients set MiddleName = '' where MiddleName is null

----------------------------------------------------------------------------------------

alter table Patients add
Photo image

----------------------------------------------------------------------------------------

-----------Patients---------------------------------------------------------------------
--exec sp_rename 'Patients.FirstName', 'Surname', 'COLUMN'
--exec sp_rename 'Patients.LastName', 'FirstName', 'COLUMN'
--exec sp_rename 'Patients.Surname', 'LastName', 'COLUMN'

----------------------------------------------------------------------------------------
---------------Added update on Mon 25-08-08 --------------------------------------------
----------------------------------------------------------------------------------------

---------AuditTrial-----------------------------------------------------------------------
drop proc uspInsertAuditTrialDetails
drop proc uspInsertAuditTrial

drop table AuditTrialDetails
drop table AuditTrial

-----------First Open the application to keep login roles-------------------------------
delete from SearchColumns
delete from SearchObjects

delete from ObjectRoles
delete from Roles 

-----------After Clearing Search Columns-----------------------------------------------
delete from AccessObjects where ObjectName = 'AuditTrail'

----------------------------------------------------------------------------------------

create table AuditTrail
(AuditID int not null identity(1,1) constraint pkAuditID primary key,
AuditAction char(1) not null constraint ckAuditAction check (AuditAction in ('U','D')), --[U-Update, D-Delete]
ObjectName varchar(40) not null 
constraint fkObjectNameAuditTrail references AccessObjects(ObjectName),
LoginID varchar(20) constraint fkLoginIDAuditTrail references Logins (LoginID), 
ClientMachine varchar(40),	
UserID varchar(40) not null constraint dfUserID default System_User,
FullDate smalldatetime not null constraint dfFullDate default getdate()
)
go

----------------------------------------------------------------------------------------

create table AuditTrailDetails
(AuditID int not null constraint fkAuditIDAuditTrailDetails 
references AuditTrail(AuditID) on delete cascade,
ColumnName varchar(60) not null,
constraint pkAuditIDColumnName primary key(AuditID,ColumnName),
OriginalValue varchar(2000),
NewValue varchar(2000)
)
go

----------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Sun 14-09-08 -------------------------------------
---------------------------------------------------------------------------------

-----------ARTStopped------------------------------------------------------------
exec sp_rename 'ARTStopped.StopReason', 'ARTStopReasons', 'COLUMN'
---------------------------------------------------------------------------------
alter table ARTStopped
alter column ARTStopReasons varchar(200)
----------------------------------------------------------------------------------
--select * from ARTStopped where ARTStopReasons like '%Toxic%'
update ARTStopped set ARTStopReasons = '291' where ARTStopReasons like '%Toxic%'
-- or update ARTStopped set ARTStopReasons = '541' where ARTStopReasons like '%Toxic%'

--select * from ARTStopped where ARTStopReasons like '%fail%'
update ARTStopped set ARTStopReasons = '293' where ARTStopReasons like '%fail%'
-- or update ARTStopped set ARTStopReasons = '543' where ARTStopReasons like '%fail%'

----------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Mon 22-09-08 -------------------------------------
---------------------------------------------------------------------------------

-----------ARTRegimen------------------------------------------------------------

alter table ARTRegimen add
WhyEligible varchar(200)

update ARTRegimen set WhyEligible = '' where WhyEligible is null

----------------------------------------------------------------------------------

alter table ARTRegimen add
ARTSwitchReasons varchar(200)

update ARTRegimen set ARTSwitchReasons = '' where ARTSwitchReasons is null

----------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Thu 25-09-08 -------------------------------------
---------------------------------------------------------------------------------

-----------Staff--------------------------------------------------------------------

alter table Staff
alter column Phone varchar(30)

-----------BillCustomers------------------------------------------------------------

alter table BillCustomers
alter column Phone varchar(30)

-----------Patients-----------------------------------------------------------------

alter table Patients
alter column Phone varchar(30)

-----------Patients-----------------------------------------------------------------

update LookupData set DataDes = 'IN (coma separated list)' where DataID = '2IN'


------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Sun 12-10-08 -------------------------------------
---------------------------------------------------------------------------------

-----------Inventory----------------------------------------------------------------

alter table Inventory
drop constraint fkDrugNoInventory

alter table Inventory
drop constraint fkLoginIDInventory

alter table Inventory
add constraint fkDrugNoInventory foreign key (DrugNo) 
references Drugs(DrugNo) on delete cascade

alter table Inventory add
constraint fkLoginIDInventory foreign key (LoginID) 
references Logins (LoginID) on delete cascade
------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Sun 19-10-08 -------------------------------------
---------------------------------------------------------------------------------

-----------DrugCombinationDetails-------------------------------------------------

create table DrugCombinationDetails
(Combination varchar(30) not null 
constraint fkCombinationDrugCombinationDetails references DrugCombinations(Combination)
on delete cascade,
DrugNo	varchar(20)
constraint fkDrugNoDrugCombinationDetails references Drugs(DrugNo),
constraint pkCombinationDrugNo primary key (Combination, DrugNo)
)
go

/*
update DrugCombinations set CombinationDes = replace (CombinationDes, 'Lamivudine', 'Lamivudine (Epivir)')
where CombinationDes like '%Lamivudine%'
*/
---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Thur 30-10-08 ------------------------------------
---------------------------------------------------------------------------------

-----------Examination-----------------------------------------------------------

alter table Examination
alter column HGB decimal (10, 2)

---------------------------------------------------------------------------------
---------------TREAT 06-05-09 ---------------------------------------------------
---------------------------------------------------------------------------------


create table Transfers
(TreatPatientID varchar(20) not null constraint pkTreatPatientIDTransfers primary key
constraint fkTreatPatientIDTransfers references TreatPatients(TreatPatientID), 
TransferDate smalldatetime,
TransferPlace varchar(40),
Notes varchar(200),
LoginID varchar(20) 
constraint fkLoginIDTransfers references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeTransfers default getdate()
)
go

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Thur 30-10-08 ------------------------------------
---------------------------------------------------------------------------------

alter table LookupData add 
LookupOrder int not null identity(1,1)

---------------------------------------------------------------------------------

----------------------------------------------------------------------------------------
---------------Added update on Sat 17-10-09 --------------------------------------------
----------------------------------------------------------------------------------------

-----------Triage-----------------------------------------------------------------------

create table Triage
(VisitNo varchar(20) not null constraint fkVisitNoTriage references Visits (VisitNo) 
constraint pkVisitNoTriage primary key,
Weight decimal(5,2) constraint ckWeight check (Weight > 0 and Weight <= 200),
Temperature decimal(5,2) constraint ckTemperature check (Temperature > 30 and Temperature < 50),
Height decimal(5,2) constraint ckHeight check (Height > 40 and Height < 300),
Pulse tinyint constraint ckPulse check (Pulse > 40 and Pulse <= 300),
BloodPressure varchar(10),
HeadCircum decimal(5,2) constraint ckHeadCircum check (HeadCircum > 20 and HeadCircum < 150),
BodySurfaceArea decimal(10,2),
LoginID varchar(20) constraint fkLoginIDTriage references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeTriage default getdate()
)
go

-----------ClinicalFindings-----------------------------------------------------------------
alter table ClinicalFindings add
ClinicalNotes varchar(4000)

update ClinicalFindings set ClinicalNotes = '' where ClinicalNotes is null

insert into Triage 
   (VisitNo, Weight, Temperature, Height, Pulse, BloodPressure, LoginID, RecordDateTime)
select VisitNo, Weight, Temperature, Height, Pulse, BloodPressure, LoginID, RecordDateTime
from ClinicalFindings

alter table ClinicalFindings drop column
Weight, Temperature, Height, Pulse, BloodPressure

-------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------
---------------Added update on Match 3, 2010 -------------------------------------------
----------------------------------------------------------------------------------------

alter table BillCustomers
add constraint uqBillCustomerName unique(BillCustomerName)

alter table Drugs
add constraint uqDrugName unique(DrugName)

/*
	select DrugName, count(DrugName) from Drugs
	group by DrugName
	having count(DrugName) > 1
	go
*/

alter table Services
add constraint uqServiceName unique(ServiceName)

alter table LabTests
add constraint uqTestName unique(TestName)

alter table LabTestsEXT
add constraint uqSubTestName unique(SubTestName)

-------------------------------------------------------------------------------------------

create table StaffEXT
(StaffNo varchar(10) not null 
constraint fkStaffNoStaffEXT references Staff (StaffNo) 
on delete cascade on update cascade
constraint pkStaffNoStaffEXT primary key,
ConsultationFee money
)
go

---------------------------------------------------------------------------------
---------------Added update on Wen 10-03-2010 -----------------------------------
---------------------------------------------------------------------------------

alter table LabTests
alter column NormalRange varchar(40)
----------------------------------------------------------------------------------
alter table LabTestsEXT
alter column NormalRange varchar(40)

----------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Fri 12-03-2010 -----------------------------------
---------------------------------------------------------------------------------

-----------Staff-----------------------------------------------------------------

alter table Staff add
LoginID varchar(20) null constraint fkLoginIDStaff references Logins (LoginID)

-----------Visits-----------------------------------------------------------------

alter table Visits add
StaffNo varchar(10) null constraint fkStaffNoVisits references Staff (StaffNo)

--------------ItemsEXT-------------------------------------------------------------------

create table ItemsEXT
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDItemsEXT  foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDItemsEXT primary key (VisitNo, ItemCode, ItemCategoryID),
Dosage varchar(40),
Duration int
)
go

------------Hospitalizations--------------------------------------------------------

-- select * from Hospitalizations
drop table Hospitalizations
drop proc uspInsertHospitalizations
drop proc uspUpdateHospitalizations
drop proc uspGetHospitalizations
delete from ObjectRoles where ObjectName = 'Hospitalizations'
-- delete from SearchColumns
-- delete from SearchObjects
delete from AccessObjects where ObjectName = 'Hospitalizations'

----------Admissions-------------------------------------------------------------------

create table Admissions
(AdmissionID int not null constraint dfAdmissionID default 1,
AdmissionNo varchar(20) not null constraint pkAdmissionNo primary key,
VisitNo varchar(20) constraint fkVisitNoAdmissions references Visits (VisitNo)
constraint uqVisitNoAdmissions unique,
AdmissionDate smalldatetime,
AdmissionNotes varchar(2000),
AdmissionStatusID varchar(10)
constraint fkAdmissionStatusIDAdmissions references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDAdmissions references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeAdmissions default getdate()
)
go

--------AdmissionsDiagnosis--------------------------------------------------------------

create table AdmissionsDiagnosis
(AdmissionNo varchar(20) not null
constraint fkAdmissionNoAdmissionsDiagnosis references Admissions (AdmissionNo)
on delete cascade,
DiagnosisID varchar(10)
constraint fkDiagnosisIDAdmissionsDiagnosis references LookupData (DataID),
constraint pkAdmissionNoDiagnosisID primary key(AdmissionNo, DiagnosisID),
DiagnosisDate smalldatetime,
DiagnosisStatusID varchar(10) 
constraint fkDiagnosisStatusIDAdmissionsDiagnosis references LookupData (DataID)
)
go

------------Discharges--------------------------------------------------------------------

create table Discharges
(AdmissionNo varchar(20) not null
constraint fkAdmissionNoDischarges references Admissions (AdmissionNo)
constraint pkAdmissionNoDischarges primary key,
DischargeDate smalldatetime,
DischargeNotes varchar(2000),
DischargeStatusID varchar(10)
constraint fkDischargeStatusIDDischarges references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDDischarges references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDischarges default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Thur 18-03-2010 ----------------------------------
---------------------------------------------------------------------------------

--------------Services-----------------------------------------------------------

alter table Services
drop constraint pkServiceCode
---------------------------------------------------------------------------------

alter table Services
alter column ServiceCode varchar(10) not null
---------------------------------------------------------------------------------

alter table Services
add constraint pkServiceCode primary key (ServiceCode)
---------------------------------------------------------------------------------

exec sp_rename 'Services.DepartmentsID', 'ServiceBillAtID', 'COLUMN'
---------------------------------------------------------------------------------

alter table Services
drop constraint fkDepartmentsIDServices
---------------------------------------------------------------------------------

alter table Services
add constraint fkServiceBillAtIDServices foreign key (ServiceBillAtID) 
references LookupData (DataID)

alter table Services
add ServicePointID varchar(10) null constraint fkServicePointIDServices 
foreign key (ServicePointID) references LookupData (DataID)

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
--------------PatientsEXT--------------------------------------------------------

create table PatientsEXT
(PatientNo varchar(20) not null
constraint fkPatientNoPatientsEXT references Patients (PatientNo) 
on delete cascade on update cascade,
AlternateNo varchar(20) not null,
constraint pkPatientNoAlternateNo primary key(PatientNo, AlternateNo),
Notes varchar(200)
)
go

---------------------------------------------------------------------------------
--------------Visits-------------------------------------------------------------

alter table Visits add
ServiceCode varchar(10) null constraint fkServiceCodeVisits references Services (ServiceCode)

update Visits set ServiceCode = '10C'
where VisitCategoryID = '10C' and ServiceCode is null

---------------------------------------------------------------------------------

---------------Services-----------------------------------------------------------

update LookupObjects set ObjectName = 'ServicePoint', ObjectDes = 'Service Point'
where ObjectID = 16

exec uspInsertServices '10C', 'Consultation','16VIS', 15.00
exec uspInsertServices 'HOS', 'Hospitalization','16DIS', 10.00
exec uspInsertServices 'REV', 'Review','16VIS', 5.00
exec uspInsertServices 'DEN', 'Dental','16VIS', 18.00
exec uspInsertServices 'PHY', 'Physiotherapy','16VIS', 9.00
exec uspInsertServices 'MEX', 'Medical Examination','16VIS', 14.00
exec uspInsertServices 'NA', 'NA','16VIS', 0

---------------------------------------------------------------------------------
---------------Added update on Wen 24-03-2010 -----------------------------------
---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
--------------ItemsEXT-----------------------------------------------------------
---------------------------------------------------------------------------------

exec sp_rename 'ItemsEXT.DailyDosage', 'Dosage', 'COLUMN'

---------------------------------------------------------------------------------

alter table ItemsEXT alter column Dosage varchar(40)

---------------------------------------------------------------------------------

drop proc uspUpdateItemsEXT

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
--------------DrugCategories-----------------------------------------------------
---------------------------------------------------------------------------------

create table DrugCategories
(CategoryNo varchar(10) not null constraint pkCategoryNo primary key,
CategoryName varchar(40) constraint uqCategoryName unique,
GroupsID varchar(10) constraint fkGroupsIDDrugCategories references LookupData (DataID),
VaryPrescribedQty bit constraint dfVaryPrescribedQtyDrugCategories default 0,
DefaultPrescribedQty smallint constraint dfDefaultPrescribedQtyDrugCategories default 0,
DosageSeparator char(1) constraint dfDosageSeparatorDrugCategories default 'X',
DosageCalculationID varchar(10) constraint fkDosageCalculationIDDrugCategories references LookupData (DataID),
DosageFormat varchar(40)
)
go

--------------Drugs--------------------------------------------------------------

alter table Drugs
drop constraint fkGroupsIDDrugs
---------------------------------------------------------------------------------

exec sp_rename 'Drugs.GroupsID', 'CategoryNo', 'COLUMN'
---------------------------------------------------------------------------------

insert into DrugCategories (CategoryNo, CategoryName, GroupsID)
select DataID, DataDes, DataID from LookupData where ObjectID = 4

-- select * from DrugCategories
---------------------------------------------------------------------------------

alter table Drugs
add constraint fkCategoryNoDrugs foreign key (CategoryNo) 
references DrugCategories (CategoryNo)
---------------------------------------------------------------------------------

update Services set ServicePointID = ServiceBillAtID
where ServicePointID is null
---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Tue 20-04-2010 -----------------------------------
---------------------------------------------------------------------------------

-----------BillCustomers---------------------------------------------------------

alter table BillCustomers add
UseCustomFee bit constraint dfUseCustomFeeBillCustomers default 0

---------------------------------------------------------------------------------
update BillCustomers set UseCustomFee = 0 where UseCustomFee is null

---------------------------------------------------------------------------------
---------------Added update on Mon 10-05-2010 -----------------------------------
---------------------------------------------------------------------------------

-----------Drugs-----------------------------------------------------------------
alter table Drugs add UnitCost money

---------------------------------------------------------------------------------
update Drugs set UnitCost = 0 where UnitCost is null

---------------------------------------------------------------------------------

-----------ARTRegimenDetails-----------------------------------------------------
alter table ARTRegimenDetails 
add Dosage varchar(40), Duration int

---------------------------------------------------------------------------------
update ARTRegimenDetails set Duration = 0 where Duration is null
update ARTRegimenDetails set Dosage = Formula where Dosage is null

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Tue 22-06-2010 -----------------------------------
---------------------------------------------------------------------------------

--------------Visits-------------------------------------------------------------

alter table Visits add
AccessCashServices bit constraint dfAccessCashServicesVisits default 0

update Visits set AccessCashServices = 0
where AccessCashServices is null

update Visits set VisitStatusID = '9CO'
where VisitNo in (select VisitNo from DoctorVisits)

--------------ClinicalFindings-----------------------------------------------------

alter table ClinicalFindings add
ClinicalImage image

--------------LabPossibleResults-----------------------------------------------------

create table LabPossibleResults
(TestCode varchar(10) not null constraint fkTestCodeLabPossibleResults 
references LabTests (TestCode) on delete cascade,
PossibleResult varchar(200) not null,
constraint pkTestCodePossibleResult primary key(TestCode, PossibleResult)
)
go

---------------------------------------------------------------------------------
---------------Added update on Tue 04-07-2010 -----------------------------------
---------------------------------------------------------------------------------

-----------LookupData-------------------------------------------------------------

update LookupData set DataDes = 'Insurance' 
where DataID = '18INS' and DataDes = 'Institution'

--------------BillCustomers----------------------------------------------------------------------------------

alter table BillCustomers add
InsuranceNo varchar(20) null constraint fkInsuranceNoBillCustomers references BillCustomers (AccountNo)

--------------LabTestsEXT------------------------------------------------------------------------------------
alter table LabTestsEXT add
SortOrder tinyint constraint dfSortOrderLabTestsEXT default 0

--------------Allergies---------------------------------------------------------------------------------------

alter table Allergies 
drop constraint fkLoginIDAllergies

alter table Allergies 
drop column LoginID

alter table Allergies 
drop constraint dfRecordDateTimeAllergies

alter table Allergies 
drop column RecordDateTime

drop proc uspInsertAllergies
drop proc uspUpdateAllergies

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Tue 26-07-2010 -----------------------------------
---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
--------------Patients-----------------------------------------------------------
---------------------------------------------------------------------------------

alter table Patients add
MedicalCardNo varchar(20) null 

update Patients set MedicalCardNo = ''
where MedicalCardNo is null

alter table Patients add
NOKName varchar(41), NOKPhone varchar(30), 
HideDetails bit constraint dfHideDetailsPatients default 0

update Patients set NOKName = '' where NOKName is null
update Patients set NOKPhone = '' where NOKPhone is null
update Patients set HideDetails = 0 where HideDetails is null

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Tue 26-07-2010 -----------------------------------
---------------------------------------------------------------------------------

--------------ProductOwnerInfo---------------------------------------------------

create table ProductOwnerInfo
(ProductOwner varchar(200) not null constraint pkProductOwner primary key,
Address varchar(200),
Phone varchar(100),
Fax varchar(100),
Email varchar(100),
Website varchar(100),
Photo image
)
go

drop proc uspInsertOptions
drop proc uspUpdateOptions

--------------------------------------------------------------------------------------

-----------LabTestsEXT----------------------------------------------------------------

alter table LabTestsEXT
drop constraint uqSubTestCodeLabTestsEXT

alter table LabTestsEXT
drop constraint uqSubTestName

alter table LabTestsEXT
add constraint uqTestCodeSubTestName unique(TestCode, SubTestName)

---------------------------------------------------------------------------------
---------------Added update on Sun 19-09-2010 -----------------------------------
---------------------------------------------------------------------------------

	--select * from ExternalLabResults
	drop table ExternalLabResults
	drop proc uspEditExternalLabResults
	drop proc uspGetExternalLabResults

---------------------------------------------------------------------------------
--------------ClinicalFindings---------------------------------------------------
---------------------------------------------------------------------------------

alter table ClinicalFindings add
Respiratory varchar(100) null 

update ClinicalFindings set Respiratory = ''
where Respiratory is null

-------------RadiologyExaminations------------------------------------------------

create table RadiologyExaminations
(ExamCode varchar(20) not null constraint pkExamCode primary key,
ExamName varchar(40) constraint uqExamName unique,
RadiologyCategoriesID varchar(10) constraint fkRadiologyCategoriesIDRadiologyExaminations references LookupData (DataID),
UnitPrice money
)
go

-------------RadiologyReports-----------------------------------------------------

create table RadiologyReports
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDRadiologyReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID),
constraint pkVisitNoItemCodeItemCategoryIDRadiologyReports primary key(VisitNo, ItemCode, ItemCategoryID),
ExamDateTime smalldatetime,
Report varchar(2000),
Conclusion varchar(200),
Radiologist varchar(10) constraint fkRadiologistRadiologyReports references Staff (StaffNo),
LoginID varchar(20) constraint fkLoginIDRadiologyReports references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeRadiologyReports default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Sat 16-10-2010 -----------------------------------
---------------------------------------------------------------------------------

-------------- SearchObjects -------------------------------------------------------------------------
alter table SearchObjects add
SearhInclude bit not null constraint dfSearhInclude default 1

------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Fri 22-10-2010 -----------------------------------
---------------------------------------------------------------------------------

-------------- Patients -----------------------------------------------------------------------------

alter table Patients add
ReferenceNo varchar(20)

update Patients set ReferenceNo = ''
where ReferenceNo is null

-----------Allergies----------------------------------------------------------------------------------

alter table Allergies
drop constraint fkPatientNoAllergies

alter table Allergies
drop constraint fkDrugNoAllergies

alter table Allergies add 
constraint fkPatientNoAllergies  foreign key (PatientNo) references Patients(PatientNo)
on delete cascade on update cascade

alter table Allergies add
constraint fkDrugNoAllergies foreign key (DrugNo) References  Drugs(DrugNo)
on delete cascade on update cascade

----------GetDoctor-----------------------------------------------------------------------------------
	drop function GetDoctor

----------Alerts---------------------------------------------------------------------------------------
drop table Alerts

create table Alerts
(AlertID int not null identity(1,1) constraint pkAlertID primary key,
AlertTypeID varchar(10) constraint fkAlertTypeIDAlerts references LookupData (DataID),
VisitNo varchar(20) constraint fkVisitNoAlerts references Visits (VisitNo)
on delete cascade on update cascade,
StaffNo varchar(10) constraint fkStaffNoAlerts references Staff (StaffNo)
on delete cascade on update cascade,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDAlerts references Logins (LoginID),
SentDate smalldatetime constraint uqAlertTypeIDVisitNoSentDate unique(AlertTypeID, VisitNo, SentDate),
SentTime varchar(8)
)
go


alter table Alerts add
Notes varchar(200) null 

update Alerts set Notes = ''
where Notes is null

---------------------------------------------------------------------------------
---------------Added update on Tue 16-11-2010 -----------------------------------
---------------------------------------------------------------------------------

---------StaffEXT---------------------------------------------------------------------------------

-- select * from ObjectRoles where ObjectName = 'StaffEXT'
delete from ObjectRoles where ObjectName = 'StaffEXT'

-- select * from AuditTrail where ObjectName = 'StaffEXT'
delete from AuditTrail where ObjectName = 'StaffEXT'

-- select * from AccessObjects where ObjectName = 'StaffEXT'
delete from AccessObjects where ObjectName = 'StaffEXT'

----------ServicesDrSpecialtyFee----------------------------------------------------------------------

create table ServicesDrSpecialtyFee
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesDrSpecialtyFee 
references Services (ServiceCode) on delete cascade on update cascade,
DoctorSpecialtyID varchar(10) not null constraint fkDoctorSpecialtyIDServicesDrSpecialtyFee references LookupData (DataID),
constraint pkServiceCodeDoctorSpecialtyID primary key(ServiceCode, DoctorSpecialtyID),
SpecialtyFee money
)
go

------------ServicesStaffFee----------------------------------------------------------------------

create table ServicesStaffFee
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesStaffFee 
references Services (ServiceCode) on delete cascade on update cascade,
StaffNo varchar(10) not null constraint fkStaffNoServicesStaffFee references Staff (StaffNo),
constraint pkServiceCodeStaffNo primary key(ServiceCode, StaffNo),
StaffFee money
)
go

-----------------------------------------------------------------------------------------------------

-----------Staff-------------------------------------------------------------------------------------
alter table Staff add
DoctorSpecialtyID varchar(10) null constraint fkDoctorSpecialtyIDStaff references LookupData (DataID)

update Staff set DoctorSpecialtyID = '39GEN' where DoctorSpecialtyID is null and StaffTitleID = '20DR'

insert into ServicesStaffFee (ServiceCode, StaffNo, StaffFee)
select '10C', StaffNo, ConsultationFee from StaffEXT

-- run below as well
drop trigger utrUpdateStaffEXT
drop trigger utrDeleteStaffEXT
drop proc uspInsertStaffEXT
drop proc uspUpdateStaffEXT
drop proc uspGetStaffEXT

drop table StaffEXT

-----------Visits----------------------------------------------------------------------------------
alter table Visits add
DoctorSpecialtyID varchar(10) constraint fkDoctorSpecialtyIDVisits references LookupData (DataID)

update Visits set DoctorSpecialtyID = '39GEN' where DoctorSpecialtyID is null

---------------------------------------------------------------------------------
---------------Added update on Thur 16-12-2010 ----------------------------------
---------------------------------------------------------------------------------

-----------DoctorVisits----------------------------------------------------------------------------------

alter table DoctorVisits add
ServiceCode varchar(10) constraint fkServiceCodeDoctorVisits references Services(ServiceCode)

update DoctorVisits set ServiceCode = '10C' where ServiceCode is null

-----------Referrals----------------------------------------------------------------------------------

create table Referrals
(VisitNo varchar(20) not null constraint pkVisitNoReferrals primary key
constraint fkVisitNoReferrals references DoctorVisits (VisitNo)
on delete cascade on update cascade,
ReferralDate smalldatetime,
ReferredBy varchar(10) constraint fkReferredByReferrals references Staff (StaffNo),
ReferredTo varchar(10) constraint fkReferredToReferrals references Staff (StaffNo),
ReferralNotes varchar(4000),
LoginID varchar(20) constraint fkLoginIDReferrals references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeReferrals default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Wen 05-01-2011 -----------------------------------
---------------------------------------------------------------------------------

create table Rooms
(RoomNo varchar(20) not null constraint pkRoomNo primary key,
RoomName varchar(41) constraint uqRoomName unique,
WardsID varchar(10) constraint fkWardsIDRooms references LookupData (DataID)
)
go

create table Beds
(BedNo varchar(20) not null constraint pkBedNo primary key,
BedName varchar(41) constraint uqBedName unique,
RoomNo varchar(20) constraint fkRoomNoBeds references Rooms (RoomNo),
UnitPrice money
)
go

-----------Admissions----------------------------------------------------------------------------------
alter table Admissions add
BedNo varchar(20) constraint fkBedNoAdmissions references Beds (BedNo)

-----------ClinicalFindings----------------------------------------------------------------------------------

alter table ClinicalFindings
drop constraint fkVisitNoClinicalFindings

alter table ClinicalFindings add 
constraint fkVisitNoClinicalFindings foreign key (VisitNo) references Visits (VisitNo)
on delete cascade on update cascade

-----------Referrals----------------------------------------------------------------------------------

alter table Referrals
drop constraint fkVisitNoReferrals

alter table Referrals add 
constraint fkVisitNoReferrals foreign key (VisitNo) references Visits (VisitNo)
on delete cascade on update cascade

alter table Referrals add
DoctorSpecialtyID varchar(10) constraint fkDoctorSpecialtyIDReferrals references LookupData (DataID)

update Referrals set DoctorSpecialtyID = '39GEN' where DoctorSpecialtyID is null

-----------Appointments----------------------------------------------------------------------------------

alter table Appointments add
DoctorSpecialtyID varchar(10) constraint fkDoctorSpecialtyIDAppointments references LookupData (DataID)

update Appointments set DoctorSpecialtyID = '39GEN' where DoctorSpecialtyID is null

---------------------------------------------------------------------------------
---------------Added update on Sun 13-02-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------IPDLaboratory---------------------------------------------------------------------------------
select * from ObjectRoles where ObjectName = 'IPDLaboratory'
delete from ObjectRoles where ObjectName = 'IPDLaboratory'

-----------After Clearing Search Columns-----------------------------------------------
delete from AccessObjects where ObjectName = 'IPDLaboratory'

drop trigger utrUpdateIPDLaboratory
drop trigger utrDeleteIPDLaboratory

drop proc uspEditIPDLaboratory
drop proc uspUpdateIPDLaboratory
drop proc uspDeleteIPDLaboratory
drop proc uspGetIPDLaboratory
drop proc uspGetIPDLab

drop proc uspEditIPDItems
drop proc uspUpdateIPDItems
drop proc uspDeleteIPDItems
drop proc uspGetIPDItems
drop proc uspGetIPDLab

create table IPDDoctor
(RoundID int not null constraint dfRoundIDIPDDoctor default 1,
RoundNo varchar(20) not null constraint pkRoundNo primary key,
AdmissionNo varchar(20) constraint fkAdmissionNoIPDDoctor references Admissions (AdmissionNo),
StaffNo varchar(10) constraint fkStaffNoIPDDoctor references Staff (StaffNo),
RoundDateTime smalldatetime,
ClinicalNotes varchar(4000),
LoginID varchar(20) constraint fkLoginIDIPDDoctor references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDDoctor default getdate()
)
go

create table IPDItems
(RoundNo varchar(20) not null constraint fkRoundNoIPDItems references IPDDoctor(RoundNo),
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDIPDItems references LookupData (DataID)
constraint pkRoundNoItemCodeItemCategoryID primary key (RoundNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice money ,
ItemDetails varchar(40) ,
LastUpdate smalldatetime ,
ItemStatusID varchar(10) constraint fkItemStatusIDIPDItems references LookupData (DataID),
PayStatusID varchar(10) constraint fkPayStatusIDIPDItems references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDIPDItems references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDItems default getdate()
)
go

create table IPDItemsEXT
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDItemsEXT  foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDItemsEXT primary key (RoundNo, ItemCode, ItemCategoryID),
Dosage varchar(40),
Duration int
)
go

create table LabRequestsIPD
(SpecimenNo varchar(20) not null
constraint fkSpecimenNoLabRequestsIPD references LabRequests (SpecimenNo)
on delete cascade on update cascade constraint pkSpecimenNoLabRequestsIPD primary key,
RoundNo varchar(20) not null constraint uqRoundNoLabRequestsIPD unique
constraint fkRoundNoLabRequestsIPD references IPDDoctor (RoundNo)
)
go

---------------------------------------------------------------------------------
---------------Added update on Sat 12-03-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------ExtraChargeItems-------------------------------------------------------

create table ExtraChargeItems
(ExtraItemCode varchar(20) not null constraint pkExtraItemCode primary key,
ExtraItemName varchar(40) constraint uqExtraItemName unique,
UnitPrice money
)
go

---------------------------------------------------------------------------------
---------------Added update on Mon 28-03-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------Patients--------------------------------------------------------------

alter table Patients add
Fingerprint image

---------------------------------------------------------------------------------
---------------Added update on Mon 25-04-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------IPDClinicalFindings---------------------------------------------------

create table IPDClinicalFindings
(RoundNo varchar(20) not null constraint pkRoundNoIPDClinicalFindings primary key
constraint fkRoundNoIPDClinicalFindings references IPDDoctor (RoundNo)
on delete cascade on update cascade,
History varchar(100),
ClinicalNotes varchar(4000),
Respiratory varchar(100),
GeneralAppearance varchar(100),
CVS varchar(100),
Abdomen varchar(100),
CNS varchar(100),
MuscularSkeletal varchar(100),
PsychologicalStatus varchar(100),
ClinicalDiagnosis varchar(100),
ClinicalImage image,
LoginID varchar(20) constraint fkLoginIDIPDClinicalFindings references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDClinicalFindings default getdate()
)
go

--------------IPDDoctor---------------------------------------------------------------------------------------

select RoundNo, ClinicalNotes from IPDDoctor
where not ClinicalNotes = ''

alter table IPDDoctor 
drop column ClinicalNotes
go

---------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Tue 30-04-2011 -----------------------------------
---------------------------------------------------------------------------------

--------------Visits-------------------------------------------------------------

alter table Visits add
FingerprintVerified bit constraint dfFingerprintVerifiedVisits default 0

update Visits set FingerprintVerified = 0
where FingerprintVerified is null

---------------------------------------------------------------------------------
---------------Added update on Wen 11-05-2011 -----------------------------------
---------------------------------------------------------------------------------

create table IPDAlerts
(AlertID int not null identity(1,1) constraint pkAlertIDIPDAlerts primary key,
AlertTypeID varchar(10) constraint fkAlertTypeIDIPDAlerts references LookupData (DataID),
RoundNo varchar(20) constraint fkRoundNoIPDAlerts references IPDDoctor (RoundNo)
on delete cascade on update cascade,
StaffNo varchar(10) constraint fkStaffNoIPDAlerts references Staff (StaffNo)
on delete cascade on update cascade,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDAlerts references Logins (LoginID),
SentDate smalldatetime constraint uqAlertTypeIDRoundNoSentDate unique(AlertTypeID, RoundNo, SentDate),
SentTime varchar(8)
)
go

------------LabRequestsIPD-----------------------------------------------------------------------------------

alter table LabRequestsIPD 
drop constraint uqRoundNoLabRequestsIPD 
go

---------------------------------------------------------------------------------
---------------Added update on Sat 21-05-2011 -----------------------------------
---------------------------------------------------------------------------------
------------IPDClinicalFindings-------------------------------------------------------------------------------------

alter table IPDClinicalFindings add
Weight decimal(5,2) constraint ckWeightIPDClinicalFindings check (Weight > 0 and Weight <= 200),
Temperature decimal(5,2) constraint ckTemperatureIPDClinicalFindings check (Temperature > 30 and Temperature < 50),
Height decimal(5,2) constraint ckHeightIPDClinicalFindings check (Height > 40 and Height < 300),
Pulse tinyint constraint ckPulseIPDClinicalFindings check (Pulse > 40 and Pulse <= 300),
BloodPressure varchar(10),
HeadCircum decimal(5,2) constraint ckHeadCircumIPDClinicalFindings check (HeadCircum > 20 and HeadCircum < 150),
BodySurfaceArea decimal(10,2)

---------------------------------------------------------------------------------
---------------Added update on Wen 25-05-2011 -----------------------------------
---------------------------------------------------------------------------------

----------------Illnesses------------------------------------------------------------------------------------

select * from Illnesses
drop table Illnesses

create table Diagnosis
(VisitNo varchar(20) constraint fkVisitNoDiagnosis references Visits(VisitNo) ,
DiagnosisID varchar(10) constraint fkDiagnosisIDDiagnosis references LookupData (DataID),
constraint pkVisitNoDiagnosisID primary key (VisitNo, DiagnosisID),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDDiagnosis references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeDiagnosis default getdate()
)
go

-----------Illnesses-----------------------------------------------------------------------------------------
select * from ObjectRoles where ObjectName = 'Illnesses'
delete from ObjectRoles where ObjectName = 'Illnesses'

-----------After Clearing Search Columns---------------------------------------------------------------------
delete from AccessObjects where ObjectName = 'Illnesses'

drop trigger utrUpdateIllnesses
drop trigger utrDeleteIllnesses

drop proc uspEditIllnesses
drop proc uspGetIllnesses

delete from LookupData where ObjectID = '33'

---------------------------------------------------------------------------------
---------------Added update on Sun 29-05-2011 -----------------------------------
---------------------------------------------------------------------------------

----------------IPDDiagnosis------------------------------------------------------------------------------------

create table IPDDiagnosis
(RoundNo varchar(20) constraint fkRoundNoIPDDiagnosis references IPDDoctor(RoundNo) ,
DiagnosisID varchar(10) constraint fkDiagnosisIDIPDDiagnosis references LookupData (DataID),
constraint pkRoundNoDiagnosisID primary key (RoundNo, DiagnosisID),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDDiagnosis references Logins (LoginID), 
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDDiagnosis default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Fri 03-06-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------PaymentDetails----------------------------------------------------------------------------------

alter table PaymentDetails add
Quantity int, UnitPrice money

--------run cursor below, but be very carefull--------------------------------------------------------------
declare @ReceiptNo varchar(20)
declare @VisitNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)

declare @Quantity int
declare @UnitPrice money

DECLARE PaymentDetails_Cursor INSENSITIVE CURSOR FOR

SELECT Payments.ReceiptNo, VisitNo, ItemCode, ItemCategoryID FROM PaymentDetails
inner join Payments on PaymentDetails.ReceiptNo = Payments.ReceiptNo

OPEN PaymentDetails_Cursor
FETCH NEXT FROM PaymentDetails_Cursor INTO @ReceiptNo, @VisitNo, @ItemCode, @ItemCategoryID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		set @Quantity = (select Quantity from Items
			where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)

		set @UnitPrice = (select UnitPrice from Items
			where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)

		UPDATE PaymentDetails Set Quantity = @Quantity, UnitPrice = @UnitPrice 
		WHERE ReceiptNo = @ReceiptNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		FETCH NEXT FROM PaymentDetails_Cursor INTO @ReceiptNo, @VisitNo, @ItemCode, @ItemCategoryID
	END
CLOSE PaymentDetails_Cursor
deallocate PaymentDetails_Cursor

----------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Thur 16-06-2011 ----------------------------------
---------------------------------------------------------------------------------

-----------Staff---------------------------------------------------------

alter table Staff add
Hidden bit constraint dfHiddenStaff default 0
update Staff set Hidden = 0 where Hidden is null

-----------BillCustomers---------------------------------------------------------

alter table BillCustomers add
Hidden bit constraint dfHiddenBillCustomers default 0
update BillCustomers set Hidden = 0 where Hidden is null

-----------Services---------------------------------------------------------

alter table Services add
Hidden bit constraint dfHiddenServices default 0
update Services set Hidden = 0 where Hidden is null

-----------Drugs---------------------------------------------------------

alter table Drugs add
Hidden bit constraint dfHiddenDrugs default 0
update Drugs set Hidden = 0 where Hidden is null

-----------LabTests---------------------------------------------------------

alter table LabTests add
Hidden bit constraint dfHiddenLabTests default 0
update LabTests set Hidden = 0 where Hidden is null

-----------LabTestsEXT---------------------------------------------------------

alter table LabTestsEXT add
Hidden bit constraint dfHiddenLabTestsEXT default 0
update LabTestsEXT set Hidden = 0 where Hidden is null

-----------RadiologyExaminations---------------------------------------------------------

alter table RadiologyExaminations add
Hidden bit constraint dfHiddenRadiologyExaminations default 0
update RadiologyExaminations set Hidden = 0 where Hidden is null

---------------------------------------------------------------------------------
---------------Added update on Thur 23-06-2011 ----------------------------------
---------------------------------------------------------------------------------

-----------DoctorVisits---------------------------------------------------------

alter table DoctorVisits add
Closed bit constraint dfClosedDoctorVisits default 0

update DoctorVisits set Closed = 0 where Closed is null

------Options---------------------------------------------------------
exec uspEditOptions 'NoNegativeDrugUnitsInStock', 0, '3BIT', 1

-- run special update for options or common

alter table Options add
Hidden bit not null constraint dfHiddenOptions default 0 

---------------------------------------------------------------------------------
---------------Added update on Mon 18-07-2011 -----------------------------------
---------------------------------------------------------------------------------

-- run common scripts

exec uspEditOptions 'IncorporateFingerprintCapture', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowPartialCashPayment', 0, '3BIT', 1, 0

------Templates---------------------------------------------------------

create table Templates
(TemplateName varchar(40) not null constraint pkTemplateName primary key,
TemplateTypeID varchar(10) constraint fkTemplateTypeIDTemplates references LookupData (DataID),
Notes varchar(2000)
)
go

---------------------------------------------------------------------------------
---------------Added update on Sat 30-07-2011 -----------------------------------
---------------------------------------------------------------------------------

------LookupData-----------------------------------------------------------------

alter table LookupData add
IsHidden char(1) not null constraint dfIsHidden default 'N'--,Y-Yes, N-No
constraint ckIsHidden check (IsHidden in ('Y','N'))

-- run common scripts

drop table CompanyMembers
go

drop proc uspInsertCompanyMembers
drop proc uspUpdateCompanyMembers
drop proc uspGetCompanyMembers
go


create table Insurances
(InsuranceID int not null constraint dfInsuranceIDInsurances default 1,
InsuranceNo varchar(20) not null constraint pkInsuranceNo primary key,
InsuranceName varchar(60) constraint uqInsuranceName unique,
ContactPerson varchar(40),
Address varchar(100),
Phone varchar(100),
Fax varchar(100),
Email varchar(100),
Website varchar(100),
LogoPhoto image,
MemberDeclaration varchar(800),
DoctorDeclaration varchar(800),
UseCustomFee bit constraint dfUseCustomFeeInsurances default 0,
Hidden bit constraint dfHiddenInsurances default 0
)
go


create table InsurancePolicies
(PolicyID int not null constraint dfPolicyIDInsurancePolicies default 1,
PolicyNo varchar(20) not null constraint pkPolicyNo primary key,
InsuranceNo varchar(20) constraint fkInsuranceNoInsurancePolicies references Insurances (InsuranceNo),
PolicyName varchar(40) constraint uqPolicyName unique,
LoginID varchar(20) constraint fkLoginIDInsurancePolicies references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeInsurancePolicies default getdate()
)
go

create table Companies
(CompanyID int not null constraint dfCompanyIDCompanies default 1,
CompanyNo varchar(20) not null constraint pkCompanyNo primary key,
CompanyName varchar(60) constraint uqCompanyName unique,
ContactPerson varchar(100),
Address varchar(200),
Phone varchar(30)
)
go

create table InsuranceSchemes
(CompanyNo varchar(20) not null
constraint fkCompanyNoInsuranceSchemes references Companies (CompanyNo),
PolicyNo varchar(20) not null
constraint fkPolicyNoInsuranceSchemes references InsurancePolicies (PolicyNo),
constraint pkCompanyNoPolicyNo primary key(CompanyNo, PolicyNo),
SchemeJoinDate smalldatetime,
SchemeStartDate smalldatetime,
SchemeEndDate smalldatetime,
CoPayTypeID varchar(10) constraint fkCoPayTypeIDInsuranceSchemes references LookupData (DataID),
CoPayPercent decimal(5,2) constraint ckCoPayPercentInsuranceSchemes check (CoPayPercent >= 0 and CoPayPercent <= 100),
CoPayValue money,
AnnualPremium money,
MemberPremium money,
SmartCardApplicable bit constraint dfSmartCardApplicableInsuranceSchemes default 0,
SchemeStatusID varchar(10) constraint fkSchemeStatusIDInsuranceSchemes references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDInsuranceSchemes references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeInsuranceSchemes default getdate()
)
go

create table InsuranceCustomFee
(InsuranceNo varchar(20) not null constraint fkInsuranceNoInsuranceCustomFee 
references Insurances (InsuranceNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInsuranceCustomFee references LookupData (DataID),
constraint pkInsuranceNoItemCodeItemCategoryID primary key(InsuranceNo, ItemCode, ItemCategoryID),
CustomFee money
)
go

create table InsuranceExcludedItems
(CompanyNo varchar(20) not null,
PolicyNo varchar(20) not null,
constraint fkCompanyNoPolicyNoInsuranceExcludedItems foreign key (CompanyNo, PolicyNo)
references InsuranceSchemes (CompanyNo, PolicyNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInsuranceExcludedItems references LookupData (DataID),
constraint pkCompanyNoPolicyNoItemCodeItemCategoryIDInsuranceExcludedItems 
primary key(CompanyNo, PolicyNo, ItemCode, ItemCategoryID)
)
go

create table SchemeMembers
(MedicalCardNo varchar(20) not null constraint pkMedicalCardNo primary key,
CompanyNo varchar(20),
PolicyNo varchar(20),
constraint fkCompanyNoPolicyNoSchemeMembers foreign key (CompanyNo, PolicyNo)
references InsuranceSchemes (CompanyNo, PolicyNo),
ReferenceNo varchar(20),
Surname varchar(20),
FirstName varchar(20),
MiddleName varchar(20),
BirthDate smalldatetime,
GenderID varchar(10) constraint fkGenderIDSchemeMembers references LookupData (DataID),
Address varchar(100),
PhoneWork varchar(30),
PhoneMobile varchar(30),
PhoneHome varchar(30),
Photo image,
Fingerprint image,
JoinDate smalldatetime,
MemberTypeID varchar(10) constraint fkMemberTypeIDSchemeMembers references LookupData (DataID),
MainMemberNo varchar(20) null constraint fkMainMemberNoSchemeMembers references SchemeMembers (MedicalCardNo),
PolicyStartDate smalldatetime,
PolicyEndDate smalldatetime,
MemberStatusID varchar(10) constraint fkMemberStatusIDSchemeMembers references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDSchemeMembers references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeSchemeMembers default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Sun 14-08-2011 -----------------------------------
---------------------------------------------------------------------------------

create table Procedures
(ProcedureCode varchar(10) not null constraint pkProcedureCode primary key,
ProcedureName varchar(800) constraint uqProcedureName unique,
ShortName varchar(200),
UnitPrice money,
Hidden bit constraint dfHiddenProcedures default 0
)
go

create table Diseases
(DiseaseCode varchar(10) not null constraint pkDiseaseCode primary key,
DiseaseName varchar(800) constraint uqDiseaseName unique,
DiseaseCategoriesID varchar(10) constraint fkDiseaseCategoriesIDDiseases references LookupData (DataID),
Hidden bit constraint dfHiddenDiseases default 0
)
go

drop table AdmissionsDiagnosis
drop trigger utrUpdateAdmissionsDiagnosis
drop trigger utrDeleteAdmissionsDiagnosis

-----------AdmissionsDiagnosis-----------------------------------------------------------------------------------------
select * from ObjectRoles where ObjectName = 'AdmissionsDiagnosis'
delete from ObjectRoles where ObjectName = 'AdmissionsDiagnosis'

-----------After Clearing Search Columns---------------------------------------------------------------------
delete from AccessObjects where ObjectName = 'AdmissionsDiagnosis'

drop proc uspEditAdmissionsDiagnosis
drop proc uspGetAdmissionsDiagnosis

-----------IPDDiagnosis------------------------------------------------------------
exec sp_rename 'IPDDiagnosis.DiagnosisID', 'DiseaseCode', 'COLUMN'
-----------------------------------------------------------------------------------

alter table IPDDiagnosis
drop constraint fkDiagnosisIDIPDDiagnosis

alter table IPDDiagnosis
drop constraint pkRoundNoDiagnosisID

alter table IPDDiagnosis
add constraint fkDiseaseCodeIPDDiagnosis foreign key (DiseaseCode) 
references Diseases (DiseaseCode)

alter table IPDDiagnosis
add constraint pkRoundNoDiseaseCode primary key(RoundNo, DiseaseCode)

-----------------------------------------------------------------------------------

-----------Diagnosis---------------------------------------------------------------
exec sp_rename 'Diagnosis.DiagnosisID', 'DiseaseCode', 'COLUMN'
-----------------------------------------------------------------------------------

alter table Diagnosis
drop constraint fkDiagnosisIDDiagnosis

alter table Diagnosis
drop constraint pkVisitNoDiagnosisID

-- select * from Diagnosis
-- delete from Diagnosis

alter table Diagnosis
add constraint fkDiseaseCodeDiagnosis foreign key (DiseaseCode) 
references Diseases (DiseaseCode)

alter table Diagnosis
add constraint pkVisitNoDiseaseCode primary key(VisitNo, DiseaseCode)

----------- Options -----------------------------------------------------------------------

exec uspEditOptions 'AllowAccessCashServices', 0, '3BIT', 1, 0

-------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Mon 05-09-2011 -----------------------------------
---------------------------------------------------------------------------------

drop table PolicyLimits

delete from ObjectRoles where ObjectName = 'PolicyLimits'
-- delete from SearchColumns
-- delete from SearchObjects
-- select * from AuditTrail where ObjectName = 'PolicyLimits'
delete from AuditTrail where ObjectName = 'PolicyLimits'
delete from AccessObjects where ObjectName = 'PolicyLimits'

	drop proc uspEditPolicyLimits
	drop proc uspGetPolicyLimits

---------------------------------------------------------------------------------
---------------Added update on Sat 10-09-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------Patients--------------------------------------------------------------

alter table Patients add
DefaultBillModesID Varchar(10) constraint fkDefaultBillModesIDPatients references LookupData (DataID)

--select * from Patients 
--where DefaultBillModesID is null and not DefaultAccountNo = 'CASH'

update Patients set DefaultBillModesID = '17C' where DefaultBillModesID is null and DefaultAccountNo = 'CASH'
update Patients set DefaultBillModesID = '17A' where DefaultBillModesID is null and not DefaultAccountNo = 'CASH'

alter table Patients
drop constraint fkDefaultAccountNoPatients

-----------Patients----------------------------------------------------------------
exec sp_rename 'Patients.DefaultAccountNo', 'DefaultBillNo', 'COLUMN'
exec sp_rename 'Patients.EnforceDefaultAccountNo', 'EnforceDefaultBillNo', 'COLUMN'
-----------------------------------------------------------------------------------

alter table Patients add
NOKRelationship varchar(20)

alter table Patients 
drop column MedicalCardNo
go

alter table Visits
drop constraint fkAccountNoVisits

-----------Visits------------------------------------------------------------------
exec sp_rename 'Visits.AccountNo', 'BillNo', 'COLUMN'
-----------------------------------------------------------------------------------

alter table Visits
drop constraint fkInsuranceNoVisits

alter table Visits 
drop column InsuranceNo

create table BillCustomFee
(AccountNo varchar(20) not null 
constraint fkAccountNoBillCustomFee references BillCustomers (AccountNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDBillCustomFee references LookupData (DataID),
constraint pkAccountNoItemCodeItemCategoryIDBillCustomFee primary key(AccountNo, ItemCode, ItemCategoryID),
CustomFee money
)
go

create table BillExcludedItems
(AccountNo varchar(20) not null
constraint fkAccountNoBillExcludedItems references BillCustomers (AccountNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDBillExcludedItems references LookupData (DataID),
constraint pkAccountNoItemCodeItemCategoryIDBillExcludedItems primary key(AccountNo, ItemCode, ItemCategoryID)
)
go

insert into BillCustomFee (AccountNo, ItemCode, ItemCategoryID, CustomFee)
select AccountNo, ExamCode, '7R' as ItemCategoryID, CustomFee from RadiologyCustomFee

insert into BillExcludedItems (AccountNo, ItemCode, ItemCategoryID)
select AccountNo, ExamCode, '7R' as ItemCategoryID from BillExcludedRadiology

drop table RadiologyCustomFee
drop table BillExcludedRadiology

insert into BillCustomFee (AccountNo, ItemCode, ItemCategoryID, CustomFee)
select AccountNo, TestCode, '7T' as ItemCategoryID, CustomFee from LabTestsCustomFee

insert into BillExcludedItems (AccountNo, ItemCode, ItemCategoryID)
select AccountNo, TestCode, '7T' as ItemCategoryID from BillExcludedLabTests

drop table LabTestsCustomFee
drop table BillExcludedLabTests

insert into BillCustomFee (AccountNo, ItemCode, ItemCategoryID, CustomFee)
select AccountNo, DrugNo, '7D' as ItemCategoryID, CustomFee from DrugsCustomFee

insert into BillExcludedItems (AccountNo, ItemCode, ItemCategoryID)
select AccountNo, DrugNo, '7D' as ItemCategoryID from BillExcludedDrugs

drop table DrugsCustomFee
drop table BillExcludedDrugs

insert into BillCustomFee (AccountNo, ItemCode, ItemCategoryID, CustomFee)
select AccountNo, ServiceCode, '7S' as ItemCategoryID, CustomFee from ServicesCustomFee

insert into BillExcludedItems (AccountNo, ItemCode, ItemCategoryID)
select AccountNo, ServiceCode, '7S' as ItemCategoryID from BillExcludedServices

drop table ServicesCustomFee
drop table BillExcludedServices

delete from ObjectRoles where ObjectName = 'DrugsCustomFee'
delete from AuditTrail where ObjectName = 'DrugsCustomFee'
delete from AccessObjects where ObjectName = 'DrugsCustomFee'

delete from ObjectRoles where ObjectName = 'BillExcludedDrugs'
delete from AuditTrail where ObjectName = 'BillExcludedDrugs'
delete from AccessObjects where ObjectName = 'BillExcludedDrugs'

delete from ObjectRoles where ObjectName = 'ServicesCustomFee'
delete from AuditTrail where ObjectName = 'ServicesCustomFee'
delete from AccessObjects where ObjectName = 'ServicesCustomFee'

delete from ObjectRoles where ObjectName = 'BillExcludedServices'
delete from AuditTrail where ObjectName = 'BillExcludedServices'
delete from AccessObjects where ObjectName = 'BillExcludedServices'

delete from ObjectRoles where ObjectName = 'LabTestsCustomFee'
delete from AuditTrail where ObjectName = 'LabTestsCustomFee'
delete from AccessObjects where ObjectName = 'LabTestsCustomFee'

delete from ObjectRoles where ObjectName = 'BillExcludedLabTests'
delete from AuditTrail where ObjectName = 'BillExcludedLabTests'
delete from AccessObjects where ObjectName = 'BillExcludedLabTests'

delete from ObjectRoles where ObjectName = 'RadiologyCustomFee'
delete from AuditTrail where ObjectName = 'RadiologyCustomFee'
delete from AccessObjects where ObjectName = 'RadiologyCustomFee'

delete from ObjectRoles where ObjectName = 'BillExcludedRadiology'
delete from AuditTrail where ObjectName = 'BillExcludedRadiology'
delete from AccessObjects where ObjectName = 'BillExcludedRadiology'

drop proc uspEditDrugsCustomFee
drop proc uspGetDrugsCustomFee

drop proc uspEditBillExcludedDrugs
drop proc uspGetBillExcludedDrugs

drop proc uspEditServicesCustomFee
drop proc uspGetServicesCustomFee

drop proc uspEditBillExcludedServices
drop proc uspGetBillExcludedServices

drop proc uspEditLabTestsCustomFee
drop proc uspGetLabTestsCustomFee

drop proc uspEditBillExcludedLabTests
drop proc uspGetBillExcludedLabTests

drop proc uspEditRadiologyCustomFee
drop proc uspGetRadiologyCustomFee

drop proc uspEditBillExcludedRadiology
drop proc uspGetBillExcludedRadiology

alter table RadiologyReports add
Indication varchar(4000)

update RadiologyReports set Indication = ''
where Indication is null

alter table RadiologyReports
alter column Report varchar(4000)

alter table RadiologyReports
alter column Conclusion varchar(4000)

alter table Items
alter column ItemDetails varchar(800)

alter table IPDItems
alter column ItemDetails varchar(800)

---------------------------------------------------------------------------------
---------------Added update on Fri 07-10-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------HealthUnits-----------------------------------------------------------

alter table HealthUnits 
add ContactPerson varchar(40)

update HealthUnits set ContactPerson = '' where ContactPerson is null

alter table HealthUnits add 
Address varchar(100)

update HealthUnits set Address = '' where Address is null

alter table HealthUnits 
add Phone varchar(30)

update HealthUnits set Phone = '' where Phone is null

alter table HealthUnits
add constraint uqHealthUnitName unique(HealthUnitName)

create table HealthUnits
(HealthUnitCode varchar(10) not null constraint pkHealthUnitCode primary key,
HealthUnitName varchar(41) constraint uqHealthUnitName unique,
DistrictsID varchar(10) constraint fkDistrictsIDHealthUnits references LookupData (DataID),
ContactPerson varchar(40),
Address varchar(100),
Phone varchar(30)
)
go

drop table Dependants

delete from ObjectRoles where ObjectName = 'Dependants'
delete from AuditTrail where ObjectName = 'Dependants'
delete from AccessObjects where ObjectName = 'Dependants'

drop function GetDependantsNo
drop proc uspEditDependants
drop proc uspGetDependants

create table IPDRadiologyReports
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDRadiologyReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID),
constraint pkRoundNoItemCodeItemCategoryIDIPDRadiologyReports primary key(RoundNo, ItemCode, ItemCategoryID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Report varchar(4000),
Conclusion varchar(4000),
Radiologist varchar(10) constraint fkRadiologistIPDRadiologyReports references Staff (StaffNo),
LoginID varchar(20) constraint fkLoginIDIPDRadiologyReports references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDRadiologyReports default getdate()
)
go

alter table Drugs add
UnitsInStock int constraint dfUnitsInStockDrugs default 0

update Drugs set UnitsInStock = dbo.GetInventoryBalance(DrugNo)

alter table ItemsEXT add DrQuantity int 
alter table IPDItemsEXT add DrQuantity int 

--------run cursor below, but be very carefull--------------------------------------------------------------

declare @VisitNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)
declare @Quantity int

DECLARE ItemsEXT_Cursor INSENSITIVE CURSOR FOR

select ItemsEXT.VisitNo, ItemsEXT.ItemCode, ItemsEXT.ItemCategoryID, Quantity
from ItemsEXT
inner join Items on ItemsEXT.VisitNo = Items.VisitNo 
and ItemsEXT.ItemCode = Items.ItemCode 
and ItemsEXT.ItemCategoryID = Items.ItemCategoryID

OPEN ItemsEXT_Cursor
FETCH NEXT FROM ItemsEXT_Cursor INTO @VisitNo, @ItemCode, @ItemCategoryID, @Quantity
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		UPDATE ItemsEXT Set DrQuantity = @Quantity
		WHERE VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		FETCH NEXT FROM ItemsEXT_Cursor INTO @VisitNo, @ItemCode, @ItemCategoryID, @Quantity
	END
CLOSE ItemsEXT_Cursor
deallocate ItemsEXT_Cursor

------------------------------------------------------------------------------------------------------------

--------run cursor below, but be very carefull--------------------------------------------------------------
declare @RoundNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)
declare @Quantity int

DECLARE IPDItemsEXT_Cursor INSENSITIVE CURSOR FOR

select IPDItemsEXT.RoundNo, IPDItemsEXT.ItemCode, IPDItemsEXT.ItemCategoryID, Quantity
from IPDItemsEXT
inner join IPDItems on IPDItemsEXT.RoundNo = IPDItems.RoundNo 
and IPDItemsEXT.ItemCode = IPDItems.ItemCode 
and IPDItemsEXT.ItemCategoryID = IPDItems.ItemCategoryID

OPEN IPDItemsEXT_Cursor
FETCH NEXT FROM IPDItemsEXT_Cursor INTO @RoundNo, @ItemCode, @ItemCategoryID, @Quantity
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		UPDATE IPDItemsEXT Set DrQuantity = @Quantity
		WHERE RoundNo = @RoundNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		FETCH NEXT FROM IPDItemsEXT_Cursor INTO @RoundNo, @ItemCode, @ItemCategoryID, @Quantity
	END
CLOSE IPDItemsEXT_Cursor
deallocate IPDItemsEXT_Cursor

-------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Wen 19-10-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------Claims----------------------------------------------------------------

-- drop table ClaimDiagnosis
-- drop table ClaimDetails
-- drop table Claims

create table Claims
(ClaimID int not null constraint dfClaimIDClaims default 1,
ClaimNo varchar(20) not null constraint pkClaimNo primary key,
MedicalCardNo varchar(20) constraint fkMedicalCardNoClaims references SchemeMembers (MedicalCardNo),
PatientNo varchar(20),
VisitDate smalldatetime,
VisitTime varchar(8),
HealthUnitCode varchar(10) null constraint fkHealthUnitCodeClaims references HealthUnits (HealthUnitCode),
PrimaryDoctor varchar(41),
ClaimStatusID varchar(10) constraint fkClaimStatusIDClaims references LookupData (DataID),
ClaimEntryID varchar(10) constraint fkClaimEntryIDClaims references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDClaims references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeClaims default getdate()
)
go

create table ClaimsEXT
(ClaimNo varchar(20) not null constraint fkClaimNoClaimsEXT references Claims (ClaimNo)
on delete cascade on update cascade constraint pkClaimNoClaimsEXT primary key,
VisitNo varchar(20) not null constraint uqVisitNo unique
constraint fkVisitNoClaimsEXT references Visits (VisitNo)
on delete cascade on update cascade 
)
go

create table ClaimDiagnosis
(ClaimNo varchar(20) not null constraint fkClaimNoClaimDiagnosis 
references Claims (ClaimNo) on delete cascade on update cascade,
DiseaseCode varchar(10) not null constraint fkDiseaseCodeClaimDiagnosis references Diseases (DiseaseCode),
constraint pkClaimNoDiseaseCode primary key(ClaimNo, DiseaseCode)
)
go

create table ClaimDetails
(ClaimNo varchar(20) not null constraint fkClaimNoClaimDetails 
references Claims (ClaimNo) on delete cascade on update cascade,
ItemName varchar(100) not null,
constraint pkClaimNoItemName primary key(ClaimNo, ItemName),
ItemCategoryID varchar(10) constraint fkItemCategoryIDClaimDetails references LookupData (DataID),
Notes varchar(200),
Quantity int,
UnitPrice Money,
Amount Money
)
go

create table PolicyLimits
(CompanyNo varchar(20) not null,
PolicyNo varchar(20) not null,
constraint fkCompanyNoPolicyNoPolicyLimits foreign key (CompanyNo, PolicyNo)
references InsuranceSchemes (CompanyNo, PolicyNo)on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDPolicyLimits references LookupData (DataID),
constraint pkCompanyNoPolicyNoItemCategoryID primary key(CompanyNo, PolicyNo, ItemCategoryID),
PolicyLimit money
)
go

create table DentalServices
(DentalCode varchar(10) not null constraint pkDentalCode primary key,
DentalName varchar(200) constraint uqDentalName unique,
UnitPrice money,
Hidden bit constraint dfHiddenDentalServices default 0
)
go

drop table Licenses

create table Licenses
(LLN nvarchar(100) not null constraint pkLLNLicenses primary key, --LicenseNo
LCO nvarchar(100) not null, -- Company
LSP nvarchar(100) not null, -- SupportPhone
LSE nvarchar(100) not null, -- SupportEmail
LSW nvarchar(100) not null, -- SupportWebsite
LCI nvarchar(100) not null, -- ContactInfo
LPO nvarchar(100) not null, -- ProductOwner
--LCD nvarchar(100) not null, -- ContractDate
LSD nvarchar(100) not null, -- StartDate
LED nvarchar(100) not null, -- EndDate
LWD nvarchar(100) not null, -- WarningDays, Shut down warning days
LNU nvarchar(100) not null, -- NoUsers, Number of active users
LID nvarchar(100) not null, -- IdleDuration, Duration in minutes to close idle user
LKT nvarchar(100) not null, -- KeyTable, Key table to control records
LNR nvarchar(100) not null, -- NoRecords, Maximum allowed records for key table
LWR nvarchar(100) not null -- WarningRecords, Shut down warning records
)
go

--- run common

-----------Insurances-----------------------------------------------------------------

--- select * from Insurances

alter table Insurances
alter column Phone varchar(100)

alter table Insurances add
Fax varchar(100), Email varchar(100), Website varchar(100), LogoPhoto image,
MemberDeclaration varchar(800), DoctorDeclaration varchar(800)

update Insurances set Fax = '' where Fax is null
update Insurances set Email = '' where Email is null
update Insurances set Website = '' where Website is null
update Insurances set MemberDeclaration = '' where MemberDeclaration is null
update Insurances set DoctorDeclaration = '' where DoctorDeclaration is null

-----------InsuranceSchemes-----------------------------------------------------------------

--- select * from InsuranceSchemes

alter table InsuranceSchemes add
AnnualPremium money, MemberPremium money

update InsuranceSchemes set AnnualPremium = 0 where AnnualPremium is null
update InsuranceSchemes set MemberPremium = 0 where MemberPremium is null

---------------------------------------------------------------------------------
---------------Added update on Mon 21-11-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------InsuranceSchemes------------------------------------------------------------

alter table InsuranceSchemes 
drop constraint dfUseCustomFeeInsuranceSchemes

alter table InsuranceSchemes 
drop column UseCustomFee

go

-----------Insurances-----------------------------------------------------------------

alter table Insurances add
UseCustomFee bit constraint dfUseCustomFeeInsurances default 0

update Insurances set UseCustomFee = 0 where UseCustomFee is null
go

-----------InsuranceCustomFee----------------------------------------------------------

drop table InsuranceCustomFee

create table InsuranceCustomFee
(InsuranceNo varchar(20) not null constraint fkInsuranceNoInsuranceCustomFee 
references Insurances (InsuranceNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInsuranceCustomFee references LookupData (DataID),
constraint pkInsuranceNoItemCodeItemCategoryID primary key(InsuranceNo, ItemCode, ItemCategoryID),
CustomFee money
)
go

exec uspEditOptions 'FingerprintCaptureAgeLimit', 3, '3NUM', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Sun 04-12-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------Accounts--------------------------------------------------------------

alter table Accounts add
AccountBillModesID varchar(10) constraint fkAccountBillModesIDAccounts references LookupData (DataID)

update Accounts set AccountBillModesID = '17A' where AccountBillModesID is null

alter table Accounts
drop constraint fkAccountNoAccounts

-----------Accounts----------------------------------------------------------------
exec sp_rename 'Accounts.AccountNo', 'AccountBillNo', 'COLUMN'

exec sp_rename 'Accounts.TranID', 'AccountID', 'COLUMN'

alter table Accounts add
TranID int not null constraint dfTranID default 1

update Accounts set TranID = AccountID where TranID = 1

-----------------------------------------------------------------------------------

drop proc uspGetSeeDoctorVisits

-----------DentalReports----------------------------------------------------------------

create table DentalReports
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDDentalReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID),
constraint pkVisitNoItemCodeItemCategoryIDDentalReports primary key(VisitNo, ItemCode, ItemCategoryID),
ReportDate smalldatetime,
Report varchar(2000),
LoginID varchar(20) constraint fkLoginIDDentalReports references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDentalReports default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Sun 31-12-2011 -----------------------------------
---------------------------------------------------------------------------------

-----------Drugs-----------------------------------------------------------------
alter table Drugs add
AlternateName varchar(40), Halted bit constraint dfHaltedDrugs default 0

update Drugs set AlternateName = '' where AlternateName is null
update Drugs set Halted = 0 where Halted is null

create table AlternateDrugs
(DrugNo varchar(20) not null constraint fkDrugNoAlternateDrugs 
references Drugs (DrugNo) on delete cascade on update cascade,
AlternateDrugNo varchar(20) not null 
constraint fkAlternateDrugNoAlternateDrugs references Drugs (DrugNo),
constraint pkDrugNoAlternateDrugNo primary key(DrugNo, AlternateDrugNo)
)
go

exec uspEditOptions 'AllowCreateMultipleVisits', 0, '3BIT', 1, 0

drop function GetAvailableBalance
drop proc uspGetAvailableBalance

---------------------------------------------------------------------------------------------
---------------Added update on Sun 17-01-2012 -----------------------------------------------
---------------------------------------------------------------------------------------------

-----------BillCustomers---------------------------------------------------------------------
alter table BillCustomers add
CoPayTypeID varchar(10) constraint fkCoPayTypeIDBillCustomers references LookupData (DataID),
CoPayPercent decimal(5,2) constraint ckCoPayPercentBillCustomers check (CoPayPercent >= 0 and CoPayPercent <= 100),
CoPayValue money, CreditLimit money constraint dfCreditLimitBillCustomers default 0

update BillCustomers set CoPayTypeID = '44NA' where CoPayTypeID is null
update BillCustomers set CoPayPercent = 0 where CoPayPercent is null
update BillCustomers set CoPayValue = 0 where CoPayValue is null
update BillCustomers set CreditLimit = 0 where CreditLimit is null

-----------ItemsCASH------------------------------------------------------------------------------

create table ItemsCASH
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDItemsCASH foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDItemsCASH primary key (VisitNo, ItemCode, ItemCategoryID),
CashAmount money constraint dfCashAmountItemsCASH default 0,
CashPayStatusID varchar(10) constraint fkCashPayStatusIDItemsCASH references LookupData (DataID)
)
go

-----------InsuranceSchemes------------------------------------------------------------------------------

alter table InsuranceSchemes
add constraint ckCoPayPercentInsuranceSchemes check (CoPayPercent >= 0 and CoPayPercent <= 100)
go

-----------Visits---------------------------------------------------------------------
alter table Visits add
CoPayTypeID varchar(10) constraint fkCoPayTypeIDVisits references LookupData (DataID),
CoPayPercent decimal(5,2) constraint ckCoPayPercentVisits check (CoPayPercent >= 0 and CoPayPercent <= 100),
CoPayValue money

update Visits set CoPayTypeID = '44NA' where CoPayTypeID is null
update Visits set CoPayPercent = 0 where CoPayPercent is null
update Visits set CoPayValue = 0 where CoPayValue is null
go

-------------- ExtraChargeItems ---------------------------------------------------------------

exec uspInsertExtraChargeItems 'CPV', 'CO-PAY VALUE', 0
go

-----------ClaimsEXT----------------------------------------------------------------

alter table ClaimsEXT
drop constraint fkVisitNoClaimsEXT

alter table ClaimsEXT
add constraint fkVisitNoClaimsEXT foreign key (VisitNo) 
references Visits (VisitNo) on delete cascade on update cascade 
go

---------------------------------------------------------------------------------------------
---------------Added update on Fri 27-01-2012 -----------------------------------------------
---------------------------------------------------------------------------------------------

------Options--------------------------------------------------------------------------------
exec uspEditOptions 'DisableConstraints', 0, '3BIT', 1, 1

---------------------------------------------------------------------------------------------
---------------Added update on Wen 01-02-2012 -----------------------------------------------
---------------------------------------------------------------------------------------------

-----------BillCustomers---------------------------------------------------------------------
alter table BillCustomers add
SmartCardApplicable bit constraint dfSmartCardApplicableBillCustomers default 0

update BillCustomers set SmartCardApplicable = 0 where SmartCardApplicable is null

-----------Patients--------------------------------------------------------------------------
alter table Patients add DefaultMemberCardNo varchar(20)

update Patients set DefaultMemberCardNo = '' where DefaultMemberCardNo is null

-----------Visits----------------------------------------------------------------------------
alter table Visits add MemberCardNo varchar(20)

update Visits set MemberCardNo = '' where MemberCardNo is null

---------------------------------------------------------------------------------
---------------Added update on Sat 18-02-2012 -----------------------------------
---------------------------------------------------------------------------------

-----------ExtraBills----------------------------------------------------------------------------------------

create table ExtraBills
(ExtraBillID int not null constraint dfExtraBillIDExtraBills default 1,
ExtraBillNo varchar(20) not null constraint pkExtraBillNo primary key,
VisitNo varchar(20) constraint fkVisitNoExtraBills references Visits (VisitNo),
ExtraBillDate smalldatetime,
LoginID varchar(20) constraint fkLoginIDExtraBills references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeExtraBills default getdate()
)
go

-----------ExtraBillItems------------------------------------------------------------------------------------

create table ExtraBillItems
(ExtraBillNo varchar(20) not null constraint fkExtraBillNoExtraBillItems 
references ExtraBills (ExtraBillNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDExtraBillItems references LookupData (DataID),
constraint pkExtraBillNoItemCodeItemCategoryID primary key(ExtraBillNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice money,
Notes varchar(200),
LastUpdate smalldatetime,
PayStatusID varchar(10) constraint fkPayStatusIDExtraBillItems references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDExtraBillItems references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeExtraBillItems default getdate()
)
go

-----------ExtraBillItemsCASH------------------------------------------------------------------------------------

create table ExtraBillItemsCASH
(ExtraBillNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkExtraBillNoItemCodeItemCategoryIDExtraBillItemsCASH foreign key (ExtraBillNo, ItemCode, ItemCategoryID) 
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkExtraBillNoItemCodeItemCategoryIDExtraBillItemsCASH primary key(ExtraBillNo, ItemCode, ItemCategoryID),
CashAmount money constraint dfCashAmountExtraBillItemsCASH default 0,
CashPayStatusID varchar(10) constraint fkCashPayStatusIDExtraBillItemsCASH references LookupData (DataID)
)
go

---------------------------------------------------------------------------------
---------------Added update on Sat 10-03-2012 -----------------------------------
---------------------------------------------------------------------------------

--------------ClaimDetails-------------------------------------------------------
alter table ClaimDetails
drop constraint pkClaimNoItemName

---------------------------------------------------------------------------------
alter table ClaimDetails
alter column ItemName varchar(100) not null

---------------------------------------------------------------------------------
alter table ClaimDetails
add constraint pkClaimNoItemName primary key(ClaimNo, ItemName)

-----------Payments----------------------------------------------------------------------------------

alter table Payments add
PayTypeID varchar(10) constraint fkPayTypeIDPayments references LookupData (DataID)

update Payments set PayTypeID = '47CAS' where PayTypeID is null

alter table Payments
drop constraint fkVisitNoPayments

-----------Payments----------------------------------------------------------------
exec sp_rename 'Payments.VisitNo', 'PayNo', 'COLUMN'
-----------------------------------------------------------------------------------

update AccessObjects set ObjectCaption = 'All Payments'
where ObjectName = 'Payments'

drop proc uspGetPayments

---------------------------------------------------------------------------------
---------------Added update on Sat 24-03-2012 -----------------------------------
---------------------------------------------------------------------------------

update AccessObjects set ObjectCaption = 'All Visits'
where ObjectName = 'Visits'

-------------- SearchObjects -------------------------------------------------------------------------
alter table SearchObjects add
IsDistinct bit not null constraint dfIsDistinct default 0

-- run common

-----------Patients----------------------------------------------------------------------------------

alter table Patients add
CombinationOn varchar(30)

update Patients set CombinationOn = dbo.GetCombinationCurrentlyOn(PatientNo) where CombinationOn is null

alter table Patients add
FirstVisitDate smalldatetime, LastVisitDate smalldatetime

update Patients set FirstVisitDate = dbo.GetFirstVisitDate(PatientNo)  
update Patients set LastVisitDate = dbo.GetLastVisitDate(PatientNo) 

---------------------------------------------------------------------------------
---------------Added update on Sat 15-04-2012 -----------------------------------
---------------------------------------------------------------------------------

-- run common

alter table LabTests
alter column NormalRange varchar(200)

alter table LabTestsEXT
alter column NormalRange varchar(200)

--------------InventoryReceiving-------------------------------------------------

create table InventoryReceiving
(TranID int not null constraint fkTranIDInventoryReceiving references Inventory (TranID)
on delete cascade on update cascade constraint pkTranIDInventoryReceiving primary key,
BatchNo varchar(20),
ExpiryDate smalldatetime
)
go

---------------------------------------------------------------------------------
---------------Added update on Fri 16-06-2012 -----------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'ForceSmartCardProcessing', 1, '3BIT', 1, 0

-------------- OtherIncome ---------------------------------------------------------------------------------------

alter table OtherIncome
drop constraint fkReceivedByOtherIncome

alter table OtherIncome 
drop column ReceivedBy

alter table OtherIncome 
drop column ReceivedFrom

alter table OtherIncome add
IncomeSourcesID varchar(10) constraint fkIncomeSourcesIDOtherIncome references LookupData (DataID)

update OtherIncome set IncomeSourcesID = '48CAF' where IncomeSourcesID is null

-----------OtherIncome-------------------------------------------------------------
exec sp_rename 'OtherIncome.Details', 'Notes', 'COLUMN'
-----------------------------------------------------------------------------------

alter table OtherIncome
alter column Notes varchar(200)

---------------------------------------------------------------------------------
---------------Added update on Sun 24-06-2012 -----------------------------------
---------------------------------------------------------------------------------

-----------Payments--------------------------------------------------------------

alter table Payments add
CurrenciesID varchar(10) constraint fkCurrenciesIDPayments references LookupData (DataID),
AmountTendered money, ExchangeRate money

update Payments set CurrenciesID = '49UGX' where CurrenciesID is null
update Payments set AmountTendered = dbo.GetAmountPaid(ReceiptNo) where AmountTendered is null
update Payments set ExchangeRate = 1 where ExchangeRate is null

---------------------------------------------------------------------------------
---------------Added update on Sun 01-07-2012 -----------------------------------
---------------------------------------------------------------------------------

-----------BulkPayDetails--------------------------------------------------------

-----------After Clearing Search Columns-----------------------------------------

delete from ObjectRoles  where ObjectName = 'BulkPayDetails'
delete from AccessObjects where ObjectName = 'BulkPayDetails'

drop proc uspInsertBulkPayDetails
drop table BulkPayDetails

-----------PaymentDetails----------------------------------------------------------------------------------

alter table PaymentDetails
drop constraint pkReceiptNoItemCodeItemCategoryID

alter table PaymentDetails add VisitNo varchar(20)

update PaymentDetails set VisitNo = dbo.GetPaymentsPayNo(ReceiptNo) where VisitNo is null

alter table PaymentDetails
alter column VisitNo varchar(20) not null

alter table PaymentDetails
add constraint fkVisitNoItemCodeItemCategoryIDPaymentDetails foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on update cascade

alter table PaymentDetails
add constraint pkReceiptNoVisitNoItemCodeItemCategoryID primary key (ReceiptNo, VisitNo, ItemCode, ItemCategoryID)

-----------Payments----------------------------------------------------------------------------------
alter table Payments 
add SendBalanceToAccount bit constraint dfSendBalanceToAccountPayments default 0

update Payments set SendBalanceToAccount = 0 where SendBalanceToAccount is null

exec uspEditOptions 'SmartCardServiceProviderNo', '1234567890ABC', '3STR', 20, 0

----------------------------------------------------------------------------------------
---------------Added update on 17 Jul 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

alter table Triage
drop constraint ckHeight

alter table Triage
add constraint ckHeight check (Height > 20 and Height < 300)

alter table Triage
add RespirationRate tinyint constraint ckRespirationRate check (RespirationRate > 10 and RespirationRate < 150)

-----------ClinicalFindings-----------------------------------------------------------------
alter table ClinicalFindings add
ENT varchar(100), Skin varchar(100)

update ClinicalFindings set ENT = '' where ENT is null
update ClinicalFindings set Skin = '' where Skin is null

----------------------------------------------------------------------------------------
---------------Added update on 21 Jul 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

-----------SchemeMembers----------------------------------------------------------------
alter table SchemeMembers add
Address varchar(100), PhoneWork varchar(30), PhoneMobile varchar(30), PhoneHome varchar(30)

update SchemeMembers set Address = '' where Address is null
update SchemeMembers set PhoneWork = '' where PhoneWork is null
update SchemeMembers set PhoneMobile = '' where PhoneMobile is null
update SchemeMembers set PhoneHome = '' where PhoneHome is null


alter table LabTests
alter column NormalRange varchar(800)

alter table LabTestsEXT
alter column NormalRange varchar(800)


-----------SchemeMembers----------------------------------------------------------------
alter table SchemeMembers add
Email varchar(40)

update SchemeMembers set Email = '' where Email is null

----------------------------------------------------------------------------------------
---------------Added update on 21 Jul 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

-----------VisitFiles-------------------------------------------------------------------

create table VisitFiles
(VisitNo varchar(20) not null constraint fkVisitNoVisitFiles references Visits (VisitNo)  
on delete cascade on update cascade constraint pkVisitNoVisitFiles primary key,
FileStatusID varchar(10) constraint fkFileStatusIDVisitFiles references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDVisitFiles references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeVisitFiles default getdate()
)
go

----------------------------------------------------------------------------------------
---------------Added update on 09 Sep 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

-----------ProductOwnerInfo-------------------------------------------------------------

alter table ProductOwnerInfo add
ProductVersion varchar(100), LastUpdate smalldatetime

-----------SpecialEdits-----------------------------------------------------------------

create table SpecialEdits
(ObjectName varchar(40) not null constraint fkObjectNameSpecialEdits references AccessObjects (ObjectName)
constraint pkObjectNameSpecialEdits primary key,
KeyColumnName varchar(100) not null,
KeyColumnCaption varchar(100) not null
)
go
-- run common

----------------------------------------------------------------------------------------
---------------Added update on 10 Sep 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

-----------PaymentDetails-------------------------------------------------------------

alter table PaymentDetails
drop constraint fkVisitNoItemCodeItemCategoryIDPaymentDetails

alter table PaymentDetails
add constraint fkVisitNoItemCodeItemCategoryIDPaymentDetails foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on update cascade

----------------------------------------------------------------------------------------
---------------Added update on 12 Sep 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

drop function GetCoPayUnitPrice

----------------------------------------------------------------------------------------
---------------Added update on 15 Sep 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

-----------Triage----------------------------------------------------------------
alter table Triage add Notes varchar(2000)
update Triage set Notes = '' where Notes is null

-----------ClinicalFindings----------------------------------------------------------------
exec sp_rename 'ClinicalFindings.ClinicalDiagnosis', 'ProvisionalDiagnosis', 'COLUMN'

alter table ClinicalFindings
alter column History varchar(1000)

alter table ClinicalFindings
alter column Respiratory varchar(1000)

alter table ClinicalFindings
alter column GeneralAppearance varchar(1000)

alter table ClinicalFindings
alter column CVS varchar(1000)

alter table ClinicalFindings
alter column Abdomen varchar(1000)

alter table ClinicalFindings
alter column CNS varchar(1000)

alter table ClinicalFindings
alter column MuscularSkeletal varchar(1000)

alter table ClinicalFindings
alter column PsychologicalStatus varchar(1000)

alter table ClinicalFindings
alter column ProvisionalDiagnosis varchar(1000)

alter table ClinicalFindings
alter column ENT varchar(1000)

alter table ClinicalFindings
alter column Skin varchar(1000)

-----------Allergies----------------------------------------------------------------

-- run commented below but with care
-- drop table Allergies
drop proc uspEditAllergies
drop proc uspGetAllergies

create table Allergies
(AllergyNo varchar(20) not null constraint pkAllergyNo primary key,
AllergyName varchar(60) constraint uqAllergyName unique,
AllergyCategoryID varchar(10) constraint fkAllergyCategoryIDAllergies references LookupData (DataID)
)
go

create table AllergyDrugs
(AllergyNo varchar(20) not null 
constraint fkAllergyNoAllergyDrugs references Allergies (AllergyNo) on delete cascade on update cascade,
DrugNo varchar(20) not null 
constraint fkDrugNoAllergyDrugs references Drugs (DrugNo) on delete cascade on update cascade,
constraint pkAllergyNoDrugNo primary key(AllergyNo, DrugNo)
)
go

create table PatientAllergies
(PatientNo varchar(20) not null
constraint fkPatientNoPatientAllergies references Patients (PatientNo) on delete cascade on update cascade,
AllergyNo varchar(20) not null constraint fkAllergyNoPatientAllergies references Allergies (AllergyNo),
constraint pkPatientNoAllergyNo primary key(PatientNo, AllergyNo),
Reaction varchar(200)
)
go

delete from ObjectRoles where ObjectName = 'Allergies'

----------------------------------------------------------------------------------------
---------------Added update on 20 Sep 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

exec uspEditOptions 'AllowCreateMultipleExtraBills', 0, '3BIT', 1, 0

----------------------------------------------------------------------------------------
---------------Added update on 22 Sep 2012 ---------------------------------------------
----------------------------------------------------------------------------------------

-----------DentalServices----------------------------------------------------------------------------------
alter table DentalServices add
DentalCategoryID varchar(10) constraint fkDentalCategoryIDDentalServices references LookupData (DataID)

update DentalServices set DentalCategoryID = '102S' where DentalCategoryID is null

---------------------------------------------------------------------------------------------
---------------Added update on Thur 27-09-2012 ----------------------------------------------
---------------------------------------------------------------------------------------------

-----------BillCustomers---------------------------------------------------------------------
alter table BillCustomers add
CaptureMemberCardNo bit constraint dfCaptureMemberCardNoBillCustomers default 1

update BillCustomers set CaptureMemberCardNo = 1 where CaptureMemberCardNo is null

-----------ClinicalFindings----------------------------------------------------------------
alter table ClinicalFindings add
ROS varchar(1000), PMH varchar(1000), POH varchar(1000),
PGH varchar(1000), FSH varchar(1000), EYE varchar(1000),
PV varchar(1000)

update ClinicalFindings set ROS = '' where ROS is null
update ClinicalFindings set PMH = '' where PMH is null
update ClinicalFindings set POH = '' where POH is null
update ClinicalFindings set PGH = '' where PGH is null
update ClinicalFindings set FSH = '' where FSH is null
update ClinicalFindings set EYE = '' where EYE is null
update ClinicalFindings set PV = '' where PV is null

exec sp_rename 'ClinicalFindings.History', 'PresentingComplaint', 'COLUMN'

---------------------------------------------------------------------------------------------
---------------Added update on Thur 06-10-2012 ----------------------------------------------
---------------------------------------------------------------------------------------------

update LookupData set DataDes = 'Processing'
where DataID = '11R' and DataDes = 'Requested'

exec uspEditOptions 'AllowSmartCardApplicableVisit', 0, '3BIT', 1, 0

-----------Visits--------------------------------------------------------------------------------
alter table Visits add
InsuranceNo varchar(20), SmartCardApplicable bit constraint dfSmartCardApplicableVisits default 0

update Visits set InsuranceNo = dbo.GetInsuranceNo(BillModesID, BillNo) where InsuranceNo is null
update Visits set SmartCardApplicable = 0 where SmartCardApplicable is null

---------------------------------------------------------------------------------------------
---------------Added update on Thur 20-10-2012 ----------------------------------------------
---------------------------------------------------------------------------------------------

update LookupObjects set ObjectName = 'EntryMode'
where ObjectID = 46 and ObjectName = 'ClaimEntry'

update LookupObjects set ObjectDes = 'Entry Mode'
where ObjectID = 46 and ObjectDes = 'Claim Entry'

-----------Inventory-----------------------------------------------------------------
alter table Inventory add
EntryModeID varchar(10) constraint fkEntryModeIDInventory references LookupData (DataID)

update Inventory set EntryModeID = '46SYS'
where EntryModeID is null and StockTypeID = '13I'
and Details LIKE 'Drug(s) Issued to %' 

-- run this after running update above
update Inventory set EntryModeID = '46MAN'
where EntryModeID is null 

-----------ItemsEXT-----------------------------------------------------------------
alter table ItemsEXT add 
IssueDate smalldatetime null,
Pharmacist varchar(10) null constraint fkPharmacistItemsEXT references Staff (StaffNo),
LoginID varchar(20) null constraint fkLoginIDItemsEXT references Logins (LoginID)

-----------IPDItemsEXT-----------------------------------------------------------------
alter table IPDItemsEXT add 
IssueDate smalldatetime null,
Pharmacist varchar(10) null constraint fkPharmacistIPDItemsEXT references Staff (StaffNo),
LoginID varchar(20) null constraint fkLoginIDIPDItemsEXT references Logins (LoginID)

-- run utilities first
update ItemsEXT set IssueDate = dbo.GetItemsLastUpdate(VisitNo, ItemCode, ItemCategoryID)
where IssueDate is null 

update ItemsEXT set LoginID = dbo.GetItemsLoginID(VisitNo, ItemCode, ItemCategoryID)
where LoginID is null 

update IPDItemsEXT set IssueDate = dbo.GetIPDItemsLastUpdate(RoundNo, ItemCode, ItemCategoryID)
where IssueDate is null 

update IPDItemsEXT set LoginID = dbo.GetIPDItemsLoginID(RoundNo, ItemCode, ItemCategoryID)
where LoginID is null 

---------------------------------------------------------------------------------------------
---------------Added update on Thur 20-10-2012 ----------------------------------------------
---------------------------------------------------------------------------------------------

update Inventory set TranDate = dbo.FormatDate(RecordDateTime)

exec uspEditOptions 'AllowPrescriptionToNegative', 1, '3BIT', 1, 0
exec uspEditOptions 'AllowDispensingToNegative', 0, '3BIT', 1, 0

delete from Options where OptionName = 'NoNegativeDrugUnitsInStock'

update LookupData set DataDes = 'Visit Bill'
where DataID = '47CAS' and DataDes = 'Cash Visit'

update LookupData set DataDes = 'IPD Round Bill'
where DataID = '47IPR' and DataDes = 'IPD Round'

---------------------------------------------------------------------------------------------
---------------Added update on Thur 25-10-2012 ----------------------------------------------
---------------------------------------------------------------------------------------------

create table Invoices
(InvoiceID int not null constraint dfInvoiceIDInvoices default 1,
InvoiceNo varchar(20) not null constraint pkInvoiceNo primary key,
PayTypeID varchar(10) constraint fkPayTypeIDInvoices references LookupData (DataID),
PayNo varchar(20), --References Visits, Bills (Bill Customers/Insurances), IPD Rounds
InvoiceDate smalldatetime,
StartDate smalldatetime,
EndDate smalldatetime,
AmountWords varchar(200),
LoginID varchar(20) constraint fkLoginIDInvoices references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeInvoices default getdate()
)
go

create table InvoiceDetails
(InvoiceNo varchar(20) not null constraint fkInvoiceNoInvoiceDetails references Invoices (InvoiceNo)
on delete cascade on update cascade,
VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInvoiceDetails references LookupData (DataID),
constraint fkVisitNoItemCodeItemCategoryIDInvoiceDetails foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkInvoiceNoVisitNoItemCodeItemCategoryID primary key(InvoiceNo, VisitNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice Money,
Discount Money,
Amount Money
)
go

---------------------------------------------------------------------------------------------
---------------Added update on Sun 04-11-2012 -----------------------------------------------
---------------------------------------------------------------------------------------------

update AccessObjects set ObjectCaption = 'Income Summaries'
where ObjectName = 'CashCollectionSummaries'

delete from ObjectRoles  where ObjectName = 'CashCollectionSummaries'

update AccessObjects set ObjectName = 'IncomeSummaries'
where ObjectName = 'CashCollectionSummaries'

---------------------------------------------------------------------------------------------
---------------Added update on Sun 11-11-2012 -----------------------------------------------
---------------------------------------------------------------------------------------------

-----------Drugs----------------------------------------------------------------------------------

alter table Drugs add
BatchNo varchar(20) constraint dfBatchNoDrugs default '',
ExpiryDate smalldatetime constraint dfExpiryDateDrugs default '1 Jan 1900'

update Drugs set BatchNo = dbo.GetInventoryBatchNo(DrugNo) where BatchNo is null
update Drugs set ExpiryDate = dbo.GetInventoryExpiryDate(DrugNo) where ExpiryDate is null

exec uspEditOptions 'AllowDispensingExpiredDrugs', 0, '3BIT', 1, 0

-----------RadiologyReports----------------------------------------------------------------------------------
alter table RadiologyReports add
RadiologyTitleID varchar(10) constraint fkRadiologyTitleIDRadiologyReports references LookupData (DataID)

update RadiologyReports set RadiologyTitleID = '10301' where RadiologyTitleID is null

-----------IPDRadiologyReports----------------------------------------------------------------------------------
alter table IPDRadiologyReports add
RadiologyTitleID varchar(10) constraint fkRadiologyTitleIDIPDRadiologyReports references LookupData (DataID)

update IPDRadiologyReports set RadiologyTitleID = '10301' where RadiologyTitleID is null

-----------LabResults---------------------------------------------------------------------------------------

alter table LabResults add
UnitMeasure varchar(100), NormalRange varchar(800),
ResultFlagID varchar(10)constraint fkResultFlagIDLabResults references LookupData (DataID),
EntryModeID varchar(10)constraint fkEntryModeIDLabResults references LookupData (DataID)

update LabResults set UnitMeasure = dbo.GetUnitMeasure('7T', TestCode) where UnitMeasure is null 
update LabResults set UnitMeasure = '' where UnitMeasure = 'NA' 
update LabResults set NormalRange = dbo.GetLabTestsNormalRange(TestCode) where NormalRange is null 
update LabResults set ResultFlagID = '104N' where ResultFlagID is null 
update LabResults set EntryModeID = '46MAN' where EntryModeID is null 

-----------LabResultsEXT----------------------------------------------------------------------------------

alter table LabResultsEXT add
UnitMeasure varchar(100),NormalRange varchar(800),
ResultFlagID varchar(10)constraint fkResultFlagIDLabResultsEXT references LookupData (DataID)

update LabResultsEXT set UnitMeasure = dbo.GetUnitMeasureEXT(TestCode, SubTestCode) where UnitMeasure is null 
update LabResultsEXT set UnitMeasure = '' where UnitMeasure = 'NA' 
update LabResultsEXT set NormalRange = dbo.GetLabTestsEXTNormalRange(TestCode, SubTestCode) where NormalRange is null 
update LabResultsEXT set ResultFlagID = '104N' where ResultFlagID is null 

---------------------------------------------------------------------------------
---------------Added update on Sat 08-12-12 -------------------------------------
---------------------------------------------------------------------------------

-----------Payments----------------------------------------------------------------------------------
alter table Payments 
add UseAccountBalance bit constraint dfUseAccountBalancePayments default 0

update Payments set UseAccountBalance = 0 where UseAccountBalance is null

-----------PaymentExtraBillItems----------------------------------------------------------------------------------

create table PaymentExtraBillItems
(ReceiptNo varchar(20) not null constraint fkReceiptNoPaymentExtraBillItems references Payments(ReceiptNo)
on delete cascade on update cascade,
ExtraBillNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDPaymentExtraBillItems references LookupData (DataID),
constraint fkExtraBillNoItemCodeItemCategoryIDPaymentExtraBillItems foreign key (ExtraBillNo, ItemCode, ItemCategoryID) 
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkReceiptNoExtraBillNoItemCodeItemCategoryID primary key (ReceiptNo, ExtraBillNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice money ,
Discount money ,
Amount money
)
go

---------------------------------------------------------------------------------
---------------Added update on Thu 14-12-12 -------------------------------------
---------------------------------------------------------------------------------

-----------LabTests--------------------------------------------------------------

alter table LabTests
alter column TestName varchar(100)

-----------LabTestsEXT--------------------------------------------------------------

alter table LabTestsEXT
alter column SubTestName varchar(100)

-----------Drugs--------------------------------------------------------------

alter table Drugs
alter column DrugName varchar(100)

alter table Drugs
alter column AlternateName varchar(100)

---------------------------------------------------------------------------------
---------------Added update on Tue 18-12-12 -------------------------------------
---------------------------------------------------------------------------------

-----------ProductOwnerInfo-----------------------------------------------------------

alter table ProductOwnerInfo 
add TINNo varchar(100), VATNo varchar(100)

---------------LabPossibleResults-----------------------------------------------------

alter table SearchColumnsEXT
drop constraint fkObjectNameColumnNameEXT

alter table SearchColumnsEXT
drop constraint pkObjectNameColumnNameEXT

---------------SearchColumns----------------------------------------------------------

alter table SearchColumns
drop constraint pkColumnNameObjectName

-----------SearchColumns--------------------------------------------------------------

alter table SearchColumns
alter column ColumnName varchar(200) not null

alter table SearchColumns
alter column ColumnCaption varchar(200) not null

-----------SearchColumnsEXT-----------------------------------------------------------

alter table SearchColumnsEXT
alter column ColumnName varchar(200) not null

---------------SearchColumns----------------------------------------------------------

alter table SearchColumns add
constraint pkColumnNameObjectName primary key(ColumnName, ObjectName)

---------------SearchColumnsEXT-----------------------------------------------------

alter table SearchColumnsEXT add 
constraint fkObjectNameColumnNameEXT foreign key (ColumnName, ObjectName)
references SearchColumns (ColumnName, ObjectName) on delete cascade

alter table SearchColumnsEXT add
constraint pkObjectNameColumnNameEXT primary key (ColumnName, ObjectName)

--- Run Common
**/
---------------------------------------------------------------------------------
---------------Added update on Tue 05-01-13 -------------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'AllowPrescriptionExpiredDrugs', 1, '3BIT', 1, 0
exec uspEditOptions 'IncludeMonthsForAgesBelow', 3, '3NUM', 2, 0
exec uspEditOptions 'ExpiryWarningDays', 60, '3NUM', 3, 0
exec uspEditOptions 'DoctorVisitUpdateDays', 14, '3NUM', 2, 0

alter table ItemsEXT alter column Dosage varchar(100)
alter table IPDItemsEXT alter column Dosage varchar(100)
alter table ARTRegimenDetails alter column Dosage varchar(100)

---------------------------------------------------------------------------------
---------------Added update on Sun 13-01-13 -------------------------------------
---------------------------------------------------------------------------------

create table TheatreServices
(TheatreCode varchar(20) not null constraint pkTheatreCode primary key,
TheatreName varchar(200) constraint uqTheatreName unique,
UnitPrice money,
Hidden bit constraint dfHiddenTheatreServices default 0
)
go

create table OpticalServices
(OpticalCode varchar(20) not null constraint pkOpticalCode primary key,
OpticalName varchar(200) constraint uqOpticalName unique,
UnitPrice money,
Hidden bit constraint dfHiddenOpticalServices default 0
)
go

create table MaternityServices
(MaternityCode varchar(20) not null constraint pkMaternityCode primary key,
MaternityName varchar(200) constraint uqMaternityName unique,
UnitPrice money,
Hidden bit constraint dfHiddenMaternityServices default 0
)
go

create table ICUServices
(ICUCode varchar(20) not null constraint pkICUCode primary key,
ICUName varchar(200) constraint uqICUName unique,
UnitPrice money,
Hidden bit constraint dfHiddenICUServices default 0
)
go

---------------------------------------------------------------------------------
---------------Added update on Sat 27-01-13 -------------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'FingerprintDevice', '105DP', '3STR', 5, 1
exec uspEditOptions 'PatientNoPrefix', '', '3STR', 10, 1

---------------------------------------------------------------------------------
---------------Added update on Wen 30-01-13 -------------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'SmartCardConnectionAttemptNo', 10, '3NUM', 3, 0

-----------Logins----------------------------------------------------------------

alter table Logins
add ChangePassword bit not null constraint dfChangePasswordLogins default 0

-- run common


---------------------------------------------------------------------------------
---------------Added update on Sat 09-02-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Triage----------------------------------------------------------------

alter table Triage
drop constraint ckPulse

alter table Triage
add constraint ckPulse check (Pulse > 10 and Pulse <= 300)

-----------IPDClinicalFindings----------------------------------------------------

alter table IPDClinicalFindings
drop constraint ckPulseIPDClinicalFindings

alter table IPDClinicalFindings
add constraint ckPulseIPDClinicalFindings check (Pulse > 10 and Pulse <= 300)

exec uspEditOptions 'AllowExtendedVisitEdits', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Sun 24-02-13 -------------------------------------
---------------------------------------------------------------------------------

-----------ExtraChargeItems---------------------------------------------------------

alter table ExtraChargeItems add
Hidden bit constraint dfHiddenExtraChargeItems default 0

update ExtraChargeItems set Hidden = 0 where Hidden is null

---------------------------------------------------------------------------------
---------------Added update on Sat 02-03-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Payments-----------------------------------------------------------------------------------------------
alter table Payments 
add Change money

update Payments set Change = dbo.GetChange(dbo.GetAmountPaid(PayTypeID, ReceiptNo), AmountTendered, ExchangeRate) 
where Change is null

---After Succeeding above, run below
drop function GetChange

-----------Expenditure-------------------------------------------------------------------------------------------

alter table Expenditure
drop constraint fkSpentByExpenditure

alter table Expenditure drop column SpentBy

alter table Expenditure 
add ExpenditureCategoryID varchar(10) constraint fkExpenditureCategoryIDExpenditure references LookupData (DataID)

update Expenditure set ExpenditureCategoryID = '106GEN' where ExpenditureCategoryID is null 

exec uspEditOptions 'AllowProvisionalPrinting', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowDirectDebitBalanceEntry', 0, '3BIT', 1, 0

-----------Refunds-----------------------------------------------------------------------------------------------

create table Refunds
(RefundID int not null constraint dfRefundIDRefunds default 1,
RefundNo varchar(20) not null constraint pkRefundNo primary key,
ReceiptNo varchar(20) constraint fkReceiptNoRefunds references Payments (ReceiptNo)
on delete cascade on update cascade,
RefundDate smalldatetime,
Amount money,
AmountWords varchar(200),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDRefunds references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefunds default getdate()
)
go

---------------------------------------------------------------------------------------------
---------------Added update on Fri 22-03-2013 -----------------------------------------------
---------------------------------------------------------------------------------------------

-----------Patients--------------------------------------------------------------------------
alter table Patients alter column DefaultMemberCardNo varchar(30)

-----------Visits----------------------------------------------------------------------------
alter table Visits alter column MemberCardNo varchar(30)

-----------ExtraBillsEXT---------------------------------------------------------------------

create table ExtraBillsEXT
(ExtraBillNo varchar(20) not null constraint fkExtraBillNoExtraBillsEXT 
references ExtraBills (ExtraBillNo) constraint pkExtraBillNoExtraBillsEXT primary key,
RoundNo varchar(20) not null constraint uqRoundNo unique
constraint fkRoundNoExtraBillsEXT references IPDDoctor (RoundNo)
on delete cascade on update cascade 
)
go

-----------ExtraBillItems------------------------------------------------------------------------

alter table ExtraBillItems add
EntryModeID varchar(10) constraint fkEntryModeIDExtraBillItems references LookupData (DataID)

update ExtraBillItems set EntryModeID = '46MAN' where EntryModeID is null 

---------------------------------------------------------------------------------------------
---------------Added update on Mon 01-04-2013 -----------------------------------------------
---------------------------------------------------------------------------------------------

exec uspEditOptions 'NullDateValue', '1 Jan 1900', '3DTE', 18, 1
exec uspEditOptions 'DecimalPlaces', 2, '3NUM', 1, 0
exec uspEditOptions 'EnableAuditTrail', 1, '3BIT', 1, 1
exec uspEditOptions 'UserIdleDuration', 30, '3NUM', 2, 0
exec uspEditOptions 'Currency', 'UGX', '3STR', 10, 1
exec uspEditOptions 'HideCashPaymentReceiptDetails', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------------------
---------------Added update on Tue 23-04-2013 -----------------------------------------------
---------------------------------------------------------------------------------------------
exec uspEditOptions 'AllowDirectDiscountCashPayment', 0, '3BIT', 1, 0

create table BillCustomerMembers
(MedicalCardNo varchar(20) not null,
AccountNo varchar(20) not null constraint fkAccountNoBillCustomerMembers 
references BillCustomers (AccountNo) on delete cascade on update cascade,
constraint pkMedicalCardNoAccountNo primary key(MedicalCardNo, AccountNo),
Surname varchar(20),
FirstName varchar(20),
MiddleName varchar(20),
PolicyStartDate smalldatetime,
PolicyEndDate smalldatetime,
CreditLimit money constraint dfCreditLimitBillCustomerMembers default 0,
MemberStatusID varchar(10) constraint fkMemberStatusIDBillCustomerMembers references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDBillCustomerMembers references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeBillCustomerMembers default getdate()
)
go

---------------LabResultsEXT-----------------------------------------------------

alter table LabResultsEXT
drop constraint fkSpecimenNoTestCode

alter table LabResultsEXT
drop constraint fkTestCodeSubTestCode

alter table LabResultsEXT
drop constraint pkSpecimenNoTestCodeSubTestCode

alter table LabResultsEXT
alter column TestCode varchar(20) not null

alter table LabResultsEXT
alter column SubTestCode varchar(20) not null

---------------LabResults-----------------------------------------------------

alter table LabResults
drop constraint fkSpecimenNoTestCodeLabResults

alter table LabResults
drop constraint pkSpecimenNoTestCodeLabResults

alter table LabResults
alter column TestCode varchar(20) not null

---------------LabRequestDetails-----------------------------------------------------

alter table LabRequestDetails
drop constraint fkTestCodeLabRequestDetails

alter table LabRequestDetails
drop constraint pkSpecimenNoTestCode

alter table LabRequestDetails
alter column TestCode varchar(20) not null

---------------LabTestsEXT-----------------------------------------------------

alter table LabTestsEXT
drop constraint fkTestCodeLabTestsEXT

alter table LabTestsEXT
drop constraint pkTestCodeSubTestCode

alter table LabTestsEXT
drop constraint uqTestCodeSubTestName

alter table LabTestsEXT
alter column TestCode varchar(20) not null

alter table LabTestsEXT
alter column SubTestCode varchar(20) not null

---------------LabPossibleResults-----------------------------------------------------

alter table LabPossibleResults
drop constraint fkTestCodeLabPossibleResults

alter table LabPossibleResults
drop constraint pkTestCodePossibleResult

alter table LabPossibleResults
alter column TestCode varchar(20) not null

---------------LabTests-------------------------------------------------------------
alter table LabTests
drop constraint pkTestCodeID

alter table LabTests
alter column TestCode varchar(20) not null

alter table LabTests add
constraint pkTestCodeID primary key(TestCode)

-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------

---------------LabPossibleResults-----------------------------------------------------

alter table LabPossibleResults add 
constraint fkTestCodeLabPossibleResults foreign key (TestCode)
references LabTests (TestCode) on delete cascade

alter table LabPossibleResults add
constraint pkTestCodePossibleResult primary key(TestCode, PossibleResult)

---------------LabTestsEXT-----------------------------------------------------------

alter table LabTestsEXT add 
constraint fkTestCodeLabTestsEXT foreign key (TestCode)
references LabTests(TestCode) on delete cascade on update cascade

alter table LabTestsEXT add
constraint pkTestCodeSubTestCode primary key (TestCode, SubTestCode)

alter table LabTestsEXT
add constraint uqTestCodeSubTestName unique(TestCode, SubTestName)

---------------LabRequestDetails-----------------------------------------------------

alter table LabRequestDetails add 
constraint fkTestCodeLabRequestDetails foreign key (TestCode)
references LabTests (TestCode)

alter table LabRequestDetails add
constraint pkSpecimenNoTestCode primary key (SpecimenNo, TestCode) 

---------------LabResults-----------------------------------------------------

alter table LabResults add 
constraint fkSpecimenNoTestCodeLabResults foreign key (SpecimenNo, TestCode)
references LabRequestDetails (SpecimenNo, TestCode)

alter table LabResults add
constraint pkSpecimenNoTestCodeLabResults primary key (SpecimenNo, TestCode)

---------------LabResultsEXT-----------------------------------------------------

alter table LabResultsEXT add 
constraint fkSpecimenNoTestCode foreign key (SpecimenNo, TestCode)
references LabResults (SpecimenNo, TestCode) on delete cascade on update cascade

alter table LabResultsEXT add
constraint fkTestCodeSubTestCode foreign key (TestCode, SubTestCode)
references LabTestsEXT (TestCode, SubTestCode)

alter table LabResultsEXT add
constraint pkSpecimenNoTestCodeSubTestCode 
primary key (SpecimenNo, TestCode, SubTestCode)

-------------- MemberLimits ------------------------------------------------------------------

create table MemberLimits
(MedicalCardNo varchar(20) not null,
AccountNo varchar(20) not null,
constraint fkMedicalCardNoAccountNoMemberLimits foreign key (MedicalCardNo, AccountNo)
references BillCustomerMembers (MedicalCardNo, AccountNo)on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDMemberLimits references LookupData (DataID),
constraint pkMedicalCardNoAccountNoItemCategoryID primary key(MedicalCardNo, AccountNo, ItemCategoryID),
MemberLimit money
)
go

---------------------------------------------------------------------------------------------
---------------Added update on Tue 30-04-2013 -----------------------------------------------
---------------------------------------------------------------------------------------------

-------------- TheatreOperations ------------------------------------------------------------

create table TheatreOperations
(VisitNo varchar(20) not null constraint fkVisitNoTheatreOperations 
references DoctorVisits (VisitNo) on delete cascade on update cascade
constraint pkVisitNoTheatreOperations primary key,
OperationDateTime smalldatetime,
LeadSurgeon varchar(10) constraint fkLeadSurgeonTheatreOperations references Staff (StaffNo),
OtherSurgeon varchar(200),
LeadAnaesthetist varchar(10) constraint fkLeadAnaesthetistTheatreOperations references Staff (StaffNo),
OtherAnaesthetist varchar(200),
LeadNurse varchar(10) constraint fkLeadNurseTheatreOperations references Staff (StaffNo),
OtherNurse varchar(200),
AnaesthesiaTypeID varchar(10) constraint fkAnaesthesiaTypeIDTheatreOperations references LookupData (DataID),
OperationClassID varchar(10) constraint fkOperationClassIDTheatreOperations references LookupData (DataID),
PreoperativeDiagnosis varchar(2000),
PlannedProcedures varchar(2000),
Report varchar(2000),
PostoperativeInstructions varchar(2000),
LoginID varchar(20) constraint fkLoginIDTheatreOperations references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeTheatreOperations default getdate()
)
go

-------------- IPDTheatreOperations ------------------------------------------------------------

create table IPDTheatreOperations
(RoundNo varchar(20) not null constraint fkRoundNoIPDTheatreOperations 
references IPDDoctor (RoundNo) on delete cascade on update cascade
constraint pkRoundNoIPDTheatreOperations primary key,
OperationDateTime smalldatetime,
LeadSurgeon varchar(10) constraint fkLeadSurgeonIPDTheatreOperations references Staff (StaffNo),
OtherSurgeon varchar(200),
LeadAnaesthetist varchar(10) constraint fkLeadAnaesthetistIPDTheatreOperations references Staff (StaffNo),
OtherAnaesthetist varchar(200),
LeadNurse varchar(10) constraint fkLeadNurseIPDTheatreOperations references Staff (StaffNo),
OtherNurse varchar(200),
AnaesthesiaTypeID varchar(10) constraint fkAnaesthesiaTypeIDIPDTheatreOperations references LookupData (DataID),
OperationClassID varchar(10) constraint fkOperationClassIDIPDTheatreOperations references LookupData (DataID),
PreoperativeDiagnosis varchar(2000),
PlannedProcedures varchar(2000),
Report varchar(2000),
PostoperativeInstructions varchar(2000),
LoginID varchar(20) constraint fkLoginIDIPDTheatreOperations references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDTheatreOperations default getdate()
)
go

---------------------------------------------------------------------------------------------
---------------Added update on Thur 13-05-2013 ----------------------------------------------
---------------------------------------------------------------------------------------------

exec uspEditOptions 'AllowProcessingPendingItems', 1, '3BIT', 1, 0

exec uspInsertStaff	104, 'Private', 'Anaesthetist', '15M', '20ANA', '', '', '', '05 Jan 2013',  '', ''
exec uspInsertStaff	105, 'Private', 'Nurse', '15F', '20NUR', '', '', '', '05 Jan 2013',  '', ''

-----------BillCustomers---------------------------------------------------------------------
alter table BillCustomers add
CaptureClaimReferenceNo bit constraint dfCaptureClaimReferenceNoBillCustomers default 1

-- Run commented below for Case and Victoria and line that follows for others
-- update BillCustomers set CaptureClaimReferenceNo = 1 where CaptureClaimReferenceNo is null
update BillCustomers set CaptureClaimReferenceNo = 0 where CaptureClaimReferenceNo is null

-----------Visits----------------------------------------------------------------------------
alter table Visits add ClaimReferenceNo varchar(30)

update Visits set ClaimReferenceNo = '' where ClaimReferenceNo is null

-----------BillCustomers-----------------------------------------------------------------

alter table BillCustomers add
Fax varchar(100), Email varchar(100), Website varchar(100), LogoPhoto image,
MemberDeclaration varchar(800), DoctorDeclaration varchar(800)

update BillCustomers set Fax = '' where Fax is null
update BillCustomers set Email = '' where Email is null
update BillCustomers set Website = '' where Website is null
update BillCustomers set MemberDeclaration = '' where MemberDeclaration is null
update BillCustomers set DoctorDeclaration = '' where DoctorDeclaration is null

---------------------------------------------------------------------------------------------
---------------Added update on Sun 26-05-2013 -----------------------------------------------
---------------------------------------------------------------------------------------------

-----------OtherIncome-----------------------------------------------------------------------

alter table OtherIncome add
PayModesID varchar(10) constraint fkPayModesIDOtherIncome references LookupData (DataID),
DocumentNo varchar(20)

update OtherIncome set PayModesID = '6CA' where PayModesID is null
update OtherIncome set DocumentNo = '' where DocumentNo is null

exec uspEditOptions 'HideCashReceiptHeader', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Thu 07-06-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Staff-----------------------------------------------------------------

alter table Staff add Signature image

---------------------------------------------------------------------------------
---------------Added update on Tue 19-06-13 -------------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'HideBillFormPaymentReceiptDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'HideCreditBillsPaymentReceiptDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'HideCreditBillFormPaymentReceiptDetails', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Sun 23-06-13 -------------------------------------
---------------------------------------------------------------------------------

-----------IPDDentalReports------------------------------------------------------

create table IPDDentalReports
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDDentalReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID),
constraint pkRoundNoItemCodeItemCategoryIDIPDDentalReports primary key(RoundNo, ItemCode, ItemCategoryID),
ReportDate smalldatetime,
Report varchar(2000),
LoginID varchar(20) constraint fkLoginIDIPDDentalReports references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDDentalReports default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Sun 30-07-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Payments----------------------------------------------------------------------------------

alter table Payments add
VisitTypeID varchar(10) constraint fkVisitTypeIDPayments references LookupData (DataID)

update Payments set VisitTypeID = '110OPD' where VisitTypeID is null and not PayTypeID = '47EXT' 
update Payments set VisitTypeID = '110IPD' where VisitTypeID is null and PayTypeID = '47EXT' 

-- select * from Payments  where VisitTypeID is null

---------------------------------------------------------------------------------
---------------Added update on Thu 04-07-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Invoices----------------------------------------------------------------------------------

alter table Invoices add
VisitTypeID varchar(10) constraint fkVisitTypeIDInvoices references LookupData (DataID)

update Invoices set VisitTypeID = '110OPD' where VisitTypeID is null 

-------------- InvoiceExtraBillItems --------------------------------------------------------------------

create table InvoiceExtraBillItems
(InvoiceNo varchar(20) not null constraint fkInvoiceNoInvoiceExtraBillItems references Invoices(InvoiceNo)
on delete cascade on update cascade,
ExtraBillNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInvoiceExtraBillItems references LookupData (DataID),
constraint fkExtraBillNoItemCodeItemCategoryIDInvoiceExtraBillItems foreign key (ExtraBillNo, ItemCode, ItemCategoryID) 
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkInvoiceNoExtraBillNoItemCodeItemCategoryID primary key (InvoiceNo, ExtraBillNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice money ,
Discount money ,
Amount money
)
go

---------------------------------------------------------------------------------
---------------Added update on Sat 13-07-13 -------------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'AllowCreateMultipleVisitInvoices', 0, '3BIT', 1, 0

-------------- Patients --------------------------------------------------------------------
alter table Patients add TotalVisits int

drop proc uspUpdatePatientVisitDates

--------run cursor below, but be very carefull and run it only once, it may take awhile to complete-------------------------

DECLARE @PatientNo VARCHAR(20)
DECLARE Patients_Cursor INSENSITIVE CURSOR FOR

SELECT PatientNo FROM Patients

OPEN Patients_Cursor
FETCH NEXT FROM Patients_Cursor INTO @PatientNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
			
		UPDATE Patients SET FirstVisitDate = dbo.GetFirstVisitDate(@PatientNo) WHERE PatientNo = @PatientNo									
		UPDATE Patients SET LastVisitDate = dbo.GetLastVisitDate(@PatientNo)  WHERE PatientNo = @PatientNo 				
		UPDATE Patients SET TotalVisits = dbo.GetTotalVisits(@PatientNo)  WHERE PatientNo = @PatientNo 				
		
		FETCH NEXT FROM Patients_Cursor INTO @PatientNo
	END
CLOSE Patients_Cursor
DEALLOCATE Patients_Cursor

----------------------------------------------------------------------------------------------------------------------------

-----------ClinicalFindings-----------------------------------------------------------------
alter table ClinicalFindings add TreatmentPlan varchar(1000)

update ClinicalFindings set TreatmentPlan = '' where TreatmentPlan is null

---------------------------------------------------------------------------------
---------------Added update on Sun 21-07-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Admissions-----------------------------------------------------------------

update Admissions set AdmissionStatusID = '34D'
where AdmissionDate < '1 Jul 2013' and AdmissionStatusID = '34I'

-----------Discharges-----------------------------------------------------------------

exec sp_rename 'Discharges.DischargeDate', 'DischargeDateTime', 'COLUMN'

alter table Discharges add
StaffNo varchar(10) constraint fkStaffNoDischarges references Staff (StaffNo),
RoundNo varchar(20) constraint fkRoundNoDischarges references IPDDoctor (RoundNo),
ReviewDate smalldatetime

-- after running Utilities
update Discharges set ReviewDate = '1 Jan 1900' where ReviewDate is null

---------------------------------------------------------------------------------
---------------Added update on Wen 24-07-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Accounts--------------------------------------------------------------

alter table Accounts add
CurrenciesID varchar(10) constraint fkCurrenciesIDAccounts references LookupData (DataID),
AmountTendered money, ExchangeRate money, Change money

update Accounts set CurrenciesID = '49UGX' where CurrenciesID is null
update Accounts set AmountTendered = Amount where AmountTendered is null
update Accounts set ExchangeRate = 1 where ExchangeRate is null
update Accounts set Change = 0 where Change is null

---------------------------------------------------------------------------------
---------------Added update on Thu 01-08-13 -------------------------------------
---------------------------------------------------------------------------------

-----------ExtraBills------------------------------------------------------------------------

alter table ExtraBills add
StaffNo varchar(10) constraint fkStaffNoExtraBills references Staff (StaffNo)

---- After running Utilities

update ExtraBills set StaffNo = dbo.GetAttendingDoctorNo(dbo.GetExtraBillRoundNo(ExtraBillNo)) 
where StaffNo is null and not dbo.GetAttendingDoctorNo(dbo.GetExtraBillRoundNo(ExtraBillNo)) = ''

---------------------------------------------------------------------------------
---------------Added update on Sun 11-08-13 -------------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'AutoRenewSchemeMembers', 0, '3BIT', 1, 0
exec uspEditOptions 'HideDoctorBillServiceFee', 0, '3BIT', 1, 0
exec uspEditOptions 'HideBillFormDrugDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceInsuranceFingerprintVerification', 0, '3BIT', 1, 0
exec uspEditOptions 'ActivePatientMonths', 24, '3NUM', 2, 0

--------------BillCustomers----------------------------------------------------------------------------------

alter table BillCustomers add
AccountStatusID varchar(10) constraint fkAccountStatusIDBillCustomers references LookupData (DataID)

update BillCustomers set AccountStatusID = '1A' where AccountStatusID is null

---------------------------------------------------------------------------------
---------------Added update on Tue 03-09-13 -------------------------------------
---------------------------------------------------------------------------------

-----------ExchangeRates------------------------------------------------------------------------

create table ExchangeRates
(CurrenciesID varchar(10) not null constraint fkCurrenciesIDExchangeRates 
references LookupData (DataID) constraint pkCurrenciesID primary key,
ExchangeRate money constraint ckExchangeRateExchangeRates check (ExchangeRate > 0),
LoginID varchar(20) constraint fkLoginIDExchangeRates references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeExchangeRates default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Sat 07-09-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Quotations------------------------------------------------------------------------

create table Quotations
(QuotationID int not null constraint dfQuotationIDQuotations default 1,
QuotationNo varchar(20) not null constraint pkQuotationNo primary key,
QuotationDate smalldatetime,
AmountWords varchar(200),
LoginID varchar(20) constraint fkLoginIDQuotations references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeQuotations default getdate()
)
go

-----------QuotationDetails-------------------------------------------------------------------

create table QuotationDetails
(QuotationNo varchar(20) not null constraint fkQuotationNoQuotationDetails 
references Quotations (QuotationNo) on delete cascade on update cascade,
VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDQuotationDetails references LookupData (DataID),
constraint fkVisitNoItemCodeItemCategoryIDQuotationDetails foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkQuotationNoVisitNoItemCodeItemCategoryID primary key(QuotationNo, VisitNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice Money,
Discount Money,
Amount Money
)
go

---------------------------------------------------------------------------------
---------------Added update on Thu 26-09-13 -------------------------------------
---------------------------------------------------------------------------------

--------------Patients-----------------------------------------------------------

alter table Patients add DefaultMainMemberName varchar(41)

update Patients set DefaultMainMemberName = '' where DefaultMainMemberName is null

---------------------------------------------------------------------------------

--------------Visits-----------------------------------------------------------

alter table Visits add
MainMemberName varchar(41)

update Visits set MainMemberName = '' where MainMemberName is null

exec uspEditOptions 'ForceAccountMainMemberName', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Sun 06-10-13 -------------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'AllowCreditSelfRequests', 0, '3BIT', 1, 0

--------------OpticalServices------------------------------------------------------------------------------

alter table OpticalServices add
OpticalCategoryID varchar(10) constraint fkOpticalCategoryIDOpticalServices references LookupData (DataID)

--------------Optical--------------------------------------------------------------------------------------

create table Optical
(VisitNo varchar(20) not null constraint pkVisitNoOptical primary key
constraint fkVisitNoOptical references Visits (VisitNo)
on delete cascade on update cascade,
RightSPH varchar(200),
RightCYL varchar(200),
RightAXIS varchar(200),
RightPRISM varchar(200),
RightADD varchar(200),
LeftSPH varchar(200),
LeftCYL varchar(200),
LeftAXIS varchar(200),
LeftPRISM varchar(200),
LeftADD varchar(200),
LenseTypeID varchar(10) constraint fkLenseTypeIDOptical references LookupData (DataID),
Pd smallint,
Sg smallint,
LoginID varchar(20) constraint fkLoginIDOptical references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeOptical default getdate()
)
go

-----------Rooms------------------------------------------------------------

alter table Rooms 
drop constraint uqRoomName

alter table Rooms
add constraint uqRoomNameWardsID unique(RoomName, WardsID)

-----------Beds------------------------------------------------------------

alter table Beds 
drop constraint uqBedName

alter table Beds
add constraint uqBedNameRoomNo unique(BedName, RoomNo)

-----------Counties------------------------------------------------------------

create table Counties
(CountyCode varchar(20) not null constraint pkCountyCode primary key,
CountyName varchar(41),
DistrictsID varchar(10) constraint fkDistrictsIDCounties references LookupData (DataID)
constraint uqCountyNameDistrictsID unique(CountyName, DistrictsID)
)
go

-----------SubCounties------------------------------------------------------------

create table SubCounties
(SubCountyCode varchar(20) not null constraint pkSubCountyCode primary key,
SubCountyName varchar(41),
CountyCode varchar(20) constraint fkCountyCodeSubCounties references Counties (CountyCode)
constraint uqSubCountyNameCountyCode unique(SubCountyName, CountyCode)
)
go

-----------Parishes------------------------------------------------------------

create table Parishes
(ParishCode varchar(20) not null constraint pkParishCode primary key,
ParishName varchar(41),
SubCountyCode varchar(20) constraint fkSubCountyCodeParishes references SubCounties (SubCountyCode)
constraint uqParishNameSubCountyCode unique(ParishName, SubCountyCode)
)
go

-----------Villages------------------------------------------------------------

create table Villages
(VillageCode varchar(20) not null constraint pkVillageCode primary key,
VillageName varchar(41),
ParishCode varchar(20) constraint fkParishCodeVillages references Parishes (ParishCode)
constraint uqVillageNameParishCode unique(VillageName, ParishCode)
)
go

/*********************************************************************************
delete from LookupData
where ObjectID = 51 and DataID not in(
select DistrictsID from HealthUnits)
*********************************************************************************/

-----------Patients------------------------------------------------------------

alter table Patients add
BloodGroupID varchar(10) constraint fkBloodGroupIDPatients references LookupData (DataID),
VillageCode varchar(20) null constraint fkVillageCodePatients references Villages (VillageCode),
TribeID varchar(10) constraint fkTribeIDPatients references LookupData (DataID),
ReligionID varchar(10) constraint fkReligionIDPatients references LookupData (DataID),
Employer varchar(41) constraint dfEmployerPatients default '',
EmployerAddress varchar(100) constraint dfEmployerAddressPatients default '',
ReferringMedicalOfficer varchar(41) constraint dfReferringMedicalOfficerPatients default '',
NearestDispensary varchar(30) constraint dfNearestDispensaryPatients default '',
PreviousAdmissions varchar(30) constraint dfPreviousAdmissionsPatients default ''


update Patients set BloodGroupID = '113NA' where BloodGroupID is null
update Patients set TribeID = '114NA' where TribeID is null
update Patients set ReligionID = '115NA' where ReligionID is null
update Patients set Employer = '' where Employer is null
update Patients set EmployerAddress = '' where EmployerAddress is null
update Patients set ReferringMedicalOfficer = '' where ReferringMedicalOfficer is null
update Patients set NearestDispensary = '' where NearestDispensary is null
update Patients set PreviousAdmissions = '' where PreviousAdmissions is null

-----------Patients------------------------------------------------------------

alter table Patients add
ChronicDiseases varchar(200) constraint dfChronicDiseasesPatients default ''

update Patients set ChronicDiseases = '' where ChronicDiseases is null

exec uspEditOptions 'AllowAccessCoPayServices', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Fri 25-10-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Services--------------------------------------------------------------

alter table Services add
UnitCost money constraint dfUnitCostServices default 0

update Services set UnitCost = 0 where UnitCost is null

-----------ConsumableItems--------------------------------------------------------------

create table ConsumableItems
(ConsumableNo varchar(20) not null constraint pkConsumableNo primary key,
ConsumableName varchar(100) constraint uqConsumableName unique,
AlternateName varchar(100),
UnitMeasureID varchar(10) constraint fkUnitMeasureIDConsumableItems references LookupData (DataID),
OrderLevel int constraint dfOrderLevelConsumableItems default 0,
KeepingUnit int constraint dfKeepingUnitConsumableItems default 0,
UnitCost money,
UnitPrice money,
LastUpdate smalldatetime,
Halted bit constraint dfHaltedConsumableItems default 0,
Hidden bit constraint dfHiddenConsumableItems default 0,
UnitsInStock int constraint dfUnitsInStockConsumableItems default 0,
BatchNo varchar(20) constraint dfBatchNoConsumableItems default '',
ExpiryDate smalldatetime constraint dfExpiryDateConsumableItems default '1 Jan 1900'
)
go

---------------------------------------------------------------------------------
---------------Added update on Mon 04-11-13 -------------------------------------
---------------------------------------------------------------------------------

-----------Inventory----------------------------------------------------------------

alter table Inventory drop constraint fkDrugNoInventory

-----------Inventory-----------------------------------------------------------------

exec sp_rename 'Inventory.DrugNo', 'ItemCode', 'COLUMN'

alter table Inventory add
LocationID varchar(10) constraint fkLocationIDInventory references LookupData (DataID),
ItemCategoryID varchar(10) constraint fkItemCategoryIDInventory references LookupData (DataID)

update Inventory set LocationID = '11702' where LocationID is null
update Inventory set ItemCategoryID = '7D' where ItemCategoryID is null

exec uspEditOptions 'AllowInsuranceDirectLinkedMember', 0, '3BIT', 1, 0
exec uspEditOptions 'ForceDiagnosisOnPrescription', 0, '3BIT', 1, 0

delete from LookupData where ObjectID = 112

--------------Optical--------------------------------------------------------------------------------------

alter table Optical add Pd smallint, Sg smallint

---------------------------------------------------------------------------------
---------------Added update on Mon 19-11-13 -------------------------------------
---------------------------------------------------------------------------------

-----------AssociatedBillCustomers-----------------------------------------------

create table AssociatedBillCustomers
(AccountNo varchar(20) not null constraint fkAccountNoAssociatedBillCustomers 
references BillCustomers (AccountNo) on delete cascade on update cascade,
AssociatedBillNo varchar(20) not null constraint fkAssociatedBillNoAssociatedBillCustomers 
references BillCustomers (AccountNo),
constraint pkAccountNoAssociatedBillNo primary key(AccountNo, AssociatedBillNo)
)
go

-----------------------Visits--------------------------------------------------------------------------------

alter table Visits add
AssociatedBillNo varchar(20) null constraint fkAssociatedBillNoVisits references BillCustomers (AccountNo)

---------------------------------------------------------------------------------
---------------Added update on Fri 22-11-2013 ----------------------------------
---------------------------------------------------------------------------------

--------------Services-----------------------------------------------------------
alter table Services alter column ServiceName varchar(100)

-----------Admissions----------------------------------------------------------------------------------

alter table Admissions add
StaffNo varchar(10) constraint fkStaffNoAdmissions references Staff (StaffNo)

update Admissions set StaffNo = dbo.GetDoctorStaffNo(VisitNo) 
where VisitNo in (select VisitNo from DoctorVisits) and  StaffNo is null

-- For Case run commented below others run uncommented
-- update Admissions set StaffNo = 'D001' where StaffNo is null
update Admissions set StaffNo = '100' where StaffNo is null

exec uspEditOptions 'ForcePatientGeographicalLocation', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Thu 28-11-2013 -----------------------------------
---------------------------------------------------------------------------------

--------------EyeServices--------------------------------------------------------

create table EyeServices
(EyeCode varchar(20) not null constraint pkEyeCode primary key,
EyeName varchar(200) constraint uqEyeName unique,
UnitCost money,
UnitPrice money,
Hidden bit constraint dfHiddenEyeServices default 0
)
go

exec uspEditOptions 'AllowDispensingExpiredConsumables', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Thu 10-12-2013 -----------------------------------
---------------------------------------------------------------------------------

--------------ImportDataInfo-----------------------------------------------------

-- run commented below for clients with earlier version of ImportDataInfo
-- drop table ImportDataInfo

create table ImportDataInfo
(ItemCode varchar(20) not null constraint fkItemCodeImportDataInfo references LabTests (TestCode),
SourceName varchar(60) not null,
constraint pkItemCodeSourceName primary key(ItemCode, SourceName),
SourceCaption varchar(100) constraint uqItemCodeSourceCaption unique(ItemCode, SourceCaption),
DatabaseTypeID varchar(10) constraint fkDatabaseTypeIDImportDataInfo references LookupData (DataID),
ConnectionModeID varchar(10) constraint fkConnectionModeIDImportDataInfo references LookupData (DataID),
ImportServer varchar(100),
ImportLogin varchar(100),
ImportPassword nvarchar(100),
SP_Name varchar(100)
)
go

---------------------------------------------------------------------------------
---------------Added update on Tue 24-12-2013 -----------------------------------
---------------------------------------------------------------------------------

-----------Beds------------------------------------------------------------------

alter table Beds add
UnitCost money, Hidden bit constraint dfHiddenBeds default 0

update Beds set UnitCost = 0 where UnitCost is null
update Beds set Hidden = 0 where Hidden is null

---------------------------------------------------------------------------------
---------------Added update on Fri 03-01-14 -------------------------------------
---------------------------------------------------------------------------------

-----------ProductOwnerInfo-----------------------------------------------------------

alter table ProductOwnerInfo add AlternatePhone varchar(100), AlternateEmail varchar(100)

-- run common scripts

exec uspEditOptions 'AllowPrintingBeforeDispensing', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Sat 18-01-2014 -----------------------------------
---------------------------------------------------------------------------------

---------------ImportDataInfo----------------------------------------------------
alter table ImportDataInfo drop constraint pkItemCodeSourceName
alter table ImportDataInfo drop constraint uqItemCodeSourceCaption

--------------ImportDataInfo-----------------------------------------------------
alter table ImportDataInfo alter column SourceCaption varchar(100) not null

--------------ImportDataInfo-----------------------------------------------------
alter table ImportDataInfo add 
constraint pkItemCodeSourceNameSourceCaption 
primary key(ItemCode, SourceName, SourceCaption)

---------------------------------------------------------------------------------
---------------Added update on Wen 22-01-14 -------------------------------------
---------------------------------------------------------------------------------

-----------Payments----------------------------------------------------------------------------------
alter table Payments add
ClientMachine varchar(40) constraint dfClientMachinePayments default host_name()

update Payments set ClientMachine = host_name() where ClientMachine is null

-----------Accounts-------------------------------------------------------------------------------------
alter table Accounts add
ClientMachine varchar(40) constraint dfClientMachineAccounts default host_name()

update Accounts set ClientMachine = host_name() where ClientMachine is null

-----------OtherIncome----------------------------------------------------------------------------------
alter table OtherIncome add
ClientMachine varchar(40) constraint dfClientMachineOtherIncome default host_name()

update OtherIncome set ClientMachine = host_name() where ClientMachine is null

-----------Refunds--------------------------------------------------------------------------------------
alter table Refunds add
ClientMachine varchar(40) constraint dfClientMachineRefunds default host_name()

update Refunds set ClientMachine = host_name() where ClientMachine is null

-----------Expenditure----------------------------------------------------------------------------------
alter table Expenditure add
ClientMachine varchar(40) constraint dfClientMachineExpenditure default host_name()

update Expenditure set ClientMachine = host_name() where ClientMachine is null

-----------Patients--------------------------------------------------------------------------------------
alter table Patients add
ClientMachine varchar(40) constraint dfClientMachinePatients default host_name()

update Patients set ClientMachine = host_name() where ClientMachine is null

-----------Visits----------------------------------------------------------------------------------
alter table Visits add
ClientMachine varchar(40) constraint dfClientMachineVisits default host_name()

update Visits set ClientMachine = host_name() where ClientMachine is null

---------------------------------------------------------------------------------
---------------Added update on Wen 22-01-14 -------------------------------------
---------------------------------------------------------------------------------

-----------OutwardFiles----------------------------------------------------------------------------------

create table OutwardFiles
(OutwardID int not null constraint dfOutwardIDOutwardFiles default 1,
OutwardNo varchar(20) not null constraint pkOutwardNoOutwardFiles primary key,
FileNo varchar(20) constraint fkFileNoOutwardFiles references Patients (PatientNo)
on delete cascade on update cascade,
TakenDateTime smalldatetime,
TakenBy varchar(100),
BillAccountName varchar(100),
LoginID varchar(20) constraint fkLoginIDOutwardFiles references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOutwardFiles default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeOutwardFiles default getdate()
)
go

-----------InwardFiles--------------------------------------------------------------------------------------

create table InwardFiles
(OutwardNo varchar(20) not null constraint fkOutwardNoInwardFiles 
references OutwardFiles (OutwardNo) on delete cascade on update cascade
constraint pkOutwardNoInwardFiles primary key,
ReturnDateTime smalldatetime,
ReturnedBy varchar(100),
LoginID varchar(20) constraint fkLoginIDInwardFiles references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInwardFiles default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInwardFiles default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Fri 28-02-14 -------------------------------------
---------------------------------------------------------------------------------

-----------OutwardFiles-----------------------------------------------------------

alter table OutwardFiles add
VisitNo varchar(20) null constraint fkVisitNoOutwardFiles references Visits (VisitNo)

-----------ProductOwnerInfo------------------------------------------------------

alter table ProductOwnerInfo add AlternatePhoto image

-- run common

-----------ReturnedExtraBillItems--------------------------------------------------

create table ReturnedExtraBillItems
(ExtraBillNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkExtraBillNoItemCodeItemCategoryIDReturnedExtraBillItems foreign key (ExtraBillNo, ItemCode, ItemCategoryID) 
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkExtraBillNoItemCodeItemCategoryIDReturnedExtraBillItems primary key(ExtraBillNo, ItemCode, ItemCategoryID),
ReturnDate smalldatetime,
Quantity int,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDReturnedExtraBillItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineReturnedExtraBillItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeReturnedExtraBillItems default getdate()
)
go

exec uspEditOptions 'OpenIPDDispenseAfterPrescription', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Tue 18-03-14 -------------------------------------
---------------------------------------------------------------------------------

-----------QuickSearchColumns-----------------------------------------------------

create table QuickSearchColumns
(SortOrder int not null identity(1,1),
ObjectName varchar(40) not null 
constraint fkObjectNameQuickSearchColumns references SearchObjects(ObjectName),
ColumnName varchar(200) not null,
constraint pkColumnNameObjectNameQuickSearchColumns primary key(ObjectName, ColumnName),
ColumnCaption varchar(200) not null,
constraint uqObjectNameColumnCaptionQuickSearchColumns unique(ObjectName, ColumnCaption),
ColumnReference varchar(200) not null,
constraint uqObjectNameColumnReferenceQuickSearchColumns unique(ObjectName, ColumnReference),
SearchCriterionID varchar(10) not null constraint fkSearchCriterionIDQuickSearchColumns references LookupData (DataID),
Searchable bit constraint dfSearchableQuickSearchColumns default 0
)
go

---------------------------------------------------------------------------------
---------------Added update on Thu 10-04-14 -------------------------------------
---------------------------------------------------------------------------------

-------------- ServerCredentials --------------------------------------------------------------------

create table ServerCredentials
(SourceName varchar(60) not null constraint pkSourceNameServerCredentials primary key,
ConnectionModeID varchar(10) constraint fkConnectionModeIDServerCredentials references LookupData (DataID),
SourceLogin varchar(100),
SourcePassword nvarchar(100)
)
go

--- run common

-------------- InventoryLocation --------------------------------------------------------------------

-- run commented below only for The Surgeons Plaza
-- 	drop table InventoryLocation

create table InventoryLocation
(LocationID varchar(10) not null constraint fkLocationIDInventoryLocation references LookupData (DataID),
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInventoryLocation references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkLocationIDItemCategoryIDItemCode primary key(LocationID, ItemCategoryID, ItemCode),
UnitsAtHand int,
BatchNo varchar(20),
ExpiryDate smalldatetime
)
go

---------------------------------------------------------------------------------
---------------Added update on Sat 26-04-14 -------------------------------------
---------------------------------------------------------------------------------

-----------ProductOwnerInfo-----------------------------------------------------------

alter table ProductOwnerInfo add 
PrintHeaderAlignmentID varchar(10)constraint fkPrintHeaderAlignmentIDProductOwner references LookupData (DataID),
LogoTopMargin tinyint constraint dfLogoTopMarginProductOwner default 1,
TextTopMargin tinyint constraint dfTextTopMarginProductOwner default 1

--- run data scripts
update ProductOwnerInfo set PrintHeaderAlignmentID = '120LTTB' where PrintHeaderAlignmentID is null
update ProductOwnerInfo set LogoTopMargin = 1 where LogoTopMargin is null
update ProductOwnerInfo set TextTopMargin = 1 where TextTopMargin is null

-- run common scripts

---------------------------------------------------------------------------------
---------------Added update on Thu 01-05-14 -------------------------------------
---------------------------------------------------------------------------------

-----------Inventory----------------------------------------------------------------------------------
alter table Inventory add
ClientMachine varchar(40) constraint dfClientMachineInventory default host_name()

update Inventory set ClientMachine = host_name() where ClientMachine is null

-----------ItemsEXT----------------------------------------------------------------------------------
alter table ItemsEXT add
LocationID varchar(10) null constraint fkLocationIDItemsEXT references LookupData (DataID),
ClientMachine varchar(40) constraint dfClientMachineItemsEXT default host_name()

update ItemsEXT set LocationID = '11702' where LocationID is null
update ItemsEXT set ClientMachine = host_name() where ClientMachine is null

-----------IPDItemsEXT----------------------------------------------------------------------------------
alter table IPDItemsEXT add
LocationID varchar(10) constraint fkLocationIDIPDItemsEXT references LookupData (DataID),
ClientMachine varchar(40) constraint dfClientMachineIPDItemsEXT default host_name()

update IPDItemsEXT set LocationID = '11702' where LocationID is null
update IPDItemsEXT set ClientMachine = host_name() where ClientMachine is null

-----------Items----------------------------------------------------------------------------------
alter table Items add
ClientMachine varchar(40) constraint dfClientMachineItems default host_name()

update Items set ClientMachine = host_name() where ClientMachine is null

-----------IPDItems----------------------------------------------------------------------------------
alter table IPDItems add
ClientMachine varchar(40) constraint dfClientMachineIPDItems default host_name()

update IPDItems set ClientMachine = host_name() where ClientMachine is null

-----------Inventory-----------------------------------------------------------------
alter table Inventory add LocationUnits int

update Inventory set LocationUnits = Balance where LocationUnits is null

exec uspEditOptions 'AllowManualIssuingToNegative', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowLocationIssuingToNegative', 0, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Thu 15-05-14 -------------------------------------
---------------------------------------------------------------------------------

-----------ProductOwnerInfo------------------------------------------------------

alter table ProductOwnerInfo add 
LogoLeftMargin tinyint constraint dfLogoLeftMarginProductOwner default 1,
TextLeftMargin tinyint constraint dfTextLeftMarginProductOwner default 1

update ProductOwnerInfo set LogoLeftMargin = 1 where LogoLeftMargin is null
update ProductOwnerInfo set TextLeftMargin = 1 where TextLeftMargin is null

-- run common scripts

---------------------------------------------------------------------------------
---------------Added update on Tue 09-06-14 -------------------------------------
---------------------------------------------------------------------------------

-----------Triage----------------------------------------------------------------

alter table Triage add
OxygenSaturation decimal(5,2) constraint ckOxygenSaturation check (OxygenSaturation > 0 and OxygenSaturation <= 100),
HeartRate tinyint constraint ckHeartRate check (HeartRate > 0 and HeartRate <= 250),
ClientMachine varchar(40) constraint dfClientMachineTriage default host_name()

update Triage set ClientMachine = host_name() where ClientMachine is null

-----------Companies-----------------------------------------------------------------

alter table Companies
alter column ContactPerson varchar(100)

alter table Companies
alter column Address varchar(200)

-----------HealthUnits-----------------------------------------------------------------

alter table HealthUnits
alter column ContactPerson varchar(100)

alter table HealthUnits
alter column Address varchar(200)

alter table HealthUnits
alter column Phone varchar(100)

---------------------------------------------------------------------------------
---------------Added update on Thu 19-06-14 -------------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'AllowGenerateSelfRequestsNo', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowAccessCashDischarges', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableAccessCashServices', 0, '3BIT', 1, 0

----------------------------------------------------------------------------------------
---------------Added update on 01 Jul 2014 ---------------------------------------------
----------------------------------------------------------------------------------------

-----------SchemeMembers----------------------------------------------------------------

alter table SchemeMembers add
MedicalCardID int not null constraint dfMedicalCardIDSchemeMembers default 1,
MainMemberID int not null constraint dfMainMemberIDSchemeMembers default 0,
Relationship varchar(41)

update SchemeMembers set MedicalCardID = 1 where MedicalCardID is null
update SchemeMembers set MainMemberID = 0 where MainMemberID is null
update SchemeMembers set Relationship = '' where Relationship is null

-- run common scripts

exec uspEditOptions 'EnableSetAssociatedBillCustomer', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSetInventoryLocation', 0, '3BIT', 1, 0

exec uspEditOptions 'MedicalCardNoPrefix', '', '3STR', 10, 1
exec uspEditOptions 'SelfRequestNoPrefix', 'SR', '3STR', 10, 1

---------------------------------------------------------------------------------
---------------Added update on Wen 16-07-2014 -----------------------------------
---------------------------------------------------------------------------------

--------------ClaimDetails-------------------------------------------------------

alter table ClaimDetails alter column Notes varchar(400)
alter table ClaimDetails add Adjustment money
update ClaimDetails set Adjustment = 0 where Adjustment is null

---------------------------------------------------------------------------------
---------------Added update on Fri 18-07-2014 -----------------------------------
---------------------------------------------------------------------------------

-----------SchemeMembers---------------------------------------------------------

alter table SchemeMembers add
ClientMachine varchar(40) constraint dfClientMachineSchemeMembers default host_name()

update SchemeMembers set ClientMachine = host_name() where ClientMachine is null

-----------Admissions------------------------------------------------------------

exec sp_rename 'Admissions.AdmissionDate', 'AdmissionDateTime', 'COLUMN'

alter table Admissions add
ClientMachine varchar(40) constraint dfClientMachineAdmissions default host_name()

-- run utilities first then run below

update Admissions set ClientMachine = host_name() where ClientMachine is null

-----------Items---------------------------------------------------------------------

alter table Items 
add UnitCost money constraint dfUnitCostItems default 0

update Items set UnitCost = 0 where UnitCost is null

-----------IPDItems------------------------------------------------------------------

alter table IPDItems
add UnitCost money constraint dfUnitCostIPDItems default 0

update IPDItems set UnitCost = 0 where UnitCost is null

-----------ExtraBillItems------------------------------------------------------------

alter table ExtraBillItems add
UnitCost money constraint dfUnitCostExtraBillItems default 0,
ClientMachine varchar(40) constraint dfClientMachineExtraBillItems default host_name()

update ExtraBillItems set UnitCost = 0 where UnitCost is null

update ExtraBillItems set ClientMachine = host_name() where ClientMachine is null

---------------------------------------------------------------------------------
---------------Added update on Wen 06-08-2014 -----------------------------------
---------------------------------------------------------------------------------

-------------- InventoryOrders --------------------------------------------------------------------

create table InventoryOrders
(OrderID int not null constraint dfOrderIDInventoryOrders default 1,
OrderNo varchar(20) not null constraint pkOrderNoInventoryOrders primary key,
OrderDate smalldatetime,
FromLocationID varchar(10) constraint fkFromLocationIDInventoryOrders references LookupData (DataID),
ToLocationID varchar(10) constraint fkToLocationIDInventoryOrders references LookupData (DataID),
LoginID varchar(20)constraint fkLoginIDInventoryOrders references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryOrders default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryOrders default getdate()
)
go

-------------- InventoryOrderDetails --------------------------------------------------------------------

create table InventoryOrderDetails
(OrderNo varchar(20) not null constraint fkOrderNoInventoryOrderDetails 
references InventoryOrders (OrderNo)on delete cascade on update cascade, 
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInventoryOrderDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkOrderNoItemCategoryIDItemCodeInventoryOrderDetails primary key(OrderNo, ItemCategoryID, ItemCode),
Quantity int,
LoginID varchar(20) constraint fkLoginIDInventoryOrderDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryOrderDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryOrderDetails default getdate()
)
go

-------------- InventoryTransfers --------------------------------------------------------------------

--- run commented  belowfor APH            
-- drop table InventoryTransfers

create table InventoryTransfers
(TransferID int not null constraint dfTransferIDInventoryTransfers default 1,
TransferNo varchar(20) not null constraint pkTransferNoInventoryTransfers primary key,
TransferDate smalldatetime,
FromLocationID varchar(10) constraint fkFromLocationIDInventoryTransfers references LookupData (DataID),
ToLocationID varchar(10) constraint fkToLocationIDInventoryTransfers references LookupData (DataID),
OrderNo varchar(20) null constraint fkOrderNoInventoryTransfers references InventoryOrders (OrderNo),
LoginID varchar(20)constraint fkLoginIDInventoryTransfers references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryTransfers default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryTransfers default getdate()
)
go

-------------- InventoryTransferDetails ------------------------------------------------------

create table InventoryTransferDetails
(TransferNo varchar(20) not null constraint fkTransferNoInventoryTransferDetails 
references InventoryTransfers (TransferNo)on delete cascade on update cascade, 
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDInventoryTransferDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkTransferNoItemCategoryIDItemCodeInventoryTransferDetails primary key(TransferNo, ItemCategoryID, ItemCode),
Quantity int,
BatchNo varchar(20),
ExpiryDate smalldatetime,
StockStatusID varchar(10) constraint fkStockStatusIDInventoryTransferDetails references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDInventoryTransferDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryTransferDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryTransferDetails default getdate()
)
go

-------------- InventoryAcknowledges ------------------------------------------------------

create table InventoryAcknowledges
(TransferNo varchar(20) not null,
ItemCategoryID varchar(10) not null,
ItemCode varchar(20) not null,
constraint fkTransferNoItemCategoryIDItemCodeInventoryAcknowledges foreign key (TransferNo, ItemCategoryID, ItemCode) 
references InventoryTransferDetails (TransferNo, ItemCategoryID, ItemCode) on delete cascade on update cascade ,
constraint pkTransferNoItemCategoryIDItemCodeInventoryAcknowledges primary key(TransferNo, ItemCategoryID, ItemCode),
ReceivedDate smalldatetime,
LoginID varchar(20) constraint fkLoginIDInventoryAcknowledges references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineInventoryAcknowledges default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeInventoryAcknowledges default getdate()
)
go

-- run common

---------------------------------------------------------------------------------
---------------Added update on Sun 31-08-2014 -----------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'EnableInventoryPhysicalStockEntry', 0, '3BIT', 1, 0

-----------BillCustomers---------------------------------------------------------

alter table BillCustomers add
AllowOnlyListedMember bit constraint dfAllowOnlyListedMemberBillCustomers default 0

update BillCustomers set AllowOnlyListedMember = 0 where AllowOnlyListedMember is null

-----------Payments----------------------------------------------------------------------------------

alter table Payments add
FilterNo varchar(20) null constraint fkFilterNoPayments references Visits (VisitNo)

---------------------------------------------------------------------------------
---------------Added update on Tue 09-09-2014 -----------------------------------
---------------------------------------------------------------------------------

-----------MemberBenefits----------------------------------------------------------------------------

create table MemberBenefits
(BenefitCode varchar(20) not null constraint pkBenefitCodeMemberBenefits primary key,
BenefitName varchar(100) constraint uqBenefitNameMemberBenefits unique,
ItemCategoryID varchar(10) null constraint fkItemCategoryIDMemberBenefits references LookupData (DataID)
)
go

-------------- MemberBenefits -----------------------------------------------------------------

-- First run ManageDatabase

exec uspInsertMemberBenefits '7S', 'Service', '7S'
exec uspInsertMemberBenefits '7D', 'Drug', '7D'
exec uspInsertMemberBenefits '7C', 'Consumable', '7C'
exec uspInsertMemberBenefits '7P', 'Procedure', '7P'
exec uspInsertMemberBenefits '7T', 'Test', '7T'
exec uspInsertMemberBenefits '7R', 'Radiology', '7R'
exec uspInsertMemberBenefits '7N', 'Dental', '7N'
exec uspInsertMemberBenefits '7H', 'Theatre', '7H'
exec uspInsertMemberBenefits '7O', 'Optical', '7O'
exec uspInsertMemberBenefits '7M', 'Maternity', '7M'
exec uspInsertMemberBenefits '7I', 'ICU', '7I'
exec uspInsertMemberBenefits '7E', 'Extras', '7E'
exec uspInsertMemberBenefits '7Y', 'Eye', '7Y'
exec uspInsertMemberBenefits '7A', 'Admission', '7A'
exec uspInsertMemberBenefits '7OP', 'Out Patient'
exec uspInsertMemberBenefits '7IP', 'In Patient'
go

-----------MemberLimits------------------------------------------------------------

exec sp_rename 'MemberLimits.ItemCategoryID', 'BenefitCode', 'COLUMN'

alter table MemberLimits drop constraint fkItemCategoryIDMemberLimits

alter table MemberLimits drop constraint pkMedicalCardNoAccountNoItemCategoryID

alter table MemberLimits alter column BenefitCode varchar(20) not null

alter table MemberLimits
add constraint fkBenefitCodeMemberLimits foreign key (BenefitCode) 
references MemberBenefits (BenefitCode)

alter table MemberLimits add constraint pkMedicalCardNoAccountNoBenefitCode 
primary key(MedicalCardNo, AccountNo, BenefitCode)

-----------PolicyLimits------------------------------------------------------------

exec sp_rename 'PolicyLimits.ItemCategoryID', 'BenefitCode', 'COLUMN'

alter table PolicyLimits drop constraint fkItemCategoryIDPolicyLimits

alter table PolicyLimits drop constraint pkCompanyNoPolicyNoItemCategoryID

alter table PolicyLimits alter column BenefitCode varchar(20) not null

alter table PolicyLimits
add constraint fkBenefitCodePolicyLimits foreign key (BenefitCode) 
references MemberBenefits (BenefitCode)

alter table PolicyLimits add constraint pkCompanyNoPolicyNoBenefitCode 
primary key (CompanyNo, PolicyNo, BenefitCode)

-----------ClaimDetails------------------------------------------------------------

exec sp_rename 'ClaimDetails.ItemCategoryID', 'BenefitCode', 'COLUMN'

alter table ClaimDetails drop constraint fkItemCategoryIDClaimDetails

alter table ClaimDetails alter column BenefitCode varchar(20)

alter table ClaimDetails
add constraint fkBenefitCodeClaimDetails foreign key (BenefitCode) 
references MemberBenefits (BenefitCode)

--------------ClaimDetails-------------------------------------------------------

alter table ClaimDetails add 
LimitAmount money constraint dfLimitAmountClaimDetails default 0,
ConsumedAmount money constraint dfConsumedAmountClaimDetails default 0,
LimitBalance money constraint dfLimitBalanceClaimDetails default 0

--- run utilities

update ClaimDetails set LimitAmount = 0 where LimitAmount is null

update ClaimDetails set ConsumedAmount = 0 where ConsumedAmount is null

update ClaimDetails set LimitBalance = 0 where LimitBalance is null

-------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Mon 27-10-2014 -----------------------------------
---------------------------------------------------------------------------------

-----------Licenses----------------------------------------------------------------------------

alter table Licenses add LCD nvarchar(100)

update Licenses set LCD = LSD where LCD is null

alter table Licenses alter column LCD nvarchar(100) not null

---- run common

-----------VisionAssessment----------------------------------------------------------------------------

create table VisionAssessment
(VisitNo varchar(20) not null constraint fkVisitNoVisionAssessment references Visits (VisitNo),
EntryOrder int not null constraint dfVisionAssessment default 1,
EyeTestID varchar(10) not null constraint fkEyeTestIDVisionAssessment references LookupData (DataID),
constraint pkVisitNoEyeTestID primary key(VisitNo, EyeTestID),
VisualAcuityRightID varchar(10)constraint fkVisualAcuityRightIDVisionAssessment references LookupData (DataID),
VisualAcuityRightExtID varchar(10)constraint fkVisualAcuityRightExtIDVisionAssessment references LookupData (DataID),
VisualAcuityLeftID varchar(10)constraint fkVisualAcuityLeftIDVisionAssessment references LookupData (DataID),
VisualAcuityLeftExtID varchar(10)constraint fkVisualAcuityLeftExtIDVisionAssessment references LookupData (DataID),
HandMovementRightID varchar(10)constraint fkHandMovementRightIDVisionAssessment references LookupData (DataID),
HandMovementLeftID varchar(10)constraint fkHandMovementLeftIDVisionAssessment references LookupData (DataID),
PerceptionOfLightRightID varchar(10)constraint fkPerceptionOfLightRightIDVisionAssessment references LookupData (DataID),
PerceptionOfLightLeftID varchar(10)constraint fkPerceptionOfLightLeftIDVisionAssessment references LookupData (DataID),
ClinicalCommentID varchar(10)constraint fkClinicalCommentIDVisionAssessment references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20)constraint fkLoginIDVisionAssessment references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineVisionAssessment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeVisionAssessment default getdate()
)
go

-----------EyeAssessment----------------------------------------------------------------------------

create table EyeAssessment
(VisitNo varchar(20) not null constraint fkVisitNoEyeAssessment references Visits (VisitNo)
constraint pkVisitNoEyeAssessment primary key,
LeftPupil varchar(200),
RightPupil varchar(200),
LeftLidMargin varchar(200),
RightLidMargin varchar(200),
LeftConjuctiva varchar(200),
RightConjuctiva varchar(200),
LeftBulbarConjuctiva varchar(200),
RightBulbarConjuctiva varchar(200),
LeftCentralCornea varchar(200),
RightCentralCornea varchar(200),
LeftVerticalCornea varchar(200),
RightVerticalCornea varchar(200),
LeftAnteriorChamber varchar(200),
RightAnteriorChamber varchar(200),
LeftIrish varchar(200),
RightIrish varchar(200),
LeftAnteriorChamberAngle varchar(200),
RightAnteriorChamberAngle varchar(200),
LeftRetina varchar(200),
RightRetina varchar(200),
LeftMacular varchar(200),
RightMacular varchar(200),
LeftOpticDisc varchar(200),
RightOpticDisc varchar(200),
LeftIOP Decimal(6,2),
RightIOP Decimal(6,2),
LeftVitreous varchar(200),
RightVitreous varchar(200),
LeftLense varchar(200),
RightLense varchar(200),
EyeNotes varchar(200),
LeftEyeBall varchar(200),
RightEyeBall varchar(200),
LeftOrbit varchar(200),
RightOrbit varchar(200),
LoginID varchar(20) constraint fkLoginIDEyeAssessment references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineEyeAssessment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeEyeAssessment default getdate()
)
go

---------------------------------------------------------------------------------
---------------Added update on Thu 06-11-2014 -----------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'AllowPrescriptionExpiredConsumables', 1, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Tue 18-11-2014 -----------------------------------
---------------------------------------------------------------------------------

drop function GetHasVisionAssessmentTwo

exec sp_rename 'EyeAssessment.LeftMapular', 'LeftMacular', 'COLUMN'
exec sp_rename 'EyeAssessment.RightMapular', 'RightMacular', 'COLUMN'
exec sp_rename 'EyeAssessment.LeftOpticalDisc', 'LeftOpticDisc', 'COLUMN'
exec sp_rename 'EyeAssessment.RightOpticalDisc', 'RightOpticDisc', 'COLUMN'

-----------EyeAssessment----------------------------------------------------------------------------

alter table EyeAssessment add
LeftIOP Decimal(6,2), RightIOP Decimal(6,2), LeftVitreous varchar(200),
RightVitreous varchar(200), LeftLense varchar(200), RightLense varchar(200)

---------------------------------------------------------------------------------
---------------Added update on Sat 06-12-2014 -----------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'OpenIssueConsumablesAfterPrescription', 0, '3BIT', 1, 0

-----------OutwardFiles----------------------------------------------------------------------------

alter table OutwardFiles drop constraint fkVisitNoOutwardFiles

alter table OutwardFiles add constraint fkVisitNoOutwardFiles foreign key (VisitNo) 
references Visits (VisitNo) on delete cascade on update cascade

---------------------------------------------------------------------------------
---------------Added update on Sun 14-12-2014 -----------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'AllowInventoryManualIssuing', 1, '3BIT', 1, 0

---------------------------------------------------------------------------------
---------------Added update on Fri 19-12-2014 -----------------------------------
---------------------------------------------------------------------------------

-----------EyeAssessment----------------------------------------------------------------------------

exec sp_rename 'EyeAssessment.LeftUpperConjuctiva', 'LeftConjuctiva', 'COLUMN'
exec sp_rename 'EyeAssessment.RightUpperConjuctiva', 'RightConjuctiva', 'COLUMN'
exec sp_rename 'EyeAssessment.LeftLowerConjuctiva', 'LeftBulbarConjuctiva', 'COLUMN'
exec sp_rename 'EyeAssessment.RightLowerConjuctiva', 'RightBulbarConjuctiva', 'COLUMN'

alter table EyeAssessment add
EyeNotes varchar(200), LeftEyeBall varchar(200),
RightEyeBall varchar(200), LeftOrbit varchar(200), RightOrbit varchar(200)

alter table EyeAssessment drop constraint fkVisitNoEyeAssessment

alter table EyeAssessment add constraint fkVisitNoEyeAssessment foreign key (VisitNo) 
references Visits (VisitNo) on delete cascade on update cascade

---------------------------------------------------------------------------------
---------------Added update on Fri 02-01-2015 -----------------------------------
---------------------------------------------------------------------------------

-----------EyeAssessment----------------------------------------------------------------------------

alter table EyeAssessment alter column LeftIOP varchar(10)

alter table EyeAssessment alter column RightIOP varchar(10)

---------------------------------------------------------------------------------
---------------Added update on Fri 19-01-2015 -----------------------------------
---------------------------------------------------------------------------------

exec uspEditOptions 'DisablePatientSignOnInvoices', 0, '3BIT', 1, 0
exec uspEditOptions 'AllowAccessOPDTheatre', 0, '3BIT', 1, 0

-----------Suppliers----------------------------------------------------------------------------

create table Suppliers
(SupplierID int not null constraint dfSupplierIDSuppliers default 1,
SupplierNo varchar(20) not null constraint pkSupplierNo primary key,
SupplierName varchar(60) constraint uqSupplierName unique,
ContactPerson varchar(100),
Address varchar(200),
Phone varchar(30)
)
go

-----------TheatreOperations------------------------------------------------------------

alter table TheatreOperations drop constraint fkVisitNoTheatreOperations

alter table TheatreOperations add constraint fkVisitNoTheatreOperations foreign key (VisitNo) 
references Visits (VisitNo) on delete cascade on update cascade

---------------------------------------------------------------------------------
---------------Added update on Mon 16-02-2015 -----------------------------------
---------------------------------------------------------------------------------

-----------IPDVisionAssessment----------------------------------------------------------------------------

create table IPDVisionAssessment
(VARoundID int constraint dfVARoundIDIPDVisionAssessment default 1,
AdmissionNo varchar(20)constraint fkAdmissionNoIPDVisionAssessment references Admissions (AdmissionNo),
VARoundNo Varchar(20) not null,
RoundDateTime smalldatetime constraint dfRoundDateTimeIPDVisionAssessment default getdate(),
EyeTestID varchar(10) not null constraint fkEyeTestIDIPDVisionAssessment references LookupData (DataID),
constraint pkVARoundNoEyeTestID primary key(VARoundNo, EyeTestID),
VisualAcuityRightID varchar(10)constraint fkVisualAcuityRightIDIPDVisionAssessment references LookupData (DataID),
VisualAcuityRightExtID varchar(10)constraint fkVisualAcuityRightExtIDIPDVisionAssessment references LookupData (DataID),
VisualAcuityLeftID Varchar(10)constraint fkVisualAcuityLeftIDIPDVisionAssessment references LookupData (DataID),
VisualAcuityLeftExtID Varchar(10)constraint fkVisualAcuityLeftExtIDIPDVisionAssessment references LookupData (DataID),
HandMovementRightID Varchar(10)constraint fkHandMovementRightIDIPDVisionAssessment references LookupData (DataID),
HandMovementLeftID Varchar(10)constraint fkHandMovementLeftIDIPDVisionAssessment references LookupData (DataID),
PerceptionOfLightRightID Varchar(10)constraint fkPerceptionOfLightRightIDIPDVisionAssessment references LookupData (DataID),
PerceptionOfLightLeftID Varchar(10)constraint fkPerceptionOfLightLeftIDIPDVisionAssessment references LookupData (DataID),
ClinicalComment Varchar(10)constraint fkClinicalCommentIPDVisionAssessment references LookupData (DataID),
Notes Varchar(200),
LoginID varchar(20)
constraint fkLoginIDIPDVisionAssessment references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDVisionAssessment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDVisionAssessment default getdate()
)
go

----------------IPDEyeAssessment---------------------------------------------------------------------------------------------

create table IPDEyeAssessment(
RoundNo varchar(20) not null constraint pkRoundNoIPDEyeAssessment primary key
constraint fkRoundNoIPDEyeAssessment references IPDDoctor (RoundNo)
on delete cascade on update cascade,
LeftPupil varchar(200),
RightPupil varchar(200),
LeftLidMargin varchar(200),
RightLidMargin varchar(200),
LeftConjuctiva varchar(200),
RightConjuctiva varchar(200),
LeftBulbarConjuctiva varchar(200),
RightBulbarConjuctiva varchar(200),
LeftCentralCornea varchar(200),
RightCentralCornea varchar(200),
LeftVerticalCornea varchar(200),
RightVerticalCornea varchar(200),
LeftAnteriorChamber varchar(200),
RightAnteriorChamber varchar(200),
LeftIrish varchar(200),
RightIrish varchar(200),
LeftAnteriorChamberAngle varchar(200),
RightAnteriorChamberAngle varchar(200),
LeftRetina varchar(200),
RightRetina varchar(200),
LeftMacular varchar(200),
RightMacular varchar(200),
LeftOpticDisc varchar(200),
RightOpticDisc varchar(200),
LeftIOP varchar(10),
RightIOP varchar(10),
LeftVitreous varchar(200),
RightVitreous varchar(200),
LeftLense varchar(200),
RightLense varchar(200),
EyeNotes varchar(200),
LeftEyeBall varchar(200),
RightEyeBall varchar(200),
LeftOrbit varchar(200),
RightOrbit varchar(200),
LoginID varchar(20)
constraint fkLoginIDIPDEyeAssessment references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDEyeAssessment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDEyeAssessment default getdate()
)
go

----------------Orthoptics---------------------------------------------------------------------------------------------

create table Orthoptics
(VisitNo varchar(20) constraint pkVisitNoOrthoptics primary key 
constraint fkVisitNoOrthoptics references Visits (VisitNo) on delete cascade on update cascade,
HeadPosture varchar(200),
Fixation varchar(200),
LeftHirschberg varchar(200),
RightHirschberg varchar(200),
RightEOM varchar(200),
LeftEOM varchar(200),
CoverTestID varchar(10)
constraint fkCoverTestIDOrthoptics references LookupData (DataID),
LeftAPCTGlasses varchar(200),
RightAPCTGlasses varchar(200),
LeftAPCTWithOutGlasses varchar(200),
RightAPCTWithOutGlasses varchar(200),
Correspondence varchar(200),
PrismAdaptation varchar(200),
FusionConvergence varchar(200),
FusionDivergence varchar(200),
FusionRange varchar(200),
NearPointOfAccommodation varchar(200),
NearPointOfConvergence varchar(200),
OrthopticsNotes varchar(400),
LoginID varchar(20)
constraint fkLoginIDOrthoptics references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOrthoptics default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeOrthoptics default getdate()
)
go

----------------IPDOrthoptics---------------------------------------------------------------------------------------------

create table IPDOrthoptics
(RoundNo varchar(20) not null constraint pkRoundNoIPDOrthoptics primary key
constraint fkRoundNoIPDOrthoptics references IPDDoctor (RoundNo)
on delete cascade on update cascade,
HeadPosture varchar(200),
Fixation varchar(200),
LeftHirschberg varchar(200),
RightHirschberg varchar(200),
RightEOM varchar(200),
LeftEOM varchar(200),
CoverTestID varchar(10) constraint fkCoverTestIDIPDOrthoptics references LookupData (DataID),
LeftAPCTGlasses varchar(200),
RightAPCTGlasses varchar(200),
LeftAPCTWithOutGlasses varchar(200),
RightAPCTWithOutGlasses varchar(200),
Correspondence varchar(200),
PrismAdaptation varchar(200),
FusionConvergence varchar(200),
FusionDivergence varchar(200),
FusionRange varchar(200),
NearPointOfAccommodation varchar(200),
NearPointOfConvergence varchar(200),
OrthopticsNotes varchar(400),
LoginID varchar(20) constraint fkLoginIDIPDOrthoptics references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDOrthoptics default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDOrthoptics default getdate()
)
go

drop function GetTurnAroundTime
-- run common

---------------------------------------------------------------------------------
---------------Added update on Mon 23-02-2015 -----------------------------------
---------------------------------------------------------------------------------

-----------Expenditure-----------------------------------------------------------------

alter table Expenditure add DocumentNo varchar(20)

update Expenditure set DocumentNo = '' where DocumentNo is null

-----------LabRequestDetails-----------------------------------------------------------------

alter table LabRequestDetails add
LoginID varchar(20)constraint fkLoginIDLabRequestDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineLabRequestDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeLabRequestDetails default getdate()

update LabRequestDetails set ClientMachine = host_name() where ClientMachine is null

--------run cursor below, but be very carefull--------------------------------------------------------------

declare @SpecimenNo varchar(20)
declare @LoginID varchar(20)
declare @RecordDateTime smalldatetime

DECLARE LabRequests_Cursor INSENSITIVE CURSOR FOR

SELECT SpecimenNo, LoginID, RecordDateTime FROM LabRequests

OPEN LabRequests_Cursor
FETCH NEXT FROM LabRequests_Cursor INTO @SpecimenNo, @LoginID, @RecordDateTime
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		update LabRequestDetails set LoginID = @LoginID, RecordDateTime = @RecordDateTime 
		where ((SpecimenNo = @SpecimenNo) and (LoginID is null or RecordDateTime is null))
		
		FETCH NEXT FROM LabRequests_Cursor INTO @SpecimenNo, @LoginID, @RecordDateTime
	END
CLOSE LabRequests_Cursor
deallocate LabRequests_Cursor

------------------------------------------------------------------------------------------------

-----------ItemsEXT-----------------------------------------------------------------------------
exec sp_rename 'ItemsEXT.IssueDate', 'IssueDateTime', 'COLUMN'

-----------IPDItemsEXT--------------------------------------------------------------------------
exec sp_rename 'IPDItemsEXT.IssueDate', 'IssueDateTime', 'COLUMN'

--------run cursor below, but be very carefull--------------------------------------------------------------

declare @VisitNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)

declare @Time varchar(8)

DECLARE ItemsEXT_Cursor INSENSITIVE CURSOR FOR

SELECT VisitNo, ItemCode, ItemCategoryID FROM ItemsEXT

OPEN ItemsEXT_Cursor
FETCH NEXT FROM ItemsEXT_Cursor INTO @VisitNo, @ItemCode, @ItemCategoryID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		SET @Time = (SELECT dbo.GetTime(RecordDateTime) FROM Items
			WHERE VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
			
		UPDATE ItemsEXT SET IssueDateTime = dbo.FormatDate(IssueDateTime) + ' ' + @Time
			WHERE IssueDateTime = dbo.GetShortDate(IssueDateTime) and VisitNo = @VisitNo and ItemCode = @ItemCode 
			and ItemCategoryID = @ItemCategoryID and not (IssueDateTime is null)
						
		FETCH NEXT FROM ItemsEXT_Cursor INTO @VisitNo, @ItemCode, @ItemCategoryID
	END
CLOSE ItemsEXT_Cursor
deallocate ItemsEXT_Cursor

----------------------------------------------------------------------------------

--------run cursor below, but be very carefull--------------------------------------------------------------

declare @RoundNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)

declare @Time varchar(8)

DECLARE IPDItemsEXT_Cursor INSENSITIVE CURSOR FOR

SELECT RoundNo, ItemCode, ItemCategoryID FROM IPDItemsEXT

OPEN IPDItemsEXT_Cursor
FETCH NEXT FROM IPDItemsEXT_Cursor INTO @RoundNo, @ItemCode, @ItemCategoryID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		SET @Time = (SELECT dbo.GetTime(RecordDateTime) FROM IPDItems
			WHERE RoundNo = @RoundNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
			
		UPDATE IPDItemsEXT SET IssueDateTime = dbo.FormatDate(IssueDateTime) + ' ' + @Time
			WHERE IssueDateTime = dbo.GetShortDate(IssueDateTime) and RoundNo = @RoundNo and ItemCode = @ItemCode 
			and ItemCategoryID = @ItemCategoryID and not (IssueDateTime is null)
						
		FETCH NEXT FROM IPDItemsEXT_Cursor INTO @RoundNo, @ItemCode, @ItemCategoryID
	END
CLOSE IPDItemsEXT_Cursor
deallocate IPDItemsEXT_Cursor

----------------------------------------------------------------------------------
---------------Added update on Sat 7-03-2015 -------------------------------------
----------------------------------------------------------------------------------

-----------Refraction-----------------------------------------------------------------

create table Refraction
(VisitNo varchar(20) not null constraint pkVisitNoRefraction primary key  constraint fkVisitNoRefraction
references Visits (VisitNo) on delete cascade on update cascade,
RightMRSPH varchar(200),
LeftMRSPH varchar(200),
RightMRCYL varchar(200),
LeftMRCYL varchar(200),
RightMRAXIS varchar(200),
LeftMRAXIS varchar(200),
RightCRSPH varchar(200),
LeftCRSPH varchar(200),
RightCRCYL varchar(200),
LeftCRCYL varchar(200),
RightCRAXIS varchar(200),
LeftCRAXIS varchar(200),
RightPCRSPH varchar(200),
LeftPCRSPH varchar(200),
RightPCRCYL varchar(200),
LeftPCRCYL varchar(200),
RightPCRAXIS varchar(200),
LeftPCRRAXIS varchar(200),
LoginID varchar(20)
constraint fkLoginIDRefraction references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefraction default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefraction default getdate()
)
go

-----------VisionAssessment-----------------------------------------------------------------

alter table VisionAssessment drop constraint fkVisitNoVisionAssessment
go

alter table VisionAssessment
add constraint fkVisitNoVisionAssessment foreign key (VisitNo)
references Visits(VisitNo) on delete cascade on update cascade
go

---------------Visits-----------------------------------------------------------------------
-- If below generate error, it means constraint is already added please ignore

alter table Visits
add constraint fkPatientNoVisits foreign key (PatientNo) references Patients(PatientNo)
go
 
-----------RadiologyReports-----------------------------------------------------------------

alter table RadiologyReports drop constraint fkVisitNoItemCodeItemCategoryIDRadiologyReports
go

alter table RadiologyReports
add constraint fkVisitNoItemCodeItemCategoryIDRadiologyReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete no action on update cascade
go
 
 -----------IPDRadiologyReports-----------------------------------------------------------------

alter table IPDRadiologyReports drop constraint fkRoundNoItemCodeItemCategoryIDIPDRadiologyReports
go

alter table IPDRadiologyReports
add constraint fkRoundNoItemCodeItemCategoryIDIPDRadiologyReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete no action on update cascade
go

 -----------DentalReports-----------------------------------------------------------------

alter table DentalReports drop constraint fkVisitNoItemCodeItemCategoryIDDentalReports
go

alter table DentalReports
add constraint fkVisitNoItemCodeItemCategoryIDDentalReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete no action on update cascade
go
 
 -----------IPDDentalReports-----------------------------------------------------------------

alter table IPDDentalReports drop constraint fkRoundNoItemCodeItemCategoryIDIPDDentalReports
go

alter table IPDDentalReports
add constraint fkRoundNoItemCodeItemCategoryIDIPDDentalReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete no action on update cascade
go

---------------------------------------------------------------------------------
---------------Added update on Wen 11-03-2015 -----------------------------------
---------------------------------------------------------------------------------

-- for sites where earlier quotations were run, drop them by running below

-- drop table QuotationDetails
-- drop table Quotations

-----------Quotations-----------------------------------------------------------------

create table Quotations
(QuotationID int not null constraint dfQuotationIDQuotations default 1,
QuotationNo varchar(20) not null constraint pkQuotationNo primary key,
QuotationDate smalldatetime,
AmountWords varchar(200),
LoginID varchar(20) constraint fkLoginIDQuotations references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineQuotations default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeQuotations default getdate()
)
go

-----------QuotationDetails-----------------------------------------------------------------

create table QuotationDetails
(QuotationNo varchar(20) not null constraint fkQuotationNoQuotationDetails 
references Quotations (QuotationNo) on delete cascade on update cascade,
VisitNo varchar(20) not null constraint fkVisitNoQuotationDetails 
references Visits (VisitNo) on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDQuotationDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkQuotationNoVisitNoItemCategoryIDItemCode primary key(QuotationNo, VisitNo, ItemCategoryID, ItemCode),
ItemName varchar(800) not null,
constraint uqQuotationNoVisitNoItemCategoryIDItemName unique(QuotationNo, VisitNo, ItemCategoryID, ItemName),
UnitMeasure varchar(100),
Quantity int,
UnitPrice money,
Discount money,
Amount money,
LoginID varchar(20) constraint fkLoginIDQuotationDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineQuotationDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeQuotationDetails default getdate()
)
go

-----------PurchaseOrders-----------------------------------------------------------------

-- for sites where earlier PurchaseOrders were run, drop them by running below

-- drop table PurchaseOrderDetails
-- drop table PurchaseOrders

create table PurchaseOrders
(PurchaseOrderID int not null constraint dfPurchaseOrderIDPurchaseOrders default 1,
PurchaseOrderNo varchar(20) not null constraint pkPurchaseOrderNoPurchaseOrders primary key,
OrderDate smalldatetime,
DocumentNo varchar(20),
SupplierNo varchar(20) constraint fkSupplierNoPurchaseOrders references Suppliers (SupplierNo),
ShipAddress varchar(100),
LoginID varchar(20) constraint fkLoginIDPurchaseOrders references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePurchaseOrders default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePurchaseOrders default getdate()
)
go

-----------PurchaseOrderDetails-----------------------------------------------------------------

create table PurchaseOrderDetails
(PurchaseOrderNo varchar(20) not null constraint fkPurchaseOrderNoPurchaseOrderDetails 
references PurchaseOrders (PurchaseOrderNo)on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDPurchaseOrderDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkPurchaseOrderNoItemCategoryIDItemCodePurchaseOrderDetails primary key(PurchaseOrderNo, ItemCategoryID, ItemCode),
ItemName varchar(800) not null,
constraint uqPurchaseOrderNoItemCategoryIDItemName unique(PurchaseOrderNo, ItemCategoryID, ItemName),
UnitMeasure varchar(100),
Quantity int,
Rate money,
LoginID varchar(20)constraint fkLoginIDPurchaseOrderDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePurchaseOrderDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePurchaseOrderDetails default getdate()
)
go

----------- PathologyExaminations 31-03-2015-----------------------------------------------------------------

create table PathologyExaminations
(ExamCode varchar(20)constraint pkExamCodePathologyExaminations primary key,
ExamName varchar(40),
PathologyCategoriesID varchar(10)constraint fkPathologyCategoriesIDPathologyExaminations references LookupData (DataID),
UnitPrice money,
Hidden bit constraint dfHiddenPathologyExaminations default 0,
LoginID Varchar(20)constraint fkLoginIDPathologyExaminations references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePathologyExaminations default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePathologyExaminations default getdate()
)
go

----------------------------------------------------------------------------------
---------------Added update on Wen 15-04-2015 ------------------------------------
----------------------------------------------------------------------------------

-----------InsuranceExclusions-----------------------------------------------------------------

create table InsuranceExclusions
(InsuranceNo varchar(20) not null constraint fkInsuranceNoInsuranceExclusions 
references Insurances (InsuranceNo) on delete cascade on update cascade,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null
constraint fkItemCategoryIDInsuranceExclusions references LookupData (DataID),
constraint pkInsuranceNoItemCodeItemCategoryIDInsuranceExclusions primary key(InsuranceNo, ItemCode, ItemCategoryID)
)
go

---------------Added update on Sat 18-04-2015 ------------------------------------
----------------------------------------------------------------------------------
-----------Staff----------------------------------------------------------------------------

alter table Staff add
StaffID int not null constraint dfStaffIDStaff default 1,
Fingerprint image
go

-----------PathologyImages----------------------------------------------------------------------------

create table PathologyImages
(VisitNo varchar(20) not null references visits  on delete cascade on update cascade,
ImageName varchar(20) not null,
constraint pkVisitNoImageName primary key(VisitNo,ImageName),
PathologyImage image,
LoginID varchar(20) constraint fkLoginIDPathologyImages references Logins (LoginID)
)

-----------PathologyReports----------------------------------------------------------------------------

create table PathologyReports
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDPathologyReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDPathologyReports primary key(VisitNo, ItemCode, ItemCategoryID),
ReportTypeID varchar(10) constraint fkReportTypeIDPathologyReports references LookupData (DataID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Diagnosis varchar(4000),
Pathologist varchar(10) constraint fkPathologistPathologyReports references Staff (staffno),
PathologyTitleID varchar(10) constraint fkPathologyTitleIDPathologyReports references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDPathologyReports references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePathologyReports default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePathologyReports default getdate()
)
go

----------- ResearchRoutingForm ----------------------------------------------------------------------------

create table ResearchRoutingForm
(UCINo int constraint dfUCINoResearchRoutingForm default 1,
UCIID varchar(20) not null constraint pkUCIID primary key,
FirstName varchar(20),
LastName varchar(20),
OtherName varchar(20),
ReferalInitials varchar(10),
GenderID varchar(10) constraint fkGenderIDResearchRoutingForm references LookupData (DataID),
BirthDate smalldatetime,
VillageCode varchar(20) constraint fkVillageCodeResearchRoutingForm references Villages (VillageCode),
ReferralDate smalldatetime,
ReferralStudyCodeID varchar(10)constraint fkReferralStudyCodeIDResearchRoutingForm references LookupData (DataID),
ReferralStudyName varchar(100),
Diagnosis varchar(1000),
HealthUnitCode varchar(10)constraint fkHealthUnitCodeResearchRoutingForm references HealthUnits (HealthUnitCode),
ReferredBy varchar(100),
PatientScreenedBy varchar(200),
ReferralInitials varchar(10),
EligibleForScreeningID varchar(10) constraint fkEligibleForScreeningIDResearchRoutingForm references LookupData (DataID),
ExclusionReason varchar(1000),
PatientReferedTo varchar(200),
ReferredDate smalldatetime,
SCRNo varchar(20),
PID varchar(20),
SID varchar(20),
LoginID varchar(20) constraint fkLoginIDResearchRoutingForm references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineResearchRoutingForm default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeResearchRoutingForm default getdate()
)
go

----------- EnrollmentInformation ----------------------------------------------------------------------------

create table EnrollmentInformation
(UCIID varchar(20) not null constraint fkUCIIDEnrollmentInformation references ResearchRoutingForm (UCIID)
on delete cascade on update cascade,
ReferralStudyCodeID varchar(10) not null constraint fkReferralStudyCodeIDEnrollmentInformation references LookupData (DataID),
constraint pkUCIIDReferralStudyCodeID primary key(UCIID, ReferralStudyCodeID),
EnrolledID varchar(10) constraint fkEnrolledIDEnrollmentInformation references LookupData (DataID),
CoEnrolledID varchar(10) constraint fkCoEnrolledIDEnrollmentInformation references LookupData (DataID),
CoEnrolledStudyCodeID varchar(10) constraint fkCoEnrolledStudyCodeIDEnrollmentInformation references LookupData (DataID),
CCInitials varchar(20),
ExclusionReason Varchar(1000),
EnrollmentDate Smalldatetime,
PatientReferred varchar(1000),
ReferredDate Smalldatetime,
LoginID varchar(20) constraint fkLoginIDEnrollmentInformation references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineEnrollmentInformation default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeEnrollmentInformation default getdate()
)
go

----------- Options -----------------------------------------------------------------------------------------

exec uspEditOptions 'AllowManualAccountDebitEntry', 0, '3BIT', 1, 0
exec uspEditOptions 'VisitReviewDays', 0, '3NUM', 2, 0
exec uspEditOptions 'CashPaymentPercentBeforeAdmission', 0, '3NUM', 3, 0
exec uspEditOptions 'ForceDispensingPreviousPrescription', 0, '3BIT', 1, 0
go

----------------------------------------------------------------------------------
---------------Added update on Thur 09-04-2015 -----------------------------------
----------------------------------------------------------------------------------

-- for a few places where below are run drop tables first
-- drop table GoodsReceivedNoteDetails
-- drop table GoodsReceivedNote

----------- GoodsReceivedNote -----------------------------------------------------------------------------------------

create table GoodsReceivedNote
(GRNID int not null constraint dfGRNIDGoodsReceivedNote default 1,
GRNNo varchar(20) not null constraint pkGRNNoGoodsReceivedNote primary key,
PurchaseOrderNo varchar(20) constraint fkPurchaseOrderNoGoodsReceivedNote references PurchaseOrders (PurchaseOrderNo),
ReceivedDate smalldatetime,
AdviceNoteNo varchar(20),
DeliveryLocationID varchar(10) constraint fkDeliveryLocationIDGoodsReceivedNote references LookupData (DataID),
AmountWords varchar(200),
LoginID varchar(20) constraint fkLoginIDGoodsReceivedNote references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineGoodsReceivedNote default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeGoodsReceivedNote default getdate()
)
go

----------- GoodsReceivedNoteDetails -------------------------------------------------------------------------------

create table GoodsReceivedNoteDetails
(GRNNo varchar(20) not null constraint fkGRNNoGoodsReceivedNoteDetails 
references GoodsReceivedNote (GRNNo)on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDGoodsReceivedNoteDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkGRNNoItemCategoryIDItemCodeGoodsReceivedNoteDetails primary key(GRNNo, ItemCategoryID, ItemCode),
ItemName varchar(800) not null,
constraint uqGRNNoItemCategoryIDItemName unique(GRNNo, ItemCategoryID, ItemName),
UnitMeasure varchar(100),
OrderedQuantity int,
ReceivedQuantity int,
BonusQuantity int,
Rate money,
Discount money constraint dfDiscountGoodsReceivedNoteDetails default 0,
Amount money,
BatchNo varchar(20),
ExpiryDate smalldatetime,
Notes varchar(100),
LoginID varchar(20)constraint fkLoginIDGoodsReceivedNoteDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineGoodsReceivedNoteDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeGoodsReceivedNoteDetails default getdate()
)
go

-----------OtherIncome-----------------------------------------------------------

alter table OtherIncome add
CurrenciesID varchar(10) constraint fkCurrenciesIDOtherIncome references LookupData (DataID),
AmountTendered money, ExchangeRate money, Change money

update OtherIncome set CurrenciesID = '49UGX' where CurrenciesID is null
update OtherIncome set AmountTendered = Amount where AmountTendered is null
update OtherIncome set ExchangeRate = 1 where ExchangeRate is null
update OtherIncome set Change = 0 where Change is null

----------- Companies -----------------------------------------------------------

alter table Companies add
ContractStartDate smalldatetime, ContractEndDate smalldatetime

----------- Accounts ---------------------------------------------------------------------------

alter table Accounts add
AccountGroupID varchar(10) constraint fkAccountGroupIDAccounts references LookupData (DataID)

--- Frirst Run Data for below to update

update Accounts set AccountGroupID = '138NA' where AccountGroupID is null

--- run common

----------------------------------------------------------------------------------
---------------Added update on Mon 11-05-2015 ------------------------------------
----------------------------------------------------------------------------------

-----------Drugs----------------------------------------------------------------------------

alter table Drugs add DrugID int not null constraint dfDrugIDDrugs default 1
go

-----------ConsumableItems----------------------------------------------------------------------------

alter table ConsumableItems add ConsumableID int not null constraint dfConsumableIDConsumableItems default 1
go

exec uspEditOptions 'StaffNoPrefix', 'S', '3STR', 1, 1
exec uspEditOptions 'DrugNoPrefix', 'M', '3STR', 1, 1
exec uspEditOptions 'ConsumableNoPrefix', 'C', '3STR', 1, 1

-----------Accounts-----------------------------------------------------------------

alter table Accounts add 
EntryModeID varchar(10) constraint fkEntryModeIDAccounts references LookupData (DataID)

update Accounts set EntryModeID = '46SYS'
where EntryModeID is null and Notes LIKE 'Payment under receipt no: %' 

-- run this after running update above
update Accounts set EntryModeID = '46MAN' where EntryModeID is null 

----------------------------------------------------------------------------------
---------------Added update on Thu 21-05-2015 ------------------------------------
----------------------------------------------------------------------------------

-----------InventoryAcknowledges-----------------------------------------------------------------

alter table InventoryAcknowledges drop constraint fkTransferNoItemCategoryIDItemCodeInventoryAcknowledges
go

alter table InventoryAcknowledges add constraint fkTransferNoItemCategoryIDItemCodeInventoryAcknowledges 
foreign key (TransferNo, ItemCategoryID, ItemCode) references InventoryTransferDetails (TransferNo, ItemCategoryID, ItemCode)
go

-----------ExchangeRates----------------------------------------------------------------

alter table ExchangeRates drop constraint ckExchangeRateExchangeRates

exec sp_rename 'ExchangeRates.ExchangeRate', 'Buying', 'COLUMN'

alter table ExchangeRates add constraint ckBuyingExchangeRates check (Buying > 0)
alter table ExchangeRates add Selling money constraint ckSellingExchangeRates check (Selling > 0)

--- after running utilities
update ExchangeRates set Selling = Buying where Selling is null 

-----------BillCustomFee----------------------------------------------------------------

alter table BillCustomFee add 
CurrenciesID varchar(10) constraint fkCurrenciesIDBillCustomFee references LookupData (DataID)

update BillCustomFee set CurrenciesID = '49UGX' where CurrenciesID is null

-----------InsuranceCustomFee----------------------------------------------------------------

alter table InsuranceCustomFee add 
CurrenciesID varchar(10) constraint fkCurrenciesIDInsuranceCustomFee references LookupData (DataID)

update InsuranceCustomFee set CurrenciesID = '49UGX' where CurrenciesID is null

-----------Patients----------------------------------------------------------------------------
alter table Patients add
MaritalStatusID varchar(10) constraint fkMaritalStatusIDPatients references LookupData (DataID),
CareEntryPointID varchar(10) constraint fkCareEntryPointIDPatients references LookupData (DataID)
go

-------------- TopologySites ------------------------------------------------------

create table TopologySites
(TopographicalNo varchar(20) not null constraint pkTopographicalNo primary key,
TopologySiteCodeID varchar(10)constraint fkTopologySiteCodeIDTopologySites references LookupData (DataID),
TopologySiteName varchar(800),
Hidden bit,
LoginID varchar(20) constraint fkLoginIDTopologySites references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineTopologySites default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeTopologySites default getdate()
)
go

-------------- CancerDiseases ------------------------------------------------------

create table CancerDiseases
(DiseaseID int not null constraint dfDiseaseIDCancerDiseases default 1,
DiseaseNo varchar(20) not null constraint pkDiseaseNo primary key,
DiseaseCode varchar(10),
DiseaseName varchar(800),
CancerDiseaseCategoriesID varchar(10) constraint fkCancerDiseaseCategoriesIDCancerDiseases references LookupData (DataID),
Hidden bit,
LoginID varchar(20) constraint fkLoginIDCancerDiseases references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineCancerDiseases default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeCancerDiseases default getdate()
)
go

-------------- CancerDiagnosis ------------------------------------------------------

create table CancerDiagnosis
(VisitNo varchar(20) constraint fkVisitNoCancerDiagnosis references Visits (VisitNo),
DiseaseNo varchar(20) constraint fkDiseaseNoCancerDiagnosis references CancerDiseases (DiseaseNo),
constraint pkVisitNoDiseaseNo primary key(VisitNo, DiseaseNo),
TopographicalNo varchar(20) constraint fkTopographicalNoCancerDiagnosis references TopologySites (TopographicalNo),
BasisOfDiagnosisID varchar(10) constraint fkBasisOfDiagnosisIDCancerDiagnosis references LookupData (DataID),
CancerStageID varchar(10) constraint fkCancerStageIDCancerDiagnosis references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20)constraint fkLoginIDCancerDiagnosis references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineCancerDiagnosis default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCancerDiagnosis default getdate()
)
go

-------------- HCTClientCard ------------------------------------------------------

create table HCTClientCard
(VisitNo Varchar(20) not null constraint pkVisitNoHCTClientCard primary key 
references Visits (VisitNo)on delete cascade on update cascade,
DistrictsID varchar(10) constraint fkDistrictsIDHCTClientCard references LookupData (DataID),
HealthUnitCode varchar(10) not null constraint fkHealthUnitCodeHCTClientCard references HealthUnits (HealthUnitCode),
HSD Varchar(100),
CenterTypeID varchar(10) not null constraint fkCenterTypeIDHCTClientCard references LookupData (DataID),
TestingPointID varchar(10) not null constraint fkTestingPointIDHCTClientCard references LookupData (DataID),
AccompaniedByID Varchar(10) constraint fkAccompaniedByIDHCTClientCard references LookupData (DataID),
PreTestCounselingID Varchar(10) not null constraint fkPreTestCounselingIDHCTClientCard references LookupData (DataID),
CounseledAsID Varchar(10) constraint fkCounseledAsIDHCTClientCard references LookupData (DataID),
HCTEntryPoint Varchar(10) not null constraint fkHCTEntryPointHCTClientCard references LookupData (DataID),
MaritalStatusID Varchar(10) not null constraint fkMaritalStatusIDHCTClientCard references LookupData (DataID),
SexualPatnerNo smallint,
TestedHIVBeforeID varchar(10) not null constraint fkTestedHIVBeforeIDHCTClientCard references LookupData (DataID),
HIVTestThreeMonthsID Varchar(10) constraint fkHIVTestThreeMonthsIDHCTClientCard references LookupData (DataID),
HIVTestSixMonthsID Varchar(10) constraint fkHIVTestSixMonthsIDHCTClientCard references LookupData (DataID),
HIVTestTwelveMonthsID Varchar(10) constraint fkHIVTestTwelveMonthsIDHCTClientCard references LookupData (DataID),
ResultThreeMonthsID Varchar(10) constraint fkResultThreeMonthsIDHCTClientCard references LookupData (DataID),
ResultSixMonthsID Varchar(10) constraint fkResultSixMonthsIDHCTClientCard references LookupData (DataID),
ResultTwelveMonthsID Varchar(10) constraint fkResultTwelveMonthsIDHCTClientCard references LookupData (DataID),
NoTestsInTwelveMonthsID Varchar(10) constraint fkNoTestsInTwelveMonthsIDHCTClientCard references LookupData (DataID),
PatnerTestedHIVID Varchar(10) constraint fkPatnerTestedHIVIDHCTClientCard references LookupData (DataID),
PatnerTypeID Varchar(10) constraint fkPatnerTypeIDHCTClientCard references LookupData (DataID),
PatnerResultID Varchar(10) constraint fkPatnerResultIDHCTClientCard references LookupData (DataID),
KnowAboutServiceID Varchar(200) not null,
ConsentID Varchar(10) not null constraint fkConsentIDHCTClientCard references LookupData (DataID),
NoConsentReasonID Varchar(200),
HIVResultID Varchar(10) constraint fkHIVResultIDHCTClientCard references LookupData (DataID),
TestDoneBy Varchar(41),
Designation Varchar(20),
TestDate smalldatetime,
ResultReceivedID Varchar(10) constraint fkResultReceivedIDHCTClientCard references LookupData (DataID),
ResultReceivedAsCoupleID Varchar(10) constraint fkResultReceivedAsCoupleIDHCTClientCard references LookupData (DataID),
CoupleResultsID Varchar(10) constraint fkCoupleResultsIDHCTClientCard references LookupData (DataID),
TBSuspicionID Varchar(10) constraint fkTBSuspicionIDHCTClientCard references LookupData (DataID),
STIID Varchar(10) constraint fkSTIIDHCTClientCard references LookupData (DataID),
StartedCotrimoxazoleID Varchar(10) constraint fkStartedCotrimoxazoleIDHCTClientCard references LookupData (DataID),
LinkedToCareID Varchar(10) constraint fkLinkedToCareIDHCTClientCard references LookupData (DataID),
WhereLinkedToCareID Varchar(10) constraint fkWhereLinkedToCareIDHCTClientCard references HealthUnits (HealthUnitCode),
ReferralReason Varchar(200),
CounselorName Varchar(41),
CounselDate smalldatetime,
LoginID varchar(20) constraint fkLoginIDHCTClientCard references Logins (LoginID),
ClientMachine varchar(40),
RecordDateTime smalldatetime constraint dfRecordDateTimeHCTClientCard default getdate()
)
go

------------------------------------------------------------------------------------------------------
exec uspEditOptions 'AllowPrintingPatientFaceSheet', 0, '3BIT', 1, 0
exec uspEditOptions 'CategorizeVisitPaymentDetails', 0, '3BIT', 1, 0
exec uspEditOptions 'CategorizeVisitInvoiceDetails', 0, '3BIT', 1, 0

----------------------------------------------------------------------------------
---------------Added update on Thu 02-07-2015 ------------------------------------
----------------------------------------------------------------------------------

/** Run below only if you ran updates on Thu 21-05-2015. they might take awhile

delete from lookupdata where objectid = 400
delete from LookupObjects where objectid = 400

delete from lookupdata where objectid = 401
delete from LookupObjects where objectid = 401

delete from lookupdata where objectid = 402
delete from LookupObjects where objectid = 402

delete from lookupdata where objectid = 403
delete from LookupObjects where objectid = 403

delete from lookupdata where objectid = 404
delete from LookupObjects where objectid = 404

**/

-----------ExtraChargeItems-----------------------------------------------------------------

alter table ExtraChargeItems add 
ExtraChargeCategoryID varchar(10) constraint fkExtraChargeCategoryIDExtraChargeItems references LookupData (DataID),
UnitCost money constraint dfUnitCostExtraChargeItems default 0

-- run Data first then run below

update ExtraChargeItems set ExtraChargeCategoryID = '145GEN' where ExtraChargeCategoryID is null 
update ExtraChargeItems set UnitCost = 0 where UnitCost is null 

-----------SagePastel-----------------------------------------------------------------

delete from ObjectRoles Where ObjectName ='SagePastel' 
delete from AccessObjects Where ObjectCaption ='SagePastel'
drop view SagePastel
------------------------------------------------------------------------------------

---------------------------------------------------------------------------------
---------------Added update on Fri 24-07-15 -------------------------------------
---------------------------------------------------------------------------------

-------------- BillCustomers --------------------------------------------------------------------

alter table BillCustomers add AccountBalance money constraint dfAccountBalanceBillCustomers default 0

--------run cursor below, but be very carefull and run it only once, it may take awhile to complete-------------------------

DECLARE @AccountNo VARCHAR(20)
DECLARE @AccountBillModesID VARCHAR(10)
DECLARE BillCustomers_Cursor INSENSITIVE CURSOR FOR

SELECT AccountNo FROM BillCustomers
SET @AccountBillModesID = dbo.GetLookupDataID('BillModes', 'A')

OPEN BillCustomers_Cursor
FETCH NEXT FROM BillCustomers_Cursor INTO @AccountNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN							
		UPDATE BillCustomers SET AccountBalance = dbo.GetAccountBalance(@AccountBillModesID, @AccountNo)  
		WHERE AccountNo = @AccountNo AND AccountBalance IS NULL		
		FETCH NEXT FROM BillCustomers_Cursor INTO @AccountNo
	END
CLOSE BillCustomers_Cursor
DEALLOCATE BillCustomers_Cursor

----------------------------------------------------------------------------------------------------------------------------

-------------- Patients --------------------------------------------------------------------
alter table Patients add AccountBalance money constraint dfAccountBalancePatients default 0

--------run cursor below, but be very carefull and run it only once, it may take awhile to complete-------------------------

DECLARE @PatientNo VARCHAR(20)
DECLARE @CashBillModesID VARCHAR(10)
DECLARE Patients_Cursor INSENSITIVE CURSOR FOR

SELECT PatientNo FROM Patients
SET @CashBillModesID = dbo.GetLookupDataID('BillModes', 'C')

OPEN Patients_Cursor
FETCH NEXT FROM Patients_Cursor INTO @PatientNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN							
		UPDATE Patients SET AccountBalance = dbo.GetAccountBalance(@CashBillModesID, @PatientNo) 
		WHERE PatientNo = @PatientNo AND AccountBalance IS NULL		
		FETCH NEXT FROM Patients_Cursor INTO @PatientNo
	END
CLOSE Patients_Cursor
DEALLOCATE Patients_Cursor

----------------------------------------------------------------------------------------------------------------------------

exec uspEditOptions 'AllowCreateMultipleSpecialityVisits', 0, '3BIT', 1, 0

alter table Patients add CountryID varchar(10) constraint fkCountryIDPatients references LookupData (DataID)

-----------Deaths-----------------------------------------------------------------

alter table Deaths add
StaffNo varchar(10), TimeOfDeath varchar(8), PrimaryCauseOfDeath varchar(200),
SecondaryCauseOfDeath varchar(200), OtherCauseOfDeath varchar(200)

---------------------------------------------------------------------------------
---------------Added update on Wen 12-08-15 -------------------------------------
---------------------------------------------------------------------------------

-----------CancerDiagnosis-----------------------------------------------------------------

alter table CancerDiagnosis drop constraint fkCancerStageIDCancerDiagnosis
go

alter table CancerDiagnosis
alter column CancerStageID varchar(200) not null 

---------------------------------------------------------------------------------
---------------Added update on Wen 19-08-15 -------------------------------------
---------------------------------------------------------------------------------

-- Run commentated below for other place if table SmartCardAuthorisations already created apart from Case

-- drop table SmartCardAuthorisations

-----------SmartCardAuthorisations-----------------------------------------------------------------

create table SmartCardAuthorisations
(PatientNo varchar(20) not null constraint fkPatientNoSmartCardAuthorisations 
references Patients (PatientNo) on delete cascade on update cascade,
BillModesID varchar(10) not null constraint fkBillModesIDSmartCardAuthorisations references LookupData (DataID),
BillNo varchar(20)not null, -- Reference BillCustomers and SchemeMembers
ToVisitDate Smalldatetime not null,
constraint pkPatientNoBillModesIDBillNoToVisitDate primary key(PatientNo, BillModesID, BillNo, ToVisitDate),
MedicalCardNo varchar(20),
AuthorisedBy varchar(41),
AuthorisationReason varchar(10) constraint fkAuthorisationReasonSmartCardAuthorisations references LookupData (DataID),
ClaimReferenceNo varchar(30),
LoginID varchar(20) constraint fkLoginIDSmartCardAuthorisations references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineSmartCardAuthorisations default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeSmartCardAuthorisations default getdate()
)
go

exec uspEditOptions 'RestrictDoctorLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictLabTechnologistLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictPharmacistLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictRadiologistLoginID', 0, '3BIT', 1, 0
exec uspEditOptions 'RestrictPathologistLoginID', 0, '3BIT', 1, 0
go

-----------SmartCardAuthorisations-----------------------------------------------------------------

create table ExternalReferrals
(VisitNo varchar(20) constraint fkVisitNoExternalReferrals references Visits (VisitNo)
constraint pkVisitNoExternalReferrals primary key,
ProcedurePaidBy varchar(200),
EmployeeName varchar(200),
ReferredTo varchar(200),
DepartureTime varchar(8),
DateOfReferral smalldatetime,
HistoryAndSymptoms varchar(200),
Diagnosis varchar (200),
TreatmentGiven varchar(200),
ReasonForReferral varchar(200),
StaffNo varchar(10) constraint fkStaffNoExternalReferrals references Staff (StaffNo),
AuthorisedBy varchar(200),
TreatmentLimit money,
LoginID varchar(20) constraint fkLoginIDExternalReferrals references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineExternalReferrals default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeExternalReferrals default getdate()
)
go

----------------------------------------------------------------------------------
---------------Added update on Tue 01-09-2015 ------------------------------------
----------------------------------------------------------------------------------

-----------Staff----------------------------------------------------------------------------

alter table Staff drop constraint dfStaffIDStaff 

alter table Staff alter column StaffID int not null

exec uspEditOptions 'RestrictDrawnByLoginID', 0, '3BIT', 1, 0

----------------------------------------------------------------------------------
---------------Added update on Wen 10-09-2015 ------------------------------------
----------------------------------------------------------------------------------

-----------Drugs----------------------------------------------------------------------------

alter table Drugs add
GroupsID varchar(10) constraint fkGroupsIDDrugs references LookupData (DataID)
go

---------------DRUGS TRANSFER CURSOR -----------------------------------------------------------

declare @DrugNo varchar(20)
declare @GroupsIDdrugs varchar(10)
declare @GroupsIDDrugCategories varchar(10)
declare @CategoryNoDrugs varchar(10)

declare @CategoryNoDrugCategories varchar(10)

DECLARE GroupsIdTransfer INSENSITIVE CURSOR FOR

	select DrugNo,CategoryNo,GroupsID from Drugs where GroupsID is null

OPEN GroupsIdTransfer
	FETCH NEXT FROM GroupsIdTransfer INTO @DrugNo,@CategoryNoDrugs,@GroupsIDdrugs
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		SET @GroupsIDDrugCategories = (select GroupsID from DrugCategories where CategoryNo = @CategoryNoDrugs)
		UPDATE Drugs set GroupsID = @GroupsIDDrugCategories where DrugNo=@DrugNo and GroupsID is null
	FETCH NEXT FROM GroupsIdTransfer INTO @DrugNo,@CategoryNoDrugs,@GroupsIDdrugs
	END
CLOSE GroupsIdTransfer
DEALLOCATE GroupsIdTransfer

--------------------------------------------------------------------------------------------------------------

----------- DrugCategories ----------------------------------------------------------------------------

alter table DrugCategories drop constraint fkGroupsIDDrugCategories
	
alter table DrugCategories drop column GroupsID 

exec uspEditOptions 'AllowNetworkMultipleLogins', 0, '3BIT', 1, 0

drop proc uspGetDailyCashPayments

----------------------------------------------------------------------------------
---------------Added update on Wen 16-09-2015 ------------------------------------
----------------------------------------------------------------------------------

-- RUN COMMON

-----------InventoryOrderDetails--------------------------------------------------

alter table InventoryOrderDetails add
ItemStatusID varchar(10) constraint fkItemStatusIDInventoryOrderDetails references LookupData (DataID)
go

---------------------------------------------------------------------------------------------------------------------------------
-- After running below, check to ensure that all entries of InventoryOrderDetails column ItemStatusId are updated, else run again
---------------InventoryOrderDetailsCUR CURSOR ----------------------------------------------------------------------------------

DECLARE @OrderNo varchar(20)
DECLARE @ItemCategoryID VARCHAR(10)
DECLARE @ItemCode VARCHAR(20)

DECLARE @StockStatusID varchar(10)

DECLARE InventoryOrderDetailsCUR INSENSITIVE CURSOR FOR
SELECT OrderNo, ItemCategoryID, ItemCode from InventoryOrderDetails WHERE ItemStatusID is null

OPEN InventoryOrderDetailsCUR
	FETCH NEXT FROM InventoryOrderDetailsCUR INTO @OrderNo, @ItemCategoryID, @ItemCode
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
		SET @StockStatusID = (SELECT TOP 1 StockStatusID from InventoryTransferDetails
		inner join InventoryTransfers on InventoryTransferDetails.TransferNo = InventoryTransfers.TransferNo
		WHERE OrderNo = @OrderNo AND ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode)
		
		IF (@StockStatusID IS NULL or @StockStatusID = '') 
			BEGIN 
				UPDATE InventoryOrderDetails SET ItemStatusID = '11P' 
				WHERE OrderNo = @OrderNo AND ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND ItemStatusID is null 
			END
		ELSE IF (@StockStatusID = '13I') 
			BEGIN 
				UPDATE InventoryOrderDetails SET ItemStatusID = '11R' 
				WHERE OrderNo = @OrderNo AND ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND ItemStatusID is null 
			END
		ELSE IF (@StockStatusID = '13R') 
			BEGIN 
				UPDATE InventoryOrderDetails SET ItemStatusID = '11O' 
				WHERE OrderNo = @OrderNo AND ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND ItemStatusID is null 
			END
		ELSE 
			BEGIN 
				UPDATE InventoryOrderDetails SET ItemStatusID = '11P' 
				WHERE OrderNo = @OrderNo AND ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND ItemStatusID is null 
			END
				
	FETCH NEXT FROM InventoryOrderDetailsCUR INTO @OrderNo, @ItemCategoryID, @ItemCode
	END
CLOSE InventoryOrderDetailsCUR
DEALLOCATE InventoryOrderDetailsCUR

----------------------------------------------------------------------------------------------------------------------------------

drop function GetIsInventoryOrderDetailTransfered
drop proc uspIsInventoryOrderDetailTransfered

----------------------------------------------------------------------------------
---------------Added update on Sun 11-10-2015 ------------------------------------
----------------------------------------------------------------------------------
----#####ian
exec uspEditOptions 'GroupVisitInvoiceDetails', 0, '3BIT', 1, 0

----------------------------------------------------------------------------------
---------------Added update on Tue 20-10-2015 ------------------------------------
----------------------------------------------------------------------------------

-----------PurchaseOrderDetails----------------------------------------------------

alter table PurchaseOrderDetails add ItemGroup varchar(100), Amount money, Notes varchar(200), 
StockStatusID varchar(10) constraint fkStockStatusIDPurchaseOrderDetails references LookupData (DataID)

update PurchaseOrderDetails set ItemGroup = '' where ItemGroup is null

update PurchaseOrderDetails set Amount = (Quantity * Rate) where Amount is null

update PurchaseOrderDetails set Notes = '' where Notes is null

---------------------------------------------------------------------------------------------------------------------------------
-- After running below, check to ensure that all entries of PurchaseOrderDetails column StockStatusID are updated, else run again
---------------PurchaseOrderDetailsCUR CURSOR ----------------------------------------------------------------------------------

DECLARE @PurchaseOrderNo varchar(20)
DECLARE @ItemCategoryID VARCHAR(10)
DECLARE @ItemCode VARCHAR(20)

DECLARE PurchaseOrderDetailsCUR INSENSITIVE CURSOR FOR
SELECT PurchaseOrderNo, ItemCategoryID, ItemCode from PurchaseOrderDetails WHERE StockStatusID is null

OPEN PurchaseOrderDetailsCUR
	FETCH NEXT FROM PurchaseOrderDetailsCUR INTO @PurchaseOrderNo, @ItemCategoryID, @ItemCode
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
		IF EXISTS (SELECT GoodsReceivedNoteDetails.GRNNo from GoodsReceivedNoteDetails
					inner join GoodsReceivedNote on GoodsReceivedNoteDetails.GRNNo = GoodsReceivedNote.GRNNo
					WHERE PurchaseOrderNo = @PurchaseOrderNo AND ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode)			 
		BEGIN 
			UPDATE PurchaseOrderDetails SET StockStatusID = '13R' 
			WHERE PurchaseOrderNo = @PurchaseOrderNo AND ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND StockStatusID is null 
		END
		ELSE 
			BEGIN 
				UPDATE PurchaseOrderDetails SET StockStatusID = '13I' 
				WHERE PurchaseOrderNo = @PurchaseOrderNo AND ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND StockStatusID is null 
			END
				
	FETCH NEXT FROM PurchaseOrderDetailsCUR INTO @PurchaseOrderNo, @ItemCategoryID, @ItemCode
	END
CLOSE PurchaseOrderDetailsCUR
DEALLOCATE PurchaseOrderDetailsCUR

----------------------------------------------------------------------------------
---------------Added update on Wen 28-10-2015 ------------------------------------
----------------------------------------------------------------------------------

-----------GoodsReceivedNote------------------------------------------------------

alter table GoodsReceivedNote add 
DiscountTotal money constraint dfDiscountTotalGoodsReceivedNote default 0,
VATPercent decimal(5,2) constraint dfVATPercentGoodsReceivedNote default 0

update GoodsReceivedNote set DiscountTotal = 0 where DiscountTotal is null
update GoodsReceivedNote set VATPercent = 0 where VATPercent is null

drop function GetGoodsReceivedNoteAmount

----------------------------------------------------------------------------------
---------------Added update on MOn 23-11-2015 ------------------------------------
----------------------------------------------------------------------------------

----------- Discharges -----------------------------------------------------------

alter table Discharges add
History varchar(400),
Examination varchar(400),
KeyFindingsInvestigation varchar(400),
TreatmentOnWard varchar(400),
OutcomeOfTreatment varchar(400),
KeyRecommendations varchar(400)
go

----------------------------------------------------------------------------------
---------------Added update on Wen 25-11-2015 ------------------------------------
----------------------------------------------------------------------------------

create table PossibleAttachedItems
(AttachedItemCode varchar(20),
ItemCode varchar(20),
ItemCategoryID varchar(10)
constraint fkItemCategoryIDPossibleAttachedItems references LookupData (DataID),
constraint pkAttachedItemCodeItemCodeItemCategoryID primary key(AttachedItemCode, ItemCode, ItemCategoryID),
Quantity int,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDPossibleAttachedItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePossibleAttachedItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePossibleAttachedItems default getdate()
)
go

create table LowVision
(VisitNo varchar(20) constraint pkVisitNoLowVision primary key  constraint fkVisitNoLowVision references Visits (VisitNo) on delete cascade on update cascade,
BriefHistory varchar(200),
Profession varchar(200),
MajorOcularDiagnosisRE varchar(200),
MajorOcularDiagnosisLE varchar(200),
OtherOcularDiagnosisRE varchar(200),
OtherOcularDiagnosisLE varchar(200),
OphthalmologistSeenID varchar(10) constraint fkOphthalmologistSeenIDLowVision references LookupData (DataID),
OphthalmologistSeenDate smallDateTime,
OtherImpairments varchar(200),
ExistingTreatmentRE varchar(200),
ExistingTreatmentLE varchar(200),
ExistingLVDs varchar(200),
ProblemEncounteredLVDs varchar(200),
PresentingVADistRE varchar(200),
PresentingVADistLE varchar(200),
PresentingVANearRE varchar(200),
PresentingVANearLE varchar(200),
ObjectiveRefractionRE varchar(200),
ObjectiveRefractionLE varchar(200),
SubjectiveRefractionRE varchar(200),
SubjectiveRefractionLE varchar(200),
VADistanceWithNewRxRE varchar(200),
VADistanceWithNewRxLE varchar(200),
VANearWithNewRxRE varchar(200),
VANearWithNewRxLE varchar(200),
TypeOfSquintID varchar(10) constraint fkTypeOfSquintIDLowVision references LookupData (DataID),
NystagmusID varchar(10) constraint fkNystagmusIDLowVision references LookupData (DataID),
FixationID varchar(10) constraint fkFixationIDLowVision references LookupData (DataID),
AbdnormalHeadPostureID varchar(10) constraint fkAbdnormalHeadPostureIDLowVision references LookupData (DataID),
ColourVisionDefectID varchar(10) constraint fkColourVisionDefectIDLowVision references LookupData (DataID),
ColourVisionDefect varchar(200),
ColourVisionTestUsed varchar(200),
ContrastSensitivityID varchar(10) constraint fkContrastSensitivityIDLowVision references LookupData (DataID),
ContrastSensitivity varchar(200),
ContrastSensitivityTestUsed varchar(200),
VisualFieldDefectID varchar(10) constraint fkVisualFieldDefectIDLowVision references LookupData (DataID),
VisualFieldDefect varchar(200),
VisualFieldDefectTestUsed varchar(200),
LowVisionDevicesFar varchar(200),
LowVisionDevicesNear varchar(200),
NonOpticalAids varchar(200),
PD varchar(200),
Heights varchar(200),
Advice varchar(200),
LoginID varchar(20) constraint fkLoginIDLowVision references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineLowVision default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeLowVision default getdate()
)
go

----------------------------------------------------------------------------------
---------------Added update on Mon 28-12-2015 ------------------------------------
----------------------------------------------------------------------------------

create table AssetRegister
(SerialNo Varchar(20) constraint pkSerialNo primary key,
AssetCategoryID Varchar(10) constraint fkAssetCategoryIDAssetRegister references LookupData (DataID),
DeptID Varchar(10) constraint fkDeptIDAssetRegister references LookupData (DataID),
ItemDescription varchar(200),
Brand varchar(200),
Quantity int,
ValuePerPc money,
DateOfPurchase smalldatetime,
SupplierNo Varchar(20) constraint fkSupplierNoAssetRegister references Suppliers (SupplierNo),
LoginID varchar(20) constraint fkLoginIDAssetRegister references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineAssetRegister default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeAssetRegister default getdate()
)
go

-----------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------
---------------Added update on Sat 16-01-2016 ------------------------------------
----------------------------------------------------------------------------------

-----------ServicesDrSpecialtyFee----------------------------------------------------------------

alter table ServicesDrSpecialtyFee add 
CurrenciesID varchar(10) constraint fkCurrenciesIDServicesDrSpecialtyFee references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDServicesDrSpecialtyFee references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesDrSpecialtyFee default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesDrSpecialtyFee default getdate()

update ServicesDrSpecialtyFee set CurrenciesID = '49UGX' where CurrenciesID is null
update ServicesDrSpecialtyFee set ClientMachine = host_name() where ClientMachine is null

-----------ServicesStaffFee----------------------------------------------------------------

alter table ServicesStaffFee add 
CurrenciesID varchar(10) constraint fkCurrenciesIDServicesStaffFee references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDServicesStaffFee references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesStaffFee default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesStaffFee default getdate()

update ServicesStaffFee set CurrenciesID = '49UGX' where CurrenciesID is null
update ServicesStaffFee set ClientMachine = host_name() where ClientMachine is null

----------- Update AutoNumbers to below ----------------------------------------------------------------

/* exec uspInsertAutoNumbers 'InventoryTransfers', 'TransferNo', 'TransferID', 6, '0', 4, '-', '2', 0, 1, 0, 0
exec uspInsertAutoNumbers 'InventoryOrders', 'OrderNo', 'OrderID', 6, '0', 4, '-', '2', 0, 1, 0, 0
exec uspInsertAutoNumbers 'PurchaseOrders', 'PurchaseOrderNo', 'PurchaseOrderID', 6, '0', 4, '-', '2', 0, 1, 0, 0
exec uspInsertAutoNumbers 'GoodsReceivedNote', 'GRNNo', 'GRNID', 8, '0', 2, '-', '2,7', 0, 1, 0, 0 */

-----------AccessedCashServices-----03-02-2016---------------------------------------------------------

create table AccessedCashServices
(VisitNo Varchar(20) not null constraint fkVisitNoAccessedCashServices references Visits (VisitNo) on delete cascade on update cascade,
ToVisitDate Smalldatetime not null, constraint pkVisitNoToVisitDate primary key(VisitNo, ToVisitDate),
AuthorisedBy varchar(41),
AuthorisationReason varchar(10) constraint fkAuthorisationReasonAccessedCashServices references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDAccessedCashServices references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineAccessedCashServices default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeAccessedCashServices default getdate()
)
go

-----------------------------------03-02-2016--------------------------------------------------------------------------------------
alter table LabTests add UnitCost money
Alter table LabTests add LoginID varchar(20) null constraint fkLoginLabTests references Logins (LoginID)
Alter table LabTests add ClientMachine Varchar(40) constraint dfClientMachineLabTests default host_name()
Alter table LabTests add RecordDateTime smalldatetime constraint dfRecordDateTimeLabTests default getdate()

update LabTests set UnitCost = 0 where UnitCost is null 
update LabTests set ClientMachine = host_name() where ClientMachine is null
update LabTests set RecordDateTime = getdate() where RecordDateTime is null
----------------------------------------------------------------------------------------------------------------------------------

--Run Option below to hide Access Cash Services at Visits

exec uspEditOptions 'HideAccessCashServicesAtVisits', 0, '3BIT', 1, 0


create table ItemLocationOrderLevels
(LocationID varchar(10) not null constraint fkLocationIDItemLocationOrderLevels references LookupData (DataID),
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDItemLocationOrderLevels references LookupData (DataID),
ItemCode varchar(20) not null, constraint pkLocationIDItemCategoryIDItemCodeItemLocationOrderLevels primary key(LocationID, ItemCategoryID, ItemCode),
LocationOrderLevel int,
LoginID varchar(20) constraint fkLoginIDItemLocationOrderLevels references Logins (LoginID),
ClientMachine varchar(40),
RecordDateTime smallDateTime constraint dfRecordDateTimeItemLocationOrderLevels default getdate()
)
go

----------------------------------------------------------------------------------------------------------------------------------

Alter table DoctorVisits add ClientMachine varchar(40) constraint dfClientMachineDoctorVisits default host_name()
go

Alter table IPDDoctor add  ClientMachine varchar(40) constraint dfClientMachineIPDDoctor default host_name()
go


Alter table Items add CreatorClientMachine varchar(40) constraint dfCreatorClientMachine default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginID references Logins (LoginID),
ItemName varchar(800),
constraint uqVisitNoItemCategoryIDItemCodeItems unique(VisitNo, ItemCategoryID, ItemCode),
UnitMeasure varchar(100)
go


------------------------------------------14-02-2016------------------------------------------------------------------------------------

Alter table ExtraBillItems add CreatorClientMachine varchar(40) constraint dfCreatorClientMachineExtraBillItems default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginIDExtraBillItems references Logins (LoginID),ItemName varchar(800),
constraint uqExtraBillNoItemCategoryIDItemCodeItems unique(ExtraBillNo, ItemCategoryID, ItemCode),
UnitMeasure varchar(100)
go

Alter table IPDItems add CreatorClientMachine varchar(40) constraint dfCreatorClientMachineIPDItems default host_name(),
CreatorLoginID varchar(20) constraint fkIPDItemRecordLoginIDIPDItems references Logins (LoginID),ItemName varchar(800),
constraint uqRoundNoItemCategoryIDItemCodeItems unique(RoundNo, ItemCategoryID, ItemCode),
UnitMeasure varchar(100)
go

---------------------------------------------------------------------------------------------------------------------------------
-- After running below,whoever created an IPD item
---------------IPDItemCreatorCUR CURSOR ----------------------------------------------------------------------------------

DECLARE @RoundNo varchar(20)
DECLARE @ItemCategoryID VARCHAR(10)
DECLARE @ItemCode VARCHAR(20)
DECLARE @ClientMachine varchar(40)
DECLARE @LoginID varchar(20)
DECLARE @ItemName varchar(800)
DECLARE @UnitMeasure varchar(100)

DECLARE IPDItemCreatorCUR INSENSITIVE CURSOR FOR
SELECT RoundNo,ItemCategoryID, ItemCode,dbo.GetItemName(ItemCategoryID, ItemCode) as ItemName,
dbo.GetUnitMeasure(IPDItems.ItemCategoryID, IPDItems.ItemCode) as UnitMeasure,ClientMachine,
LoginID from IPDItems WHERE ItemName is null AND UnitMeasure is null

OPEN IPDItemCreatorCUR
	FETCH NEXT FROM IPDItemCreatorCUR INTO @RoundNo,@ItemCategoryID, @ItemCode,@ItemName,@UnitMeasure,@ClientMachine,@LoginID
WHILE (@@FETCH_STATUS <> -1)
	 BEGIN 
			UPDATE IPDItems SET CreatorClientMachine = @ClientMachine,CreatorLoginID = @LoginID,
			ItemName=@ItemName,UnitMeasure=@UnitMeasure
			WHERE ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND RoundNo=@RoundNo
	
	FETCH NEXT FROM IPDItemCreatorCUR INTO @RoundNo, @ItemCategoryID, @ItemCode,@ItemName,@UnitMeasure,@ClientMachine,@LoginID
	END
CLOSE IPDItemCreatorCUR
DEALLOCATE IPDItemCreatorCUR
go
---------------------------------------------------------------------------------------------------------------------------------
-- After running below,whoever created an OPD item
---------------ItemCreatorCUR CURSOR ----------------------------------------------------------------------------------
DECLARE @VisitNo VARCHAR(20)
DECLARE @ItemCategoryID VARCHAR(10)
DECLARE @ItemCode VARCHAR(20)
DECLARE @ClientMachine varchar(40)
DECLARE @LoginID varchar(20)
DECLARE @ItemName varchar(800)
DECLARE @UnitMeasure varchar(100)

DECLARE ItemCreatorCUR INSENSITIVE CURSOR FOR

SELECT VisitNo,ItemCategoryID, ItemCode,dbo.GetItemName(ItemCategoryID, ItemCode) as ItemName,
dbo.GetUnitMeasure(Items.ItemCategoryID, Items.ItemCode) as UnitMeasure,ClientMachine,
LoginID from Items WHERE ItemName is null AND UnitMeasure is null

OPEN ItemCreatorCUR
	FETCH NEXT FROM ItemCreatorCUR INTO @VisitNo,@ItemCategoryID, @ItemCode,@ItemName,@UnitMeasure,@ClientMachine,@LoginID
WHILE (@@FETCH_STATUS <> -1)
	 BEGIN 
			UPDATE Items SET CreatorClientMachine = @ClientMachine,CreatorLoginID = @LoginID,ItemName=@ItemName,UnitMeasure=@UnitMeasure
			WHERE ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND VisitNo = @VisitNo
	
	FETCH NEXT FROM ItemCreatorCUR INTO @VisitNo,@ItemCategoryID, @ItemCode,@ItemName,@UnitMeasure,@ClientMachine,@LoginID
	END
CLOSE ItemCreatorCUR
DEALLOCATE ItemCreatorCUR
go
---------------------------------------------------------------------------------------------------------------------------------
-- After running below,whoever created an ExtraBillItem will be logged  
---------------ExtraBillItemsCreatorCUR CURSOR ----------------------------------------------------------------------------------

DECLARE @ExtraBillNo VARCHAR(20)
DECLARE @ItemCategoryID VARCHAR(10)
DECLARE @ItemCode VARCHAR(20)
DECLARE @ClientMachine varchar(40)
DECLARE @LoginID varchar(20)
DECLARE @ItemName varchar(800)
DECLARE @UnitMeasure varchar(100)

DECLARE ExtraBillNoCreatorCUR INSENSITIVE CURSOR FOR
SELECT ExtraBillNo,ItemCategoryID,ItemCode,
dbo.GetItemName(ItemCategoryID, ItemCode) as ItemName,dbo.GetUnitMeasure(ExtraBillItems.ItemCategoryID, ExtraBillItems.ItemCode) as UnitMeasure,
ClientMachine,LoginID from ExtraBillItems WHERE ItemName is null AND UnitMeasure is null

OPEN ExtraBillNoCreatorCUR
	FETCH NEXT FROM ExtraBillNoCreatorCUR INTO @ExtraBillNo,@ItemCategoryID, @ItemCode,@ItemName,@UnitMeasure,@ClientMachine,@LoginID
WHILE (@@FETCH_STATUS <> -1)
	 BEGIN 
			UPDATE ExtraBillItems SET CreatorClientMachine = @ClientMachine,CreatorLoginID = @LoginID,
			ItemName=@ItemName,UnitMeasure=@UnitMeasure
			WHERE ItemCategoryID = @ItemCategoryID AND ItemCode = @ItemCode AND ExtraBillNo = @ExtraBillNo
	
	FETCH NEXT FROM ExtraBillNoCreatorCUR INTO  @ExtraBillNo,@ItemCategoryID, @ItemCode,@ItemName,@UnitMeasure,@ClientMachine,@LoginID
	END
CLOSE ExtraBillNoCreatorCUR
DEALLOCATE ExtraBillNoCreatorCUR
go

----------------------------------------------25-March-2016----------------------------------------------------------------------------------

create table SymptomsHistory
(VisitNo varchar(20) not null constraint fkVisitNoSymptomsHistory references Visits (VisitNo)
constraint pkVisitNoSymptomsHistory primary key,
Fever varchar(10) constraint fkFeverSymptomsHistory references LookupData (DataID),
Cough varchar(10) constraint fkCoughSymptomsHistory references LookupData (DataID),
CoughMoreThanTwoWeeks varchar(10) constraint fkCoughMoreThanTwoWeeksSymptomsHistory references LookupData (DataID),
DifficultyInBreathing varchar(10) constraint fkDifficultyInBreathingSymptomsHistory references LookupData (DataID),
ImmunizationDetails varchar(10) constraint fkImmunizationDetailsSymptomsHistory references LookupData (DataID),
OtherHistory varchar(2000),
Convulsions varchar(10) constraint fkConvulsionsSymptomsHistory references LookupData (DataID),
AlteredConsciousness varchar(10) constraint fkAlteredConsciousnessSymptomsHistory references LookupData (DataID),
Vomiting varchar(10) constraint fkVomitingSymptomsHistory references LookupData (DataID),
UnableToDrinkBreastfeed varchar(10) constraint fkUnableToDrinkBreastfeedSymptomsHistory references LookupData (DataID),
PastMedicalHistory varchar(2000),
Diarrhoea varchar(10) constraint fkDiarrhoeaSymptomsHistory references LookupData (DataID),
DiarrhoeaLongerThanTwoWeeks varchar(10) constraint fkDiarrhoeaLongerThanTwoWeeksSymptomsHistory references LookupData (DataID),
BloodDiarrhoea varchar(10) constraint fkBloodDiarrhoeaSymptomsHistory references LookupData (DataID),
PassingTeaColouredUrine varchar(10) constraint fkPassingTeaColouredUrineSymptomsHistory references LookupData (DataID),
FeedingHistory varchar(2000),
Pallor varchar(10) constraint fkPallorSymptomsHistory references LookupData (DataID),
SkinPinchReturn varchar(10) constraint fkSkinPinchReturnSymptomsHistory references LookupData (DataID),
SevereWasting varchar(10) constraint fkSevereWastingSymptomsHistory references LookupData (DataID),
Edema varchar(10) constraint fkEdemaSymptomsHistory references LookupData (DataID),
SunkenEyes varchar(10) constraint fkSunkenEyesSymptomsHistory references LookupData (DataID),
Jaundice varchar(10) constraint fkJaundiceSymptomsHistory references LookupData (DataID),
MUAC int ,
Height int,
DeepBreathing varchar(10) constraint fkDeepBreathingSymptomsHistory references LookupData (DataID),
FlaringOfNostrils varchar(10) constraint fkFlaringOfNostrilsSymptomsHistory references LookupData (DataID),
IntercostalRecession  varchar(10) constraint fkIntercostalRecessionSymptomsHistory references LookupData (DataID),
subCostalRecession  varchar(10) constraint fksubCostalRecessionSymptomsHistory references LookupData (DataID),
Pulse varchar(10) constraint fkPulseSymptomsHistory references LookupData (DataID),
CapRefill varchar(10) constraint fkCapRefillSymptomsHistory references LookupData (DataID),
Airway varchar(10) constraint fkAirwaySymptomsHistory references LookupData (DataID),
Wheezing varchar(10) constraint fkWheezingSymptomsHistory references LookupData (DataID),
PleuralRub varchar(10) constraint fkPleuralRubSymptomsHistory references LookupData (DataID),
Crackles varchar(10) constraint fkCracklesSymptomsHistory references LookupData (DataID),
Unconscious varchar(10) constraint fkUnconsciousSymptomsHistory references LookupData (DataID),
Lethargic varchar(10) constraint fkLethargicSymptomsHistory references LookupData (DataID),
UnableToSitStand varchar(10) constraint fkUnableToSitStandSymptomsHistory references LookupData (DataID),
BulgingFontanelle varchar(10) constraint fkBulgingFontanelleSymptomsHistory references LookupData (DataID),
StiffNeck varchar(10) constraint fkStiffNeckSymptomsHistory references LookupData (DataID),
KerningsSign varchar(10) constraint fkKerningsSignSymptomsHistory references LookupData (DataID),
IsBloodTransfusionDesired varchar(10) constraint fkIsBloodTransfusionDesiredSymptomsHistory references LookupData (DataID),
BloodTransfusionStateReasons varchar(200),
IfDesiredWasBloodGiven varchar(10) constraint fkIfDesiredWasBloodGivenSymptomsHistory references LookupData (DataID),
IfYesVolume int,
TransfusionDate smallDateTime,
BloodUnits int,
BloodTransfusionNotGivenStateReasons varchar(200),
OtherFormsOfSupportiveCare varchar(200),
ReasonsForDiagnosisOfSevereComplicatedMalaria varchar(200),
ReasonsForAdmissionWithPositiveMalariaTest varchar(200),
LoginID varchar(20) constraint fkLoginIDSymptomsHistory references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineSymptomsHistory default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeSymptomsHistory default getdate()

)
go

----------------------------------------------------------------------------------------------------------------------------------

create table FamilyMembers
(PatientNo varchar(20) not null constraint fkPatientNoFamilyMembers references Patients (PatientNo)
on delete cascade on update cascade,
MemberName varchar(41) not null,
constraint pkPatientNoMemberName primary key(PatientNo, MemberName),
Age tinyint,
HIVStatusID varchar(10) constraint fkHIVStatusIDFamilyMembers references LookupData (DataID),
HIVCareID varchar(10) constraint fkHIVCareIDFamilyMembers references LookupData (DataID),
UniqueNo varchar(20)
)
go
----------------------------------------------------------------------------------------------------------------------------------
create table ExposedInfants
(PatientNo varchar(20) not null constraint fkPatientNoExposedInfants references Patients (PatientNo) 
on delete cascade on update cascade,
InfantName varchar(41) not null,
constraint pkPatientNoInfantName primary key(PatientNo, InfantName),
BirthDate smalldatetime,
InfantFeedingID varchar(10) constraint fkInfantFeedingIDExposedInfants references LookupData (DataID),
CTXStarted varchar(41),
HIVTestTypeID varchar(10) constraint fkHIVTestTypeIDExposedInfants references LookupData (DataID),
TestResultsID varchar(10) constraint fkTestResultsIDExposedInfants references LookupData (DataID),
InfantStatusID varchar(10) constraint fkInfantStatusIDExposedInfants references LookupData (DataID),
UniqueNo varchar(20)
)
go
----------------------------------------------------------------------------------------------------------------------------------
create table PriorARTDetails
(PatientNo varchar(20) not null constraint fkPatientNoPriorARTDetails references Patients (PatientNo)
on delete cascade on update cascade,
PriorARTID varchar(10) constraint fkPriorARTIDPriorARTDetails references LookupData (DataID),
constraint pkPatientNoPriorARTID primary key(PatientNo, PriorARTID),
ARTDate smalldatetime,
ARTWhere varchar(41),
Combination varchar(30) constraint fkCombinationPriorARTDetails references DrugCombinations (Combination)
)
go
----------------------------------------------------------------------------------------------------------------------------------
create table Examinations
(VisitNo varchar(20) not null constraint fkVisitNoExaminations references Visits (VisitNo) 
constraint pkVisitNoExaminations primary key,
ExamVisitTypeID varchar(10) constraint fkExamVisitTypeIDExaminations references LookupData (DataID),
FollowupDate smalldatetime,
DurationStartART int,
DurationCurrentART int,
OedemaID varchar(10) constraint fkOedemaIDExaminations references LookupData (DataID),
PregnancyStatusID varchar(10) constraint fkPregnancyStatusIDExaminations references LookupData (DataID),
ExpectedDeliveryDate smalldatetime,
PMTCT bit,
GestationalAge smallint,
MUACStatusID varchar(10) constraint fkMUACStatusIDExaminations references LookupData (DataID),
FPMethods varchar(200),
TBStatusID varchar(10) constraint fkTBStatusIDExaminations references LookupData (DataID),
TBRxStartDate smalldatetime,
TBRxStopDate smalldatetime,
TBRegNo varchar(20),
SideEffects varchar(200),
NewOI varchar(200),
FunctionalStatusID varchar(10) constraint fkFunctionalStatusIDExaminations references LookupData (DataID),
WHOStageID varchar(10) constraint fkWHOStageIDExaminations references LookupData (DataID),
CPTAdhereID varchar(10) constraint fkCPTAdhereIDExaminations references LookupData (DataID),
CPTDosage smallint,
CPTDuration smallint,
OtherMeds varchar(200),
NutritionalSupID varchar(10) constraint fkNutritionalSupIDExaminations references LookupData (DataID),
ARVAdhereID varchar(10) constraint fkARVAdhereIDExaminations references LookupData (DataID),
ARVAdhereWhy varchar(200),
Combination varchar(30) constraint fkCombinationExaminations references DrugCombinations (Combination),
ARVDosage smallint,
ARVDuration smallint,
CD4ABS decimal(10,2),
CD4PCT decimal(10,2),
Investigations varchar(200),
Refer varchar(40),
DaysHOSP smallint,
LoginID varchar(20) constraint fkLoginIDExaminations references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeExaminations default getdate()
)
go
----------------------------------------------------------------------------------------------------------------------------------
create table HIVCARE
( PatientNo Varchar(20) not null constraint pkPatientNoHIVCARE primary key constraint 
 fkPatientNo references Patients (PatientNo) on delete cascade on update cascade,
HealthUnitCode varchar(10) constraint fkHealthUnit references HealthUnits (HealthUnitCode),
TeamLeader varchar(10) constraint fkTeamLeader references Staff (StaffNo),
PtClinic varchar(20),
LC1 Varchar(200),
ConfirmedTestDate smalldatetime,
HIVEnrolledDate smalldatetime,
EligibleARTDate smalldatetime,
EligibleReadyDate smalldatetime,
Ab bit,
PCR bit,
HIVCareWhere varchar(41),
HIVCareTransferIn bit,
TransferInFrom varchar(41),
WHOStageID varchar(10) constraint fkWHOStageIDPatients references LookupData (DataID),
CD4 decimal(10,2),
PresumptiveHIV bit,
PCRInfant bit,
MedicalConditions varchar(2000),
COHORTMonth tinyint,
COHORTYear smallint,
ARTTransferInDate smalldatetime,
ARTTransferInFrom varchar(40),
TransferInRegimen varchar(30) constraint fkTransferInRegimenPatients references DrugCombinations (Combination),
StartARTDate smalldatetime,
StartARTRegimen varchar(30) constraint fkStartARTRegimenPatients references DrugCombinations (Combination),
StartARTWeight decimal(10,2),
StartARTWHOStageID varchar(10) constraint fkStartARTWHOStageIDPatients references LookupData (DataID),
StartARTCD4 decimal(10,2),
PregnancyStatusID varchar(10) constraint fkPregnancyStatusIDPatients references LookupData (DataID),
LoginID varchar(20)constraint fkLoginIDHIVCARE references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeHIVCARE default getdate(),
ComputerName varchar(40) constraint dfComputerNameHIVCARE  default host_name()

)
go
----------------------------------------------------------------------------------------------------------------------------------
create table DrugAdministration
(VisitNo varchar(20) constraint fkVisitNoDrugAdministration references Visits (VisitNo) On delete cascade on update cascade,
TakenDateTime smalldatetime,
constraint pkVisitNoTakenDateTime primary key(VisitNo, TakenDateTime),
ItemCode varchar(20) not null,
ItemCategory varchar(10) constraint fkItemCategoryDrugAdministration references LookupData (DataID),
ItemName varchar(800) not null,
constraint uqVisitNoTakenDateTimeItemName unique(VisitNo, TakenDateTime, ItemName),
QuantityTaken int,
NurseNotes varchar(200),
StaffNo varchar(10) constraint fkStaffNoDrugAdministration references Staff (StaffNo),
LoginID varchar(20) constraint fkLoginIDDrugAdministration references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineDrugAdministration default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeDrugAdministration default getdate()
)
go

----------------------------------------------------------------------------------------------------------------------------------
alter table Patients add NationalIDNo varchar(14)

update Patients set NationalIDNo = '' where NationalIDNo is null
----------------------------------------------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------------------------------------------

----------------------------07-04-2016----------------------------------------------------------------------------------------------

Alter Table Visits add VisitsPriorityID varchar(10) null constraint dfVisitsPriorityIDVisits references LookupData (DataID)

update Visits  set Visits.VisitsPriorityID = '155NO' where Visits.VisitsPriorityID is null

Alter Table Triage add TriagePriorityID varchar(10) null constraint dfTriagePriorityIDTriage references LookupData (DataID)

update Triage  set Triage.TriagePriorityID = '155NO' where Triage.TriagePriorityID is null


------------------------------------------------------------------------------------------------------
-------------- Create Table: ItemsBalanceDetails ------------------------------------------------------
------------------------------------------------------------------------------------------------------

create table ItemsBalanceDetails
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDItemsBalanceDetails foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDItemsBalanceDetails primary key (VisitNo, ItemCode, ItemCategoryID),
ItemName varchar(800),
Balance int constraint dfBalanceItemsBalanceDetails default 0,
BalanceStatus varchar(10) constraint fkBalanceStatusItemsBalanceDetails references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDitemsBalanceDetails references Logins (LoginID),
NextVisitNo varchar(20) not null,
ClientMachine varchar(40) constraint dfClientMachineitemsBalanceDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeitemsBalanceDetails default getdate()
)
go
-------------------------------------------------------------------------------------------------------------
exec uspEditOptions 'AllowExtraBillInventoryIssuing', 0, '3BIT', 1, 0
-------------------------------------------------------------------------------------------------------------

drop proc uspCountNationalIdentificationNo


create table ItemsIncome
(VisitNo varchar(20) constraint fkVisitNoItemsIncome references Visits (VisitNo),
ItemCode Varchar(20),
ItemCategoryID varchar(10) constraint fkItemCategoryIDItemsIncome references LookupData (DataID),
constraint pkVisitNoItemCodeItemCategoryIDItemsIncome primary key(VisitNo, ItemCode, ItemCategoryID),
ItemName Varchar(500),
UnitPrice money,
CopayAmount money,
Quantity int,
LoginID varchar(20) constraint fkLoginIDItemsIncome references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineItemsIncome default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeItemsIncome default getdate()
)
go
-------------------------------------------------------------------------------------------------------------
exec uspEditOptions 'SendSMSUsingAPI001', 0, '3BIT', 1, 0
-------------------------------------------------------------------------------------------------------------

Alter table GoodsReceivedNote add CreditNoteOnTotal money
go

update GoodsReceivedNote set CreditNoteOnTotal = 0.00 where CreditNoteOnTotal is null
go

exec uspEditOptions 'HideBillFormItemsPresentAtIPDDoctor', 0, '3BIT', 1, 0

exec uspEditOptions 'EnableSMSNotificationAtAppointments', 0, '3BIT', 1, 0

exec uspEditOptions 'EnableSMSNotificationAtCashPayment', 0, '3BIT', 1, 0

exec uspEditOptions 'EnableSMSNotificationAtLab', 0, '3BIT', 1, 0

exec uspEditOptions 'EnableSMSNotificationAtPatientReg', 0, '3BIT', 1, 0

exec uspEditOptions 'InventoryAlertDays', 7, '3NUM', 2, 0

exec uspEditOptions 'InheritOPDServicesAtIPD', 0, '3BIT', 1, 0

------------------------------------------25-MAY-2016-----------------------------------------------------------------

create table GoodsReturnedNote
(ReturnID int,
ReturnNo varchar(20) constraint pkReturnNoGoodsReturnedNote primary key,
GRNNo varchar(20) constraint fkGRNNoGoodsReturnedNote references GoodsReceivedNote (GRNNo) on delete cascade on update cascade,
ReturnDate smalldatetime,
AmountWords varchar(200),
Notes varchar(100),
LoginID varchar(20) constraint fkLoginIDGoodsReturnedNote references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineGoodsReturnedNote default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateGoodsReturnedNote default getdate()
)
go
--------------------------------------------25-MAY-2016-----------------------------------------------------------------
create table GoodsReturnedNoteDetails
(ReturnNo varchar(20) not null constraint fkReturnNoGoodsReturnedNoteDetails references GoodsReturnedNote (ReturnNo) on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDGoodsReturnedNoteDetails references LookupData (DataID),
ItemCode varchar(20) not null, constraint pkReturnNoItemCategoryIDItemCode primary key(ReturnNo, ItemCategoryID, ItemCode),
ItemName varchar(800),
ReturnQuantity Int,
GoodsReturnReasonID varchar(10) constraint fkGoodsReturnReasonIDGoodsReturnedNoteDetails references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDGoodsReturnedNoteDetails references Logins (LoginID),
ClientMachine varchar(20) constraint dfClientMachineGoodsReturnedNoteDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeGoodsReturnedNoteDetails default getdate()
)
go

-----------------------------------------------25-MAY-2016------------------------------------------------------------

create table updateHistory
(OriginalLogin varchar(500),
SystemUser varchar(500),
ClientMachine varchar(40) constraint dfClientMachineupdateHistory default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeupdateHistory default getdate()
)
go

-------------------------------------------27-may-2016----------------------------------------------------------------
alter table DrugAdministration drop pkVisitNoTakenDateTime

-------------------------------------------------------------------------------------------------------------
alter table DrugAdministration
add constraint pkVisitNoTakenDateTimeItemCode primary key(VisitNo, TakenDateTime,ItemCode)
-------------------------------------------------------------------------------------------------------------

exec uspEditOptions 'CategorizeVisitInvoiceDetails', 0, '3BIT', 1, 0

-------------------------------------------------------------------------------------------------------------
alter table LabTests add TubeType varchar(200)
alter table LabTests add TestDescription varchar(500)
-------------------------------------------------------------------------------------------------------------

update LabTests set TubeType = '' where TubeType is null
update LabTests set TestDescription = '' where TestDescription is null
-------------------------------------------------------------------------------------------------------------

exec uspEditOptions 'DisablePatientRegistration', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableVisitsCreation', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableExtras', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableTriagePoint', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableCashier', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableInvoices', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableDoctor', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableLaboratory', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableRadiology', 0, '3BIT', 1, 0
exec uspEditOptions 'DisablePharmacy', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableTheatre', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableDental', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableAppointments', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableInPatients', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableManageART', 0, '3BIT', 1, 0
exec uspEditOptions 'DisableDeaths', 0, '3BIT', 1, 0
exec uspEditOptions 'DisablePathology', 0, '3BIT', 1, 0
-------------------------------------------------------------------------------------------------------------
alter table PurchaseOrders
alter column ShipAddress varchar(300) not null

----------------------------------------------------------------------------------------------------------------------------
drop function GetOutWardNoFromFileNo

-------------------------------20-JUNE-2016-------------------------------------------------------------------------------------------

create table BulkMessaging
(MessageID INT constraint dfMessageIDBulkMessaging default 0,
MessageNo Varchar(20) constraint pkMessageNo primary key,
Phone varchar(7500),
Message Varchar(500),
LoginID Varchar(20) constraint fkLoginIDBulkMessaging references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineBulkMessaging default host_name(),
RecordDateTime smallDatetime constraint dfRecordDateTimeBulkMessaging default getdate()
)
go

----------------------------------------------------------------------------------------------------------------------------

create table Messenger
(ReceiverStaffNo varchar(10) constraint fkReceiverStaffNoMessenger references Staff (StaffNo),
MessageInfo varchar(2000),
LoginID varchar(20) constraint fkLoginIDMessenger references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineMessenger default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeMessenger default getdate(),
Status bit
)
go

---------------Logins-------------------------------------------------------------

alter table Logins add
CreatorLoginID varchar(20) null constraint fkCreatorLoginIDLogins references Logins (LoginID),
CreatorClientMachine varchar(40) constraint dfCreatorClientMachineLogins default host_name(),
CreatorRecordDateTime smalldatetime constraint dfCreatorRecordDateTimeLogins default getdate()


--- Note: If Admin is not created in DB, use whoever administors database
update Logins set CreatorLoginID = 'Admin' where CreatorLoginID is null and not LoginID = 'Admin'
update Logins set CreatorClientMachine = host_name() where CreatorClientMachine is null
update Logins set CreatorRecordDateTime = getdate() where CreatorRecordDateTime is null


----------------------------------------------------------------------------------------------------------------------------
--------------------------------------- low vision--------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'LowVision')
	drop table LowVision
go

alter table VisionAssessment drop constraint fkVisualAcuityRightIDVisionAssessment
alter table VisionAssessment drop constraint fkVisualAcuityLeftIDVisionAssessment
go

alter table IPDVisionAssessment drop constraint fkVisualAcuityRightIDIPDVisionAssessment
alter table IPDVisionAssessment drop constraint fkVisualAcuityLeftIDIPDVisionAssessment
go

delete from LookupData where DataID= '12301'
delete from LookupData where DataID= '12300'
delete from LookupData where DataID= '12302'
delete from LookupData where DataID= '12303'
delete from LookupData where DataID= '12304'
delete from LookupData where DataID= '12305'
delete from LookupData where DataID= '12306'
delete from LookupData where DataID= '12307'
delete from LookupData where DataID= '12308'
go





create table LowVision
(VisitNo varchar(20) constraint pkVisitNoLowVision primary key  constraint fkVisitNoLowVision references Visits (VisitNo) on delete cascade on update cascade,
BriefHistory varchar(200),
Profession varchar(200),
MajorOcularDiagnosisRE varchar(200),
MajorOcularDiagnosisLE varchar(200),
OtherOcularDiagnosisRE varchar(200),
OtherOcularDiagnosisLE varchar(200),
OphthalmologistSeenID varchar(10) constraint fkOphthalmologistSeenIDLowVision references LookupData (DataID),
OtherImpairmentsID varchar(10) constraint fkOtherImpairmentsIDLowVision references LookupData (DataID),
OtherImpairments varchar(200),
ExistingTreatmentFarRE varchar(200),
ExistingTreatmentFarLE varchar(200),
ExistingTreatmentNearRE varchar(200),
ExistingTreatmentNearLE varchar(200),
NewTreatmentFarRE varchar(200),
NewTreatmentFarLE varchar(200),
NewTreatmentNearRE varchar(200),
NewTreatmentNearLE varchar(200),
ExistingVisualAcuityFarLEID varchar(200),
ExistingVisualAcuityFarREID varchar(200),
ExistingVisualAcuityNearLEID varchar(200),
ExistingVisualAcuityNearREID varchar(200),
NewVisualAcuityFarLEID varchar(200),
NewVisualAcuityFarREID varchar(200),
NewVisualAcuityNearLEID varchar(200),
NewVisualAcuityNearREID varchar(200),
ExistingLVDsNear varchar(200),
ExistingLVDsFar varchar(200),
ProblemEncounteredLVDsNear varchar(200),
ProblemEncounteredLVDsFar varchar(200),
ColourVisionDefectID varchar(10) constraint fkColourVisionDefectIDLowVision references LookupData (DataID),
ColourVisionTestUsed varchar(200),
ContrastSensitivityID varchar(10) constraint fkContrastSensitivityIDLowVision references LookupData (DataID),
ContrastSensitivityTestUsed varchar(200),
VisualFieldDefectID varchar(10) constraint fkVisualFieldDefectIDLowVision references LookupData (DataID),
VisualFieldDefectTestUsed varchar(200),
LowVisionDevicesFar varchar(200),
LowVisionDevicesNear varchar(200),
NonOpticalAids varchar(200),
Advice varchar(200),
LoginID varchar(20) constraint fkLoginIDLowVision references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineLowVision default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeLowVision default getdate()
)
go

alter table Refraction add PD varchar(200)
alter table Refraction add SegmentHeights varchar(200)
go

alter table VisionAssessment drop constraint fkPerceptionOfLightRightIDVisionAssessment
alter table VisionAssessment drop constraint fkPerceptionOfLightLeftIDVisionAssessment
go

alter table IPDVisionAssessment drop constraint fkPerceptionOfLightRightIDIPDVisionAssessment
alter table IPDVisionAssessment drop constraint fkPerceptionOfLightLeftIDIPDVisionAssessment
go

 delete from LookupData where DataID= '127NA'
 delete from LookupData where DataID= '127NPL'
 delete from LookupData where DataID= '127PL'
go


update  LookupObjects SET ObjectName ='PreferentialLooking', ObjectDes ='Preferential Looking' where ObjectID = 127
go 

alter table VisionAssessment drop fkHandMovementRightIDVisionAssessment
alter table VisionAssessment drop fkHandMovementLeftIDVisionAssessment
alter table VisionAssessment drop fkClinicalCommentIDVisionAssessment
go

alter table VisionAssessment drop column HandMovementRightID 
alter table VisionAssessment drop column HandMovementLeftID
alter table VisionAssessment drop column ClinicalCommentID
go

exec sp_rename 'VisionAssessment.PerceptionOfLightRightID', 'PreferentialLookingRightID', 'COLUMN'
exec sp_rename 'VisionAssessment.PerceptionOfLightLeftID', 'PreferentialLookingLeftID', 'COLUMN'
go

--------------------------------------- First Run Data--------------------------------------------------------------------------

alter table VisionAssessment add constraint fkVisualAcuityRightIDVisionAssessment foreign key (VisualAcuityRightID) references LookupData (DataID)
alter table VisionAssessment add constraint fkVisualAcuityLeftIDVisionAssessment foreign key (VisualAcuityLeftID) references LookupData (DataID)
alter table VisionAssessment add constraint fkPreferentialLookingRightIDVisionAssessment foreign key (PreferentialLookingRightID) references LookupData (DataID)
alter table VisionAssessment add constraint fkPreferentialLookingLeftIDVisionAssessment foreign key (PreferentialLookingLeftID) references LookupData (DataID)
go

alter table IPDVisionAssessment drop fkHandMovementRightIDIPDVisionAssessment
alter table IPDVisionAssessment drop fkHandMovementLeftIDIPDVisionAssessment
alter table IPDVisionAssessment drop fkClinicalCommentIPDVisionAssessment
go

alter table IPDVisionAssessment drop column HandMovementRightID 
alter table IPDVisionAssessment drop column HandMovementLeftID
alter table IPDVisionAssessment drop column ClinicalComment



exec sp_rename 'IPDVisionAssessment.PerceptionOfLightRightID', 'PreferentialLookingRightID', 'COLUMN'
exec sp_rename 'IPDVisionAssessment.PerceptionOfLightLeftID', 'PreferentialLookingLeftID', 'COLUMN'
go

alter table IPDVisionAssessment add constraint fkVisualAcuityRightIDIPDVisionAssessment foreign key (VisualAcuityRightID) references LookupData (DataID)
alter table IPDVisionAssessment add constraint fkVisualAcuityLeftIDIPDVisionAssessment foreign key (VisualAcuityLeftID) references LookupData (DataID)
alter table IPDVisionAssessment add constraint fkPreferentialLookingRightIDIPDVisionAssessment foreign key (PreferentialLookingRightID) references LookupData (DataID)
alter table IPDVisionAssessment add constraint fkPreferentialLookingLeftIDIPDVisionAssessment foreign key (PreferentialLookingLeftID) references LookupData (DataID)
go


----------------------------------------------------------------------------------------------------------------------------

-------------------------------110COM combined visitType lookUpData----------------------
exec uspInsertLookupData '110COM', 110, 'COMBINED IPD AND OPD','N'



alter table Visits add
Locked bit constraint dfLockedVisits default 0

---------------------------------------------------------------------------------
update Visits set Locked = 0 where Locked is null

exec uspEditOptions 'LockVisitUponInvoiceCreation', 0, '3BIT', 1, 0

exec uspEditOptions 'DisableDosageAndDurationAtSelfRequest', 0, '3BIT', 1, 0

exec uspEditOptions 'CaptureAndUseBarCodes', 0, '3BIT', 1, 0

---------------------------------------------------22-Aug-2016-----------------------------------------------------------------------
create table BarCodeDetails
(ItemCode Varchar(20),
ItemCategoryID varchar(10),
BarCode Varchar(2000),
LoginID varchar(20),
ClientMachine Varchar(40),
RecordDateTime SmallDateTime constraint dfRecordDateTimeBarCodeDetails default getdate(),
constraint pkItemCodeItemCategoryIDRecordDateTime primary key(ItemCode, ItemCategoryID, RecordDateTime)
)
go

----------------24/08/16-------------------------------------

alter table GoodsReceivedNoteDetails add VATPercentage decimal
alter table ConsumableItems add VATPercentage decimal
alter table Drugs add VATPercentage decimal
alter table Services add VATPercentage decimal
alter table LabTests add VATPercentage decimal
alter table RadiologyExaminations add VATPercentage decimal
alter table PathologyExaminations add VATPercentage decimal
alter table Beds add VATPercentage decimal
alter table ExtraChargeItems add VATPercentage decimal
alter table Procedures add VATPercentage decimal
alter table DentalServices add VATPercentage decimal
alter table TheatreServices add VATPercentage decimal
alter table EyeServices add VATPercentage decimal
alter table OpticalServices add VATPercentage decimal
alter table MaternityServices add VATPercentage decimal
alter table ICUServices add VATPercentage decimal
alter table Items add VATValue money default 0
alter table ItemsIncome add VATValue money default 0


update GoodsReceivedNoteDetails set VATPercentage=0 where VATPercentage is null
update ConsumableItems set VATPercentage=0 where VATPercentage is null
update Drugs set VATPercentage=0 where VATPercentage is null
update Services  set VATPercentage=0 where VATPercentage is null
update LabTests  set VATPercentage=0 where VATPercentage is null
update RadiologyExaminations  set VATPercentage=0 where VATPercentage is null
update PathologyExaminations  set VATPercentage=0 where VATPercentage is null
update Beds  set VATPercentage=0 where VATPercentage is null
update ExtraChargeItems  set VATPercentage=0 where VATPercentage is null
update Procedures  set VATPercentage=0 where VATPercentage is null
update DentalServices  set VATPercentage=0 where VATPercentage is null
update TheatreServices  set VATPercentage=0 where VATPercentage is null
update EyeServices  set VATPercentage=0 where VATPercentage is null
update OpticalServices  set VATPercentage=0 where VATPercentage is null
update MaternityServices  set VATPercentage=0 where VATPercentage is null
update ICUServices  set VATPercentage=0 where VATPercentage is null
update Items set VATValue=0 where VATValue is null
update ItemsIncome set VATValue=0 where VATValue is null

----------------------------------------------------------------------------------------------------------------------------

exec uspEditOptions 'EnableSMSNotificationAtRadiology', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableSMSNotificationAtVisits', 0, '3BIT', 1, 0

-------------------------------------28-Aug-2016-------------------------------------------------------------------------------------
exec uspEditOptions 'EnableSMSNotificationForBirthdays', 0, '3BIT', 1, 0

----------------------------------------------------------------------------------------------------------------------------

-----------------2016-09-01--Returns-----------------------------------------------------------------------------------------------

---------------UpDate ReturnedExtrabillItems--------------------------------------------------------------------------------

alter table ReturnedExtrabillItems add
ItemTransferStatus varchar(10) constraint fkItemTransferStatusReturnedExtrabillItems references LookupData (DataID),
TransactionDate smalldatetime  constraint fkTransactionDateReturnedExtrabillItems default getdate()

update ReturnedExtrabillItems set ItemTransferStatus = '11P' where ItemTransferStatus is null

update ReturnedExtrabillItems set TransactionDate = ReturnedExtrabillItems.ReturnDate where TransactionDate is null

----------------------------------------------------------------------------------------------------------------------------
---------------------------2016-09-12 46RTD emtry mode returned lookupdata----------------------------------------------------------------

exec uspInsertLookupData '46RTD', 46, 'Returned','N'

---------------------------------------------------------------------------------------------------------------------


---------------------------2016-08-25 returnedItems------------------------------------------------------------------

create table ReturnedItems
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDReturnedItems foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDReturnedItems primary key(VisitNo, ItemCode, ItemCategoryID),
ReturnDate smalldatetime,
Quantity int,
Notes varchar(200),
ItemTransferStatus varchar(10) constraint fkItemTransferStatusReturnedItems references LookupData (DataID),
TransactionDate smalldatetime  constraint fkTransactionDateReturnedItems default getdate(),
LoginID varchar(20) constraint fkLoginIDReturnedItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineReturnedItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeReturnedItems default getdate()
)
go
-------------------------------------------------------------------------------------------------------------------------------

--------------------------SEPTEMBER 05/09/2016-----------------------------------

alter table GoodsReceivedNote
drop constraint dfVATPercentGoodsReceivedNote

exec sp_rename 'GoodsReceivedNote.VATPercent', 'TotalVAT', 'COLUMN'

alter table GoodsReceivedNote
alter column TotalVAT money


alter table GoodsReceivedNote
add constraint dfTotalVAT default 0 for TotalVAT 

alter table GoodsReceivedNoteDetails
add VATValue money default 0 

update GoodsReceivedNoteDetails set VATValue=0 Where VATValue is null


-----------08-Sep-2016-----------------------------------------

exec uspEditOptions 'ForceDiagnosisAtDoctor', 0, '3BIT', 1, 0
-----------09-Sep-2016-----------------------------------------

exec uspEditOptions 'OpenIPDTheatreIssueConsumablesAfterPrescription', 0, '3BIT', 1, 0

exec uspEditOptions 'AllowAccessCashConsultation', 0, '3BIT', 1, 0

-----------03 -Oct -2016---------------------------------------
create table PhysicalStockCount
(PSCID int not null constraint dfPSCIDPhysicalStockCount default 1,
PSCNo varchar(20) not null
constraint pkPSCNo primary key,
GeneralNotes Varchar(200),
LoginID varchar(20)
constraint fkLoginIDPhysicalStockCount references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePhysicalStockCount default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePhysicalStockCount default getdate()
)
go


create table PhysicalStockCountDetails
(PSCNo varchar(20) not null
constraint fkPSCNoPhysicalStockCountDetails references PhysicalStockCount (PSCNo),
LocationID  varchar(10) not null
constraint fkLocationIDPhysicalStockCountDetails references LookupData (DataID),
ItemCategoryID  varchar(10) not null
constraint fkItemCategoryIDPhysicalStockCountDetails references LookupData (DataID),
ItemCode Varchar(20),
constraint pkPSCNoLocationIDItemCategoryIDItemCode primary key(PSCNo, LocationID , ItemCategoryID , ItemCode),
SystemQuantity int,
PhysicalCountQuantity int,
Notes Varchar(200),
LoginID Varchar(20)
constraint fkLoginIDPhysicalStockCountDetails references Logins (LoginID),
ClientMachine Varchar(20) constraint dfClientMachinePhysicalStockCountDetails default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePhysicalStockCountDetails default getdate()
)
go

alter table Patients add
BranchID varchar(10) constraint fkBranchIDPatients references LookupData (DataID)
go

-----RUN DATA

Update Patients SET BranchID ='177NA' where BranchID is null


alter table Visits add
BranchID varchar(10) constraint fkBranchIDVisits references LookupData (DataID)
go

Update Visits SET BranchID ='177NA' where BranchID is null

----------------------------------------10-Oct-2016-------------------------------------------------------------------------------------

alter table BulkMessaging drop pkMessageNo
alter table BulkMessaging alter column Message varchar(600) Not Null
alter table BulkMessaging alter column RecordDateTime smallDatetime Not Null

alter table BulkMessaging add
SentID varchar(10) constraint fkSentIDBulkMessaging references LookupData (DataID)

alter table BulkMessaging add
flagID varchar(10) constraint fkflagIDBulkMessaging references LookupData (DataID)

alter table BulkMessaging add constraint pkMessageNoMessageRecordDateTime primary key(MessageNo, Message,RecordDateTime)
go

----------------------------------------------18-Oct-2016----------------------------------------------------------------------------

UPDATE AccessObjects SET ObjectCaption ='Text Messages' WHERE ObjectName ='BulkMessaging'

exec uspEditOptions 'EnableSMSNotificationForIncomeSummaries', 0, '3BIT', 1, 0
exec uspEditOptions 'IncomeSummariesSMSTime', '7:31:00 PM', '3STR', 20, 0
exec uspEditOptions 'EnableSMSNotificationAtManageAccounts', 0, '3BIT', 1, 0

------------------------------------------------------------------------------------------------------------------------------------

drop table IPDNurse

------------------------------------------------------------------------------------------------------------------------------------
create table IPDNurse
(IPDNurseRoundID int not null constraint dfIPDNurseRoundIDIPDNurse default 1,
NurseRoundNo varchar(20) not null constraint pkNurseRoundNoIPDNurse primary key,
RoundNo varchar(20) not null constraint fkRoundNoIPDNurse  references IPDDoctor (RoundNo)on delete cascade on update cascade,
Weight decimal(5,2) constraint ckWeightIPDNurse check (Weight > 0 and Weight <= 200),
Temperature decimal(5,2) constraint ckTemperatureIPDNurse check (Temperature > 30 and Temperature < 50),
Height decimal(5,2) constraint ckHeightIPDNurse check (Height > 40 and Height < 300),
Pulse tinyint constraint ckPulseIPDNurse check (Pulse > 10 and Pulse <= 300),
BloodPressure varchar(10),
HeadCircum decimal(5,2) constraint ckHeadCircumIPDNurse check (HeadCircum > 20 and HeadCircum < 150),
BodySurfaceArea decimal(10,2),
RespirationRate tinyint constraint ckRespirationRateIPDNurse check (RespirationRate > 10 and RespirationRate < 150),
OxygenSaturation decimal(5,2) constraint ckOxygenSaturationIPDNurse check (OxygenSaturation > 0 and OxygenSaturation <= 100),
HeartRate tinyint constraint ckHeartRateIPDNurse check (HeartRate > 0 and HeartRate <= 250),
Notes varchar(4000),
NurseRoundDateTime smalldatetime,
StaffNo varchar(10) constraint fkStaffNoIPDNurse references Staff (StaffNo),
OtherAttendingNurse varchar(100),
LoginID varchar(20) constraint fkLoginIDIPDNurse references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDNurse default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDNurse default getdate()
)
go
------------------------------------------------------------------------------------------------------------------------------------

drop table IPDDrugAdministration

------------------------------------------------------------------------------------------------------------------------------------

create table IPDDrugAdministration
(NurseRoundNo varchar(20) constraint fkNurseRoundNoIPDDrugAdministration references IPDNurse (NurseRoundNo) On delete cascade on update cascade,
TakenDateTime smalldatetime,
ItemCode varchar(20) not null
constraint pkNurseRoundNoTakenDateTimeItemCodeIPDDrugAdministration primary key(NurseRoundNo, TakenDateTime,ItemCode),
ItemCategoryID varchar(10) constraint fkItemCategoryIPDDrugAdministration references LookupData (DataID),
ItemName varchar(800) not null,
constraint uqNurseRoundNoTakenDateTimeItemNameIPDDrugAdministration unique(NurseRoundNo, TakenDateTime, ItemName),
QuantityTaken int,
StaffNo varchar(10) constraint fkStaffNoIPDDrugAdministration references Staff (StaffNo),
NurseNotes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDDrugAdministration references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDDrugAdministration default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDDrugAdministration default getdate()
)
go

------------------------------------------------------------------------------------------------------------------------------------

drop table IPDNurseFluids

------------------------------------------------------------------------------------------------------------------------------------

create table IPDNurseFluids
(NurseRoundNo varchar(20) constraint fkNurseRoundNoIPDNurseFluids references IPDNurse (NurseRoundNo) On delete cascade on update cascade,
TakenDateTime smalldatetime,
FluidTypeID varchar(10) constraint fkFluidTypeIDIPDNurseFluids references LookupData (DataID),
constraint pkNurseRoundNoFluidTypeIDFluidCategoryIDIPDNurseFluids primary key(NurseRoundNo, FluidTypeID, FluidCategoryID),
FluidCategoryID varchar(10) constraint fkFluidCategoryIDIPDNurseFluids references LookupData (DataID),
RouteID varchar(10)  constraint fkRouteIDIPDNurseFluids references LookupData (DataID),
constraint uqNurseRoundNoFluidTypeIDFluidCategoryIDIPDNurseFluids unique(NurseRoundNo, FluidTypeID,FluidCategoryID),
Quantity int,
NurseNotes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDNurseFluids references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDNurseFluids default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDNurseFluids default getdate()
)
go
------------------------------------------------------------------------------------------------------------------------------------

exec uspEditOptions 'IPDNurseAlertDays', 30, '3NUM', 3, 0

------------------------------------------------------------------------------------------------------------------------------------

-----------19th-Oct-2016-----------------------------------------

alter table PurchaseOrderDetails
add PackID varchar(10) constraint fkPackIDPurchaseOrderDetails references LookupData (DataID)

alter table PurchaseOrderDetails add
PackSize int not null constraint dfPackSizePurchaseOrderDetails default 0

------------------------------------------------------------------------------------------------------------------------------------

------run data-----

update PurchaseOrderDetails set PackID= '179004' where PackID is null
update PurchaseOrderDetails set PackSize= 0 where PackSize is null

-----------19th-Oct-2016-----------------------------------------

alter table GoodsReceivedNoteDetails drop column VATPercentage

alter table GoodsReceivedNoteDetails
add PackID varchar(10) constraint fkPackIDGoodsReceivedNoteDetails references LookupData (DataID)

alter table GoodsReceivedNoteDetails
add PackSize int not null constraint dfPackSizeGoodsReceivedNoteDetails default 0


update GoodsReceivedNoteDetails set PackID= '179004' where PackID is null
update GoodsReceivedNoteDetails set PackSize= 0 where PackSize is null

------------------------------------------------------------------------------------------------------------------------------------

create table BankAccounts
(AccountNo Varchar(20)
constraint pkAccountNoBankAccounts primary key,
AccountName Varchar(40),
BankNameID Varchar(10)
constraint fkBankNameIDBankAccounts references LookupData (DataID),
CurrencyID Varchar(10)
constraint fkCurrencyIDBankAccounts references LookupData (DataID),
LoginID Varchar(20)
constraint fkLoginIDBankAccounts references Logins (LoginID),
ClientMachine Varchar(40),
RecordDateTime smalldatetime
)
go

------------------------------------------------------------------------------------------------------------------------------------

create table BankingRegister
(RegisterID int not null constraint dfRegisterIDBankingRegister default 1,
RegisterNo Varchar(20) not null
constraint pkRegisterNo primary key,
CollectionStartDate smalldatetime,
CollectionEndDate smalldatetime,
BankingDate smalldatetime,
BankNameID Varchar(10)
constraint fkBankNameIDBankingRegister references LookupData (DataID),
AccountName Varchar(20),
AccountNo Varchar(20)
constraint fkAccountNoBankingRegister references BankAccounts (AccountNo),
AmountCollected money,
AmountBanked money,
AmountInWords Varchar(800),
BankModesID Varchar(10)
constraint fkBankModesIDBankingRegister references LookupData (DataID),
CurrencyID Varchar(10)
constraint fkCurrencyIDIDBankingRegister references LookupData (DataID),
ExchangeRate  money,
BankedBy Varchar(40),
LoginID Varchar(20)
constraint fkLoginIDBankingRegister references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineBankingRegister default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeBankingRegister default getdate()
)
go

--------------------------------------------------20-oct-2016--------------------------------------------------------------------------------
alter table OtherIncome add
BranchID varchar(10) constraint fkBranchIDOtherIncome references LookupData (DataID)
go
Update OtherIncome SET BranchID ='177NA' where BranchID is null

alter table Accounts add
BranchID varchar(10) constraint fkBranchIDAccounts references LookupData (DataID)
go

Update Accounts SET BranchID ='177NA' where BranchID is null

alter table Refunds add
BranchID varchar(10) constraint fkBranchIDRefunds references LookupData (DataID)
go

Update Refunds SET BranchID ='177NA' where BranchID is null

alter table Expenditure add
BranchID varchar(10) constraint fkBranchIDExpenditure references LookupData (DataID)
go

Update Expenditure SET BranchID ='177NA' where BranchID is null

alter table Payments add
BranchID varchar(10) constraint fkBranchIDPayments references LookupData (DataID)
go

Update Payments SET BranchID ='177NA' where BranchID is null


exec uspEditOptions 'ForceSelfRequestVisitsToPayConsultation', 0, '3BIT', 1, 0


----- 11-Nov-2016-----------------------------------------------------------------------------------------------------------------------------------

-----Run Data first before running the lines below--------------------

exec sp_rename 'AssetRegister.ValuePerPc', 'Value', 'COLUMN'

Alter table AssetRegister add Photo Image,
AssetSourceID Varchar(10) constraint fkAssetSourceIDAssetRegister references LookupData (DataID),
InvoiceNo Varchar(20),InvoiceDate SmallDateTime,DateOfDelivery SmallDateTime,SalvageValue Int,
DepreciationRate Int,UsefulLife Int,DepreciationMethodID Varchar(10) constraint fkDepreciationMethodIDAssetRegister references LookupData (DataID),
DepreciationStartDate SmallDateTime,AssignedTo Varchar(200),Location Varchar(200),ServicingSchedule int
------------------------------------------------------------------------------------------------------------------------------------

UPDATE AssetRegister SET AssetSourceID ='185NA' where AssetSourceID is Null
UPDATE AssetRegister SET DepreciationMethodID ='186NA' where DepreciationMethodID is Null
------------------------------------------------------------------------------------------------------------------------------------


create table AssetMaintainanceLog
(SerialNo Varchar(20) constraint fkSerialNoAssetMaintainanceLog references AssetRegister (SerialNo),
ActionTaken Varchar(200),
MaintainanceDate SmallDateTime,constraint pkSerialNoMaintainanceDate primary key(SerialNo, MaintainanceDate),
MaintainedBy Varchar(200),
MaintainaceCost Money,
NextDue SmallDateTime,
LoginID varchar(20) constraint fkLoginIDAssetMaintainanceLog references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineAssetMaintainanceLog default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeAssetMaintainanceLog default getdate()
)
go

----------------------------------------22-NOV-2016-----------------------------------------------------------------------------
create table StaffLocations
(StaffLoginID Varchar(20) constraint fkStaffLoginIDStaffLocations references Logins (LoginID),
LocationID varchar(10) constraint fkLocationIDStaffLocations references LookupData (DataID),
StartDate smallDateTime, constraint pkStaffLoginIDLocationIDStartDate primary key(StaffLoginID, LocationID, StartDate),
Notes varchar(200),
LoginID varchar(20)constraint fkLoginIDStaffLocations references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineStaffLocations default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeStaffLocations default getdate()
)
go

---------------------------------------22 Nov 2016------------------------------------------------------------------

exec uspEditOptions 'EnableQueue', 0, '3BIT', 1, 0
exec uspEditOptions 'QueueReadCount', 3, '3NUM', 1, 0

------------------------------------------------------------------------------------------------------------------------------------

create table Queues
(TokenID int not null constraint dfTokenIDQueues default 1,
VisitNo Varchar(20) not null
constraint fkVisitNoQueues references Visits (VisitNo) on delete cascade on update cascade,
BranchID Varchar(10) not null
constraint fkBranchIDQueues references LookupData (DataID),
ServicePointID varchar(10) not null
constraint fkServicePointIDQueues references LookupData (DataID),
constraint pkVisitNoBranchIDServicePointID primary key(VisitNo, BranchID, ServicePointID),
TokenNo Varchar(20),
PriorityID Varchar(10)
constraint fkPriorityIDQueues references LookupData (DataID),
QueueStatus bit constraint dfQueueStatusQueues default 1,
LoginID Varchar(20)
constraint fkLoginIDQueues references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineQueues default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeQueues default getdate()
)
go
------------------------------------------------------------------------------------------------------------------------------------

create table QueuedMessages
(VisitNo Varchar(20)
constraint fkVisitNoQueuedMessages references Visits (VisitNo) on delete cascade on update cascade,
BranchID Varchar(10)
constraint fkBranchIDQueuedMessages references LookupData (DataID),
RoomNameID Varchar(200),
ServicePointID varchar(10)
constraint fkServicePointIDQueuedMessages references LookupData (DataID),
TokenNo Varchar(20),
constraint pkVisitNoBranchIDServicePointIDTokenNo primary key(VisitNo, BranchID, ServicePointID, TokenNo),
ReadCount int constraint dfReadCountQueuedMessages default 0,
LoginID Varchar(20)
constraint fkLoginIDQueuedMessages references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineQueuedMessages default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeQueuedMessages default getdate()
)
go

-----------------------------------------25-NOV-2016-----------------------------------------------------------------------------------------

exec uspEditOptions 'ClaimPaymentsAlertDays', 100, '3NUM', 3, 0

create table ClaimPayments
(ClaimNo varchar(20) not null
constraint fkClaimNoClaimPayments references Claims (ClaimNo)
constraint pkClaimNoClaimPayments primary key,
PayStatusID varchar(10)
constraint fkPayStatusIDClaimPayments references LookupData (DataID),
PaymentDateTime smallDatetime, 
constraint uqClaimNoPayStatusIDPaymentDateTime unique(ClaimNo, PayStatusID, PaymentDateTime),
LoginID varchar(20)
constraint fkLoginIDClaimPayments references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineClaimPayments default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeClaimPayments default getdate(),
) 
go

-------------------------------------25 Nov 2016------------------------------------------------------------------

alter table Accounts add ReferenceNo varchar(20)
go

Update Accounts SET ReferenceNo ='' WHERE ReferenceNo is null
go
------------------------------------------------------------------------------------------------------------------

-------------------------------------9 Dec 2016------------------------------------------------------------------

alter table Patients add XrayNumbers  Decimal(6,2),
PoliceNotified bit not null constraint dfPoliceNotified default 0,
InfectiousDiseasesNotified bit not null constraint dfInfectiousDiseasesNotified default 0,
MedicalConditions varchar(2000),ProvisionalDiagnosis varchar(2000)
go
------------------------------------------------------------------------------------------------------------------

-------------------------------------12 Dec 2016------------------------------------------------------------------
exec uspEditOptions 'IncomeSummariesSMSTime(2)', '8:31:00 AM', '3STR', 20, 0
go
------------------------------------------------------------------------------------------------------------------

update PurchaseOrderDetails set PackSize= 1 where PackSize is null or PackSize= 0
update GoodsReceivedNoteDetails set PackSize= 1 where PackSize is null or PackSize= 0



-------------------------------------14 Dec 2016------------------------------------------------------------------
exec uspEditOptions 'EnableSMSNotificationAtPharmacy', 0, '3BIT', 1, 0

-------------------------------------19 Dec 2016------------------------------------------------------------------

Alter table RadiologyExaminations add RadiologySiteID varchar(10) 
constraint fkRadiologySiteIDRadiologyExaminations references LookupData (DataID)
go

Update RadiologyExaminations SET RadiologySiteID ='19209' WHERE RadiologySiteID is null
go


-----------------------------------------------20 Dec 2016
alter table Inventory add UnitCost money
go


------------------------------------------------------------------------------------------------------------
sUPDATE Inventory Set UnitCost = dbo.GetItemUnitCost(ItemCategoryID, ItemCode) WHERE UnitCost is null	

------------------------------------------------------------------------------------------------------------

alter table Inventory add
BranchID varchar(10) constraint fkBranchIDInventory references LookupData (DataID)  -----check if in create table at integration and also utilities
go

Update Inventory SET BranchID ='177NA'
 where BranchID is null 
go

alter table Inventory
add WeightedCostAverage money
go


update Inventory set WeightedCostAverage=UnitCost 
where WeightedCostAverage is null

alter table ExtraBillItems add VATValue money default 0

update ExtraBillItems set VATValue=0 where VATValue is null

update PurchaseOrderDetails set PackSize= 1 where PackSize is null or PackSize=0
update GoodsReceivedNoteDetails set PackSize= 1 where PackSize is null or PackSize=0

alter table Expenditure add ExpenditureSourceTypeID varchar(10)
alter table Expenditure add AccountNo varchar(20)
alter table Expenditure add ExchangeRate money

update Expenditure set ExpenditureSourceTypeID='190CAS' where ExpenditureSourceTypeID is null
update Expenditure set ExchangeRate=1.00 where ExchangeRate is null


----------------------------------------------------------------------------------
--------------------------22-12-2016---------------------------------------------
----------------------------------------------------------------------------------

create table StaffPayments
(PaymentVoucherID int not null,
PaymentVoucherNo varchar(20) not null
constraint pkPaymentVoucherNo primary key,
VisitTypeID varchar(10) not null
constraint fkVisitTypeIDStaffPayments references LookupData (DataID),
StartDateTime SmallDateTime not null,
EndDateTime SmallDateTime not null,
BillModesID varchar(10) not null
constraint fkBillModesIDStaffPayments references LookupData (DataID),
StaffNo varchar(10) not null
constraint fkStaffNoStaffPayments references Staff (StaffNo),
VoucherStatusID varchar(10) not null
constraint fkVoucherStatusIDStaffPayments references LookupData (DataID),
LoginID varchar(20) not null
constraint fkLoginIDStaffPayments references Logins (LoginID),
ClientMachine Varchar(40) not null constraint dfClientMachineStaffPayments default Host_Name(),
RecordDateTime SmallDateTime not null constraint dfRecordDateTimeStaffPayments default GetDate()
)
go

create table StaffPaymentExt
(PaymentVoucherNo varchar(20)
constraint fkPaymentVoucherNoStaffPaymentExt references StaffPayments (PaymentVoucherNo)
constraint pkPaymentVoucherNoStaffPaymentExt primary key,
ApprovalDateTime SmallDateTime,
PayModeID varchar(10)
constraint fkPayModeIDStaffPaymentExt references LookupData (DataID),
DocumentNo varchar(20) not null,
CurrenciesID varchar(10)
constraint fkCurrenciesIDStaffPaymentExt references LookupData (DataID),
ExchangeRate money not null,
Amount money not null,
AmountWords varchar(400) not null,
ApprovalStatusID varchar(10)
constraint fkApprovalStatusIDStaffPaymentExt references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDStaffPaymentExt references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineStaffPaymentExt default Host_Name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeStaffPaymentExt default GetDate()
)
go


create table IPDStaffPaymentDetails
(PaymentVoucherNo varchar(20) not null
constraint fkPaymentVoucherNoIPDStaffPaymentDetails references StaffPayments (PaymentVoucherNo),
VisitNo varchar(20) not null constraint fkVisitNoIPDStaffPaymentDetails references Visits (VisitNo),
RoundNo varchar(20) not null,
ExtraBillNo varchar(20) not null,-- constraint fkExtraBillNoIPDStaffPaymentDetails references ExtraBillItems (ExtraBillNo),
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkExtraBillNoItemCodeItemCategoryIDIPDStaffPaymentDetails foreign key (ExtraBillNo, ItemCode, ItemCategoryID)
references ExtraBillItems (ExtraBillNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkOPDStaffPaymentDetailsPaymentVoucherNoVisitNoExtraBillNoItemCodeItemCategoryID primary key(PaymentVoucherNo, VisitNo, ExtraBillNo, ItemCode, ItemCategoryID),
Amount money not null,
ApprovalStatusID varchar(10) not null constraint fkApprovalStatusIDIPDStaffPaymentDetails references LookupData (DataID),
ApprovalNotes varchar(200),
LoginID varchar(20) not null constraint fkLoginIDIPDStaffPaymentDetails references Logins (LoginID),
ClientMachine Varchar(40) not null constraint dfClientMachineIPDStaffPaymentDetails default Host_Name(),
RecordDateTime SmallDateTime not null constraint dfRecordDateTimeIPDStaffPaymentDetails default GetDate()
)
go


create table OPDStaffPaymentDetails
(PaymentVoucherNo varchar(20) not null
constraint fkPaymentVoucherNoOPDStaffPaymentDetails references StaffPayments (PaymentVoucherNo),
VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDOPDStaffPaymentDetails foreign key (VisitNo, ItemCode, ItemCategoryID)
references Items (VisitNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkOPDStaffPaymentDetailsPaymentVoucherNoVisitNoItemCodeItemCategoryID primary key(PaymentVoucherNo, VisitNo, ItemCode, ItemCategoryID),
Amount money not null,
ApprovalStatusID varchar(10) not null constraint fkApprovalStatusIDOPDStaffPaymentDetails references LookupData (DataID),
ApprovalNotes varchar(200),
LoginID varchar(20) not null constraint fkLoginIDOPDStaffPaymentDetails references Logins (LoginID),
ClientMachine Varchar(40) not null constraint dfClientMachineOPDStaffPaymentDetails default host_Name(),
RecordDateTime SmallDateTime not null constraint dfRecordDateTimeOPDStaffPaymentDetails default GetDate()
)
go

----------------------------------------------------------------------------------
---------------Added update on Mon 7-01-2017 ------------------------------------
----------------------------------------------------------------------------------

---------------SearchQueries------------------------------------------------------

create table SearchQueries
(QueryName varchar(40) not null constraint pkQueryName primary key,
ObjectName varchar(40) constraint fkObjectNameSearchQueries references AccessObjects (ObjectName),
QueryData xml,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDSearchQueries references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineSearchQueries default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeSearchQueries default getdate()
)
go

----------------------------------------------------------------------------------
exec uspEditOptions 'AllowIssueStockOnLabRequest', 0, '3BIT', 1, 0

 
 ---------------Added update on friday 02-02-2017 ------------------------------------
----------------------------------------------------------------------------------
exec sp_rename 'StaffPaymentExt', 'StaffPaymentsExt'
exec sp_rename 'fkPaymentVoucherNoStaffPaymentExt', 'fkPaymentVoucherNoStaffPaymentsExt'
exec sp_rename 'pkPaymentVoucherNoStaffPaymentExt', 'pkPaymentVoucherNoStaffPaymentExt'
exec sp_rename 'fkPayModeIDStaffPaymentExt', 'fkPayModeIDStaffPaymentsExt'
exec sp_rename 'fkCurrenciesIDStaffPaymentExt', 'fkCurrenciesIDStaffPaymentsExt' 
exec sp_rename 'fkApprovalStatusIDStaffPaymentExt', 'fkApprovalStatusIDStaffPaymentsExt'
exec sp_rename 'fkLoginIDStaffPaymentExt', 'fkLoginIDStaffPaymentsExt'
exec sp_rename 'dfClientMachineStaffPaymentExt', 'dfClientMachineStaffPaymentsExt'
exec sp_rename 'dfRecordDateTimeStaffPaymentExt', 'dfRecordDateTimeStaffPaymentsExt'
---------------------------------------------------------------------------------- 
 
alter table  Queues drop  constraint fkVisitNoQueues
----------------------------------------------------------------------------------

alter table  Queues add  constraint fkVisitNoQueues  foreign key (VisitNo)
 references Visits (VisitNo) on delete cascade on update cascade

----------------------------------------------------------------------------------
-----------------Added 16th Feb 2017
----------------------------------------------------------------------------------

UPDATE Patients SET Phone = REPLACE( Phone, '/', ',' )

----------------------------------------------------------------------------------

ALTER table BulkMessaging add SendDateTime SmallDateTime

----------------------------------------------------------------------------------

UPDATE BulkMessaging SET SendDateTime = RecordDateTime where Phone =Phone and Message =Message and SendDateTime is null




exec uspEditOptions 'EnableUseOfInventoryPackSizes', 0, '3BIT', 1, 0
----------------------------------------------------------------------------------

alter table PurchaseOrderDetails add
VATValue decimal constraint dfPurchaseOrderDetailsVATValue default 0 

update PurchaseOrderDetails set VATValue=0 Where VATValue is null


delete from Options where OptionName ='TextMessageLifeSpan'

exec uspEditOptions 'SMSLifeSpanAppointments', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanCashier', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanVisits', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanRadiology', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanLab', '3', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanPatientReg', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanIncomeSummaries', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanManageACCs', '30', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanBirthDays', '5', '3NUM', 2, 0
exec uspEditOptions 'SMSLifeSpanPharmacy', '3', '3NUM', 2, 0


ALTER table BulkMessaging add TextLifeSpan int

----------------------------------------------------------------------------------

UPDATE BulkMessaging SET TextLifeSpan = 5 where Phone =Phone and Message =Message and TextLifeSpan is null

----------------------------------------------------------------------------------
exec uspEditOptions 'AllowCreateInvoicesAtCashPayments', 0, '3BIT', 1, 0

alter table Invoices add Locked bit constraint dfLockedInvoices default 0

update Invoices set Locked = 0 where Locked is null

exec uspEditOptions 'OtherItemsPrefix', 'A', '3STR', 1, 1


----------------------------------------------------------------------------------
create table OtherItems
(ItemID int not null constraint dfItemIDOtherItems default 1,
ItemCode Varchar(20) constraint pkItemCode primary key,
ItemName varchar(200),
ItemCategoryID varchar(10) constraint fkItemCategoryIDOtherItems references LookupData (DataID),
UnitCost Money,
Quantity int,
Details Varchar(1000),
LocationID Varchar(10) constraint fkLocationIDOtherItems references LookupData (DataID),
Hidden bit,
LoginID Varchar(20) constraint fkLoginIDOtherItems references Logins (LoginID),
RecordDateTime SmallDateTime constraint dfRecordDateTimeOtherItems default getdate(),
ClientMachine Varchar(41) constraint dfClientMachineOtherItems default host_name()
)
go


--21st March 2017

alter table BankingRegister add CollectionSourceTypeID varchar(10)

update BankingRegister set CollectionSourceTypeID =19301 where CollectionSourceTypeID is null

alter table BankingRegister drop column BankModesID

create table BankingRegisterDetails
(RegisterNo Varchar(20) not null
constraint fkRegisterNoBankingRegisterDetails references BankingRegister (RegisterNo),
CollectionModesID Varchar(10) not null
constraint fkCollectionModesIDBankingRegisterDetails references LookupData (DataID),
BankModesID varchar(10)
constraint fkBankModesIDBankingRegisterDetails references LookupData (DataID),
Amount money,
DocumentNo varchar(20),
constraint pkRegisterNoCollectionModesIDDocumentNo primary key(RegisterNo, CollectionModesID, DocumentNo),
LoginID Varchar(20)
constraint fkLoginIDBankingRegisterDetails references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineBankingRegisterDetails default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeBankingRegisterDetails default getdate()
)
go


create table BankPaymentDetails
(ReceiptNo varchar(10) not null
constraint pkReceiptNoBankPaymentDetails primary key,
BankNamesID varchar(10)
constraint fkBankNamesIDBankPaymentDetails references LookupData (DataID),
AccountNo varchar(20),
DocumentNo varchar(20),
PayModesID varchar(10)
constraint fkPayModesIDBankPaymentDetails references LookupData (DataID),
ClientMachine varchar(40) constraint dfClientMachineBankPaymentDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeBankPaymentDetails default getdate(),
LoginID varchar(20)
constraint fkLoginIDBankPaymentDetails references Logins (LoginID)
)
go


create table RefundDetails
(RefundNo Varchar(20) not null
constraint fkRefundNoRefundDetails references Refunds (RefundNo),
ReceiptNo Varchar(20) not null
constraint fkReceiptNoRefundDetails references Payments (ReceiptNo),
ItemCategoryID varchar(10) not null
constraint fkItemCategoryIDRefundDetails references LookupData (DataID),
ItemCode Varchar(20) not null,
constraint pkRefundNoReceiptNoItemCategoryIDItemCode primary key(RefundNo, ReceiptNo, ItemCategoryID, ItemCode),
Quantity int,
UnitPrice money,
ReturnReasonID varchar(10)
constraint fkReturnReasonIDRefundDetails references LookupData (DataID),
LoginID Varchar(20)
constraint fkLoginIDRefundDetails references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineRefundDetails default host_name(),
RecordDateTime SmalldateTime constraint dfRecordDateTimeRefundDetails default getdate()
)
go


exec uspEditOptions 'EnableCommentsAtPrintingLabReport', 1, '3BIT', 1, 0
exec uspEditOptions 'ForceFingerPrintOnSelfRequestLabReport', 0, '3BIT', 1, 0

----------------------------20/04/2017-----------------------------------
create table ReceiptInvoiceDetails
(InvoiceNo varchar(20),
ReceiptNo varchar(20),
constraint pkInvoiceNoReceiptNo primary key(InvoiceNo, ReceiptNo)
)
go


create table ExtraBillsINT
(ExtraBillNo varchar(20)
constraint pkExtraBills primary key,
SyncStatus varchar(20),
AgentID varchar(20),
RecordDateTime smalldatetime constraint dfRecordDateTimeExtraBillsINT default getdate()
)
go
--------------------------------------------------------------------------
--exec uspEditOptions 'EnableIntegrationN001', 1, '3BIT', 1, 0

alter table ExtraChargeItems add RevenueStreamCode  varchar(20)
alter table Services add RevenueStreamCode  varchar(20)

--------------------------26 April 2017----------------------------------------------

alter table Triage add MUAC decimal(5,2) constraint ckMUACTriage check (MUAC > 0 and MUAC < 150),
BMIStatusID varchar(10) constraint fkBMIStatusIDTriage references LookupData (DataID),
MUACStatusID varchar(10) constraint fkMUACStatusIDTriage references LookupData (DataID)
go


update Triage SET BMIStatusID ='30300',MUACStatusID='76N'  where BMIStatusID is null and
MUACStatusID is null



--- INTEGRATION TABLES

create table RevenueStreams
(RevenueStreamCode varchar(20) not null constraint pkRevenueStreamCode primary key,
Name varchar(40),
Hidden bit constraint dfHiddenRevenueStreams default 0,
RecordDateTime smalldatetime constraint dfRecordDateTimeRevenueStreams default getdate()
)
go


---------------------------03-05-2016-----------------------------------------------------

create table TBIntensifiedCaseFinding
(VisitNo varchar(20) not null constraint fkVisitNoTBIntensifiedCaseFinding references Visits (VisitNo) constraint pkVisitNoTBIntensifiedCaseFinding primary key,
CoughingTwoWeeksMoreID varchar(10) constraint fkCoughingTwoWeeksMoreIDTBIntensifiedCaseFinding references LookupData (DataID),
PersistantFeversID varchar(10) constraint fkPersistantFeversIDTBIntensifiedCaseFinding references LookupData (DataID),
NoticableWeightLossID varchar(10) constraint fkNoticableWeightLossIDTBIntensifiedCaseFinding references LookupData (DataID),
ExcessiveNightSweatsID varchar(10) constraint fkExcessiveNightSweatsIDTBIntensifiedCaseFinding references LookupData (DataID),
PoorWeightGainID varchar(10) constraint fkPoorWeightGainIDTBIntensifiedCaseFinding references LookupData (DataID),
PulmonaryTBChronicCoughContactID varchar(10) constraint fkPulmonaryTBChronicCoughContactIDTBIntensifiedCaseFinding references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDTBIntensifiedCaseFinding references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineTBIntensifiedCaseFinding default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeTBIntensifiedCaseFinding default getdate()
) 
go





---exec uspEditOptions 'AllowDrugsServiceFee', 0, '3BIT', 1, 1

---exec uspEditOptions 'ReceiptNoPrefix', '', '3STR', 10, 1

exec uspEditOptions 'ForcePatientAddress', 0, '3BIT', 1, 0

create table RejectedSpecimens
(SpecimenNo varchar(20)
constraint pkSpecimenNoRejectedSpecimens primary key,
VisitNo varchar(20),
RejectectionReasonID varchar(10)
constraint fkRejectectionReasonIDRejectedSpecimens references LookupData (DataID),
RejectionDate smalldatetime,
RejectedAt varchar(10),
RejectedBy varchar(40),
IsReAccepted bit,
LoginID varchar(20)
constraint fkLoginIDRejectedSpecimens references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRejectedSpecimens default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRejectedSpecimens default getdate()
)
go

----#######################

------------------------07 June 2017-----------------------------------------------


-----------------------------------------8th June 2017--------------------------------------------

exec uspEditOptions 'RestrictSelectionOfOnlyLoggedInDoctors', 0, '3BIT', 1, 0


----------------------------------------12 June 2017----------------------------------------------

create table Packages
(PackageNo varchar(20) not null constraint pkPackageNo primary key,
PackageName varchar(200),
UnitCost money,
UnitPrice money,
ExpiryDays int,
RevenueStreamCode varchar(20) constraint fkRevenueStreamCodePackages references RevenueStreams (RevenueStreamCode),
Hidden bit constraint dfHiddenPackages default 0,
MonitorQty bit constraint dfMonitorQtyPackages default 0,
LoginID varchar(20) constraint fkLoginIDPackages references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePackages default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimePackages default getdate()
)
go

--------------------------------------------------------------------------------------------------------
create table PackagesEXT
(PackageNo varchar(20) not null constraint fkPackageNoPackagesEXT references Packages (PackageNo),
ItemCode varchar(20),
ItemCategoryID varchar(10)constraint fkItemCategoryIDPackagesEXT references LookupData (DataID),
constraint pkPackageNoItemCodeItemCategoryID primary key(PackageNo, ItemCode, ItemCategoryID),
Quantity int,
LoginID varchar(20)
constraint fkLoginIDPackagesEXT references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachinePackagesEXT default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimePackagesEXT default getdate()
)
go

------------------------------------------------------------------------------------------------------------------
create table PackageDetails
(TransactionNo varchar(20) constraint fkTransactionNoPackageDetails references Payments (ReceiptNO) constraint pkTransactionNo primary key,
PackageNo varchar(20) constraint fkPackageNoPackageDetails references Packages (PackageNo),
PatientNo varchar(20) constraint fkPatientNoPackageDetails references Patients (PatientNo),
StatusID Varchar(10) constraint fkStatusIDPackageDetails references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDPackageDetails references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachinePackageDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePackageDetails default getdate()
)
go
-----------------------------------------------------------------------------------------------------
create table PackageConsumption
(VisitNo varchar(20) constraint fkVisitNoPackageConsumption references Visits (VisitNo),
ReceiptNo varchar(20) constraint fkReceiptNoPayments references Payments(ReceiptNo),
PackageNo varchar(20) constraint fkPackageNoPackageConsumption references Packages (PackageNo),
ItemCode varchar(20),
ItemCategoryID varchar(10) constraint fkItemCategoryIDPackageConsumption references LookupData (DataID),
constraint pkVisitNoPackageNoItemCodeItemCategoryID primary key(VisitNo, PackageNo, ItemCode, ItemCategoryID),
ItemStatusID varchar(10) constraint fkItemStatusIDPackageConsumption references LookupData (DataID),
Quantity int,
LoginID varchar(20),
ClientMachine varchar(41) constraint dfClientMachinePackageConsumption default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePackageConsumption default getdate()
)
go

------------------------------------------------------------------------------------------------------------------


exec uspEditOptions 'EnablePackages', 0, '3BIT', 1, 0



-----------------------------------19th June 2017----------------------------------------

----Alter table ResourcesINT drop constraint fkItemCategoryIDResourcesINT

----Alter table ResourcesINT drop constraint pkCodeItemCategoryID

----alter table ResourcesINT Alter column ItemCategoryID Varchar(20) not null

----alter table ResourcesINT
----add constraint pkCodeItemCategoryID primary key(Code, ItemCategoryID)


Alter table Admissions add ChartNumber Varchar(20)

 

create table LabTestsEXTPossibleResults
(TestCode varchar(20) constraint fkTestCodeLabTestsEXTPossibleResults references LabTests (TestCode),
SubTestCode varchar(20),
PossibleResults varchar(200), constraint pkTestCodeSubTestCodePossibleResults primary key(TestCode, SubTestCode, PossibleResults),
LoginID varchar(20) constraint fkLoginIDLabTestsEXTPossibleResults references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineLabTestsEXTPossibleResults default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeLabTestsEXTPossibleResults default getdate()
)
go

alter table PackageConsumption drop column TransactionNo

-----------------------------------30 June 2017----------------------------------------

create table DepositsINT
(TransNo varchar(20),
SyncStatus bit constraint dfSyncStatusDepositsINT default 0,
AgentID varchar(20), constraint pkTransNoAgentID primary key(TransNo, AgentID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDepositsINT default getdate()
)
go


alter table PackageDetailsINT drop  constraint pkTransactionNoAgentID

-----------------------------------20 July 2017----------------------------------------

create table AttachPackage
(VisitNo varchar(20) constraint fkVisitNoAttachPackage references Visits (VisitNo),
PackageNo varchar(20) constraint fkPackageNoAttachPackage references Packages (PackageNo),constraint pkVisitNoPackageNo primary key(VisitNo, PackageNo),
Details varchar(200),
LoginID varchar(20) constraint fkLoginIDAttachPackage references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineAttachPackage default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeAttachPackage default getdate()
)

exec uspEditOptions 'CategorizeVisitInvoiceDetailsByItemCategory', 0, '3BIT', 1, 0

go


alter table Packages Add MonitorQty bit constraint dfMonitorQtyPackages default 0

Update Packages set MonitorQty = 1 where MonitorQty is null

-----------------------------------------------1 August 2017------------------------------------------------------------------------------
create table IPDPackageConsumption
(ExtraBillNo varchar(20),
VisitNo varchar(20) constraint fkVisitNoIPDPackageConsumption references Visits (VisitNo),
PackageNo varchar(20) constraint fkPackageNoIPDPackageConsumption references Packages (PackageNo),
ItemCode varchar(20),
ItemCategoryID varchar(10) constraint fkItemCategoryIDIPDPackageConsumption references LookupData (DataID),
constraint pkExtraBillNoPackageNoItemCodeItemCategoryID primary key(ExtraBillNo, PackageNo, ItemCode, ItemCategoryID),
ItemStatusID varchar(10) constraint fkItemStatusIDIPDPackageConsumption references LookupData (DataID),
Quantity int,
LoginID varchar(20),
ClientMachine varchar(41) constraint dfClientMachineIPDPackageConsumption default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDPackageConsumption default getdate()
)
go
------------------------------------------------------------------------------------------------------------------------------------------
create table IPDCancerDiagnosis
(RoundNo varchar(20) constraint fkRoundNoIPDCancerDiagnosis references IPDDoctor (RoundNo),
DiseaseNo varchar(20) constraint fkDiseaseNoIPDCancerDiagnosis references CancerDiseases (DiseaseNo),
constraint pkRoundNoDiseaseNoIPDCancerDiagnosis primary key(RoundNo, DiseaseNo),
TopographicalNo varchar(20) constraint fkTopographicalNoIPDCancerDiagnosis references TopologySites (TopographicalNo),
BasisOfDiagnosisID varchar(10) constraint fkBasisOfDiagnosisIDIPDCancerDiagnosis references LookupData (DataID),
CancerStageID varchar(10) constraint fkCancerStageIDIPDCancerDiagnosis references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDIPDCancerDiagnosis references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineIPDCancerDiagnosis default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeIPDCancerDiagnosis default getdate()
)
go



---------------------------------------------------------------------------------------------------------------
alter table InventoryOrders
add OrderTypeID varchar(10)

alter table InventoryOrders
add StockCost money

update InventoryOrders set OrderTypeID='188IN' where OrderTypeID is null

alter table InventoryOrderDetails
add PackID varchar(10) 

alter table InventoryOrderDetails
add PackSize int constraint dfPackSizeInventoryOrderDetails default 1

alter table InventoryOrderDetails
add UnitCost money 

update InventoryOrderDetails set UnitCost=dbo.GetItemUnitCost(ItemCategoryID, ItemCode) 
where UnitCost is null

update InventoryOrderDetails set PackID= '177004' where PackID is null
update InventoryOrderDetails set PackSize= 1 where PackSize is null

---------------------------------------------------------------------------------------------------------------
alter table InventoryTransfers
add StockCost money 

alter table InventoryTransferDetails
add PackID varchar(10) 

alter table InventoryTransferDetails
add PackSize int constraint dfPackSizeInventoryTransferDetails default 1

alter table InventoryTransferDetails
add UnitCost money 

update InventoryTransferDetails set UnitCost=dbo.GetItemUnitCost(ItemCategoryID, ItemCode) 
where UnitCost is null

update InventoryTransferDetails set PackID= '177004' where PackID is null
update InventoryTransferDetails set PackSize= 1 where PackSize is null

----------------------------------------------------------------------------------------------------------------

declare @TransferNo varchar(20)
declare @StockCost money
DECLARE StockCost_Cursor INSENSITIVE CURSOR FOR

SELECT TransferNo FROM InventoryTransfers 
 
OPEN StockCost_Cursor
FETCH NEXT FROM StockCost_Cursor into @TransferNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
	  set @StockCost= (select sum(Packsize*Quantity*UnitCost)  FROM InventoryTransferDetails
       WHERE TransferNo= @TransferNo)
	   
	   UPDATE InventoryTransfers Set StockCost = @StockCost
		WHERE TransferNo= @TransferNo 	
		
		FETCH NEXT FROM StockCost_Cursor into @TransferNo
	END
CLOSE StockCost_Cursor
deallocate StockCost_Cursor
go
----------------------------------------------------------------------------------------------------------------------

declare @OrderNo varchar(20)
declare @StockCost money

DECLARE StockCost_Cursor INSENSITIVE CURSOR FOR

SELECT OrderNo FROM InventoryOrders 
 
OPEN StockCost_Cursor
FETCH NEXT FROM StockCost_Cursor into @OrderNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
	  set @StockCost= (select sum(Packsize*Quantity*UnitCost)  FROM InventoryOrderDetails
       WHERE OrderNo= @OrderNo)
	   
	   UPDATE InventoryOrders Set StockCost = @StockCost
		WHERE OrderNo= @OrderNo 	
		
		FETCH NEXT FROM StockCost_Cursor into @OrderNo
	END
CLOSE StockCost_Cursor
deallocate StockCost_Cursor
go

-----------------------------------------------------------------------------------------------------------------------
create table DeliveryNoteDetails
(TransferNo varchar(20) not null,
ItemCategoryID varchar(10) not null,
ItemCode varchar(20) not null,
constraint pkTransferNoItemCategoryIDItemCode primary key(TransferNo, ItemCategoryID, ItemCode),
PackID varchar(10)
constraint fkPackIDDeliveryNoteDetails references LookupData (DataID),
DeliveryDate smalldatetime,
PackSize int,
Quantity int,
UnitCost money,
LoginID varchar(20)
constraint fkLoginIDDeliveryNoteDetails references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDeliveryNoteDetails default getdate(),
ClientMachine varchar(40) constraint dfClientMachineDeliveryNoteDetails default host_name())
go

--------------------------------------------04-August-2017---------------------------------------------------------------------------------

create table AccountTransferDetails
(TranNo varchar(20) constraint fkTranNoAccountTransferDetails references Accounts (TranNo) constraint pkTranNoAccountTransferDetails primary key,
FromAccount varchar(20),
ToAccount varchar(20) constraint fkToAccountAccountTransferDetails references BillCustomers (AccountNo),
Amount money,
AmountInWords varchar(500),
Reason varchar(10) constraint fkReasonAccountTransferDetails references LookupData (DataID),
LoginID varchar(20)constraint fkLoginIDAccountTransferDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineAccountTransferDetails default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeAccountTransferDetails default getdate()
)
go

-------------------------------------------------------------------------------------------------------------------------------

exec uspInsertBillCustomers 'SUSP', 'SUSPENSE ACCOUNT', '18IND', '', '', '', '', '', '', '', null, '', '', '44NA', 0, 0, 0, 0, 0, 0, 0, 0, 1, '1A'


-------------------------------------------------------------------------------------------------------------------------------

exec uspEditOptions 'CategorizeBillFormPaymentDetails',1, '3BIT', 1, 0

alter table PackageDetails drop constraint pkTransactionNo

alter table PackageDetails drop constraint fkTransactionNoPackageDetails

alter table PackageDetails drop column TransactionNo


alter table PackageDetails add VisitNo varchar(20)
-----------------------------------------------------------------------------------------------------------

-----run as a block

declare @ReceiptNo varchar(20)
declare @VisitNo varchar(20)

DECLARE VisitNo_Cursor INSENSITIVE CURSOR FOR

select TransactionNo  FROM PackageDetails
 
OPEN VisitNo_Cursor
FETCH NEXT FROM VisitNo_Cursor into @ReceiptNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
	  set @VisitNo= (select PayNo  FROM Payments
       WHERE ReceiptNo= @ReceiptNo)
	   
	   UPDATE PackageDetails Set VisitNo = @VisitNo
		WHERE TransactionNo= @ReceiptNo 	
		
		FETCH NEXT FROM VisitNo_Cursor into @ReceiptNo
	END
CLOSE VisitNo_Cursor
deallocate VisitNo_Cursor
go

--alter table PackageDetails drop constraint fkVisitNoPackageDetails


alter table PackageDetails add constraint fkVisitNoPackageDetails foreign key (VisitNo)
references Visits (VisitNo) on delete cascade on update cascade 

--constraint pkVisitNo primary key

-- constraint pkVisitNo primary key


alter table PackageConsumption drop fkReceiptNoPayments

-------------------------------------------------------------------------------------------------------

alter table PackageConsumption add PackageVisitNo varchar(20)
-------------------------------------------------------------------------------------------------------

declare @ReceiptNo varchar(20)
declare @VisitNo varchar(20)

DECLARE VisitNo_Cursor INSENSITIVE CURSOR FOR

select ReceiptNo  FROM PackageConsumption
 
OPEN VisitNo_Cursor
FETCH NEXT FROM VisitNo_Cursor into @ReceiptNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
	  set @VisitNo= (select PayNo  FROM Payments
       WHERE ReceiptNo= @ReceiptNo)
	   
	   UPDATE PackageConsumption Set PackageVisitNo = @VisitNo
		WHERE ReceiptNo= @ReceiptNo 	
		
		FETCH NEXT FROM VisitNo_Cursor into @ReceiptNo
	END
CLOSE VisitNo_Cursor
deallocate VisitNo_Cursor
go
---------------------------------------------------------------------------------------------------------


----------------------------Run below after the above cursor --------------------------------------------

Update PackageConsumption set PackageVisitNo = VisitNo Where PackageVisitNo is null

-----------------Be carful the line below should only be ran after success to all the above--------------

alter table PackageConsumption drop column ReceiptNo

------------------------------------------14-August-2017---------------------------------------------------

alter table Payments add ClientFullName varchar(100)


---------------------------------------------------------------------------------------------------------

---This updates the Payments table with the corresponding Patient Names


Declare @PayNo varchar(20)
Declare @ReceiptNo varchar(20)
Declare @FullName varchar(100)

DECLARE ClientFullNameCreatorCUR INSENSITIVE CURSOR FOR

select PayNo,ReceiptNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName from Payments
inner join Visits on Payments.PayNo =Visits.VisitNo
inner join Patients on Visits.PatientNo=Patients.PatientNo WHERE ClientFullName is null

OPEN ClientFullNameCreatorCUR
	FETCH NEXT FROM ClientFullNameCreatorCUR INTO @PayNo,@ReceiptNo,@FullName
WHILE (@@FETCH_STATUS <> -1)
	 BEGIN 
			UPDATE Payments SET ClientFullName = @FullName
			WHERE PayNo = @PayNo AND ReceiptNo = @ReceiptNo
	
	FETCH NEXT FROM ClientFullNameCreatorCUR INTO @PayNo,@ReceiptNo,@FullName
	END
CLOSE ClientFullNameCreatorCUR
DEALLOCATE ClientFullNameCreatorCUR
go


---------------------------------------------------------------------------------------------------------

---This updates the Payments table with the corresponding  (Companies,INS,ACC) Names

Declare @AccountNo varchar(20)
Declare @ReceiptNo varchar(20)
Declare @BillCustomerName varchar(100)

DECLARE ClientFullNameCreatorCUR INSENSITIVE CURSOR FOR

select AccountNo,ReceiptNo,BillCustomerName from BillCustomers
inner join Payments on Payments.PayNo =BillCustomers.AccountNo
WHERE ClientFullName is null

OPEN ClientFullNameCreatorCUR
	FETCH NEXT FROM ClientFullNameCreatorCUR INTO @AccountNo,@ReceiptNo,@BillCustomerName
WHILE (@@FETCH_STATUS <> -1)
	 BEGIN 
			UPDATE Payments SET ClientFullName = @BillCustomerName
			WHERE PayNo = @AccountNo AND ReceiptNo = @ReceiptNo
	
	FETCH NEXT FROM ClientFullNameCreatorCUR INTO @AccountNo,@ReceiptNo,@BillCustomerName
	END
CLOSE ClientFullNameCreatorCUR
DEALLOCATE ClientFullNameCreatorCUR
go

------------------------------------------------------------------------------------------------------------------------

alter table Accounts add ClientFullName varchar(100)


---------------------------------------------------------------------------------------------------------

---This updates the Accounts table with the corresponding Patient Names


Declare @AccountBillNo varchar(20)
Declare @FullName varchar(100)

DECLARE ClientFullNameCreatorCUR INSENSITIVE CURSOR FOR

select AccountBillNo,dbo.GetFullName(LastName, MiddleName, FirstName) as FullName from Accounts
inner join Patients on Patients.PatientNo =Accounts.AccountBillNo WHERE ClientFullName is null

OPEN ClientFullNameCreatorCUR
	FETCH NEXT FROM ClientFullNameCreatorCUR INTO @AccountBillNo,@FullName
WHILE (@@FETCH_STATUS <> -1)
	 BEGIN 
			UPDATE Accounts SET ClientFullName = @FullName
			WHERE AccountBillNo = @AccountBillNo
	
	FETCH NEXT FROM ClientFullNameCreatorCUR INTO @AccountBillNo,@FullName
	END
CLOSE ClientFullNameCreatorCUR
DEALLOCATE ClientFullNameCreatorCUR
go


---------------------------------------------------------------------------------------------------------

---This updates the Accounts table with the corresponding BillCustomer Names


Declare @AccountBillNo varchar(20)
Declare @FullName varchar(100)

DECLARE ClientFullNameCreatorCUR INSENSITIVE CURSOR FOR

select AccountBillNo,BillCustomerName as FullName from Accounts
inner join BillCustomers on BillCustomers.AccountNo =Accounts.AccountBillNo WHERE ClientFullName is null

OPEN ClientFullNameCreatorCUR
	FETCH NEXT FROM ClientFullNameCreatorCUR INTO @AccountBillNo,@FullName
WHILE (@@FETCH_STATUS <> -1)
	 BEGIN 
			UPDATE Accounts SET ClientFullName = @FullName
			WHERE AccountBillNo = @AccountBillNo
	
	FETCH NEXT FROM ClientFullNameCreatorCUR INTO @AccountBillNo,@FullName
	END
CLOSE ClientFullNameCreatorCUR
DEALLOCATE ClientFullNameCreatorCUR
go

--------------------------------------------------21th-August-2017----------------------------------------------------------------------------------

create table IPDPathologyReports
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDPathologyReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDPathologyReports primary key(RoundNo, ItemCode, ItemCategoryID),
ReportTypeID varchar(10) constraint fkReportTypeIDIPDPathologyReports references LookupData (DataID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Diagnosis varchar(4000),
Pathologist varchar(10) constraint fkPathologistIPDPathologyReports references Staff (staffNo),
PathologyTitleID varchar(10) constraint fkPathologyTitleIDIPDPathologyReports references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDIPDPathologyReports references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineIPDPathologyReports default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDPathologyReports default getdate()
)
go

--------------------------------------25-08-2017-----------------------------------------------------------------

create table PrintDetails
(PatientNo varchar(20),
DocumentNo varchar(20),
PrintDesc varchar(200),
PrintCategoryID varchar(10) constraint fkPrintCategoryIDPrintDetails references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDPrintDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePrintDetails default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePrintDetails default getdate(),
constraint pkPatientNoPrintDescRecordDateTime primary key(PatientNo, PrintDesc, RecordDateTime)
)
go


exec uspEditOptions 'EnableMemberLimitBalanceTracking',0, '3BIT', 1, 0

Alter table ResearchRoutingForm add PatientNo varchar(20) 

------------------------------------25th. Sept. 2017---------------------------------------------------

create table RefundRequests
(RefundRequestID int constraint dfRefundRequestIDRefundRequests default 1,
RefundRequestNo varchar(20)
constraint pkRefundRequestNo primary key,
ReceiptNo varchar(20)
constraint fkReceiptNoRefundRequests references Payments (ReceiptNo),
RequestStatusID varchar(10)
constraint fkRequestStatusIDRefundRequests references LookupData (DataID),
ApprovalStatusID varchar(10) constraint fkApprovalStatusIDRefundRejects references LookupData (DataID),
RequestedBy varchar(41),
LoginID varchar(20)
constraint fkLoginIDRefundRequests references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineRefundRequests default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundRequests default getdate()
)
go

create table RefundRequestDetails
(RefundRequestNo varchar(20)
constraint fkRefundRequestNoRefundRequestDetails references RefundRequests (RefundRequestNo),
ItemCategoryID varchar(10)
constraint fkItemCategoryIDRefundRequestDetails references LookupData (DataID),
ItemCode varchar(20),
constraint pkRefundRequestNoItemCategoryIDItemCode primary key(RefundRequestNo, ItemCategoryID, ItemCode),
Quantity int,
UnitPrice money,
NewPrice money,
ReturnReasonID varchar(10)
constraint fkReturnReasonIDRefundRequestDetails references LookupData (DataID)
)
go

alter table Refunds Add RefundRequestNo varchar(20) constraint fkRefundRequestNoRefunds references RefundRequests(RefundRequestNo) 
go


create table RefundApprovals
(RefundRequestNo varchar(20)
constraint fkRefundRequestNoRefundApprovals references RefundRequests (RefundRequestNo)
constraint pkRefundRequestNoRefundApprovals primary key,
Notes varchar(800),
AttendingPersonel varchar(41),
ApprovalStatusID varchar(10) constraint fkApprovalStatusIDRefundApprovals references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDRefundApprovals references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundApprovals default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundApprovals default getdate()
)
go

create table RefundRejects
(RefundRequestNo varchar(20)
constraint fkRefundRequestNoRefundRejects references RefundRequests (RefundRequestNo)
constraint pkRefundRequestNoRefundRejects primary key,
ReceiptNo varchar(20)
constraint fkReceiptNoRefundRejects references Payments (ReceiptNo),
RejectedAt varchar(10)
constraint fkRejectedAtRefundRejects references LookupData (DataID),
RejectionDate smallDateTime,
Notes varchar(200),
LoginID varchar(20)
constraint fkLoginIDRefundRejects references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineRefundRejects default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeRefundRejects default getdate()
)
go

create table CreditNote
(CreditNoteID varchar(10) constraint dfCreditNoteIDCreditNote default 1,
CreditNoteNo varchar(20)
constraint pkCreditNoteNo primary key,
PayNo varchar(20),
InvoiceNo varchar(20)
constraint fkInvoiceNoCreditNote references Invoices (InvoiceNo),
EntryLevelID varchar(10) constraint fkEntryLevelIDCreditNote references LookupData(DataID),
CreditNoteDate smalldatetime,
Amount money,
LoginID varchar(20)
constraint fkLoginIDCreditNote references Logins (LoginID),
ClientMachine varchar(10) constraint dfClientMachineCreditNote default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCreditNote default getdate()
)
go

create table CreditNoteDetails
(CreditNoteNo varchar(20)
constraint fkCreditNoteCreditNoteNo references CreditNote(CreditNoteNo),
ItemCategoryID varchar(10),
ItemCode varchar(20),
constraint pkCreditNoteNoItemCategoryIDItemCode primary key(CreditNoteNo, ItemCategoryID, ItemCode),
Quantity int,
UnitPrice money,
ReturnReasonID varchar(10) constraint fkReturnReasonIDCreditNoteDetails references LookupData(DataID),
LoginID varchar(20)
constraint fkLoginIDCreditNoteDetails references Logins (LoginID),
ClientMachine varchar(10) constraint dfClientMachineCreditNoteDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCreditNoteDetails default getdate()
)
go

Alter table ReturnedExtraBillItems add EntryLevelID varchar(10) constraint fkEntryLevelIDReturnedExtraBillItems references LookupData(DataID)
go


update ReturnedExtraBillItems set EntryLevelID='201BFR' where EntryLevelID is null


Alter table ReturnedItems add EntryLevelID varchar(10) constraint fkEntryLevelIDReturnedItems references LookupData(DataID)



update ReturnedItems set EntryLevelID='201OPDR' where EntryLevelID is null

create table InventoryReturns
(ReturnID int constraint dfReturnIDInventoryReturns default 1,
ReturnNo varchar(20)
constraint pkReturnNo primary key,
BillNo varchar(20),
ReturnTypeID varchar(10)
constraint fkReturnTypeIDInventoryReturns references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDInventoryReturns references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineInventoryReturns default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeInventoryReturns default getdate()
)
go

Alter table ReturnedExtraBillItems add ReturnNo varchar(20)
Alter table ReturnedItems add ReturnNo varchar(20) 


update ReturnedExtraBillItems set ReturnNo=ExtraBillNo+'001' where ReturnNo is null
update ReturnedItems set ReturnNo=VisitNo+'001' where ReturnNo is null
go

alter table ReturnedExtraBillItems drop constraint pkExtraBillNoItemCodeItemCategoryIDReturnedExtraBillItems 
alter table ReturnedExtraBillItems alter column ReturnNo varchar(20) not null
alter table ReturnedExtraBillItems add constraint pkReturnNoExtraBillNoItemCodeItemCategoryIDReturnedExtraBillItems primary key(ReturnNo,ExtraBillNo, ItemCode, ItemCategoryID)
go

alter table ReturnedItems drop constraint pkVisitNoItemCodeItemCategoryIDReturnedItems 
alter table ReturnedItems alter column ReturnNo varchar(20) not null
alter table ReturnedItems add constraint pkReturnNoVisitNoItemCodeItemCategoryIDReturnedItems primary key(ReturnNo,VisitNo, ItemCode, ItemCategoryID)
go
------------------------------------------------------------------------------------------------------------------------------------------------------------
exec uspEditOptions 'GenerateInventoryInvoiceOnDispensingOnly', 0, '3BIT', 1, 0

---------------------------------------11-OCT-2017-------------------------------------------------------------------------------------------------------------------
create table SuspiciousLogins
(Username varchar(20),
Details varchar(200),
ClientMachine varchar(41) constraint dfClientMachineSuspiciousLogins default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeSuspiciousLogins default getdate()
)
go

------------Run Common -----------------------------

exec uspEditOptions 'DisableFinance', 0, '3BIT', 1, 0

exec uspEditOptions 'EnablePrintingInvoicesWithCompanyName', 0, '3BIT', 1, 0


--------------------------------------16th Oct 2017--------------------------------------------------------------

Alter table ConsumableItems add ConsumableCategoryID varchar(10) constraint fkConsumableCategoryIDConsumableItems references LookupData(DataID)

go

--------------------------------------19th Oct 2017--------------------------------------------------------------

Alter table Staff add 
CreatorClientMachine varchar(40) constraint dfCreatorClientMachineStaff default host_name(),
CreatorLoginID varchar(20) constraint fkCreatorLoginIDStaff references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeStaff default getdate(),
ClientMachine varchar(41) constraint dfClientMachineStaff default host_name()



Alter table Messenger drop constraint fkReceiverStaffNoMessenger

alter table Messenger
alter column ReceiverStaffNo varchar(20) not null


update Messenger set ReceiverStaffNo = dbo.GetStaffLoginID(ReceiverStaffNo)

update Messenger set ReceiverStaffNo ='Administrator' where ReceiverStaffNo=''


alter table Messenger
add constraint fkReceiverStaffNoMessenger foreign key (ReceiverStaffNo) 
references Logins (LoginID)

--------------------10 Nov 2017-------------------------------------

alter table ExternalReferrals add LabInvestigations varchar(2000)
go

alter table ExternalReferrals
alter column HistoryAndSymptoms varchar(2000)

alter table ExternalReferrals
alter column Diagnosis varchar(2000)

alter table ExternalReferrals
alter column TreatmentGiven varchar(2000)

alter table ExternalReferrals
alter column ReasonForReferral varchar(2000)


---------------------13th Nov 2017------------------------------

exec uspEditOptions 'ForceInventoryAcknowledgementBeforeOrdering', 0, '3BIT', 1, 0


create table MappedCodes
(AccountNo varchar(20) constraint fkAccountNoMappedCodes references BillCustomers (AccountNo),
ItemCode varchar(200),
ItemCategoryID varchar(10) constraint fkItemCategoryIDMappedCodes references LookupData (DataID),
CustomCode varchar(20),
LoginID varchar(20),
constraint pkAccountNoItemCodeItemCategoryIDLoginID primary key(AccountNo, ItemCode, ItemCategoryID, LoginID),
ClientMachine varchar(40) constraint dfClientMachineMappedCodes default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeMappedCodes default getdate()
)
go


exec uspEditOptions 'PrintItemCodesOnInvoices', 0, '3BIT', 1, 0

create table CreditNoteINT
(CreditNoteNo varchar(20) not null,
SyncStatus bit,
AgentID varchar(10),
constraint pkCreditNoteNoAgentID primary key(CreditNoteNo, AgentID),
RecordDateTime smalldatetime constraint dfRecordDateTimeCreditNoteINT default getdate()
)
go

create table CreditNoteDetailsINT
(CreditNoteNo varchar(20) not null,
ItemCategoryID varchar(10),
ItemCode varchar(20),
SyncStatus bit constraint dfSyncStatusCreditNoteDetailsINT default 0,
AgentID varchar(10),
constraint pkCreditNoteNoItemCategoryIDItemCodeAgentID primary key(CreditNoteNo, ItemCategoryID, ItemCode, AgentID),
RecordDateTime smalldatetime constraint dfRecordDateTimeCreditNoteDetailsINT default getdate())
go

alter table OtherItems add GroupsID varchar(10) constraint fkGroupsIDOtherItems references LookupData (DataID),
UnitMeasureID varchar(10) constraint fkUnitMeasureIDOtherItems references LookupData (DataID),
VATPercentage decimal constraint dfVATPercentageOtherItems default 0
go


Alter table OtherItems add BatchNo varchar(20) constraint dfBatchNoOtherItems default '',
ExpiryDate smalldatetime constraint dfExpiryDateOtherItems default '1 Jan 1900'



Alter table OtherItems drop constraint fkItemCategoryIDOtherItems
go

alter table OtherItems alter column ItemCategoryID varchar(20)

Alter table OtherItems add constraint
fkSubCategoryNoCOASubCategories foreign key (SubCategoryNo) 
references COASubCategories (SubCategoryNo)
go

----------------------------------30th Nov ---------------------------------------------------------------------



create table CardiologyExaminations
(ExamCode varchar(20) not null constraint pkCardiologyExamCode primary key,
ExamName varchar(200) constraint uqCardiologyExamName unique,
CardiologyCategoriesID varchar(10) constraint fkCardiologyCategoriesIDCardiologyExaminations references LookupData (DataID),
CardiologySiteID varchar(10) constraint fkCardiologySiteIDCardiologyExaminations references LookupData (DataID),
UnitPrice money,
VATPercentage decimal constraint dfVATPercentageCardiologyExaminations default 0,
Hidden bit constraint dfHiddenCardiologyExaminations default 0,

LoginID Varchar(20) constraint fkLoginIDCardiologyExaminations references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineCardiologyExaminations default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeCardiologyExaminations default getdate()

)
go

create table CardiologyReports
(VisitNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkVisitNoItemCodeItemCategoryIDCardiologyReports foreign key (VisitNo, ItemCode, ItemCategoryID) 
references Items (VisitNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkVisitNoItemCodeItemCategoryIDCardiologyReports primary key(VisitNo, ItemCode, ItemCategoryID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Report varchar(4000),
Conclusion varchar(4000),
Cardiologist varchar(10) constraint fkCardiologistCardiologyReports references Staff (StaffNo),
CardiologyTitleID varchar(10) constraint fkCardiologyTitleIDCardiologyReports references LookupData (DataID),

LoginID varchar(20) constraint fkLoginIDCardiologyReports references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineCardiologyReports default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCardiologyReports default getdate()
)
go

create table IPDCardiologyReports
(RoundNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null,
constraint fkRoundNoItemCodeItemCategoryIDIPDCardiologyReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete no action on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDCardiologyReports primary key(RoundNo, ItemCode, ItemCategoryID),
ExamDateTime smalldatetime,
Indication varchar(4000),
Report varchar(4000),
Conclusion varchar(4000),
Cardiologist varchar(10) constraint fkCardiologistIPDCardiologyReports references Staff (StaffNo),
CardiologyTitleID varchar(10) constraint fkCardiologyTitleIDIPDCardiologyReports references LookupData (DataID),

LoginID varchar(20) constraint fkLoginIDIPDCardiologyReports references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineIPDCardiologyReports default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeIPDCardiologyReports default getdate()

)
go


-----------------------------1st DEC 2017----------------------------------------------------
create table COACategories
(AccountTypeName varchar(10) constraint fkAccountTypeNameCOACategories references LookupData (DataID),
CategoryNo varchar(20) not null constraint pkCategoryNoCOACategories primary key,
CategoryName varchar(200),
LoginID varchar(20) constraint fkLoginIDCOACategories references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineCOACategories default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCOACategories default Getdate()
)
go


create table COASubCategories
(CategoryNo varchar(20) constraint fkCategoryNoCOASubCategories references COACategories (CategoryNo),
SubCategoryNo varchar(20) constraint pkSubCategoryNoCOASubCategories primary key,
SubCategoryName varchar(200),
LoginID varchar(20) constraint fkLoginIDCOASubCategories references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineCOASubCategories default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCOASubCategories default GetDate()
)
go

create table ChartItems
(ItemCode varchar(20) constraint pkItemCodeChartItems primary key,
ItemCategoryID varchar(10) constraint fkItemCategoryIDChartItems references LookupData (DataID),
SubCategoryNo varchar(20) constraint fkSubCategoryNoChartItems references COASubCategories (SubCategoryNo),
ItemName varchar(100),
LoginID varchar(20) constraint fkLoginIDChartItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineChartItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeChartItems default GetDate())
go


alter table AssetRegister drop fkAssetCategoryIDAssetRegister

alter table AssetRegister alter column AssetCategoryID varchar(20)

alter table BankAccounts add RevenueStream varchar(20) null


alter table Suppliers add RevenueStream varchar(20) null


Alter table Suppliers add 
LoginID varchar(20) constraint fkLoginIDSuppliers references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeSuppliers default getdate(),
ClientMachine varchar(41) constraint dfClientMachineSuppliers default host_name()


Alter table RadiologyExaminations add RevenueStream varchar(20)
go

Alter table RadiologyExaminations add 
LoginID varchar(20) constraint fkLoginIDRadiologyExaminations references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeRadiologyExaminations default getdate(),
ClientMachine varchar(41) constraint dfClientMachineRadiologyExaminations default host_name()


Alter table DentalServices add
RevenueStream varchar(20), 
LoginID varchar(20) constraint fkLoginIDDentalServices references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeDentalServices default getdate(),
ClientMachine varchar(41) constraint dfClientMachineDentalServices default host_name()
go


Alter table ICUServices add
RevenueStream varchar(20), 
LoginID varchar(20) constraint fkLoginIDICUServices references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeICUServices default getdate(),
ClientMachine varchar(41) constraint dfClientMachineICUServices default host_name()
go

Alter table Procedures add
RevenueStream varchar(20), 
LoginID varchar(20) constraint fkLoginIDProcedures references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeProcedures default getdate(),
ClientMachine varchar(41) constraint dfClientMachineProcedures default host_name()
go


Alter table Staff add RevenueStream varchar(20)
go


-------------------------------05- Dec 2017--------------------------------
create table ImmunisationVaccines
(ImmunisationID Int constraint dfImmunisationIDImmunisationVaccines default 1,
ImmunisationNo Varchar(20)
constraint pkImmunisationNo primary key,
PatientNo Varchar(20)
constraint fkPatientNoImmunisationVaccines references Patients (PatientNo),
VaccineName Varchar(10)
constraint fkVaccineNameImmunisationVaccines references LookupData (DataID),
VaccineReceived varchar(10)
constraint fkVaccineReceivedImmunisationVaccines references LookupData (DataID),
DateGiven smalldatetime,
PlaceReceived varchar(10)
constraint fkPlaceReceivedImmunisationVaccines references LookupData (DataID),
Notes varchar(100),
MothersName varchar(20),
LoginID Varchar(20)
constraint fkLoginIDImmunisationVaccines references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineImmunisationVaccines default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeImmunisationVaccines default getdate()
)
go

create table ChildNutrition
(VisitNo Varchar(20)
constraint fkVisitNoChildNutrition references Visits (VisitNo),
BreastFeeding Varchar(10)
constraint fkBreastFeedingChildNutrition references LookupData (DataID),
IfNoDetails Varchar(100),
ComplementaryFoods Varchar(10)
constraint fkComplementaryFoodsChildNutrition references LookupData (DataID),
ComplementaryFoodsDetails Varchar(100),
LoginID Varchar(20)
constraint fkLoginIDChildNutrition references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineChildNutrition default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeChildNutrition default getdate()
)
go

create table Antenatal
(PatientNo Varchar(20) constraint fkPatientNoAntenatal references Patients (PatientNo),
Infection Varchar(10) constraint fkInfectionAntenatal references LookupData (DataID),
InfectionDetails Varchar(100),
AccidentDuringPregnancy Varchar(10) constraint fkAccidentDuringPregnancyAntenatal references LookupData (DataID),
DetailsOfAccident Varchar(100),
UseOfDrugsOrPrescription Varchar(10) constraint fkUseOfDrugsOrPrescriptionAntenatal references LookupData (DataID),
DrugDetails Varchar(100),
Smoking Varchar(10) constraint fkSmokingAntenatal references LookupData (DataID),
ChronicIllness varchar(10) constraint fkChronicIllnessAntenatal references LookupData (DataID),
DetailsOfIllness varchar(100),
LoginID Varchar(20) constraint fkLoginIDAntenatal references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineAntenatal default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeAntenatal default getdate()
)
go

create table ChildDevelopment
(VisitNo Varchar(20)
constraint fkVisitNoChildDevelopment references Visits (VisitNo),
IsBabySmiling Varchar(10)
constraint fkIsBabySmilingChildDevelopment references LookupData (DataID),
Crawling Varchar(10)
constraint fkCrawlingChildDevelopment references LookupData (DataID),
Standing Varchar(10)
constraint fkStandingChildDevelopment references LookupData (DataID),
Sitting Varchar(10)
constraint fkSittingChildDevelopment references LookupData (DataID),
WeightGain Varchar(10)
constraint fkWeightGainChildDevelopment references LookupData (DataID),
SocialInteraction Varchar(100),
Sight Varchar(100),
HeightGain Varchar(10)
constraint fkHeightGainChildDevelopment references LookupData (DataID),
LoginID Varchar(20)
constraint fkLoginIDChildDevelopment references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineChildDevelopment default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeChildDevelopment default getdate()
)
go

create table Perinatal
(PatientNo Varchar(20) constraint fkPatientNoPerinatal references Patients (PatientNo),
ModeOfDelivery Varchar(10) constraint fkModeOfDeliveryPerinatal references LookupData (DataID),
DurationOfLabour Decimal,
DeliveryComplications Varchar(10) constraint fkDeliveryComplicationsPerinatal references LookupData (DataID),
AmountOfBloodLoss Decimal,
MothersCondition Varchar(10) constraint fkMothersConditionPerinatal references LookupData (DataID),
DetailsOfCondition Varchar(100),
BabyAlive Varchar(10) constraint fkBabyAlivePerinatal references LookupData (DataID),
CauseOfDeath Varchar(10) constraint fkCauseOfDeathPerinatal references LookupData (DataID),
LoginID Varchar(20) constraint fkLoginIDPerinatal references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePerinatal default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePerinatal default getdate()
)
go

create table Neonatal
(PatientNo Varchar(20)
constraint fkPatientNoNeonatal references Patients (PatientNo),
GestationalStage Varchar(10)
constraint fkGestationalStageNeonatal references LookupData (DataID),
Sex Varchar(10)
constraint fkSexNeonatal references LookupData (DataID),
BirthWeight Decimal,
WeighedWithin72hrs varchar(10)
constraint fkWeighedWithin72hrsNeonatal references LookupData (DataID),
ConditionOnBirth Varchar(10)
constraint fkConditionOnBirthNeonatal references LookupData (DataID),
ConditionDetails Varchar(10)
constraint fkConditionDetailsNeonatal references LookupData (DataID),
PhysicalAbnormalityDetails Varchar(100),
UmblicalCordDetails Varchar(10)
constraint fkUmblicalCordDetailsNeonatal references LookupData (DataID),
Jaundice Varchar(10)
constraint fkJaundiceNeonatal references LookupData (DataID),
Bleeding Varchar(10)
constraint fkBleedingNeonatal references LookupData (DataID),
EarlyInfection Varchar(10)
constraint fkEarlyInfectionNeonatal references LookupData (DataID),
InfectionDetails Varchar(100),
Convulsions Varchar(10)
constraint fkConvulsionsNeonatal references LookupData (DataID),
ConvulsionsDetails Varchar(100),
EIDResults Varchar(10)
constraint fkEIDResultsNeonatal references LookupData (DataID),
ApgarScore Int,
SleepingHabits Varchar(100),
LoginID Varchar(20)
constraint fkLoginIDNeonatal references Logins (LoginID),
ClientMachine Varchar(40),
RecordDateTime SmallDateTime
)
go

create table ObstetricHistory
(PatientNo Varchar(20) constraint fkPatientNoObstetricHistory references Patients (PatientNo),
Gravidity int,
Parity int,
NoOfSurvivingChildren int,
LMP SmallDateTime,
EDD SmallDateTime,
GestationalAgeInWks int,
StillBirth Varchar(10) constraint fkStillBirthObstetricHistory references LookupData (DataID),
NoOfStillBirths int,
Abortions Varchar(10) constraint fkAbortionsObstetricHistory references LookupData (DataID),
NoOfAbortions int,
Caesarian Varchar(10) constraint fkCaesarianObstetricHistory references LookupData (DataID),
NoOfCaesarians int,
LoginID Varchar(20) constraint fkLoginIDObstetricHistory references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineObstetricHistory default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeObstetricHistory default getdate()
)
go




exec uspEditOptions 'AllowAccountReceiptsRefunds', 0, '3BIT', 1, 1
go

Alter table RefundRequests add 
VisitNo varchar(20) constraint fkVisitNoRefundRequests references Visits (VisitNo)
go
-----------------------------------------------------------------------------------------
---------------run as block-------------------------------------------------------------

Declare @ReceiptNo varchar(20)

DECLARE UpdateRefundRequestVisitNo INSENSITIVE CURSOR FOR

select ReceiptNo from RefundRequests

OPEN UpdateRefundRequestVisitNo
	FETCH NEXT FROM UpdateRefundRequestVisitNo INTO @ReceiptNo
WHILE (@@FETCH_STATUS <> -1)
	 BEGIN 
			UPDATE RefundRequests SET VisitNo = dbo.GetRefundVisitNo(@ReceiptNo)
			WHERE VisitNo is null
	
	FETCH NEXT FROM UpdateRefundRequestVisitNo INTO @ReceiptNo
	END
CLOSE UpdateRefundRequestVisitNo
DEALLOCATE UpdateRefundRequestVisitNo
go

Alter table Patients add 
CommunityID varchar(10) constraint fkComnunityIDPatients references LookupData (DataID)
go

Alter table Visits add 
CommunityID varchar(10) constraint fkComnunityIDVisits references LookupData (DataID)
go

--- exec uspEditOptions 'ClosePendingItemsAfterVisitClosed', 0, '3BIT', 1, 0
--- go





-------------------------------------------------------------------------------------------------------------------------------------------------
Alter table GoodsReceivedNoteDetails add PayStatusID varchar(10) constraint fkPayStatusIDGoodsReceivedNoteDetails references LookupData (DataID)
go

update GoodsReceivedNoteDetails set PayStatusID= '12NP' where PayStatusID is null

------------------------------------------------------------------------------------------------------------------------------------------------

create table PaymentVouchers
(VoucherID int not null constraint dfVoucherID default 1,
VoucherNo varchar(20) constraint pkVoucherNo primary key,
PayTypeID varchar(10) constraint fkPayTypeIDPaymentVouchers references LookupData (DataID),
BillNo varchar(20),
PayDate smallDateTime,
PayModesID varchar(10) constraint fkPayModesIDPaymentVouchers references LookupData (DataID),
DocumentNo varchar(20),
AmountWords varchar(200),
Notes varchar(200),
CurrenciesID varchar(10) constraint fkCurrenciesIDPaymentVouchers references LookupData (DataID),
AmountTendered Money,
ExchangeRate money,
Change Money,
SendBalanceToAccount bit constraint dfSendBalanceToAccountPaymentVouchers default 0,
UseAccountBalance bit constraint dfUseAccountBalancePaymentVouchers default 0,
VoucherTypeID varchar(10) constraint fkVoucherTypeIDPaymentVouchers references LookupData (DataID),
PayNo varchar(20),
FilterNo varchar(20),
Payee varchar(200),
LoginID varchar(20) constraint fkLoginIDPaymentVouchers references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachinePaymentVouchers default Host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimePaymentVouchers default GetDate()
)
go


create table PaymentVoucherDetails
(VoucherNo varchar(20) constraint fkVoucherNoPaymentVoucherDetails references PaymentVouchers (VoucherNo),
BillNo varchar(20),
ItemCode varchar(20),
ItemCategoryID varchar(10) constraint fkItemCategoryIDPaymentVoucherDetails references LookupData (DataID),
constraint pkVoucherNoBillNoItemCodeItemCategoryID primary key(VoucherNo, BillNo, ItemCode, ItemCategoryID),
Quantity int,
UnitPrice money,
Discount money,
Amount money,
LoginID Varchar(20) constraint fkLoginIDPaymentVoucherDetails references Logins (LoginID),
ClientMachine Varchar(41) constraint dfClientMachinePaymentVoucherDetails default Host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimePaymentVoucherDetails default GetDate()
)
go

create table ServiceInvoices
(ServiceInvoiceID int not null constraint dfServiceInvoiceIDServiceInvoices default 1,
ServiceInvoiceNo varchar(20) not null constraint pkServiceInvoiceNoServiceInvoices primary key,
InvoiceDate smalldatetime,
DocumentNo varchar(20),
SupplierNo varchar(20) constraint fkSupplierNoServiceInvoices references Suppliers (SupplierNo),
ShipAddress varchar(300),
LoginID varchar(20) constraint fkLoginIDServiceInvoices references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServiceInvoices default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServiceInvoices default getdate()
)
go

create table ServiceInvoiceDetails
(ServiceInvoiceNo varchar(20) not null constraint fkServiceInvoiceNoServiceInvoiceDetails 
references ServiceInvoices (ServiceInvoiceNo)on delete cascade on update cascade,
ItemCategoryID varchar(10) not null constraint fkItemCategoryIDServiceInvoiceDetails references LookupData (DataID),
ItemCode varchar(20) not null,
constraint pkServiceInvoiceNoItemCategoryIDItemCodeServiceInvoiceDetails primary key(ServiceInvoiceNo, ItemCategoryID, ItemCode),
ItemName varchar(800) not null,
constraint uqServiceInvoiceNoItemCategoryIDItemName unique(ServiceInvoiceNo, ItemCategoryID, ItemName),
UnitMeasure varchar(100),
ItemGroup varchar(100),
PackID varchar(10) not null constraint fkPackIDServiceInvoiceDetails references LookupData (DataID),
PackSize int constraint dfPackSizeServiceInvoiceDetails default 1,
Quantity int,
Rate money,
Amount money,
VATValue money constraint dfVATValueServiceInvoiceDetails default 0,
Notes varchar(200),
PayStatusID varchar(10) constraint fkPayStatusIDServiceInvoiceDetails references LookupData (DataID),
LoginID varchar(20)constraint fkLoginIDServiceInvoiceDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServiceInvoiceDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServiceInvoiceDetails default getdate()
)
go

-----------------------------------------------------------------------------------
---------------Added update on Thue 28-12-2017 ------------------------------------
-----------------------------------------------------------------------------------

exec uspEditOptions 'AllowUserSaveLoginPassword', 0, '3BIT', 1, 0
exec uspEditOptions 'PasswordComplexity', 'M', '3STR', 10, 1

-----------------------------------------------------------------------------------

alter table Patients
alter column Occupation varchar(100)
go
-----------------------------------------------------------------------------------

CREATE INDEX indexLookupData
ON LookupData (LookupOrder,ObjectID, DataID,DataDes)
go
-----------------------------------------------------------------------------------

alter table  OtherItems drop  constraint fkSubCategoryNoCOASubCategories


-----------------------------------------------------------------------------------
---------------Added update on Thue 22-01-2018 ------------------------------------
-----------------------------------------------------------------------------------

Alter table services add 
ServiceId int not null constraint dfserviceidservices default 1
go

Alter table dentalservices add 
DentalId int not null constraint dfdentaliddentalservices default 1
go

Alter table opticalservices add 
OpticalId int not null constraint dfopticalidopticalservices default 1
go

Alter table eyeservices add 
EyeId int not null constraint dfeyeideyeservices default 1
go

Alter table icuservices add 
IcuId int not null constraint dficuidicuservices default 1
go

Alter table theatreservices add 
TheatreId int not null constraint dftheatreidtheatreservices default 1
go

Alter table maternityservices add 
MaternityId int not null constraint dfmaternityidmaternityservices default 1
go

Alter table drugs add 
DrugId int not null constraint dfdrugiddrugs default 1
go

Alter table consumableitems add 
ConsumableId int not null constraint dfconsumableidconsumables default 1
go

Alter table extrachargeitems add 
ExtraItemId int not null constraint dfextraitemidextrachargeitems default 1
go


Alter table procedures add 
ProcedureId int not null constraint dfprocedureidprocedures default 1
go

Alter table packages add 
PackageId int not null constraint dfpackageidpackages default 1
go

Alter table labtests add 
TestId int not null constraint dftestidlabtests default 1
go

Alter table beds add 
BedId int not null constraint dfbedidbeds default 1
go


Alter table radiologyexaminations add 
ExamId int not null constraint dfexamidradiologyexaminations default 1

go

Alter table cardiologyexaminations add 
ExamId int not null constraint dfexamidcardiologyexaminations default 1
go

Alter table pathologyexaminations add 
ExamId int not null constraint dfexamidpathologyexaminations default 1

go



-------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------25 jan 18-------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------

begin
declare @autoid int
set @autoid = 0
update services set @autoid = serviceid = @autoid + 1 where serviceid is null
end
go

-- dentalservices
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update dentalservices set @autoid = dentalid = @autoid + 1 where dentalid is null
end
go

-- opticalservices
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update opticalservices set @autoid = opticalid = @autoid + 1 where opticalid is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- eyeservices
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update eyeservices set @autoid = eyeid = @autoid + 1 where eyeid is null

end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- icuservices
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update icuservices set @autoid = icuid = @autoid + 1 where icuid is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- theatreservices
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update theatreservices set @autoid = theatreid = @autoid + 1 where theatreid is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- maternityservices
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update maternityservices set @autoid = maternityid = @autoid + 1 where maternityid is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- drugs
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update drugs set @autoid = drugid = @autoid + 1 where DrugID is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- consumableitems
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update consumableitems set @autoid = consumableid = @autoid + 1 where consumableid is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- extrachargeitems
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update extrachargeitems set @autoid = extraitemid = @autoid + 1 where extraitemid is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- procedures
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update procedures set @autoid = procedureid = @autoid + 1 where procedureid is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- packages
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update packages set @autoid = packageid = @autoid + 1 where packageid is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- labtests
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update labtests set @autoid = TestID = @autoid + 1 where TestID is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- beds
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update beds set @autoid = bedid = @autoid + 1 where BedID is null
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- radiologyexaminations
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update radiologyexaminations set @autoid = examid = @autoid + 1
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- cardiologyexaminations
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update cardiologyexaminations set @autoid = examid = @autoid + 1
end
go

---------------------------------------------------------------------------------------------------------------------------------------------------
-- pathologyexaminations
---------------------------------------------------------------------------------------------------------------------------------------------------
begin
declare @autoid int
set @autoid = 0
update pathologyexaminations set @autoid = examid = @autoid + 1
end
go
---------------------------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------------------------

Begin
exec uspEditOptions 'ServiceCodePrefix', 'SER', '3STR', 20, 1
exec uspEditOptions 'DentalCodePrefix', 'DEN', '3STR', 20, 1
exec uspEditOptions 'OpticalCodePrefix', 'OPT', '3STR', 20, 1
exec uspEditOptions 'EyeCodePrefix', 'EYE', '3STR', 20, 1
exec uspEditOptions 'ICUCodePrefix', 'ICU', '3STR', 20, 1
exec uspEditOptions 'TheatreCodePrefix', 'THE', '3STR', 20, 1
exec uspEditOptions 'MaternityCodePrefix', 'MAT', '3STR', 20, 1
exec uspEditOptions 'ExtraItemCodePrefix', 'EXT', '3STR', 20, 1
exec uspEditOptions 'PackageNoPrefix', 'PAC', '3STR', 20, 1
exec uspEditOptions 'ProcedureCodePrefix', 'PRO', '3STR', 20, 1
exec uspEditOptions 'TestCodePrefix', 'LAB', '3STR', 20, 1
exec uspEditOptions 'BedNoPrefix', 'BED', '3STR', 20, 1
exec uspEditOptions 'CardiologyExamCodePrefix', 'CAR', '3STR', 20, 1
exec uspEditOptions 'RadiologyExamCodePrefix', 'RAD', '3STR', 20, 1
exec uspEditOptions 'PathologyExamCodePrefix', 'PAT', '3STR', 20, 1

exec uspEditOptions 'DrugNoPrefix', 'DRG', '3STR', 20, 1
exec uspEditOptions 'OtherItemsPrefix', 'OTH', '3STR', 20, 1
exec uspEditOptions 'ConsumableNoPrefix', 'CON', '3STR', 20, 1
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
exec uspEditOptions 'RequisitionNoPrefix', 'REQ', '3STR', 20, 1
exec uspEditOptions 'RequisitionApprovalNoPrefix', 'APP', '3STR', 20, 1
exec uspEditOptions 'RequisitionPaymentNoPrefix', 'PAY', '3STR', 20, 1
End
Go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Begin
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'Services' and AutoColumnName = 'ServiceCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'DentalServices' and AutoColumnName = 'DentalCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'OpticalServices' and AutoColumnName = 'OpticalCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'EyeServices' and AutoColumnName = 'EyeCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'ICUServices' and AutoColumnName = 'ICUCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'TheatreServices' and AutoColumnName = 'TheatreCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'MaternityServices' and AutoColumnName = 'MaternityCode'
Update AutoNumbers set AutoColumnLEN = '7', PaddingLEN = '4', SeparatorPositions ='3' where ObjectName= 'Drugs' and AutoColumnName = 'DrugNo'
Update AutoNumbers set AutoColumnLEN = '7', PaddingLEN = '4', SeparatorPositions ='3' where ObjectName= 'OtherItems' and AutoColumnName = 'ItemCode'
Update AutoNumbers set AutoColumnLEN = '7', PaddingLEN = '4', SeparatorPositions ='3' where ObjectName= 'ConsumableItems' and AutoColumnName = 'ConsumableNo'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'ExtraChargeItems' and AutoColumnName = 'ExtraItemCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'LabTests' and AutoColumnName = 'TestCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'Procedures' and AutoColumnName = 'ProcedureCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'Packages' and AutoColumnName = 'PackageNo'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'Beds' and AutoColumnName = 'BedNo'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'RadiologyExaminations' and AutoColumnName = 'ExamCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'CardiologyExaminations' and AutoColumnName = 'ExamCode'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'PathologyExaminations' and AutoColumnName = 'ExamCode'
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'Requisitions' and AutoColumnName = 'RequisitionNo'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'RequisitionApprovals' and AutoColumnName = 'ApprovalNo'
Update AutoNumbers set AutoColumnLEN = '6', PaddingLEN = '3', SeparatorPositions ='3' where ObjectName= 'RequisitionPayments' and AutoColumnName = 'PaymentNo'
End
go
------------------------------------01 Feb 2018-------------------------------------
exec uspEditOptions 'ImmunisationNoPrefix', 'I', '3STR', 1, 1
go

alter table ImmunisationVaccines 
add UpToDate bit

create table ChildGrowth
(VisitNo Varchar(20) not null constraint fkVisitNoChildGrowth references Visits (VisitNo)
on delete cascade on update cascade,
SocialSmile bit,
HeadControl bit,
ReactionToSound bit,
GraspReflex bit,
Sitting bit,
Standing bit,
WeightForAge Varchar(10) constraint fkWeightForAgeChildGrowth references LookupData (DataID),
HeightForAge Varchar(10) constraint fkHeightForAgeChildGrowth references LookupData (DataID),
WeightForHeight Varchar(10) constraint fkWeightForHeightChildGrowth references LookupData (DataID),
BreastFeedingID varchar(10) constraint fkBreastFeedingIDChildGrowth references LookupData (DataID),
Notes varchar(200),
LoginID Varchar(20) constraint fkLoginIDChildGrowth references Logins (LoginID),
ClientMachine Varchar(41) constraint dfClientMachineChildGrowth default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeChildGrowth default getdate()
)
go

alter table Antenatal drop fkPatientNoAntenatal

Alter table Antenatal add 
VisitNo Varchar(20) constraint fkVisitNoAntenatal references Visits (VisitNo)
go

alter table Perinatal drop fkPatientNoPerinatal

Alter table Perinatal add 
VisitNo Varchar(20) constraint fkVisitNoPerinatal references Visits (VisitNo)
go

create table PostNatal
(PatientNo Varchar(20) not null constraint fkPatientNoPostNatal references Patients (PatientNo)
on delete cascade on update cascade,
DeliveryComplications varchar(10) constraint fkDeliveryComplicationsPostNatal references LookupData (DataID),
ConditionOnBirth varchar(10) constraint fkConditionOnBirthPostNatal references LookupData (DataID),
ConditionDetails varchar(100),
PhysicalAbnormalityDetails varchar(100),
UmblicalCordDetails varchar(100),
Jaundice varchar(10) constraint fkJaundicePostNatal references LookupData (DataID),
EarlyInfection varchar(10) constraint fkEarlyInfectionPostNatal references LookupData (DataID),
InfectionDetails varchar(100),
Convulsions varchar(10) constraint fkConvulsionsPostNatal references LookupData (DataID),
ConvulsionsDetails varchar(100),
EIDResults varchar(10) constraint fkEIDResultsPostNatal references LookupData (DataID),
ApgarScore int,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDPostNatal references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachinePostNatal default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePostNatal default getdate()
)
go

alter table QueuedMessages drop constraint pkVisitNoBranchIDServicePointIDTokenNo
go

--- Don't worry deleting from this table. QueuedMessages can be deleted and this have no effect
delete from QueuedMessages
go

alter table QueuedMessages add constraint pkVisitNoBranchIDServicePointIDQueuedMessages primary key(VisitNo, BranchID, ServicePointID)
go

-----------------------22 Feb 2018 Physiotherapy------------------------------------------
create table TreatmentPlan
(VisitNo Varchar(20)
constraint fkVisitNoTreatmentPlan references Visits (VisitNo),
CategoryID Varchar(10)
constraint fkCategoryIDTreatmentPlan references LookupData (DataID),
TherapyTechniqueID Varchar(10)
constraint fkTherapyTechniqueIDTreatmentPlan references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20)
constraint fkLoginIDTreatmentPlan references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineTreatmentPlan default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeTreatmentPlan default getdate()
)
go

create table PhysioDiseases
(DiseaseID int constraint dfDiseaseIDPhysioDiseases default 0,
PhysioDiseaseNo varchar(20)
constraint pkPhysioDiseaseNo primary key,
DiseaseCode varchar(10),
DiseaseName varchar(200),
PhysioDiseaseCategoriesID varchar(10)
constraint fkPhysioDiseaseCategoriesIDPhysioDiseases references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDPhysioDiseases references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePhysioDiseases default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePhysioDiseases default getdate()
)
go

create table PhysioDiagnosis
(VisitNo Varchar(20)
constraint fkVisitNoPhysioDiagnosis references Visits (VisitNo),
PhysioDiseaseNo varchar(20) constraint fkPhysioDiseaseNoPhysioDiseases references PhysioDiseases (PhysioDiseaseNo),
constraint pkVisitNoPhysioDiseaseNo primary key(VisitNo, PhysioDiseaseNo),
Notes Varchar(200),
LoginID varchar(20)
constraint fkLoginIDPhysioDiagnosis references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachinePhysioDiagnosis default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePhysioDiagnosis default getdate()
)
go


create table Physiotherapy
(VisitNo Varchar(20) constraint fkVisitNoPhysiotherapy references Visits (VisitNo),
OnMedication Varchar(10) constraint fkOnMedicationPhysiotherapy references LookupData (DataID),
Medication Varchar(100),
Pain24hoursOrVAS Varchar(10) constraint fkPain24hoursOrVASPhysiotherapy references LookupData (DataID),
LevelOfDependenceOrADLS Varchar(10) constraint fkLevelOfDependenceOrADLSPhysiotherapy references LookupData (DataID),
MuscleStatus varchar(100),
StatusOfJoints Varchar(50),
Sensitivity varchar(100),
WalkingAnalysis varchar(100),
ShortTermTreatmentTargets varchar(100),
LongTermTreatmentTargets varchar(100),
ProvisionalDiagnosis varchar(100),
LoginID Varchar(20) constraint fkLoginIDPhysiotherapy references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePhysiotherapy default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimePhysiotherapy default getdate()
)
go

------------------------------------------------------------------------------------------------------

exec uspEditOptions 'EnablePrintInvoiceDetailesCheck', 0, '3BIT', 1, 0
go


---------------------------------------------------------------------------------
---------------Added update on Thur 15-02-18 By Wilson --------------------------
---------------------------------------------------------------------------------

----------- ServicesSpecialtyBillCustomFee ---------------------------------------

create table ServicesSpecialtyBillCustomFee
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesSpecialtyBillCustomFee 
references Services (ServiceCode) on delete cascade on update cascade,
DoctorSpecialtyID varchar(10) not null constraint fkDoctorSpecialtyIDServicesSpecialtyBillCustomFee references LookupData (DataID),
AccountNo varchar(20) not null constraint fkAccountNoServicesSpecialtyBillCustomFee 
references BillCustomers (AccountNo) on delete cascade on update cascade,
constraint pkServiceCodeDoctorSpecialtyIDAccountNo primary key(ServiceCode, DoctorSpecialtyID, AccountNo),
CustomFee money,
CurrenciesID varchar(10) constraint fkCurrenciesIDServicesSpecialtyBillCustomFee references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDServicesSpecialtyBillCustomFee references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesSpecialtyBillCustomFee default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesSpecialtyBillCustomFee default getdate()
)
go

--- Feb 24th. 2018



exec sp_rename 'Suppliers.RevenueStream', 'AccountNo', 'COLUMN'


------------------------Required in the sites where the Account Module is working

exec uspEditOptions 'EnableClinicMasterFinanceItengration',  0, '3BIT', 1, 0

exec uspEditOptions 'BankAccountCategoryNo', '110', '3STR', 20, 1
go

exec uspEditOptions 'CashAccountCategoryNo', '111', '3STR', 20, 1
go

exec uspEditOptions 'TradePayableCategoryAccountNo', '210', '3STR', 20, 1
go


Alter table PaymentDetails add 
SyncStatus bit constraint dfSyncStatusPaymentDetails default 0
go

update PaymentDetails set SyncStatus=0 where SyncStatus is null
go

Alter table PaymentExtraBillItems add 
SyncStatus bit constraint dfSyncStatusPaymentExtraBillItems default 0
go

update PaymentExtraBillItems set SyncStatus=0 where SyncStatus is null
go

Alter table GoodsReceivedNoteDetails add 
SyncStatus bit constraint dfSyncStatusGoodsReceivedNoteDetails default 0
go

update GoodsReceivedNoteDetails set SyncStatus=0 where SyncStatus is null
go

Alter table GoodsReturnedNoteDetails add 
SyncStatus bit constraint dfSyncStatusGoodsGoodsReturnedNoteDetails default 0
go

update GoodsReturnedNoteDetails set SyncStatus=0 where SyncStatus is null
go


Alter table ServiceInvoiceDetails add 
SyncStatus bit constraint dfSyncStatusServiceInvoiceDetails default 0
go

update ServiceInvoiceDetails set SyncStatus=0 where SyncStatus is null
go

---------------------------------01 March 2018---------------------------------------

create table IPDNurseAssessment
(RoundNo Varchar(20)not null constraint pkRoundNoIPDNurseAssessment primary key
constraint fkRoundNoIPDNurseAssessment references IPDNurse (NurseRoundNo)
on delete cascade on update cascade,
Complaint Varchar(1000),
Etiology Varchar(1000),
SignsAndSymptoms Varchar(1000),
ProposedSolution Varchar(1000),
LoginID Varchar(20)
constraint fkLoginIDIPDNurseAssessment2 references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineIPDNurseAssessment  default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeIPDNurseAssessment  default getdate()
)
go

create table IPDNursingPlan
(RoundNo Varchar(20)not null constraint pkRoundNoIPDNursingPlan primary key
constraint fkRoundNoIPDNursingPlan references IPDNurse (NurseRoundNo)
on delete cascade on update cascade,
ExpectedOutcome Varchar(1000),
NursingActions Varchar(1000),
Implementation Varchar(1000),
LoginID Varchar(20)
constraint fkLoginIDIPDNursingPlan references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineIPDNursingPlan default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeIPDNursingPlan default getdate()
)
go

create table IPDNurseEvaluation
(RoundNo Varchar(20)not null constraint pkRoundNoIPDNurseEvaluation primary key
constraint fkRoundNoIPDNurseEvaluation references IPDNurse (NurseRoundNo)
on delete cascade on update cascade,
NursingCareEffective Varchar(10)
constraint fkNursingCareEffectiveIPDNurseEvaluation references LookupData (DataID),
ProposedModifications Varchar(1000),
EvaluationNotes Varchar(1000),
LoginID Varchar(20)
constraint fkLoginIDIPDNurseEvaluation references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineIPDNurseEvaluation default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeIPDNurseEvaluation default getdate()
)
go

------------------------------------------------------------------------------------------------------
---------------------------------05 March 2018--------------------------------------------------------
------------------------------------------------------------------------------------------------------

create table Clients
(ReferenceID int constraint dfReferenceIDClients default 1,
ReferenceNo varchar(20) constraint pkReferenceNo primary key,
FirstName varchar(20),
LastName varchar(20),
MiddleName varchar(20),
GenderID varchar(10) constraint fkGenderIDClients references LookupData (DataID),
PhoneNo varchar(30),
DoctorSpecialtyID varchar(10) constraint fkDoctorSpecialtyIDClients references LookupData (DataID),
StaffNo varchar(10) constraint fkStaffNoClients references Staff (StaffNo),
Description varchar(200),
LoginID varchar(20) constraint fkLoginIDClients references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineClients default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeClients default GetDate()
)
go

exec uspEditOptions 'PurchaseCategoryNo', '511', '3STR', 20, 1
go

alter table ConsumableItems drop constraint fkConsumableCategoryIDConsumableItems
------------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------------
---------------------------------10 March 2018--------------------------------------------------------
------------------------------------------------------------------------------------------------------

exec uspEditOptions 'AllowPrintingPatientBioData', 0, '3BIT', 1, 0

exec uspEditOptions 'SendSMSUsingAPI002', 0, '3BIT', 1, 0

exec uspEditOptions 'SendSMSUsingAPI003', 0, '3BIT', 1, 0


update Patients set  
CommunityID ='50701' where CommunityID is null
go

update Visits set
CommunityID ='50701' where CommunityID is null
go

Alter table OpticalServices add 
UnitCost money
go


Alter table OpticalServices add BatchNo varchar(20) constraint dfBatchNoOpticalServices default '',
UnitMeasureID varchar(10) constraint fkUnitMeasureIDOpticalServices references LookupData (DataID),
LocationID Varchar(10) constraint fkLocationIDOpticalServices references LookupData (DataID),
LastUpdate smalldatetime,
ExpiryDate smalldatetime constraint dfExpiryDateOpticalServices default '1 Jan 1900'
go

alter table Items add InvoiceNo varchar(20) null constraint fkInvoiceNoItems references Invoices (InvoiceNo) 
go

alter table ExtraBillItems add InvoiceNo varchar(20) null constraint fkInvoiceNoExtraBillItems references Invoices (InvoiceNo)
go

create table MappedCodesFinance
(ItemCode varchar(20),
ItemCategoryID varchar(10)
constraint fkItemCategoryIDMappedCodesFinance references LookupData (DataID),
AccountTypeID Varchar(10)
constraint fkAccountTypeIDMappedCodesFinance references LookupData (DataID),
constraint pkItemCodeItemCategoryIDAccountTypeID primary key(ItemCode, ItemCategoryID, AccountTypeID),
ItemName varchar(200),
AccountNo varchar(20),
LoginID varchar(20)
constraint fkLoginIDMappedCodesFinance references Logins (LoginID),
Username varchar(41),
ClientMachine varchar(40) constraint dfClientMachineMappedCodesFinance default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeMappedCodesFinance default getdate()
)
go

------------------------------------------------------------------------------------------------------

alter table RefundRequestDetails add Amount money


--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor

declare @RefundRequestNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)


DECLARE RefundRequest_Cursor INSENSITIVE CURSOR FOR

SELECT RefundRequestNo, ItemCode, ItemCategoryID FROM RefundRequestDetails

OPEN RefundRequest_Cursor
FETCH NEXT FROM RefundRequest_Cursor INTO @RefundRequestNo, @ItemCode, @ItemCategoryID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE RefundRequestDetails Set Amount = Quantity * NewPrice
		WHERE RefundRequestNo = @RefundRequestNo and  ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		FETCH NEXT FROM RefundRequest_Cursor INTO @RefundRequestNo, @ItemCode, @ItemCategoryID
	END
CLOSE RefundRequest_Cursor
deallocate RefundRequest_Cursor

----- End Amount Cursor Block ---------------------------------------------------------------------

alter table BankAccounts drop column RevenueStream
alter table BankAccounts add constraint dfRecordDateTimeBankAccounts default getdate() for RecordDateTime


---------------------------03 May 2018----------------------------------------------
alter table ImmunisationVaccines
drop constraint pkImmunisationNo
go

alter table ImmunisationVaccines alter column PatientNo varchar(20) not null
alter table ImmunisationVaccines alter column VaccineName varchar(10) not null

alter table ImmunisationVaccines add constraint pkPatientNoVaccineNameImmunisationVaccines primary key(PatientNo, VaccineName)
go

--- run on 9/6/18

--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor

declare @InvoiceNo varchar(20)
declare @PayNo varchar(20)
declare @VisitNo varchar(20)
declare @ItemCategoryID varchar(10)
declare @ItemCode varchar(20)


DECLARE UpdateItemsInvoiceNo_Cursor  INSENSITIVE CURSOR FOR

SELECT InvoiceDetails.InvoiceNo, PayNo, VisitNo, ItemCategoryID, ItemCode FROM InvoiceDetails
inner join Invoices on Invoices.InvoiceNo = InvoiceDetails.InvoiceNo and Invoices.PayNo = InvoiceDetails.VisitNo
WHERE VisitTypeID ='110OPD'

OPEN UpdateItemsInvoiceNo_Cursor 
FETCH NEXT FROM UpdateItemsInvoiceNo_Cursor  INTO @InvoiceNo, @PayNo, @VisitNo, @ItemCategoryID, @ItemCode
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE Items Set InvoiceNo = @InvoiceNo 
		WHERE  VisitNo= @PayNo and  ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		FETCH NEXT FROM UpdateItemsInvoiceNo_Cursor  INTO @InvoiceNo, @PayNo, @VisitNo, @ItemCategoryID, @ItemCode
	END
CLOSE UpdateItemsInvoiceNo_Cursor 
deallocate UpdateItemsInvoiceNo_Cursor 
go
----- End Cursor Block ---------------------------------------------------------------------
---- select * from InvoiceDetails



--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor

declare @InvoiceNo varchar(20)
declare @PayNo varchar(20)
declare @VisitNo varchar(20)
declare @ExtraBillNo varchar(20)
declare @ItemCategoryID varchar(10)
declare @ItemCode varchar(20)


DECLARE UpdateExtraBillItemsInvoiceNo_Cursor INSENSITIVE CURSOR FOR

SELECT InvoiceExtraBillItems.InvoiceNo, PayNo, VisitNo, InvoiceExtraBillItems.ExtraBillNo, ItemCategoryID, ItemCode 
FROM InvoiceExtraBillItems
inner join ExtraBills on ExtraBills.ExtraBillNo = InvoiceExtraBillItems.ExtraBillNo
inner join Invoices on Invoices.InvoiceNo = InvoiceExtraBillItems.InvoiceNo and Invoices.PayNo = ExtraBills.VisitNo
WHERE VisitTypeID ='110IPD'

OPEN UpdateExtraBillItemsInvoiceNo_Cursor
FETCH NEXT FROM UpdateExtraBillItemsInvoiceNo_Cursor INTO @InvoiceNo, @PayNo, @VisitNo, @ExtraBillNo, @ItemCategoryID, @ItemCode
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE ExtraBillItems Set InvoiceNo = @InvoiceNo 
		WHERE  ExtraBillNo= @ExtraBillNo and  ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		FETCH NEXT FROM UpdateExtraBillItemsInvoiceNo_Cursor INTO @InvoiceNo, @PayNo, @VisitNo, @ExtraBillNo, @ItemCategoryID, @ItemCode
	END
CLOSE UpdateExtraBillItemsInvoiceNo_Cursor
deallocate UpdateExtraBillItemsInvoiceNo_Cursor

----- End Cursor Block ---------------------------------------------------------------------
---- select * from InvoiceDetails


--- exec uspEditOptions 'EnableUseOfRefundDateForReports', 0, '3BIT', 1, 0

Alter table Patients add EducationLevelID varchar(10) constraint fkEducationLevelIDPatients references LookupData (DataID)
go

-------------Run Data First

update Patients set
EducationLevelID ='86U' where EducationLevelID is null
go


---------------------------28 May 2018-------------------------------

create table OccupationalTherapy
(VisitNo Varchar(20)
constraint fkVisitNoOccupationalTherapy references Visits (VisitNo),
WalkingID varchar(10)
constraint fkWalkingIDOccupationalTherapy references LookupData (DataID),
SitStandTransfersID varchar(10)
constraint fkSitStandTransfersIDOccupationalTherapy references LookupData (DataID),
BathingID varchar(10)
constraint fkBathingIDOccupationalTherapy references LookupData (DataID),
ToiletingID varchar(10)
constraint fkToiletingIDOccupationalTherapy references LookupData (DataID),
DressingID varchar(10)
constraint fkDressingIDOccupationalTherapy references LookupData (DataID),
HandFunctionID varchar(10)
constraint fkHandFunctionIDOccupationalTherapy references LookupData (DataID),
WashingID varchar(10)
constraint fkWashingIDOccupationalTherapy references LookupData (DataID),
FeedingID varchar(10)
constraint fkFeedingIDOccupationalTherapy references LookupData (DataID),
GroomingID varchar(10)
constraint fkGroomingIDOccupationalTherapy references LookupData (DataID),
MealPreparationID varchar(10)
constraint fkMealPreparationIDOccupationalTherapy references LookupData (DataID),
WorkPlaySchoolID varchar(10)
constraint fkWorkPlaySchoolIDOccupationalTherapy references LookupData (DataID),
LeisureID varchar(10)
constraint fkLeisureIDOccupationalTherapy references LookupData (DataID),
CommunicationID varchar(10)
constraint fkCommunicationIDOccupationalTherapy references LookupData (DataID),
CognitionID varchar(10)
constraint fkCognitionIDOccupationalTherapy references LookupData (DataID),
AttentionID varchar(10)
constraint fkAttentionIDOccupationalTherapy references LookupData (DataID),
ImpulseControlID varchar(10)
constraint fkImpulseControlIDOccupationalTherapy references LookupData (DataID),
SleepID varchar(10)
constraint fkSleepIDOccupationalTherapy references LookupData (DataID),
MemoryID varchar(10)
constraint fkMemoryIDOccupationalTherapy references LookupData (DataID),
PerceptionID varchar(10)
constraint fkPerceptionIDOccupationalTherapy references LookupData (DataID),
ThoughtID varchar(10)
constraint fkThoughtIDOccupationalTherapy references LookupData (DataID),
SightID varchar(10)
constraint fkSightIDOccupationalTherapy references LookupData (DataID),
TasteID varchar(10)
constraint fkTasteIDOccupationalTherapy references LookupData (DataID),
HearingID varchar(10)
constraint fkHearingIDOccupationalTherapy references LookupData (DataID),
TouchID varchar(10)
constraint fkTouchIDOccupationalTherapy references LookupData (DataID),
SmellID varchar(10)
constraint fkSmellIDOccupationalTherapy references LookupData (DataID),
PainID varchar(10)
constraint fkPainIDOccupationalTherapy references LookupData (DataID),
VestibularID varchar(10)
constraint fkVestibularIDOccupationalTherapy references LookupData (DataID),
TemperatureAndPressureID varchar(10)
constraint fkTemperatureAndPressureIDOccupationalTherapy references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDOccupationalTherapy references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOccupationalTherapy default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeOccupationalTherapy default getdate()
)
go

create table OTIntervention
(VisitNo Varchar(20)
constraint fkVisitNoOTIntervention references Visits (VisitNo),
LeadTherapist Varchar(10)
constraint fkLeadTherapistOTIntervention references Staff (StaffNo),
InterventionTypeID Varchar(10)
constraint fkInterventionTypeIDOTIntervention references LookupData (DataID),
CognitiveAssessment bit,
HandTherapy bit,
HealthEducation bit,
TherapeuticGroupActivities bit,
HomebasedRehabilitation bit,
AssistiveDevices bit,
MobilitySkillsTraining bit,
NeurocognitiveRehabilitation bit,
OrientationTechniques bit,
VocationalRehabilitation bit,
SelfCareTraining bit,
PlayTherapy bit,
StressManagement bit,
OtherAssessment varchar(100),
Notes varchar(200),
LoginID varchar(20)
constraint fkLoginIDOTIntervention references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineOTIntervention default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeOTIntervention default getdate()
)
go


---------------------------------------------------------------------------------
---------------Added update on Thur 11-06-18 By Wilson --------------------------
---------------------------------------------------------------------------------

create table ServicesStaffBillCustomFee
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesStaffBillCustomFee 
references Services (ServiceCode) on delete cascade on update cascade,
StaffNo varchar(10) not null constraint fkStaffNoServicesStaffBillCustomFee 
references Staff (StaffNo) on delete cascade on update cascade,
AccountNo varchar(20) not null constraint fkAccountNoServicesStaffBillCustomFee
references BillCustomers (AccountNo) on delete cascade on update cascade,
constraint pkServiceCodeStaffNoAccountNo primary key(ServiceCode, StaffNo, AccountNo),
CustomFee money,
CurrenciesID varchar(10) constraint fkCurrenciesIDServicesStaffBillCustomFee references LookupData (DataID),
LoginID varchar(20) constraint fkLoginIDServicesStaffBillCustomFee references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesStaffBillCustomFee default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesStaffBillCustomFee default getdate()
)
go

create table ServicesSpecialtyCustomCode
(ServiceCode varchar(10) not null constraint fkServiceCodeServicesSpecialtyCustomCode 
references Services (ServiceCode) on delete cascade on update cascade,
DoctorSpecialtyID varchar(10) not null constraint fkDoctorSpecialtyIDServicesSpecialtyCustomCode references LookupData (DataID),
constraint pkServiceCodeDoctorSpecialtyIDServicesSpecialtyCustomCode primary key(ServiceCode, DoctorSpecialtyID),
CustomCode varchar(20),
LoginID varchar(20) constraint fkLoginIDServicesSpecialtyCustomCode references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineServicesSpecialtyCustomCode default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeServicesSpecialtyCustomCode default getdate()
)
go


--------- 19th Jun 2018 -----------------------------------------------------------------------

alter table PhysicalStockCount add 
 StartDate smalldatetime,
EndDate smalldatetime,
Closed bit constraint dfClosedPhysicalStockCount default 1
go

update PhysicalStockCount set StartDate = dbo.GetShortDate(RecordDateTime) where StartDate is null
go
update PhysicalStockCount set EndDate = dbo.GetShortDate(RecordDateTime) where EndDate is null
go
update PhysicalStockCount set Closed = 1 where Closed is null
go
exec uspEditOptions 'UseCentralisedPhysicalStockCount', 0, '3BIT', 1, 0
go
exec uspEditOptions 'EnableMultiplePhysicalStockCountNumbers', 0, '3BIT', 1, 0
go

create table INTStockTake
(PSCNo varchar(20),
ItemCategoryID varchar(10),
ItemCode varchar(20),
constraint pkPSCNoItemCategoryIDItemCode primary key(PSCNo, ItemCategoryID, ItemCode),
Agent varchar(10),
SyncStatus bit constraint dfSyncStatusINTStockTake default 0,
RecordDateTime smalldatetime constraint dfRecordDateTimeINTStockTake default getdate()
)
go

-------------------------- 29 June 2018----------------------------------------------------------

create table MaternalEnrollment
(ANCID int constraint dfANCIDMaternalEnrollment default 1,
ANCNo varchar(20) constraint pkMaternalEnrollmentANCNo primary key, 
PatientNo varchar(20) constraint fkPatientNoMaternalEnrollment references Patients (PatientNo),
HIVStatusID varchar(10) constraint fkHIVStatusIDMaternalEnrollment references LookupData (DataID),
PartnersHIVStatusID varchar(10) constraint fkPartnersHIVStatusIDMaternalEnrollment references LookupData (DataID),
Gravida int,
Para int,
LNMP smalldatetime,
LNMPDateReliable bit,
CycleRegularID varchar(10) constraint fkCycleRegularIDMaternalEnrollment references LookupData (DataID),
EDD smalldatetime,
ScanDate smalldatetime,
MedicalHistory varchar(200),
MedicalHistoryNotes varchar(200),
BloodTransfusion varchar(10) constraint fkBloodTransfusionMaternalEnrollment references LookupData (DataID),
BloodTransfusionDate smalldatetime,
SurgicalHistory varchar(200),
SurgicalHistoryNotes varchar(200),
GynaecologicalHistory varchar(200),
GynaecologicalHistoryNotes varchar(200),
FamilyHistory varchar(200),
FamilyHistoryNotes varchar(200),
SocialHistory varchar(200),
SocialHistoryNotes varchar(200),
PatientStatusID varchar(10) constraint fkPatientStatusIDMaternalEnrollment references LookupData (DataID),
LoginID varchar(20)
constraint fkLoginIDMaternalEnrollment references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineMaternalEnrollment default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeMaternalEnrollment default getdate()
)
go

----Requires lookupdata genderID NA enabled
create table Obstetric
(PatientNo Varchar(20) constraint fkPatientNoObstetric references Patients (PatientNo)
constraint pkPatientNoPregnancy primary key(PatientNo, Pregnancy),
Pregnancy int,
YearPregnant int,
AbortionID varchar(10) constraint fkAbortionIDObstetric references LookupData (DataID),
AbortionPeriodID varchar(10) constraint fkAbortionPeriodIDObstetric references LookupData (DataID),
TypeOfDeliveryID varchar(10) constraint fkTypeOfDeliveryIDObstetric references LookupData (DataID),
ThirdStageID Varchar(10) constraint fkThirdStageIDObstetric references LookupData (DataID),
PuerPeriumID Varchar(10) constraint fkPuerPeriumIDObstetric references LookupData (DataID),
ChildStatusID varchar(10) constraint fkChildStatusIDObstetric references LookupData (DataID),
GenderID Varchar(10) constraint fkGenderIDObstetric references LookupData (DataID),
BirthWeight decimal,
ChildImmunised bit,
HealthCondition Varchar(200),
LoginID Varchar(20) constraint fkLoginIDObstetric references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineObstetric default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeObstetric default getdate()
)
go

--drop table obstetric

create table ContraceptivesHistory
(PatientNo varchar(20) constraint fkPatientNoContraceptivesHistory references Patients (PatientNo) constraint pkContraceptivesHistoryPatientNo primary key,
ComplicationsID varchar(10) constraint fkComplicationsIDContraceptivesHistory references LookupData (DataID),
ComplicationDetails varchar(200),
ContraceptiveID varchar(10) constraint fkContraceptiveIDContraceptivesHistory references LookupData (DataID),
DateStarted smalldatetime,
DiscontinuedRemovedID varchar(10) constraint fkDiscontinuedRemovedIDContraceptivesHistory references LookupData (DataID),
RemovalReasonsID varchar(10) constraint fkRemovalReasonsIDContraceptivesHistory references LookupData (DataID),
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDContraceptivesHistory references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineContraceptivesHistory default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeContraceptivesHistory default getdate()
)
go

create table AntenatalVisits

(VisitNo Varchar(20) constraint fkVisitNoAntenatalVisits references Visits (VisitNo) constraint pkAntenatalVisitsVisitNo primary key,
ANCNo varchar(20) constraint fkANCNoAntenatalVisits references MaternalEnrollment (ANCNo),
PallorID varchar(10) constraint fkPallorIDAntenatalVisits references LookupData (DataID),
JaundiceID varchar(10) constraint fkJaundiceIDAntenatalVisits references LookupData (DataID),
LynphadenopathyID varchar(10) constraint fkLynphadenopathyIDAntenatalVisits references LookupData (DataID),
VaricoseID varchar(10) constraint fkVaricoseIDAntenatalVisits references LookupData (DataID),
OedemaID Varchar(10) constraint fkOedemaIDAntenatalVisits references LookupData (DataID),
HeartSoundID Varchar(10) constraint fkHeartSoundIDAntenatalVisits references LookupData (DataID),
AirEntryID varchar(10) constraint fkAirEntryIDAntenatalVisits references LookupData (DataID),
BreastID Varchar(10) constraint fkBreastIDAntenatalVisits references LookupData (DataID),
LiverID Varchar(10) constraint fkLiverIDAntenatalVisits references LookupData (DataID),
SpleenID Varchar(10) constraint fkSpleenIDAntenatalVisits references LookupData (DataID),
BowelSoundsID varchar(10) constraint fkBowelSoundsIDAntenatalVisits references LookupData (DataID),
ScarID Varchar(10) constraint fkScarIDAntenatalVisits references LookupData (DataID),
PupilReactionID Varchar(10) constraint fkPupilReactionIDAntenatalVisits references LookupData (DataID),
ReflexesID Varchar(10) constraint fkReflexesIDAntenatalVisits references LookupData (DataID),
OtherSTIID varchar(10) constraint fkOtherSTIIDAntenatalVisits references LookupData (DataID),
STIDetails Varchar(200),
SkeletalDeformityID Varchar(10) constraint fkSkeletalDeformityIDAntenatalVisits references LookupData (DataID),
AnenorrheaWeeks int,
FundalHeight varchar(10),
PresentationID Varchar(10) constraint fkPresentationIDAntenatalVisits references LookupData (DataID),
LieID varchar(10) constraint fkLieDAntenatalVisits references LookupData (DataID),
PositionID varchar(10) constraint fkPositionIDAntenatalVisits references LookupData (DataID),
RelationPPOrBrim varchar(10),
FoetalHeart int,
TTGiven bit,
IPTID  varchar(10) constraint fkIPTIDAntenatalVisits references LookupData (DataID),
NetUseID varchar(10) constraint fkNetUseIDAntenatalVisits references LookupData (DataID),
Remarks varchar(200),
ReturnDate smalldatetime,
DoctorSpecialityID varchar(10) constraint fkDoctorSpecialityIDAntenatalVisits references LookupData (DataID),
DoctorID varchar(10) constraint fkDoctorIDAntenatalVisits references Staff (StaffNo),
NurseInChargeID varchar(10) constraint fkNurseInChargeIDAntenatalVisits references Staff(StaffNo),
LoginID Varchar(20) constraint fkLoginIDAntenatalVisits references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachineAntenatalVisits default host_name(),
RecordDateTime Smalldatetime constraint dfRecordDateTimeAntenatalVisits default getdate()
)
go

create table PelvicExamination
(VisitNo Varchar(20) constraint fkVisitNoPelvicExamination references Visits (VisitNo) constraint pkPelvicExaminationVisitNo primary key,
ANCNo varchar(20) constraint fkANCNoPelvicExamination references MaternalEnrollment (ANCNo),
VulvaID Varchar(10) constraint fkVulvaIDPelvicExamination references LookupData (DataID),
CervixID varchar(10) constraint fkCervixIDPelvicExamination references LookupData (DataID),
AdnexaID Varchar(10) constraint fkAdnexaIDPelvicExamination references LookupData (DataID),
VaginaID Varchar(10) constraint fkVaginaIDPelvicExamination references LookupData (DataID),
UterusID Varchar(10) constraint fkUterusIDPelvicExamination references LookupData (DataID),
DiagonalConjugate int,
SacralCurve int,
IschialSpine int,
SubPublicAngle int,
IschialTuberosities int,
ConclusionID varchar(10) constraint fkConclusionIDPelvicExamination references LookupData (DataID),
RiskFactors varchar(200),
Recommendations varchar(200),
LoginID Varchar(20) constraint fkLoginIDPelvicExamination references Logins (LoginID),
ClientMachine Varchar(40) constraint dfClientMachinePelvicExamination default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePelvicExamination default getdate()
)
go




-------------------------- 05 Jul 2018----------------------------------------------------------

delete from ObjectRoles where RoleName ='Cashier' and ObjectName ='HCTClientCard'
delete from ObjectRoles where RoleName ='Cashier' and ObjectName ='CancerAndNormalDiagnosis'
delete from ObjectRoles where RoleName ='Cashier' and ObjectName ='StaffLocations'
delete from ObjectRoles where RoleName ='Cashier' and ObjectName ='DeliveryNoteDetails'
delete from ObjectRoles where RoleName ='Cashier' and ObjectName ='IPDCancerDiagnosis'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='StaffLocations'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='IPDNurseFluids'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='IPDDrugAdministration'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='IPDNurse'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='BulkMessaging'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='ItemsBalanceDetails'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='DrugAdministration'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='InvoiceExtraBillItems'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='InvoiceDetails'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='Invoices'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='QuotationDetails'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='Quotations'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='PaymentExtraBillItems'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='PaymentDetails'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='CreditBillFormPayment'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='BillsPayment'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='BillFormPayment'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='CashPayments'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='Payments'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='CashReceipts'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='CashCollections'
delete from ObjectRoles where RoleName ='Guest' and ObjectName ='Accounts'
go


delete from ObjectRoles where RoleName ='Setup' and ObjectName ='StaffPayments'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='StaffPaymentsEXT'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='OPDStaffPaymentDetails'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='IPDStaffPaymentDetails'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='RefundRequests'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='RefundRequestDetails'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='RefundApprovals'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='RefundRejects'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='MaternalEnrollment'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='ContraceptivesHistory'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='AntenatalVisits'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='BankingRegisterDetails'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='BankPaymentDetails'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='RefundDetails'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='TBIntensifiedCaseFinding'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='Emergency'
delete from ObjectRoles where RoleName ='Doctor' and ObjectName ='CreditNote'
delete from ObjectRoles where RoleName ='Doctor' and ObjectName ='RefundRequests'
delete from ObjectRoles where RoleName ='Doctor' and ObjectName ='CreditNoteDetails'
delete from ObjectRoles where RoleName ='Doctor' and ObjectName ='RefundRequestDetails'
delete from ObjectRoles where RoleName ='Doctor' and ObjectName ='InventoryReturns'
delete from ObjectRoles where RoleName ='Doctor' and ObjectName ='MappedCodes'
delete from ObjectRoles where RoleName ='Doctor' and ObjectName ='StaffLocations'
delete from ObjectRoles where RoleName ='Setup' and ObjectName ='SymptomsHistory'
go



drop table ChartItems

drop table COASubCategories

drop table COACategories


drop proc uspInsertCOACategories

drop proc uspUpdateCOACategories

drop proc uspGetCOACategories

drop proc uspInsertCOASubCategories

drop proc uspUpdateCOASubCategories

drop proc uspGetCOASubCategories

drop proc uspEditChartItems

drop proc uspUpdateChartItems

drop proc uspGetChartItems

go


exec uspEditOptions 'AdmissionMaxDays', 30, '3NUM', 2, 0
go

-------------------------- 12 Jul 2018----------------------------------------------------------

create table ReceiptReversals
(ReceiptNo varchar(20) constraint fkReceiptNoReceiptReversals references Payments (ReceiptNo),
RefundNo varchar(20) constraint fkRefundNoReceiptReversals references Refunds (RefundNo) constraint pkRefundNoReceiptReversals primary key,
Notes varchar(200),
LoginID varchar(20) constraint fkLoginIDReceiptReversals references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineReceiptReversals default host_name(),
RecordDateTime smallDateTime constraint dfRecordDateTimeReceiptReversals default getdate()
)
go

alter table AttachPackage add PatientNo varchar(20) constraint fkPatientNoAttachPackage references Patients (PatientNo),
PackageStartDate smallDateTime constraint dfPackageStartDateAttachPackage default getdate(),
PackageEndDate smallDateTime
go

drop proc uspInsertPackageDetails

drop proc uspUpdatePackageDetails

drop proc uspGetPackageDetails

drop trigger utrUpdatePackageDetails

drop trigger utrDeletePackageDetails



--------run cursor below, but be very carefull--------------------------------------------------------------

--------Note : Run Manage first

declare @VisitNo varchar(20)
declare @PatientNo varchar(20)
declare @PackageNo varchar(20)
declare @LoginID varchar(20)
declare @PackageExpiryDays int
declare @PackageEndDate smallDateTime
declare @Packagestart smallDateTime
 
DECLARE PackageVisits_Cursor INSENSITIVE CURSOR FOR

select VisitNo,PatientNo,PackageNo,LoginID,RecordDateTime
from PackageDetails


OPEN PackageVisits_Cursor
FETCH NEXT FROM PackageVisits_Cursor INTO @VisitNo,@PatientNo,@PackageNo,@LoginID,@Packagestart
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	

------------------------------------------------------------------------------------------------------
Set @PackageExpiryDays =isnull ((select ExpiryDays from Packages where PackageNo =@PackageNo),0)
Set @PackageEndDate =(@Packagestart + @PackageExpiryDays)
------------------------------------------------------------------------------------------------------

exec uspInsertAttachPackage @VisitNo,@PatientNo,@PackageNo,'',@LoginID


FETCH NEXT FROM PackageVisits_Cursor INTO @VisitNo,@PatientNo,@PackageNo,@LoginID,@Packagestart
	END
CLOSE PackageVisits_Cursor
deallocate PackageVisits_Cursor

----------------------------------------------------------------------------------



drop table PackageDetails


-------------------------------------- 17 th Jul 2018 ---------------------------------------------------------


create table PackageVisits
(VisitNo varchar(20) constraint fkVisitNoPackageVisits references Visits (VisitNo),
PatientNo varchar(20) constraint fkPatientNoPackageVisits references Patients (PatientNo),
PackageNo varchar(20) constraint fkPackageNoPackageVisits references Packages (PackageNo),
constraint pkVisitNoPackageNoPackageVisits primary key(VisitNo, PackageNo)
)
go

--------run cursor below, but be very carefull--------------------------------------------------------------

--------Note : Run Manage first

declare @VisitNo varchar(20)
declare @PatientNo varchar(20)
declare @PackageNo varchar(20)
 
DECLARE PackageVisits_Cursor INSENSITIVE CURSOR FOR

select VisitNo,PatientNo,PackageNo
from Visits where len(PackageNo) > 0


OPEN PackageVisits_Cursor
FETCH NEXT FROM PackageVisits_Cursor INTO @VisitNo,@PatientNo,@PackageNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
exec uspInsertPackageVisits @VisitNo,@PatientNo,@PackageNo


FETCH NEXT FROM PackageVisits_Cursor INTO @VisitNo,@PatientNo,@PackageNo
	END
CLOSE PackageVisits_Cursor
deallocate PackageVisits_Cursor

----------------------------------------------------------------------------------




alter table IPDPackageConsumption add PackageVisitNo varchar(20)
go

Alter table Admissions add BillModesID varchar(10) constraint fkBillModesIDAdmissions references LookupData (DataID),
BillNo varchar(20), -- Reference BillCustomers and SchemeMembers
InsuranceNo varchar(20), -- Reference BillCustomers and Insurances
AssociatedBillNo varchar(20) null constraint fkAssociatedBillNoAdmissions references BillCustomers (AccountNo),
MemberCardNo varchar(30),
MainMemberName varchar(41),
ClaimReferenceNo varchar(30),
CoPayTypeID varchar(10) constraint fkCoPayTypeIDAdmissions references LookupData (DataID),
CoPayPercent decimal(5,2) constraint ckCoPayPercentAdmissions check (CoPayPercent >= 0 and CoPayPercent <= 100),
CoPayValue money,
AccessCashServices bit constraint dfAccessCashServicesAdmissions default 0,
SmartCardApplicable bit constraint dfSmartCardApplicableAdmissions default 0
go


------------------------------------------ 19th Jul 2018  --------------------------------------------------------------

alter table ReturnedExtraBillItems 
add Amount money constraint dfAmountReturnedExtraBillItems default 0,
 Acknowledgeable bit constraint dfAcknowledgeableReturnedExtraBillItems default 0,
 IsAcknowledged bit constraint dfIsAcknowledgedReturnedExtraBillItems default 0
go


update ReturnedExtraBillItems set IsAcknowledged = 0 where ItemTransferStatus = '11P'
go
update ReturnedExtraBillItems set IsAcknowledged = 1 where  ItemTransferStatus = '11D'
go


--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @ExtraBillNo varchar(20)
declare @ItemCategoryID varchar(10)
declare @ItemCode varchar(20)
declare @Quantity int
declare @UnitPrice money


DECLARE UpdateReturnedExtraBillItemsAmount_Cursor INSENSITIVE CURSOR FOR

SELECT ReturnedExtraBillItems.ExtraBillNo, ReturnedExtraBillItems.ItemCategoryID, ReturnedExtraBillItems.ItemCode,ReturnedExtraBillItems.Quantity, UnitPrice 
FROM ReturnedExtraBillItems
inner join ExtraBillItems on ExtraBillItems.ExtraBillNo = ReturnedExtraBillItems.ExtraBillNo 
and ExtraBillItems.ItemCategoryID = ReturnedExtraBillItems.ItemCategoryID
and ExtraBillItems.ItemCode = ReturnedExtraBillItems.ItemCode


OPEN UpdateReturnedExtraBillItemsAmount_Cursor
FETCH NEXT FROM UpdateReturnedExtraBillItemsAmount_Cursor INTO @ExtraBillNo, @ItemCategoryID, @ItemCode, @Quantity, @UnitPrice
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE ReturnedExtraBillItems Set Amount = (@UnitPrice * @Quantity)
		WHERE  ExtraBillNo= @ExtraBillNo and  ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		and Amount is null
		
		UPDATE ReturnedExtraBillItems Set Acknowledgeable = 1
		WHERE  ExtraBillNo= @ExtraBillNo and  ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		and ItemCategoryID in('7D', '7C') and Quantity>0

		FETCH NEXT FROM UpdateReturnedExtraBillItemsAmount_Cursor INTO  @ExtraBillNo, @ItemCategoryID, @ItemCode, @Quantity, @UnitPrice
	END
CLOSE UpdateReturnedExtraBillItemsAmount_Cursor
deallocate UpdateReturnedExtraBillItemsAmount_Cursor




----- End Cursor Block ---------------------------------------------------------------------

alter table ExtraBillItems 
add ReturnQuantity int constraint dfReturnQuantityExtraBillItems default 0,
 ReturnAmount money constraint dfReturnAmountExtraBillItems default 0
 go



exec sp_rename 'InventoryReturns', 'BillReturns'
go  
drop proc uspInsertInventoryReturns
go
drop proc uspUpdateInventoryReturns
go

drop proc uspGetInventoryReturns
go

drop proc uspGetNextInventoryReturnID
go

exec sp_rename 'BillReturns.ReturnTypeID', 'VisitTypeID'
go

alter table BillReturns add ReturnDate smalldatetime
go


delete from AutoNumbers where ObjectName = 'InventoryReturns'
delete from ObjectRoles where ObjectName = 'InventoryReturns'
delete from AccessObjects where ObjectName = 'InventoryReturns'
go

alter table ReturnedItems add Amount money constraint dfAmountReturnedItems default 0,
Acknowledgeable bit constraint dfAcknowledgeableReturnedItems default 0,
IsAcknowledged bit constraint dfIsAcknowledgedReturnedItems default 0
go

update ReturnedItems set Amount = 0 where Amount is null
go

update ReturnedItems set IsAcknowledged = 0 where ItemTransferStatus = '11P'
go
update ReturnedItems set IsAcknowledged = 1 where  ItemTransferStatus = '11D'
go


--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @VisitNo varchar(20)
declare @ItemCategoryID varchar(10)
declare @ItemCode varchar(20)
declare @Quantity int
declare @UnitPrice money


DECLARE UpdateReturnedItemsAmount_Cursor INSENSITIVE CURSOR FOR

SELECT ReturnedItems.VisitNo, ReturnedItems.ItemCategoryID, ReturnedItems.ItemCode,ReturnedItems.Quantity, UnitPrice 
FROM ReturnedItems
inner join Items on Items.VisitNo = ReturnedItems.VisitNo 
and Items.ItemCategoryID = ReturnedItems.ItemCategoryID
and Items.ItemCode = ReturnedItems.ItemCode


OPEN UpdateReturnedItemsAmount_Cursor
FETCH NEXT FROM UpdateReturnedItemsAmount_Cursor INTO @VisitNo, @ItemCategoryID, @ItemCode, @Quantity, @UnitPrice
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE ReturnedItems Set Amount = (@UnitPrice * @Quantity)
		WHERE  VisitNo= @VisitNo and  ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		
		UPDATE ReturnedItems Set Acknowledgeable = 1
		WHERE  VisitNo= @VisitNo and  ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		and ItemCategoryID in('7D', '7C') and Quantity>0

		FETCH NEXT FROM UpdateReturnedItemsAmount_Cursor INTO  @VisitNo, @ItemCategoryID, @ItemCode, @Quantity, @UnitPrice
	END
CLOSE UpdateReturnedItemsAmount_Cursor
deallocate UpdateReturnedItemsAmount_Cursor

----- End Cursor Block ---------------------------------------------------------------------

alter table CreditNote add VisitTypeID varchar(10) constraint fkVisitTypeIDCreditNote references LookupData (DataID)
go
 alter table CreditNote alter column ClientMachine varchar(40)
 go

  alter table CreditNote drop  dfCreditNoteIDCreditNote
  go
    
alter table CreditNote alter column  CreditNoteID int 
go

Alter table CreditNote add constraint dfCreditNoteIDCreditNote default 1 for CreditNoteID

--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @CreditNoteNo varchar(20)
declare @InvoiceNo varchar(20)
declare @VisitTypeID varchar(10)

DECLARE UpdateCreditNoteVisitTypeID_Cursor INSENSITIVE CURSOR FOR

SELECT CreditNoteNo, CreditNote.InvoiceNo, Invoices.VisitTypeID from CreditNote 
inner join Invoices on Invoices.InvoiceNo =CreditNote.InvoiceNo



OPEN UpdateCreditNoteVisitTypeID_Cursor
FETCH NEXT FROM UpdateCreditNoteVisitTypeID_Cursor INTO @CreditNoteNo, @InvoiceNo, @VisitTypeID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE CreditNote Set VisitTypeID = @VisitTypeID WHERE  CreditNoteNo = @CreditNoteNo
		

		FETCH NEXT FROM UpdateCreditNoteVisitTypeID_Cursor INTO @CreditNoteNo, @InvoiceNo, @VisitTypeID
	END
CLOSE UpdateCreditNoteVisitTypeID_Cursor
deallocate UpdateCreditNoteVisitTypeID_Cursor
go
----- End Cursor Block ---------------------------------------------------------------------


alter table CreditNoteDetails add
VisitNo varchar(20), 
InvoiceNo varchar(20),
Amount money constraint dfAmountCreditNoteDetails default 0
go

update CreditNoteDetails set Amount = UnitPrice * Quantity where Amount is null
go
alter table CreditNoteDetails alter column ClientMachine varchar(40) 
go

create table CreditNoteExtraBillItems
(CreditNoteNo varchar(20) not null
constraint fkCreditNoteNoCreditNoteExtraBillItems references CreditNote (CreditNoteNo),
ExtraBillNo varchar(20) not null,
InvoiceNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10) not null
constraint fkItemCategoryIDCreditNoteExtraBillItems references LookupData (DataID),
constraint fkExtraBillNoInvoiceNoItemCodeItemCategoryIDCreditNoteExtraBillItems foreign key (InvoiceNo, ExtraBillNo, ItemCode, ItemCategoryID)
references InvoiceExtraBillItems (InvoiceNo, ExtraBillNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkCreditNoteNoExtraBillNoInvoiceNoItemCodeItemCategoryID primary key(CreditNoteNo, ExtraBillNo, InvoiceNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDCreditNoteExtraBillItems references LookupData (DataID),
Quantity int,
Amount money,
LoginID varchar(20)
constraint fkLoginIDCreditNoteExtraBillItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineCreditNoteExtraBillItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeCreditNoteExtraBillItems default getdate()
)
go

--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @CreditNoteNo varchar(20)
declare @InvoiceNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)
declare @VisitTypeID varchar(10)
declare @VisitNo varchar(20)

DECLARE UpdateCreditNoteDetailsVisitNoInvoiceNo_Cursor INSENSITIVE CURSOR FOR

SELECT CreditNote.CreditNoteNo, CreditNote.InvoiceNo,VisitTypeID, ItemCode, ItemCategoryID from CreditNoteDetails 
inner join CreditNote on CreditNote.CreditNoteNo = CreditNoteDetails.creditNoteNo



OPEN UpdateCreditNoteDetailsVisitNoInvoiceNo_Cursor
FETCH NEXT FROM UpdateCreditNoteDetailsVisitNoInvoiceNo_Cursor INTO @CreditNoteNo, @InvoiceNo,@VisitTypeID, @ItemCode, @ItemCategoryID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		if @VisitTypeID = '110OPD'
		  begin
			 set @VisitNo = (select top 1 VisitNo from InvoiceDetails 
			 where InvoiceNo = @InvoiceNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
		  end
		  else if @VisitTypeID = '110IPD'
		  begin
			 set @VisitNo = (select top 1 VisitNo from InvoiceExtraBillItems
			 inner join ExtraBills on ExtraBills.ExtraBillNo = InvoiceExtraBillItems.ExtraBillNo 
			 where InvoiceNo = @InvoiceNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
		  end
		
		UPDATE CreditNoteDetails set VisitNo = @VisitNo,  InvoiceNo = @InvoiceNo WHERE  CreditNoteNo = @CreditNoteNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		
		FETCH NEXT FROM UpdateCreditNoteDetailsVisitNoInvoiceNo_Cursor INTO @CreditNoteNo, @InvoiceNo,@VisitTypeID, @ItemCode, @ItemCategoryID
	END
CLOSE UpdateCreditNoteDetailsVisitNoInvoiceNo_Cursor
deallocate UpdateCreditNoteDetailsVisitNoInvoiceNo_Cursor
go

--------------------------------------------------------------------------------------------------------------------------------------

alter table CreditNoteDetails drop constraint pkCreditNoteNoItemCategoryIDItemCode
go

alter table CreditNoteDetails alter column VisitNo varchar(20) not null
go
alter table CreditNoteDetails alter column InvoiceNo varchar(20) not null
go
alter table CreditNoteDetails alter column ItemCode varchar(20) not null
go
alter table CreditNoteDetails alter column ItemCategoryID varchar(10) not null
go
alter table CreditNoteDetails add  constraint pkCreditNoteNoVisitNoInvoiceNoItemCodeItemCategoryID primary key(CreditNoteNo, VisitNo, InvoiceNo, ItemCode, ItemCategoryID)
go


alter table CreditNote drop column PayNo
go

alter table CreditNoteDetails drop column UnitPrice
go


alter table InvoiceDetails 
add ReturnQuantity int constraint dfReturnQuantityInvoiceDetails default 0,
 ReturnAmount money constraint dfReturnAmountInvoiceDetails default 0
 go


 /************************************************************************************************************************/


alter table InvoiceExtraBillItems 
add ReturnQuantity int constraint dfReturnQuantityInvoiceExtraBillItems default 0,
 ReturnAmount money constraint dfReturnAmountInvoiceExtraBillItems default 0
 go

 
 
 
-------------- Insert CreditNoteExtraBillItems -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertCreditNoteExtraBillItems')
	drop proc uspInsertCreditNoteExtraBillItems
go

create proc uspInsertCreditNoteExtraBillItems(
@CreditNoteNo varchar(20),
@ExtraBillNo varchar(20),
@InvoiceNo varchar(20),
@ItemCode varchar(20),
@ItemCategoryID varchar(10),
@ReturnReasonID varchar(10),
@Quantity int,
@Amount money,
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)
declare @CreditNoteEntryLevelID varchar(10)
declare @EntryLevelID varchar(10)

set @EntryLevelID = (select EntryLevelID from CreditNote where CreditNoteNo = @CreditNoteNo)
set @CreditNoteEntryLevelID = dbo.GetLookupDataID('DocumentType', 'CRDNT')

if not exists(select CreditNoteNo from CreditNote where CreditNoteNo  = @CreditNoteNo)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Credit Note No', @CreditNoteNo, 'CreditNote')
		return 1
	end

if exists(select CreditNoteNo from CreditNoteExtraBillItems where CreditNoteNo = @CreditNoteNo and ExtraBillNo = @ExtraBillNo and InvoiceNo = @InvoiceNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s and %s: %s and %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Credit Note No', @CreditNoteNo, 'Extra Bill No', @ExtraBillNo, 'Invoice No', @InvoiceNo, 'Item Code', @ItemCode, 'Item Category ID', @ItemCategoryID)
		return 1
	end

if not exists(select InvoiceNo from InvoiceExtraBillItems where  ExtraBillNo = @ExtraBillNo and InvoiceNo = @InvoiceNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s and %s: %s and %s: %s, you are trying to enter does not exists in registered %s'
		raiserror(@ErrorMSG, 16, 1,  'Extra Bill No', @ExtraBillNo, 'Invoice No', @InvoiceNo, 'Item Code', @ItemCode, 'Item Category ID', @ItemCategoryID, 'Invoice Bill Form')
		return 1
	end


if not exists(select DataID from LookupData where DataID = @ReturnReasonID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Return Reason ID', @ReturnReasonID, 'Lookup Data')
		return 1
	end

if not exists(select LoginID from Logins where LoginID  = @LoginID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'LoginID', @LoginID, 'Logins')
		return 1
	end

	if exists(select top 1 ReceiptNo from PaymentExtraBillItems where ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID) and @EntryLevelID = @CreditNoteEntryLevelID
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s, you are trying to enter is already paid and can''t be saved. A Credit Note will be made when a refund is made'
		raiserror(@ErrorMSG, 16, 1, 'Extra Bill No', @ExtraBillNo, 'Item Code', @ItemCode, 'Item Category ID', @ItemCategoryID)
		return 1
	end

begin
	begin tran
	insert into CreditNoteExtraBillItems
	(CreditNoteNo, ExtraBillNo, InvoiceNo, ItemCode, ItemCategoryID, ReturnReasonID, Quantity, Amount, LoginID, ClientMachine)
	values
	(@CreditNoteNo, @ExtraBillNo, @InvoiceNo, @ItemCode, @ItemCategoryID, @ReturnReasonID, @Quantity, @Amount, @LoginID, @ClientMachine)
	
	update InvoiceExtraBillItems set ReturnQuantity =  dbo.GetCreditNoteIPDQuantity(InvoiceNo, ExtraBillNo, ItemCategoryID, ItemCode),
	ReturnAmount = dbo.GetCreditNoteIPDAmount(InvoiceNo, ExtraBillNo, ItemCategoryID, ItemCode)
	where ExtraBillNo = @ExtraBillNo and InvoiceNo = @InvoiceNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
	
	if @@error > 0
	begin
		rollback tran
		return 1		
	end
	commit tran
return 0
end
go


-----------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @CreditNoteNo varchar(20)
declare @VisitNo varchar(20)
declare @InvoiceNo varchar(20)
declare @ItemCategoryID varchar(20)
declare @ItemCode varchar(20)
declare @Quantity int
declare @Amount money
declare @ReturnReasonID varchar(10)
declare @LoginID varchar(20)
declare @ClientMachine varchar(40)
declare @ExtraBillNo varchar(20)
declare @RecordDateTime smalldatetime

DECLARE InsertCreditNoteExtraBillItems_Cursor INSENSITIVE CURSOR FOR

SELECT CreditNoteDetails.CreditNoteNo, VisitNo, CreditNoteDetails.InvoiceNo, ItemCategoryID, ItemCode, Quantity, CreditNoteDetails.Amount, ReturnReasonID, CreditNoteDetails.LoginID, CreditNoteDetails.ClientMachine, CreditNoteDetails.RecordDateTime from CreditNoteDetails 
inner join CreditNote on CreditNote.CreditNoteNo = CreditNoteDetails.creditNoteNo where VisitTypeID = '110IPD'


OPEN InsertCreditNoteExtraBillItems_Cursor
FETCH NEXT FROM InsertCreditNoteExtraBillItems_Cursor INTO @CreditNoteNo, @VisitNo, @InvoiceNo, @ItemCategoryID, @ItemCode, @Quantity, @Amount, @ReturnReasonID, @LoginID, @ClientMachine, @RecordDateTime
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		set @ExtraBillNo = (select top 1 ExtrabillNo from ExtraBills where VisitNo = @VisitNo)
		
		begin try
		  begin tran
		  exec uspInsertCreditNoteExtraBillItems @CreditNoteNo, @ExtraBillNo, @InvoiceNo, @ItemCode,
           @ItemCategoryID, @ReturnReasonID, @Quantity, @Amount, @LoginID ,@ClientMachine,@RecordDateTime
		   
		   delete from CreditNoteDetails where InvoiceNo = @InvoiceNo and VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID 

		  commit tran
		end try
		
		begin catch
		rollback tran
		end catch
		

		FETCH NEXT FROM InsertCreditNoteExtraBillItems_Cursor INTO @CreditNoteNo, @VisitNo, @InvoiceNo, @ItemCategoryID, @ItemCode, @Quantity, @Amount, @ReturnReasonID, @LoginID, @ClientMachine, @RecordDateTime
	END
CLOSE InsertCreditNoteExtraBillItems_Cursor
deallocate InsertCreditNoteExtraBillItems_Cursor
go
--- End Cursor----------------------------------


alter table CreditNoteDetails add  constraint fkInvoiceNoVisitNoItemCodeItemCategoryIDCreditNoteDetails 
foreign key (InvoiceNo, VisitNo, ItemCode, ItemCategoryID) 
references InvoiceDetails (InvoiceNo, VisitNo, ItemCode, ItemCategoryID) on update cascade
go


-------------- Insert BillReturns -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertBillReturns')
	drop proc uspInsertBillReturns
go

create proc uspInsertBillReturns(
@ReturnNo varchar(20),
@BillNo varchar(20),
@ReturnDate smalldatetime,
@VisitTypeID varchar(10),
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)
declare @ReturnID int

if exists(select ReturnNo from BillReturns where ReturnNo = @ReturnNo)
	begin
		set @ErrorMSG = 'The record with %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Return No', @ReturnNo)
		return 1
	end

if not exists(select DataID from LookupData where DataID = @VisitTypeID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Visit Type ID', @VisitTypeID, 'Lookup Data')
		return 1
	end

if not exists(select LoginID from Logins where LoginID  = @LoginID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'LoginID', @LoginID, 'Logins')
		return 1
	end

begin
set @ReturnID = (select max(ReturnID) from BillReturns where BillNo = @BillNo)
	set @ReturnID = dbo.GetNextAutoNumber('BillReturns', 'ReturnNo', @ReturnID)
insert into BillReturns
(ReturnID, ReturnNo, BillNo, ReturnDate, VisitTypeID, LoginID, ClientMachine)
values
(@ReturnID, @ReturnNo, @BillNo, @ReturnDate, @VisitTypeID, @LoginID, @ClientMachine)
return 0
end
go


-------------- Edit ReturnedItems -----------------------------------------------------------
----- Kindly run this as a block
if exists (select * from sysobjects where name = 'uspEditReturnedItems')
	drop proc uspEditReturnedItems
go

create proc uspEditReturnedItems(
@ReturnNo varchar(20),
@VisitNo varchar(20),
@ItemCode varchar(20),
@ItemCategoryID varchar(10),
@ReturnDate smalldatetime,
@Quantity int,
@EntryLevelID varchar(10),
@Notes varchar(200),
@Amount money,
@NewPrice money,
@Acknowledgeable bit,
@IsAcknowledged bit = 0,
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)
declare @PaidPayStatusID varchar(10)

declare @OfferedItemStatusID varchar(10)
declare @TransactionDate smallDatetime
declare @OPDEntryLevel varchar(10)
declare @RefundEntryLevel varchar(10)
declare @CreditNoteEntryLevel varchar(10)
declare @ReturnedQuantity int
declare @ConsumedQuantity int
declare @QuantityBalance int
--------------------------------------------------------------------------------------------------
set @PaidPayStatusID = dbo.GetLookupDataID('PayStatus', 'PF')
set @OfferedItemStatusID = dbo.GetLookupDataID('ItemStatus', 'O')
set @TransactionDate = getDate()
set @OPDEntryLevel=dbo.GetLookupDataID('DocumentType', 'OPDR')
set @RefundEntryLevel=dbo.GetLookupDataID('DocumentType', 'REF')
set @CreditNoteEntryLevel=dbo.GetLookupDataID('DocumentType', 'CRDNT')
set @ConsumedQuantity= (select Quantity from Items where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)                  
set @QuantityBalance = @ConsumedQuantity-@Quantity
--------------------------------------------------------------------------------------------------

if not exists(select VisitNo from Items where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Visit No', @VisitNo, 'Item Code', @ItemCode, 'Item Category', @ItemCategoryID, 'Items')
		return 1
	end

if not exists(select LoginID from Logins where LoginID  = @LoginID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Login ID', @LoginID, 'Logins')
		return 1
	end
	
------------------------------------------------------------------------------------------------------------------------------

if  exists(select VisitNo from Items where VisitNo = @VisitNo and ItemCode = @ItemCode and 
				ItemCategoryID = @ItemCategoryID and PayStatusID = @PaidPayStatusID) 
				 and not @EntryLevelID = @RefundEntryLevel
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: ' + dbo.GetLookupDataDes(@ItemCategoryID) + ', is already paid for. It will be auto saved when a refund is made at cashier. You can''t save this record.'
		raiserror(@ErrorMSG, 16, 1, 'Visit No', @VisitNo, 'Item Code', @ItemCode, 'Item Category')
		return 1
	end

	if  exists(select ItemCode from InvoiceDetails where VisitNo = @VisitNo and ItemCode = @ItemCode and 
				ItemCategoryID = @ItemCategoryID)
				 and not (@EntryLevelID = @RefundEntryLevel or @EntryLevelID = @CreditNoteEntryLevel )
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: ' + dbo.GetLookupDataDes(@ItemCategoryID) + ',  is already invoiced. It will be auto saved when the Credit Note is made against its Invoice. You can''t save this record.'
		raiserror(@ErrorMSG, 16, 1, 'Visit No', @VisitNo, 'Item Code', @ItemCode, 'Item Category')
		return 1
	end

if not exists(select VisitNo from Items where VisitNo = @VisitNo and ItemCode = @ItemCode and 
				ItemCategoryID = @ItemCategoryID and ItemStatusID = @OfferedItemStatusID) and @EntryLevelID = @OPDEntryLevel
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: ' + dbo.GetLookupDataDes(@ItemCategoryID) + ', is not an offered item. You can''t save this record.'
		raiserror(@ErrorMSG, 16, 1, 'Visit No', @VisitNo, 'Item Code', @ItemCode, 'Item Category')
		return 1
	end

if  @ReturnedQuantity > @ConsumedQuantity
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: ' + dbo.GetLookupDataDes(@ItemCategoryID) + ', can''t have more returned than dispensed items .'
		raiserror(@ErrorMSG, 16, 1, 'Visit No', @VisitNo, 'Item Code', @ItemCode, 'Item Category')
		return 1
	end		
------------------------------------------------------------------------------------------------------------------------------

	begin
		insert into ReturnedItems
		(ReturnNo,VisitNo, ItemCode, ItemCategoryID, ReturnDate, Quantity,EntryLevelID, Notes, Amount, Acknowledgeable, IsAcknowledged, LoginID, ClientMachine)
		values
		(@ReturnNo,@VisitNo, @ItemCode, @ItemCategoryID, @ReturnDate, @Quantity,@EntryLevelID, @Notes,@Amount, @Acknowledgeable, @IsAcknowledged, @LoginID, @ClientMachine)
		
		return 0
	end
go



--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor



declare @CreditNoteNo varchar(20)
declare @VisitNo varchar(20)
declare @InvoiceNo varchar(20)
declare @ItemCategoryID varchar(20)
declare @ItemCode varchar(20)
declare @Quantity int
declare @Amount money
declare @ReturnReasonID varchar(10)
declare @CreditNoteDate smalldatetime
declare @EntryLevelID varchar(10)
declare @LoginID varchar(20)
declare @ClientMachine varchar(40)
declare @ExtraBillNo varchar(20)
declare @RecordDateTime smalldatetime
declare @Notes varchar(100)
declare @ReturnNo varchar(20)
declare @NewPrice money

declare @ReturnID int
declare @PaddingLEN int
declare @PadChar char

select  @PadChar= PaddingCHAR from AutoNumbers where ObjectName = 'BillReturns' and AutoColumnName = 'ReturnNo'
select @PaddingLEN = PaddingLEN from AutoNumbers where ObjectName = 'BillReturns' and AutoColumnName = 'ReturnNo'

DECLARE InsertReturnedItems_Cursor INSENSITIVE CURSOR FOR

SELECT CreditNoteDetails.CreditNoteNo, VisitNo, CreditNoteDetails.InvoiceNo, ItemCategoryID, ItemCode, Quantity, CreditNoteDetails.Amount, ReturnReasonID, CreditNoteDate, EntryLevelID, CreditNoteDetails.LoginID, CreditNoteDetails.ClientMachine, CreditNoteDetails.RecordDateTime from CreditNoteDetails 
inner join CreditNote on CreditNote.CreditNoteNo = CreditNoteDetails.creditNoteNo where VisitTypeID = '110OPD' and  not ItemCategoryID in ('7D', '7C')


OPEN InsertReturnedItems_Cursor
FETCH NEXT FROM InsertReturnedItems_Cursor INTO @CreditNoteNo, @VisitNo, @InvoiceNo, @ItemCategoryID, @ItemCode, @Quantity, @Amount, @ReturnReasonID, @CreditNoteDate,@EntryLevelID, @LoginID, @ClientMachine, @RecordDateTime
WHILE (@@FETCH_STATUS <> -1)
	BEGIN

	    set @ReturnID = (select max(ReturnID) from BillReturns where BillNo = @VisitNo)
		set @ReturnID = dbo.GetNextAutoNumber('BillReturns', 'ReturnNo', @ReturnID)
		set @ReturnNo= @VisitNo+ dbo.PadLeft(@ReturnID, @PaddingLEN)
		set @Notes = dbo.GetLookupDataDes(@ReturnReasonID)
		set @NewPrice = (select UnitPrice from Items where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)

		exec uspInsertBillReturns @ReturnNo,@VisitNo,@CreditNoteDate,'110OPD',@LoginID,@ClientMachine 
        
		exec uspEditReturnedItems @ReturnNo,@VisitNo, @ItemCode,@ItemCategoryID, @CreditNoteDate, @Quantity, @EntryLevelID,
		@Notes ,@Amount,@NewPrice, 0,0, @LoginID, @ClientMachine
		
		FETCH NEXT FROM InsertReturnedItems_Cursor INTO @CreditNoteNo, @VisitNo, @InvoiceNo, @ItemCategoryID, @ItemCode, @Quantity, @Amount, @ReturnReasonID, @CreditNoteDate, @EntryLevelID, @LoginID, @ClientMachine, @RecordDateTime
	END
CLOSE InsertReturnedItems_Cursor
deallocate InsertReturnedItems_Cursor
go

--- End Cursor----------------------------------

--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @CreditNoteNo varchar(20)
declare @InvoiceNo varchar(20)
declare @ItemCategoryID varchar(20)
declare @ItemCode varchar(20)
declare @Quantity int
declare @Amount money
declare @ReturnReasonID varchar(10)
declare @CreditNoteDate smalldatetime
declare @EntryLevelID varchar(10)
declare @LoginID varchar(20)
declare @ClientMachine varchar(40)
declare @ExtraBillNo varchar(20)
declare @RecordDateTime smalldatetime
declare @Notes varchar(100)
declare @ReturnNo varchar(20)

declare @ReturnID int
declare @PaddingLEN int
declare @PadChar char
declare @NewPrice money

select  @PadChar= PaddingCHAR from AutoNumbers where ObjectName = 'BillReturns' and AutoColumnName = 'ReturnNo'
select @PaddingLEN = PaddingLEN from AutoNumbers where ObjectName = 'BillReturns' and AutoColumnName = 'ReturnNo'

DECLARE InsertReturnedItems_Cursor INSENSITIVE CURSOR FOR

SELECT CreditNoteExtraBillItems.CreditNoteNo, ExtraBillNo, CreditNoteExtraBillItems.InvoiceNo, ItemCategoryID, ItemCode, Quantity, CreditNoteExtraBillItems.Amount, ReturnReasonID, CreditNoteDate, EntryLevelID, CreditNoteExtraBillItems.LoginID, CreditNoteExtraBillItems.ClientMachine, CreditNoteExtraBillItems.RecordDateTime 
from CreditNoteExtraBillItems 
inner join CreditNote on CreditNote.CreditNoteNo = CreditNoteExtraBillItems.creditNoteNo where VisitTypeID = '110IPD' and  not ItemCategoryID in ('7D', '7C')


OPEN InsertReturnedItems_Cursor
FETCH NEXT FROM InsertReturnedItems_Cursor INTO @CreditNoteNo, @ExtraBillNo, @InvoiceNo, @ItemCategoryID, @ItemCode, @Quantity, @Amount, @ReturnReasonID, @CreditNoteDate,@EntryLevelID, @LoginID, @ClientMachine, @RecordDateTime
WHILE (@@FETCH_STATUS <> -1)
	BEGIN

	    set @ReturnID = (select max(ReturnID) from BillReturns where BillNo = @ExtraBillNo)
		set @ReturnID = dbo.GetNextAutoNumber('BillReturns', 'ReturnNo', @ReturnID)
		set @ReturnNo= @ExtraBillNo+ dbo.PadLeft(@ReturnID, @PaddingLEN)
		set @Notes = dbo.GetLookupDataDes(@ReturnReasonID)
		set @NewPrice = (select UnitPrice from ExtraBillItems where ExtraBillItems.ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
		
		exec uspInsertBillReturns @ReturnNo,@ExtraBillNo,@CreditNoteDate,'110IPD',@LoginID,@ClientMachine 
        

		 exec uspEditReturnedExtraBillItems @ReturnNo, @ExtraBillNo,@ItemCode,@ItemCategoryID,@CreditNoteDate,@Quantity,@Amount, @NewPrice,
		 0,@EntryLevelID, @Notes, @LoginID, @ClientMachine

		
		FETCH NEXT FROM InsertReturnedItems_Cursor INTO @CreditNoteNo, @ExtraBillNo, @InvoiceNo, @ItemCategoryID, @ItemCode, @Quantity, @Amount, @ReturnReasonID, @CreditNoteDate, @EntryLevelID, @LoginID, @ClientMachine, @RecordDateTime
	END
CLOSE InsertReturnedItems_Cursor
deallocate InsertReturnedItems_Cursor
go
--- End Cursor----------------------------------
---------------------------------------------------21-July-2018 --------------------------------------------------

alter table Items 
add ReturnQuantity int constraint dfReturnQuantityItems default 0,
 ReturnAmount money constraint dfReturnAmountItems default 0
 go

 
-------------- Edit ReturnedExtraBillItems -----------------------------------------------------------
-------------- Kindly run this as a block
if exists (select * from sysobjects where name = 'uspEditReturnedExtraBillItems')
	drop proc uspEditReturnedExtraBillItems
go

create proc uspEditReturnedExtraBillItems(
@ReturnNo varchar(20),
@ExtraBillNo varchar(20),
@ItemCode varchar(20),
@ItemCategoryID varchar(10),
@ReturnDate smalldatetime,
@Quantity int,
@Amount money,
@NewPrice money,
@Acknowledgeable bit,
@EntryLevelID varchar(10),
@Notes varchar(200),
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)
declare @PaidPayStatusID varchar(10)
declare @SystemEntryModeID varchar(10)


declare @TransactionDate smallDatetime
declare @BillFormReturnsEntryLevel varchar(10)
declare @RefundEntryLevel varchar(10)
declare @CreditNoteEntryLevel varchar(10)
declare @ReturnedItems int
declare @ConsumedItems int
declare @QuantityBalance int
--------------------------------------------------------------------------------------------------
set @PaidPayStatusID = dbo.GetLookupDataID('PayStatus', 'PF')
set @SystemEntryModeID = dbo.GetLookupDataID('EntryMode', 'SYS')
set @TransactionDate = getDate()
set @BillFormReturnsEntryLevel=dbo.GetLookupDataID('DocumentType', 'BFR')
set @RefundEntryLevel=dbo.GetLookupDataID('DocumentType', 'REF')
set @CreditNoteEntryLevel=dbo.GetLookupDataID('DocumentType', 'CRDNT')
set @ConsumedItems= (select Quantity from ExtraBillItems where ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)                  
set @QuantityBalance = @ConsumedItems - @Quantity
--------------------------------------------------------------------------------------------------

if not exists(select ExtraBillNo from ExtraBillItems where ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s and %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1,  'Extra Bill No', @ExtraBillNo, 'Item Code', @ItemCode, 'Item Category', @ItemCategoryID, 'Extra Bill Items')
		return 1
	end

if not exists(select DataID from LookupData where DataID  = @EntryLevelID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'EntryLevelID', @EntryLevelID, 'LookupData')
		return 1
	end

if not exists(select LoginID from Logins where LoginID  = @LoginID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Login ID', @LoginID, 'Logins')
		return 1
	end
	
------------------------------------------------------------------------------------------------------------------------------

if  exists(select ExtraBillNo from ExtraBillItems where ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and
				ItemCategoryID = @ItemCategoryID and PayStatusID = @PaidPayStatusID)
				 and not @EntryLevelID=@RefundEntryLevel
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: ' + dbo.GetLookupDataDes(@ItemCategoryID) + ', 
		is already paid for. This record will be auto saved when the item is refunded at Cashier. You can''t save this record.'
		raiserror(@ErrorMSG, 16, 1, 'Extra Bill No', @ExtraBillNo, 'Item Code', @ItemCode, 'Item Category')
		return 1
	end

	if  exists(select ExtraBillNo from InvoiceExtraBillItems where ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and 
				ItemCategoryID = @ItemCategoryID)
				 and not (@EntryLevelID=@RefundEntryLevel or @EntryLevelID=@CreditNoteEntryLevel )
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: ' + dbo.GetLookupDataDes(@ItemCategoryID) + ', is already invoiced. It will be auto saved when the item is a Credit Note is made against its Invoice. You can''t save this record.'
		raiserror(@ErrorMSG, 16, 1, 'Extra Bill No', @ExtraBillNo, 'Item Code', @ItemCode, 'Item Category')
		return 1
	end



if @Quantity>@ConsumedItems
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: ' + dbo.GetLookupDataDes(@ItemCategoryID) + ', has more returned items than consumed item.'
		raiserror(@ErrorMSG, 16, 1, 'Extra Bill No', @ExtraBillNo, 'Item Code', @ItemCode, 'Item Category')
		return 1
	end		
-------------------------------------------------------------------------------------------------------
begin

insert into ReturnedExtraBillItems
(ReturnNo,ExtraBillNo, ItemCode, ItemCategoryID, ReturnDate, Quantity, Amount, Acknowledgeable, EntryLevelID, Notes, LoginID, ClientMachine)
values
(@ReturnNo,@ExtraBillNo, @ItemCode, @ItemCategoryID, @ReturnDate, @Quantity, @Amount, @Acknowledgeable, @EntryLevelID, @Notes, @LoginID, @ClientMachine)

end
go


 alter table RefundRequests add VisitTypeID varchar(10) constraint fkVisitTypeIDRefundRequests references LookupData (DataID)
 go

 --------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @RefundRequestNo varchar(20)
declare @ReceiptNo varchar(20)
declare @VisitTypeID varchar(10)

DECLARE UpdateRefundRequestVisitTypeID_Cursor INSENSITIVE CURSOR FOR

SELECT RefundRequests.RefundRequestNo, RefundRequests.ReceiptNo,  Payments.VisitTypeID from RefundRequests 
inner join Payments on Payments.ReceiptNo =RefundRequests.ReceiptNo



OPEN UpdateRefundRequestVisitTypeID_Cursor
FETCH NEXT FROM UpdateRefundRequestVisitTypeID_Cursor INTO @RefundRequestNo, @ReceiptNo, @VisitTypeID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE RefundRequests Set VisitTypeID = @VisitTypeID WHERE  RefundRequestNo = @RefundRequestNo
		

		FETCH NEXT FROM UpdateRefundRequestVisitTypeID_Cursor INTO @RefundRequestNo, @ReceiptNo, @VisitTypeID
	END
CLOSE UpdateRefundRequestVisitTypeID_Cursor
deallocate UpdateRefundRequestVisitTypeID_Cursor
go
----- End Cursor Block ---------------------------------------------------------------------

alter table RefundRequestDetails add VisitNo varchar(20),ReceiptNo varchar(20)
go

----------------------------- 1-Aug -2018 ------------------------------------------------------------------

create table RefundRequestExtraBillItems
(RefundRequestNo varchar(20) not null
constraint fkRefundRequestNoRefundRequestExtraBillItems references RefundRequests (RefundRequestNo),
ExtraBillNo varchar(20) not null,
ReceiptNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10)
constraint fkItemCategoryIDRefundRequestExtraBillItems references LookupData (DataID),
constraint pkRefundRequestNoExtraBillNoReceiptNoItemCodeItemCategoryID primary key(RefundRequestNo, ExtraBillNo, ReceiptNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDRefundRequestExtraBillItems references LookupData (DataID),
Quantity int,
Amount money,
NewPrice money,
LoginID varchar(20)
constraint fkLoginIDRefundRequestExtraBillItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundRequestExtraBillItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundRequestExtraBillItems default getdate()
)
go

create table RefundExtraBillItems
(RefundNo varchar(20) not null
constraint fkRefundNoRefundExtraBillItems references Refunds (RefundNo),
ExtraBillNo varchar(20) not null,
ReceiptNo varchar(20) not null,
ItemCode varchar(20) not null,
ItemCategoryID varchar(10)
constraint fkItemCategoryIDRefundExtraBillItems references LookupData (DataID),
constraint fkReceiptNoExtraBillNoItemCodeItemCategoryIDCreditNoteExtraBillItems foreign key (ReceiptNo, ExtraBillNo, ItemCode, ItemCategoryID)
references PaymentExtraBillItems (ReceiptNo, ExtraBillNo, ItemCode, ItemCategoryID) on update cascade,
constraint pkRefundNoExtraBillNoReceiptNoItemCodeItemCategoryID primary key(RefundNo, ExtraBillNo, ReceiptNo, ItemCode, ItemCategoryID),
ReturnReasonID varchar(10)
constraint fkReturnReasonIDRefundExtraBillItems references LookupData (DataID),
Quantity int,
Amount money,
LoginID varchar(20)
constraint fkLoginIDRefundExtraBillItems references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundExtraBillItems default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundExtraBillItems default getdate()
)
go

--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor

declare @RefundRequestNo varchar(20)
declare @ReceiptNo varchar(20)
declare @VisitNo varchar(10)



DECLARE UpdateRefundRequestDetailsVisitNoReceiptNo_Cursor INSENSITIVE CURSOR FOR

SELECT RefundRequestDetails.RefundRequestNo, RefundRequests.ReceiptNo, RefundRequests.VisitNo 
from RefundRequestDetails
inner join RefundRequests on RefundRequests.RefundRequestNo = RefundRequestDetails.RefundRequestNo



OPEN UpdateRefundRequestDetailsVisitNoReceiptNo_Cursor
FETCH NEXT FROM UpdateRefundRequestDetailsVisitNoReceiptNo_Cursor INTO @RefundRequestNo, @ReceiptNo, @VisitNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE RefundRequestDetails Set VisitNo = @VisitNo, ReceiptNo = @ReceiptNo WHERE  RefundRequestNo = @RefundRequestNo
		

		FETCH NEXT FROM UpdateRefundRequestDetailsVisitNoReceiptNo_Cursor INTO @RefundRequestNo, @ReceiptNo, @VisitNo
	END
CLOSE UpdateRefundRequestDetailsVisitNoReceiptNo_Cursor
deallocate UpdateRefundRequestDetailsVisitNoReceiptNo_Cursor
go
----- End Cursor Block ---------------------------------------------------------------------



alter table RefundRequests drop constraint fkVisitNoRefundRequests
go
alter table RefundRequests drop column VisitNo
go

alter table RefundRequestDetails add
LoginID varchar(20)
constraint fkLoginIDRefundRequestDetails references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineRefundRequestDetails default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeRefundRequestDetails default getdate()
go

alter table Refunds add VisitTypeID varchar(10) constraint fkVisitTypeIDRefunds references LookupData (DataID)
 go

alter table RefundDetails add Amount money
go

update RefundDetails set Amount = UnitPrice*Quantity where Amount is null
go

alter table RefundDetails drop column UnitPrice
go

alter table RefundDetails add VisitNo varchar(20)
go


 --------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @RefundNo varchar(20)
declare @ReceiptNo varchar(20)
declare @VisitTypeID varchar(10)

DECLARE UpdateRefundVisitTypeID_Cursor INSENSITIVE CURSOR FOR

SELECT RefundNo, Refunds.ReceiptNo,  Payments.VisitTypeID from Refunds 
inner join Payments on Payments.ReceiptNo =Refunds.ReceiptNo



OPEN UpdateRefundVisitTypeID_Cursor
FETCH NEXT FROM UpdateRefundVisitTypeID_Cursor INTO @RefundNo, @ReceiptNo, @VisitTypeID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		UPDATE Refunds Set VisitTypeID = @VisitTypeID WHERE  RefundNo = @RefundNo
		

		FETCH NEXT FROM UpdateRefundVisitTypeID_Cursor INTO @RefundNo, @ReceiptNo, @VisitTypeID
	END
CLOSE UpdateRefundVisitTypeID_Cursor
deallocate UpdateRefundVisitTypeID_Cursor
go
----- End Cursor Block ---------------------------------------------------------------------

--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @RefundNo varchar(20)
declare @ReceiptNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)
declare @VisitTypeID varchar(10)
declare @VisitNo varchar(20)

DECLARE UpdateRefundDetailsVisitNo_Cursor INSENSITIVE CURSOR FOR

SELECT Refunds.RefundNo, Refunds.ReceiptNo, VisitTypeID, ItemCode, ItemCategoryID 
from RefundDetails 
inner join Refunds on Refunds.RefundNo = RefundDetails.RefundNo

OPEN UpdateRefundDetailsVisitNo_Cursor
FETCH NEXT FROM UpdateRefundDetailsVisitNo_Cursor INTO @RefundNo, @ReceiptNo, @VisitTypeID, @ItemCode, @ItemCategoryID
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		
		if @VisitTypeID = '110OPD'
		  begin
			 set @VisitNo = (select top 1 VisitNo from PaymentDetails 
			 where ReceiptNo = @ReceiptNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
		  end
		  else if @VisitTypeID = '110IPD'
		  begin
			 set @VisitNo = (select top 1 VisitNo from PaymentExtraBillItems
			 inner join ExtraBills on ExtraBills.ExtraBillNo = PaymentExtraBillItems.ExtraBillNo 
			 where ReceiptNo = @ReceiptNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
		  end
		
		UPDATE RefundDetails set VisitNo = @VisitNo, ReceiptNo = @ReceiptNo   WHERE
		 RefundNo = @RefundNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
		
		FETCH NEXT FROM UpdateRefundDetailsVisitNo_Cursor INTO @RefundNo, @ReceiptNo, @VisitTypeID, @ItemCode, @ItemCategoryID
	END
CLOSE UpdateRefundDetailsVisitNo_Cursor
deallocate UpdateRefundDetailsVisitNo_Cursor
go

------------------------------------
----------- Kindly run this as a block
-------------- Insert RefundExtraBillItems -------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspInsertRefundExtraBillItems')
	drop proc uspInsertRefundExtraBillItems
go

create proc uspInsertRefundExtraBillItems(
@RefundNo varchar(20),
@ExtraBillNo varchar(20),
@ReceiptNo varchar(20),
@ItemCode varchar(20),
@ItemCategoryID varchar(10),
@ReturnReasonID varchar(10),
@Quantity int,
@Amount money,
@LoginID varchar(20),
@ClientMachine varchar(40)
)with encryption as

declare @ErrorMSG varchar(200)

if not exists(select RefundNo from Refunds where RefundNo  = @RefundNo)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Refund No', @RefundNo, 'Refunds')
		return 1
	end

if not exists(select DataID from LookupData where DataID = @ItemCategoryID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Item Category', @ItemCategoryID, 'Lookup Data')
		return 1
	end

if exists(select RefundNo from RefundExtraBillItems where RefundNo = @RefundNo and ExtraBillNo = @ExtraBillNo and ReceiptNo = @ReceiptNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s and %s: %s and %s: %s, you are trying to enter already exists'
		raiserror(@ErrorMSG, 16, 1, 'Refund No', @RefundNo, 'Extra Bill No', @ExtraBillNo, 'Receipt No', @ReceiptNo, 'Item Code', @ItemCode, 'Item Category', @ItemCategoryID)
		return 1
	end

if not exists(select ReceiptNo from PaymentExtraBillItems where ReceiptNo = @ReceiptNo and ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
	begin
		set @ErrorMSG = 'The record with %s: %s and %s: %s and %s: %s and %s: %s and %s: %s, you are trying to enter does not exist in registered %s'
		raiserror(@ErrorMSG, 16, 1, 'Receipt No', @ReceiptNo, 'Extra Bill No', @ExtraBillNo, 'Item Code', @ItemCode, 'Item Category', @ItemCategoryID, 'Bill Form Payments')
		return 1
	end

if not exists(select LoginID from Logins where LoginID  = @LoginID)
	begin
		set @ErrorMSG = 'The %s: %s, you are trying to enter does not exist in the registered %s'
		raiserror(@ErrorMSG, 16, 1, 'LoginID', @LoginID, 'Logins')
		return 1
	end

begin
insert into RefundExtraBillItems
(RefundNo, ExtraBillNo, ReceiptNo, ItemCode, ItemCategoryID, ReturnReasonID, Quantity, Amount, LoginID, ClientMachine)
values
(@RefundNo, @ExtraBillNo, @ReceiptNo, @ItemCode, @ItemCategoryID, @ReturnReasonID, @Quantity, @Amount, @LoginID, @ClientMachine)
return 0
end
go

--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor


declare @RefundNo varchar(20)
declare @VisitNo varchar(20)
declare @ReceiptNo varchar(20)
declare @ItemCategoryID varchar(20)
declare @ItemCode varchar(20)
declare @Quantity int
declare @Amount money
declare @ReturnReasonID varchar(10)
declare @LoginID varchar(20)
declare @ClientMachine varchar(40)
declare @ExtraBillNo varchar(20)
declare @RecordDateTime smalldatetime

DECLARE InsertRefundExtraBillItems_Cursor INSENSITIVE CURSOR FOR

SELECT RefundDetails.RefundNo, VisitNo, RefundDetails.ReceiptNo, ItemCategoryID, ItemCode, Quantity, RefundDetails.Amount, ReturnReasonID, RefundDetails.LoginID, RefundDetails.ClientMachine, RefundDetails.RecordDateTime 
from RefundDetails 
inner join Refunds on Refunds.RefundNo = RefundDetails.RefundNo where VisitTypeID = '110IPD'


OPEN InsertRefundExtraBillItems_Cursor
FETCH NEXT FROM InsertRefundExtraBillItems_Cursor INTO @RefundNo, @VisitNo, @ReceiptNo, @ItemCategoryID, @ItemCode, @Quantity, @Amount, @ReturnReasonID, @LoginID, @ClientMachine, @RecordDateTime
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		set @ExtraBillNo = (select top 1 ExtrabillNo from ExtraBills where VisitNo = @VisitNo)
		
		begin try
		  begin tran
		  exec uspInsertRefundExtraBillItems @RefundNo, @ExtraBillNo, @ReceiptNo, @ItemCode, @ItemCategoryID, @ReturnReasonID, @Quantity, @Amount, @LoginID, @ClientMachine

		  delete from RefundDetails where ReceiptNo = @ReceiptNo and VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID 

		  commit tran
		end try
		
		begin catch
		rollback tran
		end catch
		

		FETCH NEXT FROM InsertRefundExtraBillItems_Cursor INTO @RefundNo, @VisitNo, @ReceiptNo, @ItemCategoryID, @ItemCode, @Quantity, @Amount, @ReturnReasonID, @LoginID, @ClientMachine, @RecordDateTime
	END
CLOSE InsertRefundExtraBillItems_Cursor
deallocate InsertRefundExtraBillItems_Cursor
go


--- End Cursor----------------------------------


---------------------------------------------------------- 3 Aug 2018 -----------------------------------------

drop function GetPreviousRefundAmount
go
drop function GetPreviousRefundQuantity
go 
drop function GetReversedItemQuantity
go
drop function GetInvoiceReversedQuantity
go

drop function GetReversedIPDItemQuantity
	go
drop function  GetInvoiceReversedItemQuantity
go
drop function  GetInvoiceReversedItemAmount
go


drop function GetItemInvoiceNo
go

alter table Items drop constraint fkInvoiceNoItems
go
alter table ExtraBillItems drop constraint fkInvoiceNoExtraBillItems
go
update Items set InvoiceNo = '' where InvoiceNo is null
go

update ExtraBillItems set InvoiceNo = '' where InvoiceNo is null
go

alter table Items add constraint dfInvoiceNoItems default '' for InvoiceNo
go

alter table ExtraBillItems add constraint dfInvoiceNoExtraBillItems default '' for InvoiceNo
go

alter table Items add OriginalQuantity int, OriginalPrice money
go

update Items set OriginalQuantity = Quantity where OriginalQuantity is null
go

update Items set OriginalPrice = UnitPrice where OriginalPrice is null
go

alter table ExtraBillItems add OriginalQuantity int, OriginalPrice money
go

update ExtraBillItems set OriginalQuantity = Quantity where OriginalQuantity is null
go

update ExtraBillItems set OriginalPrice = UnitPrice where OriginalPrice is null
go

alter table IPDItems add OriginalQuantity int, OriginalPrice money
go

update IPDItems set OriginalQuantity = Quantity where OriginalQuantity is null
go

update IPDItems set OriginalPrice = UnitPrice where OriginalPrice is null
go

------- kindly run this as a block


-----------------UpdateIPDItemUnitPriceQuantity--------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateIPDItemUnitPriceQuantity')
drop proc uspUpdateIPDItemUnitPriceQuantity
go

create proc uspUpdateIPDItemUnitPriceQuantity(
@ExtraBillNo varchar(20),
@ItemCode varchar(20),
@ItemCategoryID varchar(10),
@UnitPrice money,
@Quantity int
)with encryption as 

declare @ErrorMSG varchar(200)

declare @RoundNo varchar(20)
declare @NotPaidPayStatusID varchar(10)
declare @PercentCoPayTypeID varchar(10)

declare @CoPayTypeID varchar(10)
declare @CoPayPercent decimal(5,2)
declare @CashAmount money

-----------------------------------------------------------------------------------------------
set @RoundNo = dbo.GetExtraBillRoundNo(@ExtraBillNo)
set @NotPaidPayStatusID = dbo.GetLookupDataID('PayStatus', 'NP')
set @PercentCoPayTypeID = dbo.GetLookupDataID('CoPayType', 'PCT')
-----------------------------------------------------------------------------------------------

			
					 
begin tran 						
				 								
set @CoPayTypeID = (select CoPayTypeID from Visits 
inner join ExtraBills on ExtraBills.ExtraBillNo = Visits.VisitNo
where ExtraBills.ExtraBillNo = @ExtraBillNo)				
														
---------------------------------------------------------------------------------------
update ExtraBillItems set UnitPrice = @UnitPrice, Quantity = @Quantity
where ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID	
													
if not (@RoundNo is null or @RoundNo = '') 
begin					
update IPDItems set UnitPrice = @UnitPrice, Quantity = @Quantity
where RoundNo = @RoundNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID	
end
---------------------------------------------------------------------------------------
if  exists(select ExtraBillNo from ExtraBillItemsCASH 
where ExtraBillNo = @ExtraBillNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
					
begin		
if (@CoPayTypeID = @PercentCoPayTypeID)
begin
set @CoPayPercent = (select CoPayPercent from Visits 
inner join ExtraBills on ExtraBills.ExtraBillNo = Visits.VisitNo
where ExtraBills.ExtraBillNo = @ExtraBillNo)
									
set @CashAmount = (@Quantity * @UnitPrice * @CoPayPercent)/100
set @CashAmount = isnull(@CashAmount, 0)

update ExtraBillItemsCash set CashAmount = @CashAmount
from ExtraBillItemsCash where @ExtraBillNo = @ExtraBillNo 
and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
																		
end
---------------------------------------------------------------------------------------
end				
							
if @@error > 0
begin
rollback tran
return 1		
end
commit tran
						
return 0
		

go

--------run cursor below, as a block--------------------------------------------------------------
-------- Begin Cursor

--------NOTE ::  Kindly run this once

declare @ExtraBillNo varchar(20)
declare @ItemCategoryID varchar(10)
declare @ItemCode varchar(20)
declare @Quantity int
declare @ReturnedItems int
declare @QuantityBalance int
declare @UnitPrice money


DECLARE UpdateExtraBillItemsQuantity_Cursor INSENSITIVE CURSOR FOR

SELECT ExtraBillNo, ItemCategoryID, ItemCode, Quantity, UnitPrice FROM ExtraBillItems


OPEN UpdateExtraBillItemsQuantity_Cursor
FETCH NEXT FROM UpdateExtraBillItemsQuantity_Cursor INTO @ExtraBillNo, @ItemCategoryID, @ItemCode, @Quantity, @UnitPrice
WHILE (@@FETCH_STATUS <> -1)
BEGIN
set @ReturnedItems = (select sum(Quantity) from ReturnedExtraBillItems where ExtraBillNo =@ExtraBillNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
set @ReturnedItems = isnull(@ReturnedItems,0)		
set @QuantityBalance = (@Quantity - @ReturnedItems)
		
exec uspUpdateIPDItemUnitPriceQuantity  @ExtraBillNo, @ItemCode, @ItemCategoryID, @UnitPrice, @QuantityBalance


FETCH NEXT FROM UpdateExtraBillItemsQuantity_Cursor INTO  @ExtraBillNo, @ItemCategoryID, @ItemCode, @Quantity, @UnitPrice
END
CLOSE UpdateExtraBillItemsQuantity_Cursor
deallocate UpdateExtraBillItemsQuantity_Cursor
go
----- End Cursor Block ---------------------------------------------------------------------



------------------------------Run this as a block

-----------------UpdateItemUnitPriceQuantity--------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'uspUpdateItemUnitPriceQuantity')
drop proc uspUpdateItemUnitPriceQuantity
go

create proc uspUpdateItemUnitPriceQuantity(
@VisitNo varchar(20),
@ItemCode varchar(20),
@ItemCategoryID varchar(10),
@UnitPrice money,
@Quantity int
)with encryption as 

declare @ErrorMSG varchar(200)

declare @NotPaidPayStatusID varchar(10)
declare @PercentCoPayTypeID varchar(10)

declare @CoPayTypeID varchar(10)
declare @CoPayPercent decimal(5,2)
declare @CashAmount money

-----------------------------------------------------------------------------------------------
set @NotPaidPayStatusID = dbo.GetLookupDataID('PayStatus', 'NP')
set @PercentCoPayTypeID = dbo.GetLookupDataID('CoPayType', 'PCT')
-----------------------------------------------------------------------------------------------

			
					 
begin tran 						
				 								
set @CoPayTypeID = (select CoPayTypeID from Visits where VisitNo = @VisitNo)				
														
---------------------------------------------------------------------------------------
update Items set UnitPrice = @UnitPrice, Quantity = @Quantity
where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID	
								
update ItemsIncome set UnitPrice = @UnitPrice, Quantity = @Quantity
where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID	
---------------------------------------------------------------------------------------
if  exists(select VisitNo from ItemsCASH 
where VisitNo = @VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
					
begin		
if (@CoPayTypeID = @PercentCoPayTypeID)
begin
set @CoPayPercent = (select CoPayPercent from Visits where VisitNo = @VisitNo)

set @CashAmount = (@Quantity * @UnitPrice * @CoPayPercent)/100
set @CashAmount = isnull(@CashAmount, 0)

update ItemsCash set CashAmount = @CashAmount
from ItemsCash where @VisitNo = @VisitNo 
and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID
																		
end
---------------------------------------------------------------------------------------
end				
							
if @@error > 0
begin
rollback tran
return 1		
end
commit tran
						
return 0
		

go

-------- Begin Cursor
--- Kindly run this a block

declare @VisitNo varchar(20)
declare @ItemCategoryID varchar(10)
declare @ItemCode varchar(20)
declare @Quantity int
declare @ReturnedItems int
declare @QuantityBalance int
declare @UnitPrice money


DECLARE UpdateItemsQuantity_Cursor INSENSITIVE CURSOR FOR

SELECT VisitNo, ItemCategoryID, ItemCode, Quantity, UnitPrice FROM Items


OPEN UpdateItemsQuantity_Cursor
FETCH NEXT FROM UpdateItemsQuantity_Cursor INTO @VisitNo, @ItemCategoryID, @ItemCode, @Quantity, @UnitPrice
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
		set @ReturnedItems = (select sum(Quantity) from ReturnedItems where VisitNo =@VisitNo and ItemCode = @ItemCode and ItemCategoryID = @ItemCategoryID)
		set @ReturnedItems = isnull(@ReturnedItems,0)
		set @QuantityBalance = (@Quantity -@ReturnedItems)
		
		 exec uspUpdateItemUnitPriceQuantity  @VisitNo, @ItemCode, @ItemCategoryID, @UnitPrice, @QuantityBalance


		FETCH NEXT FROM UpdateItemsQuantity_Cursor INTO  @VisitNo, @ItemCategoryID, @ItemCode, @Quantity, @UnitPrice
	END
CLOSE UpdateItemsQuantity_Cursor
deallocate UpdateItemsQuantity_Cursor

----- End Cursor Block ---------------------------------------------------


alter table RefundRequestDetails drop column UnitPrice
go
alter table ReturnedItems drop fkItemTransferStatusReturnedItems
go
alter table ReturnedItems drop column ItemTransferStatus
go

alter table ReturnedExtraBillItems drop fkItemTransferStatusReturnedExtrabillItems
go
alter table ReturnedExtraBillItems drop column ItemTransferStatus
go

-------------------------24 July 2018------------------------

alter table InventoryOrders add
TransferReasonID varchar(10) constraint fkTransferReasonIDInventoryOrders references Lookupdata (DataID)
go



 alter table RefundRequestDetails drop pkRefundRequestNoItemCategoryIDItemCode
 go
 
 alter table RefundRequestDetails alter column VisitNo varchar(20) not null
 go

  alter table RefundRequestDetails alter column ReceiptNo varchar(20) not null
 go

 alter table RefundRequestDetails add constraint pkRefundRequestNoVisitNoReceiptNoItemCodeItemCategoryID primary key(RefundRequestNo, VisitNo, ReceiptNo, ItemCode, ItemCategoryID)
 go

alter table RefundDetails drop constraint pkRefundNoReceiptNoItemCategoryIDItemCode
go

alter table RefundDetails alter column VisitNo varchar(20) not null
go
alter table RefundDetails alter column ReceiptNo varchar(20) not null
go
alter table RefundDetails add constraint pkRefundNoVisitNoReceiptNoItemCodeItemCategoryID primary key(RefundNo, VisitNo, ReceiptNo, ItemCode, ItemCategoryID)
go

 alter table RefundDetails add constraint fkReceiptNoVisitNoItemCodeItemCategoryIDRefundDetails foreign key(ReceiptNo, VisitNo, ItemCode, ItemCategoryID)  references PaymentDetails (ReceiptNo, VisitNo, ItemCode, ItemCategoryID)
 go




 update Items set ItemDetails = '_' where ItemCategoryID ='7T'
 and ItemDetails =''
 go

 
 update IPDItems set ItemDetails = '_' where ItemCategoryID ='7T'
 and ItemDetails =''
 go


 Alter table LabResults add ApprovedStatusID varchar(10)
 constraint fkApprovedStatusIDLabResults references LookupData (DataID)
 go


 Update LabResults set ApprovedStatusID ='54Y' where ApprovedStatusID is null
 go 


 create table ApprovedLabResults
(SpecimenNo varchar(20) constraint fkSpecimenNoApprovedLabResults references LabRequests (SpecimenNo),
TestCode varchar(20),
constraint pkSpecimenNoTestCodeApprovedLabResults foreign key (SpecimenNo, TestCode)
references LabResults (SpecimenNo, TestCode),
TestName varchar(200),
LoginID varchar(20) constraint fkLoginIDApprovedLabResults references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineApprovedLabResults default host_name(),
RecordDateTime SmallDateTime constraint dfRecordDateTimeApprovedLabResults default GetDate()
)
go


exec uspEditOptions 'ForceLabResultsVerification', 0, '3BIT', 1, 0
go


Alter table Admissions add PatientNo varchar(20)
constraint fkPatientNoAdmissions references Patients (PatientNo)


--------run cursor below, as a block--------------------------------------------------------------


declare @VisitNo varchar(20)
declare @PatientNo varchar(20)


DECLARE UpdatePatientNo_Cursor INSENSITIVE CURSOR FOR

select visits.PatientNo,Admissions.VisitNo from Admissions 
inner join visits on visits.VisitNo = Admissions.VisitNo
where Admissions.PatientNo is null

OPEN UpdatePatientNo_Cursor

FETCH NEXT FROM UpdatePatientNo_Cursor INTO @PatientNo,@VisitNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN

	update Admissions set PatientNo =@PatientNo where VisitNo =@VisitNo

		FETCH NEXT FROM UpdatePatientNo_Cursor INTO @PatientNo,@VisitNo
	END
CLOSE UpdatePatientNo_Cursor
deallocate UpdatePatientNo_Cursor

------------------------------------------------------------------------------------------------

drop proc uspEditExtraBillItemsINT
drop proc uspEditExtraBillsINT



drop proc uspUpdateInventoryEXT
drop proc uspEditPackageHeadersINT
drop proc uspGetPackageHeadersINT
drop proc uspInsertPackageDetailsINT
drop proc uspUpdatePackageDetailsINT
drop proc uspGetPackageDetailsINT
drop proc uspEditPaymentsINT
drop proc uspUpdatePaymentsINT
drop proc uspGetPaymentsINT
drop proc uspInsertDepositsINT
drop proc uspGetDepositsINT
drop trigger utrDeleteDepositsINT
drop trigger utrUpdateDepositsINT
go


------------------------------------------------------------------------------------------------

alter table PackagesEXT add
UnitCost money,
UnitPrice money
go

------- 13th Aug 2018


alter table Items drop constraint dfReturnQuantityItems
alter table Items drop constraint dfReturnAmountItems
go

alter table Items drop column ReturnQuantity
alter table Items drop column ReturnAmount
go

alter table ExtraBillItems drop constraint dfReturnQuantityExtraBillItems
alter table ExtraBillItems drop constraint dfReturnAmountExtraBillItems
go

alter table ExtraBillItems drop column ReturnQuantity
alter table ExtraBillItems drop column ReturnAmount
go

alter table InvoiceDetails drop constraint dfReturnQuantityInvoiceDetails
alter table InvoiceDetails drop constraint dfReturnAmountInvoiceDetails
go

alter table InvoiceDetails drop column ReturnQuantity
alter table InvoiceDetails drop column ReturnAmount

alter table InvoiceExtraBillItems drop column ReturnQuantity
alter table InvoiceExtraBillItems drop column ReturnAmount
go

alter table InvoiceExtraBillItems drop constraint dfReturnQuantityInvoiceExtraBillItems
alter table InvoiceExtraBillItems drop constraint dfReturnAmountInvoiceExtraBillItems
go
alter table InvoiceExtraBillItems drop column ReturnQuantity
alter table InvoiceExtraBillItems drop column ReturnAmount
go

exec sp_rename 'BillReturns.ReturnID', 'AdjustmentID'
go
exec sp_rename 'BillReturns.ReturnNo', 'AdjustmentNo'
go
exec sp_rename 'BillReturns.ReturnDate', 'AdjustmentDate'
go

exec sp_rename 'BillReturns.ReturnDate', 'AdjustmentDate'
go

exec sp_rename 'BillReturns', 'BillAdjustments'
go

drop proc uspInsertBillReturns
go

drop proc uspGetBillReturns
go

drop proc uspGetNextBillReturnID
go


drop trigger utrUpdateBillReturns
go

drop trigger utrDeleteBillReturns
go

delete from AutoNumbers where ObjectName = 'BillReturns'
delete from ObjectRoles where ObjectName = 'BillReturns'
delete from AccessObjects where ObjectName ='BillReturns'
drop trigger utrUpdateInventoryReturns
go


alter table BillAdjustments add AdjustmentTypeID varchar(10)
constraint fkAdjustmentTypeIDBillAdjustments references LookupData (DataID)
go

update BillAdjustments set AdjustmentTypeID = '264D' where  AdjustmentTypeID is null
go

exec sp_rename 'ReturnedExtraBillItems.ReturnNo', 'AdjustmentNo'
go

exec sp_rename 'ReturnedExtraBillItems', 'ExtraBillItemAdjustments'
go

drop trigger utrUpdateReturnedExtraBillItems
go

drop trigger utrDeleteReturnedExtraBillItems
go

drop function GetReturnedQuantity
go



delete from ObjectRoles where ObjectName = 'ReturnedExtraBillItems'
delete from SearchColumns where ObjectName = 'ReturnedExtraBillItems'
delete from SearchObjects where ObjectName = 'ReturnedExtraBillItems'
delete from AccessObjects where ObjectName ='ReturnedExtraBillItems'
go

delete from ObjectRoles where ObjectName = 'ReturnedItems'
delete from SearchColumns where ObjectName = 'ReturnedItems'
delete from SearchObjects where ObjectName = 'ReturnedItems'
delete from AccessObjects where ObjectName ='ReturnedItems'
go


exec sp_rename 'ReturnedItems.ReturnNo', 'AdjustmentNo'
go

exec sp_rename 'ReturnedItems', 'ItemAdjustments'
go

alter table ItemAdjustments drop column ReturnDate
go

alter table ExtraBillItemAdjustments drop column ReturnDate
go

drop proc uspInsertBillReturns
go

drop proc uspGetBillReturns
go

drop proc uspGetNextBillReturnID
go

drop proc uspEditReturnedExtraBillItems
go

drop proc uspGetReturnedExtraBillItems
go

drop proc uspGetPendingReturnedExtraBillItemsDetails
go

drop proc uspGetPendingReturnedExtraBillItems
go

drop trigger utrUpdateReturnedExtraBillItems
go

drop trigger utrDeleteReturnedExtraBillItems
go

drop trigger utrUpdateReturnedItems
go

drop trigger utrDeleteReturnedItems
go

drop proc uspEditReturnedItems
go

drop proc uspGetReturnedItems
go

exec sp_rename 'fkLoginIDReturnedExtraBillItems', 'fkLoginIDExtraBillItemAdjustments'
go
exec sp_rename 'fkExtraBillNoItemCodeItemCategoryIDReturnedExtraBillItems', 'fkExtraBillNoItemCodeItemCategoryIDExtraBillItemAdjustments'
go
exec sp_rename 'dfClientMachineReturnedExtraBillItems', 'dfClientMachineExtraBillItemAdjustments'
go
exec sp_rename 'dfRecordDateTimeReturnedExtraBillItems', 'dfRecordDateTimeExtraBillItemAdjustments'
go
exec sp_rename 'fkTransactionDateReturnedExtrabillItems', 'fkTransactionDateExtraBillItemAdjustments'
go
exec sp_rename 'dfAmountReturnedExtraBillItems', 'dfAmountExtraBillItemAdjustments'
go
exec sp_rename 'dfAcknowledgeableReturnedExtraBillItems', 'dfAcknowledgeableExtraBillItemAdjustments'
go
exec sp_rename 'fkEntryLevelIDReturnedExtraBillItems', 'fkEntryLevelIDExtraBillItemAdjustments'
go
exec sp_rename 'dfIsAcknowledgedReturnedExtraBillItems', 'dfIsAcknowledgedExtraBillItemAdjustments'
go
exec sp_rename 'pkReturnNoExtraBillNoItemCodeItemCategoryIDReturnedExtraBillItems', 'pkAdjustmentNoExtraBillNoItemCodeItemCategoryIDExtraBillItemAdjustments'
go

drop table INTReturnedExtraBillItems
go
drop table INTReturnedExtraBillItems
go
drop proc uspGetPeriodicPendingReturnedExtraBillItems
go
drop proc uspGetReturnedExtraBillItemsByVisitNo
go
drop proc uspDeleteReturnedExtraBillItems
go
drop proc uspUpdatePendingReturnedExtraBillItems
go
drop proc uspEditINTReturnedExtraBillItems
go

 drop proc uspGetINTReturnedExtraBillItems
 go

  drop proc uspUpdateBillReturns
 go

 drop proc GetReturnedQuantity
go

drop function GetConsumedQuantity
go


----- Credit Note

exec sp_rename 'CreditNote.CreditNoteID', 'AdjustmentID'
go

exec sp_rename 'CreditNote.CreditNoteNo', 'AdjustmentNo'
go

exec sp_rename 'CreditNote.CreditNoteDate', 'AdjustmentDate'
go



exec sp_rename 'CreditNote', 'InvoiceAdjustments'
go

drop trigger utrUpdateCreditNote
go

drop trigger utrDeleteCreditNote
go

delete from AutoNumbers where ObjectName = 'CreditNote'
delete from ObjectRoles where ObjectName = 'CreditNote'
delete from SearchColumns where ObjectName = 'CreditNote'
delete from SearchObjects where ObjectName = 'CreditNote'
delete from AccessObjects where ObjectName ='CreditNote'
go


alter table InvoiceAdjustments add AdjustmentTypeID varchar(10)
constraint fkAdjustmentTypeIDInvoiceAdjustments references LookupData (DataID)
go

update InvoiceAdjustments set AdjustmentTypeID = '264D' where  AdjustmentTypeID is null
go


exec sp_rename 'CreditNoteExtraBillItems.CreditNoteNo', 'AdjustmentNo'
go

exec sp_rename 'CreditNoteExtraBillItems', 'InvoiceExtraBillItemAdjustments'
go


delete from ObjectRoles where ObjectName = 'CreditNoteExtraBillItems'
delete from SearchColumns where ObjectName = 'CreditNoteExtraBillItems'
delete from SearchObjects where ObjectName = 'CreditNoteExtraBillItems'
delete from AccessObjects where ObjectName ='CreditNoteExtraBillItems'
go

delete from ObjectRoles where ObjectName = 'CreditNoteDetails'
delete from SearchColumns where ObjectName = 'CreditNoteDetails'
delete from SearchObjects where ObjectName = 'CreditNoteDetails'
delete from AccessObjects where ObjectName ='CreditNoteDetails'
go


exec sp_rename 'CreditNoteDetails.CreditNoteNo', 'AdjustmentNo'
go

exec sp_rename 'CreditNoteDetails', 'InvoiceDetailAdjustments'
go



------------------------------------------------------------------------------------------------
------------------------------------------15-Aug-2018-------------------------------------------
------------------------------------------------------------------------------------------------

alter table PackagesEXT add
UnitCost money,
UnitPrice money
go


--------run utilities first

--------run cursor below, as a block--------------------------------------------------------------


declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(10)
declare @UnitCost money
declare @UnitPrice money


DECLARE UpdatePackages_Cursor INSENSITIVE CURSOR FOR

SELECT ItemCode,ItemCategoryID,UnitCost,UnitPrice 
FROM AllBillableItems


OPEN UpdatePackages_Cursor

FETCH NEXT FROM UpdatePackages_Cursor INTO @ItemCode,@ItemCategoryID,@UnitCost,@UnitPrice
WHILE (@@FETCH_STATUS <> -1)
BEGIN

UPDATE PackagesEXT SET UnitCost =@UnitCost, UnitPrice =@UnitPrice
WHERE ItemCode =@ItemCode AND ItemCategoryID =@ItemCategoryID

FETCH NEXT FROM UpdatePackages_Cursor INTO @ItemCode,@ItemCategoryID,@UnitCost,@UnitPrice
END
CLOSE UpdatePackages_Cursor
deallocate UpdatePackages_Cursor

------------------------------------------------------------------------------------------------

UPDATE PackagesEXT SET UnitCost =0
WHERE UnitCost is Null

UPDATE PackagesEXT SET UnitPrice =0
WHERE UnitPrice is Null

Alter table AttachPackage add PackageVisitNo varchar(20)

Alter table PackageVisits add PackageVisitNo varchar(20)





--------Note : Run Manage first

declare @VisitNo varchar(20)
declare @PackageVisitNo varchar(20)
declare @PackageNo varchar(20)
 
DECLARE PackageVisits_Cursor INSENSITIVE CURSOR FOR

select VisitNo,PackageVisitNo,PackageNo
from PackageConsumption


OPEN PackageVisits_Cursor
FETCH NEXT FROM PackageVisits_Cursor INTO @VisitNo,@PackageVisitNo,@PackageNo
WHILE (@@FETCH_STATUS <> -1)
	BEGIN

update PackageVisits set PackageVisitNo = @PackageVisitNo
where PackageNo =@PackageNo and VisitNo =@VisitNo


update AttachPackage set PackageVisitNo = @PackageVisitNo
where PackageNo =@PackageNo and VisitNo =@VisitNo
------------------------------------------------------------------------------------------------------

FETCH NEXT FROM PackageVisits_Cursor INTO  @VisitNo,@PackageVisitNo,@PackageNo
	END
CLOSE PackageVisits_Cursor
deallocate PackageVisits_Cursor

----------------------------------------------------------------------------------

----------------------------------------16 Aug 2018 ----------------------------------------------

alter table PossibleAttachedItems add
UnitCost money,
UnitPrice money
go

----------------------------------------23 Aug 2018 ----------------------------------------------

exec uspEditOptions 'SchemeMembersMaxDependants', 2, '3NUM', 2, 0




 --------run cursor below, but be very carefull--------------------------------------------------------------

declare @VisitNo varchar(20)
declare @BillModesID varchar(10)
declare @BillNo varchar(20)
declare @InsuranceNo varchar(20)
declare @AssociatedBillNo varchar(20)

declare @MemberCardNo varchar(20)
declare @MainMemberName varchar(50)
declare @ClaimReferenceNo varchar(20)
declare @CoPayTypeID varchar(10) 

declare @CoPayPercent Decimal
declare @CoPayValue Decimal

declare @AccessCashServices bit
declare @SmartCardApplicable bit


DECLARE AdmissionsDetails_Cursor INSENSITIVE CURSOR FOR

SELECT VisitNo,BillModesID, BillNo, InsuranceNo, AssociatedBillNo,MemberCardNo, MainMemberName, ClaimReferenceNo,
CoPayTypeID, CoPayPercent, CoPayValue,SmartCardApplicable,AccessCashServices
FROM VISITS

OPEN AdmissionsDetails_Cursor
FETCH NEXT FROM AdmissionsDetails_Cursor INTO @VisitNo,@BillModesID, @BillNo, @InsuranceNo, @AssociatedBillNo,@MemberCardNo, @MainMemberName, 
@ClaimReferenceNo,@CoPayTypeID, @CoPayPercent, @CoPayValue,@SmartCardApplicable,@AccessCashServices
WHILE (@@FETCH_STATUS <> -1)
	BEGIN
	
		UPDATE Admissions Set BillModesID = @BillModesID, BillNo = @BillNo,InsuranceNo=@InsuranceNo,AssociatedBillNo=@AssociatedBillNo,MemberCardNo=@MemberCardNo,
		ClaimReferenceNo=@ClaimReferenceNo,CoPayTypeID=@CoPayTypeID,CoPayPercent=@CoPayPercent,CoPayValue=@CoPayValue,SmartCardApplicable=@SmartCardApplicable,
		AccessCashServices=@AccessCashServices
        WHERE VisitNo = @VisitNo


FETCH NEXT FROM AdmissionsDetails_Cursor INTO @VisitNo,@BillModesID, @BillNo, @InsuranceNo, @AssociatedBillNo,@MemberCardNo, @MainMemberName,
		 @ClaimReferenceNo,@CoPayTypeID, @CoPayPercent, @CoPayValue,@SmartCardApplicable,@AccessCashServices
	END
CLOSE AdmissionsDetails_Cursor
deallocate AdmissionsDetails_Cursor

----------------------------------------------------------------------------------

Update InventoryOrders Set TransferReasonID ='262DIS' where TransferReasonID is null
go

exec uspEditOptions 'DisallowPaymentOfOutStockDrugs', 0, '3BIT', 1, 0

alter table Payments add
WithholdingTax money constraint dfWithholdingTaxPayments default 0,
GrandDiscount money constraint dfGrandDiscountPayments default 0
go

update Payments set WithholdingTax = 0 where WithholdingTax is null
go
update Payments set GrandDiscount = 0 where GrandDiscount is null
go


----------------------------------------02 Sept 2018 ----------------------------------------------

create table AccountsEXT
(TranNo varchar(20) constraint fkTranNoAccountsEXT references Accounts (TranNo)
on delete cascade on update cascade,
ReferenceNo varchar(20) constraint fkReferenceNoAccountsEXT references Accounts (TranNo),
constraint pkTranNoReferenceNo primary key(TranNo, ReferenceNo)
)
go

alter table AttachPackage add 
AttachPackageID int not null identity(1,1)

-----------------03 Oct 2018-------------------
create table INTAgents
(AgentNo varchar(20) not null
constraint pkAgentNo primary key,
AgentName varchar(60),
LoginID varchar(20)
constraint fkLoginIDINTAgents references Logins (LoginID),
ClientMachine varchar(41) constraint dfClientMachineINTAgents default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeINTAgents default GetDate()
)
go

create table LookupDataMappings
(DataID Varchar(10) constraint fkDataIDLookupDataMappings references LookupData (DataID) on delete cascade,
AgentNo Varchar(20) constraint fkAgentNoLookupDataMappings references INTAgents (AgentNo),
constraint pkDataIDAgentDataID primary key(DataID,AgentNo),
AgentDataID Varchar(10) not null,
ObjectName Varchar(10) ,
LoginID Varchar(20) constraint fkLoginIDLookupDataMappings references Logins (LoginID),
RecordDateTime smalldatetime constraint dfRecordDateTimeLookupDataMappings default getdate(),
ClientMachine Varchar(40) constraint dfClientMachineLookupDataMappings default host_name()
)
go

alter table AssetRegister add ManufacturerID Varchar(20),InstitutionalID Varchar(20)
go

alter table Patients add
ReferringFacility varchar(41) 
go

create table PatientConsent
(PatientNo Varchar(20) constraint fkPatientNoPatientConsent references Patients (PatientNo)
on delete cascade on update cascade constraint pkPatientNoPatientConsent primary key,
PhoneNo Varchar(30),
Notes Varchar(200),
FingerprintVerified bit constraint dfFingerprintVerifiedPatientConsent default 0,
LoginID Varchar(20) constraint fkLoginIDPatientConsent references Logins (LoginID),
ClientMachine Varchar(41) constraint dfClientMachinePatientConsent default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimePatientConsent default GetDate()
)
go

-----------------12 Oct 2018-------------------

exec uspEditOptions 'EnableSecondPatientForm', 0, '3BIT', 1, 0

------------------ 24 Oct 2018 -----------------
exec uspEditOptions 'ForceTBAssessmentAtTriage', 0, '3BIT', 1, 0


----------------- Contraceptives History ---------------------

alter table ContraceptivesHistory drop constraint pkPatientNoContraceptiveID
go

alter table ContraceptivesHistory drop constraint fkContraceptiveIDContraceptivesHistory
go

alter table ContraceptivesHistory drop constraint fkPatientNoContraceptivesHistory
go

alter table ContraceptivesHistory drop column PatientNo, ContraceptiveID
go

alter table ContraceptivesHistory
add PatientNo varchar(20)
constraint fkPatientNoContraceptivesHistory references Patients (PatientNo)  on delete cascade on update cascade,
ContraceptiveID varchar(10) constraint fkContraceptiveIDContraceptivesHistory references LookupData (DataID),
constraint pkPatientNoContraceptiveID primary key(PatientNo, ContraceptiveID)
go


exec uspEditOptions 'HideInvoiceHeader', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableRegistrationShortCuts', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableVisitToSeeDoctorSelection', 1, '3BIT', 1, 0

drop function GetDebitCashAccountBalance

---------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------- Nov 12 2018 ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------


update LookupObjects set ObjectName = 'IntegrationAgent', ObjectDes = 'Integration Agent' where ObjectID = 167
go

alter table Invoices add Cancelled  bit constraint dfCancelledInvoices default 0
go
update Invoices set Cancelled = 0 where Cancelled is null
go
alter table InvoiceAdjustments add ReversalActionID varchar(10) constraint fkReversalActionIDInvoiceAdjustemnts references LookupData(DataID)

------ run data first
drop trigger utrUpdateCreditNote
go

update InvoiceAdjustments set ReversalActionID = '266A' where  ReversalActionID is null
go

exec uspEditOptions 'LockItemsUnitPrices', 1, '3BIT', 1, 0
go



Alter table Procedures add 
ProcedureCategoryID varchar(10) constraint fkProcedureCategoryID references LookupData (DataID)
go

update Procedures set ProcedureCategoryID = '265NA' where  ProcedureCategoryID is null
go

alter table PackageVisits drop constraint fkVisitNoPackageVisits
alter table AttachPackage drop constraint fkVisitNoAttachPackage
alter table PackageConsumption drop constraint fkVisitNoPackageConsumption
go


alter table PackageVisits add
constraint fkVisitNoPackageVisits foreign key (VisitNo) 
references Visits (VisitNo) on delete cascade on update cascade
go

alter table AttachPackage add
constraint fkVisitNoAttachPackage foreign key (VisitNo) 
references Visits (VisitNo) on delete cascade on update cascade
go


alter table PackageConsumption add
constraint fkVisitNoPackageConsumption foreign key (VisitNo) 
references Visits (VisitNo) on delete cascade on update cascade
go


---------------------------------------------------------------------------------------------------------------------------------
---------------------------------------------- Dec 04 2018 ----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------------------


alter table IPDPathologyReports add
Macroscopic varchar(4000),
Microscopic  varchar(4000)
go


Alter table Procedures add 
UnitCost money
go

alter table PathologyReports add
Macroscopic varchar(4000),
Microscopic  varchar(4000)
go


exec uspEditOptions 'ForceRefundsApproval', 1, '3BIT', 1, 0
go

alter table PossibleAttachedItems add
Dosage varchar(20),
Duration int
go


Alter table Items add ConclusionDate smallDateTime
go

Alter table Items add PayDate smallDateTime
go

drop proc uspEditExtraBillItemsINT
drop proc uspUpdateExtraBillItemsINT
drop proc uspGetExtraBillItemsINT



----------------------------------------------------------------------------------
--------------------------------- PayDate on Items  ------------------------------
----------------------------------------------------------------------------------

declare @VisitNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(20)
declare @PayDate smalldatetime

DECLARE Payments_Cursor INSENSITIVE CURSOR FOR

SELECT  PayNo,ItemCode,ItemCategoryID,RecordDateTime FROM Payments
inner join PaymentDetails on Payments.ReceiptNo =PaymentDetails.ReceiptNo and
Payments.PayNo = PaymentDetails.VisitNo


OPEN Payments_Cursor
FETCH NEXT FROM Payments_Cursor INTO @VisitNo,@ItemCode,@ItemCategoryID,@PayDate
WHILE (@@FETCH_STATUS <> -1)
	BEGIN

update Items set PayDate = @PayDate
where ItemCode =@ItemCode and ItemCategoryID =@ItemCategoryID and VisitNo =@VisitNo and PayDate is null

------------------------------------------------------------------------------------------------------

FETCH NEXT FROM Payments_Cursor INTO  @VisitNo,@ItemCode,@ItemCategoryID,@PayDate
	END
CLOSE Payments_Cursor
deallocate Payments_Cursor
go

----------------------------------------------------------------------------------

-----The cursor below updates the Conclusion Date Items Except Extra Charge
----------------------------------------------------------------------------------


declare @VisitNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(20)
declare @ConclusionDate smalldatetime

DECLARE ItemsEXT_Cursor INSENSITIVE CURSOR FOR

SELECT  VisitNo,ItemCode,ItemCategoryID,IssueDateTime FROM ItemsEXT


OPEN ItemsEXT_Cursor
FETCH NEXT FROM ItemsEXT_Cursor INTO @VisitNo,@ItemCode,@ItemCategoryID,@ConclusionDate
WHILE (@@FETCH_STATUS <> -1)
	BEGIN

update Items set ConclusionDate = @ConclusionDate
where ItemCode =@ItemCode and ItemCategoryID =@ItemCategoryID and VisitNo =@VisitNo and ConclusionDate is null

------------------------------------------------------------------------------------------------------

FETCH NEXT FROM ItemsEXT_Cursor INTO  @VisitNo,@ItemCode,@ItemCategoryID,@ConclusionDate
	END
CLOSE ItemsEXT_Cursor
deallocate ItemsEXT_Cursor

----------------------------------------------------------------------------------

-----The cursor below updates the Conclusion Date for Extra charge Items
----------------------------------------------------------------------------------



declare @VisitNo varchar(20)
declare @ItemCode varchar(20)
declare @ItemCategoryID varchar(20)
declare @ConclusionDate smalldatetime

DECLARE ItemsEXT_Cursor INSENSITIVE CURSOR FOR

SELECT  VisitNo,ItemCode,ItemCategoryID,RecordDateTime FROM Items where ItemCategoryID ='7E'


OPEN ItemsEXT_Cursor
FETCH NEXT FROM ItemsEXT_Cursor INTO @VisitNo,@ItemCode,@ItemCategoryID,@ConclusionDate
WHILE (@@FETCH_STATUS <> -1)
	BEGIN

update Items set ConclusionDate = @ConclusionDate
where ItemCode =@ItemCode and ItemCategoryID =@ItemCategoryID and VisitNo =@VisitNo and ConclusionDate is null

------------------------------------------------------------------------------------------------------

FETCH NEXT FROM ItemsEXT_Cursor INTO  @VisitNo,@ItemCode,@ItemCategoryID,@ConclusionDate
	END
CLOSE ItemsEXT_Cursor
deallocate ItemsEXT_Cursor

----------------------------------------------------------------------------------


alter table Appointments add 
AppointmentCategoryID varchar(10) constraint fkAppointmentCategoryIDAppointments references LookupData (DataID),
CommunityID varchar(10) constraint fkCommunityAppointments references LookupData (DataID)
go

update Appointments  set CommunityID = '50701' where CommunityID is null
update Appointments  set AppointmentCategoryID = '10C' where AppointmentCategoryID is null
go

drop proc uspUpdateExtraBillItems
go

drop proc uspDeleteExtraBillItems
go

-----------------21 January 2019 -----------------------------------
-----------------------------------------------------------------
create table BillableMappings
(ItemCategoryID varchar(10)
constraint fkItemCategoryIDBillableMappings references LookupData (DataID),
ItemCode varchar(20),
MappedTypeID varchar(10)
constraint fkMappedTypeIDBillableMappings references LookupData (DataID),
AgentNo varchar(20)
constraint fkAgentNoBillableMappings references INTAgents (AgentNo),
constraint pkItemCategoryIDItemCode primary key(ItemCategoryID, ItemCode, MappedTypeID, AgentNo ),
MappedCode varchar(20),
LoginID varchar(20)
constraint fkLoginIDBillableMappings references Logins (LoginID),
ClientMachine varchar(10) constraint dfClientMachineBillableMappings default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeBillableMappings default getdate()
)
go


exec uspEditOptions 'ForceBillableMappings', 0, '3BIT', 1, 0
exec uspEditOptions 'EnableVisitDate',1, '3BIT', 1, 0
exec uspEditOptions 'EnableInvoiceDate',1, '3BIT', 1, 0
exec uspEditOptions 'EnablePayDate',1, '3BIT', 1, 0

----------         Feb 10 2019

alter table ItemsCASH add InvoiceNo varchar(20) null constraint dfInvoiceNoItemsCASH default '' 
go

alter table ExtraBillItemsCASH add InvoiceNo varchar(20) not null constraint dfInvoiceNoExtraBillItemsCASH default ''
go

drop proc uspUpdateOPDItemInvoiceNo
go

alter table Invoices add 
EntryModeID varchar(10) constraint fkEntryModeIDInvoices references LookupData (DataID)
go

update Invoices set EntryModeID = '46SYS' where Locked = 1
go
update Invoices set EntryModeID = '46MAN' where Locked = 0
go
alter table InvoiceDetails add
ObjectName varchar(40) constraint fkObjectNameInvoiceDetails references AccessObjects (ObjectName)
constraint ckObjectNameInvoiceDetails check (ObjectName in ('Items', 'ItemsCASH', 'ExtraBillItems', 'ExtraBillItemsCASH'))
go

alter table InvoiceExtraBillItems add
ObjectName varchar(40) constraint fkObjectNameInvoiceExtraBillItems references AccessObjects (ObjectName)
constraint ckObjectNameInvoiceExtraBillItems check (ObjectName in ('Items', 'ItemsCASH', 'ExtraBillItems', 'ExtraBillItemsCASH'))
go

create table Dimensions
(DimensionCode varchar(20) not null,
DimensionTypeID varchar(10) not null
constraint fkDimensionTypeIDDimensions references LookupData (DataID),
constraint pkDimensionCodeDimensionTypeID primary key(DimensionCode, DimensionTypeID),
DimensionName varchar(100),
Blocked bit,
LoginID varchar(20)
constraint fkLoginIDDimensions references Logins (LoginID),
ClientMachine varchar(40) constraint dfClientMachineDimensions default host_name(),
RecordDateTime smalldatetime constraint dfRecordDateTimeDimensions default getdate()
)
go

alter table Suppliers drop column AccountNo
go


------------------------------23 Feb 2019 -------------------------
alter table LabTests add
RequiresResultsApproval bit constraint dfRequiresResultsApprovalLabTests default 0
go


Update LabTests set RequiresResultsApproval =0 where RequiresResultsApproval is null
go

exec uspEditOptions 'EnforceCreditLimitOnInPatientAndOutPatient',1, '3BIT', 1, 0

exec uspEditOptions 'OpenInvoicesAfterVisits',0, '3BIT', 1, 0

exec uspEditOptions 'AllowPrintingForm5',0, '3BIT', 1, 0
go
----------------------------------------------------------------------
 delete from Options where OptionName = 'AllowCreateInvoicesAtCashPayments'

 
 
 
  alter table Visits drop constraint fkPackageNoPackages
 go

 alter table Visits drop column PackageNo
 go

Alter table Clients add BirthDate SmallDateTime, 
AppointmentDate SmallDateTime
go

exec uspEditOptions 'AllowPrintingAdmissionFaceSheet', 0, '3BIT', 1, 0
go

alter table INTAgents add ConnectionModeID varchar(10) constraint fkConnectionModeIDINTAgents references LookupData (DataID),
DatabaseTypeID varchar(10) constraint fkDatabaseTypeIDINTAgents references LookupData (DataID),
DataSource varchar(100),
DBName varchar(100),
Port int,
Username varchar(40),
Password varchar(1000)
go

-------------------------------2-MAY-2019------------------------------------------------------

Alter table Admissions add 
ServiceCode varchar(10) constraint fkServiceCodeAdmissions references Services(ServiceCode)
go

exec uspEditOptions 'EnableAdmissionBillServiceFee', 0, '3BIT', 1, 0
go

exec uspEditOptions 'OpenCashierFormOnAdmission', 0, '3BIT', 1, 0
go

alter table ExtraBills add
VisitTypeID varchar(10) constraint fkVisitTypeExtraBills references LookupData (DataID)
go

update ExtraBills set VisitTypeID = '110IPD'
go

-------------------------------5-MAY-2019------------------------------------------------------

exec uspEditOptions 'AllowOpenCashierAtBillingForm', 0, '3BIT', 1, 0
go

exec uspEditOptions 'AllowBillVisitServiceAtExtraBill', 0, '3BIT', 1, 0
go

Alter table Admissions add 
ProvisionalDiagnosis varchar(2000)
go

-------------------------------8-MAY-2019------------------------------------------------------
exec uspEditOptions 'EnableOPDExtraBills', 0, '3BIT', 1, 1

exec uspEditOptions 'MaximumDrugQtyToGive', 100, '3NUM', 4, 0
exec uspEditOptions 'MaximumConsumableQtyToGive', 200, '3NUM', 4, 0
exec uspEditOptions 'MaximumExtraChargeQtyToIssue', 200, '3NUM', 4, 0

-----------------------------21---MAY-2019------------------------------------------------------
drop proc uspGetAverageAgeItemConsumption
drop function GetAverageAgeItemConsumption
drop proc uspGetAverageItemConsumption
drop function GetAverageItemConsumption
drop proc uspGetGenderSpecificItemConsumption
drop function GetGenderSpecificItemConsumption
go
