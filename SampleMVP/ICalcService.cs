using System.Collections.Generic;

namespace SampleMVP
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of a Service object
    /// that calculates values.
    /// </summary>
    /// <remarks>
    /// Service objects, in this case, that implement the
    /// <see
    ///     cref="T:SampleMVP.ICalcService" />
    /// interface.
    /// <para />
    /// The only concern of such objects is that they receive a reference to
    /// some other object that implements the
    /// <see
    ///     cref="T:SampleMVP.ICalcModel" />
    /// interface, and a list of numeric values
    /// (represented here by a collection of <see cref="T:System.Decimal" />
    /// values) whose total is to be calculated.
    /// <para />
    /// The task of this object is to perform the calculation, and then store
    /// the results of the calculation in the properties of the model.
    /// </remarks>
    public interface ICalcService
    {
        /// <summary>
        /// Occurs when the total of a collection of decimal values has been computed.
        /// </summary>
        event TotalComputedEventHandler TotalComputed;

        /// <summary>
        /// Given a collection of values, sums them, and sets the
        /// <see
        ///     cref="P:SampleMVP.ICalcModel.Total" />
        /// and
        /// <see
        ///     cref="P:SampleMVP.ICalcModel.RunningTotal" />
        /// properties accordingly.
        /// </summary>
        /// <param name="model">
        /// (Required.) Reference to an instance of an object that implements
        /// the <see cref="T:SampleMVP.ICalcModel" /> interface.
        /// </param>
        /// <param name="numbers">
        /// (Required.) Reference to an instance of a collection of values that
        /// are to be summed.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if either of the required parameters,
        /// <paramref
        ///     name="model" />
        /// or <paramref name="numbers" />, are passed a
        /// <c>null</c> value.
        /// </exception>
        /// <remarks>
        /// This method does nothing if the <paramref name="numbers" />
        /// collection contains zero elements.
        /// </remarks>
        void CalculateTotal(ICalcModel model, IList<decimal> numbers);
    }
}