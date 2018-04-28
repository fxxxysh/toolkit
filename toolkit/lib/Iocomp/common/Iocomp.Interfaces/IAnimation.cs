using Iocomp.Types;
using System;

namespace Iocomp.Interfaces
{
	public interface IAnimation
	{
		bool On
		{
			get;
			set;
		}

		int FrameNumber
		{
			get;
			set;
		}

		int FrameCount
		{
			get;
			set;
		}

		FrameDirection Direction
		{
			get;
			set;
		}

		double Interval
		{
			get;
			set;
		}

		event EventHandler FrameChanged;

		void GoFirst();

		void GoLast();
	}
}
