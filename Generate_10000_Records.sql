-- =============================================
-- Script to Generate 10,000 ReadDetails Records for Testing
-- This will create approximately 10,000 ReadDetails records across multiple months
-- =============================================

-- Variables for data generation
DECLARE @StartDate DATE = '2024-07-01'; -- Start from July 2024 to have 6+ months of data
DECLARE @EndDate DATE = '2025-01-31';   -- End in January 2025
DECLARE @CurrentDate DATE = @StartDate;
DECLARE @TrapReadId INT;
DECLARE @ReadDetailId INT;
DECLARE @TargetRecords INT = 10000;
DECLARE @RecordsGenerated INT = 0;

-- Get the next available IDs to avoid conflicts
SELECT @TrapReadId = ISNULL(MAX(Id), 0) + 1 FROM TrapReads;
SELECT @ReadDetailId = ISNULL(MAX(Id), 0) + 1 FROM ReadDetails;

PRINT 'Starting TrapRead ID: ' + CAST(@TrapReadId AS VARCHAR(10));
PRINT 'Starting ReadDetail ID: ' + CAST(@ReadDetailId AS VARCHAR(10));
PRINT 'Target Records: ' + CAST(@TargetRecords AS VARCHAR(10));

-- =============================================
-- Generate TrapRead and ReadDetails Data
-- =============================================
PRINT 'Generating ' + CAST(@TargetRecords AS VARCHAR(10)) + ' ReadDetails records...';

