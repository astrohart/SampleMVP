using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using xyLOGIX.Queues.Messages;

namespace SampleMVP
{
    /// <summary>
    /// Contains all the business logic for the
    /// <see
    ///     cref="T:SampleMVP.CalcView" />
    /// form that represents the main window.
    /// </summary>
    public class CalcPresenter : ICalcPresenter
    {
        /// <summary>
        /// Reference to an instance of an object that implements the
        /// <see
        ///     cref="T:SampleMVP.ICalcForm" />
        /// interface.
        /// </summary>
        /// <remarks>
        /// The object is supposed to represent the main window of the application.
        /// </remarks>
        private readonly ICalcView _view;

        /// <summary>
        /// Reference to an instance of an object that implements the
        /// <see
        ///     cref="T:SampleMVP.ICalcModel" />
        /// interface.
        /// </summary>
        private ICalcModel _model;

        /// <summary>
        /// Reference to an instance of an object that implements the
        /// <see
        ///     cref="T:SampleMVP.ICalcService" />
        /// interface.
        /// </summary>
        private ICalcService _service;

        public CalcPresenter(ICalcView view = null, ICalcModel model = null,
            ICalcService service = null)
        {
            _model = model;
            _service = service;
            _view = view;

            MapMessages();
        }

        /// <summary>
        /// Associates this presenter with a calculation service object.
        /// </summary>
        /// <param name="service">
        /// (Required.) Reference to an instance of an object that implements
        /// the <see cref="T:SampleMVP.ICalcService" /> interface.
        /// </param>
        /// <returns>
        /// Reference to the same instance of the object that called this
        /// method, for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="service" />, is
        /// passed a <c>null</c> value.
        /// </exception>
        public ICalcPresenter AndService(ICalcService service)
        {
            _service = service ??
                       throw new ArgumentNullException(nameof(service));

            return this;
        }

