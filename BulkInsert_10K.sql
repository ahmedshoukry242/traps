-- =============================================
-- Bulk Insert Script to Generate Exactly 10,000 ReadDetails Records
-- This script will clear existing data and create exactly 10,000 records
-- =============================================

-- Clear existing data to start fresh
PRINT 'Clearing existing data...';
DELETE FROM ReadDetails;
DELETE FROM TrapReads;

-- Reset identity seeds
DBCC CHECKIDENT ('ReadDetails', RESEED, 0);
DBCC CHECKIDENT ('TrapReads', RESEED, 0);

PRINT 'Starting bulk generation of 10,000 ReadDetails records...';

-- Variables
DECLARE @RecordsToGenerate INT = 10000;
DECLARE @BatchSize INT = 100;
DECLARE @CurrentBatch INT = 0;
DECLARE @TotalBatches INT = @RecordsToGenerate / @BatchSize;

-- Base date for data generation
DECLARE @BaseDate DATE = '2024-08-01';

PRINT 'Total batches to process: ' + CAST(@TotalBatches AS VARCHAR(10));

-- Generate data in batches for better performance
WHILE @CurrentBatch < @TotalBatches
BEGIN
    DECLARE @BatchStart INT = @CurrentBatch * @BatchSize + 1;
    DECLARE @BatchEnd INT = (@CurrentBatch + 1) * @BatchSize;
    
    -- Insert TrapReads for this batch
    WITH NumberSequence AS (
        SELECT @BatchStart as n
        UNION ALL
        SELECT n + 1
        FROM NumberSequence
        WHERE n < @BatchEnd
    )
    INSERT INTO TrapReads (Date, ServerCreationDate, TrapId)
    SELECT 
        DATEADD(DAY, (n-1) / 50, @BaseDate) as Date,
        DATEADD(DAY, (n-1) / 50, @BaseDate) as ServerCreationDate,
        1 + ((n-1) % 15) as TrapId
    FROM NumberSequence
    OPTION (MAXRECURSION 0);
    
    -- Insert ReadDetails for this batch
    WITH NumberSequence AS (
        SELECT @BatchStart as n
        UNION ALL
        SELECT n + 1
        FROM NumberSequence
        WHERE n < @BatchEnd
    )
    INSERT INTO ReadDetails (
        Time, SerialNumber, ReadingLat, ReadingLng, Counter, Fan, Co2, Co2Val,
        ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingTempIn, ReadingTempOut,
        ReadingWindSpeed, ReadingHumidty, ReadingFly, BigBattery, SmallBattery,
        IsDone, IsClean, TrapReadId
    )
    SELECT 
        CAST(FORMAT((n % 24), '00') + ':' + FORMAT((n % 60), '00') + ':00' AS TIME) as Time,
        'SN_' + CAST(1 + ((n-1) % 15) AS VARCHAR(5)) + '_' + CAST(n AS VARCHAR(10)) as SerialNumber,
        CAST(29.0 + ((n % 3000) / 1000.0) AS VARCHAR(20)) as ReadingLat,
        CAST(30.0 + ((n % 4000) / 1000.0) AS VARCHAR(20)) as ReadingLng,
        1000 + (n % 2000) as Counter,
        n % 6 as Fan,
        300 + (n % 700) as Co2,
        CAST(300 + (n % 700) AS VARCHAR(10)) as Co2Val,
        n % 80 as ReadingSmall,
        n % 50 as ReadingLarg,
        n % 200 as ReadingMosuqitoes,
        CAST(15.0 + ((n % 350) / 10.0) AS VARCHAR(10)) as ReadingTempIn,
        CAST(10.0 + ((n % 450) / 10.0) AS VARCHAR(10)) as ReadingTempOut,
        CAST((n % 250) / 10.0 AS VARCHAR(10)) as ReadingWindSpeed,
        CAST(20.0 + ((n % 700) / 10.0) AS VARCHAR(10)) as ReadingHumidty,
        n % 60 as ReadingFly,
        CAST(40.0 + ((n % 600) / 10.0) AS VARCHAR(10)) as BigBattery,
        CAST(35.0 + ((n % 650) / 10.0) AS VARCHAR(10)) as SmallBattery,
        1 as IsDone,
        1 as IsClean,
        @BatchStart + (n - @BatchStart) as TrapReadId
    FROM NumberSequence
    OPTION (MAXRECURSION 0);
    
    SET @CurrentBatch = @CurrentBatch + 1;
    
    -- Progress indicator
    IF @CurrentBatch % 10 = 0
    BEGIN
        PRINT 'Completed batch ' + CAST(@CurrentBatch AS VARCHAR(10)) + ' of ' + CAST(@TotalBatches AS VARCHAR(10)) + ' (' + CAST(@CurrentBatch * @BatchSize AS VARCHAR(10)) + ' records)';
    END
END

PRINT 'Bulk insert completed!';

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

PRINT '=== SUCCESS! ===';
PRINT 'Database now contains exactly ' + CAST(@FinalCount AS VARCHAR(10)) + ' ReadDetails records!';
PRINT 'Ready to test GetCountOfMosuqitoesPer6Month API endpoint at: http://localhost:5006/swagger';