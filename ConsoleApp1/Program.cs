using System;

[Serializable]
class PaymentBill
{
    public double DailyRate;
    public int Days;
    public double PenaltyPerDay;
    public int PenaltyDays;
    private static bool includeCalculatedFields = true;

    public PaymentBill(double dailyRate, int days, double penaltyPerDay, int penaltyDays)
    {
        DailyRate = dailyRate;
        Days = days;
        PenaltyPerDay = penaltyPerDay;
        PenaltyDays = penaltyDays;
    }

    public double BaseAmount
    {
        get { return DailyRate * Days; }
    }

    public double PenaltyAmount
    {
        get { return PenaltyPerDay * PenaltyDays; }
    }

    public double TotalAmount
    {
        get { return BaseAmount + PenaltyAmount; }
    }

    public static bool IncludeCalculatedFields
    {
        get { return includeCalculatedFields; }
        set { includeCalculatedFields = value; }
    }

    [NonSerialized]
    private double baseAmountField;
    [NonSerialized]
    private double penaltyAmountField;
    [NonSerialized]
    private double totalAmountField;

    private void OnSerializing()
    {
        if (includeCalculatedFields)
        {
            baseAmountField = BaseAmount;
            penaltyAmountField = PenaltyAmount;
            totalAmountField = TotalAmount;
        }
    }

    private void OnDeserialized()
    {
        if (includeCalculatedFields)
        {
            baseAmountField = 0;
            penaltyAmountField = 0;
            totalAmountField = 0;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
    }
}