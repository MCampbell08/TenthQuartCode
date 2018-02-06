using System;

public class Kata
{
    public static int[,] FloodFill(int[,] array, int y, int x, int newValue)
    {
        if (array[y, x] == newValue)
            return array;

        array[y, x] = newValue;

        if (x > 0 && array[y, x - 1] == array[y, x])
        {
            array[y, x] = newValue;
            FloodFill(array, y, x - 1, newValue);
        }
        if (x < array.GetLength(1) - 1 && array[y, x + 1] == array[y, x])
        {
            array[y, x] = newValue;
            FloodFill(array, y, x + 1, newValue);
        }
        if (y > 0 && array[y - 1, x] == array[y, x])
        {
            array[y, x] = newValue;
            FloodFill(array, y - 1, x, newValue);
        }
        if (y < array.GetLength(0) - 1 && array[y + 1, x] == array[y, x])
        {
            array[y, x] = newValue;
            FloodFill(array, y + 1, x, newValue);
        }


        return array;
    }
}