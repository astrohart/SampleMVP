namespace SampleMVP
{
    /// <summary>
    /// Creates new instances of objects that implement the
    /// <see
    ///     cref="T:SampleMVP.ICalcService" />
    /// interface.
    /// </summary>
    public static class MakeNewCalcService
    {
        /// <summary>
        /// Creates a new instance of an object that implements the
        /// <see
        ///     cref="T:SampleMVP.ICalcService" />
        /// interface and returns a reference
        /// to it.
        /// </summary>
        public static ICalcService FromScratch()
            => new CalcService();
    }
}