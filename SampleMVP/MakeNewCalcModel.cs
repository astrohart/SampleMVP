namespace SampleMVP
{
    /// <summary>
    /// Creates instances of objects that implement the
    /// <see
    ///     cref="T:SampleMVP.ICalcModel" />
    /// interface.
    /// </summary>
    public static class MakeNewCalcModel
    {
        /// <summary>
        /// Creates a new instance of an object that implements the
        /// <see
        ///     cref="T:SampleMVP.ICalcModel" />
        /// interface and returns a reference to it.
        /// </summary>
        /// <remarks>
        /// This method and class are named the way they are so that they can be
        /// called in a fluent manner.
        /// <para />
        /// The name of the containing class and this method should always form
        /// a complete sentence when invoked.
        /// </remarks>
        public static ICalcModel FromScratch()
            => new CalcModel();
    }
}