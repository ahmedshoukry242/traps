IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [Companies] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [Traps] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [SerialNumber] nvarchar(450) NULL,
        [TrapStatus] int NOT NULL,
        [Iema] nvarchar(max) NULL,
        [ValveQut] nvarchar(max) NULL,
        [Fan] int NOT NULL,
        [IsCounterOn] bit NOT NULL,
        [IsCounterReadingFromSimCard] bit NOT NULL,
        [ReadingDate] datetime2 NOT NULL,
        [Lat] nvarchar(max) NULL,
        [Long] nvarchar(max) NULL,
        [IsScheduleOn] bit NOT NULL,
        [BigBattery] nvarchar(max) NULL,
        [SmallBattery] nvarchar(max) NULL,
        [FileDate] datetime2 NOT NULL,
        [IsThereEmergency] bit NOT NULL,
        [IsNew] bit NOT NULL,
        [LastLat] nvarchar(max) NULL,
        [LastLong] nvarchar(max) NULL,
        [CategoryId] int NULL,
        [CountryId] int NULL,
        [StateId] int NULL,
        CONSTRAINT [PK_Traps] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] uniqueidentifier NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [TrapReads] (
        [Id] int NOT NULL IDENTITY,
        [Date] date NOT NULL,
        [TrapId] int NOT NULL,
        CONSTRAINT [PK_TrapReads] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TrapReads_Traps_TrapId] FOREIGN KEY ([TrapId]) REFERENCES [Traps] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [UserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_UserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [UserRoles] (
        [UserId] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_UserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [UserTokens] (
        [UserId] uniqueidentifier NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_UserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [UserTraps] (
        [Id] int NOT NULL IDENTITY,
        [UserId] uniqueidentifier NOT NULL,
        [TrapId] int NOT NULL,
        CONSTRAINT [PK_UserTraps] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserTraps_Traps_TrapId] FOREIGN KEY ([TrapId]) REFERENCES [Traps] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserTraps_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE TABLE [ReadDetails] (
        [Id] int NOT NULL IDENTITY,
        [Time] time NOT NULL,
        [SerialNumber] nvarchar(max) NOT NULL,
        [ReadingLat] nvarchar(max) NOT NULL,
        [ReadingLng] nvarchar(max) NOT NULL,
        [Counter] int NOT NULL,
        [Fan] int NOT NULL,
        [Co2] int NOT NULL,
        [Co2Val] nvarchar(max) NOT NULL,
        [ReadingSmall] nvarchar(max) NOT NULL,
        [ReadingLarg] nvarchar(max) NOT NULL,
        [ReadingMosuqitoes] nvarchar(max) NOT NULL,
        [ReadingTempIn] nvarchar(max) NOT NULL,
        [ReadingTempOut] nvarchar(max) NOT NULL,
        [ReadingWindSpeed] nvarchar(max) NOT NULL,
        [ReadingHumidty] nvarchar(max) NOT NULL,
        [Amb_Light] nvarchar(max) NOT NULL,
        [Battery] nvarchar(max) NOT NULL,
        [Reception] nvarchar(max) NOT NULL,
        [Power_Draw] nvarchar(max) NOT NULL,
        [ReadingFly] nvarchar(max) NOT NULL,
        [BigBattery] nvarchar(max) NOT NULL,
        [SmallBattery] nvarchar(max) NOT NULL,
        [IsDone] bit NOT NULL,
        [IsClean] bit NOT NULL,
        [TrapReadId] int NOT NULL,
        CONSTRAINT [PK_ReadDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ReadDetails_TrapReads_TrapReadId] FOREIGN KEY ([TrapReadId]) REFERENCES [TrapReads] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE INDEX [IX_ReadDetails_TrapReadId] ON [ReadDetails] ([TrapReadId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE INDEX [IX_TrapReads_TrapId] ON [TrapReads] ([TrapId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    EXEC(N'CREATE INDEX [IX_Traps_SerialNumber] ON [Traps] ([SerialNumber]) WHERE [SerialNumber] IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE INDEX [IX_UserLogins_UserId] ON [UserLogins] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [Users] ([NormalizedEmail]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [Users] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE INDEX [IX_UserTraps_TrapId] ON [UserTraps] ([TrapId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    CREATE UNIQUE INDEX [IX_UserTraps_UserId_TrapId] ON [UserTraps] ([UserId], [TrapId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250827134638_InitialCreation'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250827134638_InitialCreation', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831094232_TrapModifications01'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Traps]') AND [c].[name] = N'ValveQut');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Traps] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [Traps] ALTER COLUMN [ValveQut] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831094232_TrapModifications01'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Traps]') AND [c].[name] = N'Iema');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Traps] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Traps] ALTER COLUMN [Iema] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831094232_TrapModifications01'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Traps]') AND [c].[name] = N'FileDate');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Traps] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Traps] ALTER COLUMN [FileDate] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831094232_TrapModifications01'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Traps]') AND [c].[name] = N'Fan');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Traps] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Traps] ALTER COLUMN [Fan] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831094232_TrapModifications01'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250831094232_TrapModifications01', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831115512_TrapReadingModification01'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ReadDetails]') AND [c].[name] = N'Amb_Light');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ReadDetails] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ReadDetails] DROP COLUMN [Amb_Light];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831115512_TrapReadingModification01'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ReadDetails]') AND [c].[name] = N'Battery');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [ReadDetails] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [ReadDetails] DROP COLUMN [Battery];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831115512_TrapReadingModification01'
)
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ReadDetails]') AND [c].[name] = N'Power_Draw');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ReadDetails] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ReadDetails] DROP COLUMN [Power_Draw];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831115512_TrapReadingModification01'
)
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ReadDetails]') AND [c].[name] = N'Reception');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [ReadDetails] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [ReadDetails] DROP COLUMN [Reception];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250831115512_TrapReadingModification01'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250831115512_TrapReadingModification01', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250902081945_check'
)
BEGIN
    ALTER TABLE [TrapReads] ADD [ServerCreationDate] date NOT NULL DEFAULT '0001-01-01';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250902081945_check'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250902081945_check', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250902114047_TrapModification02'
)
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Traps]') AND [c].[name] = N'ReadingDate');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Traps] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Traps] ALTER COLUMN [ReadingDate] datetime2 NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250902114047_TrapModification02'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250902114047_TrapModification02', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    ALTER TABLE [Users] ADD [Name] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    CREATE TABLE [Countries] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [TimeZoneName] nvarchar(max) NOT NULL,
        [UtcOffsetMinutes] int NOT NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    CREATE TABLE [States] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [CountryId] int NOT NULL,
        CONSTRAINT [PK_States] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_States_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Name])
    VALUES (1, N''None''),
    (2, N''Afaq'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'TimeZoneName', N'UtcOffsetMinutes') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Name], [TimeZoneName], [UtcOffsetMinutes])
    VALUES (1, N''Egypt'', N''Africa/Cairo'', 120),
    (2, N''Saudi Arabia'', N''Asia/Riyadh'', 180),
    (3, N''United Arab Emirates'', N''Asia/Dubai'', 240),
    (4, N''Qatar'', N''Asia/Qatar'', 180)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'TimeZoneName', N'UtcOffsetMinutes') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CountryId', N'Name') AND [object_id] = OBJECT_ID(N'[States]'))
        SET IDENTITY_INSERT [States] ON;
    EXEC(N'INSERT INTO [States] ([Id], [CountryId], [Name])
    VALUES (1, 1, N''Cairo''),
    (2, 1, N''Alexandria''),
    (3, 1, N''Giza''),
    (4, 1, N''Damietta''),
    (5, 1, N''Port Said''),
    (6, 1, N''Suez''),
    (7, 1, N''Aswan''),
    (8, 1, N''Luxor''),
    (9, 1, N''Qena''),
    (10, 1, N''Sohag''),
    (11, 1, N''Ismailia''),
    (12, 1, N''Menofia''),
    (13, 1, N''Qalyubia''),
    (14, 1, N''Sharqia''),
    (15, 1, N''Beheira''),
    (16, 1, N''Fayoum''),
    (17, 1, N''Minya''),
    (18, 1, N''Asyut''),
    (19, 1, N''Dakahlia''),
    (20, 1, N''Matruh''),
    (21, 1, N''Beni Suef''),
    (22, 1, N''Red Sea''),
    (23, 1, N''North Sinai''),
    (24, 1, N''South Sinai''),
    (26, 2, N''Riyadh''),
    (27, 2, N''Jeddah''),
    (28, 2, N''Mecca''),
    (29, 2, N''Medina''),
    (30, 2, N''Dammam''),
    (31, 2, N''Khobar''),
    (32, 2, N''Tabuk''),
    (33, 2, N''Hail''),
    (34, 2, N''Qassim''),
    (35, 2, N''Najran''),
    (36, 2, N''Jizan''),
    (37, 2, N''Asir''),
    (38, 2, N''Al Bahah''),
    (39, 2, N''Northern Borders''),
    (40, 2, N''Jouf''),
    (41, 3, N''Dubai''),
    (42, 3, N''Abu Dhabi''),
    (43, 3, N''Sharjah'');
    INSERT INTO [States] ([Id], [CountryId], [Name])
    VALUES (44, 3, N''Ajman''),
    (45, 3, N''Umm Al-Quwain''),
    (46, 3, N''Fujairah''),
    (47, 3, N''Ras Al Khaimah''),
    (48, 4, N''Doha''),
    (49, 4, N''Al Wakrah''),
    (50, 4, N''Al Khor''),
    (51, 4, N''Mesaieed''),
    (52, 4, N''Al Rayyan''),
    (53, 4, N''Al Daayen''),
    (54, 4, N''Umm Salal'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CountryId', N'Name') AND [object_id] = OBJECT_ID(N'[States]'))
        SET IDENTITY_INSERT [States] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    CREATE INDEX [IX_Traps_CategoryId] ON [Traps] ([CategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    CREATE INDEX [IX_Traps_CountryId] ON [Traps] ([CountryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    CREATE INDEX [IX_States_CountryId] ON [States] ([CountryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    ALTER TABLE [Traps] ADD CONSTRAINT [FK_Traps_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    ALTER TABLE [Traps] ADD CONSTRAINT [FK_Traps_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    ALTER TABLE [Traps] ADD CONSTRAINT [FK_Traps_States_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [States] ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250903081844_Lookups'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250903081844_Lookups', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250907092706_trapEmergency'
)
BEGIN
    CREATE TABLE [TrapEmergency] (
        [Id] int NOT NULL IDENTITY,
        [Lat] nvarchar(max) NULL,
        [Long] nvarchar(max) NULL,
        [Date] datetime2 NOT NULL,
        [EmergencyStatus] bit NOT NULL,
        [TrapId] int NOT NULL,
        CONSTRAINT [PK_TrapEmergency] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TrapEmergency_Traps_TrapId] FOREIGN KEY ([TrapId]) REFERENCES [Traps] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250907092706_trapEmergency'
)
BEGIN
    CREATE INDEX [IX_TrapEmergency_TrapId] ON [TrapEmergency] ([TrapId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250907092706_trapEmergency'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250907092706_trapEmergency', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250907113913_trapEmergency02'
)
BEGIN
    ALTER TABLE [TrapEmergency] ADD [InsertDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250907113913_trapEmergency02'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250907113913_trapEmergency02', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250909115822_Users01'
)
BEGIN
    ALTER TABLE [Users] ADD [IsLocked] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250909115822_Users01'
)
BEGIN
    ALTER TABLE [Users] ADD [LockReason] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250909115822_Users01'
)
BEGIN
    ALTER TABLE [Users] ADD [ParentUserId] uniqueidentifier NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250909115822_Users01'
)
BEGIN
    CREATE INDEX [IX_Users_ParentUserId] ON [Users] ([ParentUserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250909115822_Users01'
)
BEGIN
    ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Users_ParentUserId] FOREIGN KEY ([ParentUserId]) REFERENCES [Users] ([Id]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250909115822_Users01'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250909115822_Users01', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250910090219_trapReadIndex'
)
BEGIN
    DROP INDEX [IX_TrapReads_TrapId] ON [TrapReads];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250910090219_trapReadIndex'
)
BEGIN
    CREATE INDEX [IX_TrapReads_TrapId_Date_Up] ON [TrapReads] ([TrapId], [Date]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250910090219_trapReadIndex'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250910090219_trapReadIndex', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    DROP INDEX [IX_TrapReads_TrapId_Date] ON [TrapReads];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Name])
    VALUES (3, N''Industrial''),
    (4, N''Agricultural''),
    (5, N''Residential''),
    (6, N''Commercial'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
        SET IDENTITY_INSERT [Companies] ON;
    EXEC(N'INSERT INTO [Companies] ([Id], [Name])
    VALUES (1, N''TechCorp Solutions''),
    (2, N''Green Valley Industries''),
    (3, N''Desert Shield Technologies''),
    (4, N''Oasis Environmental Systems''),
    (5, N''Gulf Monitoring Services''),
    (6, N''Smart Trap Solutions''),
    (7, N''EcoGuard Systems''),
    (8, N''Advanced Pest Control''),
    (9, N''Regional Safety Corp''),
    (10, N''Innovation Labs Ltd'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Companies]'))
        SET IDENTITY_INSERT [Companies] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BigBattery', N'CategoryId', N'CountryId', N'Fan', N'FileDate', N'Iema', N'IsCounterOn', N'IsCounterReadingFromSimCard', N'IsNew', N'IsScheduleOn', N'IsThereEmergency', N'LastLat', N'LastLong', N'Lat', N'Long', N'Name', N'ReadingDate', N'SerialNumber', N'SmallBattery', N'StateId', N'TrapStatus', N'ValveQut') AND [object_id] = OBJECT_ID(N'[Traps]'))
        SET IDENTITY_INSERT [Traps] ON;
    EXEC(N'INSERT INTO [Traps] ([Id], [BigBattery], [CategoryId], [CountryId], [Fan], [FileDate], [Iema], [IsCounterOn], [IsCounterReadingFromSimCard], [IsNew], [IsScheduleOn], [IsThereEmergency], [LastLat], [LastLong], [Lat], [Long], [Name], [ReadingDate], [SerialNumber], [SmallBattery], [StateId], [TrapStatus], [ValveQut])
    VALUES (1, NULL, 2, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(1 AS bit), CAST(1 AS bit), CAST(0 AS bit), CAST(0 AS bit), NULL, NULL, N''30.0444'', N''31.2357'', N''Cairo Central Trap'', NULL, N''TRP001'', NULL, 1, 1, NULL),
    (4, NULL, 2, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(1 AS bit), CAST(1 AS bit), CAST(1 AS bit), CAST(0 AS bit), NULL, NULL, N''24.7136'', N''46.6753'', N''Riyadh Smart Trap'', NULL, N''TRP004'', NULL, 26, 1, NULL),
    (9, NULL, 2, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), NULL, NULL, N''24.0889'', N''32.8998'', N''Aswan Desert Trap'', NULL, N''TRP009'', NULL, 7, 1, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BigBattery', N'CategoryId', N'CountryId', N'Fan', N'FileDate', N'Iema', N'IsCounterOn', N'IsCounterReadingFromSimCard', N'IsNew', N'IsScheduleOn', N'IsThereEmergency', N'LastLat', N'LastLong', N'Lat', N'Long', N'Name', N'ReadingDate', N'SerialNumber', N'SmallBattery', N'StateId', N'TrapStatus', N'ValveQut') AND [object_id] = OBJECT_ID(N'[Traps]'))
        SET IDENTITY_INSERT [Traps] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'IsLocked', N'LockReason', N'LockoutEnabled', N'LockoutEnd', N'Name', N'NormalizedEmail', N'NormalizedUserName', N'ParentUserId', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [IsLocked], [LockReason], [LockoutEnabled], [LockoutEnd], [Name], [NormalizedEmail], [NormalizedUserName], [ParentUserId], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (''11111111-1111-1111-1111-111111111111'', 0, N''7237ba19-3191-4ea5-8dc7-9c365a81dc7c'', N''user1@example.com'', CAST(1 AS bit), CAST(0 AS bit), NULL, CAST(0 AS bit), NULL, N''User 1'', N''USER1@EXAMPLE.COM'', N''USER1@EXAMPLE.COM'', NULL, N''AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ='', NULL, CAST(0 AS bit), NULL, CAST(0 AS bit), N''user1@example.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'IsLocked', N'LockReason', N'LockoutEnabled', N'LockoutEnd', N'Name', N'NormalizedEmail', N'NormalizedUserName', N'ParentUserId', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapCounterSchedules]'))
        SET IDENTITY_INSERT [TrapCounterSchedules] ON;
    EXEC(N'INSERT INTO [TrapCounterSchedules] ([Id], [ScdTime], [Status], [TrapId])
    VALUES (10, 0, CAST(1 AS bit), 4),
    (11, 6, CAST(1 AS bit), 4),
    (12, 12, CAST(1 AS bit), 4),
    (13, 18, CAST(1 AS bit), 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapCounterSchedules]'))
        SET IDENTITY_INSERT [TrapCounterSchedules] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapFanSchedules]'))
        SET IDENTITY_INSERT [TrapFanSchedules] ON;
    EXEC(N'INSERT INTO [TrapFanSchedules] ([Id], [ScdTime], [Status], [TrapId])
    VALUES (14, 2, CAST(1 AS bit), 4),
    (15, 10, CAST(1 AS bit), 4),
    (16, 18, CAST(1 AS bit), 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapFanSchedules]'))
        SET IDENTITY_INSERT [TrapFanSchedules] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'ServerCreationDate', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapReads]'))
        SET IDENTITY_INSERT [TrapReads] ON;
    EXEC(N'INSERT INTO [TrapReads] ([Id], [Date], [ServerCreationDate], [TrapId])
    VALUES (1, ''2024-01-01'', ''2024-01-02'', 1),
    (2, ''2024-01-03'', ''2024-01-04'', 1),
    (3, ''2024-01-05'', ''2024-01-06'', 1),
    (4, ''2024-01-07'', ''2024-01-08'', 1),
    (5, ''2024-01-09'', ''2024-01-10'', 1),
    (6, ''2024-01-11'', ''2024-01-12'', 1),
    (7, ''2024-01-13'', ''2024-01-14'', 1),
    (8, ''2024-01-15'', ''2024-01-16'', 1),
    (9, ''2024-01-17'', ''2024-01-18'', 1),
    (10, ''2024-01-19'', ''2024-01-20'', 1),
    (11, ''2024-01-21'', ''2024-01-22'', 1),
    (12, ''2024-01-23'', ''2024-01-24'', 1),
    (13, ''2024-01-25'', ''2024-01-26'', 1),
    (14, ''2024-01-27'', ''2024-01-28'', 1),
    (15, ''2024-01-29'', ''2024-01-30'', 1),
    (46, ''2024-03-31'', ''2024-04-01'', 4),
    (47, ''2024-04-02'', ''2024-04-03'', 4),
    (48, ''2024-04-04'', ''2024-04-05'', 4),
    (49, ''2024-04-06'', ''2024-04-07'', 4),
    (50, ''2024-04-08'', ''2024-04-09'', 4),
    (51, ''2024-04-10'', ''2024-04-11'', 4),
    (52, ''2024-04-12'', ''2024-04-13'', 4),
    (53, ''2024-04-14'', ''2024-04-15'', 4),
    (54, ''2024-04-16'', ''2024-04-17'', 4),
    (55, ''2024-04-18'', ''2024-04-19'', 4),
    (56, ''2024-04-20'', ''2024-04-21'', 4),
    (57, ''2024-04-22'', ''2024-04-23'', 4),
    (58, ''2024-04-24'', ''2024-04-25'', 4),
    (59, ''2024-04-26'', ''2024-04-27'', 4),
    (60, ''2024-04-28'', ''2024-04-29'', 4),
    (121, ''2024-08-28'', ''2024-08-29'', 9),
    (122, ''2024-08-30'', ''2024-08-31'', 9),
    (123, ''2024-09-01'', ''2024-09-02'', 9),
    (124, ''2024-09-03'', ''2024-09-04'', 9),
    (125, ''2024-09-05'', ''2024-09-06'', 9),
    (126, ''2024-09-07'', ''2024-09-08'', 9),
    (127, ''2024-09-09'', ''2024-09-10'', 9),
    (128, ''2024-09-11'', ''2024-09-12'', 9),
    (129, ''2024-09-13'', ''2024-09-14'', 9),
    (130, ''2024-09-15'', ''2024-09-16'', 9),
    (131, ''2024-09-17'', ''2024-09-18'', 9),
    (132, ''2024-09-19'', ''2024-09-20'', 9);
    INSERT INTO [TrapReads] ([Id], [Date], [ServerCreationDate], [TrapId])
    VALUES (133, ''2024-09-21'', ''2024-09-22'', 9),
    (134, ''2024-09-23'', ''2024-09-24'', 9),
    (135, ''2024-09-25'', ''2024-09-26'', 9)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'ServerCreationDate', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapReads]'))
        SET IDENTITY_INSERT [TrapReads] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapValveQutSchedules]'))
        SET IDENTITY_INSERT [TrapValveQutSchedules] ON;
    EXEC(N'INSERT INTO [TrapValveQutSchedules] ([Id], [ScdTime], [Status], [TrapId])
    VALUES (17, 4, CAST(1 AS bit), 4),
    (18, 16, CAST(1 AS bit), 4)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapValveQutSchedules]'))
        SET IDENTITY_INSERT [TrapValveQutSchedules] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BigBattery', N'CategoryId', N'CountryId', N'Fan', N'FileDate', N'Iema', N'IsCounterOn', N'IsCounterReadingFromSimCard', N'IsNew', N'IsScheduleOn', N'IsThereEmergency', N'LastLat', N'LastLong', N'Lat', N'Long', N'Name', N'ReadingDate', N'SerialNumber', N'SmallBattery', N'StateId', N'TrapStatus', N'ValveQut') AND [object_id] = OBJECT_ID(N'[Traps]'))
        SET IDENTITY_INSERT [Traps] ON;
    EXEC(N'INSERT INTO [Traps] ([Id], [BigBattery], [CategoryId], [CountryId], [Fan], [FileDate], [Iema], [IsCounterOn], [IsCounterReadingFromSimCard], [IsNew], [IsScheduleOn], [IsThereEmergency], [LastLat], [LastLong], [Lat], [Long], [Name], [ReadingDate], [SerialNumber], [SmallBattery], [StateId], [TrapStatus], [ValveQut])
    VALUES (2, NULL, 3, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(1 AS bit), CAST(0 AS bit), CAST(1 AS bit), CAST(0 AS bit), NULL, NULL, N''31.2001'', N''29.9187'', N''Alexandria Port Trap'', NULL, N''TRP002'', NULL, 2, 1, NULL),
    (3, NULL, 4, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), NULL, NULL, N''30.0131'', N''31.2089'', N''Giza Industrial Trap'', NULL, N''TRP003'', NULL, 3, 1, NULL),
    (5, NULL, 5, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(1 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), NULL, NULL, N''25.2048'', N''55.2708'', N''Dubai Advanced Trap'', NULL, N''TRP005'', NULL, 41, 1, NULL),
    (6, NULL, 6, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(0 AS bit), CAST(1 AS bit), CAST(1 AS bit), CAST(0 AS bit), NULL, NULL, N''25.2854'', N''51.5310'', N''Doha Monitoring Trap'', NULL, N''TRP006'', NULL, 48, 1, NULL),
    (7, NULL, 3, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(1 AS bit), CAST(0 AS bit), CAST(0 AS bit), CAST(0 AS bit), NULL, NULL, N''21.4858'', N''39.1925'', N''Jeddah Coastal Trap'', NULL, N''TRP007'', NULL, 27, 1, NULL),
    (8, NULL, 4, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(1 AS bit), CAST(1 AS bit), CAST(1 AS bit), CAST(0 AS bit), NULL, NULL, N''24.4539'', N''54.3773'', N''Abu Dhabi Control Trap'', NULL, N''TRP008'', NULL, 42, 1, NULL),
    (10, NULL, 5, NULL, NULL, NULL, NULL, CAST(1 AS bit), CAST(1 AS bit), CAST(1 AS bit), CAST(1 AS bit), CAST(0 AS bit), NULL, NULL, N''25.3463'', N''55.4209'', N''Sharjah Tech Trap'', NULL, N''TRP010'', NULL, 43, 1, NULL)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BigBattery', N'CategoryId', N'CountryId', N'Fan', N'FileDate', N'Iema', N'IsCounterOn', N'IsCounterReadingFromSimCard', N'IsNew', N'IsScheduleOn', N'IsThereEmergency', N'LastLat', N'LastLong', N'Lat', N'Long', N'Name', N'ReadingDate', N'SerialNumber', N'SmallBattery', N'StateId', N'TrapStatus', N'ValveQut') AND [object_id] = OBJECT_ID(N'[Traps]'))
        SET IDENTITY_INSERT [Traps] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'TrapId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserTraps]'))
        SET IDENTITY_INSERT [UserTraps] ON;
    EXEC(N'INSERT INTO [UserTraps] ([Id], [TrapId], [UserId])
    VALUES (1, 1, ''11111111-1111-1111-1111-111111111111'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'TrapId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserTraps]'))
        SET IDENTITY_INSERT [UserTraps] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'IsLocked', N'LockReason', N'LockoutEnabled', N'LockoutEnd', N'Name', N'NormalizedEmail', N'NormalizedUserName', N'ParentUserId', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] ON;
    EXEC(N'INSERT INTO [Users] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [IsLocked], [LockReason], [LockoutEnabled], [LockoutEnd], [Name], [NormalizedEmail], [NormalizedUserName], [ParentUserId], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName])
    VALUES (''22222222-2222-2222-2222-222222222222'', 0, N''b2f04e23-0bcc-493c-83eb-398fa9eb893d'', N''user2@example.com'', CAST(1 AS bit), CAST(0 AS bit), NULL, CAST(0 AS bit), NULL, N''User 2'', N''USER2@EXAMPLE.COM'', N''USER2@EXAMPLE.COM'', ''11111111-1111-1111-1111-111111111111'', N''AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ='', NULL, CAST(0 AS bit), NULL, CAST(0 AS bit), N''user2@example.com''),
    (''33333333-3333-3333-3333-333333333333'', 0, N''8768756b-2278-441f-a3b2-73dbb5f47b9d'', N''user3@example.com'', CAST(1 AS bit), CAST(0 AS bit), NULL, CAST(0 AS bit), NULL, N''User 3'', N''USER3@EXAMPLE.COM'', N''USER3@EXAMPLE.COM'', ''11111111-1111-1111-1111-111111111111'', N''AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ='', NULL, CAST(0 AS bit), NULL, CAST(0 AS bit), N''user3@example.com''),
    (''44444444-4444-4444-4444-444444444444'', 0, N''5b21d9fc-4309-4fee-8731-32853af27441'', N''user4@example.com'', CAST(1 AS bit), CAST(0 AS bit), NULL, CAST(0 AS bit), NULL, N''User 4'', N''USER4@EXAMPLE.COM'', N''USER4@EXAMPLE.COM'', ''11111111-1111-1111-1111-111111111111'', N''AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ='', NULL, CAST(0 AS bit), NULL, CAST(0 AS bit), N''user4@example.com''),
    (''55555555-5555-5555-5555-555555555555'', 0, N''15f4aaa5-8c8a-4eee-945b-b4b813b3d97a'', N''user5@example.com'', CAST(1 AS bit), CAST(0 AS bit), NULL, CAST(0 AS bit), NULL, N''User 5'', N''USER5@EXAMPLE.COM'', N''USER5@EXAMPLE.COM'', ''11111111-1111-1111-1111-111111111111'', N''AQAAAAEAACcQAAAAEJ7t2Kd8Qz9QzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQzQ='', NULL, CAST(0 AS bit), NULL, CAST(0 AS bit), N''user5@example.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'Email', N'EmailConfirmed', N'IsLocked', N'LockReason', N'LockoutEnabled', N'LockoutEnd', N'Name', N'NormalizedEmail', N'NormalizedUserName', N'ParentUserId', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[Users]'))
        SET IDENTITY_INSERT [Users] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BigBattery', N'Co2', N'Co2Val', N'Counter', N'Fan', N'IsClean', N'IsDone', N'ReadingFly', N'ReadingHumidty', N'ReadingLarg', N'ReadingLat', N'ReadingLng', N'ReadingMosuqitoes', N'ReadingSmall', N'ReadingTempIn', N'ReadingTempOut', N'ReadingWindSpeed', N'SerialNumber', N'SmallBattery', N'Time', N'TrapReadId') AND [object_id] = OBJECT_ID(N'[ReadDetails]'))
        SET IDENTITY_INSERT [ReadDetails] ON;
    EXEC(N'INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (1, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000001'', N''78'', ''08:15:00'', 1),
    (2, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000002'', N''85'', ''12:30:00'', 1),
    (3, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN001000003'', N''72'', ''16:45:00'', 1),
    (4, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN001000004'', N''88'', ''20:00:00'', 1),
    (5, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN001000005'', N''75'', ''06:20:00'', 1),
    (6, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN001000006'', N''82'', ''10:35:00'', 2),
    (7, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN001000007'', N''79'', ''14:50:00'', 2),
    (8, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN001000008'', N''86'', ''18:05:00'', 2),
    (9, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN001000009'', N''74'', ''22:25:00'', 2),
    (10, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN001000010'', N''81'', ''02:40:00'', 2),
    (11, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000011'', N''78'', ''08:15:00'', 2),
    (12, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000012'', N''85'', ''12:30:00'', 3),
    (13, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN001000013'', N''72'', ''16:45:00'', 3),
    (14, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN001000014'', N''88'', ''20:00:00'', 3),
    (15, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN001000015'', N''75'', ''06:20:00'', 3),
    (16, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN001000016'', N''82'', ''10:35:00'', 4),
    (17, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN001000017'', N''79'', ''14:50:00'', 4),
    (18, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN001000018'', N''86'', ''18:05:00'', 4),
    (19, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN001000019'', N''74'', ''22:25:00'', 4),
    (20, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN001000020'', N''81'', ''02:40:00'', 4),
    (21, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000021'', N''78'', ''08:15:00'', 4),
    (22, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000022'', N''85'', ''12:30:00'', 4),
    (23, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN001000023'', N''72'', ''16:45:00'', 5),
    (24, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN001000024'', N''88'', ''20:00:00'', 5),
    (25, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN001000025'', N''75'', ''06:20:00'', 5),
    (26, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN001000026'', N''82'', ''10:35:00'', 5),
    (27, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN001000027'', N''79'', ''14:50:00'', 5),
    (28, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN001000028'', N''86'', ''18:05:00'', 6),
    (29, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN001000029'', N''74'', ''22:25:00'', 6),
    (30, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN001000030'', N''81'', ''02:40:00'', 6),
    (31, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000031'', N''78'', ''08:15:00'', 6),
    (32, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000032'', N''85'', ''12:30:00'', 6),
    (33, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN001000033'', N''72'', ''16:45:00'', 6),
    (34, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN001000034'', N''88'', ''20:00:00'', 7),
    (35, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN001000035'', N''75'', ''06:20:00'', 7),
    (36, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN001000036'', N''82'', ''10:35:00'', 7),
    (37, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN001000037'', N''79'', ''14:50:00'', 7),
    (38, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN001000038'', N''86'', ''18:05:00'', 8),
    (39, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN001000039'', N''74'', ''22:25:00'', 8),
    (40, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN001000040'', N''81'', ''02:40:00'', 8),
    (41, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000041'', N''78'', ''08:15:00'', 8),
    (42, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000042'', N''85'', ''12:30:00'', 8);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (43, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN001000043'', N''72'', ''16:45:00'', 9),
    (44, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN001000044'', N''88'', ''20:00:00'', 9),
    (45, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN001000045'', N''75'', ''06:20:00'', 9),
    (46, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN001000046'', N''82'', ''10:35:00'', 9),
    (47, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN001000047'', N''79'', ''14:50:00'', 9),
    (48, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN001000048'', N''86'', ''18:05:00'', 9),
    (49, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN001000049'', N''74'', ''22:25:00'', 10),
    (50, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN001000050'', N''81'', ''02:40:00'', 10),
    (51, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000051'', N''78'', ''08:15:00'', 10),
    (52, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000052'', N''85'', ''12:30:00'', 10),
    (53, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN001000053'', N''72'', ''16:45:00'', 10),
    (54, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN001000054'', N''88'', ''20:00:00'', 10),
    (55, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN001000055'', N''75'', ''06:20:00'', 10),
    (56, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN001000056'', N''82'', ''10:35:00'', 11),
    (57, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN001000057'', N''79'', ''14:50:00'', 11),
    (58, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN001000058'', N''86'', ''18:05:00'', 11),
    (59, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN001000059'', N''74'', ''22:25:00'', 11),
    (60, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN001000060'', N''81'', ''02:40:00'', 11),
    (61, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000061'', N''78'', ''08:15:00'', 12),
    (62, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000062'', N''85'', ''12:30:00'', 12),
    (63, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN001000063'', N''72'', ''16:45:00'', 12),
    (64, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN001000064'', N''88'', ''20:00:00'', 12),
    (65, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN001000065'', N''75'', ''06:20:00'', 12),
    (66, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN001000066'', N''82'', ''10:35:00'', 12),
    (67, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN001000067'', N''79'', ''14:50:00'', 13),
    (68, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN001000068'', N''86'', ''18:05:00'', 13),
    (69, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN001000069'', N''74'', ''22:25:00'', 13),
    (70, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN001000070'', N''81'', ''02:40:00'', 13),
    (71, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000071'', N''78'', ''08:15:00'', 14),
    (72, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000072'', N''85'', ''12:30:00'', 14),
    (73, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN001000073'', N''72'', ''16:45:00'', 14),
    (74, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN001000074'', N''88'', ''20:00:00'', 14),
    (75, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN001000075'', N''75'', ''06:20:00'', 14),
    (76, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN001000076'', N''82'', ''10:35:00'', 14),
    (77, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN001000077'', N''79'', ''14:50:00'', 14),
    (78, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN001000078'', N''86'', ''18:05:00'', 15),
    (79, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN001000079'', N''74'', ''22:25:00'', 15),
    (80, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN001000080'', N''81'', ''02:40:00'', 15),
    (81, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN001000081'', N''78'', ''08:15:00'', 15),
    (82, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN001000082'', N''85'', ''12:30:00'', 15),
    (248, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000248'', N''86'', ''18:05:00'', 46),
    (249, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000249'', N''74'', ''22:25:00'', 46);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (250, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000250'', N''81'', ''02:40:00'', 46),
    (251, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN004000251'', N''78'', ''08:15:00'', 46),
    (252, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN004000252'', N''85'', ''12:30:00'', 46),
    (253, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN004000253'', N''72'', ''16:45:00'', 46),
    (254, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN004000254'', N''88'', ''20:00:00'', 47),
    (255, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN004000255'', N''75'', ''06:20:00'', 47),
    (256, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN004000256'', N''82'', ''10:35:00'', 47),
    (257, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN004000257'', N''79'', ''14:50:00'', 47),
    (258, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000258'', N''86'', ''18:05:00'', 48),
    (259, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000259'', N''74'', ''22:25:00'', 48),
    (260, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000260'', N''81'', ''02:40:00'', 48),
    (261, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN004000261'', N''78'', ''08:15:00'', 48),
    (262, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN004000262'', N''85'', ''12:30:00'', 48),
    (263, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN004000263'', N''72'', ''16:45:00'', 49),
    (264, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN004000264'', N''88'', ''20:00:00'', 49),
    (265, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN004000265'', N''75'', ''06:20:00'', 49),
    (266, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN004000266'', N''82'', ''10:35:00'', 49),
    (267, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN004000267'', N''79'', ''14:50:00'', 49),
    (268, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000268'', N''86'', ''18:05:00'', 49),
    (269, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000269'', N''74'', ''22:25:00'', 50),
    (270, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000270'', N''81'', ''02:40:00'', 50),
    (271, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN004000271'', N''78'', ''08:15:00'', 50),
    (272, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN004000272'', N''85'', ''12:30:00'', 50),
    (273, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN004000273'', N''72'', ''16:45:00'', 50),
    (274, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN004000274'', N''88'', ''20:00:00'', 50),
    (275, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN004000275'', N''75'', ''06:20:00'', 50),
    (276, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN004000276'', N''82'', ''10:35:00'', 51),
    (277, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN004000277'', N''79'', ''14:50:00'', 51),
    (278, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000278'', N''86'', ''18:05:00'', 51),
    (279, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000279'', N''74'', ''22:25:00'', 51),
    (280, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000280'', N''81'', ''02:40:00'', 51),
    (281, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN004000281'', N''78'', ''08:15:00'', 52),
    (282, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN004000282'', N''85'', ''12:30:00'', 52),
    (283, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN004000283'', N''72'', ''16:45:00'', 52),
    (284, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN004000284'', N''88'', ''20:00:00'', 52),
    (285, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN004000285'', N''75'', ''06:20:00'', 52),
    (286, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN004000286'', N''82'', ''10:35:00'', 52),
    (287, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN004000287'', N''79'', ''14:50:00'', 53),
    (288, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000288'', N''86'', ''18:05:00'', 53),
    (289, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000289'', N''74'', ''22:25:00'', 53),
    (290, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000290'', N''81'', ''02:40:00'', 53),
    (291, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN004000291'', N''78'', ''08:15:00'', 54);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (292, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN004000292'', N''85'', ''12:30:00'', 54),
    (293, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN004000293'', N''72'', ''16:45:00'', 54),
    (294, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN004000294'', N''88'', ''20:00:00'', 54),
    (295, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN004000295'', N''75'', ''06:20:00'', 54),
    (296, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN004000296'', N''82'', ''10:35:00'', 54),
    (297, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN004000297'', N''79'', ''14:50:00'', 54),
    (298, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000298'', N''86'', ''18:05:00'', 55),
    (299, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000299'', N''74'', ''22:25:00'', 55),
    (300, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000300'', N''81'', ''02:40:00'', 55),
    (301, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN004000301'', N''78'', ''08:15:00'', 55),
    (302, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN004000302'', N''85'', ''12:30:00'', 55),
    (303, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN004000303'', N''72'', ''16:45:00'', 56),
    (304, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN004000304'', N''88'', ''20:00:00'', 56),
    (305, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN004000305'', N''75'', ''06:20:00'', 56),
    (306, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN004000306'', N''82'', ''10:35:00'', 56),
    (307, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN004000307'', N''79'', ''14:50:00'', 56),
    (308, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000308'', N''86'', ''18:05:00'', 56),
    (309, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000309'', N''74'', ''22:25:00'', 57),
    (310, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000310'', N''81'', ''02:40:00'', 57),
    (311, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN004000311'', N''78'', ''08:15:00'', 57),
    (312, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN004000312'', N''85'', ''12:30:00'', 57),
    (313, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN004000313'', N''72'', ''16:45:00'', 58),
    (314, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN004000314'', N''88'', ''20:00:00'', 58),
    (315, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN004000315'', N''75'', ''06:20:00'', 58),
    (316, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN004000316'', N''82'', ''10:35:00'', 58),
    (317, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN004000317'', N''79'', ''14:50:00'', 58),
    (318, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000318'', N''86'', ''18:05:00'', 59),
    (319, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000319'', N''74'', ''22:25:00'', 59),
    (320, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000320'', N''81'', ''02:40:00'', 59),
    (321, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN004000321'', N''78'', ''08:15:00'', 59),
    (322, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN004000322'', N''85'', ''12:30:00'', 59),
    (323, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN004000323'', N''72'', ''16:45:00'', 59),
    (324, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN004000324'', N''88'', ''20:00:00'', 60),
    (325, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN004000325'', N''75'', ''06:20:00'', 60),
    (326, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN004000326'', N''82'', ''10:35:00'', 60),
    (327, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN004000327'', N''79'', ''14:50:00'', 60),
    (328, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN004000328'', N''86'', ''18:05:00'', 60),
    (329, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN004000329'', N''74'', ''22:25:00'', 60),
    (330, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN004000330'', N''81'', ''02:40:00'', 60),
    (661, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000661'', N''78'', ''08:15:00'', 121),
    (662, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000662'', N''85'', ''12:30:00'', 121),
    (663, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN009000663'', N''72'', ''16:45:00'', 121);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (664, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN009000664'', N''88'', ''20:00:00'', 121),
    (665, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN009000665'', N''75'', ''06:20:00'', 121),
    (666, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN009000666'', N''82'', ''10:35:00'', 122),
    (667, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN009000667'', N''79'', ''14:50:00'', 122),
    (668, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN009000668'', N''86'', ''18:05:00'', 122),
    (669, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN009000669'', N''74'', ''22:25:00'', 122),
    (670, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN009000670'', N''81'', ''02:40:00'', 122),
    (671, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000671'', N''78'', ''08:15:00'', 122),
    (672, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000672'', N''85'', ''12:30:00'', 123),
    (673, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN009000673'', N''72'', ''16:45:00'', 123),
    (674, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN009000674'', N''88'', ''20:00:00'', 123),
    (675, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN009000675'', N''75'', ''06:20:00'', 123),
    (676, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN009000676'', N''82'', ''10:35:00'', 124),
    (677, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN009000677'', N''79'', ''14:50:00'', 124),
    (678, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN009000678'', N''86'', ''18:05:00'', 124),
    (679, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN009000679'', N''74'', ''22:25:00'', 124),
    (680, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN009000680'', N''81'', ''02:40:00'', 124),
    (681, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000681'', N''78'', ''08:15:00'', 124),
    (682, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000682'', N''85'', ''12:30:00'', 124),
    (683, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN009000683'', N''72'', ''16:45:00'', 125),
    (684, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN009000684'', N''88'', ''20:00:00'', 125),
    (685, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN009000685'', N''75'', ''06:20:00'', 125),
    (686, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN009000686'', N''82'', ''10:35:00'', 125),
    (687, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN009000687'', N''79'', ''14:50:00'', 125),
    (688, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN009000688'', N''86'', ''18:05:00'', 126),
    (689, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN009000689'', N''74'', ''22:25:00'', 126),
    (690, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN009000690'', N''81'', ''02:40:00'', 126),
    (691, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000691'', N''78'', ''08:15:00'', 126),
    (692, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000692'', N''85'', ''12:30:00'', 126),
    (693, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN009000693'', N''72'', ''16:45:00'', 126),
    (694, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN009000694'', N''88'', ''20:00:00'', 127),
    (695, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN009000695'', N''75'', ''06:20:00'', 127),
    (696, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN009000696'', N''82'', ''10:35:00'', 127),
    (697, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN009000697'', N''79'', ''14:50:00'', 127),
    (698, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN009000698'', N''86'', ''18:05:00'', 128),
    (699, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN009000699'', N''74'', ''22:25:00'', 128),
    (700, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN009000700'', N''81'', ''02:40:00'', 128),
    (701, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000701'', N''78'', ''08:15:00'', 128),
    (702, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000702'', N''85'', ''12:30:00'', 128),
    (703, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN009000703'', N''72'', ''16:45:00'', 129),
    (704, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN009000704'', N''88'', ''20:00:00'', 129),
    (705, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN009000705'', N''75'', ''06:20:00'', 129);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (706, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN009000706'', N''82'', ''10:35:00'', 129),
    (707, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN009000707'', N''79'', ''14:50:00'', 129),
    (708, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN009000708'', N''86'', ''18:05:00'', 129),
    (709, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN009000709'', N''74'', ''22:25:00'', 130),
    (710, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN009000710'', N''81'', ''02:40:00'', 130),
    (711, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000711'', N''78'', ''08:15:00'', 130),
    (712, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000712'', N''85'', ''12:30:00'', 130),
    (713, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN009000713'', N''72'', ''16:45:00'', 130),
    (714, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN009000714'', N''88'', ''20:00:00'', 130),
    (715, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN009000715'', N''75'', ''06:20:00'', 130),
    (716, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN009000716'', N''82'', ''10:35:00'', 131),
    (717, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN009000717'', N''79'', ''14:50:00'', 131),
    (718, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN009000718'', N''86'', ''18:05:00'', 131),
    (719, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN009000719'', N''74'', ''22:25:00'', 131),
    (720, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN009000720'', N''81'', ''02:40:00'', 131),
    (721, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000721'', N''78'', ''08:15:00'', 132),
    (722, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000722'', N''85'', ''12:30:00'', 132),
    (723, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN009000723'', N''72'', ''16:45:00'', 132),
    (724, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN009000724'', N''88'', ''20:00:00'', 132),
    (725, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN009000725'', N''75'', ''06:20:00'', 132),
    (726, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN009000726'', N''82'', ''10:35:00'', 132),
    (727, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN009000727'', N''79'', ''14:50:00'', 133),
    (728, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN009000728'', N''86'', ''18:05:00'', 133),
    (729, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN009000729'', N''74'', ''22:25:00'', 133),
    (730, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN009000730'', N''81'', ''02:40:00'', 133),
    (731, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000731'', N''78'', ''08:15:00'', 134),
    (732, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000732'', N''85'', ''12:30:00'', 134),
    (733, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN009000733'', N''72'', ''16:45:00'', 134),
    (734, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN009000734'', N''88'', ''20:00:00'', 134),
    (735, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN009000735'', N''75'', ''06:20:00'', 134),
    (736, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN009000736'', N''82'', ''10:35:00'', 134),
    (737, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN009000737'', N''79'', ''14:50:00'', 134),
    (738, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN009000738'', N''86'', ''18:05:00'', 135),
    (739, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN009000739'', N''74'', ''22:25:00'', 135),
    (740, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN009000740'', N''81'', ''02:40:00'', 135),
    (741, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN009000741'', N''78'', ''08:15:00'', 135),
    (742, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN009000742'', N''85'', ''12:30:00'', 135)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BigBattery', N'Co2', N'Co2Val', N'Counter', N'Fan', N'IsClean', N'IsDone', N'ReadingFly', N'ReadingHumidty', N'ReadingLarg', N'ReadingLat', N'ReadingLng', N'ReadingMosuqitoes', N'ReadingSmall', N'ReadingTempIn', N'ReadingTempOut', N'ReadingWindSpeed', N'SerialNumber', N'SmallBattery', N'Time', N'TrapReadId') AND [object_id] = OBJECT_ID(N'[ReadDetails]'))
        SET IDENTITY_INSERT [ReadDetails] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapCounterSchedules]'))
        SET IDENTITY_INSERT [TrapCounterSchedules] ON;
    EXEC(N'INSERT INTO [TrapCounterSchedules] ([Id], [ScdTime], [Status], [TrapId])
    VALUES (1, 0, CAST(1 AS bit), 2),
    (2, 6, CAST(1 AS bit), 2),
    (3, 12, CAST(1 AS bit), 2),
    (4, 18, CAST(1 AS bit), 2),
    (19, 0, CAST(1 AS bit), 6),
    (20, 6, CAST(1 AS bit), 6),
    (21, 12, CAST(1 AS bit), 6),
    (22, 18, CAST(1 AS bit), 6),
    (28, 0, CAST(1 AS bit), 8),
    (29, 6, CAST(1 AS bit), 8),
    (30, 12, CAST(1 AS bit), 8),
    (31, 18, CAST(1 AS bit), 8),
    (37, 0, CAST(1 AS bit), 10),
    (38, 6, CAST(1 AS bit), 10),
    (39, 12, CAST(1 AS bit), 10),
    (40, 18, CAST(1 AS bit), 10)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapCounterSchedules]'))
        SET IDENTITY_INSERT [TrapCounterSchedules] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapFanSchedules]'))
        SET IDENTITY_INSERT [TrapFanSchedules] ON;
    EXEC(N'INSERT INTO [TrapFanSchedules] ([Id], [ScdTime], [Status], [TrapId])
    VALUES (5, 2, CAST(1 AS bit), 2),
    (6, 10, CAST(1 AS bit), 2),
    (7, 18, CAST(1 AS bit), 2),
    (23, 2, CAST(1 AS bit), 6),
    (24, 10, CAST(1 AS bit), 6),
    (25, 18, CAST(1 AS bit), 6),
    (32, 2, CAST(1 AS bit), 8),
    (33, 10, CAST(1 AS bit), 8),
    (34, 18, CAST(1 AS bit), 8),
    (41, 2, CAST(1 AS bit), 10),
    (42, 10, CAST(1 AS bit), 10),
    (43, 18, CAST(1 AS bit), 10)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapFanSchedules]'))
        SET IDENTITY_INSERT [TrapFanSchedules] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'ServerCreationDate', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapReads]'))
        SET IDENTITY_INSERT [TrapReads] ON;
    EXEC(N'INSERT INTO [TrapReads] ([Id], [Date], [ServerCreationDate], [TrapId])
    VALUES (16, ''2024-01-31'', ''2024-02-01'', 2),
    (17, ''2024-02-02'', ''2024-02-03'', 2),
    (18, ''2024-02-04'', ''2024-02-05'', 2),
    (19, ''2024-02-06'', ''2024-02-07'', 2),
    (20, ''2024-02-08'', ''2024-02-09'', 2),
    (21, ''2024-02-10'', ''2024-02-11'', 2),
    (22, ''2024-02-12'', ''2024-02-13'', 2),
    (23, ''2024-02-14'', ''2024-02-15'', 2),
    (24, ''2024-02-16'', ''2024-02-17'', 2),
    (25, ''2024-02-18'', ''2024-02-19'', 2),
    (26, ''2024-02-20'', ''2024-02-21'', 2),
    (27, ''2024-02-22'', ''2024-02-23'', 2),
    (28, ''2024-02-24'', ''2024-02-25'', 2),
    (29, ''2024-02-26'', ''2024-02-27'', 2),
    (30, ''2024-02-28'', ''2024-02-29'', 2),
    (31, ''2024-03-01'', ''2024-03-02'', 3),
    (32, ''2024-03-03'', ''2024-03-04'', 3),
    (33, ''2024-03-05'', ''2024-03-06'', 3),
    (34, ''2024-03-07'', ''2024-03-08'', 3),
    (35, ''2024-03-09'', ''2024-03-10'', 3),
    (36, ''2024-03-11'', ''2024-03-12'', 3),
    (37, ''2024-03-13'', ''2024-03-14'', 3),
    (38, ''2024-03-15'', ''2024-03-16'', 3),
    (39, ''2024-03-17'', ''2024-03-18'', 3),
    (40, ''2024-03-19'', ''2024-03-20'', 3),
    (41, ''2024-03-21'', ''2024-03-22'', 3),
    (42, ''2024-03-23'', ''2024-03-24'', 3),
    (43, ''2024-03-25'', ''2024-03-26'', 3),
    (44, ''2024-03-27'', ''2024-03-28'', 3),
    (45, ''2024-03-29'', ''2024-03-30'', 3),
    (61, ''2024-04-30'', ''2024-05-01'', 5),
    (62, ''2024-05-02'', ''2024-05-03'', 5),
    (63, ''2024-05-04'', ''2024-05-05'', 5),
    (64, ''2024-05-06'', ''2024-05-07'', 5),
    (65, ''2024-05-08'', ''2024-05-09'', 5),
    (66, ''2024-05-10'', ''2024-05-11'', 5),
    (67, ''2024-05-12'', ''2024-05-13'', 5),
    (68, ''2024-05-14'', ''2024-05-15'', 5),
    (69, ''2024-05-16'', ''2024-05-17'', 5),
    (70, ''2024-05-18'', ''2024-05-19'', 5),
    (71, ''2024-05-20'', ''2024-05-21'', 5),
    (72, ''2024-05-22'', ''2024-05-23'', 5);
    INSERT INTO [TrapReads] ([Id], [Date], [ServerCreationDate], [TrapId])
    VALUES (73, ''2024-05-24'', ''2024-05-25'', 5),
    (74, ''2024-05-26'', ''2024-05-27'', 5),
    (75, ''2024-05-28'', ''2024-05-29'', 5),
    (76, ''2024-05-30'', ''2024-05-31'', 6),
    (77, ''2024-06-01'', ''2024-06-02'', 6),
    (78, ''2024-06-03'', ''2024-06-04'', 6),
    (79, ''2024-06-05'', ''2024-06-06'', 6),
    (80, ''2024-06-07'', ''2024-06-08'', 6),
    (81, ''2024-06-09'', ''2024-06-10'', 6),
    (82, ''2024-06-11'', ''2024-06-12'', 6),
    (83, ''2024-06-13'', ''2024-06-14'', 6),
    (84, ''2024-06-15'', ''2024-06-16'', 6),
    (85, ''2024-06-17'', ''2024-06-18'', 6),
    (86, ''2024-06-19'', ''2024-06-20'', 6),
    (87, ''2024-06-21'', ''2024-06-22'', 6),
    (88, ''2024-06-23'', ''2024-06-24'', 6),
    (89, ''2024-06-25'', ''2024-06-26'', 6),
    (90, ''2024-06-27'', ''2024-06-28'', 6),
    (91, ''2024-06-29'', ''2024-06-30'', 7),
    (92, ''2024-07-01'', ''2024-07-02'', 7),
    (93, ''2024-07-03'', ''2024-07-04'', 7),
    (94, ''2024-07-05'', ''2024-07-06'', 7),
    (95, ''2024-07-07'', ''2024-07-08'', 7),
    (96, ''2024-07-09'', ''2024-07-10'', 7),
    (97, ''2024-07-11'', ''2024-07-12'', 7),
    (98, ''2024-07-13'', ''2024-07-14'', 7),
    (99, ''2024-07-15'', ''2024-07-16'', 7),
    (100, ''2024-07-17'', ''2024-07-18'', 7),
    (101, ''2024-07-19'', ''2024-07-20'', 7),
    (102, ''2024-07-21'', ''2024-07-22'', 7),
    (103, ''2024-07-23'', ''2024-07-24'', 7),
    (104, ''2024-07-25'', ''2024-07-26'', 7),
    (105, ''2024-07-27'', ''2024-07-28'', 7),
    (106, ''2024-07-29'', ''2024-07-30'', 8),
    (107, ''2024-07-31'', ''2024-08-01'', 8),
    (108, ''2024-08-02'', ''2024-08-03'', 8),
    (109, ''2024-08-04'', ''2024-08-05'', 8),
    (110, ''2024-08-06'', ''2024-08-07'', 8),
    (111, ''2024-08-08'', ''2024-08-09'', 8),
    (112, ''2024-08-10'', ''2024-08-11'', 8),
    (113, ''2024-08-12'', ''2024-08-13'', 8),
    (114, ''2024-08-14'', ''2024-08-15'', 8);
    INSERT INTO [TrapReads] ([Id], [Date], [ServerCreationDate], [TrapId])
    VALUES (115, ''2024-08-16'', ''2024-08-17'', 8),
    (116, ''2024-08-18'', ''2024-08-19'', 8),
    (117, ''2024-08-20'', ''2024-08-21'', 8),
    (118, ''2024-08-22'', ''2024-08-23'', 8),
    (119, ''2024-08-24'', ''2024-08-25'', 8),
    (120, ''2024-08-26'', ''2024-08-27'', 8),
    (136, ''2024-09-27'', ''2024-09-28'', 10),
    (137, ''2024-09-29'', ''2024-09-30'', 10),
    (138, ''2024-10-01'', ''2024-10-02'', 10),
    (139, ''2024-10-03'', ''2024-10-04'', 10),
    (140, ''2024-10-05'', ''2024-10-06'', 10),
    (141, ''2024-10-07'', ''2024-10-08'', 10),
    (142, ''2024-10-09'', ''2024-10-10'', 10),
    (143, ''2024-10-11'', ''2024-10-12'', 10),
    (144, ''2024-10-13'', ''2024-10-14'', 10),
    (145, ''2024-10-15'', ''2024-10-16'', 10),
    (146, ''2024-10-17'', ''2024-10-18'', 10),
    (147, ''2024-10-19'', ''2024-10-20'', 10),
    (148, ''2024-10-21'', ''2024-10-22'', 10),
    (149, ''2024-10-23'', ''2024-10-24'', 10),
    (150, ''2024-10-25'', ''2024-10-26'', 10)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'ServerCreationDate', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapReads]'))
        SET IDENTITY_INSERT [TrapReads] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapValveQutSchedules]'))
        SET IDENTITY_INSERT [TrapValveQutSchedules] ON;
    EXEC(N'INSERT INTO [TrapValveQutSchedules] ([Id], [ScdTime], [Status], [TrapId])
    VALUES (8, 4, CAST(1 AS bit), 2),
    (9, 16, CAST(1 AS bit), 2),
    (26, 4, CAST(1 AS bit), 6),
    (27, 16, CAST(1 AS bit), 6),
    (35, 4, CAST(1 AS bit), 8),
    (36, 16, CAST(1 AS bit), 8),
    (44, 4, CAST(1 AS bit), 10),
    (45, 16, CAST(1 AS bit), 10)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ScdTime', N'Status', N'TrapId') AND [object_id] = OBJECT_ID(N'[TrapValveQutSchedules]'))
        SET IDENTITY_INSERT [TrapValveQutSchedules] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'TrapId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserTraps]'))
        SET IDENTITY_INSERT [UserTraps] ON;
    EXEC(N'INSERT INTO [UserTraps] ([Id], [TrapId], [UserId])
    VALUES (2, 2, ''22222222-2222-2222-2222-222222222222''),
    (3, 3, ''33333333-3333-3333-3333-333333333333''),
    (4, 4, ''44444444-4444-4444-4444-444444444444''),
    (5, 5, ''55555555-5555-5555-5555-555555555555''),
    (6, 6, ''11111111-1111-1111-1111-111111111111''),
    (7, 7, ''22222222-2222-2222-2222-222222222222''),
    (8, 8, ''33333333-3333-3333-3333-333333333333''),
    (9, 9, ''44444444-4444-4444-4444-444444444444''),
    (10, 10, ''55555555-5555-5555-5555-555555555555'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'TrapId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserTraps]'))
        SET IDENTITY_INSERT [UserTraps] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BigBattery', N'Co2', N'Co2Val', N'Counter', N'Fan', N'IsClean', N'IsDone', N'ReadingFly', N'ReadingHumidty', N'ReadingLarg', N'ReadingLat', N'ReadingLng', N'ReadingMosuqitoes', N'ReadingSmall', N'ReadingTempIn', N'ReadingTempOut', N'ReadingWindSpeed', N'SerialNumber', N'SmallBattery', N'Time', N'TrapReadId') AND [object_id] = OBJECT_ID(N'[ReadDetails]'))
        SET IDENTITY_INSERT [ReadDetails] ON;
    EXEC(N'INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (83, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000083'', N''72'', ''16:45:00'', 16),
    (84, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000084'', N''88'', ''20:00:00'', 16),
    (85, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000085'', N''75'', ''06:20:00'', 16),
    (86, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN002000086'', N''82'', ''10:35:00'', 16),
    (87, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN002000087'', N''79'', ''14:50:00'', 16),
    (88, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN002000088'', N''86'', ''18:05:00'', 16),
    (89, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN002000089'', N''74'', ''22:25:00'', 17),
    (90, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN002000090'', N''81'', ''02:40:00'', 17),
    (91, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN002000091'', N''78'', ''08:15:00'', 17),
    (92, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN002000092'', N''85'', ''12:30:00'', 17),
    (93, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000093'', N''72'', ''16:45:00'', 18),
    (94, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000094'', N''88'', ''20:00:00'', 18),
    (95, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000095'', N''75'', ''06:20:00'', 18),
    (96, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN002000096'', N''82'', ''10:35:00'', 18),
    (97, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN002000097'', N''79'', ''14:50:00'', 18),
    (98, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN002000098'', N''86'', ''18:05:00'', 19),
    (99, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN002000099'', N''74'', ''22:25:00'', 19),
    (100, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN002000100'', N''81'', ''02:40:00'', 19),
    (101, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN002000101'', N''78'', ''08:15:00'', 19),
    (102, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN002000102'', N''85'', ''12:30:00'', 19),
    (103, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000103'', N''72'', ''16:45:00'', 19),
    (104, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000104'', N''88'', ''20:00:00'', 20),
    (105, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000105'', N''75'', ''06:20:00'', 20),
    (106, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN002000106'', N''82'', ''10:35:00'', 20),
    (107, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN002000107'', N''79'', ''14:50:00'', 20),
    (108, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN002000108'', N''86'', ''18:05:00'', 20),
    (109, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN002000109'', N''74'', ''22:25:00'', 20),
    (110, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN002000110'', N''81'', ''02:40:00'', 20),
    (111, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN002000111'', N''78'', ''08:15:00'', 21),
    (112, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN002000112'', N''85'', ''12:30:00'', 21),
    (113, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000113'', N''72'', ''16:45:00'', 21),
    (114, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000114'', N''88'', ''20:00:00'', 21),
    (115, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000115'', N''75'', ''06:20:00'', 21),
    (116, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN002000116'', N''82'', ''10:35:00'', 22),
    (117, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN002000117'', N''79'', ''14:50:00'', 22),
    (118, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN002000118'', N''86'', ''18:05:00'', 22),
    (119, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN002000119'', N''74'', ''22:25:00'', 22),
    (120, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN002000120'', N''81'', ''02:40:00'', 22),
    (121, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN002000121'', N''78'', ''08:15:00'', 22),
    (122, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN002000122'', N''85'', ''12:30:00'', 23),
    (123, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000123'', N''72'', ''16:45:00'', 23),
    (124, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000124'', N''88'', ''20:00:00'', 23);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (125, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000125'', N''75'', ''06:20:00'', 23),
    (126, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN002000126'', N''82'', ''10:35:00'', 24),
    (127, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN002000127'', N''79'', ''14:50:00'', 24),
    (128, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN002000128'', N''86'', ''18:05:00'', 24),
    (129, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN002000129'', N''74'', ''22:25:00'', 24),
    (130, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN002000130'', N''81'', ''02:40:00'', 24),
    (131, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN002000131'', N''78'', ''08:15:00'', 24),
    (132, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN002000132'', N''85'', ''12:30:00'', 24),
    (133, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000133'', N''72'', ''16:45:00'', 25),
    (134, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000134'', N''88'', ''20:00:00'', 25),
    (135, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000135'', N''75'', ''06:20:00'', 25),
    (136, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN002000136'', N''82'', ''10:35:00'', 25),
    (137, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN002000137'', N''79'', ''14:50:00'', 25),
    (138, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN002000138'', N''86'', ''18:05:00'', 26),
    (139, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN002000139'', N''74'', ''22:25:00'', 26),
    (140, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN002000140'', N''81'', ''02:40:00'', 26),
    (141, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN002000141'', N''78'', ''08:15:00'', 26),
    (142, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN002000142'', N''85'', ''12:30:00'', 26),
    (143, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000143'', N''72'', ''16:45:00'', 26),
    (144, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000144'', N''88'', ''20:00:00'', 27),
    (145, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000145'', N''75'', ''06:20:00'', 27),
    (146, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN002000146'', N''82'', ''10:35:00'', 27),
    (147, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN002000147'', N''79'', ''14:50:00'', 27),
    (148, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN002000148'', N''86'', ''18:05:00'', 28),
    (149, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN002000149'', N''74'', ''22:25:00'', 28),
    (150, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN002000150'', N''81'', ''02:40:00'', 28),
    (151, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN002000151'', N''78'', ''08:15:00'', 28),
    (152, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN002000152'', N''85'', ''12:30:00'', 28),
    (153, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000153'', N''72'', ''16:45:00'', 29),
    (154, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000154'', N''88'', ''20:00:00'', 29),
    (155, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000155'', N''75'', ''06:20:00'', 29),
    (156, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN002000156'', N''82'', ''10:35:00'', 29),
    (157, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN002000157'', N''79'', ''14:50:00'', 29),
    (158, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN002000158'', N''86'', ''18:05:00'', 29),
    (159, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN002000159'', N''74'', ''22:25:00'', 30),
    (160, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN002000160'', N''81'', ''02:40:00'', 30),
    (161, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN002000161'', N''78'', ''08:15:00'', 30),
    (162, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN002000162'', N''85'', ''12:30:00'', 30),
    (163, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN002000163'', N''72'', ''16:45:00'', 30),
    (164, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN002000164'', N''88'', ''20:00:00'', 30),
    (165, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN002000165'', N''75'', ''06:20:00'', 30),
    (166, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000166'', N''82'', ''10:35:00'', 31);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (167, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000167'', N''79'', ''14:50:00'', 31),
    (168, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN003000168'', N''86'', ''18:05:00'', 31),
    (169, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN003000169'', N''74'', ''22:25:00'', 31),
    (170, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN003000170'', N''81'', ''02:40:00'', 31),
    (171, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN003000171'', N''78'', ''08:15:00'', 32),
    (172, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN003000172'', N''85'', ''12:30:00'', 32),
    (173, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN003000173'', N''72'', ''16:45:00'', 32),
    (174, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN003000174'', N''88'', ''20:00:00'', 32),
    (175, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN003000175'', N''75'', ''06:20:00'', 32),
    (176, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000176'', N''82'', ''10:35:00'', 32),
    (177, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000177'', N''79'', ''14:50:00'', 33),
    (178, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN003000178'', N''86'', ''18:05:00'', 33),
    (179, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN003000179'', N''74'', ''22:25:00'', 33),
    (180, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN003000180'', N''81'', ''02:40:00'', 33),
    (181, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN003000181'', N''78'', ''08:15:00'', 34),
    (182, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN003000182'', N''85'', ''12:30:00'', 34),
    (183, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN003000183'', N''72'', ''16:45:00'', 34),
    (184, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN003000184'', N''88'', ''20:00:00'', 34),
    (185, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN003000185'', N''75'', ''06:20:00'', 34),
    (186, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000186'', N''82'', ''10:35:00'', 34),
    (187, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000187'', N''79'', ''14:50:00'', 34),
    (188, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN003000188'', N''86'', ''18:05:00'', 35),
    (189, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN003000189'', N''74'', ''22:25:00'', 35),
    (190, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN003000190'', N''81'', ''02:40:00'', 35),
    (191, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN003000191'', N''78'', ''08:15:00'', 35),
    (192, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN003000192'', N''85'', ''12:30:00'', 35),
    (193, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN003000193'', N''72'', ''16:45:00'', 36),
    (194, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN003000194'', N''88'', ''20:00:00'', 36),
    (195, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN003000195'', N''75'', ''06:20:00'', 36),
    (196, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000196'', N''82'', ''10:35:00'', 36),
    (197, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000197'', N''79'', ''14:50:00'', 36),
    (198, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN003000198'', N''86'', ''18:05:00'', 36),
    (199, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN003000199'', N''74'', ''22:25:00'', 37),
    (200, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN003000200'', N''81'', ''02:40:00'', 37),
    (201, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN003000201'', N''78'', ''08:15:00'', 37),
    (202, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN003000202'', N''85'', ''12:30:00'', 37),
    (203, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN003000203'', N''72'', ''16:45:00'', 38),
    (204, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN003000204'', N''88'', ''20:00:00'', 38),
    (205, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN003000205'', N''75'', ''06:20:00'', 38),
    (206, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000206'', N''82'', ''10:35:00'', 38),
    (207, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000207'', N''79'', ''14:50:00'', 38),
    (208, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN003000208'', N''86'', ''18:05:00'', 39);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (209, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN003000209'', N''74'', ''22:25:00'', 39),
    (210, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN003000210'', N''81'', ''02:40:00'', 39),
    (211, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN003000211'', N''78'', ''08:15:00'', 39),
    (212, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN003000212'', N''85'', ''12:30:00'', 39),
    (213, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN003000213'', N''72'', ''16:45:00'', 39),
    (214, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN003000214'', N''88'', ''20:00:00'', 40),
    (215, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN003000215'', N''75'', ''06:20:00'', 40),
    (216, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000216'', N''82'', ''10:35:00'', 40),
    (217, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000217'', N''79'', ''14:50:00'', 40),
    (218, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN003000218'', N''86'', ''18:05:00'', 40),
    (219, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN003000219'', N''74'', ''22:25:00'', 40),
    (220, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN003000220'', N''81'', ''02:40:00'', 40),
    (221, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN003000221'', N''78'', ''08:15:00'', 41),
    (222, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN003000222'', N''85'', ''12:30:00'', 41),
    (223, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN003000223'', N''72'', ''16:45:00'', 41),
    (224, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN003000224'', N''88'', ''20:00:00'', 41),
    (225, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN003000225'', N''75'', ''06:20:00'', 41),
    (226, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000226'', N''82'', ''10:35:00'', 42),
    (227, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000227'', N''79'', ''14:50:00'', 42),
    (228, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN003000228'', N''86'', ''18:05:00'', 42),
    (229, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN003000229'', N''74'', ''22:25:00'', 42),
    (230, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN003000230'', N''81'', ''02:40:00'', 42),
    (231, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN003000231'', N''78'', ''08:15:00'', 42),
    (232, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN003000232'', N''85'', ''12:30:00'', 43),
    (233, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN003000233'', N''72'', ''16:45:00'', 43),
    (234, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN003000234'', N''88'', ''20:00:00'', 43),
    (235, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN003000235'', N''75'', ''06:20:00'', 43),
    (236, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000236'', N''82'', ''10:35:00'', 44),
    (237, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000237'', N''79'', ''14:50:00'', 44),
    (238, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN003000238'', N''86'', ''18:05:00'', 44),
    (239, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN003000239'', N''74'', ''22:25:00'', 44),
    (240, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN003000240'', N''81'', ''02:40:00'', 44),
    (241, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN003000241'', N''78'', ''08:15:00'', 44),
    (242, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN003000242'', N''85'', ''12:30:00'', 44),
    (243, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN003000243'', N''72'', ''16:45:00'', 45),
    (244, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN003000244'', N''88'', ''20:00:00'', 45),
    (245, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN003000245'', N''75'', ''06:20:00'', 45),
    (246, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN003000246'', N''82'', ''10:35:00'', 45),
    (247, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN003000247'', N''79'', ''14:50:00'', 45),
    (331, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000331'', N''78'', ''08:15:00'', 61),
    (332, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000332'', N''85'', ''12:30:00'', 61),
    (333, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN005000333'', N''72'', ''16:45:00'', 61);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (334, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN005000334'', N''88'', ''20:00:00'', 61),
    (335, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN005000335'', N''75'', ''06:20:00'', 61),
    (336, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN005000336'', N''82'', ''10:35:00'', 62),
    (337, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN005000337'', N''79'', ''14:50:00'', 62),
    (338, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN005000338'', N''86'', ''18:05:00'', 62),
    (339, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN005000339'', N''74'', ''22:25:00'', 62),
    (340, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN005000340'', N''81'', ''02:40:00'', 62),
    (341, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000341'', N''78'', ''08:15:00'', 62),
    (342, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000342'', N''85'', ''12:30:00'', 63),
    (343, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN005000343'', N''72'', ''16:45:00'', 63),
    (344, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN005000344'', N''88'', ''20:00:00'', 63),
    (345, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN005000345'', N''75'', ''06:20:00'', 63),
    (346, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN005000346'', N''82'', ''10:35:00'', 64),
    (347, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN005000347'', N''79'', ''14:50:00'', 64),
    (348, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN005000348'', N''86'', ''18:05:00'', 64),
    (349, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN005000349'', N''74'', ''22:25:00'', 64),
    (350, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN005000350'', N''81'', ''02:40:00'', 64),
    (351, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000351'', N''78'', ''08:15:00'', 64),
    (352, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000352'', N''85'', ''12:30:00'', 64),
    (353, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN005000353'', N''72'', ''16:45:00'', 65),
    (354, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN005000354'', N''88'', ''20:00:00'', 65),
    (355, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN005000355'', N''75'', ''06:20:00'', 65),
    (356, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN005000356'', N''82'', ''10:35:00'', 65),
    (357, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN005000357'', N''79'', ''14:50:00'', 65),
    (358, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN005000358'', N''86'', ''18:05:00'', 66),
    (359, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN005000359'', N''74'', ''22:25:00'', 66),
    (360, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN005000360'', N''81'', ''02:40:00'', 66),
    (361, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000361'', N''78'', ''08:15:00'', 66),
    (362, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000362'', N''85'', ''12:30:00'', 66),
    (363, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN005000363'', N''72'', ''16:45:00'', 66),
    (364, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN005000364'', N''88'', ''20:00:00'', 67),
    (365, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN005000365'', N''75'', ''06:20:00'', 67),
    (366, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN005000366'', N''82'', ''10:35:00'', 67),
    (367, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN005000367'', N''79'', ''14:50:00'', 67),
    (368, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN005000368'', N''86'', ''18:05:00'', 68),
    (369, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN005000369'', N''74'', ''22:25:00'', 68),
    (370, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN005000370'', N''81'', ''02:40:00'', 68),
    (371, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000371'', N''78'', ''08:15:00'', 68),
    (372, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000372'', N''85'', ''12:30:00'', 68),
    (373, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN005000373'', N''72'', ''16:45:00'', 69),
    (374, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN005000374'', N''88'', ''20:00:00'', 69),
    (375, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN005000375'', N''75'', ''06:20:00'', 69);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (376, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN005000376'', N''82'', ''10:35:00'', 69),
    (377, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN005000377'', N''79'', ''14:50:00'', 69),
    (378, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN005000378'', N''86'', ''18:05:00'', 69),
    (379, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN005000379'', N''74'', ''22:25:00'', 70),
    (380, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN005000380'', N''81'', ''02:40:00'', 70),
    (381, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000381'', N''78'', ''08:15:00'', 70),
    (382, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000382'', N''85'', ''12:30:00'', 70),
    (383, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN005000383'', N''72'', ''16:45:00'', 70),
    (384, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN005000384'', N''88'', ''20:00:00'', 70),
    (385, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN005000385'', N''75'', ''06:20:00'', 70),
    (386, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN005000386'', N''82'', ''10:35:00'', 71),
    (387, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN005000387'', N''79'', ''14:50:00'', 71),
    (388, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN005000388'', N''86'', ''18:05:00'', 71),
    (389, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN005000389'', N''74'', ''22:25:00'', 71),
    (390, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN005000390'', N''81'', ''02:40:00'', 71),
    (391, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000391'', N''78'', ''08:15:00'', 72),
    (392, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000392'', N''85'', ''12:30:00'', 72),
    (393, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN005000393'', N''72'', ''16:45:00'', 72),
    (394, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN005000394'', N''88'', ''20:00:00'', 72),
    (395, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN005000395'', N''75'', ''06:20:00'', 72),
    (396, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN005000396'', N''82'', ''10:35:00'', 72),
    (397, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN005000397'', N''79'', ''14:50:00'', 73),
    (398, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN005000398'', N''86'', ''18:05:00'', 73),
    (399, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN005000399'', N''74'', ''22:25:00'', 73),
    (400, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN005000400'', N''81'', ''02:40:00'', 73),
    (401, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000401'', N''78'', ''08:15:00'', 74),
    (402, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000402'', N''85'', ''12:30:00'', 74),
    (403, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN005000403'', N''72'', ''16:45:00'', 74),
    (404, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN005000404'', N''88'', ''20:00:00'', 74),
    (405, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN005000405'', N''75'', ''06:20:00'', 74),
    (406, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN005000406'', N''82'', ''10:35:00'', 74),
    (407, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN005000407'', N''79'', ''14:50:00'', 74),
    (408, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN005000408'', N''86'', ''18:05:00'', 75),
    (409, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN005000409'', N''74'', ''22:25:00'', 75),
    (410, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN005000410'', N''81'', ''02:40:00'', 75),
    (411, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN005000411'', N''78'', ''08:15:00'', 75),
    (412, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN005000412'', N''85'', ''12:30:00'', 75),
    (413, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000413'', N''72'', ''16:45:00'', 76),
    (414, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000414'', N''88'', ''20:00:00'', 76),
    (415, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000415'', N''75'', ''06:20:00'', 76),
    (416, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN006000416'', N''82'', ''10:35:00'', 76),
    (417, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN006000417'', N''79'', ''14:50:00'', 76);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (418, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN006000418'', N''86'', ''18:05:00'', 76),
    (419, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN006000419'', N''74'', ''22:25:00'', 77),
    (420, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN006000420'', N''81'', ''02:40:00'', 77),
    (421, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN006000421'', N''78'', ''08:15:00'', 77),
    (422, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN006000422'', N''85'', ''12:30:00'', 77),
    (423, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000423'', N''72'', ''16:45:00'', 78),
    (424, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000424'', N''88'', ''20:00:00'', 78),
    (425, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000425'', N''75'', ''06:20:00'', 78),
    (426, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN006000426'', N''82'', ''10:35:00'', 78),
    (427, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN006000427'', N''79'', ''14:50:00'', 78),
    (428, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN006000428'', N''86'', ''18:05:00'', 79),
    (429, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN006000429'', N''74'', ''22:25:00'', 79),
    (430, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN006000430'', N''81'', ''02:40:00'', 79),
    (431, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN006000431'', N''78'', ''08:15:00'', 79),
    (432, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN006000432'', N''85'', ''12:30:00'', 79),
    (433, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000433'', N''72'', ''16:45:00'', 79),
    (434, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000434'', N''88'', ''20:00:00'', 80),
    (435, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000435'', N''75'', ''06:20:00'', 80),
    (436, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN006000436'', N''82'', ''10:35:00'', 80),
    (437, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN006000437'', N''79'', ''14:50:00'', 80),
    (438, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN006000438'', N''86'', ''18:05:00'', 80),
    (439, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN006000439'', N''74'', ''22:25:00'', 80),
    (440, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN006000440'', N''81'', ''02:40:00'', 80),
    (441, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN006000441'', N''78'', ''08:15:00'', 81),
    (442, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN006000442'', N''85'', ''12:30:00'', 81),
    (443, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000443'', N''72'', ''16:45:00'', 81),
    (444, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000444'', N''88'', ''20:00:00'', 81),
    (445, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000445'', N''75'', ''06:20:00'', 81),
    (446, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN006000446'', N''82'', ''10:35:00'', 82),
    (447, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN006000447'', N''79'', ''14:50:00'', 82),
    (448, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN006000448'', N''86'', ''18:05:00'', 82),
    (449, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN006000449'', N''74'', ''22:25:00'', 82),
    (450, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN006000450'', N''81'', ''02:40:00'', 82),
    (451, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN006000451'', N''78'', ''08:15:00'', 82),
    (452, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN006000452'', N''85'', ''12:30:00'', 83),
    (453, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000453'', N''72'', ''16:45:00'', 83),
    (454, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000454'', N''88'', ''20:00:00'', 83),
    (455, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000455'', N''75'', ''06:20:00'', 83),
    (456, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN006000456'', N''82'', ''10:35:00'', 84),
    (457, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN006000457'', N''79'', ''14:50:00'', 84),
    (458, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN006000458'', N''86'', ''18:05:00'', 84),
    (459, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN006000459'', N''74'', ''22:25:00'', 84);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (460, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN006000460'', N''81'', ''02:40:00'', 84),
    (461, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN006000461'', N''78'', ''08:15:00'', 84),
    (462, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN006000462'', N''85'', ''12:30:00'', 84),
    (463, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000463'', N''72'', ''16:45:00'', 85),
    (464, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000464'', N''88'', ''20:00:00'', 85),
    (465, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000465'', N''75'', ''06:20:00'', 85),
    (466, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN006000466'', N''82'', ''10:35:00'', 85),
    (467, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN006000467'', N''79'', ''14:50:00'', 85),
    (468, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN006000468'', N''86'', ''18:05:00'', 86),
    (469, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN006000469'', N''74'', ''22:25:00'', 86),
    (470, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN006000470'', N''81'', ''02:40:00'', 86),
    (471, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN006000471'', N''78'', ''08:15:00'', 86),
    (472, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN006000472'', N''85'', ''12:30:00'', 86),
    (473, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000473'', N''72'', ''16:45:00'', 86),
    (474, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000474'', N''88'', ''20:00:00'', 87),
    (475, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000475'', N''75'', ''06:20:00'', 87),
    (476, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN006000476'', N''82'', ''10:35:00'', 87),
    (477, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN006000477'', N''79'', ''14:50:00'', 87),
    (478, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN006000478'', N''86'', ''18:05:00'', 88),
    (479, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN006000479'', N''74'', ''22:25:00'', 88),
    (480, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN006000480'', N''81'', ''02:40:00'', 88),
    (481, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN006000481'', N''78'', ''08:15:00'', 88),
    (482, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN006000482'', N''85'', ''12:30:00'', 88),
    (483, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000483'', N''72'', ''16:45:00'', 89),
    (484, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000484'', N''88'', ''20:00:00'', 89),
    (485, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000485'', N''75'', ''06:20:00'', 89),
    (486, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN006000486'', N''82'', ''10:35:00'', 89),
    (487, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN006000487'', N''79'', ''14:50:00'', 89),
    (488, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN006000488'', N''86'', ''18:05:00'', 89),
    (489, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN006000489'', N''74'', ''22:25:00'', 90),
    (490, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN006000490'', N''81'', ''02:40:00'', 90),
    (491, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN006000491'', N''78'', ''08:15:00'', 90),
    (492, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN006000492'', N''85'', ''12:30:00'', 90),
    (493, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN006000493'', N''72'', ''16:45:00'', 90),
    (494, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN006000494'', N''88'', ''20:00:00'', 90),
    (495, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN006000495'', N''75'', ''06:20:00'', 90),
    (496, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000496'', N''82'', ''10:35:00'', 91),
    (497, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000497'', N''79'', ''14:50:00'', 91),
    (498, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN007000498'', N''86'', ''18:05:00'', 91),
    (499, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN007000499'', N''74'', ''22:25:00'', 91),
    (500, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN007000500'', N''81'', ''02:40:00'', 91),
    (501, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN007000501'', N''78'', ''08:15:00'', 92);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (502, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN007000502'', N''85'', ''12:30:00'', 92),
    (503, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN007000503'', N''72'', ''16:45:00'', 92),
    (504, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN007000504'', N''88'', ''20:00:00'', 92),
    (505, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN007000505'', N''75'', ''06:20:00'', 92),
    (506, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000506'', N''82'', ''10:35:00'', 92),
    (507, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000507'', N''79'', ''14:50:00'', 93),
    (508, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN007000508'', N''86'', ''18:05:00'', 93),
    (509, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN007000509'', N''74'', ''22:25:00'', 93),
    (510, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN007000510'', N''81'', ''02:40:00'', 93),
    (511, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN007000511'', N''78'', ''08:15:00'', 94),
    (512, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN007000512'', N''85'', ''12:30:00'', 94),
    (513, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN007000513'', N''72'', ''16:45:00'', 94),
    (514, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN007000514'', N''88'', ''20:00:00'', 94),
    (515, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN007000515'', N''75'', ''06:20:00'', 94),
    (516, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000516'', N''82'', ''10:35:00'', 94),
    (517, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000517'', N''79'', ''14:50:00'', 94),
    (518, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN007000518'', N''86'', ''18:05:00'', 95),
    (519, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN007000519'', N''74'', ''22:25:00'', 95),
    (520, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN007000520'', N''81'', ''02:40:00'', 95),
    (521, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN007000521'', N''78'', ''08:15:00'', 95),
    (522, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN007000522'', N''85'', ''12:30:00'', 95),
    (523, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN007000523'', N''72'', ''16:45:00'', 96),
    (524, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN007000524'', N''88'', ''20:00:00'', 96),
    (525, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN007000525'', N''75'', ''06:20:00'', 96),
    (526, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000526'', N''82'', ''10:35:00'', 96),
    (527, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000527'', N''79'', ''14:50:00'', 96),
    (528, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN007000528'', N''86'', ''18:05:00'', 96),
    (529, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN007000529'', N''74'', ''22:25:00'', 97),
    (530, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN007000530'', N''81'', ''02:40:00'', 97),
    (531, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN007000531'', N''78'', ''08:15:00'', 97),
    (532, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN007000532'', N''85'', ''12:30:00'', 97),
    (533, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN007000533'', N''72'', ''16:45:00'', 98),
    (534, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN007000534'', N''88'', ''20:00:00'', 98),
    (535, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN007000535'', N''75'', ''06:20:00'', 98),
    (536, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000536'', N''82'', ''10:35:00'', 98),
    (537, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000537'', N''79'', ''14:50:00'', 98),
    (538, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN007000538'', N''86'', ''18:05:00'', 99),
    (539, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN007000539'', N''74'', ''22:25:00'', 99),
    (540, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN007000540'', N''81'', ''02:40:00'', 99),
    (541, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN007000541'', N''78'', ''08:15:00'', 99),
    (542, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN007000542'', N''85'', ''12:30:00'', 99),
    (543, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN007000543'', N''72'', ''16:45:00'', 99);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (544, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN007000544'', N''88'', ''20:00:00'', 100),
    (545, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN007000545'', N''75'', ''06:20:00'', 100),
    (546, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000546'', N''82'', ''10:35:00'', 100),
    (547, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000547'', N''79'', ''14:50:00'', 100),
    (548, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN007000548'', N''86'', ''18:05:00'', 100),
    (549, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN007000549'', N''74'', ''22:25:00'', 100),
    (550, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN007000550'', N''81'', ''02:40:00'', 100),
    (551, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN007000551'', N''78'', ''08:15:00'', 101),
    (552, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN007000552'', N''85'', ''12:30:00'', 101),
    (553, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN007000553'', N''72'', ''16:45:00'', 101),
    (554, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN007000554'', N''88'', ''20:00:00'', 101),
    (555, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN007000555'', N''75'', ''06:20:00'', 101),
    (556, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000556'', N''82'', ''10:35:00'', 102),
    (557, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000557'', N''79'', ''14:50:00'', 102),
    (558, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN007000558'', N''86'', ''18:05:00'', 102),
    (559, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN007000559'', N''74'', ''22:25:00'', 102),
    (560, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN007000560'', N''81'', ''02:40:00'', 102),
    (561, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN007000561'', N''78'', ''08:15:00'', 102),
    (562, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN007000562'', N''85'', ''12:30:00'', 103),
    (563, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN007000563'', N''72'', ''16:45:00'', 103),
    (564, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN007000564'', N''88'', ''20:00:00'', 103),
    (565, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN007000565'', N''75'', ''06:20:00'', 103),
    (566, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000566'', N''82'', ''10:35:00'', 104),
    (567, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000567'', N''79'', ''14:50:00'', 104),
    (568, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN007000568'', N''86'', ''18:05:00'', 104),
    (569, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN007000569'', N''74'', ''22:25:00'', 104),
    (570, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN007000570'', N''81'', ''02:40:00'', 104),
    (571, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN007000571'', N''78'', ''08:15:00'', 104),
    (572, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN007000572'', N''85'', ''12:30:00'', 104),
    (573, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN007000573'', N''72'', ''16:45:00'', 105),
    (574, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN007000574'', N''88'', ''20:00:00'', 105),
    (575, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN007000575'', N''75'', ''06:20:00'', 105),
    (576, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN007000576'', N''82'', ''10:35:00'', 105),
    (577, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN007000577'', N''79'', ''14:50:00'', 105),
    (578, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000578'', N''86'', ''18:05:00'', 106),
    (579, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000579'', N''74'', ''22:25:00'', 106),
    (580, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000580'', N''81'', ''02:40:00'', 106),
    (581, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN008000581'', N''78'', ''08:15:00'', 106),
    (582, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN008000582'', N''85'', ''12:30:00'', 106),
    (583, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN008000583'', N''72'', ''16:45:00'', 106),
    (584, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN008000584'', N''88'', ''20:00:00'', 107),
    (585, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN008000585'', N''75'', ''06:20:00'', 107);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (586, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN008000586'', N''82'', ''10:35:00'', 107),
    (587, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN008000587'', N''79'', ''14:50:00'', 107),
    (588, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000588'', N''86'', ''18:05:00'', 108),
    (589, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000589'', N''74'', ''22:25:00'', 108),
    (590, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000590'', N''81'', ''02:40:00'', 108),
    (591, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN008000591'', N''78'', ''08:15:00'', 108),
    (592, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN008000592'', N''85'', ''12:30:00'', 108),
    (593, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN008000593'', N''72'', ''16:45:00'', 109),
    (594, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN008000594'', N''88'', ''20:00:00'', 109),
    (595, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN008000595'', N''75'', ''06:20:00'', 109),
    (596, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN008000596'', N''82'', ''10:35:00'', 109),
    (597, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN008000597'', N''79'', ''14:50:00'', 109),
    (598, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000598'', N''86'', ''18:05:00'', 109),
    (599, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000599'', N''74'', ''22:25:00'', 110),
    (600, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000600'', N''81'', ''02:40:00'', 110),
    (601, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN008000601'', N''78'', ''08:15:00'', 110),
    (602, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN008000602'', N''85'', ''12:30:00'', 110),
    (603, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN008000603'', N''72'', ''16:45:00'', 110),
    (604, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN008000604'', N''88'', ''20:00:00'', 110),
    (605, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN008000605'', N''75'', ''06:20:00'', 110),
    (606, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN008000606'', N''82'', ''10:35:00'', 111),
    (607, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN008000607'', N''79'', ''14:50:00'', 111),
    (608, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000608'', N''86'', ''18:05:00'', 111),
    (609, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000609'', N''74'', ''22:25:00'', 111),
    (610, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000610'', N''81'', ''02:40:00'', 111),
    (611, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN008000611'', N''78'', ''08:15:00'', 112),
    (612, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN008000612'', N''85'', ''12:30:00'', 112),
    (613, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN008000613'', N''72'', ''16:45:00'', 112),
    (614, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN008000614'', N''88'', ''20:00:00'', 112),
    (615, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN008000615'', N''75'', ''06:20:00'', 112),
    (616, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN008000616'', N''82'', ''10:35:00'', 112),
    (617, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN008000617'', N''79'', ''14:50:00'', 113),
    (618, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000618'', N''86'', ''18:05:00'', 113),
    (619, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000619'', N''74'', ''22:25:00'', 113),
    (620, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000620'', N''81'', ''02:40:00'', 113),
    (621, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN008000621'', N''78'', ''08:15:00'', 114),
    (622, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN008000622'', N''85'', ''12:30:00'', 114),
    (623, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN008000623'', N''72'', ''16:45:00'', 114),
    (624, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN008000624'', N''88'', ''20:00:00'', 114),
    (625, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN008000625'', N''75'', ''06:20:00'', 114),
    (626, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN008000626'', N''82'', ''10:35:00'', 114),
    (627, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN008000627'', N''79'', ''14:50:00'', 114);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (628, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000628'', N''86'', ''18:05:00'', 115),
    (629, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000629'', N''74'', ''22:25:00'', 115),
    (630, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000630'', N''81'', ''02:40:00'', 115),
    (631, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN008000631'', N''78'', ''08:15:00'', 115),
    (632, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN008000632'', N''85'', ''12:30:00'', 115),
    (633, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN008000633'', N''72'', ''16:45:00'', 116),
    (634, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN008000634'', N''88'', ''20:00:00'', 116),
    (635, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN008000635'', N''75'', ''06:20:00'', 116),
    (636, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN008000636'', N''82'', ''10:35:00'', 116),
    (637, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN008000637'', N''79'', ''14:50:00'', 116),
    (638, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000638'', N''86'', ''18:05:00'', 116),
    (639, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000639'', N''74'', ''22:25:00'', 117),
    (640, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000640'', N''81'', ''02:40:00'', 117),
    (641, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN008000641'', N''78'', ''08:15:00'', 117),
    (642, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN008000642'', N''85'', ''12:30:00'', 117),
    (643, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN008000643'', N''72'', ''16:45:00'', 118),
    (644, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN008000644'', N''88'', ''20:00:00'', 118),
    (645, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN008000645'', N''75'', ''06:20:00'', 118),
    (646, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN008000646'', N''82'', ''10:35:00'', 118),
    (647, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN008000647'', N''79'', ''14:50:00'', 118),
    (648, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000648'', N''86'', ''18:05:00'', 119),
    (649, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000649'', N''74'', ''22:25:00'', 119),
    (650, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000650'', N''81'', ''02:40:00'', 119),
    (651, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN008000651'', N''78'', ''08:15:00'', 119),
    (652, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN008000652'', N''85'', ''12:30:00'', 119),
    (653, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN008000653'', N''72'', ''16:45:00'', 119),
    (654, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN008000654'', N''88'', ''20:00:00'', 120),
    (655, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN008000655'', N''75'', ''06:20:00'', 120),
    (656, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN008000656'', N''82'', ''10:35:00'', 120),
    (657, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN008000657'', N''79'', ''14:50:00'', 120),
    (658, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN008000658'', N''86'', ''18:05:00'', 120),
    (659, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN008000659'', N''74'', ''22:25:00'', 120),
    (660, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN008000660'', N''81'', ''02:40:00'', 120),
    (743, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000743'', N''72'', ''16:45:00'', 136),
    (744, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000744'', N''88'', ''20:00:00'', 136),
    (745, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000745'', N''75'', ''06:20:00'', 136),
    (746, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN010000746'', N''82'', ''10:35:00'', 136),
    (747, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN010000747'', N''79'', ''14:50:00'', 136),
    (748, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN010000748'', N''86'', ''18:05:00'', 136),
    (749, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN010000749'', N''74'', ''22:25:00'', 137),
    (750, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN010000750'', N''81'', ''02:40:00'', 137),
    (751, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN010000751'', N''78'', ''08:15:00'', 137);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (752, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN010000752'', N''85'', ''12:30:00'', 137),
    (753, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000753'', N''72'', ''16:45:00'', 138),
    (754, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000754'', N''88'', ''20:00:00'', 138),
    (755, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000755'', N''75'', ''06:20:00'', 138),
    (756, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN010000756'', N''82'', ''10:35:00'', 138),
    (757, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN010000757'', N''79'', ''14:50:00'', 138),
    (758, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN010000758'', N''86'', ''18:05:00'', 139),
    (759, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN010000759'', N''74'', ''22:25:00'', 139),
    (760, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN010000760'', N''81'', ''02:40:00'', 139),
    (761, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN010000761'', N''78'', ''08:15:00'', 139),
    (762, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN010000762'', N''85'', ''12:30:00'', 139),
    (763, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000763'', N''72'', ''16:45:00'', 139),
    (764, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000764'', N''88'', ''20:00:00'', 140),
    (765, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000765'', N''75'', ''06:20:00'', 140),
    (766, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN010000766'', N''82'', ''10:35:00'', 140),
    (767, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN010000767'', N''79'', ''14:50:00'', 140),
    (768, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN010000768'', N''86'', ''18:05:00'', 140),
    (769, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN010000769'', N''74'', ''22:25:00'', 140),
    (770, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN010000770'', N''81'', ''02:40:00'', 140),
    (771, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN010000771'', N''78'', ''08:15:00'', 141),
    (772, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN010000772'', N''85'', ''12:30:00'', 141),
    (773, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000773'', N''72'', ''16:45:00'', 141),
    (774, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000774'', N''88'', ''20:00:00'', 141),
    (775, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000775'', N''75'', ''06:20:00'', 141),
    (776, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN010000776'', N''82'', ''10:35:00'', 142),
    (777, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN010000777'', N''79'', ''14:50:00'', 142),
    (778, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN010000778'', N''86'', ''18:05:00'', 142),
    (779, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN010000779'', N''74'', ''22:25:00'', 142),
    (780, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN010000780'', N''81'', ''02:40:00'', 142),
    (781, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN010000781'', N''78'', ''08:15:00'', 142),
    (782, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN010000782'', N''85'', ''12:30:00'', 143),
    (783, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000783'', N''72'', ''16:45:00'', 143),
    (784, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000784'', N''88'', ''20:00:00'', 143),
    (785, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000785'', N''75'', ''06:20:00'', 143),
    (786, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN010000786'', N''82'', ''10:35:00'', 144),
    (787, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN010000787'', N''79'', ''14:50:00'', 144),
    (788, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN010000788'', N''86'', ''18:05:00'', 144),
    (789, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN010000789'', N''74'', ''22:25:00'', 144),
    (790, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN010000790'', N''81'', ''02:40:00'', 144),
    (791, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN010000791'', N''78'', ''08:15:00'', 144),
    (792, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN010000792'', N''85'', ''12:30:00'', 144),
    (793, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000793'', N''72'', ''16:45:00'', 145);
    INSERT INTO [ReadDetails] ([Id], [BigBattery], [Co2], [Co2Val], [Counter], [Fan], [IsClean], [IsDone], [ReadingFly], [ReadingHumidty], [ReadingLarg], [ReadingLat], [ReadingLng], [ReadingMosuqitoes], [ReadingSmall], [ReadingTempIn], [ReadingTempOut], [ReadingWindSpeed], [SerialNumber], [SmallBattery], [Time], [TrapReadId])
    VALUES (794, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000794'', N''88'', ''20:00:00'', 145),
    (795, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000795'', N''75'', ''06:20:00'', 145),
    (796, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN010000796'', N''82'', ''10:35:00'', 145),
    (797, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN010000797'', N''79'', ''14:50:00'', 145),
    (798, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN010000798'', N''86'', ''18:05:00'', 146),
    (799, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN010000799'', N''74'', ''22:25:00'', 146),
    (800, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN010000800'', N''81'', ''02:40:00'', 146),
    (801, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN010000801'', N''78'', ''08:15:00'', 146),
    (802, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN010000802'', N''85'', ''12:30:00'', 146),
    (803, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000803'', N''72'', ''16:45:00'', 146),
    (804, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000804'', N''88'', ''20:00:00'', 147),
    (805, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000805'', N''75'', ''06:20:00'', 147),
    (806, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN010000806'', N''82'', ''10:35:00'', 147),
    (807, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN010000807'', N''79'', ''14:50:00'', 147),
    (808, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN010000808'', N''86'', ''18:05:00'', 148),
    (809, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN010000809'', N''74'', ''22:25:00'', 148),
    (810, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN010000810'', N''81'', ''02:40:00'', 148),
    (811, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN010000811'', N''78'', ''08:15:00'', 148),
    (812, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN010000812'', N''85'', ''12:30:00'', 148),
    (813, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000813'', N''72'', ''16:45:00'', 149),
    (814, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000814'', N''88'', ''20:00:00'', 149),
    (815, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000815'', N''75'', ''06:20:00'', 149),
    (816, N''87'', 580, N''580'', 540, 1, CAST(0 AS bit), CAST(1 AS bit), N''22'', N''51'', N''19'', N''0.0'', N''0.0'', N''68'', N''31'', N''31'', N''33'', N''10'', N''SN010000816'', N''82'', ''10:35:00'', 149),
    (817, N''94'', 490, N''490'', 870, 0, CAST(1 AS bit), CAST(0 AS bit), N''19'', N''69'', N''10'', N''0.0'', N''0.0'', N''51'', N''22'', N''26'', N''25'', N''6'', N''SN010000817'', N''79'', ''14:50:00'', 149),
    (818, N''89'', 430, N''430'', 410, 1, CAST(0 AS bit), CAST(1 AS bit), N''26'', N''42'', N''16'', N''0.0'', N''0.0'', N''79'', N''38'', N''29'', N''36'', N''14'', N''SN010000818'', N''86'', ''18:05:00'', 149),
    (819, N''93'', 560, N''560'', 690, 0, CAST(1 AS bit), CAST(0 AS bit), N''14'', N''61'', N''13'', N''0.0'', N''0.0'', N''42'', N''26'', N''33'', N''19'', N''9'', N''SN010000819'', N''74'', ''22:25:00'', 150),
    (820, N''86'', 410, N''410'', 520, 1, CAST(0 AS bit), CAST(1 AS bit), N''21'', N''48'', N''20'', N''0.0'', N''0.0'', N''63'', N''33'', N''24'', N''31'', N''11'', N''SN010000820'', N''81'', ''02:40:00'', 150),
    (821, N''92'', 450, N''450'', 450, 1, CAST(0 AS bit), CAST(1 AS bit), N''18'', N''65'', N''12'', N''0.0'', N''0.0'', N''55'', N''25'', N''28'', N''22'', N''8'', N''SN010000821'', N''78'', ''08:15:00'', 150),
    (822, N''85'', 520, N''520'', 320, 0, CAST(1 AS bit), CAST(0 AS bit), N''25'', N''45'', N''18'', N''0.0'', N''0.0'', N''72'', N''35'', N''32'', N''35'', N''12'', N''SN010000822'', N''85'', ''12:30:00'', 150),
    (823, N''96'', 380, N''380'', 780, 1, CAST(0 AS bit), CAST(1 AS bit), N''12'', N''72'', N''8'', N''0.0'', N''0.0'', N''38'', N''18'', N''25'', N''18'', N''5'', N''SN010000823'', N''72'', ''16:45:00'', 150),
    (824, N''88'', 620, N''620'', 650, 1, CAST(1 AS bit), CAST(1 AS bit), N''28'', N''38'', N''22'', N''0.0'', N''0.0'', N''84'', N''42'', N''30'', N''38'', N''15'', N''SN010000824'', N''88'', ''20:00:00'', 150),
    (825, N''91'', 340, N''340'', 290, 0, CAST(1 AS bit), CAST(0 AS bit), N''15'', N''58'', N''15'', N''0.0'', N''0.0'', N''46'', N''28'', N''27'', N''20'', N''7'', N''SN010000825'', N''75'', ''06:20:00'', 150)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BigBattery', N'Co2', N'Co2Val', N'Counter', N'Fan', N'IsClean', N'IsDone', N'ReadingFly', N'ReadingHumidty', N'ReadingLarg', N'ReadingLat', N'ReadingLng', N'ReadingMosuqitoes', N'ReadingSmall', N'ReadingTempIn', N'ReadingTempOut', N'ReadingWindSpeed', N'SerialNumber', N'SmallBattery', N'Time', N'TrapReadId') AND [object_id] = OBJECT_ID(N'[ReadDetails]'))
        SET IDENTITY_INSERT [ReadDetails] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    CREATE UNIQUE INDEX [IX_TrapReads_TrapId_Date] ON [TrapReads] ([TrapId], [Date]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    CREATE UNIQUE INDEX [IX_ReadDetails_Time_TrapReadId] ON [ReadDetails] ([Time], [TrapReadId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916084602_ComprehensiveTrapDataSeeding'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250916084602_ComprehensiveTrapDataSeeding', N'9.0.8');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TrapReads]') AND [c].[name] = N'ServerCreationDate');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [TrapReads] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [TrapReads] ALTER COLUMN [ServerCreationDate] datetime2 NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    DROP INDEX [IX_TrapReads_TrapId_Date] ON [TrapReads];
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TrapReads]') AND [c].[name] = N'Date');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [TrapReads] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [TrapReads] ALTER COLUMN [Date] datetime2 NOT NULL;
    CREATE UNIQUE INDEX [IX_TrapReads_TrapId_Date] ON [TrapReads] ([TrapId], [Date]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    DELETE FROM ReadDetails
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    DELETE FROM TrapReads
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    DELETE FROM Traps
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    SET IDENTITY_INSERT Traps ON
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN

                    INSERT INTO Traps (Id, Name, SerialNumber, TrapStatus, ReadingDate, FileDate, Lat, Long, IsCounterOn, IsCounterReadingFromSimCard, IsScheduleOn, IsThereEmergency, IsNew)
                    VALUES 
                    (1, 'Trap 1', 'SN001', 1, '2024-01-01', '2024-01-01', '40.7128', '-74.0060', 1, 0, 1, 0, 1),
                    (2, 'Trap 2', 'SN002', 1, '2024-01-02', '2024-01-02', '40.7589', '-73.9851', 1, 0, 1, 0, 1),
                    (3, 'Trap 3', 'SN003', 1, '2024-01-03', '2024-01-03', '40.7505', '-73.9934', 1, 0, 1, 0, 1),
                    (4, 'Trap 4', 'SN004', 1, '2024-01-04', '2024-01-04', '40.7282', '-73.7949', 1, 0, 1, 0, 1),
                    (5, 'Trap 5', 'SN005', 1, '2024-01-05', '2024-01-05', '40.6892', '-74.0445', 1, 0, 1, 0, 1),
                    (6, 'Trap 6', 'SN006', 1, '2024-01-06', '2024-01-06', '40.7831', '-73.9712', 1, 0, 1, 0, 1),
                    (7, 'Trap 7', 'SN007', 1, '2024-01-07', '2024-01-07', '40.7484', '-73.9857', 1, 0, 1, 0, 1),
                    (8, 'Trap 8', 'SN008', 1, '2024-01-08', '2024-01-08', '40.6782', '-73.9442', 1, 0, 1, 0, 1),
                    (9, 'Trap 9', 'SN009', 1, '2024-01-09', '2024-01-09', '40.7794', '-73.9632', 1, 0, 1, 0, 1),
                    (10, 'Trap 10', 'SN010', 1, '2024-01-10', '2024-01-10', '40.7549', '-73.9840', 1, 0, 1, 0, 1)
                
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    SET IDENTITY_INSERT Traps OFF
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    SET IDENTITY_INSERT TrapReads ON
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN

                    DECLARE @TrapId INT = 1;
                    DECLARE @ReadId INT = 1;
                    DECLARE @Counter INT = 1;

                    WHILE @TrapId <= 10
                    BEGIN
                        SET @Counter = 1;
                        WHILE @Counter <= 15
                        BEGIN
                            INSERT INTO TrapReads (Id, TrapId, Date, ServerCreationDate)
                            VALUES (
                                @ReadId,
                                @TrapId,
                                DATEADD(day, @Counter - 1, '2024-01-01'),
                                DATEADD(day, @Counter, '2024-01-01')
                            );
                            
                            SET @ReadId = @ReadId + 1;
                            SET @Counter = @Counter + 1;
                        END
                        SET @TrapId = @TrapId + 1;
                    END
                
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    SET IDENTITY_INSERT TrapReads OFF
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    SET IDENTITY_INSERT ReadDetails ON
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN

                    DECLARE @TrapReadId INT = 1;
                    DECLARE @DetailId INT = 1;
                    DECLARE @DetailCounter INT;

                    -- Loop through all 150 TrapReads
                    WHILE @TrapReadId <= 150
                    BEGIN
                        SET @DetailCounter = 1;
                        -- Generate 5-8 ReadDetails per TrapRead
                        DECLARE @NumDetails INT = 5 + (@TrapReadId % 4); -- This gives us 5-8 details per read
                        
                        WHILE @DetailCounter <= @NumDetails
                        BEGIN
                            INSERT INTO ReadDetails (Id, TrapReadId, Time, SerialNumber, ReadingLat, ReadingLng, Counter, Fan, Co2, Co2Val, ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingTempIn, ReadingTempOut, ReadingWindSpeed, ReadingHumidty, ReadingFly, BigBattery, SmallBattery, IsDone, IsClean)
                            VALUES (
                                @DetailId,
                                @TrapReadId,
                                CAST(DATEADD(minute, @DetailCounter * 10, '08:00:00') AS TIME),
                                'SN' + RIGHT('000' + CAST(@TrapReadId AS VARCHAR), 3) + '_' + CAST(@DetailCounter AS VARCHAR),
                                '40.7128',
                                '-74.0060',
                                @DetailCounter * 10,
                                @DetailCounter % 3,
                                @DetailCounter * 5,
                                'CO2_' + CAST(@DetailCounter AS VARCHAR),
                                'Small_' + CAST(@DetailCounter AS VARCHAR),
                                'Large_' + CAST(@DetailCounter AS VARCHAR),
                                'Mosquitoes_' + CAST(@DetailCounter AS VARCHAR),
                                'TempIn_' + CAST(@DetailCounter AS VARCHAR),
                                'TempOut_' + CAST(@DetailCounter AS VARCHAR),
                                'WindSpeed_' + CAST(@DetailCounter AS VARCHAR),
                                'Humidity_' + CAST(@DetailCounter AS VARCHAR),
                                'Fly_' + CAST(@DetailCounter AS VARCHAR),
                                'BigBat_' + CAST(@DetailCounter AS VARCHAR),
                                'SmallBat_' + CAST(@DetailCounter AS VARCHAR),
                                CASE WHEN @DetailCounter % 2 = 0 THEN 1 ELSE 0 END,
                                CASE WHEN @DetailCounter % 3 = 0 THEN 1 ELSE 0 END
                            );
                            
                            SET @DetailId = @DetailId + 1;
                            SET @DetailCounter = @DetailCounter + 1;
                        END
                        
                        SET @TrapReadId = @TrapReadId + 1;
                    END
                
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    SET IDENTITY_INSERT ReadDetails OFF
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    EXEC(N'UPDATE [Users] SET [ConcurrencyStamp] = N''c8554266-b7bb-4f44-9aac-0cbaa7b4e92a''
    WHERE [Id] = ''11111111-1111-1111-1111-111111111111'';
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    EXEC(N'UPDATE [Users] SET [ConcurrencyStamp] = N''c8554266-b7bb-4f44-9aac-0cbaa7b4e92a''
    WHERE [Id] = ''22222222-2222-2222-2222-222222222222'';
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    EXEC(N'UPDATE [Users] SET [ConcurrencyStamp] = N''c8554266-b7bb-4f44-9aac-0cbaa7b4e92a''
    WHERE [Id] = ''33333333-3333-3333-3333-333333333333'';
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    EXEC(N'UPDATE [Users] SET [ConcurrencyStamp] = N''c8554266-b7bb-4f44-9aac-0cbaa7b4e92a''
    WHERE [Id] = ''44444444-4444-4444-4444-444444444444'';
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    EXEC(N'UPDATE [Users] SET [ConcurrencyStamp] = N''c8554266-b7bb-4f44-9aac-0cbaa7b4e92a''
    WHERE [Id] = ''55555555-5555-5555-5555-555555555555'';
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250916091423_SeedDataWithReadDetailsFixed'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250916091423_SeedDataWithReadDetailsFixed', N'9.0.8');
END;

COMMIT;
GO

