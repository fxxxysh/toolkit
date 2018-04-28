using System;

namespace Iocomp.Classes
{
	public class AnnotationEventArgs : EventArgs
	{
		private AnnotationBase m_Annotation;

		public AnnotationBase Annotation => this.m_Annotation;

		public AnnotationEventArgs(AnnotationBase annotation)
		{
			this.m_Annotation = annotation;
		}
	}
}
