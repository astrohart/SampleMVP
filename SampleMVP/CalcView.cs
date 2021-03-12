﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SampleMVP
{
    /// <summary>
    /// Calculates the sums of values that the user types in.
    /// </summary>
    public partial class CalcView : Form, ICalcView
    {
        /// <summary>
        /// Constructs a new instance of <see cref="T:SampleMVP.CalcForm"/> and
        /// returns a reference to it.
        /// </summary>
        /// S
        public CalcView()
        {
            InitializeComponent();

            CreateCalcPresenter.ForForm(this)
                            .WithModel(
                                MakeNewCalcModel.FromScratch()
                            )
                            .AndService(
                                MakeNewCalcService.FromScratch()
                            );
        }

        /// <summary>
        /// Gets or sets the value of the First Value text box.
        /// </summary>
        public string FirstValue
        {
            get => firstValueTextBox.Text;
            set => firstValueTextBox.Text = value;
        }

        /// <summary>
        /// Gets a reference to the first <see
        /// cref="T:System.Windows.Forms.TextBox"/> having a number to be added.
        /// </summary>
        public TextBox FirstValueTextBox
        {
            [DebuggerStepThrough]
            get => firstValueTextBox;
        }

        /// <summary>
        /// Gets a reference to the <see cref="T:System.Windows.Forms.TextBox"/>
        /// that displays the running total.
        /// </summary>
        public TextBox RunningTotalTextBox
        {
            [DebuggerStepThrough]
            get => runningTotalTextBox;
        }

        /// <summary>
        /// Gets or sets the value of the Running Total text box.
        /// </summary>
        public string RunningTotalValue
        {
            get => runningTotalTextBox.Text;
            set => runningTotalTextBox.Text = value;
        }

        /// <summary>
        /// Gets or sets the value of the Second Value text box.
        /// </summary>
        public string SecondValue
        {
            get => secondValueTextBox.Text;
            set => secondValueTextBox.Text = value;
        }

        /// <summary>
        /// Gets a reference to the second <see
        /// cref="T:System.Windows.Forms.TextBox"/> having a number to be added.
        /// </summary>
        public TextBox SecondValueTextBox
        {
            [DebuggerStepThrough]
            get => secondValueTextBox;
        }

        /// <summary>
        /// Gets or sets the value of the Third Value text box.
        /// </summary>
        public string ThirdValue
        {
            get => thirdValueTextBox.Text;
            set => thirdValueTextBox.Text = value;
        }

        /// <summary>
        /// Gets a reference to the third <see
        /// cref="T:System.Windows.Forms.TextBox"/> having a number to be added.
        /// </summary>
        public TextBox ThirdValueTextBox
        {
            [DebuggerStepThrough]
            get => thirdValueTextBox;
        }

        /// <summary>
        /// Gets or sets the value of the Total Value text box.
        /// </summary>
        public string TotalValue
        {
            get => totalValueTextBox.Text;
            set => totalValueTextBox.Text = value;
        }

        /// <summary>
        /// Gets a reference to the <see cref="T:System.Windows.Forms.TextBox"/>
        /// that holds the current total.
        /// </summary>
        public TextBox TotalValueTextBox
        {
            [DebuggerStepThrough]
            get => totalValueTextBox;
        }

        /// <summary>
        /// Adds the numbers in the three text boxes together to the running total.
        /// </summary>
        /// <param name="sender">
        /// Reference to an instance of the object that raised the event.
        /// </param>
        /// <param name="e">
        /// A <see cref="T:System.EventArgs"/> that contains the event data.
        /// </param>
        private void OnClickAddButton(object sender, EventArgs e)
            => SendMessage<EventArgs>.Having.Args(e)
                                     .ForMessageId(
                                         MessageIds.ADD_BUTTON_CLICKED
                                     );

        /// <summary>
        /// Resets all the boxes, except for the running total box, to blank.
        /// </summary>
        /// <param name="sender">
        /// Reference to an instance of the object that raised the event.
        /// </param>
        /// <param name="e">
        /// A <see cref="T:System.EventArgs"/> that contains the event data.
        /// </param>
        private void OnClickResetButton(object sender, EventArgs e)
            => SendMessage<EventArgs>.Having.Args(e)
                                     .ForMessageId(
                                         MessageIds.RESET_BUTTON_CLICKED
                                     );
    }
}