using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using URIstudy.Models;
using System.Collections;

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
            //int result = WordLadder("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });

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

            //ShowMatrix(matriz, 8, 8);
            Console.WriteLine();

            matriz = PaintCloseOnes(matriz, x, y, numberToChange, 8);

            ShowMatrix(matriz, 8, 8);

            Console.ReadLine();
        }

        // E05-COMPLEMENTO: Recursivo para navegar norte, sul, leste e oeste das coordenadas da matriz e ir pintando se
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

        // E05-COMPLEMENTO
        static void ShowMatrix(int[,] matriz, int maxX, int maxY) // 4    5
        {
            Console.WriteLine("---------------");
            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
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
            List<int> arr = new List<int> { 3, 7, 1, 5, 9 };

            arr.Sort();

            int response = 0;

            for (int i = 0; i < arr.Count; i++)
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

            foreach (string item in list)
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

            for (int i = 0; i < queries.Count; i++)
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

            for (int i = 0; i < a.Count; i++)
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

        // E11 Recebe duas linked lists e retorna uma unica com os elementos ordenados de ambas. Premissa dos inputs estarem ordenados
        public static LinkedListNodeN MergeListsSorted(LinkedListNodeN head1, LinkedListNodeN head2)
        {
            var runner1 = head1;
            var runner2 = head2;
            var initial = new LinkedListNodeN();

            if (head1.data <= head2.data)
            {
                initial = head1;
                runner1 = runner1.next;
            }
            else
            {
                initial = head2;
                runner2 = runner2.next;
            }

            LinkedListNodeN response = new LinkedListNodeN(initial.data);
            LinkedListNodeN responseRunner = response;

            while (runner1 != null && runner2 != null)
            {
                if (runner1 != null && runner1.data <= runner2.data)
                {
                    responseRunner.next = new LinkedListNodeN { data = runner1.data, next = null };
                    runner1 = runner1.next;
                }
                else if (runner2 != null && runner2.data <= runner1.data)
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

        // E12 Exercicio meio especifico, 'Queue using two stacks' do harcker rank
        public static void QueueExercise()
        {
            QueueN<int> queue = new QueueN<int>();
            int queries = 0;
            int value = 0;
            string cmd = "";

            Console.Write("numero queries ");
            queries = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < queries; i++)
            {
                Console.Write("Comando: ");
                cmd = Console.ReadLine();
                var split = cmd.Split(' ');

                if (split.Length > 1)
                {
                    queue.Enqueue(Convert.ToInt32(split[1]));
                }

                if (Convert.ToInt32(split[0]) == 2)
                    queue.Dequeue();

                if (Convert.ToInt32(split[0]) == 3)
                    queue.PrintFirstElement();

            }
        }

        // E13
        public static string AreBracketsBalanced()
        {
            string response = "YES";
            string querie = Console.ReadLine();
            Stack<string> stack = new Stack<string>();

            var split = querie.ToCharArray();

            if ((split.Length % 2) > 0)
                return response = "NO";

            for (int i = 0; i < split.Length; i++)
            {
                string currentBracket = split[i].ToString();

                if (currentBracket == "{" || currentBracket == "[" || currentBracket == "(")
                {
                    stack.Push(currentBracket);
                }
                else
                {
                    var peek = stack.Peek();

                    if (currentBracket == "}" && peek == "{")
                        stack.Pop();
                    else if (currentBracket == "]" && peek == "[")
                        stack.Pop();
                    else if (currentBracket == ")" && peek == "(")
                        stack.Pop();
                    else
                        response = "NO";

                }

                if (response == "NO")
                    return response;

            }

            return response;
        }

        // E14 Encontra caracteres de uma string dentro de uma matriz e salva as coordenadas numa hastable
        public static void FindStringInMatrix()
        {
            string[,] matrix = {{"D", "E", "M", "X", "B"},
                                {"A", "O", "E", "P", "E"},
                                {"D", "D", "C", "O", "D"},
                                {"E", "B", "E", "D", "S"},
                                {"C", "P", "Y", "E", "N"},
                                {"A", "2", "3", "4", "5"}
                                };

            string queryToFind = "CODE";

            // IDEIA: usar dfs, começar do primeiro mesmo e usar recursão pra navegar primeiro em tudo pra baixo e depois pra direita.
            // diferente do flood fill, como inicio na 0,0 posso navegar somenta sul e leste

            NavigateMatrix(matrix, 0, 0, queryToFind);
        }

        // E14-COMPLEMENTO
        public static void NavigateMatrix(string[,] matrix, int y, int x, string query)
        {
            int edgeY = matrix.GetLength(0); // Retorna y 6
            int edgeX = matrix.GetLength(1); // Retorna x 5

            Hashtable htResponse = new Hashtable();

            var queryArr = query.ToList();

            for (int i = 0; i < edgeY; i++)
            {
                for (int j = 0; j < edgeX; j++)
                {
                    var current = matrix[i, j];

                    var find = queryArr.Find(letter => letter.ToString() == current).ToString();

                    if (find != "\0")
                    {
                        if (!htResponse.ContainsKey(find))
                            htResponse.Add(find, j + "," + i);
                        else
                            htResponse[find] = htResponse[find] + "; " + j + "," + i;
                    }

                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine("");
            }
        }

        // E15 Calcula a diferença das diagonais de uma matriz quadrática
        public static int DiagonalDifference()
        {
            // outro jeito de fazer matriz
            List<List<int>> arr = new List<List<int>>();
            arr.Add(new List<int> { 1, 2, 3, 4 });
            arr.Add(new List<int> { 5, 6, 7, 8 });
            arr.Add(new List<int> { 9, 10, 11, 12 });
            arr.Add(new List<int> { 13, 14, 15, 16 });

            int lastIndex = arr.Count - 1;
            int firstIndex = 0;

            int leftDiagonal = 0;
            int rightDiagonal = 0;


            for (int i = 0; i < arr.Count; i++)
            {
                List<int> currentArr = arr[i];

                rightDiagonal += currentArr[lastIndex];

                leftDiagonal += currentArr[firstIndex];

                firstIndex++;
                lastIndex--;
            }

            return System.Math.Abs(leftDiagonal - rightDiagonal);
        }

        // E16 Encontra o menor caminho na transformacao da beginWord para a endWord usando a worList e podendo alterar somente um caracter por vezes
        public static int WordLadder(string beginWord, string endWord, List<string> wordList)
        {
            //string beginWord = "hit";
            //string endWord = "cog";
            //List<string> wordList = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            var supList = new List<string> { beginWord };

            if (!wordList.Contains(endWord))
                return 0;

            string last = beginWord;

            while (wordList.Count > 0)
            {
                var lastChar = last.ToCharArray().ToList();
                string result = CheckIntersect(wordList, lastChar);

                if (result == "")
                {
                    // significa que nao encontrou na lista, nunca vai cair nisso visto que valida o ultimo mas para caso eu use no futuro
                    return 0;
                }
                else
                {
                    supList.Add(result);

                    if (result == wordList.Last())
                        return supList.Count;

                    last = result;
                    wordList.RemoveAt(wordList.FindIndex(x => x == result));
                }
            }

            return 0;
        }

        // E16-COMPLEMENTO Pega a lista disponivel de palavras e checa se com apenas um alterado já chega no final da transformation, caso nao
        // checa pela resto da wordList a mesma coisa para ir avancando na mesma
        public static string CheckIntersect(List<string> wordList, List<char> lastChar)
        {
            // tem que achar o caminho mais curto para a transformation, entao preciso sempre checar com a ultima palavra da lista se ja consigo finalizar
            var lastTransformation = wordList.Last().ToCharArray().ToList();
            var final = lastTransformation.Intersect(lastChar);
            if (final.Count() == lastChar.Count - 1)
                return wordList.Last();

            foreach (string word in wordList)
            {
                var sup = word.ToCharArray().ToList();
                // checa por elementos da lastChar dentro da sup
                var result = sup.Intersect(lastChar);

                if (result.Count() == lastChar.Count - 1)
                    return word;
            }

            return "";
        }

        // E17 https://www.interviewbit.com/problems/gas-station
        public static int CanCompleteCircuit()
        {
            List<int> A = new List<int> { 1, 2, 2 };
            List<int> B = new List<int> { 2, 1, 2 };
            int gasUnit = 0;
            int initialIndex = -1;

            // A = quantidade de gás disponivel no posto
            // B = quantidade de gás necessária para o proximo posto

            //checa se gasUnit + A[i] <= B[i] pra saber se consegue ir para o próximo posto
            // a subtração de (gasUnit + A[i]) - B[i] tem que sempre ser positiva

            for (int i = 0; i < A.Count && initialIndex != i; i++)
            {
                if (initialIndex == -1)
                    initialIndex = i;

                gasUnit = gasUnit + (A[i] - B[i]);

                // ficou sem combustivel para o posto, entao posso reiniciar a partir de outro
                if (gasUnit < 0)
                {
                    if (initialIndex == A.Count - 1)
                        return -1;

                    i = initialIndex;
                    // passo -1 para ele alterar o initial index e não sair da condição do FOR initialIndex != i
                    initialIndex = -1;
                    gasUnit = 0;
                }
                else
                {
                    // para voltar ao inicio do array
                    if (i == A.Count - 1)
                        i = -1;
                }

            }

            return initialIndex;
        }

        // E18 Retorna o elemento que aparece mais em uma array de tamanho n, para ter o resultado o elemento precisa aparecer mais do que floor(n/2)
        public static int MajorityElement(List<int> A)
        {
            //List<int> A = new List<int> { 2, 1, 2 };
            int n = A.Count / 2;
            int result = 0;

            for (int i = 0; i < A.Count; i++)
            {
                var partialResult = A.FindAll(x => x == A[i]);

                if (partialResult.Count > n)
                {
                    result = A[i];
                    return result;
                }
            }

            return result;
        }

        // E19 Recebe uma lista com preços de stocks dia a dia, o método retorna o 'valor' com máximo de lucro possível a partir da lista fazendo operações de compra
        // e venda nos períodos de baixa e alta. Só pode fazer uma compra por vez, sem operações paralelas.
        public int MaxProfit(List<int> A)
        {
            int result = 0;

            // começo o for a partir do i = 1 porque estou comparando com o elementao anterior para tirar a diferença do valor caso seja maior.
            for (int i = 1; i < A.Count; i++)
            {
                // como eu posso vender e comprar no mesmo dia (A[i]), tiro a diferença do resultado comparando somente com o dia anterior (compra e venda)
                if (A[i] > A[i - 1])
                    result += A[i] - A[i - 1];
            }

            return result;
        }

        // E20 Deleta nodes duplicados em uma sorted linkedList
        public static ListNode DeleteDuplicates()
        {
            var list = new List<int> { 1, 1, 2, 3, 3 };
            ListNode A = new ListNode(list[0]);
            var current = A;
            // como o current eu vou correr, o result armazena o head dele
            var result = current;

            // montei uma linkedList aqui mas é para receber de param
            for (int i = 1; i < list.Count; i++)
            {
                A.next = new ListNode(list[i]);
                A = A.next;
            }

            // essa temp serve para usar o next.next e pular um node
            ListNode temp = new ListNode(A.val);

            while (current.next != null)
            {
                // valor repetido
                if (current.next.val == current.val)
                {
                    temp = current.next.next;
                    current.next = null;
                    current.next = temp;
                }
                else
                {
                    current = current.next;
                }
            }
            return result;
        }

        // E20-COMPLEMENTO
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { this.val = x; this.next = null; }
        }

        // E21 Inverte elementos de dois em dois dentro de uma linkedList. Entao de eu tenho a lista 1 -> 2 -> 3 -> 4 ela vira 2 -> 1 -> 4 -> 3
        public static ListNode SwapNodesInPair()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            ListNode A = new ListNode(list[0]);
            var current = A;
            // como o current eu vou correr, o result armazena o head dele
            var result = current;

            // montei uma linkedList aqui mas é para receber de param
            for (int i = 1; i < list.Count; i++)
            {
                A.next = new ListNode(list[i]);
                A = A.next;
            }


            while (current != null)
            {
                // if necessário para caso venha uma linkedList com numero de elementos ímpar
                if (current.next != null)
                {
                    int nextVal = current.next.val;
                    current.next.val = current.val;
                    current.val = nextVal;

                    current = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return result;
        }

        // E22 encontra o valor do B° node saindo da metade para o inicio da linkedList. Se nao tiver como, ou seja, da metade da linkedList para o inicio nao existir B elementos, retorna -1;
        public static int KthNodeFromMiddle(ListNode A, int B)
        {
            //int B = 3;
            //var list = new List<int> { 1, 14, 6, 16, 4, 10 };
            //ListNode A = new ListNode(list[0]);
            var current = A;
            var numbers = new List<int>();
            int result = 0;

            // montei uma linkedList aqui mas é para receber de param
            //for (int i = 1; i < list.Count; i++)
            //{
            //    A.next = new ListNode(list[i]);
            //    A = A.next;
            //}

            while (current != null)
            {
                numbers.Add(current.val);
                current = current.next;
            }

            int halfLength = (numbers.Count / 2);
            if (B > halfLength)
                result = -1;
            else
                result = numbers[halfLength - B];

            return result;
        }

        // E23 Junta e ordena duas linkedLists em uma.
        public static ListNode MergeTwoSortedLinkedLists()
        {
            var list = new List<int> { 5, 8, 20 };
            ListNode A = new ListNode(list[0]);

            var listB = new List<int> { 4, 11, 15 };
            ListNode B = new ListNode(listB[0]);

            var runner1 = A;
            var runner2 = B;
            int initial = 0;

            // criar as linkedLists mas são parametros
            for (int i = 1; i < list.Count; i++)
            {
                A.next = new ListNode(list[i]);
                A = A.next;
            }

            for (int i = 1; i < listB.Count; i++)
            {
                B.next = new ListNode(listB[i]);
                B = B.next;
            }

            if (runner1.val <= runner2.val)
            {
                initial = runner1.val;
                runner1 = runner1.next;
            }
            else
            {
                initial = runner2.val;
                runner2 = runner2.next;
            }

            var current = new ListNode(initial);

            // como o current eu vou correr, o result armazena o head dele
            var result = current;

            while (runner1 != null || runner2 != null)
            {
                if (runner1 == null)
                {
                    current.next = runner2;
                    return result;
                }

                if (runner2 == null)
                {
                    current.next = runner1;
                    return result;
                }

                if (runner1.val <= runner2.val)
                {
                    current.next = new ListNode(runner1.val);
                    runner1 = runner1.next;
                    current = current.next;
                }
                else
                {
                    current.next = new ListNode(runner2.val);
                    runner2 = runner2.next;
                    current = current.next;
                }
            }

            return result;
        }

        // E24 Recebe quantos degraus de uma escada irá subir pelo int A, só pode subir 1 ou 2 degraus de uma vez. Sabendo disso, o código 
        // retorna quantas maneiras distintas consegue subir A degraus.
        public static int ClimbStairs(int A)
        {
            var dp = new int[ A + 1 >= 3 ? A + 1 : 3];

            // dp para resolver sub problems, jeito de subir zero degrau é 1, de subir um degrau é 1 e de subir dois degraus é 2 ([1,1], [2])
            // uso essas resoluções de sub para ter base na fórmula dos ´próximos degraus
            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 2;

            if (dp.Length >= A && dp[A] != 0)
                return dp[A];

            for(int i = 3; i <= A; i++)
            {
                // como o máximo que pode subir é 2 degraus por vez, para chegar em determinado degrau ele soma quantas formas existem para
                // chegar em dois degraus antes [i - 2] com um degrau antes [i - 1]
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[A];
        }

        // E25 Dentro de uma lista, encontra a maior sequencia crescente de subarray
        public static int LongestIncreasingSubArray()
        {
            var A = new List<int> { 1, 2, 1, 5 };

            if (A.Count == 1)
                return 1;

            // uso hashtable para usar keys e values, armazeno nas keys o indice de cada item da lista, depois eu ordeno a lista
            // mas mantenho os indices para fazer a verificação da sub-array crescente mais longa
            var ht = new Hashtable();
            for (int i = 0; i < A.Count; i++)
            {
                ht.Add(i, A[i]);
            }
            // arrays necessárias para conseguir ordenar as keys juntamente com os values, já que só os values precisam estar na ordem crescente
            int[] arrValues = new int[ht.Count];
            int[] arrKeys = new int[ht.Count];

            ht.Keys.CopyTo(arrKeys, 0);
            ht.Values.CopyTo(arrValues, 0);

            Array.Sort(arrValues, arrKeys);

            int counter = 0;
            int result = 0;
            int currentKey = 0;

            // faz a contagem da sequencia mais longa comparando um item inicial com o resto da lista;
            for(int j = 0; j < arrKeys.Length; j++)
            {
                if (j == arrKeys.Length - 1)
                    return result;

                counter++;
                currentKey = arrKeys[j];
                for(int k = j + 1; k < arrKeys.Length; k++)
                {
                    if (arrKeys[k] > currentKey)
                    {
                        counter++;
                        currentKey = arrKeys[k];
                    }
                }

                if (counter > result)
                    result = counter;

                counter = 0;
            }

            return result;
        }

        // E26 A partir de uma lista onde os ith são os preços das ações em cada dia, determina, com apenas uma operações de compra e venda, o maior lucro que se pode obter
        public static int MaxProfitOneOperation()
        {
            var A = new List<int> { 2,1 };
            if (A.Count == 0)
                return 0;

            int result = 0;
            for (int i = 0; i < A.Count; i++)
            {
                int current = A[i];

                for (int j = i; j < A.Count; j++)
                {
                    if (A[j] > current)
                    {
                        int sub = A[j] - current;
                        result = sub > result ? sub : result;
                    }
                }
            }

            return result;
        }

        // E27 Kadane's Algorithm, encontrar a maior soma em uma subarray continua e retornar esse valor.
        //Exemplo: input = [1,2,3,4,-10] vai ter como resposta o 10 porque 1+2+3+4 é a maior soma possível
        //dentro do array.
        public static int MaxSubArray(List<int> a)
        {
            //var A = new List<int> { 1, 2, 3, 4, -10 };
            int currentMax = a[0];
            int totalMax = a[0];

            for(int i = 1; i < a.Count; i++)
            {
                // currentMax assume o que é maior: a soma dos subarrays anteriores + o atual,
                //ou somente o atual pois apenas um elemento também considerado subarray
                currentMax = System.Math.Max(a[i], currentMax + a[i]);

                if (currentMax > totalMax)
                    totalMax = currentMax;
            }

            return totalMax;   
        }

        // E28 Retornar o duplicado na lista mas utilizando O(n) no tempo e traversing sequencial O(1)
        public static int RepeatedNumber(List<int> A)
        {
            // Ordeno a lista para poder comparar com o anterior e não precisar de find ou outro for
            A.Sort();
            int previous = A[0];
            for(int i = 1; i < A.Count; i++)
            {
                if (A[i] == previous)
                    return A[i];

                previous = A[i];
            }
            return -1;
        }

        public static ListNode RemoveNthFromEnd(int B)
        {
            var list = new List<int> { 1,2,3,4,5 };
            ListNode listA = new ListNode(list[0]);
            var A = listA;
            // como o current eu vou correr, o result armazena o head dele
            var runner = A;
            ListNode result = new ListNode(0);
            ListNode head = result;
            int length = 0;
            
            int count = 0;

            // montei uma linkedList aqui mas é para receber de param
            for (int i = 1; i < list.Count; i++)
            {
                listA.next = new ListNode(list[i]);
                listA = listA.next;
            }

            while(A != null)
            {
                A = A.next;
                length++;
            }

            // subtrai o length com o que vem do B, roda de novo a lista e quando chegar no node, remove
            int subtraction = length - B;

            //if(subtraction == 0)
            //    return result;

            if (subtraction <= 0)
            {
                result = runner.next;
                return result;
            }
            

            while (runner != null)
            {
                if (count != subtraction)
                {
                    result.next = runner;
                    result = runner;
                }

                runner = runner.next;
                count++;
            }

            if (subtraction <= 0)
            {
                // remove o primeiro
                var next = runner.next.next;
                runner.val = runner.next.val;
                runner.next = null;
                runner.next = next;
            } else
            {
                while(runner.next != null)
                {
                    if(count == subtraction)
                    {
                        var next = runner.next.next;
                        runner.val = runner.next.val;
                        runner.next = null;
                        runner.next = next;
                        return result;
                    }
                        
                    runner = runner.next;
                    count++;
                }
            }

            return head.next;
        }

        public int GetLength(ListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }

            return len;
        }

        public ListNode removeNthFromEnd(ListNode A, int B)
        {
            ListNode head = new ListNode(0);
            ListNode prev = head;

            int i = 0;
            int k = GetLength(A) - B;

            k = k < 0 ? 0 : k;

            if (k == 0)
                return A.next;

            while (A != null)
            {
                if (i != k)
                {
                    prev.next = A;
                    prev = A;
                }

                A = A.next;
                i++;
            }

            if (B == 1)
            {
                prev.next = null;
            }

            return head.next;
        }
        public static void BinaryTree()
        {

        }

        // E
        public static int DistributeCady()
        {
            var A = new List<int> { 1, 2,3 };
            //posso começar do segundo, se o anterior for menor e o posterior também, eu somo 4 no resultado 1 -> 2 -> 1

            //verifica um por um, vizinho de tras é < tu adiciona dois, vizinho da frente é maior que o de tras, adiciona 3

            // talvez um recursivo validando se é maior ou menor e somando ao resultado final

            int result = 0;
            int lastResult = 0;

            for(int i = 0; i < A.Count; i++)
            {
                if(i != 0)
                {
                    int current = A[i];
                    int sum = 1;
                    // checo anterior e posterior
                    if(A[i-1] < current)
                    {
                        sum = sum + (lastResult - sum) + 1;
                    }

                    if(i < A.Count - 1)
                    {
                        if (current > A[i + 1])
                        {
                            sum += 1;
                        }
                    }

                    if (current > A[i - 1] && sum <= lastResult)
                        sum = sum + (lastResult - sum) + 1;

                    if (current < A[i - 1] && sum >= lastResult)
                        sum = sum + (sum - lastResult) + 1;

                    result += sum;
                    lastResult = sum;
                }

                if (i == 0)
                {
                    // checo posterior
                    if (A[i + 1] > A[i])
                        result += 1;
                    else
                        result += 2;
                }
            }
            return result;
        }
    }
}
