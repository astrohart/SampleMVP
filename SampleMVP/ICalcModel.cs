namespace SampleMVP
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of a model object..
    /// </summary>
    /// <remarks>
    /// This model object holds the total and the running total values.
    /// <para />
    /// It also exposes a method to calculate a total given a collection of
    /// numeric values.
    /// </remarks>
    public interface ICalcModel
    {
        /// <summary>
        /// Gets or sets the current value of the running total.
        /// </summary>
        decimal RunningTotal { get; set; }

        /// <summary>
        /// Gets or sets the current total that has been calculated by the
        /// latest call to the
        /// <see
        ///     cref="M:SampleMVP.ICalcService.CalculateTotal" />
        /// method.
        /// </summary>
        decimal Total { get; set; }
    }
}