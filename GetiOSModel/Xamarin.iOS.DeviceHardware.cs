using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace Xamarin.iOS
{
	[Preserve(AllMembers = true)]
	public static class DeviceHardware
	{
		private const string HardwareProperty = "hw.machine";

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA2101:SpecifyMarshalingForPInvokeStringArguments", MessageId = "0")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass")]
		[DllImport(Constants.SystemLibrary)]
		private static extern int sysctlbyname([MarshalAs(UnmanagedType.LPStr)] string property,
												IntPtr output,
												IntPtr oldLen,
												IntPtr newp,
												uint newlen);

		private static readonly ModelInfoDic dic = LoadModelInfoDic();

		static ModelInfoDic LoadModelInfoDic()
		{
			var bundlePath = NSBundle.MainBundle.BundlePath;
			var filename = System.IO.Path.Combine(bundlePath, "ModelInfo.json");
			try
			{
				var s = System.IO.File.ReadAllText(filename);
				return ModelInfoDic.Create(s);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				throw;
			}
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2149:TransparentMethodsMustNotCallNativeCodeFxCopRule")]
		private static string FindVersion()
		{
			try
			{
				// get the length of the string that will be returned
				var pLen = Marshal.AllocHGlobal(sizeof(int));
				sysctlbyname(HardwareProperty, IntPtr.Zero, pLen, IntPtr.Zero, 0);

				var length = Marshal.ReadInt32(pLen);

				// check to see if we got a length
				if (length == 0)
				{
					Marshal.FreeHGlobal(pLen);
					return "Unknown";
				}

				// get the hardware string
				var pStr = Marshal.AllocHGlobal(length);
				sysctlbyname(HardwareProperty, pStr, pLen, IntPtr.Zero, 0);

				// convert the native string into a C# string
				var hardwareStr = Marshal.PtrToStringAnsi(pStr);

				// cleanup
				Marshal.FreeHGlobal(pLen);
				Marshal.FreeHGlobal(pStr);

				return hardwareStr;
			}
			catch (Exception ex)
			{
				Console.WriteLine("DeviceHardware.Version Ex: " + ex.Message);
			}

			return "Unknown";
		}

		/// <summary>
		/// Version could be i386 or x86_64 when running in simulators, otherwise, device model identifier.
		/// </summary>
		public static string Version => FindVersion();

		/// <summary>
		/// iOS device model identifier
		/// </summary>
		public static string ModelIdentifier
		{
			get
			{
				var v = Version;

				if (v == "i386" || v == "x86_64")
				{
					var nsDic = NSProcessInfo.ProcessInfo.Environment["SIMULATOR_MODEL_IDENTIFIER"];
					return nsDic.ToString();
				}
				else
				{
					return v;
				}
			}
		}

		public static iOSChipType ChipType => GetChipType(Version);

		public static iOSChipType GetChipType(string modelIdentifier)
		{
			var info = dic.GetDeviceInfo(modelIdentifier);
			return info.Chip;
		}

		public static string Model => GetModel(ModelIdentifier);

		public static string GetModel(string modelIdentifier)
		{
			ModelInfo info;
			if (IsSimulator(Version))
			{
				if (dic.TryGetValue(modelIdentifier, out info))
				{
					return info.Model + " Simulator";
				}
			}

			if (dic.TryGetValue(modelIdentifier, out info))
			{
				return info.Model;
			}

			return "Unknown";
		}


		private static bool IsSimulator(string v) => v == "i386" || v == "x86_64";
	}
}