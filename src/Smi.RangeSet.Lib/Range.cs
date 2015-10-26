using System;

namespace Smi.RangeSet.Lib
{
	/// <summary> Encapsulates an item that has a lower bound and an upper bound </summary>
	public class Range
	{
		private readonly int _low;
		private readonly int _high;

		/// <summary> Gets the lower bound of the item. </summary>
		public int Low
		{
			get
			{
				return this._low;
			}
		}

		/// <summary> Gets the upper bound of the item. </summary>
		public int High
		{
			get
			{
				return this._high;
			}
		}

		/// <summary> 
		/// Initializes a new instance of the <see cref="Range" /> class.
		/// </summary>
		/// <param name="low">The lower bound.</param>
		/// <param name="high">The upper bound.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">high;the upper bound of range should be greater than or equal to the lower bound</exception>
		public Range(int low, int high)
		{
			if (high < low) throw new ArgumentOutOfRangeException("high", "the upper bound of range should be greater than or equal to the lower bound");
			this._low = low;
			this._high = high;
		}

		/// <summary> Determines whether this instance of range contains the specified element. </summary>
		/// <param name="element">The element.</param>
		/// <returns>true if the element is contained in the Range, otherwise false. </returns>
		public bool Contains(int element)
		{
			return element >= this.Low && element <= this.High;
		}
	}
}
