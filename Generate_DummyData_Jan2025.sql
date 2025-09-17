-- =============================================
-- Script to Generate Dummy Data for Testing GetCountOfMosuqitoesPer6Month
-- Date Range: 01/01/2025 to 01/09/2025 (9 days)
-- =============================================

-- Variables for date calculations
DECLARE @StartDate DATE = '2025-01-01';
DECLARE @EndDate DATE = '2025-01-09';
DECLARE @CurrentDate DATE = @StartDate;
DECLARE @TrapReadId INT;
DECLARE @ReadDetailId INT;

-- Get the next available IDs to avoid conflicts
SELECT @TrapReadId = ISNULL(MAX(Id), 0) + 1 FROM TrapReads;
SELECT @ReadDetailId = ISNULL(MAX(Id), 0) + 1 FROM ReadDetails;

PRINT 'Starting TrapRead ID: ' + CAST(@TrapReadId AS VARCHAR(10));
PRINT 'Starting ReadDetail ID: ' + CAST(@ReadDetailId AS VARCHAR(10));

-- =============================================
-- Generate TrapRead Data for the specified range
-- =============================================
PRINT 'Generating TrapRead data from ' + CAST(@StartDate AS VARCHAR(20)) + ' to ' + CAST(@EndDate AS VARCHAR(20)) + '...';

WHILE @CurrentDate <= @EndDate
BEGIN
    -- Generate readings for each trap (1-10) with varying frequency
    DECLARE @TrapId INT = 1;
    
    WHILE @TrapId <= 10
    BEGIN
        -- Generate 2-4 readings per day per trap (random)
        DECLARE @ReadingsPerDay INT = 2 + (ABS(CHECKSUM(NEWID())) % 3);
        DECLARE @ReadingCount INT = 1;
        
        WHILE @ReadingCount <= @ReadingsPerDay
        BEGIN
            -- Random time offset for the reading (spread throughout the day)
            DECLARE @TimeOffset INT = ABS(CHECKSUM(NEWID())) % 1440; -- Random minutes in a day
            DECLARE @ReadingDateTime DATETIME2 = DATEADD(MINUTE, @TimeOffset, @CurrentDate);
            
            INSERT INTO TrapReads (Date, ServerCreationDate, TrapId)
            VALUES (CAST(@CurrentDate AS DATE), CAST(@CurrentDate AS DATE), @TrapId);
            
            SET @TrapReadId = @TrapReadId + 1;
            SET @ReadingCount = @ReadingCount + 1;
        END
        
        SET @TrapId = @TrapId + 1;
    END
    
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END

PRINT 'TrapRead data generation completed.';

-- =============================================
-- Generate ReadDetails Data
-- =============================================
PRINT 'Generating ReadDetails data...';

DECLARE @TrapReadCursor CURSOR;
SET @TrapReadCursor = CURSOR FOR
    SELECT Id, TrapId, Date FROM TrapReads 
    WHERE Date >= @StartDate AND Date <= @EndDate
    ORDER BY Date, TrapId;

DECLARE @CurrentTrapReadId INT, @CurrentTrapIdForDetails INT, @CurrentReadDate DATE;

