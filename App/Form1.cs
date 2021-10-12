using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace SortingAlgorithms
{
	public partial class Form : System.Windows.Forms.Form
	{
		private int[] _nArray;
		private Movie[] _mArray;
		private SortingType _workingWith;
		private readonly Control[] _sortTableControls;

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
			_sortTableControls[SortedTable.GetIndexOfControl(6, 0)] = new Label() { Text = "Простое слияние", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(7, 0)] = new Label() { Text = "Естественное слияние", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };
			_sortTableControls[SortedTable.GetIndexOfControl(8, 0)] = new Label() { Text = "Многопутевое сбалансированное слияние", AutoSize = false, TextAlign = ContentAlignment.MiddleLeft };

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
					_nArray = ParseTextToIntArray(ArrayInDialog.FileName);
					_workingWith = SortingType.ints;

					ArrayInLabel.Text = ArrayInDialog.FileName;
					ClearSorted();
					ArrayInPicture.Image = Properties.Resources.Passed;
					PrintArray(_nArray, ArrayInPreview);
				}
				else if (extension == ".json")
				{
					_mArray = ParseJsonToMovieArray(ArrayInDialog.FileName);
					_workingWith = SortingType.movies;

					ArrayInLabel.Text = ArrayInDialog.FileName;
					ClearSorted();
					ArrayInPicture.Image = Properties.Resources.Passed;
					PrintArray(_mArray, ArrayInPreview);
				}
			}
		}

		private void SortButton_Click(object sender, EventArgs e)
		{
			int[] ints = default;
			Movie[] movies = default;

			// we're not changing initial arrays so we can try every sorting algorithm
			if (_workingWith == SortingType.ints)
			{
				ints = new int[_nArray.Length];
				for (int i = 0; i < ints.Length; i++)
					ints[i] = _nArray[i];
			}
			else
			{
				movies = new Movie[_mArray.Length];
				for (int i = 0; i < movies.Length; i++)
					movies[i] = _mArray[i];
			}


			(int, int, float) results;
			switch (SortMethodNumbersDropDown.SelectedIndex)
			{
				case 0:
					results = _workingWith == SortingType.ints ? Sorting.Selection(ref ints) : Sorting.Selection(ref movies);
					break;
				case 1:
					results = _workingWith == SortingType.ints ? Sorting.Bubble(ref ints) : Sorting.Bubble(ref movies);
					break;
				case 2:
					results = _workingWith == SortingType.ints ? Sorting.Insertion(ref ints) : Sorting.Insertion(ref movies);
					break;
				case 3:
					results = _workingWith == SortingType.ints ? Sorting.Gnome(ref ints) : Sorting.Gnome(ref movies);
					break;
				case 4:
					results = _workingWith == SortingType.ints ? Sorting.Quick(ref ints) : Sorting.Quick(ref movies);
					break;
				case 5:
					results = _workingWith == SortingType.ints ? Sorting.Merge(ref ints) : Sorting.Merge(ref movies);
					break;
				case 6:
					results = _workingWith == SortingType.ints ? Sorting.NaturalMerge(ref ints) : Sorting.NaturalMerge(ref movies);
					break;
				case 7:
					results = _workingWith == SortingType.ints ? Sorting.BalancedMerge(ref ints) : Sorting.BalancedMerge(ref movies);
					break;
				default:
					results = default;
					Console.WriteLine($"Received invalid sort method index: {SortMethodNumbersDropDown.SelectedIndex}");
					break;
			}

			if (results != default)
			{
				int length;
				if (_workingWith == SortingType.ints)
				{
					PrintArray(ints, SortedArray);
					length = ints.Length;
				}
				else
				{
					PrintArray(movies, SortedArray);
					length = movies.Length;
                }

				PrintCharacteristicsToTable(SortMethodNumbersDropDown.SelectedIndex + 1, length, results.Item1, results.Item2, results.Item3);
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

		// -------------------------------------- parse methods -----------------------------------

		private int[] ParseTextToIntArray(in string path)
		{
			string text = File.ReadAllText(path);
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

		private Movie[] ParseJsonToMovieArray(in string path)
        {
			using (StreamReader sr = new StreamReader(path))
            {
				string jsonFile = sr.ReadToEnd();

				List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonFile);

				return movies.ToArray();
			}
        }

		// ------------------------------------- utility methods ----------------------------------

		private void PrintCharacteristicsToTable(in int row, in int elements, in int comparsions, in int permutations, in float time)
		{
			_sortTableControls[SortedTable.GetIndexOfControl(row, 1)].Text = elements.ToString();
			_sortTableControls[SortedTable.GetIndexOfControl(row, 2)].Text = comparsions.ToString();
			_sortTableControls[SortedTable.GetIndexOfControl(row, 3)].Text = permutations.ToString();
			_sortTableControls[SortedTable.GetIndexOfControl(row, 4)].Text = time.ToString();
		}

		private void PrintArray(in int[] array, in TextBox textBox)
		{
			textBox.Text = "";

			string arrayElements = "";
			for (int i = 0; i < array.Length; i++)
				arrayElements += array[i].ToString() + ' ';

			// textbox updates every time text is changed so directly setting text property to 5000 characters long string is too slow
			textBox.SelectionStart = textBox.TextLength;
			textBox.SelectedText = arrayElements;
		}

		private void PrintArray(in Movie[] array, in TextBox textBox)
		{
			textBox.Text = "";

			string arrayElements = "";
			for (int i = 0; i < array.Length; i++)
				arrayElements += array[i].Name + ' ' + array[i].Genre + ' ' + array[i].Director + ' ' + array[i].Year + ";   ";

			// textbox updates every time text is changed so directly setting text property to 5000 characters long string is too slow
			textBox.SelectionStart = textBox.TextLength;
			textBox.SelectedText = arrayElements;
		}

		private void ClearSorted()
		{
			// characteristics table
			for (int row = 1; row < SortedTable.RowCount; row++)
				for (int column = 1; column < SortedTable.ColumnCount; column++)
					_sortTableControls[SortedTable.GetIndexOfControl(row, column)].Text = "";

			SortedArray.Text = "";
		}
	}
}
