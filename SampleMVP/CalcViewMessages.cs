using System;

namespace SampleMVP
{
    /// <summary>
    /// Contains unique identifiers that indicate that certain messages need to
    /// be handled by certain code.
    /// </summary>
    /// <remarks>
    /// The members of this particular class are identifiers that should be used
    /// for messages dispatched by the main application window.
    /// <para />
    /// Classes such as this always belong in the application-specific layer of code.
    /// <para />
    /// We never would want to place constants such those which are members of
    /// this class into a library.
    /// </remarks>
    public static class CalcViewMessages
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