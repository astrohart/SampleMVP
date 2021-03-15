using System;
using System.Collections.Generic;

namespace SampleMVP
{
    /// <summary>
    /// Contains data for a TotalComputed event.
    /// </summary>
    public class TotalComputedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new instance of
        /// <see
        ///     cref="T:SampleMVP.TotalComputedEventArgs" />
        /// and returns a reference
        /// to it.
        /// </summary>
        /// <param name="sourceValues">
        /// (Required.) Reference to an instance of a collection of
        /// <see
        ///     cref="T:System.Decimal" />
        /// values that have been summed to obtain a total.
        /// </param>
        /// <param name="total">
        /// (Required.) A <see cref="T:System.Decimal" /> that represents the sum
        /// of the values in <paramref name="sourceValues" />.
        /// </param>
        public TotalComputedEventArgs(IList<decimal> sourceValues,
            decimal total)
        {
            SourceValues = sourceValues;
            Total = total;
        }

        /// <summary>
        /// Gets the collection of <see cref="T:System.Decimal" /> values that
        /// has been most recently summed.
        /// </summary>
        public IList<decimal> SourceValues { get; }

        /// <summary>
        /// Gets the sum of the values in the
        /// <see
        ///     cref="P:SampleMVP.TotalComputedEventArgs.SourceValues" />
        /// property's collection.
        /// </summary>
        public decimal Total { get; }
    }
}