        /// <summary>
        /// Associates this presenter with a model object.
        /// </summary>
        /// <returns>
        /// Reference to the same instance of the object that called this
        /// method, for fluent use.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// Thrown if the required parameter, <paramref name="model" />, is
        /// passed a <c>null</c> value.
        /// </exception>
        public ICalcPresenter WithModel(ICalcModel model)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));

            return this;
        }

        /// <summary>
        /// Attempts to convert a string representation of a decimal number,
        /// passed in the <paramref name="value" /> parameter, into a
        /// <see
        ///     cref="T:System.Decimal" />
        /// data value.
        /// </summary>
        /// <param name="value">
        /// (Required.) String containing the string representation of a
        /// <see
        ///     cref="T:System.Decimal" />
        /// value.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Decimal" /> value corresponding to the string
        /// representation provided. Zero is returned if this method was unable
        /// to parse <paramref name="value" />.
        /// </returns>
        private static decimal SafeGetNumber(string value)
            => decimal.TryParse(value, out var result) ? result : 0;

        /// <summary>
        /// Performs the operation of adding the numbers typed into the view by
        /// the user.
        /// </summary>
        /// <remarks>
        /// When this method is called, first, the inputs made by the user are validated.
        /// <para />
        /// If validation fails, then an error message box is displayed to the
        /// user, and the input focus is set to the text box containing the
        /// first value in the series.
        /// <para />
        /// Otherwise, the operation is performed and then the view is updated
        /// with the results.
        /// </remarks>
        private void Add()
        {
            try
            {
                Validate();

                _service.CalculateTotal(
                    _model,
                    new List<string>
                    {
                        _view.FirstValue,
                        _view.SecondValue,
                        _view.ThirdValue
                    }.ConvertAll(SafeGetNumber)
                );

                _view.TotalValue = Convert.ToString(
                    _model.Total, CultureInfo.InvariantCulture
                );
                _view.RunningTotalValue = Convert.ToString(
                    _model.RunningTotal, CultureInfo.InvariantCulture
                );

                _view.TotalValueTextBox.Focus();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(
                    _view, e.Message, Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1
                );

                _view.FirstValueTextBox.Focus();
            }
        }

        /// <summary>
        /// Gets a value that tells the caller whether the string
        /// <paramref
        ///     name="value" />
        /// provided is the string representation of a
        /// <see
        ///     cref="T:System.Decimal" />
        /// primitive data value or not.
        /// </summary>
        /// <param name="value">
        /// (Required.) String containing the value to be checked. If this value
        /// is blank or <c>null</c>, then the method returns <c>false</c>.
        /// </param>
        /// <returns>
        /// If the <paramref name="value" /> parameter has a blank, whitespace,
        /// or <c>null</c> value, then this method returns <c>false</c>.
        /// <para />
        /// Otherwise, the method determines whether the string content of the
        /// <paramref name="value" /> parameter is the representation of a value
        /// that can be converted to a <see cref="T:System.Decimal" /> data value.
        /// <para />
        /// If so, then this method returns <c>true</c>; else, the method
        /// returns <c>false</c>.
        /// </returns>
        private bool CanBeConvertedToDecimal(string value)
            => !string.IsNullOrWhiteSpace(value) && decimal.TryParse(
                _view.FirstValue, out _
            );

        /// <summary>
        /// Determines whether a click of the Reset button can proceed.
        /// </summary>
        /// <returns>
        /// If the boxes to be reset are already clear, then this method returns
        /// <c>false</c>.
        /// <para />
        /// Otherwise, the method prompts the user with a Yes/No message box.
        /// <para />
        /// If the user clicks Yes, then this method returns <c>true</c>;
        /// otherwise, it returns <c>false</c>.
        /// </returns>
        private bool CanReset()
        {
            if (string.IsNullOrWhiteSpace(_view.FirstValue) &&
                string.IsNullOrWhiteSpace(_view.SecondValue) &&
                string.IsNullOrWhiteSpace(_view.ThirdValue) &&
                string.IsNullOrWhiteSpace(_view.TotalValue))
                return false; // we've already reset the boxes

            return MessageBox.Show(
                _view,
                "Are you sure you want to reset?\n\nYour current values will be lost.",
                Application.ProductName, MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2
            ) == DialogResult.Yes;
        }

        /// <summary>
        /// Sets up the mappings between messages and their handlers.
        /// </summary>
        /// <remarks>
        /// Typically, the message handlers are methods that this class defines.
        /// <para />
        /// The messages themselves are represented by
        /// <see
        ///     cref="T:System.Guid" />
        /// values defined in the
        /// <see
        ///     cref="T:SampleMVP.MessageIds" />
        /// class.
        /// <para />
        /// A sender, such as an event handler in a view, sends a message using
        /// the identifier. Then, because we have set up the mapping here, this
        /// class' methods will be called in response to the messages being sent.
        /// </remarks>
        private void MapMessages()
        {
            NewMessageMapping<EventArgs>
                .Associate.WithMessageId(CalcViewMessages.ADD_BUTTON_CLICKED)
                .AndHandler(new Action<EventArgs>(e => Add()));
            NewMessageMapping<EventArgs>
                .Associate.WithMessageId(CalcViewMessages.RESET_BUTTON_CLICKED)
                .AndHandler(new Action<EventArgs>(e => Reset()));
        }

        /// <summary>
        /// Resets the number fields of the view to blank, and sets the total
        /// field to display zero.
        /// </summary>
        /// <remarks>
        /// Before performing this operation, this method performs two checks:
        /// <para />
        /// The first check that is performed is that the view's number fields
        /// are tested for blank. If all the fields are blank, then this method
        /// does nothing.
        /// <para />
        /// This method also prompts the user if they are sure, using a yes/no
        /// message box. If the user answers yes, then the operation is performed.
        /// <para />
        /// After performing this operation, this method sets the input focus to
        /// the first numeric data-entry field on the view.
        /// </remarks>
        private void Reset()
        {
            if (!CanReset())
                return;

            _view.FirstValue = _view.SecondValue =
                _view.ThirdValue = _view.TotalValue = string.Empty;

            _view.FirstValueTextBox.Focus();
        }

        /// <summary>
        /// Ensures that the data entered by the user on the view can all be
        /// converted to <see cref="T:System.Decimal" /> values.
        /// </summary>
        /// <remarks>
        /// If the values typed by the user are all representations of
        /// <see
        ///     cref="T:System.Decimal" />
        /// numbers, then this method does nothing.
        /// <para />
        /// If any of the values are blank, or not a string representation of a
        /// <see cref="T:System.Decimal" /> value, then the method throws
        /// <see
        ///     cref="T:System.InvalidOperationException" />
        /// .
        /// </remarks>
        /// <exception cref="T:System.InvalidOperationException">
        /// Thrown if any of the values entered on the view are either blank or
        /// not representable as <see cref="T:System.Decimal" /> values.
        /// </exception>
        private void Validate()
        {
            if (!CanBeConvertedToDecimal(_view.FirstValue) ||
                !CanBeConvertedToDecimal(_view.SecondValue) ||
                !CanBeConvertedToDecimal(_view.ThirdValue))
                throw new InvalidOperationException(
                    "You can only type numbers in these boxes.\n\nThey can't be blank."
                );
        }
    }
}