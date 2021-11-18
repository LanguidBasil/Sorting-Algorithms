using System;
using System.Collections.Generic;

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


			// algorithm
			List<int> bigger;
			List<int> smaller;
			int stepLength = 1;

			while (stepLength < arrayIn.Length)
			{
				MergeSplit(arrayIn, out bigger, out smaller, stepLength);

				MergeJoin(ref arrayIn, bigger, smaller, stepLength);

				stepLength *= 2;
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			return (_comparsions, _permutations, _milliseconds);
		}

		private static void MergeSplit(in int[] arrayIn, out List<int> bigger, out List<int> smaller, int stepLength)
		{
			bigger = new List<int>();
			smaller = new List<int>();
			int sum0 = 0;
			int sum1 = 0;

			int amountOfPairs = arrayIn.Length / stepLength / 2;

			for (int i = 0; i < amountOfPairs; i++)
			{
				for (int j = 0; j < stepLength; j++)
				{
					sum0 += arrayIn[(i * 2) * stepLength + j];
					sum1 += arrayIn[(i * 2 + 1) * stepLength + j];
				}

				for (int j = 0; j < stepLength; j++)
				{
					_comparsions++;
					if (sum0 > sum1)
					{
						bigger.Add(arrayIn[(i * 2) * stepLength + j]);
						smaller.Add(arrayIn[(i * 2 + 1) * stepLength + j]);
					}
					else
					{
						bigger.Add(arrayIn[(i * 2) * stepLength + j]);
						smaller.Add(arrayIn[(i * 2 + 1) * stepLength + j]);
					}
				}

				sum0 = 0;
				sum1 = 0;
			}

			int elementsLeft = arrayIn.Length - amountOfPairs * 2 * stepLength;
			if (elementsLeft > 0)
			{
				for (int j = 0; j < elementsLeft; j++)
				{
					if (j < stepLength)
						sum0 += arrayIn[arrayIn.Length - elementsLeft + j];
					else
						sum1 += arrayIn[arrayIn.Length - elementsLeft + j];
				}

				for (int j = 0; j < elementsLeft; j++)
				{
					_comparsions++;
					if (sum0 > sum1)
					{
						if (j < stepLength)
						{
							bigger.Add(arrayIn[arrayIn.Length - elementsLeft + j]);
						}
						else
						{
							smaller.Add(arrayIn[arrayIn.Length - elementsLeft + j]);
						}
					}
					else
					{
						if (j < stepLength)
						{
							smaller.Add(arrayIn[arrayIn.Length - elementsLeft + j]);
						}
						else
						{
							bigger.Add(arrayIn[arrayIn.Length - elementsLeft + j]);
						}
					}
				}
			}
		}

		private static void MergeJoin(ref int[] arrayIn, in List<int> bigger, in List<int> smaller, int stepLength)
		{
			int amountOfPairs = arrayIn.Length / stepLength / 2;
			int[] numbersToSort;

			for (int i = 0; i < amountOfPairs; i++)
			{
				numbersToSort = new int[stepLength * 2];

				for (int j = 0; j < stepLength; j++)
				{
					numbersToSort[j * 2] = bigger[i * stepLength + j];
					numbersToSort[j * 2 + 1] = smaller[i * stepLength + j];
				}

				Bubble(ref numbersToSort);

				for (int j = 0; j < numbersToSort.Length; j++)
					arrayIn[i * numbersToSort.Length + j] = numbersToSort[j];
			}

			int elementsLeft = arrayIn.Length - amountOfPairs * 2 * stepLength;
			int ntsIndex = 0;
			numbersToSort = new int[elementsLeft];

			for (int i = amountOfPairs * stepLength; i < bigger.Count; i++)
			{
				numbersToSort[ntsIndex] = bigger[i];
				ntsIndex++;
			}
			for (int i = amountOfPairs * stepLength; i < smaller.Count; i++)
			{
				numbersToSort[ntsIndex] = smaller[i];
				ntsIndex++;
			}

			Bubble(ref numbersToSort);
			for (int j = 0; j < numbersToSort.Length; j++)
			{
				_permutations++;
				arrayIn[arrayIn.Length - numbersToSort.Length + j] = numbersToSort[j];
			}
		}


		public static (int, int, float) NaturalMerge(ref int[] arrayIn)
		{
			RestoreControlValues();


			// algorithm
			List<int> listA;
			List<int> listB;

			while (!IsSortedAscending(arrayIn))
			{
				NaturalMergeSplit(arrayIn, out listA, out listB);

				NaturalMergeJoin(ref arrayIn, listA, listB);
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			return (_comparsions, _permutations, _milliseconds);
		}

		private static void NaturalMergeSplit(in int[] arrayIn, out List<int> listA, out List<int> listB)
		{
			listA = new List<int>();
			listB = new List<int>();

			var currentList = listA;
			currentList.Add(arrayIn[0]);
			for (int i = 1; i < arrayIn.Length; i++)
			{
				_comparsions++;
				if (arrayIn[i] >= arrayIn[i - 1])
				{
					currentList.Add(arrayIn[i]);
				}
				else
				{
					currentList = currentList == listA ? listB : listA;
					currentList.Add(arrayIn[i]);
				}
			}
		}

		private static void NaturalMergeJoin(ref int[] arrayIn, in List<int> listA, in List<int> listB)
		{
			int aIndex = 0;
			int bIndex = 0;
			for (int i = 0; i < arrayIn.Length; i++)
			{
				if (aIndex >= listA.Count)
				{
					arrayIn[i] = listB[bIndex];
					bIndex++;
				}
				else if (bIndex >= listB.Count)
				{
					arrayIn[i] = listA[aIndex];
					aIndex++;
				}
				else if (listA[aIndex] <= listB[bIndex])
				{
					_comparsions++;
					arrayIn[i] = listA[aIndex];
					aIndex++;
				}
				else
				{
					_comparsions++;
					arrayIn[i] = listB[bIndex];
					bIndex++;
				}
				_permutations++;
			}
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


			// algorithm
			List<Movie> bigger;
			List<Movie> smaller;
			int stepLength = 1;

			while (stepLength < arrayIn.Length)
			{
				MergeSplit(arrayIn, out bigger, out smaller, stepLength);

				MergeJoin(ref arrayIn, bigger, smaller, stepLength);

				stepLength *= 2;
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			return (_comparsions, _permutations, _milliseconds);
		}

		private static void MergeSplit(in Movie[] arrayIn, out List<Movie> bigger, out List<Movie> smaller, int stepLength)
		{
			bigger = new List<Movie>();
			smaller = new List<Movie>();
			int sum0 = 0;
			int sum1 = 0;

			int amountOfPairs = arrayIn.Length / stepLength / 2;

			for (int i = 0; i < amountOfPairs; i++)
			{
				for (int j = 0; j < stepLength; j++)
				{
					sum0 += arrayIn[(i * 2) * stepLength + j].Year;
					sum1 += arrayIn[(i * 2 + 1) * stepLength + j].Year;
				}

				for (int j = 0; j < stepLength; j++)
				{
					_comparsions++;
					if (sum0 > sum1)
					{
						bigger.Add(arrayIn[(i * 2) * stepLength + j]);
						smaller.Add(arrayIn[(i * 2 + 1) * stepLength + j]);
					}
					else
					{
						bigger.Add(arrayIn[(i * 2) * stepLength + j]);
						smaller.Add(arrayIn[(i * 2 + 1) * stepLength + j]);
					}
				}

				sum0 = 0;
				sum1 = 0;
			}

			int elementsLeft = arrayIn.Length - amountOfPairs * 2 * stepLength;
			if (elementsLeft > 0)
			{
				for (int j = 0; j < elementsLeft; j++)
				{
					if (j < stepLength)
						sum0 += arrayIn[arrayIn.Length - elementsLeft + j].Year;
					else
						sum1 += arrayIn[arrayIn.Length - elementsLeft + j].Year;
				}

				for (int j = 0; j < elementsLeft; j++)
				{
					_comparsions++;
					if (sum0 > sum1)
					{
						if (j < stepLength)
						{
							bigger.Add(arrayIn[arrayIn.Length - elementsLeft + j]);
						}
						else
						{
							smaller.Add(arrayIn[arrayIn.Length - elementsLeft + j]);
						}
					}
					else
					{
						if (j < stepLength)
						{
							smaller.Add(arrayIn[arrayIn.Length - elementsLeft + j]);
						}
						else
						{
							bigger.Add(arrayIn[arrayIn.Length - elementsLeft + j]);
						}
					}
				}
			}
		}

		private static void MergeJoin(ref Movie[] arrayIn, in List<Movie> bigger, in List<Movie> smaller, int stepLength)
		{
			int amountOfPairs = arrayIn.Length / stepLength / 2;
			Movie[] moviesToSort;

			for (int i = 0; i < amountOfPairs; i++)
			{
				moviesToSort = new Movie[stepLength * 2];

				for (int j = 0; j < stepLength; j++)
				{
					moviesToSort[j * 2] = bigger[i * stepLength + j];
					moviesToSort[j * 2 + 1] = smaller[i * stepLength + j];
				}

				Bubble(ref moviesToSort);

				for (int j = 0; j < moviesToSort.Length; j++)
					arrayIn[i * moviesToSort.Length + j] = moviesToSort[j];
			}

			int elementsLeft = arrayIn.Length - amountOfPairs * 2 * stepLength;
			int ntsIndex = 0;
			moviesToSort = new Movie[elementsLeft];

			for (int i = amountOfPairs * stepLength; i < bigger.Count; i++)
			{
				moviesToSort[ntsIndex] = bigger[i];
				ntsIndex++;
			}
			for (int i = amountOfPairs * stepLength; i < smaller.Count; i++)
			{
				moviesToSort[ntsIndex] = smaller[i];
				ntsIndex++;
			}

			Bubble(ref moviesToSort);
			for (int j = 0; j < moviesToSort.Length; j++)
			{
				_permutations++;
				arrayIn[arrayIn.Length - moviesToSort.Length + j] = moviesToSort[j];
			}
		}


		public static (int, int, float) NaturalMerge(ref Movie[] arrayIn)
		{
			RestoreControlValues();


			// algorithm
			List<Movie> listA;
			List<Movie> listB;

			while (!IsSortedAscending(arrayIn))
			{
				NaturalMergeSplit(arrayIn, out listA, out listB);

				NaturalMergeJoin(ref arrayIn, listA, listB);
			}
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;


			return (_comparsions, _permutations, _milliseconds);
		}

		private static void NaturalMergeSplit(in Movie[] arrayIn, out List<Movie> listA, out List<Movie> listB)
		{
			listA = new List<Movie>();
			listB = new List<Movie>();

			var currentList = listA;
			currentList.Add(arrayIn[0]);
			for (int i = 1; i < arrayIn.Length; i++)
			{
				_comparsions++;
				if (arrayIn[i].Year >= arrayIn[i - 1].Year)
				{
					currentList.Add(arrayIn[i]);
				}
				else
				{
					currentList = currentList == listA ? listB : listA;
					currentList.Add(arrayIn[i]);
				}
			}
		}

		private static void NaturalMergeJoin(ref Movie[] arrayIn, in List<Movie> listA, in List<Movie> listB)
		{
			int aIndex = 0;
			int bIndex = 0;
			for (int i = 0; i < arrayIn.Length; i++)
			{
				if (aIndex >= listA.Count)
				{
					arrayIn[i] = listB[bIndex];
					bIndex++;
				}
				else if (bIndex >= listB.Count)
				{
					arrayIn[i] = listA[aIndex];
					aIndex++;
				}
				else if (listA[aIndex].Year <= listB[bIndex].Year)
				{
					_comparsions++;
					arrayIn[i] = listA[aIndex];
					aIndex++;
				}
				else
				{
					_comparsions++;
					arrayIn[i] = listB[bIndex];
					bIndex++;
				}
				_permutations++;
			}
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

		private static bool IsSortedAscending(in int[] arrayIn)
		{
			for (int i = 1; i < arrayIn.Length; i++)
				if (arrayIn[i] < arrayIn[i - 1])
					return false;

			return true;
		}

		private static bool IsSortedAscending(in Movie[] arrayIn)
		{
			for (int i = 1; i < arrayIn.Length; i++)
				if (arrayIn[i].Year < arrayIn[i - 1].Year)
					return false;

			return true;
		}
	}
}
