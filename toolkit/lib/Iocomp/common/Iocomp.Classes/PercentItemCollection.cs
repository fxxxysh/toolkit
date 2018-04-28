using Iocomp.Interfaces;
using System;
using System.Collections;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PercentItemCollection : CollectionBase
	{
		public PercentItem this[int index]
		{
			get
			{
				return base.List[index] as PercentItem;
			}
			set
			{
				base.List[index] = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Item Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PercentItemCollectionEditorPlugIn";
		}

		public PercentItemCollection()
			: base(null)
		{
		}

		public PercentItemCollection(IComponentBase componentBase)
			: base(componentBase)
		{
		}

		public void CopyTo(PercentItem[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PercentItem value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PercentItem value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PercentItem value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PercentItem value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PercentItem value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PercentItem());
			this.Add(new PercentItem());
			this.Add(new PercentItem());
			this[0].Value.AsDouble = 100.0;
			this[1].Value.AsDouble = 100.0;
			this[2].Value.AsDouble = 100.0;
			this[0].Color = Color.Red;
			this[1].Color = Color.Yellow;
			this[2].Color = Color.Orange;
			this[0].Title = "Item 1";
			this[1].Title = "Item 2";
			this[2].Title = "Item 3";
		}

		public double GetItemPercent(int index)
		{
			double num = 0.0;
			for (int i = 0; i < base.Count; i++)
			{
				num += Math.Abs(this[i].Value.AsDouble);
			}
			if (num == 0.0)
			{
				return 1.0 / (double)base.Count;
			}
			return Math.Abs(this[index].Value.AsDouble / num);
		}

		public double GetItemPercent(PercentItem value)
		{
			return this.GetItemPercent(this.IndexOf(value));
		}
	}
}
