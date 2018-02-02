using System;

public class Kata
{
    public static int[,] FloodFil(int[,] array, int y, int x, int newValue)
    {
        int xBound = array.GetLength(0);
        int yBound = array.GetLength(1);

        if (y > 0 && array[y, x - 1] == array[x, y])
        {
            array[y, x] = newValue;
            FloodFill(array, y - 1, x, newValue);
        }
        if (x > 0 && array[x - 1, y] == array[x, y])
        {
            array[y, x] = newValue;
            FloodFill(array, y, x - 1, newValue);
        }
        if (y + 1 <= xBound && array[x, y + 1] == array[x, y])
        {
            array[y, x] = newValue;
            FloodFill(array, y + 1, x, newValue);
        }
        if (x + 1 <= yBound && array[x + 1, y] == array[x, y])
        {
            array[y, x] = newValue;
            FloodFill(array, y, x + 1, newValue);
        }
        return array;
    }
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