WHILE @CurrentDate <= @EndDate AND @RecordsGenerated < @TargetRecords
BEGIN
    -- Generate readings for each trap (1-15) with varying frequency
    DECLARE @TrapId INT = 1;
    
    WHILE @TrapId <= 15 AND @RecordsGenerated < @TargetRecords
    BEGIN
        -- Generate 3-8 readings per day per trap (random)
        DECLARE @ReadingsPerDay INT = 3 + (ABS(CHECKSUM(NEWID())) % 6);
        DECLARE @ReadingCount INT = 1;
        
        WHILE @ReadingCount <= @ReadingsPerDay AND @RecordsGenerated < @TargetRecords
        BEGIN
            -- Random time offset for the reading (spread throughout the day)
            DECLARE @TimeOffset INT = ABS(CHECKSUM(NEWID())) % 1440; -- Random minutes in a day
            DECLARE @ReadingDateTime DATETIME2 = DATEADD(MINUTE, @TimeOffset, @CurrentDate);
            
            -- Insert TrapRead
            INSERT INTO TrapReads (Date, ServerCreationDate, TrapId)
            VALUES (CAST(@CurrentDate AS DATE), CAST(@CurrentDate AS DATE), @TrapId);
            
            DECLARE @CurrentTrapReadId INT = @TrapReadId;
            SET @TrapReadId = @TrapReadId + 1;
            
            -- Generate 5-12 ReadDetails per TrapRead to reach 10,000 faster
            DECLARE @DetailsCount INT = 5 + (ABS(CHECKSUM(NEWID())) % 8);
            DECLARE @DetailIndex INT = 1;
            
            WHILE @DetailIndex <= @DetailsCount AND @RecordsGenerated < @TargetRecords
            BEGIN
                -- Generate realistic random values
                DECLARE @MosquitoCount INT = ABS(CHECKSUM(NEWID())) % 200; -- 0-199 mosquitoes
                DECLARE @SmallCount INT = ABS(CHECKSUM(NEWID())) % 80; -- 0-79 small insects
                DECLARE @LargeCount INT = ABS(CHECKSUM(NEWID())) % 50; -- 0-49 large insects
                DECLARE @FlyCount INT = ABS(CHECKSUM(NEWID())) % 60; -- 0-59 flies
                
                -- Generate other sensor readings
                DECLARE @Counter INT = ABS(CHECKSUM(NEWID())) % 2000;
                DECLARE @Fan INT = ABS(CHECKSUM(NEWID())) % 5; -- 0-4 fan levels
                DECLARE @Co2Level INT = 250 + (ABS(CHECKSUM(NEWID())) % 800); -- 250-1049 ppm
                DECLARE @TempIn DECIMAL(5,2) = 10.0 + (ABS(CHECKSUM(NEWID())) % 400) / 10.0; -- 10-49.9°C
                DECLARE @TempOut DECIMAL(5,2) = 5.0 + (ABS(CHECKSUM(NEWID())) % 500) / 10.0; -- 5-54.9°C
                DECLARE @WindSpeed DECIMAL(5,2) = (ABS(CHECKSUM(NEWID())) % 300) / 10.0; -- 0-29.9 m/s
                DECLARE @Humidity DECIMAL(5,2) = 15.0 + (ABS(CHECKSUM(NEWID())) % 800) / 10.0; -- 15-94.9%
                DECLARE @BigBattery DECIMAL(5,2) = 30.0 + (ABS(CHECKSUM(NEWID())) % 700) / 10.0; -- 30-99.9%
                DECLARE @SmallBattery DECIMAL(5,2) = 25.0 + (ABS(CHECKSUM(NEWID())) % 750) / 10.0; -- 25-99.9%
                
                -- Generate GPS coordinates (around different locations in Egypt)
                DECLARE @Lat DECIMAL(10,7) = 29.0 + (ABS(CHECKSUM(NEWID())) % 3000) / 100000.0; -- 29.0-32.0
                DECLARE @Long DECIMAL(10,7) = 30.0 + (ABS(CHECKSUM(NEWID())) % 4000) / 100000.0; -- 30.0-34.0
                
                -- Generate time for the reading (spread throughout the day)
                DECLARE @ReadingHour INT = ABS(CHECKSUM(NEWID())) % 24;
                DECLARE @ReadingMinute INT = ABS(CHECKSUM(NEWID())) % 60;
                DECLARE @ReadingSecond INT = ABS(CHECKSUM(NEWID())) % 60;
                DECLARE @ReadingTime TIME = CAST(FORMAT(@ReadingHour, '00') + ':' + FORMAT(@ReadingMinute, '00') + ':' + FORMAT(@ReadingSecond, '00') AS TIME);
                
                INSERT INTO ReadDetails (
                    Time, SerialNumber, ReadingLat, ReadingLng, Counter, Fan, Co2, Co2Val,
                    ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingTempIn, ReadingTempOut,
                    ReadingWindSpeed, ReadingHumidty, ReadingFly, BigBattery, SmallBattery,
                    IsDone, IsClean, TrapReadId
                )
                VALUES (
                    @ReadingTime, 
                    'SN' + CAST(@TrapId AS VARCHAR(5)) + '_' + FORMAT(@CurrentDate, 'yyyyMMdd') + '_' + CAST(@DetailIndex AS VARCHAR(3)),
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
                SET @RecordsGenerated = @RecordsGenerated + 1;
                
                -- Progress indicator every 1000 records
                IF @RecordsGenerated % 1000 = 0
                BEGIN
                    PRINT 'Generated ' + CAST(@RecordsGenerated AS VARCHAR(10)) + ' records...';
                END
            END
            
            SET @ReadingCount = @ReadingCount + 1;
        END
        
        SET @TrapId = @TrapId + 1;
    END
    
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END

PRINT 'Data generation completed. Total ReadDetails records generated: ' + CAST(@RecordsGenerated AS VARCHAR(10));

-- =============================================
-- Summary Statistics
-- =============================================
PRINT '=== DATA GENERATION SUMMARY ===';
PRINT 'Date Range: ' + CAST(@StartDate AS VARCHAR(20)) + ' to ' + CAST(@EndDate AS VARCHAR(20));
PRINT 'Records Generated: ' + CAST(@RecordsGenerated AS VARCHAR(10));

-- Show total counts
SELECT 
    'TrapReads (All)' as TableName,
    COUNT(*) as TotalRecords,
    MIN(Date) as EarliestDate,
    MAX(Date) as LatestDate
FROM TrapReads

UNION ALL

SELECT 
    'ReadDetails (All)' as TableName,
    COUNT(*) as TotalRecords,
    MIN(tr.Date) as EarliestDate,
    MAX(tr.Date) as LatestDate
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id;

-- Show mosquito count statistics by month for the last 6 months
SELECT 
    YEAR(tr.Date) as Year,
    MONTH(tr.Date) as Month,
    DATENAME(MONTH, tr.Date) as MonthName,
    COUNT(rd.Id) as ReadDetailsCount,
    SUM(rd.ReadingMosuqitoes) as TotalMosquitoes,
    AVG(rd.ReadingMosuqitoes) as AvgMosquitoes,
    MIN(rd.ReadingMosuqitoes) as MinMosquitoes,
    MAX(rd.ReadingMosuqitoes) as MaxMosquitoes
FROM TrapReads tr
INNER JOIN ReadDetails rd ON tr.Id = rd.TrapReadId
WHERE tr.Date >= DATEADD(MONTH, -6, GETDATE())
GROUP BY YEAR(tr.Date), MONTH(tr.Date), DATENAME(MONTH, tr.Date)
ORDER BY YEAR(tr.Date), MONTH(tr.Date);

PRINT 'You can now test your GetCountOfMosuqitoesPer6Month endpoint with ' + CAST(@RecordsGenerated AS VARCHAR(10)) + ' records!';