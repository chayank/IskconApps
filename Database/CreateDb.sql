Create table DevoteeRelationships
(
  Id int primary key identity(1,1),
  DevoteeId NVARCHAR(450) not null,
  RelationWithDevotee int not null,
  RelatedDevoteeId NVARCHAR(450) not null
  foreign key(DevoteeId) REFERENCES AspNetUsers (Id),
  foreign key(RelatedDevoteeId) REFERENCES AspNetUsers (Id)
)

Create table DevoteeDetails
(
    Id int primary key identity(1,1),
    DevoteeId NVARCHAR(450) not null,
    FirstName varchar(50) Not null,
    LastName varchar(50) Not null,
    InitiatedName varchar(100),
    Gender int,
    Dob DATE not null,
    AddressInfo varchar(200),
    Profession varchar(100),
    MobileNo varchar(10),
    WhatsappMboileNo varchar(15),
    EmergencyContactName varchar(50),
    EmergencyContactMobileNo varchar(10),

    foreign key(DevoteeId) REFERENCES AspNetUsers (Id)
)

Create table DevoteeLanguageProficiency
(
    Id int PRIMARY key identity(1,1),
    DevoteeId NVARCHAR(450) not null,
    Speaking varchar(100),
    Reading varchar(100),
    Writing varchar(100),
    MotherTongue int not null,
    TranslatableFromEnglish varchar(100),
    foreign key(DevoteeId) REFERENCES AspNetUsers (Id)
)

Create table DevoteeSkills
(
    Id int PRIMARY key identity(1,1),
    DevoteeId NVARCHAR(450) not null,
    Learning varchar(200),
    Teaching varchar(200),
    UsingInYatra varchar(200),
    HaveTheSkills varchar(200),
    SpecialSkill varchar(100),
    foreign key(DevoteeId) REFERENCES AspNetUsers (Id)

)

Create table DevoteeSpiritualInformation
(
    Id int PRIMARY key identity(1,1),
    DevoteeId NVARCHAR(450) not null,
    CaregiverId NVARCHAR(450) not null,
    IsAssociatedToBv bit,
    BvName varchar(100),
    SectorName varchar(100),
    CircleName varchar(100),
    ResponsibiltyType int not null,
    Attending varchar(200),
    Teaching varchar(200),
    ShikshaLevel varchar(100),
    ShikshaLevelReceivedDates varchar(100),
    foreign key(DevoteeId) REFERENCES AspNetUsers (Id),
    foreign key(CaregiverId) REFERENCES AspNetUsers (Id)
)