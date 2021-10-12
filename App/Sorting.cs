using System;

namespace SortingAlgorithms
{
    public static class Sorting
	{
		private static int _comparsions;
		private static int _permutations;
		private static float _milliseconds;

		public static (int, int, float) Selection(ref int[] arrayIn)
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


			return(_comparsions, _permutations, _milliseconds);
		}

		public static (int, int, float) Bubble(ref int[] arrayIn)
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


			return (_comparsions, _permutations, _milliseconds);
		}

		public static (int, int, float) Insertion(ref int[] arrayIn)
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


			return (_comparsions, _permutations, _milliseconds);
		}

		public static (int, int, float) Gnome(ref int[] arrayIn)
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


			return (_comparsions, _permutations, _milliseconds);
		}


		public static (int, int, float) Quick(ref int[] arrayIn)
		{
			RestoreControlValues();

			QuickAlgo(ref arrayIn, 0, arrayIn.Length - 1);
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;
			
			return (_comparsions, _permutations, _milliseconds);
		}

		private static void QuickAlgo(ref int[] a, int start, int finish)
		{
			if (start < finish)
			{
				int q = QuickPartition(a, start, finish);
				QuickAlgo(ref a, start, q);
				QuickAlgo(ref a, q + 1, finish);
			}
		}

		private static int QuickPartition(int[] a, int p, int r)
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


		public static (int, int, float) Merge(ref int[] arrayIn)
        {
			RestoreControlValues();

			Merge(ref arrayIn, 0, arrayIn.Length - 1);
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;

			return (_comparsions, _permutations, _milliseconds);
		}

		private static void Merge(ref int[] arrayIn, int lowIndex, int highIndex)
		{
			if (lowIndex < highIndex)
			{
				var middleIndex = (lowIndex + highIndex) / 2;
				Merge(ref arrayIn, lowIndex, middleIndex);
				Merge(ref arrayIn, middleIndex + 1, highIndex);
				_permutations++;
				MergeArrays(ref arrayIn, lowIndex, middleIndex, highIndex);
			}
        }

		private static void MergeArrays(ref int[] array, int lowIndex, int middleIndex, int highIndex)
		{
			var left = lowIndex;
			var right = middleIndex + 1;
			var tempArray = new int[highIndex - lowIndex + 1];
			var index = 0;

			while ((left <= middleIndex) && (right <= highIndex))
			{
				_comparsions++;
				if (array[left] < array[right])
				{
					tempArray[index] = array[left];
					left++;
				}
				else
				{
					tempArray[index] = array[right];
					right++;
				}

				index++;
			}

			for (var i = left; i <= middleIndex; i++)
			{
				tempArray[index] = array[i];
				index++;
			}

			for (var i = right; i <= highIndex; i++)
			{
				tempArray[index] = array[i];
				index++;
			}

			for (var i = 0; i < tempArray.Length; i++)
			{
				array[lowIndex + i] = tempArray[i];
			}
		}


		public static (int, int, float) NaturalMerge(ref int[] arrayIn)
		{
			RestoreControlValues();

			if (arrayIn.Length <= 1)
			{
				_milliseconds = DateTime.Now.Millisecond - _milliseconds;
				return (_comparsions, _permutations, _milliseconds);
			};

			int start = 0;
			int stop2;
			for (int stop1 = NaturalGetNextStop(start, arrayIn); stop1 < arrayIn.Length - 1; stop1++)
			{
				stop2 = NaturalGetNextStop(stop1 + 1, arrayIn);
				NaturalArraysMerge(ref arrayIn, start, stop1, stop2);
				stop1 = stop2;
			}

			_milliseconds = DateTime.Now.Millisecond - _milliseconds;
			return (_comparsions, _permutations, _milliseconds);
		}

		private static void NaturalArraysMerge(ref int[] arrayIn, int start, int stop1, int stop2)
		{
			int[] temp = new int[stop1 - start + 1];
			int[] tem = new int[stop2 - start + 1];
			for (int k = start; k <= stop1; k++)
				temp[k - start] = arrayIn[k];

			int i = start;
			int j = stop1 + 1;
			for (int k = start; k <= stop2; k++)
			{
				if (i > stop1)
					break;
				else if (j > stop2)
				{
					arrayIn[k] = temp[i];
					i++;
				}
				else
				{
					_comparsions++;
					if (temp[i] > arrayIn[j])
					{
						arrayIn[k] = arrayIn[j];
						j++;
					}
					else
					{
						arrayIn[k] = temp[i];
						i++;
					}
				}
				tem[k - start] = arrayIn[k];
			}

			_permutations++;
		}

		private static int NaturalGetNextStop(int i, in int[] arrayIn)
		{
			for (; i < arrayIn.Length - 1 && arrayIn[i] < arrayIn[i + 1];)
				i++;
			return i;
		}


		public static (int, int, float) BalancedMerge(ref int[] arrayIn)
        {
			RestoreControlValues();

			int[] arrayHelper = new int[arrayIn.Length];
			BalancedTopDownMerge(ref arrayIn, ref arrayHelper, arrayIn.Length);
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;

			return (_comparsions, _permutations, _milliseconds);
        }

	 	private static void BalancedTopDownMerge(ref int[] arrayIn, ref int[] arrayHelper, int n)
		{
			BalancedCopyArray(arrayIn, 0, n, arrayHelper);
			BalancedTopDownSplit(ref arrayHelper, 0, n, ref arrayIn);
		}

		private static void BalancedTopDownSplit(ref int[] arrayHelper, int iBegin, int iEnd, ref int[] arrayIn)
		{
			if (iEnd - iBegin < 2) 
				return;

			int iMiddle = (iEnd + iBegin) / 2;

			BalancedTopDownSplit(ref arrayIn, iBegin, iMiddle, ref arrayHelper);
			BalancedTopDownSplit(ref arrayIn, iMiddle, iEnd, ref arrayHelper);

			_permutations++;
			BalancedArraysMerge(ref arrayHelper, iBegin, iMiddle, iEnd, ref arrayIn);
		}

		private static void BalancedArraysMerge(ref int[] arrayIn, int iBegin, int iMiddle, int iEnd, ref int[] arrayHelper)
		{
			int i = iBegin;
			int j = iMiddle;
			for (int k = iBegin; k < iEnd; k++)
			{
				bool isLess = j >= iEnd;
				if (!isLess)
				{
					_comparsions++;
					isLess = arrayIn[i] <= arrayIn[j];
				}

				if (i < iMiddle && isLess)
				{
					arrayHelper[k] = arrayIn[i];
					i++;
				}
				else
				{
					arrayHelper[k] = arrayIn[j];
					j++;
				}
			}
		}

		private static void BalancedCopyArray(in int[] arrayIn, int iBegin, int iEnd, in int[] arrayHelper)
		{
			for (int k = iBegin; k < iEnd; k++) 
				arrayHelper[k] = arrayIn[k];
		}

		// ----------------------------------------------------------------------------------------

		public static (int, int, float) Selection(ref Movie[] arrayIn)
		{
			RestoreControlValues();


			// algorithm
			int max, indexMax, currentIndex;
			for (int j = arrayIn.Length - 1; j > 0; j--)
			{
				indexMax = 0;
				max = arrayIn[indexMax].Year;
				currentIndex = 1;

				while (currentIndex < j)
				{
					_comparsions++;
					if (max < arrayIn[currentIndex].Year)
					{
						max = arrayIn[currentIndex].Year;
						indexMax = currentIndex;
					}
					currentIndex++;
				}

				_permutations++;
				Swap(ref arrayIn[currentIndex], ref arrayIn[indexMax]);
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			return (_comparsions, _permutations, _milliseconds);
		}

		public static (int, int, float) Bubble(ref Movie[] arrayIn)
		{
			RestoreControlValues();


			// algorithm
			for (int i = 0; i < arrayIn.Length; i++)
				for (int j = 0; j < arrayIn.Length - 1; j++)
				{
					_comparsions++;
					if (arrayIn[j].Year > arrayIn[j + 1].Year)
					{
						_permutations++;
						Swap(ref arrayIn[j + 1], ref arrayIn[j]);
					}
				}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			return (_comparsions, _permutations, _milliseconds);
		}

		public static (int, int, float) Insertion(ref Movie[] arrayIn)
		{
			RestoreControlValues();


			// algorithm
			int key;
			int j;
			for (var i = 1; i < arrayIn.Length; i++)
			{
				key = arrayIn[i].Year;
				j = i;
				_comparsions++;
				while ((j >= 1) && (arrayIn[j - 1].Year > key))
				{
					_permutations++;
					Swap(ref arrayIn[j - 1], ref arrayIn[j]);
					j--;
				}

				arrayIn[j].Year = key;
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			return (_comparsions, _permutations, _milliseconds);
		}

		public static (int, int, float) Gnome(ref Movie[] arrayIn)
		{
			RestoreControlValues();


			// algorithm
			var index = 1;
			var nextIndex = index + 1;

			while (index < arrayIn.Length)
			{
				_comparsions++;
				if (arrayIn[index - 1].Year < arrayIn[index].Year)
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


			return (_comparsions, _permutations, _milliseconds);
		}


		public static (int, int, float) Quick(ref Movie[] arrayIn)
		{
			RestoreControlValues();

			Quick_Algo(ref arrayIn, 0, arrayIn.Length - 1);
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;

			return (_comparsions, _permutations, _milliseconds);
		}

		private static void Quick_Algo(ref Movie[] a, int start, int finish)
		{
			if (start < finish)
			{
				int q = Quick_Partition(a, start, finish);
				Quick_Algo(ref a, start, q);
				Quick_Algo(ref a, q + 1, finish);
			}
		}

		private static int Quick_Partition(Movie[] a, int p, int r)
		{
			int x = a[p].Year;
			int i = p - 1;
			int j = r + 1;
			while (true)
			{
				do
				{
					j--;
					_comparsions++;
				}
				while (a[j].Year > x);
				do
				{
					i++;
					_comparsions++;
				}
				while (a[i].Year < x);
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


		public static (int, int, float) Merge(ref Movie[] arrayIn)
		{
			RestoreControlValues();

			Merge(ref arrayIn, 0, arrayIn.Length - 1);
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;

			return (_comparsions, _permutations, _milliseconds);
		}

		private static void Merge(ref Movie[] arrayIn, int lowIndex, int highIndex)
		{
			if (lowIndex < highIndex)
			{
				var middleIndex = (lowIndex + highIndex) / 2;
				Merge(ref arrayIn, lowIndex, middleIndex);
				Merge(ref arrayIn, middleIndex + 1, highIndex);
				_permutations++;
				MergeArrays(ref arrayIn, lowIndex, middleIndex, highIndex);
			}
		}

		private static void MergeArrays(ref Movie[] array, int lowIndex, int middleIndex, int highIndex)
		{
			int left = lowIndex;
			int right = middleIndex + 1;
			var tempArray = new Movie[highIndex - lowIndex + 1];
			int index = 0;

			while ((left <= middleIndex) && (right <= highIndex))
			{
				_comparsions++;
				if (array[left].Year < array[right].Year)
				{
					tempArray[index] = array[left];
					left++;
				}
				else
				{
					tempArray[index] = array[right];
					right++;
				}

				index++;
			}

			for (var i = left; i <= middleIndex; i++)
			{
				tempArray[index] = array[i];
				index++;
			}

			for (var i = right; i <= highIndex; i++)
			{
				tempArray[index] = array[i];
				index++;
			}

			for (var i = 0; i < tempArray.Length; i++)
			{
				array[lowIndex + i] = tempArray[i];
			}
		}


		public static (int, int, float) NaturalMerge(ref Movie[] arrayIn)
		{
			RestoreControlValues();

			if (arrayIn.Length <= 1)
			{
				_milliseconds = DateTime.Now.Millisecond - _milliseconds;
				return (_comparsions, _permutations, _milliseconds);
			};

			int start = 0;
			int stop2;
			for (int stop1 = NaturalGetNextStop(start, arrayIn); stop1 < arrayIn.Length - 1; stop1++)
			{
				stop2 = NaturalGetNextStop(stop1 + 1, arrayIn);
				NaturalArraysMerge(ref arrayIn, start, stop1, stop2);
				stop1 = stop2;
			}

			_milliseconds = DateTime.Now.Millisecond - _milliseconds;
			return (_comparsions, _permutations, _milliseconds);
		}

		private static void NaturalArraysMerge(ref Movie[] arrayIn, int start, int stop1, int stop2)
		{
			_permutations++;

			Movie[] temp = new Movie[stop1 - start + 1];
			Movie[] tem = new Movie[stop2 - start + 1];
			for (int k = start; k <= stop1; k++)
				temp[k - start] = arrayIn[k];

			int i = start;
			int j = stop1 + 1;
			for (int k = start; k <= stop2; k++)
			{
				if (i > stop1)
					break;
				else if (j > stop2)
				{
					arrayIn[k] = temp[i];
					i++;
				}
				else
				{
					_comparsions++;
					if (temp[i].Year > arrayIn[j].Year)
					{
						arrayIn[k] = arrayIn[j];
						j++;
					}
					else
					{
						arrayIn[k] = temp[i];
						i++;
					}
				}
				tem[k - start] = arrayIn[k];
			}
		}

		private static int NaturalGetNextStop(int i, in Movie[] arrayIn)
		{
			for (; i < arrayIn.Length - 1 && arrayIn[i].Year < arrayIn[i + 1].Year;)
				i++;
			return i;
		}


		public static (int, int, float) BalancedMerge(ref Movie[] arrayIn)
		{
			RestoreControlValues();

			Movie[] arrayHelper = new Movie[arrayIn.Length];
			BalancedTopDownMerge(ref arrayIn, ref arrayHelper, arrayIn.Length);
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;

			return (_comparsions, _permutations, _milliseconds);
		}

		private static void BalancedTopDownMerge(ref Movie[] arrayIn, ref Movie[] arrayHelper, int n)
		{
			BalancedCopyArray(arrayIn, 0, n, arrayHelper);
			BalancedTopDownSplit(ref arrayHelper, 0, n, ref arrayIn);
		}

		private static void BalancedTopDownSplit(ref Movie[] arrayHelper, int iBegin, int iEnd, ref Movie[] arrayIn)
		{
			if (iEnd - iBegin < 2)
				return;

			int iMiddle = (iEnd + iBegin) / 2;

			BalancedTopDownSplit(ref arrayIn, iBegin, iMiddle, ref arrayHelper);
			BalancedTopDownSplit(ref arrayIn, iMiddle, iEnd, ref arrayHelper);

			_permutations++;
			BalancedArraysMerge(ref arrayHelper, iBegin, iMiddle, iEnd, ref arrayIn);
		}

		private static void BalancedArraysMerge(ref Movie[] arrayIn, int iBegin, int iMiddle, int iEnd, ref Movie[] arrayHelper)
		{
			int i = iBegin;
			int j = iMiddle;
			for (int k = iBegin; k < iEnd; k++)
			{
				bool isLess = j >= iEnd;
				if (!isLess)
				{
					_comparsions++;
					isLess = arrayIn[i].Year <= arrayIn[j].Year;
				}

				if (i < iMiddle && isLess)
				{
					arrayHelper[k] = arrayIn[i];
					i++;
				}
				else
				{
					arrayHelper[k] = arrayIn[j];
					j++;
				}
			}
		}

		private static void BalancedCopyArray(in Movie[] arrayIn, int iBegin, int iEnd, in Movie[] arrayHelper)
		{
			for (int k = iBegin; k < iEnd; k++)
				arrayHelper[k] = arrayIn[k];
		}

		// ----------------------------------------------------------------------------------------

		private static void Swap(ref int n1, ref int n2)
		{
			int temp = n1;
			n1 = n2;
			n2 = temp;
		}

		private static void Swap(ref Movie n1, ref Movie n2)
		{
			Movie temp = n1;
			n1 = n2;
			n2 = temp;
		}

		private static void RestoreControlValues()
        {
			_comparsions = 0;
			_permutations = 0;
			_milliseconds = DateTime.Now.Millisecond;
		}
	}
}
