using System;

namespace SampleMVP
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of a message queue object.
    /// </summary>
    public interface IMessageQueue
    {
        /// <summary>
        /// Broadcasts a message to all subscribers everywhere in the application.
        /// </summary>
        /// <typeparam name="T">
        /// Name of the class containing the message's data.
        /// </typeparam>
        /// <param name="args">
        /// Zero or more arguments to be provided to the message handler.
        /// <para />
        /// <b>NOTE:</b> The number, order, and type of arguments provider must
        /// match the message delegate's signature precisely.
        /// </param>
        void BroadcastMessage<T>(params object[] args);

        /// <summary>
        /// Associates event data with the code to be executed when the message
        /// is posted to the queue.
        /// </summary>
        /// <typeparam name="T">
        /// Name of the type of the event data.
        /// </typeparam>
        /// <param name="messageHandler">
        /// A <see cref="T:System.Delegate" /> that specifies the code to be
        /// executed when the message is posted to the queue.
        /// </param>
        void MapMessage<T>(Delegate messageHandler);

        /// <summary>
        /// Associates event data with the code to be executed when the message
        /// is posted to the queue.
        /// </summary>
        /// <typeparam name="T">
        /// Name of the type of the event data.
        /// </typeparam>
        /// <param name="messageId">
        /// (Required.) A <see cref="T:System.Guid" /> indicating the specific
        /// application object that should process the message.
        /// </param>
        /// <param name="messageHandler">
        /// A <see cref="T:System.Delegate" /> that specifies the code to be
        /// executed when the message is posted to the queue.
        /// </param>
        void MapMessage<T>(Guid messageId, Delegate messageHandler);

        /// <summary>
        /// Posts a message to the message queue and aims it at the specific
        /// message ID indicated by the <paramref name="messageId" />. Only the
        /// objects who mapped handlers to the message with the specified message ID
        /// will be sent the message.
        /// </summary>
        /// <typeparam name="T">
        /// Name of the type of data that will be passed to the message handler.
        /// </typeparam>
        /// <param name="messageId">
        /// A <see cref="T:System.Guid" /> indicating who should receive the message.
        /// </param>
        /// <param name="args">
        /// Zero or more arguments to be provided to the message handler.
        /// <para />
        /// <b>NOTE:</b> The number, order, and type of arguments provider must
        /// match the message delegate's signature precisely.
        /// </param>
        void PostMessage<T>(Guid messageId, params object[] args);
    }
}