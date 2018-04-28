using System.Collections;

namespace Iocomp.Classes
{
	public sealed class PlugIn
	{
		public static Hashtable TypeList;

		static PlugIn()
		{
			PlugIn.TypeList = new Hashtable();
		}
	}
}
