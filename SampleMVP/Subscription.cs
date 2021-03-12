using System;

namespace SampleMVP
{
    /// <summary>
    /// Encapsulates an event subscription.
    /// </summary>
    public class Subscription : IDisposable
    {
        /// <summary>
        /// A <see cref="T:System.Action" /> that specifies how to remove this
        /// subscription from the event aggregator.
        /// </summary>
        private readonly Action _removeMethod;

        /// <summary>
        /// Constructs a new instance of <see cref="T:SampleMVP.Subscription" />
        /// and returns a reference to it.
        /// </summary>
        /// <param name="removeMethod">
        /// (Required.) Reference to an instance of
        /// <see
        ///     cref="T:System.Action" />
        /// that describes the method to be called to
        /// remove the subscription from the event aggregator.
        /// </param>
        public Subscription(Action removeMethod)
            => _removeMethod = removeMethod;

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
            => _removeMethod?.Invoke();
    }
}