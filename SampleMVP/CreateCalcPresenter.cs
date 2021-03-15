namespace SampleMVP
{
    /// <summary>
    /// Creates instances of objects that implement the
    /// <see
    ///     cref="T:SampleMVP.ICalcPresenter" />
    /// interface.
    /// </summary>
    /// <remarks>
    /// This class is a simple, fluent, factory. The name of the class is chosen
    /// so as to form complete sentences with the names of its methods.
    /// </remarks>
    public static class CreateCalcPresenter
    {
        /// <summary>
        /// Creates a new instance of an object that implements the
        /// <see
        ///     cref="T:SampleMVP.ICalcPresenter" />
        /// interface and returns a
        /// reference to it.
        /// </summary>
        public static ICalcPresenter ForView(ICalcView view)
            => new CalcPresenter(view);
    }
}