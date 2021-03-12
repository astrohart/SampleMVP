using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleMVP
{
    /// <summary>
    /// Centralized storehouse for application messages.
    /// </summary>
    public class MessageQueue : IMessageQueue
    {
        /// <summary>
        /// Synchronization context object.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Internal message queue.
        /// </summary>
        private readonly IList<IMessageQueueItem> _internalMessageQueue =
            new List<IMessageQueueItem>();

        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static MessageQueue() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected MessageQueue() { }

        /// <summary>
        /// Gets a reference to the one and only instance of
        /// <see cref="T:SampleMVP.MessageQueue" />.
        /// </summary>
        public static IMessageQueue Instance { get; } = new MessageQueue();

        /// <summary>
        /// Broadcasts a message to all subscribers everywhere in the application.
        /// </summary>
        /// <typeparam name="T">
        /// Name of the class containing the message's data.
        /// </typeparam>
        /// <param name="args">
        /// Zero or more arguments to be provided to the message handler.
        /// <para />
        /// <b>NOTE:</b> The number, order, and type of arguments provided must
        /// match the message delegate's signature precisely.
        /// </param>
        public void BroadcastMessage<T>(params object[] args)
        {
            lock (SyncRoot)
            {
                if (!_internalMessageQueue.Any(item => item.DoesEventDataTypeMatch<T>()))
                    return;

                foreach (var item in _internalMessageQueue.Where(
                    item => item.DoesEventDataTypeMatch<T>()
                )) item.MessageHandler?.DynamicInvoke(args);
            }
        }

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
        /// <remarks>
        /// A message that is mapped to a handler using this method will be
        /// broadcast, i.e., any component of the application that registers a
        /// handler will automatically have its handler invoked.
        /// </remarks>
        public void MapMessage<T>(Delegate messageHandler)
        {
            if (messageHandler == null) return;

            lock (SyncRoot)
            {
                // Add the message to the message map Basically, you are telling
                // me that, when a message of type T is posted to the queue,
                // then call the code referenced by the messageHandler.
                _internalMessageQueue.Add(
                    MakeNewMessageQueueItem.ForEventDataType(typeof(T))
                                           .AndHandler(messageHandler)
                );
            }
        }

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
        public void MapMessage<T>(Guid messageId, Delegate messageHandler)
        {
            if (messageHandler == null) return;

            lock (SyncRoot)
            {
                // Add the message to the message map Basically, you are telling
                // me that, when a message of type T, with Message ID messageId
                // is posted to the queue, then execute the code referred to by the
                // messageHandler delegate.
                _internalMessageQueue.Add(
                    MakeNewMessageQueueItem.ForEventDataType(typeof(T))
                                           .AndMessageID(messageId)
                                           .AndHandler(messageHandler)
                );
            }
        }

        /// <summary>
        /// Posts a message to the message queue and aims it at the specific
        /// message ID indicated by the <paramref name="messageId" />. Only the
        /// objects who originally mapped handlers to the message with the
        /// specified message ID will be sent the message.
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
        /// <b>NOTE:</b> The number, order, and type of arguments provided must
        /// match the message delegate's signature precisely.
        /// </param>
        public void PostMessage<T>(Guid messageId, params object[] args)
        {
            /*
             * OKAY, check whether the messageId is the empty GUID. If so, then
             * this method will devolve to a call to BroadcastMessage().
             */
            if (messageId == Guid.Empty)
            {
                BroadcastMessage<T>(args);
                return;
            }

            lock (SyncRoot)
            {
                if (!_internalMessageQueue.Any(
                    item => item.IsBoundToMessageId<T>(messageId)
                )) return;

                foreach (var item in _internalMessageQueue.Where(
                    item => item.IsBoundToMessageId<T>(messageId)
                )) item.MessageHandler?.DynamicInvoke(args);
            }
        }
    }
}