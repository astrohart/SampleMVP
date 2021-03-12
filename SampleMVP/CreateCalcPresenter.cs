namespace SampleMVP
{
    /// <summary>
    /// Creates instances of objects that implement the <see cref="T:SampleMVP.ICalcPresenter" /> interface.
    /// </summary>
    public static class CreateCalcPresenter
    {
        /// <summary>
        /// Creates a new instance of an object that implements the <see cref="T:SampleMVP.ICalcPresenter" /> interface and returns a reference to it.
        /// </summary>
        public static ICalcPresenter ForForm(ICalcView view)
        {
            return new CalcPresenter(view);
        }
    }
}