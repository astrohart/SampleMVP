using System;

namespace SampleMVP
{
    /// <summary>
    /// Represents a single item in a message queue.
    /// </summary>
    public class MessageQueueItem : IMessageQueueItem
    {
        /// <summary>
        /// Gets or sets the <see cref="T:System.Type" /> of the event data.
        /// </summary>
        public Type EventDataType { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Delegate" /> that specifies what
        /// code is to be run when a message is sent.
        /// </summary>
        public Delegate MessageHandler { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the message ID of this
        /// specific message queue item.
        /// </summary>
        /// <remarks>
        /// If this property is set to the zero GUID, then the message is broadcast.
        /// </remarks>
        public Guid MessageId { get; set; } = Guid.Empty;

        /// <summary>
        /// Fluent-builder method to associate this message queue item with code
        /// to be executed when the message is published.
        /// </summary>
        /// <returns>
        /// Reference to the same instance of the object that called this
        /// method, for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="messageHandler" />,
        /// is passed a <c>null</c> value.
        /// </exception>
        public IMessageQueueItem AndHandler(Delegate messageHandler)
        {
            MessageHandler = messageHandler ??
                             throw new ArgumentNullException(
                                 nameof(messageHandler)
                             );

            return this;
        }

        /// <summary>
        /// Fluent-builder method to mark this message queue item for processing
        /// only by those objects who map handlers to a specific message ID.
        /// </summary>
        /// <param name="messageId">
        /// (Required.) A <see cref="T:System.Guid" /> indicating who should
        /// process this message.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this
        /// method, for fluent use.
        /// </returns>
        /// <remarks>
        /// Calling this method is optional. The Zero GUID will be associated
        /// with this message queue item if this method is not called.
        /// <para />
        /// Associating a message with the Zero GUID means that the message in
        /// question should be dispatched to all interested parties.
        /// </remarks>
        public IMessageQueueItem AndMessageID(Guid messageId)
        {
            MessageId = messageId;

            return this;
        }
    }
}