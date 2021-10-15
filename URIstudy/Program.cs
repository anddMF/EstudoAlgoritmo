using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace URIstudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------- S T A R T ----------------");
            List<int> numberList = new List<int> { 4, 2, 3, 7, 2, 4, 2 };
            List<int> numberList2 = new List<int> { 2, 1, 3, 5, 3, 2 };
            int sum = 13;

            //FirstDuplicated(numberList2);
            //Uri1061();
            //MatrizHigherNumber();
            PaintBrushMatrix();
            Console.ReadKey();
        }

        // Encontra uma determinada somatória de números dentro da array
        static bool CheckSum(List<int> numberList, int totalSum)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                var elem1 = numberList[i];
                var partialSum = elem1;

                for (int i2 = numberList.FindIndex(a => a == elem1) + 1; i2 < numberList.Count && partialSum < totalSum; i2++)
                {
                    var number = numberList[i2];
                    partialSum += numberList[i2];

                    if (partialSum == totalSum)
                    {
                        Console.WriteLine("Index inicio: " + i + "\nIndex fim: " + i2);
                        return true;
                    }
                }

            }
            return false;
        }

        static bool Uri1061()
        {
            var datevalue1 = new DateTime(2021, 4, 5);
            var datevalue2 = new DateTime(2021, 4, 9);

            var hora1 = "";
            var hora2 = "";

            //Console.WriteLine("Digite hora 1: ");
            hora1 = "08 : 12 : 23";
            var split1 = hora1.Split(':');

            //Console.WriteLine("Digite hora 2: ");
            hora2 = "06 : 13 : 23";
            var split2 = hora1.Split(':');
            TimeSpan ts = new TimeSpan(Convert.ToInt32(split1[0]), Convert.ToInt32(split1[1]), Convert.ToInt32(split1[2]));

            datevalue1 = datevalue1.Date + ts;

            ts = new TimeSpan(Convert.ToInt32(split2[0]), Convert.ToInt32(split2[1]), Convert.ToInt32(split2[2]));
            datevalue2 = datevalue2.Date + ts;

            var hours = (datevalue2 - datevalue1);

            return false;
        }

        // Encontra o primeiro número que se repetir dentro de array
        static bool FirstDuplicated(List<int> numberList)
        {
            var otherList = new List<int>();

            for (int i = 0; i < numberList.Count; i++)
            {
                var repetido = otherList.Find(x => x == numberList[i]);

                // se tiver um valor, significa que encontrou um repetido;
                if (repetido > 0)
                    return true;

                otherList.Add(numberList[i]);
            }

            return false;
        }

        // Devolve o indice linha e coluna do maior número da matriz
        static bool MatrizHigherNumber()
        {
            int[,] matriz = new int[3, 3];
            int[,] array2D = new int[,] { { 1, 2, 4 }, { 3, 4, 12 }, { 5, 6, 6 } };

            int higherNumber = 0;
            int x = 0;
            int y = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var obj = array2D[i, j];
                    Console.Write(obj + " ");

                    if (obj > higherNumber)
                    {
                        higherNumber = obj;
                        x = i;
                        y = j;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Valor mais alto: {higherNumber}, esta na linha {x + 1} e coluna {y + 1}");
            Console.ReadKey();
            return false;
        }

        // Troca a cor de um pixel da matriz (troca o número de uma coordenada) e também a dos adjacentes 
        // com mesma cor desta matriz
        static void PaintBrushMatrix()
        {
            // coordenadas para a pintura
            int x = 4, y = 4;
            // [8,8]
            int[,] matriz = {{1, 1, 1, 2, 5, 1, 1, 1},
                             {1, 1, 4, 2, 2, 7, 0, 0},
                             {1, 0, 0, 1, 6, 0, 1, 1},
                             {1, 2, 2, 2, 2, 0, 1, 0},
                             {1, 1, 1, 2, 2, 0, 1, 0},
                             {1, 1, 1, 2, 2, 2, 2, 0},
                             {1, 1, 1, 1, 1, 2, 1, 1},
                             {1, 1, 1, 1, 1, 2, 2, 1},
                             };

            int numberToChange = matriz[x, y];

            ShowMatrix(matriz, 8, 8);
            Console.WriteLine();

            matriz = PaintCloseOnes(matriz, x, y, numberToChange, 8);

            ShowMatrix(matriz, 8, 8);

            Console.ReadLine();
        }

        // Recursivo para navegar norte, sul, leste e oeste das coordenadas da matriz e ir pintando se
        // atender a condição
        static int[,] PaintCloseOnes(int[,] matrizInicial, int x, int y, int numberToChange, int newNumber)
        {
            int currentNumber = matrizInicial[x, y];

            if (currentNumber == numberToChange)
            {
                matrizInicial[x, y] = newNumber;

                if (x > 0 && x < 7)
                {
                    matrizInicial = PaintCloseOnes(matrizInicial, x - 1, y, numberToChange, newNumber);
                    matrizInicial = PaintCloseOnes(matrizInicial, x + 1, y, numberToChange, newNumber);
                }

                if (y > 0 && y < 7)
                {
                    matrizInicial = PaintCloseOnes(matrizInicial, x, y - 1, numberToChange, newNumber);
                    matrizInicial = PaintCloseOnes(matrizInicial, x, y + 1, numberToChange, newNumber);
                }

                return matrizInicial;
            }

            return matrizInicial;
        }

        static void ShowMatrix(int[,] matriz, int maxX, int maxY)
        {
            Console.WriteLine("---------------");
            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    //int currentNumber = matriz[i, j];
                    //if (currentNumber == numberToChange)
                    //    matriz[i, j] = 3;

                    Console.Write(matriz[i, j] + " ");
                }

                Console.WriteLine("");
            }
            Console.WriteLine("---------------");
        }


    }
}
