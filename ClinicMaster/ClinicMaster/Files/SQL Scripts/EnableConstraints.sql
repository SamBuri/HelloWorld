
use ClinicMaster
go

------Enable Constraints-------------------------------------------------------------------

--------------------------------------------------------------------------------------------
---------------ARTRegimen-------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoARTRegimen')
	alter table ARTRegimen
	drop constraint fkVisitNoARTRegimen
go

alter table ARTRegimen
add constraint fkVisitNoARTRegimen foreign key (VisitNo) references Visits(VisitNo)
go

--------------------------------------------------------------------------------------------
---------------ARTRegimenDetails------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoARTRegimenDetails')
	alter table ARTRegimenDetails
	drop constraint fkVisitNoARTRegimenDetails
go

alter table ARTRegimenDetails
add constraint fkVisitNoARTRegimenDetails foreign key (VisitNo)
references Visits(VisitNo)
on delete cascade
go

--------------------------------------------------------------------------------------------
---------------ARTStopped-------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoARTStopped')
	alter table ARTStopped
	drop constraint fkVisitNoARTStopped
go

alter table ARTStopped
add constraint fkVisitNoARTStopped foreign key (VisitNo)
references Visits(VisitNo)
go

--------------------------------------------------------------------------------------------
---------------Items------------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoItems')
	alter table Items
	drop constraint fkVisitNoItems
go

alter table Items
add constraint fkVisitNoItems foreign key (VisitNo) references Visits(VisitNo)
go

--------------------------------------------------------------------------------------------
---------------DoctorVisits-----------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoDoctorVisits')
	alter table DoctorVisits
	drop constraint fkVisitNoDoctorVisits
go

alter table DoctorVisits
add constraint fkVisitNoDoctorVisits foreign key (VisitNo) references Visits(VisitNo)
go

--------------------------------------------------------------------------------------------
---------------Triage-----------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoTriage')
	alter table Triage
	drop constraint fkVisitNoTriage
go

alter table Triage
add constraint fkVisitNoTriage foreign key (VisitNo)
references Visits(VisitNo)
go

--------------------------------------------------------------------------------------------
---------------LabRequests------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoSpecimen')
	alter table LabRequests
	drop constraint fkVisitNoSpecimen
go

alter table LabRequests
add constraint fkVisitNoSpecimen foreign key (VisitNo) references Visits(VisitNo)
go

--------------------------------------------------------------------------------------------
---------------Appointments-----------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkPatientNoAppointments')
alter table Appointments
drop constraint fkPatientNoAppointments
go

alter table Appointments
add constraint fkPatientNoAppointments foreign key (PatientNo)
references Patients(PatientNo)
go

--------------------------------------------------------------------------------------------
---------------Diagnosis--------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoDiagnosis')
	alter table Diagnosis
	drop constraint fkVisitNoDiagnosis
go

alter table Diagnosis
add constraint fkVisitNoDiagnosis foreign key (VisitNo) references Visits(VisitNo)
go

--------------------------------------------------------------------------------------------
---------------Deaths-----------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkPatientNoDeaths')
alter table Deaths
drop constraint fkPatientNoDeaths
go

alter table Deaths
add constraint fkPatientNoDeaths foreign key (PatientNo)
references Patients(PatientNo)
go

--------------------------------------------------------------------------------------------
---------------LabResults-------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkSpecimenNoTestCodeLabResults')
	alter table LabResults
	drop constraint fkSpecimenNoTestCodeLabResults
go

alter table LabResults
add constraint fkSpecimenNoTestCodeLabResults foreign key (SpecimenNo, TestCode)
references LabRequestDetails (SpecimenNo, TestCode)
go

--------------------------------------------------------------------------------------------
---------------Admissions-------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoAdmissions')
	alter table Admissions
	drop constraint fkVisitNoAdmissions
go

alter table Admissions
add constraint fkVisitNoAdmissions foreign key (VisitNo) references Visits (VisitNo)
go

if exists (select * from sysobjects where name = 'fkPatientNoAdmissions')
	alter table Admissions
	drop constraint fkPatientNoAdmissions
go

alter table Admissions
add constraint fkPatientNoAdmissions foreign key (PatientNo) references Patients (PatientNo)
go
--------------------------------------------------------------------------------------------
---------------IPDDoctor--------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkAdmissionNoIPDDoctor')
	alter table IPDDoctor
	drop constraint fkAdmissionNoIPDDoctor
go

alter table IPDDoctor
add constraint fkAdmissionNoIPDDoctor foreign key (AdmissionNo) references Admissions (AdmissionNo)
go

--------------------------------------------------------------------------------------------
---------------IPDItems---------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkRoundNoIPDItems')
	alter table IPDItems
	drop constraint fkRoundNoIPDItems
go

alter table IPDItems
add constraint fkRoundNoIPDItems foreign key (RoundNo) references IPDDoctor (RoundNo)
go

--------------------------------------------------------------------------------------------
---------------Discharges-------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkAdmissionNoDischarges')
	alter table Discharges
	drop constraint fkAdmissionNoDischarges
go

alter table Discharges
add constraint fkAdmissionNoDischarges foreign key (AdmissionNo) references Admissions (AdmissionNo)
go

--------------------------------------------------------------------------------------------
---------------ExtraBills-------------------------------------------------------------------
--------------------------------------------------------------------------------------------

if exists (select * from sysobjects where name = 'fkVisitNoExtraBills')
	alter table ExtraBills
	drop constraint fkVisitNoExtraBills
go

alter table ExtraBills
add constraint fkVisitNoExtraBills foreign key (VisitNo) references Visits(VisitNo)
go


--------------------------------------------------------------------------------------------
---------------IPDCardiologyReports-------------------------------------------------------------------
--------------------------------------------------------------------------------------------


if exists (select * from sysobjects where name = 'fkRoundNoItemCodeItemCategoryIDIPDCardiologyReports')
	alter table IPDCardiologyReports
	drop constraint fkRoundNoItemCodeItemCategoryIDIPDCardiologyReports
go

if exists (select * from sysobjects where name = 'pkRoundNoItemCodeItemCategoryIDIPDCardiologyReports')
	alter table IPDCardiologyReports
	drop constraint pkRoundNoItemCodeItemCategoryIDIPDCardiologyReports
go


alter table IPDCardiologyReports add 
constraint fkRoundNoItemCodeItemCategoryIDIPDCardiologyReports foreign key (RoundNo, ItemCode, ItemCategoryID) 
references IPDItems (RoundNo, ItemCode, ItemCategoryID) on delete cascade on update cascade,
constraint pkRoundNoItemCodeItemCategoryIDIPDCardiologyReports primary key(RoundNo, ItemCode, ItemCategoryID)