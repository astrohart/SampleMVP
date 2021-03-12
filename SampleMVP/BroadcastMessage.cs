namespace SampleMVP
{
    public class BroadcastMessage<T>
    {
        private object[] _args;

        /// <summary>
        /// Empty, static constructor to prohibit direct allocation of this class.
        /// </summary>
        static BroadcastMessage() { }

        /// <summary>
        /// Empty, protected constructor to prohibit direct allocation of this class.
        /// </summary>
        protected BroadcastMessage() { }

        /// <summary>
        /// Gets a reference to the one and only instance of
        /// <see cref="T:SampleMVP.BroadcastMessage" />.
        /// </summary>
        public static BroadcastMessage<T> Having { get; } =
            new BroadcastMessage<T>();

        public void Args(params object[] args)
            => MessageQueue.Instance.BroadcastMessage<T>(args);
    }
}