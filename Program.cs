// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// ----------------Заполнение массива---------------------
int[,,] GetArray(int deep, int row, int col, int minValue, int maxValue)
{
    int count = 0;
    int[,,] res = new int[deep, row, col];
    for (int i = 0; i < deep; i++)
        for (int j = 0; j < row; j++)
            for (int k = 0; k < col; k++)
            {
                while (true)
                {
                    int item = new Random().Next(minValue, maxValue + 1);
                    if (IsAlready(res, count, item) == false)
                    {
                        res[i, j, k] = item;
                        count++;
                        break;
                    }
                }
            }
    return res;
}

// -------------есть ли уже такой элемент?-----------------
bool IsAlready(int[,,] arr, int cnt, int item)
{
    int count = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
        for (int j = 0; j < arr.GetLength(1); j++)
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                if (count == cnt) return false;
                if (arr[i, j, k] == item) return true;
                count++;
            }
    return false; //на всякий случай))) 
}

// -----------------Вывод массива-----------------
void PrintArray3(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                //порядок i,j,k в выводе просто сделан, чтобы было как в примере к задаче
                Console.Write($"{array[i, j, k]}({j},{k},{i}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

Console.Clear();
Console.WriteLine("Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.");
Console.Write("Введите количество столбцов : ");
int columns = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);
Console.Write("Введите глубину : ");
int deep = int.Parse(Console.ReadLine()!);
if (rows * columns * deep <= 90)
{
    int[,,] array = GetArray(deep, rows, columns, 10, 99);
    PrintArray3(array);
}
else Console.WriteLine("Размерность массива должна быть не более 90 элементов.");


// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

// -----------------Вывод массива-----------------
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j].ToString("00")} ");
        }
        Console.WriteLine();
    }
}

int[,] FillSpiral(int row, int col)
{
    int count = 1;
    int step = 0;
    int[,] array = new int[row, col];
    while (true)
    {
        for (int i = 0 + step; i < col - step; i++)
        {
            array[0 + step, i] = count;
            if (count == row * col) return array;
            else count++;
        }

        for (int i = 1 + step; i < row - step; i++)
        {
            array[i, col - 1 - step] = count;
            if (count == row * col) return array;
            else count++;
        }

        for (int i = col - 2 - step; i >= 0 + step; i--)
        {
            array[row - 1 - step, i] = count;
            if (count == row * col) return array;
            else count++;
        }

        for (int i = row - 2 - step; i > 0 + step; i--)
        {
            array[i, 0 + step] = count;
            if (count == row * col) return array;
            else count++;
        }
        step++;
    }
    //return array;
}

//Console.Clear();
Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив.");
Console.Write("Введите количество столбцов : ");
columns = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество строк: ");
rows = int.Parse(Console.ReadLine()!);
//int[,] arraySpiral = FillSpiral(rows, columns);
int[,] arraySpiral = FillSpiral(rows, columns);
PrintArray(arraySpiral);

