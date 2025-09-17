-- =============================================
-- Script to Generate Additional Records to Reach 10,000 Total
-- Current count: ~2,565, Need: ~7,435 more records
-- =============================================

-- Variables for data generation
DECLARE @StartDate DATE = '2024-01-01'; -- Start from January 2024 for more historical data
DECLARE @EndDate DATE = '2025-02-28';   -- Extend to February 2025
DECLARE @CurrentDate DATE = @StartDate;
DECLARE @TrapReadId INT;
DECLARE @ReadDetailId INT;
DECLARE @TargetAdditionalRecords INT = 7500; -- Generate 7,500 more to exceed 10,000
DECLARE @RecordsGenerated INT = 0;

-- Get the next available IDs to avoid conflicts
SELECT @TrapReadId = ISNULL(MAX(Id), 0) + 1 FROM TrapReads;
SELECT @ReadDetailId = ISNULL(MAX(Id), 0) + 1 FROM ReadDetails;

PRINT 'Starting TrapRead ID: ' + CAST(@TrapReadId AS VARCHAR(10));
PRINT 'Starting ReadDetail ID: ' + CAST(@ReadDetailId AS VARCHAR(10));
PRINT 'Target Additional Records: ' + CAST(@TargetAdditionalRecords AS VARCHAR(10));

-- =============================================
-- Generate Additional TrapRead and ReadDetails Data
-- =============================================
PRINT 'Generating ' + CAST(@TargetAdditionalRecords AS VARCHAR(10)) + ' additional ReadDetails records...';

WHILE @CurrentDate <= @EndDate AND @RecordsGenerated < @TargetAdditionalRecords
BEGIN
    -- Generate readings for each trap (1-20) with higher frequency
    DECLARE @TrapId INT = 1;
    
    WHILE @TrapId <= 20 AND @RecordsGenerated < @TargetAdditionalRecords
    BEGIN
        -- Generate 2-5 readings per day per trap (random)
        DECLARE @ReadingsPerDay INT = 2 + (ABS(CHECKSUM(NEWID())) % 4);
        DECLARE @ReadingCount INT = 1;
        
        WHILE @ReadingCount <= @ReadingsPerDay AND @RecordsGenerated < @TargetAdditionalRecords
        BEGIN
            -- Random time offset for the reading
            DECLARE @TimeOffset INT = ABS(CHECKSUM(NEWID())) % 1440;
            DECLARE @ReadingDateTime DATETIME2 = DATEADD(MINUTE, @TimeOffset, @CurrentDate);
            
            -- Insert TrapRead
            INSERT INTO TrapReads (Date, ServerCreationDate, TrapId)
            VALUES (CAST(@CurrentDate AS DATE), CAST(@CurrentDate AS DATE), @TrapId);
            
            DECLARE @CurrentTrapReadId INT = @TrapReadId;
            SET @TrapReadId = @TrapReadId + 1;
            
            -- Generate 8-15 ReadDetails per TrapRead to reach target faster
            DECLARE @DetailsCount INT = 8 + (ABS(CHECKSUM(NEWID())) % 8);
            DECLARE @DetailIndex INT = 1;
            
            WHILE @DetailIndex <= @DetailsCount AND @RecordsGenerated < @TargetAdditionalRecords
            BEGIN
                -- Generate realistic random values with seasonal variations
                DECLARE @SeasonMultiplier DECIMAL(3,2) = 
                    CASE 
                        WHEN MONTH(@CurrentDate) IN (6,7,8) THEN 1.5 -- Summer: more mosquitoes
                        WHEN MONTH(@CurrentDate) IN (12,1,2) THEN 0.7 -- Winter: fewer mosquitoes
                        ELSE 1.0 -- Spring/Fall: normal
                    END;
                
                DECLARE @MosquitoCount INT = CAST((ABS(CHECKSUM(NEWID())) % 150) * @SeasonMultiplier AS INT);
                DECLARE @SmallCount INT = ABS(CHECKSUM(NEWID())) % 70;
                DECLARE @LargeCount INT = ABS(CHECKSUM(NEWID())) % 40;
                DECLARE @FlyCount INT = ABS(CHECKSUM(NEWID())) % 50;
                
                -- Generate other sensor readings with realistic ranges
                DECLARE @Counter INT = ABS(CHECKSUM(NEWID())) % 3000;
                DECLARE @Fan INT = ABS(CHECKSUM(NEWID())) % 6;
                DECLARE @Co2Level INT = 300 + (ABS(CHECKSUM(NEWID())) % 700);
                DECLARE @TempIn DECIMAL(5,2) = 15.0 + (ABS(CHECKSUM(NEWID())) % 350) / 10.0;
                DECLARE @TempOut DECIMAL(5,2) = 10.0 + (ABS(CHECKSUM(NEWID())) % 450) / 10.0;
                DECLARE @WindSpeed DECIMAL(5,2) = (ABS(CHECKSUM(NEWID())) % 250) / 10.0;
                DECLARE @Humidity DECIMAL(5,2) = 20.0 + (ABS(CHECKSUM(NEWID())) % 700) / 10.0;
                DECLARE @BigBattery DECIMAL(5,2) = 40.0 + (ABS(CHECKSUM(NEWID())) % 600) / 10.0;
                DECLARE @SmallBattery DECIMAL(5,2) = 35.0 + (ABS(CHECKSUM(NEWID())) % 650) / 10.0;
                
                -- Generate GPS coordinates (Egypt region)
                DECLARE @Lat DECIMAL(10,7) = 28.5 + (ABS(CHECKSUM(NEWID())) % 4000) / 100000.0;
                DECLARE @Long DECIMAL(10,7) = 29.5 + (ABS(CHECKSUM(NEWID())) % 5000) / 100000.0;
                
                -- Generate time for the reading
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
                    CASE WHEN ABS(CHECKSUM(NEWID())) % 10 < 9 THEN 1 ELSE 0 END, -- 90% done
                    CASE WHEN ABS(CHECKSUM(NEWID())) % 10 < 8 THEN 1 ELSE 0 END, -- 80% clean
                    @CurrentTrapReadId
                );
                
                SET @ReadDetailId = @ReadDetailId + 1;
                SET @DetailIndex = @DetailIndex + 1;
                SET @RecordsGenerated = @RecordsGenerated + 1;
                
                -- Progress indicator every 500 records
                IF @RecordsGenerated % 500 = 0
                BEGIN
                    PRINT 'Generated ' + CAST(@RecordsGenerated AS VARCHAR(10)) + ' additional records...';
                END
            END
            
            SET @ReadingCount = @ReadingCount + 1;
        END
        
        SET @TrapId = @TrapId + 1;
    END
    
    SET @CurrentDate = DATEADD(DAY, 1, @CurrentDate);
