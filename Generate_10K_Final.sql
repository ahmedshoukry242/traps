-- =============================================
-- Final Script to Generate 10,000 ReadDetails Records
-- Uses existing Trap IDs (1-10) and proper foreign key relationships
-- =============================================

-- Clear existing data
PRINT 'Clearing existing ReadDetails and TrapReads data...';
DELETE FROM ReadDetails;
DELETE FROM TrapReads;

-- Reset identity seeds
DBCC CHECKIDENT ('ReadDetails', RESEED, 0);
DBCC CHECKIDENT ('TrapReads', RESEED, 0);

PRINT 'Starting generation of 10,000 ReadDetails records...';

-- Variables
DECLARE @TargetRecords INT = 10000;
DECLARE @RecordsGenerated INT = 0;
DECLARE @TrapReadId INT = 1;
DECLARE @BaseDate DATE = '2024-08-01';
DECLARE @CurrentDate DATE = @BaseDate;
DECLARE @DayOffset INT = 0;

-- Generate records efficiently
WHILE @RecordsGenerated < @TargetRecords
BEGIN
    -- Cycle through available trap IDs (1-10, skipping 8 which seems missing)
    DECLARE @TrapId INT = CASE 
        WHEN (@RecordsGenerated % 9) + 1 = 8 THEN 9  -- Skip trap ID 8
        ELSE (@RecordsGenerated % 9) + 1 
    END;
    
    -- Update date every 100 records to spread data across time
    IF @RecordsGenerated % 100 = 0
    BEGIN
        SET @DayOffset = @RecordsGenerated / 100;
        SET @CurrentDate = DATEADD(DAY, @DayOffset, @BaseDate);
    END
    
    -- Insert TrapRead
    INSERT INTO TrapReads (Date, ServerCreationDate, TrapId)
    VALUES (@CurrentDate, @CurrentDate, @TrapId);
    
    -- Generate 1-3 ReadDetails per TrapRead
    DECLARE @DetailsCount INT = 1 + (@RecordsGenerated % 3);
    DECLARE @DetailIndex INT = 0;
    
    WHILE @DetailIndex < @DetailsCount AND @RecordsGenerated < @TargetRecords
    BEGIN
        -- Generate realistic sensor values
        DECLARE @MosquitoCount INT = @RecordsGenerated % 150;
        DECLARE @SmallCount INT = @RecordsGenerated % 70;
        DECLARE @LargeCount INT = @RecordsGenerated % 45;
        DECLARE @FlyCount INT = @RecordsGenerated % 55;
        DECLARE @Counter INT = 1000 + (@RecordsGenerated % 2000);
        DECLARE @Fan INT = @RecordsGenerated % 6;
        DECLARE @Co2Level INT = 350 + (@RecordsGenerated % 650);
        
        -- Generate time based on record number
        DECLARE @Hour INT = @RecordsGenerated % 24;
        DECLARE @Minute INT = (@RecordsGenerated * 7) % 60;
        DECLARE @Second INT = (@RecordsGenerated * 13) % 60;
        DECLARE @ReadingTime TIME = CAST(FORMAT(@Hour, '00') + ':' + FORMAT(@Minute, '00') + ':' + FORMAT(@Second, '00') AS TIME);
        
        -- Generate GPS coordinates (Egypt region)
        DECLARE @Lat DECIMAL(10,7) = 29.0 + ((@RecordsGenerated % 3000) / 100000.0);
        DECLARE @Long DECIMAL(10,7) = 30.0 + ((@RecordsGenerated % 4000) / 100000.0);
        
        -- Generate environmental readings
        DECLARE @TempIn DECIMAL(5,2) = 18.0 + ((@RecordsGenerated % 320) / 10.0);
        DECLARE @TempOut DECIMAL(5,2) = 12.0 + ((@RecordsGenerated % 380) / 10.0);
        DECLARE @WindSpeed DECIMAL(5,2) = (@RecordsGenerated % 200) / 10.0;
        DECLARE @Humidity DECIMAL(5,2) = 25.0 + ((@RecordsGenerated % 650) / 10.0);
        DECLARE @BigBattery DECIMAL(5,2) = 45.0 + ((@RecordsGenerated % 550) / 10.0);
        DECLARE @SmallBattery DECIMAL(5,2) = 40.0 + ((@RecordsGenerated % 600) / 10.0);
        
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
            @TrapReadId
        );
        
        SET @RecordsGenerated = @RecordsGenerated + 1;
        SET @DetailIndex = @DetailIndex + 1;
        
        -- Progress indicator every 1000 records
        IF @RecordsGenerated % 1000 = 0
        BEGIN
            PRINT 'Generated ' + CAST(@RecordsGenerated AS VARCHAR(10)) + ' of ' + CAST(@TargetRecords AS VARCHAR(10)) + ' records...';
        END
    END
    
    SET @TrapReadId = @TrapReadId + 1;
END

PRINT 'Generation completed! Total records generated: ' + CAST(@RecordsGenerated AS VARCHAR(10));

-- Final verification and statistics
DECLARE @FinalCount INT;
SELECT @FinalCount = COUNT(*) FROM ReadDetails;
PRINT 'Final ReadDetails count: ' + CAST(@FinalCount AS VARCHAR(10));

-- Show summary statistics
SELECT 
    'ReadDetails Total' as TableName,
    COUNT(*) as RecordCount,
    MIN(tr.Date) as EarliestDate,
    MAX(tr.Date) as LatestDate
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id

UNION ALL

SELECT 
    'TrapReads Total' as TableName,
    COUNT(*) as RecordCount,
    MIN(Date) as EarliestDate,
    MAX(Date) as LatestDate
FROM TrapReads;

-- Show data for last 6 months (for API testing)
SELECT 
    'Last 6 Months Data' as Category,
    COUNT(*) as RecordCount,
    SUM(rd.ReadingMosuqitoes) as TotalMosquitoes,
    AVG(CAST(rd.ReadingMosuqitoes AS FLOAT)) as AvgMosquitoes
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id
WHERE tr.Date >= DATEADD(MONTH, -6, GETDATE());

-- Monthly breakdown for the last 6 months
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

-- Show trap distribution
SELECT 
    t.Id as TrapId,
    t.Name as TrapName,
    COUNT(rd.Id) as ReadDetailsCount
FROM Traps t
LEFT JOIN TrapReads tr ON t.Id = tr.TrapId
LEFT JOIN ReadDetails rd ON tr.Id = rd.TrapReadId
GROUP BY t.Id, t.Name
ORDER BY t.Id;

PRINT '=== SUCCESS! ===';
PRINT 'Database now contains ' + CAST(@FinalCount AS VARCHAR(10)) + ' ReadDetails records!';
PRINT 'Ready to test GetCountOfMosuqitoesPer6Month API endpoint at: http://localhost:5006/swagger';