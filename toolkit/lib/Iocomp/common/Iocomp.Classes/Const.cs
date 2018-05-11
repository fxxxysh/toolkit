namespace Iocomp.Classes
{
	public sealed class Const
	{
		private static string m_EmptyString;

		public static string EmptyString => Const.m_EmptyString;

		static Const()
		{
			Const.m_EmptyString = string.Empty;
		}
	}
}
