namespace SampleMVP
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of a Presenter
    /// object for the main window.
    /// </summary>
    public interface ICalcPresenter
    {
        /// <summary>
        /// Associates this presenter with a calculation service object.
        /// </summary>
        /// <param name="service">
        /// (Required.) Reference to an instance of an object that implements
        /// the <see cref="T:SampleMVP.ICalcService"/> interface.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this
        /// method, for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="service"/>, is
        /// passed a <c>null</c> value.
        /// </exception>
        ICalcPresenter AndService(ICalcService service);

        /// <summary>
        /// Associates this presenter with a model object.
        /// </summary>
        /// <returns>
        /// Reference to the same instance of the object that called this
        /// method, for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="model"/>, is
        /// passed a <c>null</c> value.
        /// </exception>
        ICalcPresenter WithModel(ICalcModel model);
    }
}