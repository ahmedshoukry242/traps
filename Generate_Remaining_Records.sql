-- =============================================
-- Generate Remaining Records to Reach Exactly 10,000
-- Current: ~5,705, Need: ~4,295 more
-- =============================================

DECLARE @CurrentCount INT;
DECLARE @TargetCount INT = 10000;
DECLARE @RecordsToGenerate INT;
DECLARE @RecordsGenerated INT = 0;
DECLARE @TrapReadId INT;

-- Get current count
SELECT @CurrentCount = COUNT(*) FROM ReadDetails;
SET @RecordsToGenerate = @TargetCount - @CurrentCount;

PRINT 'Current ReadDetails count: ' + CAST(@CurrentCount AS VARCHAR(10));
PRINT 'Target count: ' + CAST(@TargetCount AS VARCHAR(10));
PRINT 'Records to generate: ' + CAST(@RecordsToGenerate AS VARCHAR(10));

-- Get next TrapRead ID
SELECT @TrapReadId = ISNULL(MAX(Id), 0) + 1 FROM TrapReads;

-- Only proceed if we need more records
IF @RecordsToGenerate > 0
BEGIN
    PRINT 'Starting generation of remaining ' + CAST(@RecordsToGenerate AS VARCHAR(10)) + ' records...';
    
    DECLARE @CurrentDate DATE = '2024-12-01'; -- Use December 2024 for recent data
    DECLARE @DayCounter INT = 0;
    
    WHILE @RecordsGenerated < @RecordsToGenerate
    BEGIN
        -- Cycle through traps 1-20
        DECLARE @TrapId INT = 1 + (@RecordsGenerated % 20);
        
        -- Spread across different days
        IF @RecordsGenerated % 100 = 0
        BEGIN
            SET @DayCounter = @DayCounter + 1;
        END
        
        DECLARE @ReadDate DATE = DATEADD(DAY, @DayCounter, @CurrentDate);
        
        -- Insert TrapRead
        INSERT INTO TrapReads (Date, ServerCreationDate, TrapId)
        VALUES (@ReadDate, @ReadDate, @TrapId);
        
        DECLARE @CurrentTrapReadId INT = @TrapReadId;
        SET @TrapReadId = @TrapReadId + 1;
        
        -- Generate 1-3 ReadDetails per TrapRead
        DECLARE @DetailsCount INT = 1 + (@RecordsGenerated % 3);
        DECLARE @DetailIndex INT = 0;
        
        WHILE @DetailIndex < @DetailsCount AND @RecordsGenerated < @RecordsToGenerate
        BEGIN
            -- Generate random sensor values
            DECLARE @MosquitoCount INT = ABS(CHECKSUM(NEWID())) % 150;
            DECLARE @SmallCount INT = ABS(CHECKSUM(NEWID())) % 70;
            DECLARE @LargeCount INT = ABS(CHECKSUM(NEWID())) % 45;
            DECLARE @FlyCount INT = ABS(CHECKSUM(NEWID())) % 55;
            DECLARE @Counter INT = ABS(CHECKSUM(NEWID())) % 2500;
            DECLARE @Fan INT = ABS(CHECKSUM(NEWID())) % 6;
            DECLARE @Co2Level INT = 350 + (ABS(CHECKSUM(NEWID())) % 650);
            
            -- Generate time (spread throughout day)
            DECLARE @Hour INT = ABS(CHECKSUM(NEWID())) % 24;
            DECLARE @Minute INT = ABS(CHECKSUM(NEWID())) % 60;
            DECLARE @Second INT = ABS(CHECKSUM(NEWID())) % 60;
            DECLARE @ReadingTime TIME = CAST(FORMAT(@Hour, '00') + ':' + FORMAT(@Minute, '00') + ':' + FORMAT(@Second, '00') AS TIME);
            
            -- Generate GPS coordinates (Egypt region)
            DECLARE @Lat DECIMAL(10,7) = 29.5 + (ABS(CHECKSUM(NEWID())) % 2500) / 100000.0;
            DECLARE @Long DECIMAL(10,7) = 30.5 + (ABS(CHECKSUM(NEWID())) % 3500) / 100000.0;
            
            -- Generate environmental readings
            DECLARE @TempIn DECIMAL(5,2) = 18.0 + (ABS(CHECKSUM(NEWID())) % 320) / 10.0;
            DECLARE @TempOut DECIMAL(5,2) = 12.0 + (ABS(CHECKSUM(NEWID())) % 380) / 10.0;
            DECLARE @WindSpeed DECIMAL(5,2) = (ABS(CHECKSUM(NEWID())) % 200) / 10.0;
            DECLARE @Humidity DECIMAL(5,2) = 25.0 + (ABS(CHECKSUM(NEWID())) % 650) / 10.0;
            DECLARE @BigBattery DECIMAL(5,2) = 45.0 + (ABS(CHECKSUM(NEWID())) % 550) / 10.0;
            DECLARE @SmallBattery DECIMAL(5,2) = 40.0 + (ABS(CHECKSUM(NEWID())) % 600) / 10.0;
            
            INSERT INTO ReadDetails (
                Time, SerialNumber, ReadingLat, ReadingLng, Counter, Fan, Co2, Co2Val,
                ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingTempIn, ReadingTempOut,
                ReadingWindSpeed, ReadingHumidty, ReadingFly, BigBattery, SmallBattery,
                IsDone, IsClean, TrapReadId
            )
            VALUES (
                @ReadingTime,
                'SN' + CAST(@TrapId AS VARCHAR(5)) + '_' + FORMAT(@ReadDate, 'yyyyMMdd') + '_' + CAST(@RecordsGenerated AS VARCHAR(10)),
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
                1, -- IsDone
                1, -- IsClean
                @CurrentTrapReadId
            );
            
            SET @RecordsGenerated = @RecordsGenerated + 1;
            SET @DetailIndex = @DetailIndex + 1;
            
            -- Progress indicator every 500 records
            IF @RecordsGenerated % 500 = 0
            BEGIN
                PRINT 'Generated ' + CAST(@RecordsGenerated AS VARCHAR(10)) + ' of ' + CAST(@RecordsToGenerate AS VARCHAR(10)) + ' remaining records...';
            END
        END
    END
    
    PRINT 'Successfully generated ' + CAST(@RecordsGenerated AS VARCHAR(10)) + ' additional records!';
