using System;

namespace Iocomp.Interfaces
{
	public interface ICollectionBase
	{
		bool AllowEdit
		{
			get;
		}

		IComponentBase ComponentBase
		{
			get;
			set;
		}

		object CreateInstance(Type type);
	}
}