OPEN @TrapReadCursor;
FETCH NEXT FROM @TrapReadCursor INTO @CurrentTrapReadId, @CurrentTrapIdForDetails, @CurrentReadDate;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Generate 3-6 ReadDetails per TrapRead
    DECLARE @DetailsCount INT = 3 + (ABS(CHECKSUM(NEWID())) % 4);
    DECLARE @DetailIndex INT = 1;
    
    WHILE @DetailIndex <= @DetailsCount
    BEGIN
        -- Generate realistic random values
        DECLARE @MosquitoCount INT = ABS(CHECKSUM(NEWID())) % 150; -- 0-149 mosquitoes
        DECLARE @SmallCount INT = ABS(CHECKSUM(NEWID())) % 50; -- 0-49 small insects
        DECLARE @LargeCount INT = ABS(CHECKSUM(NEWID())) % 30; -- 0-29 large insects
        DECLARE @FlyCount INT = ABS(CHECKSUM(NEWID())) % 40; -- 0-39 flies
        
        -- Generate other sensor readings
        DECLARE @Counter INT = ABS(CHECKSUM(NEWID())) % 1000;
        DECLARE @Fan INT = ABS(CHECKSUM(NEWID())) % 4; -- 0-3 fan levels
        DECLARE @Co2Level INT = 300 + (ABS(CHECKSUM(NEWID())) % 700); -- 300-999 ppm
        DECLARE @TempIn DECIMAL(5,2) = 15.0 + (ABS(CHECKSUM(NEWID())) % 300) / 10.0; -- 15-44.9°C
        DECLARE @TempOut DECIMAL(5,2) = 10.0 + (ABS(CHECKSUM(NEWID())) % 400) / 10.0; -- 10-49.9°C
        DECLARE @WindSpeed DECIMAL(5,2) = (ABS(CHECKSUM(NEWID())) % 200) / 10.0; -- 0-19.9 m/s
        DECLARE @Humidity DECIMAL(5,2) = 20.0 + (ABS(CHECKSUM(NEWID())) % 600) / 10.0; -- 20-79.9%
        DECLARE @BigBattery DECIMAL(5,2) = 50.0 + (ABS(CHECKSUM(NEWID())) % 500) / 10.0; -- 50-99.9%
        DECLARE @SmallBattery DECIMAL(5,2) = 40.0 + (ABS(CHECKSUM(NEWID())) % 600) / 10.0; -- 40-99.9%
        
        -- Generate GPS coordinates (around Cairo, Egypt as example)
        DECLARE @Lat DECIMAL(10,7) = 30.0444 + (ABS(CHECKSUM(NEWID())) % 1000) / 100000.0;
        DECLARE @Long DECIMAL(10,7) = 31.2357 + (ABS(CHECKSUM(NEWID())) % 1000) / 100000.0;
        
        -- Generate time for the reading (spread throughout the day)
        DECLARE @ReadingHour INT = ABS(CHECKSUM(NEWID())) % 24;
        DECLARE @ReadingMinute INT = ABS(CHECKSUM(NEWID())) % 60;
        DECLARE @ReadingTime TIME = CAST(FORMAT(@ReadingHour, '00') + ':' + FORMAT(@ReadingMinute, '00') + ':00' AS TIME);
        
        INSERT INTO ReadDetails (
            Time, SerialNumber, ReadingLat, ReadingLng, Counter, Fan, Co2, Co2Val,
            ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingTempIn, ReadingTempOut,
            ReadingWindSpeed, ReadingHumidty, ReadingFly, BigBattery, SmallBattery,
            IsDone, IsClean, TrapReadId
        )
        VALUES (
            @ReadingTime, 
            'SN' + CAST(@CurrentTrapIdForDetails AS VARCHAR(5)) + '_' + FORMAT(@CurrentReadDate, 'yyyyMMdd') + '_' + CAST(@DetailIndex AS VARCHAR(2)),
            CAST(@Lat AS VARCHAR(20)), 
            CAST(@Long AS VARCHAR(20)), 
            @Counter, 
            @Fan, 
            @Co2Level, 
            CAST(@Co2Level AS VARCHAR(10)),
            @SmallCount, 
            @LargeCount, 
            @MosquitoCount, 
            CAST(@TempIn AS VARCHAR(10)), 
            CAST(@TempOut AS VARCHAR(10)),
            CAST(@WindSpeed AS VARCHAR(10)), 
            CAST(@Humidity AS VARCHAR(10)), 
            @FlyCount, 
            CAST(@BigBattery AS VARCHAR(10)), 
            CAST(@SmallBattery AS VARCHAR(10)),
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

PRINT 'ReadDetails data generation completed.';

-- =============================================
-- Summary Statistics
-- =============================================
PRINT '=== DATA GENERATION SUMMARY ===';
PRINT 'Date Range: ' + CAST(@StartDate AS VARCHAR(20)) + ' to ' + CAST(@EndDate AS VARCHAR(20));

SELECT 
    'TrapReads (New)' as TableName,
    COUNT(*) as TotalRecords,
    MIN(Date) as EarliestDate,
    MAX(Date) as LatestDate
FROM TrapReads 
WHERE Date >= @StartDate AND Date <= @EndDate

UNION ALL

SELECT 
    'ReadDetails (New)' as TableName,
    COUNT(*) as TotalRecords,
    MIN(tr.Date) as EarliestDate,
    MAX(tr.Date) as LatestDate
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id
WHERE tr.Date >= @StartDate AND tr.Date <= @EndDate;

-- Show mosquito count statistics for the new data
SELECT 
    tr.Date,
    tr.TrapId,
    COUNT(rd.Id) as ReadDetailsCount,
    SUM(rd.ReadingMosuqitoes) as TotalMosquitoes,
    AVG(rd.ReadingMosuqitoes) as AvgMosquitoes,
    MIN(rd.ReadingMosuqitoes) as MinMosquitoes,
    MAX(rd.ReadingMosuqitoes) as MaxMosquitoes
FROM TrapReads tr
INNER JOIN ReadDetails rd ON tr.Id = rd.TrapReadId
WHERE tr.Date >= @StartDate AND tr.Date <= @EndDate
GROUP BY tr.Date, tr.TrapId
ORDER BY tr.Date, tr.TrapId;

PRINT 'Dummy data generation completed successfully!';
PRINT 'You can now test your GetCountOfMosuqitoesPer6Month endpoint with data from January 1-9, 2025.';