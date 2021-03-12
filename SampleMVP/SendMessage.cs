using System;

namespace SampleMVP
{
    public class SendMessage<T>
    {
        private object[] _args;

        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static SendMessage() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected SendMessage() { }

        /// <summary>
        /// Gets a reference to the one and only instance of <see cref="T:SampleMVP.SendMessage"/>.
        /// </summary>
        public static SendMessage<T> Having { get; } = new SendMessage<T>();

        public SendMessage<T> Args(params object[] args)
        {
            _args = args;

            return this;
        }

        public void ForMessageId(Guid messageId)
            => MessageQueue.Instance.PostMessage<T>(messageId, _args);
    }
}