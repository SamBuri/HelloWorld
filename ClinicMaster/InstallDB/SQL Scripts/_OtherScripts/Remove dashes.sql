Use ClinicMaster

go
----------------Removing dashes from Staff

-----------------Remove all foreign Keys----------------------------

alter table Admissions drop fkStaffNoAdmissions
alter table RadiologyReports drop fkRadiologistRadiologyReports
alter table ExternalReferrals drop fkStaffNoExternalReferrals
alter table IPDRadiologyReports drop fkRadiologistIPDRadiologyReports
alter table ARTRegimen drop fkStaffNoARTRegimen
alter table Referrals drop fkReferredByReferrals
alter table Referrals drop fkReferredToReferrals
alter table ARTStopped drop fkStaffNoARTStopped
alter table TheatreOperations drop fkLeadSurgeonTheatreOperations
alter table TheatreOperations drop fkLeadAnaesthetistTheatreOperations
alter table TheatreOperations drop fkLeadNurseTheatreOperations
alter table ItemsEXT drop fkPharmacistItemsEXT
alter table PathologyReports drop fkPathologistPathologyReports
alter table IPDTheatreOperations drop fkLeadSurgeonIPDTheatreOperations
alter table IPDTheatreOperations drop fkLeadAnaesthetistIPDTheatreOperations
alter table IPDTheatreOperations drop fkLeadNurseIPDTheatreOperations
alter table IPDDoctor drop fkStaffNoIPDDoctor
alter table Alerts drop fkStaffNoAlerts
alter table Appointments drop fkStaffNoAppointments
alter table ServicesStaffFee drop fkStaffNoServicesStaffFee
alter table IPDAlerts drop fkStaffNoIPDAlerts
alter table ExtraBills drop fkStaffNoExtraBills
alter table IPDItemsEXT drop fkPharmacistIPDItemsEXT
alter table Discharges drop fkStaffNoDischarges
alter table Visits drop fkStaffNoVisits
alter table DoctorVisits drop fkStaffNoDoctorVisits
alter table LabResults drop fkLabTechnologistLabResults
alter table LabRequests drop  fkDrawnByLabRequests
alter table staff drop constraint pkStaffNo

-----Remove the dashes------------------------------------------------------------------------
UPDATE Admissions SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE LabRequests SET DrawnBy=  REPLACE(DrawnBy, '-', '')
UPDATE LabResults SET LabTechnologist=  REPLACE(LabTechnologist, '-', '')
UPDATE DoctorVisits SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE Visits SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE Discharges SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE IPDItemsEXT SET Pharmacist=  REPLACE(Pharmacist, '-', '')
UPDATE ExtraBills SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE IPDAlerts SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE ServicesStaffFee SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE Appointments SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE Alerts SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE IPDDoctor SET StaffNo=  REPLACE(StaffNo, '-', '')
UPDATE IPDTheatreOperations SET LeadNurse=  REPLACE(LeadNurse, '-', '')
UPDATE IPDTheatreOperations SET LeadSurgeon=  REPLACE(LeadSurgeon, '-', '')
UPDATE IPDTheatreOperations SET LeadAnaesthetist =  REPLACE(LeadAnaesthetist, '-', '')
UPDATE PathologyReports SET Pathologist =  REPLACE(Pathologist, '-', '')
UPDATE ItemsEXT SET Pharmacist =  REPLACE(Pharmacist, '-', '')
UPDATE TheatreOperations SET LeadNurse =  REPLACE(LeadNurse, '-', '')
UPDATE TheatreOperations SET LeadSurgeon =  REPLACE(LeadSurgeon, '-', '')
UPDATE TheatreOperations SET LeadAnaesthetist =  REPLACE(LeadAnaesthetist, '-', '')
UPDATE ARTStopped SET StaffNo =  REPLACE(StaffNo, '-', '')
UPDATE Referrals SET ReferredTo =  REPLACE(ReferredTo, '-', '')
UPDATE Referrals SET ReferredBy =  REPLACE(ReferredBy, '-', '')
UPDATE ARTRegimen SET StaffNo =  REPLACE(StaffNo, '-', '')
UPDATE IPDRadiologyReports SET Radiologist =  REPLACE(Radiologist, '-', '')
UPDATE ExternalReferrals SET StaffNo =  REPLACE(StaffNo, '-', '')
UPDATE RadiologyReports SET Radiologist =  REPLACE(Radiologist, '-', '')
UPDATE TheatreOperations SET LeadNurse =  REPLACE(LeadNurse, '-', '')
UPDATE TheatreOperations SET LeadAnaesthetist =  REPLACE(LeadAnaesthetist, '-', '')
UPDATE TheatreOperations SET LeadSurgeon =  REPLACE(LeadSurgeon, '-', '')
UPDATE LabRequests SET DrawnBy =  REPLACE(DrawnBy, '-', '')
UPDATE Referrals SET ReferredBy =  REPLACE(ReferredBy, '-', '')
UPDATE LabResults SET LabTechnologist =  REPLACE(LabTechnologist, '-', '')

