using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace Lab1
{
	public partial class Form : System.Windows.Forms.Form
	{
		private int[] _nArray;
		private KeyValuePair<string, JsonToken>[] _jArray;
		private int _comparsions;
		private int _permutations;
		private float _milliseconds;
		private Control[] _sortTableControls;

		public Form()
		{
			InitializeComponent();
			_sortTableControls = new Control[SortedTable.GetIndexOfLastControl() + 1];

			_sortTableControls[SortedTable.GetIndexOfControl(0, 0)] = new Label() { Text = "Вид сортировки", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(0, 1)] = new Label() { Text = "Элементов", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(0, 2)] = new Label() { Text = "Сравнений", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(0, 3)] = new Label() { Text = "Перестановок", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(0, 4)] = new Label() { Text = "Время", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };

			_sortTableControls[SortedTable.GetIndexOfControl(1, 0)] = new Label() { Text = "Простые вставки", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(2, 0)] = new Label() { Text = "Простой обмен", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(3, 0)] = new Label() { Text = "Простой выбор", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(4, 0)] = new Label() { Text = "Гномья", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(5, 0)] = new Label() { Text = "Быстрая", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };

			for (int row = 1; row < SortedTable.RowCount; row++)
				for (int column = 1; column < SortedTable.ColumnCount; column++)
					_sortTableControls[SortedTable.GetIndexOfControl(row, column)] = new Label() { AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };

			for (int row = 0; row < SortedTable.RowCount; row++)
				for (int column = 0; column < SortedTable.ColumnCount; column++)
					SortedTable.Controls.Add(_sortTableControls[SortedTable.GetIndexOfControl(row, column)], column, row);
		}

		// --------------------------------- windows forms methods---------------------------------

		private void ArrayInButton_Click(object sender, EventArgs e)
		{
			if (ArrayInDialog.ShowDialog() == DialogResult.OK)
			{
				string extension = Path.GetExtension(ArrayInDialog.FileName);

				if (extension == ".txt")
				{
					_nArray = ParseTextToIntArray(File.ReadAllText(ArrayInDialog.FileName));

					ArrayInLabel.Text = ArrayInDialog.FileName;
					ClearSorted();
					ArrayInPicture.Image = Properties.Resources.Passed;
					PrintArrayToPreview(_nArray);
				}
				else if (extension == ".json")
				{
					// proceed next
				}
			}
		}

		private void SortButton_Click(object sender, EventArgs e)
		{
			// we're not changing initial array so we can try every sorting algorithm
			int[] array = new int[_nArray.Length];
			for (int i = 0; i < array.Length; i++)
				array[i] = _nArray[i];

			switch (SortMethodNumbersDropDown.SelectedIndex)
			{
				case 0:
				{
					SelectionSort(ref array);
					break;
				}
				case 1:
				{
					BubbleSort(ref array);
					break;
				}
				case 2:
				{
					InsertionSort(ref array);
					break;
				}
				case 3:
				{
					GnomeSort(ref array);
					break;
				}
				case 4:
				{
					QuickSort(ref array);
					break;
				}
				default:
				{
					Console.WriteLine($"Received invalid sort method index: {SortMethodNumbersDropDown.SelectedIndex}");
					break;
				}
			}
		}

		private void SortedTableButton_Click(object sender, EventArgs e)
		{
			if (SortedTableSaveDialog.ShowDialog() == DialogResult.OK)
			{
				string text = "";
				string currentCellText;
				int currentCellMaxLength;
				for (int row = 0; row < SortedTable.RowCount; row++)
				{
					for (int column = 0; column < SortedTable.ColumnCount; column++)
					{
						currentCellText = _sortTableControls[SortedTable.GetIndexOfControl(row, column)].Text;
						currentCellMaxLength = column == 1 ? 30 : 20;

						while (currentCellText.Length < currentCellMaxLength)
							currentCellText += ' ';
						currentCellText += '|';

						text += currentCellText;
					}
					text += '\n';
				}

				using (FileStream fs = File.Create(SortedTableSaveDialog.FileName))
				{
					fs.Write(new UTF8Encoding(true).GetBytes(text), 0, text.Length);
				}
			}
		}

		// ------------------------------------- utility methods ----------------------------------------

		private int[] ParseTextToIntArray(in string text)
		{
			List<int> result = new List<int>();

			string number = "";
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] != ' ')
				{
					number += text[i].ToString();
				}
				else
				{
					result.Add(Convert.ToInt32(number));
					number = "";
				}
			}

			result.Add(Convert.ToInt32(number));
			return result.ToArray();
		}

		private KeyValuePair<string, JsonToken> ParseJsonToArray()
		{
			return default;
		}

		private void PrintCharacteristicsToTable(in int row, in int elements, in int comparsions, in int permutations, in float time)
		{
			_sortTableControls[SortedTable.GetIndexOfControl(row, 1)].Text = elements.ToString();
			_sortTableControls[SortedTable.GetIndexOfControl(row, 2)].Text = comparsions.ToString();
			_sortTableControls[SortedTable.GetIndexOfControl(row, 3)].Text = permutations.ToString();
			_sortTableControls[SortedTable.GetIndexOfControl(row, 4)].Text = time.ToString();
		}

		private void PrintArrayToPreview(in int[] array)
		{
			ArrayInPreview.Text = "";

			string arrayElements = "";
			for (int i = 0; i < array.Length; i++)
				arrayElements += array[i].ToString() + ' ';

			// textbox updates every time text is changed so directly setting text property to 5000 characters long string is too slow
			ArrayInPreview.SelectionStart = ArrayInPreview.TextLength;
			ArrayInPreview.SelectedText = arrayElements;
		}

		private void PrintArrayToPreview(in KeyValuePair<string, JsonToken> array)
		{

		}

		private void PrintArrayToSorted(in int[] array)
		{
			SortedArray.Text = "";

			string arrayElements = "";
			for (int i = 0; i < array.Length; i++)
				arrayElements += array[i].ToString() + ' ';

			// textbox updates every time text is changed so directly setting text property to 5000 characters long string is too slow
			SortedArray.SelectionStart = SortedArray.TextLength;
			SortedArray.SelectedText = arrayElements;
		}

		private void PrintArrayToSorted(in KeyValuePair<string, JsonToken> array)
		{

		}

		private void ClearSorted()
		{
			// characteristics table
			for (int row = 1; row < SortedTable.RowCount; row++)
				for (int column = 1; column < SortedTable.ColumnCount; column++)
					_sortTableControls[SortedTable.GetIndexOfControl(row, column)].Text = "";

			SortedArray.Text = "";
		}

		private void RestoreControlValues()
		{
			_comparsions = 0;
			_permutations = 0;
			_milliseconds = DateTime.Now.Millisecond;
		}

		private void Swap(ref int n1, ref int n2)
		{
			int temp = n1;
			n1 = n2;
			n2 = temp;
		}

		// ------------------------------------ sorting algorithms --------------------------------------

		private void SelectionSort(ref int[] arrayIn)
		{
			RestoreControlValues();
			

			// algorithm
			int max, indexMax, currentIndex;
			for (int j = arrayIn.Length - 1; j > 0; j--)
			{
				indexMax = 0;
				max = arrayIn[indexMax];
				currentIndex = 1;

				while (currentIndex < j)
				{
					_comparsions++;
					if (max < arrayIn[currentIndex])
					{
						max = arrayIn[currentIndex];
						indexMax = currentIndex;
					}
					currentIndex++;
				}

				_permutations++;
				Swap(ref arrayIn[currentIndex], ref arrayIn[indexMax]);
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			PrintArrayToSorted(arrayIn);
			PrintCharacteristicsToTable(SortMethodNumbersDropDown.SelectedIndex + 1, arrayIn.Length, _comparsions, _permutations, _milliseconds);
		}

		private void BubbleSort(ref int[] arrayIn)
		{
			RestoreControlValues();


			// algorithm
			for (int i = 0; i < arrayIn.Length; i++)
				for (int j = 0; j < arrayIn.Length - 1; j++)
				{
					_comparsions++;
					if (arrayIn[j] > arrayIn[j + 1])
					{
						_permutations++;
						Swap(ref arrayIn[j + 1], ref arrayIn[j]);
					}
				}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			PrintArrayToSorted(arrayIn);
			PrintCharacteristicsToTable(SortMethodNumbersDropDown.SelectedIndex + 1, arrayIn.Length, _comparsions, _permutations, _milliseconds);
		}

		private void InsertionSort(ref int[] arrayIn)
		{
			RestoreControlValues();

			
			// algorithm
			int key;
			int j;
			for (var i = 1; i < arrayIn.Length; i++)
			{
				key = arrayIn[i];
				j = i;
				_comparsions++;
				while ((j >= 1) && (arrayIn[j - 1] > key))
				{
					_permutations++;
					Swap(ref arrayIn[j - 1], ref arrayIn[j]);
					j--;
				}

				arrayIn[j] = key;
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			PrintArrayToSorted(arrayIn);
			PrintCharacteristicsToTable(SortMethodNumbersDropDown.SelectedIndex + 1, arrayIn.Length, _comparsions, _permutations, _milliseconds);
		}

		private void GnomeSort(ref int[] arrayIn)
		{
			RestoreControlValues();


			// algorithm
			var index = 1;
			var nextIndex = index + 1;

			while (index < arrayIn.Length)
			{
				_comparsions++;
				if (arrayIn[index - 1] < arrayIn[index])
				{
					index = nextIndex;
					nextIndex++;
				}
				else
				{
					_permutations++;
					Swap(ref arrayIn[index - 1], ref arrayIn[index]);
					index--;
					if (index == 0)
					{
						index = nextIndex;
						nextIndex++;
					}
				}
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			PrintArrayToSorted(arrayIn);
			PrintCharacteristicsToTable(SortMethodNumbersDropDown.SelectedIndex + 1, arrayIn.Length, _comparsions, _permutations, _milliseconds);
		}

		private void QuickSort(ref int[] arrayIn)
		{
			RestoreControlValues();

			QuickSort_Algo(ref arrayIn, 0, arrayIn.Length - 1);
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;

			PrintArrayToSorted(arrayIn);
			PrintCharacteristicsToTable(SortMethodNumbersDropDown.SelectedIndex + 1, arrayIn.Length, _comparsions, _permutations, _milliseconds);
		}

		private void QuickSort_Algo(ref int[] a, int start, int finish)
		{
			if (start < finish)
			{
				int q = QuickSort_Partition(a, start, finish);
				QuickSort_Algo(ref a, start, q);
				QuickSort_Algo(ref a, q + 1, finish);
			}
		}

		private int QuickSort_Partition(int[] a, int p, int r)
		{
			int x = a[p];
			int i = p - 1;
			int j = r + 1;
			while (true)
			{
				do
				{
					j--;
					_comparsions++;
				}
				while (a[j] > x);
				do
				{
					i++;
					_comparsions++;
				}
				while (a[i] < x);
				if (i < j)
				{
					Swap(ref a[i], ref a[j]);
					_permutations++;
				}
				else
				{
					return j;
				}
			}
		}
	}
}
