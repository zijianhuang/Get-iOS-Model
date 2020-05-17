using System;
using Xunit;
using Xamarin.iOS;

namespace BasicTests
{
	public class LookupTests
	{
		[Fact]
		public void TestDeviceInfoLookup()
		{
			var dic = DeviceInfoDic.Create();
			var iPhoneInfo = dic["iPhone1,1"];
			Assert.Equal("iPhone", iPhoneInfo.Model);
			Assert.Equal(iOSChipType.A4, iPhoneInfo.Chip);
			Assert.Equal(132, iPhoneInfo.Ppi);
		}
	}
}
