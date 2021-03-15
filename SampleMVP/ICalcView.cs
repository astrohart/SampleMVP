using System.Diagnostics;
using System.Windows.Forms;

namespace SampleMVP
{
    /// <summary>
    /// Defines the publicly-exposed methods and properties of the main window
    /// of the application.
    /// </summary>
    public interface ICalcView : IWin32Window
    {
        /// <summary>
        /// Gets or sets the value of the First Value text box.
        /// </summary>
        string FirstValue { get; set; }

        /// <summary>
        /// Gets a reference to the first <see
        /// cref="T:System.Windows.Forms.TextBox"/> having a number to be added.
        /// </summary>
        TextBox FirstValueTextBox { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets a reference to the <see cref="T:System.Windows.Forms.TextBox"/>
        /// that displays the running total.
        /// </summary>
        TextBox RunningTotalTextBox { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets or sets the value of the Running Total text box.
        /// </summary>
        string RunningTotalValue { get; set; }

        /// <summary>
        /// Gets or sets the value of the Second Value text box.
        /// </summary>
        string SecondValue { get; set; }

        /// <summary>
        /// Gets a reference to the second <see
        /// cref="T:System.Windows.Forms.TextBox"/> having a number to be added.
        /// </summary>
        TextBox SecondValueTextBox { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets or sets the value of the Third Value text box.
        /// </summary>
        string ThirdValue { get; set; }

        /// <summary>
        /// Gets a reference to the third <see
        /// cref="T:System.Windows.Forms.TextBox"/> having a number to be added.
        /// </summary>
        TextBox ThirdValueTextBox { [DebuggerStepThrough] get; }

        /// <summary>
        /// Gets or sets the value of the Total Value text box.
        /// </summary>
        string TotalValue { get; set; }

        /// <summary>
        /// Gets a reference to the <see cref="T:System.Windows.Forms.TextBox"/>
        /// that holds the current total.
        /// </summary>
        TextBox TotalValueTextBox { [DebuggerStepThrough] get; }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">
        /// The form was closed while a handle was being created.
        /// </exception>
        /// <exception cref="T:System.ObjectDisposedException">
        /// You cannot call this method from the <see
        /// cref="E:System.Windows.Forms.Form.Activated"/> event when <see
        /// cref="P:System.Windows.Forms.Form.WindowState"/> is set to <see cref="F:System.Windows.Forms.FormWindowState.Maximized"/>.
        /// </exception>
        void Close();

        /// <summary>
        /// Shows the form with the specified owner to the user.
        /// </summary>
        /// <param name="owner">
        /// Any object that implements <see
        /// cref="T:System.Windows.Forms.IWin32Window"/> and represents the
        /// top-level window that will own this form.
        /// </param>
        /// <exception cref="T:System.InvalidOperationException">
        /// The form being shown is already visible.
        /// -or- The form specified in the <paramref name="owner"/> parameter is
        /// the same as the form being shown.
        /// -or- The form being shown is disabled.
        /// -or- The form being shown is not a top-level window.
        /// -or- The form being shown as a dialog box is already a modal form.
        /// -or- The current process is not running in user interactive mode
        /// (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive"/>).
        /// </exception>
        void Show(IWin32Window owner);
    }
}