-- =============================================
-- Script to Generate 2 Years of Dummy Data for Trap System
-- =============================================

-- Variables for date calculations
DECLARE @StartDate DATE = DATEADD(YEAR, -2, GETDATE());
DECLARE @EndDate DATE = GETDATE();
DECLARE @CurrentDate DATE = @StartDate;
DECLARE @TrapReadId INT = 1000; -- Start from 1000 to avoid conflicts
DECLARE @ReadDetailId INT = 5000; -- Start from 5000 to avoid conflicts
DECLARE @EmergencyId INT = 100; -- Start from 100 to avoid conflicts

-- Clear existing data (optional - uncomment if you want to start fresh)
-- DELETE FROM ReadDetails WHERE Id >= 5000;
-- DELETE FROM TrapReads WHERE Id >= 1000;
-- DELETE FROM TrapEmergencies WHERE Id >= 100;

-- =============================================
-- Generate TrapRead Data (2 years)
-- =============================================
PRINT 'Generating TrapRead data for 2 years...';

WHILE @CurrentDate <= @EndDate
BEGIN
    -- Generate readings for each trap (1-10) with varying frequency
    DECLARE @TrapId INT = 1;
    
    WHILE @TrapId <= 10
    BEGIN
        -- Generate 1-3 readings per day per trap (random)
        DECLARE @ReadingsPerDay INT = 1 + (ABS(CHECKSUM(NEWID())) % 3);
        DECLARE @ReadingCount INT = 1;
        
        WHILE @ReadingCount <= @ReadingsPerDay
        BEGIN
            -- Random time offset for the reading
            DECLARE @TimeOffset INT = ABS(CHECKSUM(NEWID())) % 1440; -- Random minutes in a day
            DECLARE @ReadingDateTime DATETIME2 = DATEADD(MINUTE, @TimeOffset, @CurrentDate);
            
            INSERT INTO TrapReads (Date, ServerCreationDate, TrapId)
            VALUES (@ReadingDateTime, @ReadingDateTime, @TrapId);
            
            SET @TrapReadId = @TrapReadId + 1;
            SET @ReadingCount = @ReadingCount + 1;
        END
        
        SET @TrapId = @TrapId + 1;
    END
    
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END

PRINT 'TrapRead data generation completed. Total records: ' + CAST(@TrapReadId - 1000 AS VARCHAR(10));

-- =============================================
-- Generate ReadDetails Data
-- =============================================
PRINT 'Generating ReadDetails data...';

DECLARE @TrapReadCursor CURSOR;
SET @TrapReadCursor = CURSOR FOR
    SELECT Id, TrapId, Date FROM TrapReads WHERE Id >= 1000;

DECLARE @CurrentTrapReadId INT, @CurrentTrapIdForDetails INT, @CurrentReadDate DATETIME2;

OPEN @TrapReadCursor;
FETCH NEXT FROM @TrapReadCursor INTO @CurrentTrapReadId, @CurrentTrapIdForDetails, @CurrentReadDate;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Generate 2-5 ReadDetails per TrapRead
    DECLARE @DetailsCount INT = 2 + (ABS(CHECKSUM(NEWID())) % 4);
    DECLARE @DetailIndex INT = 1;
    
    WHILE @DetailIndex <= @DetailsCount
    BEGIN
        -- Generate realistic random values
        DECLARE @MosquitoCount INT = ABS(CHECKSUM(NEWID())) % 100; -- 0-99 mosquitoes
        DECLARE @SmallCount INT = ABS(CHECKSUM(NEWID())) % 50; -- 0-49 small insects
        DECLARE @LargeCount INT = ABS(CHECKSUM(NEWID())) % 30; -- 0-29 large insects
        DECLARE @FlyCount INT = ABS(CHECKSUM(NEWID())) % 40; -- 0-39 flies
        DECLARE @TempIn DECIMAL(5,2) = 15.0 + (ABS(CHECKSUM(NEWID())) % 300) / 10.0; -- 15-45°C
        DECLARE @TempOut DECIMAL(5,2) = 10.0 + (ABS(CHECKSUM(NEWID())) % 400) / 10.0; -- 10-50°C
        DECLARE @Humidity DECIMAL(5,2) = 20.0 + (ABS(CHECKSUM(NEWID())) % 600) / 10.0; -- 20-80%
        DECLARE @WindSpeed DECIMAL(5,2) = (ABS(CHECKSUM(NEWID())) % 200) / 10.0; -- 0-20 m/s
        DECLARE @Co2Level INT = 300 + (ABS(CHECKSUM(NEWID())) % 500); -- 300-800 ppm
        DECLARE @Counter INT = ABS(CHECKSUM(NEWID())) % 1000; -- 0-999
        DECLARE @Fan INT = ABS(CHECKSUM(NEWID())) % 2; -- 0 or 1
        DECLARE @BigBattery DECIMAL(5,2) = 50.0 + (ABS(CHECKSUM(NEWID())) % 500) / 10.0; -- 50-100%
        DECLARE @SmallBattery DECIMAL(5,2) = 30.0 + (ABS(CHECKSUM(NEWID())) % 700) / 10.0; -- 30-100%
        
        -- Generate random coordinates (Egypt region)
        DECLARE @Lat DECIMAL(10,8) = 22.0 + (ABS(CHECKSUM(NEWID())) % 1000) / 100.0; -- 22-32°N
        DECLARE @Long DECIMAL(11,8) = 25.0 + (ABS(CHECKSUM(NEWID())) % 1000) / 100.0; -- 25-35°E
        
        -- Random time within the day
        DECLARE @ReadingTime TIME = CAST(DATEADD(MINUTE, ABS(CHECKSUM(NEWID())) % 1440, '00:00:00') AS TIME);
        
        INSERT INTO ReadDetails (
            Time, SerialNumber, ReadingLat, ReadingLng, Counter, Fan, Co2, Co2Val,
            ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingTempIn, ReadingTempOut,
            ReadingWindSpeed, ReadingHumidty, ReadingFly, BigBattery, SmallBattery,
            IsDone, IsClean, TrapReadId
        )
        VALUES (
            @ReadingTime, 'SN' + CAST(@CurrentTrapIdForDetails AS VARCHAR(5)) + '_' + CAST(@DetailIndex AS VARCHAR(2)),
            CAST(@Lat AS VARCHAR(20)), CAST(@Long AS VARCHAR(20)), @Counter, @Fan, @Co2Level, CAST(@Co2Level AS VARCHAR(10)),
            @SmallCount, @LargeCount, @MosquitoCount, CAST(@TempIn AS VARCHAR(10)), CAST(@TempOut AS VARCHAR(10)),
            CAST(@WindSpeed AS VARCHAR(10)), CAST(@Humidity AS VARCHAR(10)), @FlyCount, CAST(@BigBattery AS VARCHAR(10)), CAST(@SmallBattery AS VARCHAR(10)),
            CASE WHEN ABS(CHECKSUM(NEWID())) % 10 < 8 THEN 1 ELSE 0 END, -- 80% done
            CASE WHEN ABS(CHECKSUM(NEWID())) % 10 < 7 THEN 1 ELSE 0 END, -- 70% clean
            @CurrentTrapReadId
        );
        
        SET @ReadDetailId = @ReadDetailId + 1;
        SET @DetailIndex = @DetailIndex + 1;
    END
    
    FETCH NEXT FROM @TrapReadCursor INTO @CurrentTrapReadId, @CurrentTrapIdForDetails, @CurrentReadDate;
