using Iocomp.Interfaces;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Table Cells Formatting")]
	public class PlotTableCellsFormatting : SubClassBase
	{
		private PlotTableCellFormat m_ColTitles;

		private PlotTableCellFormat m_RowTitles;

		private PlotTableCellFormat m_Data;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotTableCellFormat ColTitles
		{
			get
			{
				return this.m_ColTitles;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotTableCellFormat RowTitles
		{
			get
			{
				return this.m_RowTitles;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotTableCellFormat Data
		{
			get
			{
				return this.m_Data;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Table Cells Formatting";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTableCellsFormattingEditorPlugIn";
		}

		public PlotTableCellsFormatting()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_ColTitles = new PlotTableCellFormat();
			base.AddSubClass(this.ColTitles);
			this.m_RowTitles = new PlotTableCellFormat();
			base.AddSubClass(this.RowTitles);
			this.m_Data = new PlotTableCellFormat();
			base.AddSubClass(this.Data);
		}

		private bool ShouldSerializeColTitles()
		{
			return ((ISubClassBase)this.ColTitles).ShouldSerialize();
		}

		private void ResetColTitles()
		{
			((ISubClassBase)this.ColTitles).ResetToDefault();
		}

		private bool ShouldSerializeRowTitles()
		{
			return ((ISubClassBase)this.RowTitles).ShouldSerialize();
		}

		private void ResetRowTitles()
		{
			((ISubClassBase)this.RowTitles).ResetToDefault();
		}

		private bool ShouldSerializeData()
		{
			return ((ISubClassBase)this.Data).ShouldSerialize();
		}

		private void ResetData()
		{
			((ISubClassBase)this.Data).ResetToDefault();
		}
	}
}
