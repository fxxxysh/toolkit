using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Table Grid")]
	public class PlotTableGrid : PlotTableBase
	{
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new int DataColCount
		{
			get
			{
				return base.DataColCount;
			}
			set
			{
				base.DataColCount = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new int DataRowCount
		{
			get
			{
				return base.DataRowCount;
			}
			set
			{
				base.DataRowCount = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Table Grid";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTableGridEditorPlugIn";
		}

		public PlotTableGrid()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Grid";
		}

		private bool ShouldSerializeDataColCount()
		{
			return base.PropertyShouldSerialize("DataColCount");
		}

		private void ResetDataColCount()
		{
			base.PropertyReset("DataColCount");
		}

		private bool ShouldSerializeDataRowCount()
		{
			return base.PropertyShouldSerialize("DataRowCount");
		}

		private void ResetDataRowCount()
		{
			base.PropertyReset("DataRowCount");
		}
	}
}