END

PRINT 'Additional data generation completed. Records generated in this run: ' + CAST(@RecordsGenerated AS VARCHAR(10));

-- =============================================
-- Final Summary Statistics
-- =============================================
PRINT '=== FINAL DATA SUMMARY ===';

-- Show total counts after generation
SELECT 
    'TrapReads (Total)' as TableName,
    COUNT(*) as TotalRecords,
    MIN(Date) as EarliestDate,
    MAX(Date) as LatestDate
FROM TrapReads

UNION ALL

SELECT 
    'ReadDetails (Total)' as TableName,
    COUNT(*) as TotalRecords,
    MIN(tr.Date) as EarliestDate,
    MAX(tr.Date) as LatestDate
FROM ReadDetails rd
INNER JOIN TrapReads tr ON rd.TrapReadId = tr.Id;

-- Show mosquito statistics for the last 6 months (for API testing)
SELECT 
    YEAR(tr.Date) as Year,
    MONTH(tr.Date) as Month,
    DATENAME(MONTH, tr.Date) as MonthName,
    COUNT(rd.Id) as ReadDetailsCount,
    SUM(rd.ReadingMosuqitoes) as TotalMosquitoes,
    AVG(CAST(rd.ReadingMosuqitoes AS FLOAT)) as AvgMosquitoes
FROM TrapReads tr
INNER JOIN ReadDetails rd ON tr.Id = rd.TrapReadId
WHERE tr.Date >= DATEADD(MONTH, -6, GETDATE())
GROUP BY YEAR(tr.Date), MONTH(tr.Date), DATENAME(MONTH, tr.Date)
ORDER BY YEAR(tr.Date), MONTH(tr.Date);

PRINT 'Database now contains 10,000+ ReadDetails records for comprehensive API testing!';