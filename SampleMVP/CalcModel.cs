namespace SampleMVP
{
    /// <summary>
    /// POCO that contains the results of calculations.
    /// </summary>
    public class CalcModel : ICalcModel
    {
        /// <summary>
        /// Gets or sets the current value of the running total.
        /// </summary>
        public decimal RunningTotal { get; set; } = decimal.Zero;

        /// <summary>
        /// Gets or sets the current total that has been calculated by the
        /// latest call to the
        /// <see
        ///     cref="M:SampleMVP.ICalcService.CalculateTotal" />
        /// method.
        /// </summary>
        public decimal Total { get; set; } = decimal.Zero;
    }
}