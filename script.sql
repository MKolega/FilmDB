create table AspNetRoles
(
    Id               nvarchar(450) not null
        constraint PK_AspNetRoles
            primary key,
    Name             nvarchar(256),
    NormalizedName   nvarchar(256),
    ConcurrencyStamp nvarchar(max)
)
go

create table AspNetRoleClaims
(
    Id         int identity
        constraint PK_AspNetRoleClaims
            primary key,
    RoleId     nvarchar(450) not null
        constraint FK_AspNetRoleClaims_AspNetRoles_RoleId
            references AspNetRoles
            on delete cascade,
    ClaimType  nvarchar(max),
    ClaimValue nvarchar(max)
)
go

create index IX_AspNetRoleClaims_RoleId
    on AspNetRoleClaims (RoleId)
go

create unique index RoleNameIndex
    on AspNetRoles (NormalizedName)
    where [NormalizedName] IS NOT NULL
go

create table AspNetUsers
(
    Id                   nvarchar(450) not null
        constraint PK_AspNetUsers
            primary key,
    UserName             nvarchar(256),
    NormalizedUserName   nvarchar(256),
    Email                nvarchar(256),
    NormalizedEmail      nvarchar(256),
    EmailConfirmed       bit           not null,
    PasswordHash         nvarchar(max),
    SecurityStamp        nvarchar(max),
    ConcurrencyStamp     nvarchar(max),
    PhoneNumber          nvarchar(max),
    PhoneNumberConfirmed bit           not null,
    TwoFactorEnabled     bit           not null,
    LockoutEnd           datetimeoffset,
    LockoutEnabled       bit           not null,
    AccessFailedCount    int           not null
)
go

create table AspNetUserClaims
(
    Id         int identity
        constraint PK_AspNetUserClaims
            primary key,
    UserId     nvarchar(450) not null
        constraint FK_AspNetUserClaims_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    ClaimType  nvarchar(max),
    ClaimValue nvarchar(max)
)
go

create index IX_AspNetUserClaims_UserId
    on AspNetUserClaims (UserId)
go

create table AspNetUserLogins
(
    LoginProvider       nvarchar(128) not null,
    ProviderKey         nvarchar(128) not null,
    ProviderDisplayName nvarchar(max),
    UserId              nvarchar(450) not null
        constraint FK_AspNetUserLogins_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    constraint PK_AspNetUserLogins
        primary key (LoginProvider, ProviderKey)
)
go

create index IX_AspNetUserLogins_UserId
    on AspNetUserLogins (UserId)
go

create table AspNetUserRoles
(
    UserId nvarchar(450) not null
        constraint FK_AspNetUserRoles_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    RoleId nvarchar(450) not null
        constraint FK_AspNetUserRoles_AspNetRoles_RoleId
            references AspNetRoles
            on delete cascade,
    constraint PK_AspNetUserRoles
        primary key (UserId, RoleId)
)
go

create index IX_AspNetUserRoles_RoleId
    on AspNetUserRoles (RoleId)
go

create table AspNetUserTokens
(
    UserId        nvarchar(450) not null
        constraint FK_AspNetUserTokens_AspNetUsers_UserId
            references AspNetUsers
            on delete cascade,
    LoginProvider nvarchar(128) not null,
    Name          nvarchar(128) not null,
    Value         nvarchar(max),
    constraint PK_AspNetUserTokens
        primary key (UserId, LoginProvider, Name)
)
go

create index EmailIndex
    on AspNetUsers (NormalizedEmail)
go

create unique index UserNameIndex
    on AspNetUsers (NormalizedUserName)
    where [NormalizedUserName] IS NOT NULL
go

create table Director
(
    ID    int identity
        constraint PK_Director
            primary key,
    Name  nvarchar(max) not null,
    Bio   nvarchar(max),
    Image nvarchar(max)
)
go

create table Movies
(
    ID          int identity
        constraint PK_Movies
            primary key,
    Title       nvarchar(max) not null,
    Description nvarchar(max) not null,
    Image       nvarchar(max) not null,
    Genre       nvarchar(max) not null,
    Year        int           not null,
    DirectorID  int
        constraint FK_Movies_Director_DirectorID
            references Director
)
go

create index IX_Movies_DirectorID
    on Movies (DirectorID)
go

create table __EFMigrationsHistory
(
    MigrationId    nvarchar(150) not null
        constraint PK___EFMigrationsHistory
            primary key,
    ProductVersion nvarchar(32)  not null
)
go


