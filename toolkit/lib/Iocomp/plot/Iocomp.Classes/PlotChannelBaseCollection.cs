using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotChannelBaseCollection : PlotObjectCollectionBase
	{
		private PlotColorTable m_ColorTable;

		private PlotChannelBarAccessor m_Bar;

		private PlotChannelBiFillAccessor m_BiFill;

		private PlotChannelBubbleAccessor m_Bubble;

		private PlotChannelCandlestick1Accessor m_Candlestick1;

		private PlotChannelCandlestick2Accessor m_Candlestick2;

		private PlotChannelCandlestick3Accessor m_Candlestick3;

		private PlotChannelCubicSplineAccessor m_CubicSpline;

		private PlotChannelDifferentialAccessor m_Differential;

		private PlotChannelDigitalAccessor m_Digital;

		private PlotChannelFillAccessor m_Fill;

		private PlotChannelImageAccessor m_Image;

		private PlotChannelPolynomialAccessor m_Polynomial;

		private PlotChannelRationalAccessor m_Rational;

		private PlotChannelSweepIntervalAccessor m_SweepInterval;

		private PlotChannelTraceAccessor m_Trace;

		private PlotChannelTraceXYAccessor m_TraceXY;

		public PlotChannelBase this[int index]
		{
			get
			{
				return base.List[index] as PlotChannelBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotChannelBase this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotChannelBase;
			}
		}

		public PlotColorTable ColorTable => this.m_ColorTable;

		public PlotChannelBarAccessor Bar => this.m_Bar;

		public PlotChannelBiFillAccessor BiFill => this.m_BiFill;

		public PlotChannelBubbleAccessor Bubble => this.m_Bubble;

		public PlotChannelCandlestick1Accessor Candlestick1 => this.m_Candlestick1;

		public PlotChannelCandlestick2Accessor Candlestick2 => this.m_Candlestick2;

		public PlotChannelCandlestick3Accessor Candlestick3 => this.m_Candlestick3;

		public PlotChannelCubicSplineAccessor CubicSpline => this.m_CubicSpline;

		public PlotChannelDifferentialAccessor Differential => this.m_Differential;

		public PlotChannelDigitalAccessor Digital => this.m_Digital;

		public PlotChannelFillAccessor Fill => this.m_Fill;

		public PlotChannelImageAccessor Image => this.m_Image;

		public PlotChannelPolynomialAccessor Polynomial => this.m_Polynomial;

		public PlotChannelRationalAccessor Rational => this.m_Rational;

		public PlotChannelSweepIntervalAccessor SweepInterval => this.m_SweepInterval;

		public PlotChannelTraceAccessor Trace => this.m_Trace;

		public PlotChannelTraceXYAccessor TraceXY => this.m_TraceXY;

		protected override string GetPlugInTitle()
		{
			return "Channel Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelBaseCollectionEditorPlugIn";
		}

		public PlotChannelBaseCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotChannelBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Channel";
			this.m_Bar = new PlotChannelBarAccessor(this);
			this.m_BiFill = new PlotChannelBiFillAccessor(this);
			this.m_Bubble = new PlotChannelBubbleAccessor(this);
			this.m_Candlestick1 = new PlotChannelCandlestick1Accessor(this);
			this.m_Candlestick2 = new PlotChannelCandlestick2Accessor(this);
			this.m_Candlestick3 = new PlotChannelCandlestick3Accessor(this);
			this.m_CubicSpline = new PlotChannelCubicSplineAccessor(this);
			this.m_Differential = new PlotChannelDifferentialAccessor(this);
			this.m_Digital = new PlotChannelDigitalAccessor(this);
			this.m_Fill = new PlotChannelFillAccessor(this);
			this.m_Image = new PlotChannelImageAccessor(this);
			this.m_Polynomial = new PlotChannelPolynomialAccessor(this);
			this.m_Rational = new PlotChannelRationalAccessor(this);
			this.m_SweepInterval = new PlotChannelSweepIntervalAccessor(this);
			this.m_Trace = new PlotChannelTraceAccessor(this);
			this.m_TraceXY = new PlotChannelTraceXYAccessor(this);
			this.m_ColorTable = new PlotColorTable();
			this.m_ColorTable.RefreshTable += this.m_ColorTable_RefreshTable;
		}

		public void CopyTo(PlotChannelBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotChannelBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotChannelBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotChannelBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotChannelBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotChannelBase value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PlotChannelTrace());
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
			PlotChannelBase plotChannelBase = value as PlotChannelBase;
			Plot plot = base.ComponentBase as Plot;
			if (plotChannelBase.Color == Color.Empty)
			{
				plotChannelBase.Color = this.ColorTable.NextColor();
			}
			if (plot != null)
			{
				if (plotChannelBase.XAxisName == "" && plot.XAxes.Count != 0)
				{
					plotChannelBase.XAxisName = plot.XAxes[0].Name;
				}
				if (plotChannelBase.YAxisName == "" && plot.YAxes.Count != 0)
				{
					plotChannelBase.YAxisName = plot.YAxes[0].Name;
				}
				if (plotChannelBase.LegendName == "" && plot.Legends.Count != 0)
				{
					plotChannelBase.LegendName = plot.Legends[0].Name;
				}
			}
		}

		private void m_ColorTable_RefreshTable(object sender, EventArgs e)
		{
			foreach (PlotChannelBase item in this)
			{
				this.ColorTable.AddUsedColor(item.Color);
			}
		}
	}
}
