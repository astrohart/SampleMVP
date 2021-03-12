using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleMVP
{
    /// <summary>
    /// Calculates the total of values.
    /// </summary>
    public class CalcService : ICalcService
    {
        /// <summary>
        /// Occurs when the total of a collection of decimal values has been computed.
        /// </summary>
        public event TotalComputedEventHandler TotalComputed;

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
        ///     name="numbers" />
        /// or <paramref name="model" /> are passed a
        /// <c>null</c> value.
        /// </exception>
        /// <remarks>
        /// This method does nothing if the <paramref name="numbers" />
        /// collection contains zero elements.
        /// </remarks>
        public void CalculateTotal(ICalcModel model, IList<decimal> numbers)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (numbers.Count == 0)
                return;

            model.Total = numbers.Sum();
            model.RunningTotal += model.Total;

            OnTotalComputed(new TotalComputedEventArgs(numbers, model.Total));
        }

        /// <summary>
        /// Raises the <see cref="E:SampleMVP.ICalcService.TotalComputed" /> event.
        /// </summary>
        /// <param name="e">
        /// A <see cref="T:SampleMVP.TotalComputedEventArgs" /> that contains the
        /// event data.
        /// </param>
        protected virtual void OnTotalComputed(TotalComputedEventArgs e)
            => BroadcastMessage<TotalComputedEventArgs>.Having.Args(this, e);
    }
}