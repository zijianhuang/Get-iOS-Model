using System;
using System.Collections.Generic;
using System.Text;

namespace BasicTests
{
	/// <summary>
	/// xCode/iOS api does not support reading device PPI, so there has to be a hard coded table.
	/// </summary>
	public class DevicePpi
	{
		public static int GetPpi(string modelIdentifier)
		{
			//ported from https://github.com/marchv/UIScreenExtension/blob/master/UIScreenExtension/UIScreenExtension.swift
			switch (modelIdentifier)
			{
				case "iPad2,1":
				case "iPad2,2":
				case "iPad2,3":
				case "iPad2,4": // iPad 2
					return 132;


				case "iPad2,5":
				case "iPad2,6":
				case "iPad2,7": // iPad Mini
					return 163;


				case "iPad3,1":
				case "iPad3,2":
				case "iPad3,3": // iPad 3rd generation
				case "iPad3,4":
				case "iPad3,5":
				case "iPad3,6": // iPad 4th generation
				case "iPad4,1":
				case "iPad4,2":
				case "iPad4,3": // iPad Air
				case "iPad5,3":
				case "iPad5,4": // iPad Air 2
				case "iPad6,7":
				case "iPad6,8": // iPad Pro (12.9 inch)
				case "iPad6,3":
				case "iPad6,4": // iPad Pro (9.7 inch)
				case "iPad6,11":
				case "iPad6,12": // iPad 5th generation
				case "iPad7,1":
				case "iPad7,2": // iPad Pro (12.9 inch: case 2nd generation)
				case "iPad7,3":
				case "iPad7,4": // iPad Pro (10.5 inch)
				case "iPad7,5":
				case "iPad7,6": // iPad 6th generation
				case "iPad7,11": //iPad (10.2 inch - 7th generation 2019) A2097
				case "iPad7,12": //A2198, A2199 & A2200
				case "iPad8,1":
				case "iPad8,2":
				case "iPad8,3":
				case "iPad8,4": // iPad Pro (11 inch)

				case "iPad8,5":
				case "iPad8,6":
				case "iPad8,7":
				case "iPad8,8": // iPad Pro (12.9 inch, 3rd generation)

				case "iPad8,9": // iPad Pro 11-inch (2nd generation) (2020)
				case "iPad8,10": // iPad Pro 11-inch (2nd generation) Wi-Fi + Cellular
				case "iPad8,11": // iPad Pro 12.9-inch (4th generation)
				case "iPad8,12": // iPad Pro 12.9-inch (4th generation Wi-Fi + Cellular)

				case "iPad11,3":
				case "iPad11,4": // iPad Air 2019 (3rd generation)
					return 264;


				case "iPhone4,1": // iPhone 4S
				case "iPhone5,1":
				case "iPhone5,2": // iPhone 5
				case "iPhone5,3":
				case "iPhone5,4": // iPhone 5C
				case "iPhone6,1":
				case "iPhone6,2": // iPhone 5S
				case "iPhone8,4": // iPhone SE
				case "iPhone7,2": // iPhone 6
				case "iPhone8,1": // iPhone 6S
				case "iPhone9,1":
				case "iPhone9,3": // iPhone 7
				case "iPhone10,1":
				case "iPhone10,4": // iPhone 8
				case "iPhone11,8": // iPhone XR
				case "iPhone12,1": // iPhone 11

				case "iPod5,1": // iPod Touch 5th generation
				case "iPod7,1": // iPod Touch 6th generation

				case "iPad4,4":
				case "iPad4,5":
				case "iPad4,6": // iPad Mini 2
				case "iPad4,7":
				case "iPad4,8":
				case "iPad4,9": // iPad Mini 3
				case "iPad5,1":
				case "iPad5,2": // iPad Mini 4
				case "iPad11,1":
				case "iPad11,2": // iPad Mini 5
				case "iPhone12,8": // iPhone SE 2nd geeneration
					return 326;


				case "iPhone7,1": // iPhone 6 Plus
				case "iPhone8,2": // iPhone 6S Plus
				case "iPhone9,2":
				case "iPhone9,4": // iPhone 7 Plus
				case "iPhone10,2":
				case "iPhone10,5": // iPhone 8 Plus
					return 401;


				case "iPhone10,3":
				case "iPhone10,6": // iPhone X
				case "iPhone11,2": // iPhone XS
				case "iPhone11,4":
				case "iPhone11,6": // iPhone XS Max
				case "iPhone12,3": // iPhone 11 Pro
				case "iPhone12,5": // iPhone 11 Max
					return 458;


				default: // unknown model identifier
						 //return 458; //todo: throws exception for better handling telling the user to contact s@fonlow.com
					return 100; // for the time being
			}
		}
	}

}
