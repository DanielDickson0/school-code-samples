CREATE DATABASE ProjectDB
go

USE ProjectDB
go

CREATE TABLE Threads
(ThreadID integer not null,
Title text not null,
BodyText text,
LikeCount integer not null,
DislikeCount integer not null,
CONSTRAINT PK_Threads PRIMARY KEY (ThreadID))
go

CREATE TABLE Concepts
(ThreadID integer not null,
VoteCount integer not null,
CONSTRAINT FK_Concepts_Threads FOREIGN KEY (ThreadID) REFERENCES Threads)
go

CREATE TABLE Attachments
(AttachmentID integer not null,
AttachmentLink text not null,
ThreadID integer not null,
CONSTRAINT PK_Attachments PRIMARY KEY (AttachmentID),
CONSTRAINT FK_Attachments_Threads FOREIGN KEY (ThreadID) REFERENCES Threads)
go

CREATE TABLE Reports
(ReportID integer not null,
Reason text not null,
BodyText text,
ThreadID integer not null,
CONSTRAINT PK_Reports PRIMARY KEY (ReportID),
CONSTRAINT FK_Reports_Threads FOREIGN KEY (ThreadID) REFERENCES Threads)
go

CREATE TABLE EmployeeApplications
(ApplicationID integer not null,
FirstName text not null,
MidInitial char(1),
LastName text not null,
Suffix text,
StreetAddress text not null,
StreetAddress2 text,
City text not null,
StateProvince text not null,
Country text not null,
ZIP char(5) not null,
HomePhone text not null,
WorkPhone text,
Email text not null,
CONSTRAINT PK_EmployeeApplications PRIMARY KEY (ApplicationID))
go