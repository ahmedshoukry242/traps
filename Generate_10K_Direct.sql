-- =============================================
-- Direct Script to Generate Exactly 10,000 ReadDetails Records
-- =============================================

-- Clear existing data first (optional - comment out if you want to keep existing data)
-- DELETE FROM ReadDetails;
-- DELETE FROM TrapReads;

DECLARE @RecordsToGenerate INT = 10000;
DECLARE @RecordsGenerated INT = 0;
DECLARE @TrapReadId INT;
DECLARE @ReadDetailId INT;
DECLARE @CurrentDate DATE = '2024-08-01'; -- Start from August 2024

-- Get starting IDs
SELECT @TrapReadId = ISNULL(MAX(Id), 0) + 1 FROM TrapReads;
SELECT @ReadDetailId = ISNULL(MAX(Id), 0) + 1 FROM ReadDetails;

PRINT 'Starting generation of ' + CAST(@RecordsToGenerate AS VARCHAR(10)) + ' ReadDetails records...';
PRINT 'Starting TrapRead ID: ' + CAST(@TrapReadId AS VARCHAR(10));
PRINT 'Starting ReadDetail ID: ' + CAST(@ReadDetailId AS VARCHAR(10));

-- Generate records in batches
WHILE @RecordsGenerated < @RecordsToGenerate
BEGIN
    -- Create a TrapRead first
    DECLARE @TrapId INT = 1 + (@RecordsGenerated % 15); -- Cycle through trap IDs 1-15
    DECLARE @DaysOffset INT = @RecordsGenerated / 50; -- Spread across multiple days
    DECLARE @ReadDate DATE = DATEADD(DAY, @DaysOffset, @CurrentDate);
    
    INSERT INTO TrapReads (Date, ServerCreationDate, TrapId)
    VALUES (@ReadDate, @ReadDate, @TrapId);
    
    DECLARE @CurrentTrapReadId INT = @TrapReadId;
    SET @TrapReadId = @TrapReadId + 1;
    
    -- Generate ReadDetails for this TrapRead
    DECLARE @DetailsForThisTrap INT = 1 + (@RecordsGenerated % 5); -- 1-5 details per trap read
    DECLARE @DetailCount INT = 0;
    
    WHILE @DetailCount < @DetailsForThisTrap AND @RecordsGenerated < @RecordsToGenerate
    BEGIN
        -- Generate random values
        DECLARE @MosquitoCount INT = ABS(CHECKSUM(NEWID())) % 200;
        DECLARE @SmallCount INT = ABS(CHECKSUM(NEWID())) % 80;
        DECLARE @LargeCount INT = ABS(CHECKSUM(NEWID())) % 50;
        DECLARE @FlyCount INT = ABS(CHECKSUM(NEWID())) % 60;
        DECLARE @Counter INT = ABS(CHECKSUM(NEWID())) % 2000;
        DECLARE @Fan INT = ABS(CHECKSUM(NEWID())) % 5;
        DECLARE @Co2Level INT = 300 + (ABS(CHECKSUM(NEWID())) % 700);
        
        -- Generate time
        DECLARE @Hour INT = ABS(CHECKSUM(NEWID())) % 24;
        DECLARE @Minute INT = ABS(CHECKSUM(NEWID())) % 60;
        DECLARE @Second INT = ABS(CHECKSUM(NEWID())) % 60;
        DECLARE @ReadingTime TIME = CAST(FORMAT(@Hour, '00') + ':' + FORMAT(@Minute, '00') + ':' + FORMAT(@Second, '00') AS TIME);
        
        -- Generate GPS coordinates
        DECLARE @Lat DECIMAL(10,7) = 29.0 + (ABS(CHECKSUM(NEWID())) % 3000) / 100000.0;
        DECLARE @Long DECIMAL(10,7) = 30.0 + (ABS(CHECKSUM(NEWID())) % 4000) / 100000.0;
        
        -- Generate other sensor values
        DECLARE @TempIn DECIMAL(5,2) = 15.0 + (ABS(CHECKSUM(NEWID())) % 350) / 10.0;
        DECLARE @TempOut DECIMAL(5,2) = 10.0 + (ABS(CHECKSUM(NEWID())) % 450) / 10.0;
        DECLARE @WindSpeed DECIMAL(5,2) = (ABS(CHECKSUM(NEWID())) % 250) / 10.0;
        DECLARE @Humidity DECIMAL(5,2) = 20.0 + (ABS(CHECKSUM(NEWID())) % 700) / 10.0;
        DECLARE @BigBattery DECIMAL(5,2) = 40.0 + (ABS(CHECKSUM(NEWID())) % 600) / 10.0;
        DECLARE @SmallBattery DECIMAL(5,2) = 35.0 + (ABS(CHECKSUM(NEWID())) % 650) / 10.0;
        
        INSERT INTO ReadDetails (
            Time, SerialNumber, ReadingLat, ReadingLng, Counter, Fan, Co2, Co2Val,
            ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingTempIn, ReadingTempOut,
            ReadingWindSpeed, ReadingHumidty, ReadingFly, BigBattery, SmallBattery,
            IsDone, IsClean, TrapReadId
        )
        VALUES (
            @ReadingTime,
            'SN' + CAST(@TrapId AS VARCHAR(5)) + '_' + CAST(@RecordsGenerated AS VARCHAR(10)),
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
        SET @DetailCount = @DetailCount + 1;
        
        -- Progress indicator
        IF @RecordsGenerated % 1000 = 0
        BEGIN
            PRINT 'Generated ' + CAST(@RecordsGenerated AS VARCHAR(10)) + ' records...';
        END
    END
END

PRINT 'Generation completed! Total ReadDetails records generated: ' + CAST(@RecordsGenerated AS VARCHAR(10));

-- Final verification
SELECT 
    'Final Count' as Status,
    COUNT(*) as TotalReadDetails
FROM ReadDetails;

SELECT 
    'Last 6 Months Count' as Status,
    COUNT(*) as ReadDetailsLast6Months
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id
WHERE tr.Date >= DATEADD(MONTH, -6, GETDATE());

-- Show monthly breakdown for last 6 months
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

PRINT 'Ready to test GetCountOfMosuqitoesPer6Month API endpoint!';