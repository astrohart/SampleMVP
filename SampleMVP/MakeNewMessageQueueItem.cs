using System;

namespace SampleMVP
{
    /// <summary>
    /// Creates new message queue item objects.
    /// </summary>
    public static class MakeNewMessageQueueItem
    {
        /// <summary>
        /// Creates a new instance of a message queue item object that
        /// implements the <see cref="T:SampleMVP.IMessageQueueItem" /> interface
        /// and associates it with the specified event data <see cref="T:System.Type" />.
        /// </summary>
        /// <param name="eventDataType">
        /// (Required.) Reference to an instance of <see cref="T:System.Type" />
        /// that specifies the data type of the event data object that is
        /// associated with this event.
        /// </param>
        /// <returns>
        /// Reference to an instance of an object that implements the
        /// <see
        ///     cref="T:SampleMVP.IMessageQueueItem" />
        /// interface.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="eventDataType" />,
        /// is passed a <c>null</c> value.
        /// </exception>
        /// <remarks>
        /// After calling this method, callers must then invoke the
        /// <see
        ///     cref="M:SampleMVP.MessageQueueItem.AndHandler" />
        /// method to
        /// associate the event data type specified with the code that is to be
        /// executed when the message is posted to the queue.
        /// </remarks>
        public static IMessageQueueItem ForEventDataType(Type eventDataType)
            => new MessageQueueItem {EventDataType = eventDataType};
    }
}