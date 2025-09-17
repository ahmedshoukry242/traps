namespace Core.DTOs.Trap.Statistic
{
    public class MonthlyMosquitoCountPer6MonthDto
    {
        public int DateInNumber { get; set; }
        public string DateOfMonth { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public int InsectsCount { get; set; }
    }
}