UPDATE staff SET StaffNo =  REPLACE(StaffNo, '-', '')


----------------------------------------------------------------------------------------------

-------Add Foreign Keys back ------------------------------------------------------------------

alter table staff add constraint  pkStaffNo primary key (StaffNo) 

alter table Admissions add constraint fkStaffNoAdmissions foreign key (StaffNo)
references Staff (StaffNo)

alter table RadiologyReports add constraint fkRadiologistRadiologyReports foreign key (Radiologist)
references Staff (StaffNo)

alter table ExternalReferrals add constraint fkStaffNoExternalReferrals foreign key (StaffNo)
references Staff (StaffNo)

alter table IPDRadiologyReports add constraint fkRadiologistIPDRadiologyReports foreign key (Radiologist)
references Staff (StaffNo)

alter table ARTRegimen add constraint fkStaffNoARTRegimen foreign key (StaffNo)
references Staff (StaffNo)

alter table Referrals add constraint fkReferredByReferrals foreign key (ReferredBy)
references Staff (StaffNo)

alter table Referrals add constraint fkReferredToReferrals foreign key (ReferredTo)
references Staff (StaffNo)

alter table ARTStopped add constraint fkStaffNoARTStopped foreign key (StaffNo)
references Staff (StaffNo)

alter table TheatreOperations add constraint fkLeadSurgeonTheatreOperations foreign key (LeadSurgeon)
references Staff (StaffNo)

alter table TheatreOperations add constraint fkLeadAnaesthetistTheatreOperations foreign key (LeadAnaesthetist)
references Staff (StaffNo)

alter table TheatreOperations add constraint fkLeadNurseTheatreOperations foreign key (LeadNurse)
references Staff (StaffNo)

alter table ItemsEXT add constraint fkPharmacistItemsEXT foreign key (Pharmacist)
references Staff (StaffNo)

alter table PathologyReports add constraint fkPathologistPathologyReports foreign key (Pathologist)
references Staff (StaffNo)

alter table IPDTheatreOperations add constraint fkLeadSurgeonIPDTheatreOperations foreign key (LeadSurgeon)
references Staff (StaffNo)

alter table IPDTheatreOperations add constraint fkLeadAnaesthetistIPDTheatreOperations foreign key (LeadAnaesthetist)
references Staff (StaffNo)

alter table IPDTheatreOperations add constraint fkLeadNurseIPDTheatreOperations foreign key (LeadNurse)
references Staff (StaffNo)

alter table IPDDoctor add constraint fkStaffNoIPDDoctor foreign key (StaffNo)
references Staff (StaffNo)

alter table Alerts add constraint fkStaffNoAlerts foreign key (StaffNo)
references Staff (StaffNo)

alter table Appointments add constraint fkStaffNoAppointments foreign key (StaffNo)
references Staff (StaffNo)

alter table ServicesStaffFee add constraint fkStaffNoServicesStaffFee foreign key (StaffNo)
references Staff (StaffNo)

alter table IPDAlerts add constraint fkStaffNoIPDAlerts foreign key (StaffNo)
references Staff (StaffNo)

alter table ExtraBills add constraint fkStaffNoExtraBills foreign key (StaffNo)
references Staff (StaffNo)

alter table IPDItemsEXT add constraint fkPharmacistIPDItemsEXT foreign key (Pharmacist)
references Staff (StaffNo)

alter table Discharges add constraint fkStaffNoDischarges foreign key (StaffNo)
references Staff (StaffNo)

alter table Visits add constraint fkStaffNoVisits foreign key (StaffNo)
references Staff (StaffNo)

alter table DoctorVisits add constraint fkStaffNoDoctorVisits foreign key (StaffNo)
references Staff (StaffNo)
 
alter table LabResults add constraint fkLabTechnologistLabResults foreign key (LabTechnologist)
references Staff (StaffNo)

alter table LabRequests add constraint  fkDrawnByLabRequests foreign key (DrawnBy)
references Staff (StaffNo)

----------------------------------------------------------------------------------------------