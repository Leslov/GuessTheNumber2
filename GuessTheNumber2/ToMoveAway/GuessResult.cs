using System;

namespace FrontWpf
{
	public class GuessResult
	{
		public GuessResult(ushort fullNumber, byte nonExactCount, byte exactCount)
		{
			#region Validation
			if (nonExactCount > 4)
				throw new Exception("NonExact count shouldn't be more than 4");
			if (exactCount > 4)
				throw new Exception("Exact count shouldn't be more than 4");
			if (exactCount > nonExactCount)
				throw new Exception("Exact count shouldn't be more than NonExact count");
			#endregion
			FullNumber = fullNumber;
			NonExactCount = nonExactCount;
			ExactCount = exactCount;
		}
		public ushort FullNumber { get; }
		public byte NonExactCount { get; }
		public byte ExactCount { get; }

		public override string ToString() => $"{FullNumber}: {NonExactCount}-{ExactCount}";
	}
}
