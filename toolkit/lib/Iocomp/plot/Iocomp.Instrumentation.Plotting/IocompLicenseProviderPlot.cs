using Iocomp.Licensing;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Iocomp.Instrumentation.Plotting
{
	public class IocompLicenseProviderPlot : IocompLicenseProvider
	{
		protected override bool LicenseKeyValid(Type type, string licensekey)
		{
			HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA1");
			byte[] value = hashAlgorithm.ComputeHash(Encoding.Default.GetBytes(licensekey));
			string a = BitConverter.ToString(value);
			if (type == typeof(Plot) && a == "AE-A4-2B-0D-D1-C9-3D-99-15-9C-C7-DF-09-7E-83-C8-A7-33-4E-3B")
			{
				return true;
			}
			return false;
		}
	}
}
