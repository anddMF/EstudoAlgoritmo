using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using URIstudy.Models;

namespace URIstudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------- S T A R T ----------------");
            List<int> numberList = new List<int> { 4, 2, 3, 7, 2, 4, 2 };
            List<int> numberList2 = new List<int> { 2, 1, 3, 5, 3, 2 };
            List<int> arr = new List<int> { -4, 3, -9, 0, 4, 1 };
            int sum = 13;

            //List<int> testeMaxTeams = new List<int> { 3, 4, 3, 1, 6, 5 };
            //countMaximumTeams(testeMaxTeams);

            //FirstDuplicated(numberList2);
            //PlusMinus(arr);

            LinkedListN head1 = new LinkedListN();
            LinkedListN head2 = new LinkedListN();

            head1.AddNodeToFront(7);
            head1.AddNodeToFront(3);
            head1.AddNodeToFront(1);


            head2.AddNodeToFront(2);
            head2.AddNodeToFront(1);

            var responde = MergeListsSorted(head1.head, head2.head);
            Console.ReadKey();
        }

        // E01: Encontra uma determinada somatória de números em sequencia dentro da array
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

        // E02
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

        // E03: Encontra o primeiro número que se repetir dentro de array
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

        // E04: Devolve o indice linha e coluna do maior número da matriz
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

        // E05: Troca a cor de um pixel da matriz (troca o número de uma coordenada) e também a dos adjacentes 
        // com mesma cor desta matriz
        static void PaintBrushMatrix()
        {
            // coordenadas para a pintura
            int x = 4, y = 4;
            // [8,8]
            int[,] matriz = {{1, 1, 1, 2, 1, 1, 1, 1},
                             {1, 1, 1, 2, 2, 1, 0, 0},
                             {1, 0, 0, 1, 1, 0, 1, 1},
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

        // E05: Recursivo para navegar norte, sul, leste e oeste das coordenadas da matriz e ir pintando se
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

        // E05
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

        // E06 ainda não resolvido 100%
        public static int countMaximumTeams(List<int> skill, int teamSize = 3, int maxDiff = 2)
        {
            // skill = [3, 4, 3, 1,6, 5]

            int possibleTeams = 0;
            var arr = new List<int> { };

            skill.Sort();

            int differentTeams = skill.Count / teamSize;

            for (int j = 1; j <= differentTeams; j++)
            {
                arr.Add(skill[0]);
                for (int i = 1; i < skill.Count && arr.Count < teamSize; i++)
                {
                    if (skill[0] - skill[i] <= maxDiff)
                    {
                        arr.Add(skill[i]);
                    }
                }

                if (arr.Count == teamSize)
                    possibleTeams++;

                foreach (var value in arr)
                {
                    skill.Remove(value);
                }
                arr = new List<int> { };
            }

            return possibleTeams;
        }

        // E07 retorna fração de números positivos, negativos e zeros dentro da array de entrada, o resultado vem com
        // seis números após a virgula
        public static void PlusMinus(List<int> arr)
        {
            
            List<string> finalList = new List<string>();

            int initiallength = arr.Count;

            double positives = 0;
            double negatives = 0;
            double zeros = 0;
            string fmt = "0.######";

            for (int i = 0; i < initiallength; i++)
            {
                if (arr[i] > 0)
                    positives++;
                else if (arr[i] < 0)
                    negatives++;
                else
                    zeros++;
            }
            string positiveF = (positives / initiallength).ToString(fmt);
            string negativeF = (negatives / initiallength).ToString(fmt);
            string zerosF = (zeros / initiallength).ToString(fmt);

            finalList.AddRange(new[] { positiveF, negativeF, zerosF });


            for (int i = 0; i < finalList.Count; i++)
            {
                if (finalList[i].Length < 8)
                {
                    while (finalList[i].Length < 8)
                    {
                        finalList[i] = finalList[i] + "0";
                    }
                }
                Console.WriteLine(finalList[i]);
            }
            Console.ReadLine();
        }

        // E08
        public static void MiniMaxSum()
        {
            List<int> arr = new List<int> {  3, 7, 1, 5, 9 };

            arr.Sort();

            int response = 0;

            for(int i = 0; i < arr.Count; i++)
            {
                response += arr[i];
            }

            Console.WriteLine("Min" + (response - arr.Last()) + " Max: " + (response - arr.First()));
        }

        public static void LinkedListExample()
        {
            LinkedList<string> list = new LinkedList<string>();

            list.AddFirst("Sofá");
            list.AddFirst("Televisão");
            list.AddFirst("Poltrona");
            list.AddLast("Mesa");

            LinkedListNode<string> node = list.Find("Televisão");
            list.AddAfter(node, "Tapete");

            foreach(string item in list)
            {
                Console.WriteLine("Item: {0}", item);
            }
        }

        //E09 Retorna uma lista com a contagem de quantas vezes cada item da queries aparece na input,
        // no exemplo comentado a resposta seria [2,1,0]
        public static List<int> SparseArrays(List<string> input, List<string> queries)
        {
            //List<string> input = new List<string> {"ab", "ab", "abc"};
            //List<string> queries = new List<string> {"ab", "abc", "bc"};

            List<int> result = new List<int>();

            for(int i = 0; i < queries.Count; i++)
            {
                var finded = input.FindAll(a => a == queries[i]);

                result.Add(finded.Count);
            }

            return result;
        }

        //E10 Identifica o elemento que não se repete na array de entrada
        public static int LonelyInteger(List<int> a)
        {
            //List<int> a = new List<int> { 1, 2, 3, 4, 3, 2, 1 };

            for(int i = 0; i < a.Count; i++)
            { 
                List<int> element = a.FindAll(number => number == a[i]);

                if (element.Count == 1)
                    return a[i];
            }

            return -1;
        }

        public static void TesteLinkedList()
        {
            LinkedListN list = new LinkedListN();
            LinkedListN list2 = new LinkedListN();

            list.AddNodeToFront(8);
            list.AddNodeToFront(3);
            list.AddNodeToFront(4);

            list.AddNodeToBack(7);

            list.DeleteNodeFromFront();

            list.PrintNodes();

        }

        // E11 
        public static LinkedListNodeN MergeListsSorted(LinkedListNodeN head1, LinkedListNodeN head2)
        {
            var runner1 = head1;
            var runner2 = head2;
            var initial = new LinkedListNodeN();

            if(head1.data <= head2.data)
            {
                initial = head1;
                runner1 = runner1.next;
            } else
            {
                initial = head2;
                runner2 = runner2.next;
            }

            LinkedListNodeN response = new LinkedListNodeN(initial.data);
            LinkedListNodeN responseRunner = response;

            while(runner1 != null && runner2 != null)
            {
                if(runner1 != null && runner1.data <= runner2.data)
                {
                    responseRunner.next = new LinkedListNodeN { data = runner1.data, next = null };
                    runner1 = runner1.next;
                } else if (runner2 != null && runner2.data <= runner1.data)
                {

                    responseRunner.next = new LinkedListNodeN { data = runner2.data, next = null };
                    runner2 = runner2.next;
                }
                responseRunner = responseRunner.next;
            }

            if (runner1 == null)
                responseRunner.next = runner2;
            else
                responseRunner.next = runner1;

            return response;
        }
    }
}
