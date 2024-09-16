namespace Core.User.Crud.Domain.Utils;

public class DateTimeUtils
{
    public static int YearsBetween(DateTime startDate, DateTime endDate)
    {
        int age = endDate.Year - startDate.Year;
        if (startDate > endDate.AddYears(-age)) age--;
        return age;
    }
}