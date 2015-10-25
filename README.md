# RangeSet
Implementation of a data structure that can map a range of values to a single value

## Synopsis

## Code Example
```csharp
using Smi.RangeSet.Lib;

// Create an collection of Range and their values
var seedCollection = new List<KeyValuePair<Range, int>>
			{
				new KeyValuePair<Range, int>(new Range(3000, 3999), 1),
				new KeyValuePair<Range, int>(new Range(4000, 4999), 2),
				new KeyValuePair<Range, int>(new Range(6000, 6999), 3)
			};
// Instantiate RangeSet
RangeSet rangeSet = new RangeSet(seedCollection);

// Lookup the value of a range
int value = rangeSet.GetValueOfItem("3256"); // returns 1

int anotherValue = rangeSet.GetValueOfItem("7000"); // returns 0 as no range exists that contains 7000
```

## Contributors

@sudhanshutheone.

## License

MIT License