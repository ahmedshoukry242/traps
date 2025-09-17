-- Script to update ReadDetails data to be compatible with int types
-- This script converts string values to integers, handling non-numeric values

-- First, let's see what data we have
SELECT TOP 10 ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingFly 
FROM ReadDetails;

-- Convert ReadingSmall: Extract numeric part or set to 0
UPDATE ReadDetails 
SET ReadingSmall = CASE 
    WHEN ReadingSmall LIKE 'Small_%' THEN 
        CASE 
            WHEN ISNUMERIC(SUBSTRING(ReadingSmall, 7, LEN(ReadingSmall))) = 1 
            THEN CAST(SUBSTRING(ReadingSmall, 7, LEN(ReadingSmall)) AS INT)
            ELSE 0 
        END
    WHEN ISNUMERIC(ReadingSmall) = 1 THEN CAST(ReadingSmall AS INT)
    ELSE 0
END;

-- Convert ReadingLarg: Extract numeric part or set to 0  
UPDATE ReadDetails 
SET ReadingLarg = CASE 
    WHEN ReadingLarg LIKE 'Large_%' THEN 
        CASE 
            WHEN ISNUMERIC(SUBSTRING(ReadingLarg, 7, LEN(ReadingLarg))) = 1 
            THEN CAST(SUBSTRING(ReadingLarg, 7, LEN(ReadingLarg)) AS INT)
            ELSE 0 
        END
    WHEN ISNUMERIC(ReadingLarg) = 1 THEN CAST(ReadingLarg AS INT)
    ELSE 0
END;

-- Convert ReadingMosuqitoes: Extract numeric part or set to 0
UPDATE ReadDetails 
SET ReadingMosuqitoes = CASE 
    WHEN ReadingMosuqitoes LIKE 'Mosquito_%' THEN 
        CASE 
            WHEN ISNUMERIC(SUBSTRING(ReadingMosuqitoes, 10, LEN(ReadingMosuqitoes))) = 1 
            THEN CAST(SUBSTRING(ReadingMosuqitoes, 10, LEN(ReadingMosuqitoes)) AS INT)
            ELSE 0 
        END
    WHEN ISNUMERIC(ReadingMosuqitoes) = 1 THEN CAST(ReadingMosuqitoes AS INT)
    ELSE 0
END;

-- Convert ReadingFly: Extract numeric part or set to 0
UPDATE ReadDetails 
SET ReadingFly = CASE 
    WHEN ReadingFly LIKE 'Fly_%' THEN 
        CASE 
            WHEN ISNUMERIC(SUBSTRING(ReadingFly, 5, LEN(ReadingFly))) = 1 
            THEN CAST(SUBSTRING(ReadingFly, 5, LEN(ReadingFly)) AS INT)
            ELSE 0 
        END
    WHEN ISNUMERIC(ReadingFly) = 1 THEN CAST(ReadingFly AS INT)
    ELSE 0
END;

-- Verify the changes
SELECT TOP 10 ReadingSmall, ReadingLarg, ReadingMosuqitoes, ReadingFly 
FROM ReadDetails;

