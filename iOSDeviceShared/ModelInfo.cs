using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

//todo: change the namespace since this has nothing to do with Xamarin.
namespace Xamarin.iOS
{
	public class ModelInfo
	{
		public iOSChipType Chip { get; set; }
		public string Model { get; set; }
		public string SpecUrl { get; set; }
	}

	public class ModelInfoDic: Dictionary<string, ModelInfo>
	{
		public static ModelInfoDic Create(string jsonContent)
		{
			var options = new JsonSerializerOptions();
			options.Converters.Add(new JsonStringEnumConverter());
			return JsonSerializer.Deserialize<ModelInfoDic>(jsonContent, options);
		}

		public static ModelInfoDic Create()
		{
			return Create(System.IO.File.ReadAllText("ModelInfo.json"));
		}
	}

	public static class ModelInfoDicExtensions
	{
		/// <summary>
		/// According to hardwareId, return model and chip type.
		/// </summary>
		/// <param name="hardwareId"></param>
		/// <returns>DeviceInfo</returns>
		public static ModelInfo GetDeviceInfo(this ModelInfoDic dic, string hardwareId)
		{
			ModelInfo info;
			if (dic.TryGetValue(hardwareId, out info))
			{
				return info;
			}

			return dic[""];//Unknown
		}
	}
}