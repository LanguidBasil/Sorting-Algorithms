using System;

namespace Lab1
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

			Quick_Algo(ref arrayIn, 0, arrayIn.Length - 1);
			_milliseconds = DateTime.Now.Millisecond - _milliseconds;
			
			return (_comparsions, _permutations, _milliseconds);
		}

		private static void Quick_Algo(ref int[] a, int start, int finish)
		{
			if (start < finish)
			{
				int q = Quick_Partition(a, start, finish);
				Quick_Algo(ref a, start, q);
				Quick_Algo(ref a, q + 1, finish);
			}
		}

		private static int Quick_Partition(int[] a, int p, int r)
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

		// ----------------------------------------------------------------------------------------

		private static void Swap(ref int n1, ref int n2)
		{
			int temp = n1;
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
