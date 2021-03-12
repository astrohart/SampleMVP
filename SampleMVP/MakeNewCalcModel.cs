using System;

namespace SampleMVP
{
    /// <summary>
    /// Creates instances of objects that implement the <see cref="T:SampleMVP.ICalcModel" /> interface.
    /// </summary>
    public static class MakeNewCalcModel
    {
        /// <summary>
        /// Creates a new instance of an object that implements the <see cref="T:SampleMVP.ICalcModel" /> interface and returns a reference to it.
        /// </summary>
        public static ICalcModel FromScratch()
            => new CalcModel();
    }
}