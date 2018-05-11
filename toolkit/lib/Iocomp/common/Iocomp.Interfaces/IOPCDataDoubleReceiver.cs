using System;

namespace Iocomp.Interfaces
{
	public interface IOPCDataDoubleReceiver
	{
		void NewOPCData(double data, DateTime timeStamp);
	}
}
