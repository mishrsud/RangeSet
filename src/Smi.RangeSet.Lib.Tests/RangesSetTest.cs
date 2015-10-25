using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Smi.RangeSet.Lib.Tests
{
	[TestClass]
	public class RangesSetTest
	{
		private static List<KeyValuePair<Range, int>> _listOfRanges;
		private static RangeSet _rangeSet;

		[ClassInitialize]
		public static void TestInit(TestContext testContext)
		{
			string json = GetTextFromEmbededFile("Smi.RangeSet.Lib.Tests.RangeMap.json");
			_listOfRanges = JsonConvert.DeserializeObject<List<KeyValuePair<Range, int>>>(json);
			_rangeSet = new RangeSet(_listOfRanges);
		}

		[TestMethod, TestCategory("Unit")]
		public void Range_ShouldNotAccept_HighLessThanLow()
		{
			Action act = () => new Range(2356, 2300);

			act.ShouldThrow<ArgumentOutOfRangeException>(
				"because we expect Range to instantiate only if lower bound is less than or equal to upper bound");
		}

		[TestMethod, TestCategory("Unit")]
		public void RangeSet_CanCorrectly_GetValueOfMappedRange()
		{
			int value = _rangeSet.GetValueOfItem("3012");

			value.Should().Be(6, "because we know we passed an element that is mapped to 6");
		}

		[TestMethod, TestCategory("Unit")]
		public void RangeSet_ReturnsZero_ForAnUnmappedRange()
		{
			int value = _rangeSet.GetValueOfItem("2356");
			value.Should().Be(0, "because we have passed an unmapped item to find");
		}

		private static string GetTextFromEmbededFile(string fileName)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = fileName;
			var result = string.Empty;

			using (var stream = assembly.GetManifestResourceStream(resourceName))
			{
				if (stream == null) return result;
				var reader = new StreamReader(stream);
				result = reader.ReadToEnd();

			}

			return result;
		}
	}
}
