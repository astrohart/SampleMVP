namespace SampleMVP
{
    /// <summary>
    /// Specifies the signature of methods that handle the TotalComputed event.
    /// </summary>
    /// <param name="sender">
    /// Reference to the instance of the object that raised this event.
    /// </param>
    /// <param name="e">
    /// A <see cref="T:SampleMVP.TotalComputedEventArgs"/> that contains the event data.
    /// </param>
    public delegate void TotalComputedEventHandler(object sender, TotalComputedEventArgs e);
}