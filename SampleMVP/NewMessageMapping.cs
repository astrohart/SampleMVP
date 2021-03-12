using System;

namespace SampleMVP
{
    /// <summary>
    /// Fluent-builder objects to build message map entries.
    /// </summary>
    /// <typeparam name="T">
    /// Name of the data type that carries the event data.
    /// </typeparam>
    public class NewMessageMapping<T>
    {
        private Guid _messageId;

        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static NewMessageMapping() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected NewMessageMapping() { }

        /// <summary>
        /// Gets a reference to the one and only instance of
        /// <see cref="T:SampleMVP.MessageMappingMaker{T}" />.
        /// </summary>
        /// <typeparam name="T">
        /// Name of the type to be composed with this object.
        /// </typeparam>
        public static NewMessageMapping<T> Associate { get; } =
            new NewMessageMapping<T>();

        public void WithHandler(Delegate d)
            => d.MapToMessage<T>();

        public void AndHandler(Delegate d)
            => d.MapToMessage<T>(_messageId);

        public NewMessageMapping<T> WithMessageId(Guid messageId)
        {
            _messageId = messageId;

            return this;
        }
    }
}