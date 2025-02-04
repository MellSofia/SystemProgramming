using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[10];

        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            array[i] = random.Next(1, 100);
        }
        Console.WriteLine("Массив: " + string.Join(", ", array));


        QuickSort(array, 0, array.Length - 1);

        Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
    }

    static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            Parallel.Invoke(
                () => QuickSort(array, low, pivotIndex - 1),
                () => QuickSort(array, pivotIndex + 1, high)
            );
        }
    }

    static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }
        Swap(array, i + 1, high);
        return i + 1;
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}