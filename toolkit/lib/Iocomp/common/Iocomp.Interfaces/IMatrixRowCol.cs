namespace Iocomp.Interfaces
{
	public interface IMatrixRowCol
	{
		int RowIndex
		{
			get;
		}

		int ColIndex
		{
			get;
		}

		void SetRowColIndexes(int rowIndex, int colIndex);
	}
}
