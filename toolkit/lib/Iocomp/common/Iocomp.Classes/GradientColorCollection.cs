using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	public class GradientColorCollection : CollectionBase
	{
		public GradientColor this[int index]
		{
			get
			{
				return base.List[index] as GradientColor;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public bool IsValid
		{
			get
			{
				if (base.Count < 2)
				{
					return false;
				}
				if (this[0].Position != 0.0)
				{
					return false;
				}
				if (this[base.LastIndex].Position != 1.0)
				{
					return false;
				}
				return true;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color[] Colors
		{
			get
			{
				Color[] array = new Color[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array[i] = this[i].Color;
				}
				return array;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public float[] Positions
		{
			get
			{
				float[] array = new float[base.Count];
				for (int i = 0; i < base.Count; i++)
				{
					array[i] = (float)this[i].Position;
				}
				return array;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Gradient Color Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.GradientColorCollectionEditorPlugIn";
		}

		public GradientColorCollection()
			: base(null)
		{
		}

		public GradientColorCollection(IComponentBase componentBase)
			: base(componentBase)
		{
		}

		public void CopyTo(GradientColor[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(GradientColor value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, GradientColor value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(GradientColor value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(GradientColor value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(GradientColor value)
		{
			return base.List.Contains(value);
		}
	}
}
