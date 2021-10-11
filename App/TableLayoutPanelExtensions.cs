using System.Windows.Forms;

namespace SortingAlgorithms
{
	public static class TableLayoutPanelExtensions
	{
		public static int GetIndexOfControl(this TableLayoutPanel tlp, int row, int column)
		{
			return tlp.ColumnCount * row + column;
		}

		public static int GetIndexOfLastControl(this TableLayoutPanel tlp)
		{
			return tlp.ColumnCount * tlp.RowCount - 1;
		}
	}
}
