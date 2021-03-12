namespace SampleMVP
{
    public static class MakeNewCalcService
    {
        public static ICalcService FromScratch()
            => new CalcService();
    }
}