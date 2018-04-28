namespace Iocomp.Classes
{
	public class PropertyData
	{
		private string m_Name;

		private object m_Value;

		public string Name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				this.m_Name = value;
			}
		}

		public object Value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
			}
		}
	}
}
