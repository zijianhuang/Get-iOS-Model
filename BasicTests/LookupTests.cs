using System;
using Xunit;
using Xamarin.iOS;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

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

			var iPadInfo = dic["iPad8,12"];
			Assert.Equal("iPad Pro 12.9-inch (4th generation Wi-Fi + Cellular)", iPadInfo.Model);
			Assert.Equal(iOSChipType.A12ZBionic, iPadInfo.Chip);
		}

		[Fact]
		public void TestDeviceInfoLookupEmpty()
		{
			var dic = DeviceInfoDic.Create();
			var iPhoneInfo = dic[""];
			Assert.Equal("Unknown", iPhoneInfo.Model);
			Assert.Equal(iOSChipType.Unknown, iPhoneInfo.Chip);

		}

		//[Fact]
		//public async Task MigrateCodeToJson()
		//{
		//	var chipTypeMap = new iOSChipTypeMap();
		//	var allIds = chipTypeMap.Keys.ToArray();
		//	var deviceInfoDictionary = allIds.ToDictionary<string, string, DeviceInfo>(id => id, (id) => new DeviceInfo()
		//	{
		//		Model = iOSHardware.GetModel(id),
		//		Chip = chipTypeMap.GetChipType(id),
		//	}
		//	);

		//	using (var stream = new FileStream("migrate.json", FileMode.Create, FileAccess.Write))
		//	{
		//		var options = new JsonSerializerOptions() { WriteIndented = true };
		//		options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
		//		await JsonSerializer.SerializeAsync<Dictionary<string, DeviceInfo>>(stream, deviceInfoDictionary, options);
		//	}
		//}
	}
}