END
ELSE
BEGIN
    PRINT 'Target already reached! Current count: ' + CAST(@CurrentCount AS VARCHAR(10));
END

-- Final verification
DECLARE @FinalCount INT;
SELECT @FinalCount = COUNT(*) FROM ReadDetails;
PRINT 'Final ReadDetails count: ' + CAST(@FinalCount AS VARCHAR(10));

-- Show final statistics
SELECT 
    'FINAL TOTALS' as Category,
    COUNT(*) as ReadDetailsCount
FROM ReadDetails

UNION ALL

SELECT 
    'TrapReads Total' as Category,
    COUNT(*) as Count
FROM TrapReads;

-- Show data for last 6 months (for API testing)
SELECT 
    'Last 6 Months Data' as Category,
    COUNT(*) as RecordCount
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id
WHERE tr.Date >= DATEADD(MONTH, -6, GETDATE());

-- Monthly breakdown for API testing
SELECT 
    YEAR(tr.Date) as Year,
    MONTH(tr.Date) as Month,
    DATENAME(MONTH, tr.Date) as MonthName,
    COUNT(rd.Id) as RecordCount,
    SUM(rd.ReadingMosuqitoes) as TotalMosquitoes,
    AVG(CAST(rd.ReadingMosuqitoes AS FLOAT)) as AvgMosquitoes
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id
WHERE tr.Date >= DATEADD(MONTH, -6, GETDATE())
GROUP BY YEAR(tr.Date), MONTH(tr.Date), DATENAME(MONTH, tr.Date)
ORDER BY YEAR(tr.Date), MONTH(tr.Date);

PRINT '=== DATABASE READY FOR API TESTING ===';
PRINT 'You now have 10,000+ ReadDetails records for comprehensive testing!';
PRINT 'Test the GetCountOfMosuqitoesPer6Month endpoint at: http://localhost:5006/swagger';