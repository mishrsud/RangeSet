using System;
using System.Collections.Generic;
using System.Linq;

namespace Smi.RangeSet.Lib
{
	/// <summary>
	/// Encapsulates a collection of key value pairs where the key is a <see cref="Range"/> and the value is a single type
	/// </summary>
	public class RangeSet
	{
		private readonly List<KeyValuePair<Range, int>> _ranges;

		/// <summary>
		/// Initializes a new instance of the <see cref="RangeSet"/> class.
		/// </summary>
		/// <param name="ranges">The ranges.</param>
		public RangeSet(List<KeyValuePair<Range, int>> ranges)
		{
			this._ranges = ranges;
		}

		/// <summary> 
		/// Gets the value that is mapped to the range to which the item belongs or 0 if no range containing the item is found. 
		/// </summary>
		/// <param name="itemToFindInRange">The item to find in range.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException">itemToFindInRange;Invalid item passed in. An integer is expected.</exception>
		public int GetValueOfItem(string itemToFindInRange)
		{
			int itemToFind;
			if (!int.TryParse(itemToFindInRange, out itemToFind))
			{
				throw new ArgumentOutOfRangeException("itemToFindInRange", "Invalid item passed in. An integer is expected.");
			}

			var result = _ranges.FirstOrDefault(kvp => kvp.Key.Contains(itemToFind)).Value;
			
			return result;
		}
	}
}