END

CLOSE @TrapReadCursor;
DEALLOCATE @TrapReadCursor;

PRINT 'ReadDetails data generation completed. Total records: ' + CAST(@ReadDetailId - 5000 AS VARCHAR(10));

-- =============================================
-- Generate TrapEmergency Data
-- =============================================
PRINT 'Generating TrapEmergency data...';

-- Reset date for emergency generation
SET @CurrentDate = @StartDate;

WHILE @CurrentDate <= @EndDate
BEGIN
    -- Generate random emergencies (0-2 per day across all traps)
    DECLARE @EmergenciesPerDay INT = ABS(CHECKSUM(NEWID())) % 3;
    DECLARE @EmergencyCount INT = 1;
    
    WHILE @EmergencyCount <= @EmergenciesPerDay
    BEGIN
        -- Random trap for emergency
        DECLARE @EmergencyTrapId INT = 1 + (ABS(CHECKSUM(NEWID())) % 10);
        
        -- Random time for emergency
        DECLARE @EmergencyTime DATETIME = DATEADD(MINUTE, ABS(CHECKSUM(NEWID())) % 1440, @CurrentDate);
        
        -- Random coordinates
        DECLARE @EmergencyLat DECIMAL(10,8) = 22.0 + (ABS(CHECKSUM(NEWID())) % 1000) / 100.0;
        DECLARE @EmergencyLong DECIMAL(11,8) = 25.0 + (ABS(CHECKSUM(NEWID())) % 1000) / 100.0;
        
        INSERT INTO TrapEmergency (Lat, Long, Date, InsertDate, EmergencyStatus, TrapId)
        VALUES (
            CAST(@EmergencyLat AS VARCHAR(20)),
            CAST(@EmergencyLong AS VARCHAR(20)),
            @EmergencyTime,
            @EmergencyTime,
            CASE WHEN ABS(CHECKSUM(NEWID())) % 10 < 8 THEN 1 ELSE 0 END, -- 80% active emergencies
            @EmergencyTrapId
        );
        
        SET @EmergencyId = @EmergencyId + 1;
        SET @EmergencyCount = @EmergencyCount + 1;
    END
    
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END

PRINT 'TrapEmergency data generation completed. Total records: ' + CAST(@EmergencyId - 100 AS VARCHAR(10));

-- =============================================
-- Generate Additional Companies (Optional)
-- =============================================
PRINT 'Generating additional company data...';

-- Add more companies (only Name column exists)
INSERT INTO Companies (Name)
VALUES 
    ('Advanced Pest Control LLC'),
    ('EcoTrap Solutions'),
    ('Desert Shield Pest Management'),
    ('Nile Valley Monitoring'),
    ('Smart Trap Technologies');

-- =============================================
-- Summary Statistics
-- =============================================
PRINT '=== DATA GENERATION SUMMARY ===';
PRINT 'Date Range: ' + CAST(@StartDate AS VARCHAR(20)) + ' to ' + CAST(@EndDate AS VARCHAR(20));

SELECT 
    'TrapReads' as TableName,
    COUNT(*) as TotalRecords,
    MIN(Date) as EarliestDate,
    MAX(Date) as LatestDate
FROM TrapReads

UNION ALL

SELECT 
    'ReadDetails' as TableName,
    COUNT(*) as TotalRecords,
    MIN(tr.Date) as EarliestDate,
    MAX(tr.Date) as LatestDate
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id

UNION ALL

SELECT 
    'TrapEmergency' as TableName,
    COUNT(*) as TotalRecords,
    MIN(Date) as EarliestDate,
    MAX(Date) as LatestDate
FROM TrapEmergency

UNION ALL

SELECT 
    'Companies' as TableName,
    COUNT(*) as TotalRecords,
    NULL as EarliestDate,
    NULL as LatestDate
FROM Companies;

PRINT 'Dummy data generation completed successfully!';
PRINT 'You can now test your GetCountOfMosuqitoesPerMonth endpoint with 2 years of realistic data.';