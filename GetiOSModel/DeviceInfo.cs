using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Xamarin.iOS
{
	public class DeviceInfo
	{
		public iOSChipType Chip { get; set; }
		public string Model { get; set; }
		public int Ppi { get; set; }
		public string SpecUrl { get; set; }
	}

	public class DeviceInfoDic: Dictionary<string, DeviceInfo>
	{
		//public DeviceInfoDic()
		//{

		//}

		//public DeviceInfoDic(Dictionary<string, DeviceInfo> dic): base(dic)
		//{

		//}


		public static DeviceInfoDic Create(string jsonContent)
		{
			var options = new JsonSerializerOptions();
			options.Converters.Add(new JsonStringEnumConverter());
			return JsonSerializer.Deserialize<DeviceInfoDic>(jsonContent, options);
		}

		public static DeviceInfoDic Create()
		{
			return Create(System.IO.File.ReadAllText("DeviceInfo.json"));
		}
	}
}