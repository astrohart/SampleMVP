using System;

namespace SampleMVP
{
    /// <summary>
    /// Contains unique identifiers that indicate that certain messages need to
    /// be handled by certain code.
    /// </summary>
    public static class MessageIds
    {
        /// <summary>
        /// Corresponds to the Add button being clicked.
        /// </summary>
        public static readonly Guid ADD_BUTTON_CLICKED = Guid.NewGuid();

        /// <summary>
        /// Corresponds to the Reset button being clicked.
        /// </summary>
        public static readonly Guid RESET_BUTTON_CLICKED = Guid.NewGuid();
    }
}