using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

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

        private void MapMessages()
        {
            NewMessageMapping<EventArgs>
                .Associate.WithMessageId(MessageIds.ADD_BUTTON_CLICKED)
                .AndHandler(new Action<EventArgs>(e => Add()));
            NewMessageMapping<EventArgs>
                .Associate.WithMessageId(MessageIds.RESET_BUTTON_CLICKED)
                .AndHandler(new Action<EventArgs>(e => Reset()));
        }

        private void Reset()
        {
            if (!CanReset())
                return;

            _view.FirstValue = _view.SecondValue =
                _view.ThirdValue = _view.TotalValue = string.Empty;

            _view.FirstValueTextBox.Focus();
        }

        private decimal SafeGetNumber(string value)
            => decimal.TryParse(value, out var result) ? result : 0;

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