using System;

namespace SampleMVP
{
    public static class DelegateExtensions
    {
        public static void MapToMessage<T>(this Delegate d)
            => MessageQueue.Instance.MapMessage<T>(d);

        public static void MapToMessage<T>(this Delegate d, Guid messageId)
            => MessageQueue.Instance.MapMessage<T>(messageId, d);
    }
}