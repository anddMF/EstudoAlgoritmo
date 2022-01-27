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

            var list = new List<int> { 1, 3, 7 };
            var llist = new SinglyLinkedListNode { data = list[0], next = null };
            var head = llist;
            for (int i = 1; i < list.Count; i++)
            {
                llist.next = new SinglyLinkedListNode { data = list[i], next = null };
                llist = llist.next;
            }

            var list2 = new List<int> { 1, 2 };
            var llist2 = new SinglyLinkedListNode { data = list2[0], next = null };
            var head2 = llist2;
            for (int i = 1; i < list2.Count; i++)
            {
                llist2.next = new SinglyLinkedListNode { data = list2[i], next = null };
                llist2 = llist2.next;
            }
            //var res = pageCount(6,2);
            Console.ReadKey();
        }

        // E01: Encontra uma determinada somatória de números em sequencia dentro da array
        static bool CheckSum(List<int> numberList, int totalSum)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                var elem1 = numberList[i];
                var partialSum = elem1;

                for (int j = i + 1; j < numberList.Count && partialSum < totalSum; j++)
                {
                    var number = numberList[j];
                    partialSum += numberList[j];

                    if (partialSum == totalSum)
                    {
                        Console.WriteLine("Index inicio: " + i + "\nIndex fim: " + j);
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

            int higherNumber = int.MinValue;
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
                             {1, 1, 1, 2,  2 , 0, 1, 0},
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

            Console.Write("Num: " + currentNumber + " | ");

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
            Console.WriteLine("\n Num diferente");
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

            list.AddNodeToFront(4);
            list.AddNodeToFront(3);
            list.AddNodeToFront(1);

            list.AddNodeToBack(9);

            //list.DeleteNodeFromFront();

            list2.AddNodeToFront(7);
            list2.AddNodeToFront(5);
            list2.AddNodeToFront(2);

            list2.AddNodeToBack(10);

            list.PrintNodes();
            list2.PrintNodes();

            var res = MergeListsSorted(list.head, list2.head);

            while (res != null)
            {
                Console.WriteLine(res.data);

                res = res.next;
            }
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
        // no inicio o user digita o número de inputs que irá fazer (queries). Os inputs seguem os seguintes parametros:
        // - "1 X" comando para adicionar um número X na fila
        // - "2" comando para remover o primeiro objeto da fila
        // - "3" comando para printar o primeiro item da fila
        public static void QueueExercise()
        {
            QueueN<int> queue = new QueueN<int>();
            int queries = 0;
            string cmd = "";

            // teste hashset
            var hs = new HashSet<int>();
            hs.Add(1);
            hs.Add(2);
            hs.Add(3);
            hs.Add(4);
            hs.Add(5);

            hs.ExceptWith(new List<int> { 1, 2, 3, 8 });

            Console.Write("numero queries ");
            queries = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < queries; i++)
            {
                Console.Write("Comando: ");
                cmd = Console.ReadLine();
                var split = cmd.Split(' ');

                if (split.Length > 1)
                    queue.Enqueue(Convert.ToInt32(split[1]));

                if (Convert.ToInt32(split[0]) == 2)
                    queue.Dequeue();

                if (Convert.ToInt32(split[0]) == 3)
                    queue.PrintFirstElement();
            }
        }

        // E13 Verifica se os brackets ('[] {} ()') estão equilibrados
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

        // E13 outra forma
        public int isValid(string A)
        {
            var arr = A.ToCharArray().ToList();
            if ((arr.Count % 2) > 0)
                return 0;

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < arr.Count; i++)
            {
                string current = arr[i].ToString();

                if (current == "(" || current == "{" || current == "[")
                {
                    stack.Push(current);
                }
                else
                {
                    if (stack.Count <= 0)
                        return 0;

                    string peek = stack.Peek();

                    switch (current)
                    {
                        case ")":
                            if (peek == "(")
                                stack.Pop();
                            else
                                return 0;
                            break;
                        case "}":
                            if (peek == "}")
                                stack.Pop();
                            else
                                return 0;
                            break;
                        case "]":
                            if (peek == "]")
                                stack.Pop();
                            else
                                return 0;
                            break;
                    }
                }
            }
            return stack.Count > 0 ? 0 : 1;
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

            Hashtable res = NavigateMatrix(matrix, 0, 0, queryToFind);
        }

        // E14-COMPLEMENTO
        public static Hashtable NavigateMatrix(string[,] matrix, int y, int x, string query)
        {
            int edgeY = matrix.GetLength(0); // Retorna y 6
            int edgeX = matrix.GetLength(1); // Retorna x 5

            // hashtable para usar o containsKey
            Hashtable htResponse = new Hashtable();

            var queryArr = query.ToList();

            for (int i = 0; i < edgeY; i++)
            {
                for (int j = 0; j < edgeX; j++)
                {
                    string current = matrix[i, j];

                    string find = queryArr.Find(letter => letter.ToString() == current).ToString();

                    // se não encontra, o find fica com valor "\0"
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

            return htResponse;
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
            var dp = new int[A + 1 >= 3 ? A + 1 : 3];

            // dp para resolver sub problems, jeito de subir zero degrau é 1, de subir um degrau é 1 e de subir dois degraus é 2 ([1,1], [2])
            // uso essas resoluções de sub para ter base na fórmula dos ´próximos degraus
            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 2;

            if (dp.Length >= A && dp[A] != 0)
                return dp[A];

            for (int i = 3; i <= A; i++)
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
            for (int j = 0; j < arrKeys.Length; j++)
            {
                if (j == arrKeys.Length - 1)
                    return result;

                counter++;
                currentKey = arrKeys[j];
                for (int k = j + 1; k < arrKeys.Length; k++)
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
            var A = new List<int> { 2, 1 };
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

            for (int i = 1; i < a.Count; i++)
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
            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] == previous)
                    return A[i];

                previous = A[i];
            }
            return -1;
        }

        // E29 A lista weights possui o peso de N itens, já a lista profits possui o valor destes N itens. Obtenha o máximo de lucro colocando dois destes itens em uma mochila,
        // sem repetir itens e respeitando o peso máximo colocado no capacity.
        public static int Knapsack()
        {
            var weights = new List<int> { 2, 3, 1, 4 };
            var profits = new List<int> { 4, 5, 3, 7 };
            int capacity = 5;
            int maxProfit = 0;

            // seleciono um item no primeiro for e comparo com o resto de itens no segundo for
            for (int i = 0; i < weights.Count; i++)
            {
                int currentWeight = weights[i];
                for (int j = 0; j < weights.Count; j++)
                {
                    // if para não repetir o item na mochila
                    if (j != i)
                    {
                        int compareWeight = weights[j];
                        int totalWeight = currentWeight + compareWeight;
                        if (totalWeight <= capacity)
                        {
                            int totalProfit = profits[i] + profits[j];
                            maxProfit = totalProfit > maxProfit ? totalProfit : maxProfit;
                        }
                    }
                }
            }

            return maxProfit;
        }

        // E30 Dada duas strings, retorne a maior sequencia em comum de caracters entre as duas. Retorno é o número de 
        // caracteres da maior sequencia
        public static int LongestCommonSubarray()
        {
            string A = "abbcdgf";
            string B = "bbadcgf";

            var charA = A.ToList();
            var charB = B.ToList();

            int firstIndex = -1;
            int maxAdd = 0;
            int longest = 0;
            int result = 0;

            for (int i = 0; i < charA.Count; i++)
            {
                longest = 0;
                string current = charA[i].ToString();

                firstIndex = charB.FindIndex(a => a.ToString() == current);
                maxAdd = (charA.Count - i) - 1;
                int currentAdd = 1;
                int lastIndexVisited = -1;
                if (firstIndex != -1)
                {
                    longest++;
                    lastIndexVisited = firstIndex;

                    /* outro método
                    var mockB = charB;
                    mockB.RemoveRange(0, firstIndex + 1);
                    int index = -1;
                    while(currentAdd <= maxAdd || mockB.Count > 0)
                    {
                        string a = charA[i + currentAdd].ToString();
                        index = mockB.FindIndex(x => x.ToString() == a);

                        if(index > -1)
                        {
                            longest++;
                            lastIndexVisited = index;
                            mockB.RemoveRange(0, index + 1);
                        }
                        currentAdd++;
                    }
                    */

                    // Percorro toda o resto da lista, depois de selecionar um item, para verificar a sequencia existente
                    for (int j = firstIndex + 1; j < charB.Count || currentAdd == maxAdd; j++)
                    {
                        // uso o currentAdd para navegar pela array A e trocar o primeiro comparador
                        string a = charA[i + currentAdd].ToString();
                        string b = charB[j].ToString();
                        if (charA[i + currentAdd] == charB[j])
                        {
                            longest++;
                            currentAdd++;
                            lastIndexVisited = j;
                        }

                        // if para verificar se chegou no final da string comparando com um determinado item da list A,
                        // se chegou ao final, avança um item na A e volta do último caracter em comum (lastIndexVisited)
                        if (j == charB.Count - 1 && currentAdd < maxAdd)
                        {
                            currentAdd++;
                            j = lastIndexVisited + 1;
                        }
                    }
                }

                result = System.Math.Max(longest, result);
            }
            return result;
        }

        // E31
        public static List<int> AddOneNumber()
        {
            var A = new List<int> { 0 };

            string inputNumber = "";
            for (int i = 0; i < A.Count; i++)
            {
                inputNumber = inputNumber + A[i].ToString();
            }

            int number = Convert.ToInt32(inputNumber) + 1;
            string stringNumber = number.ToString();
            stringNumber.ToCharArray();
            var result = new List<int>();
            foreach (char a in stringNumber)
            {
                result.Add(Convert.ToInt32(a));
            }

            return result;
        }

        // E32 Reformulação para solução mais fechada do que o E13
        public static int Brackets()
        {
            string A = "([";
            var stack = new Stack<string>();

            var arr = A.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                string elem = arr[i].ToString();

                if (elem == "[" || elem == "(" || elem == "{")
                    stack.Push(elem);
                else
                {
                    string peek = "";
                    if (stack.Count > 0)
                        peek = stack.Peek();
                    else
                        return 0;

                    switch (elem)
                    {
                        case "]":
                            if (peek == "[")
                                stack.Pop();
                            else
                                return 0;
                            break;
                        case ")":
                            if (peek == "(")
                                stack.Pop();
                            else
                                return 0;
                            break;
                        case "}":
                            if (peek == "{")
                                stack.Pop();
                            else
                                return 0;
                            break;
                    }
                }
            }
            return stack.Count > 0 ? 0 : 1;
        }

        // E33 Com uma matriz quadrática, se encontrar um 0 deve transformar a linha e coluna deste em 0 também
        // retornar a própria matriz caso não tenha 0
        public static int[,] SetMatrixZeros()
        {
            var matrix = new int[,] { { 1, 0, 1 },
                                      { 1, 1, 1 },
                                      { 1, 0, 1 }};
            // clone serve para não utilizar o mesmo espaço de memória que a var matrix
            // deep copy
            int[,] result = (int[,])matrix.Clone();

            int length = matrix.GetLength(0);
            int x = 0;
            int y = 0;
            for (int i = x; i < length; i++)
            {
                for (int j = y; j < length; j++)
                {
                    int current = matrix[i, j];

                    if (current == 0)
                    {
                        result = SetZeros(result, length, i, j);
                    }
                }
            }

            return result;
        }

        // E33-COMPLEMENTO
        public static int[,] SetZeros(int[,] matrixI, int maxLength, int x, int y)
        {
            for (int i = 0; i < maxLength; i++)
            {
                matrixI[x, i] = 0;
                matrixI[i, y] = 0;
            }
            ShowMatrix(matrixI, maxLength, maxLength);

            return matrixI;
        }

        // E34 Retornar uma lista mostrando os itens da matriz em espiral. No Exemplo 1 o retorno seria: [1,2,3, 6,9, 8,7, 4, 5]
        public static List<int> SpiralOrder()
        {
            List<List<int>> matrix = new List<List<int>>();

            // Exemplo 1
            //matrix.Add(new List<int> { 1, 2, 3 });
            //matrix.Add(new List<int> { 4, 5, 6 });
            //matrix.Add(new List<int> { 7, 8, 9 });

            //matrix.Add(new List<int> { 1, 2 });
            //matrix.Add(new List<int> { 3, 4 });
            //matrix.Add(new List<int> { 5, 6 });

            matrix.Add(new List<int> { 1 });
            matrix.Add(new List<int> { 2 });
            matrix.Add(new List<int> { 3 });

            // deep copy
            var clone = matrix.ConvertAll(obj => new List<int>(obj));

            var result = new List<int>();

            int x = 0;
            int y = matrix[0].Count - 1;

            while (clone.Count > 0)
            {
                result.AddRange(clone[0]);
                clone.RemoveAt(0);

                if (clone.Count == 0)
                    return result;

                // navegar pra baixo
                for (int i = 0; i < clone.Count; i++)
                {
                    result.Add(clone[i][y]);
                    clone[i].RemoveAt(y);
                }

                clone.RemoveAll(obj => obj.Count == 0);
                if (clone.Count == 0)
                    return result;

                //navegar pra esquerda
                x = clone.Count - 1;
                for (int i = clone[x].Count - 1; i >= 0; i--)
                {
                    result.Add(clone[x][i]);
                    clone[x].RemoveAt(i);
                    //if (clone[x].Count == 0)
                    //    clone.RemoveAt(x);
                }

                clone.RemoveAll(obj => obj.Count == 0);
                if (clone.Count == 0)
                    return result;

                // navegar pra cima
                y = 0;
                for (int i = clone.Count - 1; i >= 0; i--)
                {
                    result.Add(clone[i][y]);
                    clone[i].RemoveAt(y);
                }
            }

            return result;
        }

        // E35 Gera o triangulo de pascal em uma matrix, onde seu número de linhas é determinado pelo parametro 'row'
        public static List<List<int>> PascalTriangle(int row)
        {
            // input: int com numero de linhas para gerar, que também é a quantidade de itens dentro da última linha
            // todas as linhas iniciam e terminam com o 1
            List<List<int>> pascal = new List<List<int>>();
            int runner = 1;

            // vai armezar as somas necessárias para preenchar a próxima linha do triangulo
            var previousSum = new List<int>();

            // uso o runner para ir subindo na matriz de resposta e ir adicionando linha por linha
            while (runner <= row)
            {
                // instancio e adiciono o primeiro elemento da linha que será adicionada ao triangulo
                var list = new List<int>();
                list.Add(1);

                // loop para inserir os elementos da linha acima
                for (int i = 1; i < runner; i++)
                {
                    // SE estiver no último elemento da linha, adiciona o 1 que é determinação do triangulo
                    if (i == runner - 1)
                    {
                        list.Add(1);
                        // o previous sum só aumenta de tamanho aqui, adicionando a soma do 1 com o anterior
                        previousSum.Add(list[i - 1] + list[i]);
                    }
                    else
                    {
                        // adiciona o item na linha e depois atualizo o valor do elemento na previous sum para 
                        // a próxima linha utilizar
                        list.Add(previousSum[i - 1]);
                        previousSum[i - 1] = list[i - 1] + list[i];
                    }
                }

                pascal.Add(list);
                runner++;
            }

            return pascal;
        }

        // E36 Retorna os números da linha de um triangulo de pascal a partir do input kthRow, onde o mesmo é baseado em 0
        public static List<int> KthRowPascalsTriangle(int kthRow)
        {
            int row = kthRow > 0 ? kthRow + 1 : 1;

            List<int> result = new List<int>();
            List<int> previousSum = new List<int>();
            int runner = 1;
            while (runner <= row)
            {
                List<int> pascalLine = new List<int>();
                pascalLine.Add(1);
                for (int i = 1; i < runner; i++)
                {
                    if (i == runner - 1)
                    {
                        pascalLine.Add(1);
                        previousSum.Add(pascalLine[i - 1] + pascalLine[i]);
                    }
                    else
                    {
                        pascalLine.Add(previousSum[i - 1]);
                        previousSum[i - 1] = pascalLine[i - 1] + pascalLine[i];
                    }
                }
                result = pascalLine;
                if (runner == row)
                    return result;

                runner++;
            }
            return result;
        }

        // E37 Retorna a multiplicação mais alta
        public static int HighestProduct()
        {

            List<int> A = new List<int> { 0, -1, 3, 100, -70, -50 };

            var newArr = A.ConvertAll(x => x < 0 ? Math.Abs(x) : x);
            int curMax = 0;
            int n = A.Count - 1;
            A.Sort();
            // multiplica os mais baixos
            curMax = A[0] * A[1] * A[2];

            // reverte para tentar capturar algum negativo alto no caso de uma lista misturando positivos e negativos
            A.Reverse();

            curMax = Math.Max(curMax, A[0] * A[1] * A[2]);

            // tenta capturar o resultado mais positivo possível, visto que 3 negativos em uma equação daria negativo
            // então ele tenta pegar pelo menos um positivo no A[0] para multiplicar com dois possiveis negativos (A[n] * A[n-1])
            return Math.Max(curMax, A[0] * A[n] * A[n - 1]);

        }

        // E38 Retorna o valor da maior sequencia de números imediatamente consecutivos dentro do array de input
        public static int LongestConsecutiveSequence(List<int> list)
        {
            //List<int> list = new List<int> { 100, 4, 200, 1, 3, 2 };
            //List<int> list = new List<int> { -167, -166, -165, -11, -10, 10, 11, 12, 13, 14, 15 };
            int result = 1;
            int partialResult = 1;

            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0)
                {
                    if (list[i] != list[i - 1])
                    {
                        partialResult = list[i] - 1 == list[i - 1] ? partialResult + 1 : 1;
                        if (partialResult > result)
                            result = partialResult;
                    }
                }
            }

            return result;
        }

        // E39 Dentro da array de input, encontra dois números, que somados darão o target, e retorna seus respectivos indices em
        // uma list (não é zero based). Entretando, se existirem múltiplas soluções dentro da array, a preferência é pelo minimo 
        // valor do SEGUNDO indice, e se existir múltiplas soluções no segundo indice mínimo, a mesma condição para para o primeiro
        public static List<int> TwoSum(List<int> list, int target)
        {
            //List<int> list = new List<int> { 11, 15, 2, 7 };
            // List<int> list = new List<int> { 31, 4, 7, -4, 2, 2, 2, 3, -5, -3, 9, -4, 9, -7, 7, -1, 9, 9, 4, 1, -4, -2, 3, -3, -5, 4, -7, 7, 9, -4, 4,-8 };
            // int target = -3;
            int index1 = -1;
            int index2 = -1;

            for (int i = 0; i < list.Count; i++)
            {
                int firstNumber = list[i];
                if (i < list.Count - 2)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        int second = list[j];
                        if (firstNumber + list[j] == target)
                        {
                            // cadeia de ifs para acatar os parametros de 'indice mínimo'

                            // para a primeira alteração do index2
                            if (index2 == -1)
                            {
                                index1 = i;
                                index2 = j;
                            }

                            // a preferencia de na resposta é o menor index2
                            if (j < index2)
                            {
                                index1 = i;
                                index2 = j;
                            }

                            // se tiver mais de uma solução no indice 2, a diretiva é pegar o menor indice 1
                            if (j == index2)
                            {
                                if (i < index1)
                                {
                                    index1 = i;
                                    index2 = j;
                                }
                            }
                        }
                    }
                }
            }

            return index1 == -1 ? new List<int>() : new List<int> { index1 + 1, index2 + 1 };
        }

        // E40 Retorna o length da maior substring em que os caracters não se repetem
        public static int LengthLongestSubstring(string input)
        {
            //string input = "daD9ddb9cAy";
            var arr = input.ToList();
            // hashset para busca mais eficiente
            HashSet<string> hs = new HashSet<string>();

            if (arr.Count == 0)
                return 0;

            hs.Add(arr[0].ToString().ToLower());

            for (int i = 1; i < arr.Count; i++)
            {
                if (!hs.Contains(arr[i].ToString().ToLower()))
                    hs.Add(arr[i].ToString());

            }

            return hs.Count;
        }

        // E41 Retorna a frequencia em que os numeros aparecem na arr em uma outra array, onde cada frequencia
        // é registrada em seu específico index e com um limite de 100 numeros, por isso a freq é iniciada
        // com 100 elementos com o valor 0
        // Exemplo: arr = [ 1, 1, 3, 2, 1], resposta freq = [ 0, 3, 1, 1, ... 0]
        public static List<int> CountingSort(List<int> arr)
        {
            //List<int> arr = new List<int> { 1, 1, 3, 2, 1 };
            // inicia a list com 100 elementos contendo cada um o valor 0
            List<int> freq = new List<int>(new int[100]);

            for (int i = 0; i < arr.Count; i++)
            {
                int current = arr[i];
                freq[current] += 1;
            }

            return freq;
        }

        // E42 Pangram é uma string que contém todas as letras do alfabeto. O código retorna se a string de input é um 
        // pangram ou não, com os retornos "pangram" e "not pangram"
        public static string Pangram(string s)
        {
            //string s = "The quick brown fox jumps over the lazy dog";
            // hashset para busca mais eficiente
            var arr = s.ToLower().ToList();
            HashSet<char> hs = new HashSet<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToList());

            for (int i = 0; i < arr.Count; i++)
            {
                if (hs.Contains(arr[i]))
                    hs.Remove(arr[i]);
            }

            return hs.Count > 0 ? "not pangram" : "pangram";
        }

        // E43 Retorna o número de subarrays possíveis para as seguintes condições:
        // 1. O length da array tem que ser do tamanho do input 'm'
        // 2. A soma de todos os itens da subarray precisa se igual a do input 'd'
        public static int Birthday(List<int> s, int d, int m)
        {
            //List<int> s = new List<int> { 2, 2, 1, 3, 2 };
            //int d = 4; // sum
            //int m = 2; // length

            int result = 0;
            int first = 0;
            int partial = 0;

            // janela deslizante / sliding window
            for (int i = 0; i < s.Count; i++)
            {
                // percorri a lista usando um for e esse if para controlar 
                // o length dos elementos somados
                if (i - first >= m)
                {
                    // se cair aqui, o length da subarray passou do permitido, então eu subtraio
                    // o primeiro item que estava sendo somado na subarray
                    partial = partial - s[first];

                    // aumento em 1 o index do primeiro item da subarray
                    first++;
                }

                partial += s[i];

                // validação para que as diretrizes de sum e length, respectivamente, sejam atendidas
                if (partial == d && i - first == m - 1)
                    result++;
            }

            return result;
        }

        // E44 Verifica quantos pares de 'meias coloridas' existem dentro da lista de input, onde cada cor é representada por um
        // número diferente, então no exempo [ 1, 3, 1, 2, 3 ]  a resposta seria 2 (pares 1-1, 3-3 e uma 2 solitária)
        public static int SockMerchant(int n, List<int> ar)
        {
            // List<int> ar = new List<int> { 1,2,1,2,1,3,2 };
            // int n = 7;

            int result = 0;
            HashSet<int> hs = new HashSet<int>();

            for (int i = 0; i < ar.Count; i++)
            {
                // consulto se já existe no hs, se exister removo e incremento o contador de pares
                // se não existir, adiciono
                if (hs.Contains(ar[i]))
                {
                    hs.Remove(ar[i]);
                    result++;
                }
                else
                {
                    hs.Add(ar[i]);
                }
            }

            return result;
        }

        // E45 Imaginando um livro com suas páginas numeradas 1 ; 2,3 ; 4,5 ... onde quem está à esquerda na vírgula
        // é a página da esquerda. Para alcançar uma página X você pode iniciar pelo ínicio ou fim do livro e contando
        // o número de páginas viradas.
        // Com esse info, o exercício passa quantas páginas o livro tem (n) e em qual o leitor quer chegar (p). O 
        // retorno é o menor valor de viradas de página entre abrir pelo ínicio e fim do livro.
        public static int PageCount(int n, int p)
        {
            // Exemplo \/
            // int n = 5;
            // int p = 3;
            // resposta é 1

            int pagesFromStart = 0;
            int pagesFromBack = 0;

            // 0,1 - 2,3 - 4,5 - 6,7 - 8,9 - 10,11 - 12

            // aplico a fórmula transformando o p em par com o p-1, visto que ele fica no mesmo flip
            //  de pages que o ímpar
            pagesFromStart = p % 2 > 0 ? (p - 1) / 2 : p / 2;

            // transformo eles em pares para a fórmula funcionar
            int newN = n % 2 > 0 ? n - 1 : n;
            int newP = p % 2 > 0 ? p - 1 : p;
            pagesFromBack = (newN - newP) / 2;

            return Math.Min(pagesFromStart, pagesFromBack);
        }

        // E46 Descriptografar a string s usando o Caesar Cipher que muda cada letra a partir de um determinado número (k)
        // Exemplo: em um k = 2, o alfabeto com os indices alterados para o cipher ficaria como cdefghijklmnopqrstuvwxyzab
        // quando fosse buscar a letra 'm', seu indice no cipher seria a letra 'o'
        public static string CaesarCipher()
        {
            //string s = "lcfd";
            string s = "Always-Look-on-the-Bright-Side-of-Life";
            float k = 5;
            // return = Fqbfdx-Qttp-ts-ymj-Gwnlmy-Xnij-tk-Qnkj

            string cipher = "abcdefghijklmnopqrstuvwxyz";
            var arr = cipher.ToList();
            float count = arr.Count;

            // essa conta vai servir pra saber quantas vezes as 26 letras do alfabeto cabem dentro do K,
            // porque em caso de k > 26, eu preciso saber somente quantas casas depois do 26 tenho que andar
            float times = k / count > 0 ? k / count : 1;
            int a = (int)Math.Round(times, 0) <= 0 ? 1 : (int)Math.Round(times, 0);
            if (a > 1)
                a--;

            string result = "";

            for (int i = 0; i < s.Length; i++)
            {
                // validação de maiúscula para manter o mesmo resultado
                bool isUppercase = Char.IsUpper(s[i]);
                char letter = Char.ToLower(s[i]);
                int index = arr.FindIndex(x => x == letter);

                if (index >= 0)
                {
                    int realIndex = index + (int)k;
                    // realIndex = realIndex > count - 1 ? realIndex - count * times : realIndex;

                    // funciona para transformar um indice muito elevado e acima do count 
                    // para um equivalento dentro dos 26 caracteres do alfabeto
                    if (realIndex > count - 1)
                    {
                        int final = realIndex - (int)count * a;
                        if (final >= 26)
                            final = final - 26;

                        realIndex = final;
                    }

                    letter = arr[realIndex];
                    if (isUppercase)
                        letter = Char.ToUpper(letter);

                    result += letter;
                }
                else
                {
                    result += letter;
                }

            }

            return result;
        }

        // E47 Dada uma array de entrada (arr), retorna YES para caso seja uma array com somas balanceadas, ou seja:
        // Se, a partir de x ponto da array, as soma da esquerda e direita desse ponto sejam iguais. Por exemplo:
        // arr = [ 1, 2, 3, 3] no index 2 ela é uma array balanceada pois 1 + 2 (subarray à esquerda) é igual
        // a 3 (subarray da direita)
        public static string BalancedSums()
        {
            var arr = new List<int> { 4, 8, 3, 3 };
            int totalSum = 0;
            int leftSum = 0;
            int rigthSum = 0;

            // faço a soma total dos itens da array
            for (int i = 0; i < arr.Count; i++)
            {
                totalSum += arr[i];
            }

            // essa atribuição parte da premissa de iniciar do index 1, já que não
            // tem uma subarray à esquerda do index 0. Mas o exercício considera como subarray, então 
            // é só colocar 0 aqui e no for um int j = 0
            leftSum = arr[0];
            for (int j = 1; j < arr.Count - 1; j++)
            {
                // calculo a soma da direita subtraindo os elementos da esquerda e o index atual
                rigthSum = totalSum - leftSum - arr[j];

                if (leftSum == rigthSum)
                    return "YES";

                // incremento a soma da esquerda com o elemento atual
                leftSum += arr[j];
            }

            return "NO";
        }

        // E48 O super digit de um int x é definido pela soma dígitos de x, até que se tenha somente um dígito
        // Exemplo: x = 985, superDigit = 9 + 8 + 5 = 22 ; superDigit = 2 + 2 = 4
        // O método retorna o superDigit da string n que é repetida k vezes para ter o número final
        public static int SuperDigit(string n, int k)
        {
            //string n = " 9875".Trim();
            //int k = 4;
            // resultado = 8
            string digit = n.Trim();

            // com recurssão

            // para ter o número final tem que fazer n + n em k vezes
            /* for(int i = 0; i < k; i++)
            {
                digit += n;
            } */

            int result = 0;
            if (digit.Length > 1)
            {
                result = RecursiveSuperDigit(digit);
            }
            else
            {
                result = Convert.ToInt32(digit);
            }

            result = result * k;
            if (result.ToString().Length > 1)
                return RecursiveSuperDigit(result.ToString());

            return result;
            // fim com recurssão

            /* Sem recurssão

            var toConvert = digit.ToList();
            // result recebe também o 'digit' porque dentro do while ele vai ser utilizado para continuar 
            // a soma dos digitos ao invés do 'digit'
            long result = Convert.ToInt64(digit);
            if (toConvert.Count > 1)
            { 
                while(result.ToString().Length > 1)
                {
                    toConvert = result.ToString().ToList();
                    result = 0;
                    // soma dos dígitos
                    for (int j = 0; j < toConvert.Count; j++)
                    {
                        result += Convert.ToInt64(toConvert[j].ToString());
                    }
                    
                    result = result * k;
                }
            }
            return Convert.ToInt32(result);
            */
        }

        // E48-COMPLEMENTO
        public static int RecursiveSuperDigit(string digit)
        {
            var toConvert = digit.ToString().ToList();
            long result = 0;

            // soma de todos os dígitos
            for (int j = 0; j < toConvert.Count; j++)
            {
                result += Convert.ToInt64(toConvert[j].ToString());
            }

            // se ainda tiver mais de um dígito, chama novamente o método até ter um único
            return result.ToString().Length > 1 ? RecursiveSuperDigit(result.ToString()) : Convert.ToInt32(result);
        }

        // E49 Identifica o mínimo de unfainess na array de input. Unfainess é definido pelo max(arr) - min(arr),
        // o MaxMin recebe k que é o length necessário da subarray para calcular o unfairness. Exemplo:
        // arr = [ 1, 4, 7, 2] ; k = 2; pegando aleatórios a = [ 1, 7] o unfairness seria 7 - 1 = 6, mas o minimo
        // seria com [ 1, 2 ], sempre utilizando subarray com length == k
        public static int MaxMin(int k, List<int> arr)
        {
            // List<int> arr = new List<int> { 300, 100, 200,350,400,401,402 };
            // int k = 3;
            // resposta = 2;

            // ideia é navegar pela array e utilizar uma array de suporte para colocar os números para o calculo,
            // quanto tiver o length correto, calcular o unfairness e atualizar o response se ele for menor

            // ordeno para ter os numeros aproximados
            arr.Sort();

            int result = int.MaxValue;
            // subarray de suporte para a conta de unfairness
            var countArr = new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                countArr.Add(arr[i]);

                if (countArr.Count == k)
                {
                    // como a lista está ordenada, só fazer a subtração assim
                    int unfairness = countArr[k - 1] - countArr[0];
                    result = unfairness < result ? unfairness : result;

                    countArr.RemoveAt(0);
                }
            }
            return result;
        }

        // E50-COMPLEMENTO
        public class SinglyLinkedListNode
        {
            public int data { get; set; }
            public SinglyLinkedListNode next { get; set; }
            //int data;
            //SinglyLinkedListNode next;
        }

        // E50 Reverte uma linked list com stack
        public static SinglyLinkedListNode ReverseLinkedList(SinglyLinkedListNode llist)
        {
            if (llist == null)
                return null;

            Stack<int> stack = new Stack<int>();
            SinglyLinkedListNode runner = llist;

            while (runner != null)
            {
                stack.Push(runner.data);
                runner = runner.next;
            }

            SinglyLinkedListNode result = new SinglyLinkedListNode { data = stack.Pop(), next = null };
            SinglyLinkedListNode runner2 = result;
            while (stack.Count > 0)
            {
                runner2.next = new SinglyLinkedListNode { data = stack.Pop(), next = null };
                runner2 = runner2.next;
            }

            return result;
        }

        // E50-VERSÃO-SLIM
        public static SinglyLinkedListNode ReverseLinkedListSlim(SinglyLinkedListNode llist)
        {
            if (llist == null || llist.next == null)
                return null;

            SinglyLinkedListNode runner = llist;

            // instancia como null porque eu vou ir adicionando nele pelo inicio da linked list, então
            // esse primeiro null será o último item da lista
            SinglyLinkedListNode prev = null;

            while (runner != null)
            {
                // salva o next em outro espaço de memória pra não ser afetado no shallow copy
                var next = runner.next;

                // shallow copy
                var current = runner;
                // node atual referenciando o anterior
                current.next = prev;
                // node prev atualizado com o reverse mais recente
                prev = current;

                runner = next;
            }

            return prev;
        }

        // E51 Insere um node novo na llist a partir da posição inserida no position e o valor do data de input
        public static SinglyLinkedListNode InsertNodeAtPosition(SinglyLinkedListNode llist, int data, int position)
        {
            if (llist == null)
                return null;

            SinglyLinkedListNode runner = llist;
            SinglyLinkedListNode prev = null;

            int counter = 0;

            while (counter <= position)
            {
                // novo node tem que referenciar o atual e o anterior referenciar o novo node
                // new node.next = current node
                // prev.next = new node
                if (counter == position)
                {
                    SinglyLinkedListNode next = runner;
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode { data = data, next = next };
                    prev.next = newNode;
                    return llist;
                }

                // como o runner referencia a llist, o prev vai alterar ela também
                // prev está sempre um node antes do runner
                prev = runner;
                // corro o runner
                runner = runner.next;
                counter++;
            }

            // não é pra chegar aqui se a position for válida
            return llist;
        }

        // E52 O(n) merge de duas linkedList em ordem crescente
        static SinglyLinkedListNode MergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            if (head1 == null)
                return head2;

            if (head2 == null)
                return head1;

            SinglyLinkedListNode runner1 = head1;
            SinglyLinkedListNode runner2 = head2;

            SinglyLinkedListNode headResult = null;

            // inicia o headResult com o menor primeiro numero das listas
            if (runner1.data < runner2.data)
            {
                headResult = new SinglyLinkedListNode { data = runner1.data, next = null };
                runner1 = runner1.next;
            }
            else
            {
                headResult = new SinglyLinkedListNode { data = runner2.data, next = null };
                runner2 = runner2.next;
            }

            // shallow copy para alterar o result e salvar o head
            var result = headResult;

            // while rola até uma das listas estar no final, depois disso é só adicionar a lista restando no resultado
            while (runner1 != null && runner2 != null)
            {
                if (runner1.data < runner2.data)
                {
                    // usar o .next ao invés do result para não alterar o endereço de memória já preenchido
                    result.next = new SinglyLinkedListNode { data = runner1.data, next = null };
                    // avança o result
                    result = result.next;

                    runner1 = runner1.next;
                }
                else
                {
                    // usar o .next ao invés do result para não alterar o endereço de memória já preenchido
                    result.next = new SinglyLinkedListNode { data = runner2.data, next = null };
                    result = result.next;

                    runner2 = runner2.next;
                }
            }

            // add a lista restante no resultado
            if (runner1 == null)
            {
                result.next = runner2;
                return headResult;
            }
            else
            {
                result.next = runner1;
                return headResult;
            }

        }

        // E53 Cada elemento da lista é uma pessoa, onde a lista é a fila em ordem de chegada. Cada pessoa usa o número de sua posição inicial de 1 até n,
        // as pessoas podem subornar a outra imediatamente a sua frente para avançar um lugar, mas ainda utilizando seu número da posição inicial. Exemplo:
        // q = [ 1, 2, 4, 3, 7, 5, 6], a pessoa 4 subornou a 3 e a pessoas 7 subournou a 5 e 6
        // O método printa o número de subornos acontecidos na fila ou "Too chaotic" caso uma pessoa tenha subornado mais de duas
        public static void MinimumBribes()
        {
            //posição na fila:      1  2  3  4  5  6  7  8
            var q = new List<int> { 1, 2, 5, 3, 7, 8, 6, 4 };
            // f = q[i] > i+1 = fez bribe, então bribes = q[i] - i+1 = numero de posições que subiu
            // se o bribes > 2, print Too chaotic

            int bribes = 0;

            for (int i = 0; i < q.Count; i++)
            {
                // teve bribe
                if (q[i] > i + 1)
                {
                    int currentBribe = q[i] - (i + 1);
                    if (currentBribe > 2)
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }

                    bribes += currentBribe;
                }
            }

            Console.WriteLine(bribes);
        }

        // E54 Nesse exercício, uma string é considerada valida se: 
        // - todos os caracteres aparecem o mesmo número de vezes
        // - se remover apenas um caracter, o resto da string aparece o mesmo número de vezes
        public static string IsValid()
        {
            // validar se todos os elementos da string aparecem o mesmo número de vezes
            // se um elemento tiver apenas uma aparição a mais que os outros, ainda é uma string válida

            // percorrer a string removendo os elementos já contados, salvar em dois ints o número de repetições que cada letra tem e quantas letras
            // tem repetições a mais. Validar dentro da lista se tiver duas repetições a mais que o resto pois já retorna "NO" come essa condição

            string s = "abc";
            var arr = s.ToList();

            // lista que vai armazer a frequencia de todos os caracteres
            var countList = new List<int>();

            while (arr.Count > 0)
            {
                string current = arr[0].ToString();
                // armazeno quantas vezes a letra apareceu
                var times = arr.FindAll(x => x.ToString() == current);
                countList.Add(times.Count);

                arr.RemoveAll(x => x.ToString() == current);
            }

            // quantas frequencias distintas existem na string
            var dis = countList.Distinct();

            // se tiver só uma, string tá equalizada
            if (dis.Count() == 1)
                return "YES";
            // se tiver mais de duas, não tem como equalizar a string
            if (dis.Count() > 2)
                return "NO";

            countList.Sort();

            int freq1 = countList.FindAll(x => x == countList.First()).Count;
            int freq2 = countList.FindAll(y => y == countList.Last()).Count;

            // valido se o elemento é 1, o que dá pra remover, ou se o elemento é um a menos que o elemento mais comum
            if (freq1 == 1)
            {
                if (countList.First() == 1 || countList.Last() - countList.First() == 1)
                    return "YES";
                else
                    return "NO";
            }
            if (freq2 == 1)
            {
                if (countList.Last() == 1 || countList.Last() - countList.First() == 1)
                    return "YES";
                else
                    return "NO";
            }

            return "NO";
        }

        // E55 A lista arr contem os valores de sorvetes e o int m o dinheiro total que pretendem gastar na sorveteria.
        // Com os requisitos de que precisam gastar todo o dinheiro e em dois sabores diferentes, o método retorna os 
        // indices (1 based) dos dois sorvetes que atendam estes requisitos, caso não tenha, retorna uma lista vazia.
        public static List<int> IceCreamParlor(int m, List<int> arr)
        {
            // var arr = new List<int> { 1, 3, 4, 5, 6 };
            // int m = 6;
            // resultado: [1, 4]

            for (int i = 0; i < arr.Count - 1; i++)
            {
                int first = arr[i];
                for (int j = i + 1; j < arr.Count; j++)
                {
                    int cost = first + arr[j];

                    if (cost == m)
                        return new List<int> { i + 1, j + 1 };
                }
            }
            return new List<int>();
        }

        // E56 Recebe três listas com cilindros que possuem tamanhos diferentes, a somatória dos tamanhos dos cilindros é o tamanho da lista.
        // Podendo tirar somente o primeiro cilindro (topo de uma stack), o código tenta equalizar as listas, caso possível, removendo ou
        // não cilindros até que todas possuam a mesma somatória de tamanho retirando o mínimo possível de cilindros, pois a resposta 0 ainda 
        // é válida.
        public static int EqualStacks(List<int> h1, List<int> h2, List<int> h3)
        {
            //var h1 = new List<int> { 1,2,1,1};
            //var h2 = new List<int> { 1,1,2};
            //var h3 = new List<int> { 1,1};
            // resposta: 2

            //var h1 = new List<int> { 1, 1, 1, 1, 2 };
            //var h2 = new List<int> { 3,7 };
            //var h3 = new List<int> { 1,3,1 };
            // resposta: 0

            if (h1.Count == 0)
                return 0;

            if (h2.Count == 0)
                return 0;

            if (h3.Count == 0)
                return 0;

            // coleto a soma do tamanho total dos cilindros para depois ir subtraindos destes a cada retirada da lista
            int sum1 = SumAllElements(h1);
            int sum2 = SumAllElements(h2);
            int sum3 = SumAllElements(h3);

            while (sum1 > 0 || sum2 > 0 || sum3 > 0)
            {
                if (sum1 == sum2 && sum1 == sum3)
                    return sum1;

                // possui esse ternário pois alguma das listas pode ter sido zerada entre as operações
                int c1 = h1.Count > 0 ? h1[0] : 0; // 1
                int c2 = h2.Count > 0 ? h2[0] : 0; // 1
                int c3 = h3.Count > 0 ? h3[0] : 0; // 1

                // verifico qual das listas tem a maior somatória no momento remove dela o cilindro 
                if (sum1 >= sum2 && sum1 >= sum3)
                {
                    h1.RemoveAt(0);
                    sum1 = sum1 - c1;
                }
                else if (sum2 >= sum1 && sum2 >= sum3)
                {
                    h2.RemoveAt(0);
                    sum2 = sum2 - c2;
                }
                else if (sum3 >= sum1 && sum3 >= sum2)
                {
                    h3.RemoveAt(0);
                    sum3 = sum3 - c3;
                }
            }

            return 0;
        }

        // E56-COMPLEMENTO
        public static int SumAllElements(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        // E57 Encontra a maior somatória de subarray e subsequence dentro da array de entrada.
        public static List<int> MaxSubarray()
        {
            // encontrar a maior soma de números continuos e não continuos
            var arr = new List<int> { -2, -3, -1, -4, -6 }; //15
            // talvez seja uma boa somar todos os elementos da array e ir subtraindo 
            // e salvando no total sum os que passam após subtrair

            int sum = SumAllElements(arr);
            int reverseSum = sum;

            int sumSubsequence = 0;
            int partialSum = sum;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > 0)
                    sumSubsequence += arr[i];
                if (i < arr.Count - 1)
                {
                    partialSum = partialSum - arr[i];
                    sum = Math.Max(sum, partialSum);
                }

            }
            partialSum = reverseSum;
            // verificar a soma vindo de trás da arrray pra frente
            for (int j = arr.Count - 1; j > 0; j--)
            {
                if (j > 0)
                {
                    partialSum = partialSum - arr[j];
                    sum = Math.Max(sum, partialSum);
                }
            }

            // se tiver uma array só com números negativs, subsequence não vai pegar dados e o sum ficará com
            // a soma de sequencia, então esse método é pra pegar o número mais próximo do positivo em cada uma
            if (sum <= 0 || sumSubsequence <= 0)
            {
                arr.Sort();
                return new List<int> { arr[arr.Count - 1], arr[arr.Count - 1] };
            }

            return new List<int> { sum, sumSubsequence };
        }

        // E58 Todos os itens da array precisam ser >= k, e para isso a fórmula que deve ser seguida é:
        // f = menor elemento + 2 * segundo menor elemento
        // o retorno deve ser quantas vezes essa fórmula teve que ser aplicada, se não puder ser resolvida
        // o retorno é -1.
        public static int Cookies()
        {
            int k = 9;
            var A = new List<int>() { 2, 7, 3, 6, 4, 6 };
            // resultado: 4

            if (A.Count == 0)
                return -1;
            A.Sort();

            int count = 0;
            bool isCorrect = false;

            while (!isCorrect)
            {
                if (A.Count <= 1 && A[0] < k)
                    return -1;
                else if (A[0] >= k)
                    return count;

                // removo da lista após aplicar a fórmula
                int f = A[0] + 2 * A[1];
                A.RemoveRange(0, 2);

                // se o resultado ainda estiver abaixo do k e o A.Count estiver com menos de dois elementos
                // (necessário para conseguir executar as fórmulas), adiciono o resultado de volta na listas
                if (f < k || A.Count < 2)
                    A.Add(f);

                //var a = A.FindAll(x => x >= k);

                count++;
                isCorrect = A.Count > 0 ? false : true;

                if (isCorrect)
                    return count;

                // mais um sort para alinhar sempre pegar os menores da lista
                A.Sort();
            }

            return count;
        }

        // E59
        public static void CamelCase()
        {
            // a linha começa com a operação S(split) ou C(combine), 
            // depois da primeira ; tem M (method), C(class) e V(variable)
            string input = Console.ReadLine();
            var split = input.Split(';');

            string operation = split[0];
            string type = split[1];
            string word = split[2];
            string result = "";

            if (operation == "S")
            {
                if (type == "M" || type == "V")
                {
                    // preciso encontrar o primeiro uppercase para separar 
                    foreach (char item in word)
                    {
                        if (item.ToString() != "(" && item.ToString() != ")")
                        {
                            if (Char.IsUpper(item))
                                result += " " + item.ToString().ToLower();
                            else
                                result += item.ToString();
                        }

                    }
                    Console.WriteLine(result);
                }
                if (type == "C")
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        char item = word[i];
                        if (Char.IsUpper(item))
                        {
                            if (i == 0)
                                result += item.ToString();
                            else
                                result += " " + item.ToString().ToLower();
                        }
                        else
                            result += item.ToString();
                    }
                    Console.WriteLine(result);
                }

            }

            if (operation == "C")
            {
                string[] words = word.Split(' ');

                if (type != "V")
                {
                    foreach (string item in words)
                    {

                        var word1 = char.ToUpper(item[0]);
                        var rest = item.Remove(0, 1);
                        result += word1 + rest;
                    }

                    if (type == "M")
                        result += "()";

                    Console.WriteLine(result);
                }
                else
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        string item = words[i];
                        if (i == 0)
                            result += item;
                        else
                        {
                            var word1 = char.ToUpper(item[0]);
                            var rest = item.Remove(0, 1);
                            result += word1 + rest;
                        }

                    }
                    Console.WriteLine(result);
                }

            }
        }

        // E60
        public int HorseMoves(int A, int B)
        {
            // recebo as posições do bishop num board de 8x8
            // preciso retornar quantos movimentos ele consegue fazer 

            // ele se move em L, duas casas para algum eixo e uma para alguma lado

            // tenho 4 movimentos em eixo, e 2 movimentos em cada eixo

            // movimento pra direita é B+2 e A-1 ou A-2
            // pra esquerda é B-2 e A-1 ou A-2

            // movimento pra cima é A+2 e B+1 ou B-1
            // pra baico é A-1 e B+1 ou B-1

            int moves = 0;
            // a = 2 b = 40,
            //andar pra direita
            if (B <= 6)
            {
                if (A >= 2)
                    moves++;
                if (A <= 7)
                    moves++;
            }

            // andar pra esquerda
            if (B >= 3)
            {
                if (A >= 2)
                    moves++;
                if (A <= 7)
                    moves++;
            }

            // andar pra cima
            if (A >= 3)
            {
                if (B >= 1)
                    moves++;
                if (B >= 2)
                    moves++;
            }

            // andar pra baixo
            if (A <= 6)
            {
                if (B >= 1)
                    moves++;
                if (B >= 2)
                    moves++;
            }

            return moves;
        }

        // E61
        public int MaxSumWithLength(List<int> A, int B)
        {
            A.Sort();

            int totalSum = int.MinValue;
            int partialSum = 0;

            int counter = 0;

            for (int i = A.Count - 1; i > 0; i--)
            {
                partialSum += A[i];
                counter++;
                if (counter == B)
                {
                    totalSum = Math.Max(partialSum, totalSum);
                    return totalSum;
                }
            }
            return 0;
        }

        // E62 #uber# recebe dois inputs, uma frase string na name e uma lista de symbols da tabela periódica. Tem que retornar a frase destacando os elementos
        // que existem na tabela periodica e estão no inicio das palavras, exemplo:
        // name = copperfield f riddler
        // symbols = [ "Co", "F", "Po", "Ct" ]
        // resposta: [Co]pperfield [F] riddler //como riddler não possui os primeiros caracteres na tabela, retorna igual a entrada
        // O(n+s) O(s^n)
        // eu posso jogar o l2 como vazio e retirar uma cadeia de if juntando ele mesmo vazio com a palavra que eu fosse buscar na symbols;
        // passar a lista de symbols para um hashset e melhorar o find
        public static string BreakingBad(string name, List<string> symbols)
        {
            // quebra da string de input 

            var words = name.Split(' ');

            string result = "";
            char l2 = 's';
            string countTwoLetter = "";

            for (int i = 0; i < words.Count(); i++)
            {
                string current = words[i];

                // colocar validação para palavras com menos de 2 caracteres
                char l1 = current[0];

                if (current.Length >= 2)
                {
                    l2 = current[1];

                    string twoLetter = l1.ToString() + l2.ToString();

                    countTwoLetter = symbols.Find(x => x.ToLower() == twoLetter.ToLower());
                    Console.WriteLine(countTwoLetter != null ? countTwoLetter.Length : 0);
                }
                else
                {
                    countTwoLetter = null;
                }

                if (countTwoLetter != null)
                {
                    result += " [" + countTwoLetter + "]" + current.Substring(2, current.Length - 2); //colocar o resto da string name
                    Console.WriteLine("result two letter: " + result);
                }
                else
                {
                    var countOneLetter = symbols.Find(x => x.ToLower() == l1.ToString().ToLower());

                    if (countOneLetter != null)
                    {
                        result += " [" + countOneLetter + "]" + current.Substring(1, current.Length - 1); //colocar o resto da string name
                        Console.WriteLine("result one letter: " + result);
                    }
                    else
                    {
                        result += " " + current;
                        Console.WriteLine("result sem find: " + result);
                    }
                }
            }

            return result;
        }

        // E63 Determina o números de pares da lista que são divisíveis por k
        public static int DivisibleSumPairs(int n, int k, List<int> ar)
        {
            //var ar = new List<int> { 1, 2, 3, 4, 5, 6 };
            //int k = 5;
            // resposta: 3,  1+3 ; 2+3 ; 4+6
            int counter = 0;

            for (int i = 0; i < ar.Count - 1; i++)
            {
                int first = ar[i];
                for (int j = i + 1; j < ar.Count; j++)
                {
                    int sum = first + ar[j];
                    int divisible = sum % k;

                    if (divisible == 0)
                        counter++;
                }
            }

            return counter;
        }

        // E64 Contar quantas vezes cada item da queries aparece na strings. Retorna esses
        // contadores em forma de lista, onde cada um ocupa o index de sua respectiva querie
        public static List<int> MatchingStrings(List<string> strings, List<string> queries)
        {
            //var strings = new List<string> { "aba", "baba", "aba", "xzxb" };
            //var queries = new List<string> { "aba", "xzxb", "ab" };
            //resultado: [2, 1, 0]
            // tenho que contar quantas vezes cada item da queries aparece na strings, retornar 
            // esses contadores em forma de lista, onde cada um ocupa o index de sua respectiva querie

            // finxar uma querie e atravessar as strings
            List<int> result = new List<int>(queries.Count);

            for (int i = 0; i < queries.Count; i++)
            {
                string current = queries[i];
                int localCounter = 0;
                for (int j = 0; j < strings.Count; j++)
                {
                    if (current == strings[j])
                        localCounter++;
                }

                result.Add(localCounter);

                if (localCounter > 0)
                    strings.RemoveAll(x => x == current);
            }

            return result;
        }

        // E65 A personagem do exercicio mantem uma lista com os seus pontos em jogos de basquete da temporada. O algoritmo
        // deve retornar em forma de lista quantas vezes essa personagem quebrou seus recordes de mais e menos pontos por partida.
        // O retorno é em forma de lista, onde o index 0 são os recordes de mais pontos e o 1 de menos.
        public static List<int> BreakingRecords(List<int> scores)
        {
            // var scores = new List<int> {10, 5, 20, 20, 4, 5, 2, 25, 1}
            // resposta: [2, 4]
            int min = scores[0];
            int max = scores[0];
            List<int> result = new List<int>(2) { 0, 0 };

            // o que tenho que fazer é retornar contadores para as vezes que ela bateu recorde
            // de least e most pontos por jogo

            for (int i = 0; i < scores.Count; i++)
            {
                int currentScore = scores[i];

                if (currentScore < min)
                {
                    min = currentScore;
                    result[1] += 1;
                }

                if (currentScore > max)
                {
                    max = currentScore;
                    result[0] += 1;
                }
            }

            return result;
        }

        // E66 A lista de input possui elementos que se repetem duas vezes, exceto um. O Algoritmo retorna o que não se repete.
        public static int Lonelyinteger(List<int> a)
        {
            //var a = new List<int> { 1, 1, 2 };

            // lista é par, então não tem item sobrando nela
            if (a.Count % 2 == 0)
                return -1;

            a.Sort();

            for (int i = 0; i < a.Count; i++)
            {
                if (i == a.Count - 1)
                    return a[i];

                if (a[i] == a[i + 1])
                    i++;
                else
                    return a[i];
            }

            return -1;
        }

        // E67 A lista de entrada possui notas de estudantes e as abaixo de 40 são reprovadas. O algoritmo arredonda
        // para o próximo múltiplo de 5 caso a diferença da nota para o próximo multiplo de 5 é menor que 3. Se a nota
        // for menor do que 38, não adianta arredondar. A resposta é a lista de notas atualizadas.
        public static List<int> GradingStudents(List<int> grades)
        {
            //var grades = new List<int> { 75, 67,38,33 };
            // resposta: [75, 67, 40, 33]
            // se a (proximo multiplo de 5) - current  > 3 ? current : multiplo de 5 próximo
            // se a nota for menor que 38, não arredonda

            // como descobrir o próximo mútiplo de 5
            for (int i = 0; i < grades.Count; i++)
            {
                int current = grades[i];
                if (current > 37)
                {
                    int next = GetNextMultipleOf(current, 5);
                    grades[i] = next - current < 3 ? next : current;
                }
            }

            return grades;
        }

        // E67-COMPLEMENTO
        public static int GetNextMultipleOf(int valueToRound, int multipleOf)
        {
            int result = 0;
            string text = valueToRound.ToString();
            var a = text[1].ToString();
            int second = Convert.ToInt32(text[1].ToString());
            int first = Convert.ToInt32(text[0].ToString());

            if (second == 0)
                return valueToRound;

            if (second > 5)
                second = 0;
            else if (second < 5 && second > 0)
            {
                second = 5;
                result = Convert.ToInt32("" + first + second);
                return result;
            }

            if (second == 0)
                first++;

            result = Convert.ToInt32("" + first + second);

            return result;
        }

        // E68 Dentro da string de input existe uma mensagem de SOS que foi danificada. O algoritmo retorna quantas letras
        // da mensagem que foram danificadas. Exemplo:
        // s = "SOSTOT", resposta: 2  SOS'T'O'T', os dois Ts deveriam ser um S.
        public static int MarsExploration(string s)
        {
            int sosIndex = 0;
            int counter = 0;
            List<string> sos = new List<string>() { "S", "O", "S" };

            char[] input = s.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                // uso para reiniciar o index da mensagem de gabarito
                if (sosIndex == 3)
                    sosIndex = 0;

                string current = s[i].ToString();
                if (current != sos[sosIndex])
                    counter++;

                sosIndex++;
            }

            return counter;

        }

        // E69 O input 'path' contém os passos dados por uma hiker em seu hiking. Os passos consistem em 'U' para subida
        // e 'D' para descida. A caminhada é sempre iniciada e finalizada no sea level, e cada passo U ou D representa 
        // uma unidade de altitude. Para o exercício a definição de montanha é iniciada com um passo acima de sea level
        // e finalizada voltando para sea level após uma sequencia de subida, já o valley é definido por uma sequencia
        // de steps abaixo de sea level, no seu start, e finalizando com a subida para sea level.
        // O algoritmo retorna por quantos valleys o hiker passou.
        public static int CountingValleys(int steps, string path)
        {
            // string path = "UDDDUDUU"
            // resposta: 1
            int seaLevel = 0; // a cada D eu faço -1, a cada U +1
            int counter = 0; // a cada SUBIDA pra sea level, +1
            char[] input = path.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i].ToString();

                seaLevel = current == "D" ? seaLevel - 1 : seaLevel + 1;

                // terminei um valley pois SUBI para sea level
                if (seaLevel == 0 && current == "U")
                    counter++;
            }

            return counter;
        }

        // E70-REVISAO-E42
        public static string Pangrams(string s)
        {
            //string s = "We promptly judged antique ivory buckles for the next prize";
            // resultado: pangram
            List<char> letters = "abcdefghijklmnopqrstuvwxyz".ToList();
            List<char> arr = s.Trim().ToList();
            string response = "";

            for (int i = 0; i < arr.Count; i++)
            {
                string current = arr[i].ToString().ToLower();
                if (current != " ")
                {
                    int index = letters.FindIndex(x => x.ToString() == current);
                    if (index > -1)
                        letters.RemoveAt(index);
                }
            }

            response = letters.Count > 0 ? "not pangram" : "pangram";

            return response;
        }

        // E71-REVISAO-E41
        public static List<int> CountingSort2(List<int> arr)
        {
            List<int> result = new List<int>(new int[100]);
            for (int i = 0; i < arr.Count; i++)
                result[arr[i]] += 1;

            return result;
        }

        // E72-REVISAO-E15
        public static int DiagonalDifference2(List<List<int>> arr)
        {
            // 1 2 3
            // 4 5 6
            // 9 8 9
            //
            // 1+5+9 = 15 ; 3+5+9 = 17
            // |15-17| = 2;
            var a = new List<int> { 1, 2, 3 };
            var b = new List<int> { 4, 5, 6 };
            var c = new List<int> { 9, 8, 9 };

            arr.Add(a);
            arr.Add(b);
            arr.Add(c);

            int left = arr[0][0];
            int right = arr[0][arr[0].Count - 1];
            int lastIndex = arr[0].Count - 2;
            for (int i = 1; i < arr.Count; i++)
            {
                List<int> current = arr[i];
                left += current[i];
                right += current[lastIndex];

                lastIndex--;
            }

            int result = Math.Abs(left - right);
            return result;
        }

        // E73 Inverte bionary tree
        public static TreeNode InvertTree(TreeNode root)
        {
            //      1
            //   2     3            
            //  4 5   6 7


            //   2     
            //  4 5

            //      1
            //  3      2
            // 7 6    5 4

            // comum nesses algoritmos de arvore é utilizar recursion.

            // então utilizar a validação de null pra voltar ao node com valor. depth firt search, vou até
            // o final da árvore antes de começar a fazer o processo.
            if (root == null)
                return root;

            // chamo o invert até chegar no útimo node da esquerda, depois o da direita e, consequentemente, estar no último
            // galho da árvore (2) para poder começar a inverter.
            TreeNode left = InvertTree(root.left);
            TreeNode right = InvertTree(root.right);

            root.left = right;
            root.right = left;
            return root;
        }

        // E73-COMPLEMENTO
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }

            public TreeNode(int x)
            {
                val = x;
            }
        }

        // E74 Retorna se a subtree (s) completa existe na tree og. Para ser válido, a subtree tem que terminar junto com a og, combinando também
        // nos let=null e right=null que existem em todo final de binary tree.
        public static bool HasSubTree(TreeNode og, TreeNode s)
        {
            // preciso navegar na principal e ir comparando os roots, quando existir um root igual (com left e right iguais), retorna true

            // se for true, naveguei por toda a tree og e nao encontrei a subtree
            if (og == null)
                return false;

            // verifica no level atual da tree se são iguais, caso não, vai para o else avançar pela tree og
            else if (TestSubsTree(og, s))
            {
                return true;
            }
            else
            {
                // traverse da tree og, só precisa de um desses retornando true para validar que existe
                return HasSubTree(og.left, s) || HasSubTree(og.right, s);
            }
        }

        // E74-COMPLEMENTO
        public static bool TestSubsTree(TreeNode og, TreeNode s)
        {
            if (og == null || s == null)
            {
                return s == null && og == null;
            }
            // se encontrar os valores iguais, ele então pode continuar a recursion para ir verificando nos próximos nodes se 
            // continuam sendo iguais
            else if (og.val == s.val)
            {
                // caso sejam arvores iguais, essas chamadas vão navegar até ambas chegarem ao valor null, assim o primeiro if
                // retorna true;
                return TestSubsTree(og.left, s.left) && TestSubsTree(og.right, s.right);
            }
            else
            {
                // se os valores não batem, então retorna false para todas as chamadas, até chegar na principal que vai traversar na og
                return false;
            }

        }

        // E75 Write a RECURSIVE funcion that given an integer input n, sums all non negative integer up to n
        public static int RecursiveUpToN(int n)
        {
            // 15
            return SolveUpTo(0, n, 0);
        }

        // E75-COMPLEMENTO
        public static int SolveUpTo(int n, int target, int currentSum)
        {
            if (n == target)
            {
                return currentSum += n;
            }
            else
            {
                currentSum += n;
                return SolveUpTo(n + 1, target, currentSum);
            }
        }

        // E76 Cria uma binary tree a partir de uma list de input. Com o exemplo arr = [ 1, 2, 3, 4, 5, 6]
        //        1
        //     2     3
        //    4 5   6
        public static TreeNode CreateTreeByList(List<int> arr)
        {
            //List<int> arr = new List<int> { 1, 2, 5, 6, 8, 12 };
            TreeNode result = new TreeNode(arr[0]);
            // shallow copy para poder correr a árvore
            var runner = result;

            Queue<TreeNode> q = new Queue<TreeNode>();

            int index = 1;

            // crio os primeiros nodes e utilizo a Queue para salvar o próximo level da arvore que precisa
            // adicionar left e right
            runner.left = new TreeNode(arr[index]);
            q.Enqueue(runner.left);

            if (index + 1 < arr.Count)
            {
                runner.right = new TreeNode(arr[index + 1]);
                q.Enqueue(runner.right);
            }


            index = 3;
            // esse loop vai ir navegando pela queue e adicionar os próximos elementos da arvore pela left e right
            // até que a array termine
            while (q.Count > 0 && index < arr.Count)
            {
                runner = q.Dequeue();

                runner.left = new TreeNode(arr[index]);
                // já adicionar na queue pois é o próximo level da árvore para se completada
                q.Enqueue(runner.left);
                index++;
                if (index < arr.Count)
                {
                    runner.right = new TreeNode(arr[index]);
                    q.Enqueue(runner.right);
                    index++;
                }

            }

            return result;
        }

        // E77-REVISAO-E43
        public static int Birthday2()
        {
            // encontrar uma subarray com o length de m, que somada resulta no d
            List<int> s = new List<int>();
            int d = 4;
            int m = 2;

            int currentSum = 0;
            int counter = 0;

            int length = 0;
            int firstIndex = 0;

            //sliding window
            for(int i = 0; i < s.Count; i++)
            {
                int current = s[i];
                currentSum += current;
                length++;

                if(length == m)
                {
                    counter = currentSum == d ? counter + 1 : counter;
                    length--;
                    currentSum -= s[firstIndex];
                    firstIndex++;
                }
            }

            return counter;
        }

        // E78 Cada item na lista é o id de um pássaro avistado. O método retorna o id do pássaro mais visto, caso tenha a mesma 
        // frequencia em mais de um id, tem que retornar o menor dos ids. O(n x l) onde l é o length da lista distinct
        public static int MigratoryBirds(List<int> arr)
        {
            // get the frequency from the birds ids
            int id = 0;
            int freq = 0;
            // [ 1,1,2,2,3 ]

            // use the distinct to get the different ids on the existing list
            var distinct = arr.Distinct(); // 1,2,3
            
            // foreach because the distinct is a Ienumerable
            foreach(int obj in distinct)
            {
                // get how many times the number appears on the main list
                int count = arr.FindAll(x => x == obj).Count; //2
                if(count >= freq)
                {
                    // if the frequency is the same, get the smallest id
                    if(count == freq)
                        id = obj < id ? obj : id;
                    // otherwise, update the most frequent id and his frequency
                    else
                    {
                        id = obj;
                        freq = count;
                    }
                }
            }

            return id;
        }

        // E79-REVISAO-E44
        public static int SockMerchant2(int n, List<int> ar)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int pairs = 0;

            // add on the dictionary the number of times each sock appears
            for (int i = 0; i < ar.Count; i++)
            {
                int current = ar[i];
                if (dic.ContainsKey(current))
                    dic[current] += 1;
                else
                    dic.Add(current, 1);
            }

            // for every sock, transform the number of times it appears in a even number and calculate
            // the number os pairs by dividing by two
            foreach (var data in dic)
            {
                int times = data.Value;

                if (times % 2 != 0)
                    times -= 1;

                pairs += times / 2;
            }

            return pairs;
        }

        // E80-REVISAO-E45
        public static int PageCount2(int n, int p)
        {
            // count the min number of pages that must be turned
            // 1 23 45 67 89 10,11
            // n 5/ F = 2, B = 3

            // transform n and p in even numbers
            // frontFormula = n / 2;
            // endFormula = (p - n) / 2;

            if (n % 2 != 0)
                n -= 1;

            if (p % 2 != 0)
                p -= 1;

            int start = p / 2;
            int end = (n - p) / 2;

            return Math.Min(start, end);
        }

        // E81 Given the input array, find the pair with the smallest absolute difference and return tha pair in a array. If there is more than 
        // one pair, return them all.
        public static List<int> ClosestNumbers(List<int> arr)
        {
            //  0 1  2  3  4
            // -5 15 25 63 71
            // if I find a new min difference, clear the response list
            arr.Sort();
            int diff = int.MaxValue;
            List<int> res = new List<int>();

            for (int i = 0; i < arr.Count - 1; i++)
            {
                // cálculo para pegar a diferença absoluta atual. Como eu faço a conta usando i+1, o for
                // tem a condição de arr.Count-1 para eu não atingir o index inexistente.
                int currentDiff = Math.Abs(arr[i] - arr[i + 1]);

                // se a currentDiff for menor que a diff principal até então, limpo a lista de resposta
                // (já que não tinha a menor diff da array) e adiciono o par da diferença atual
                if (currentDiff < diff)
                {
                    diff = currentDiff;
                    res.Clear();
                    res.Add(arr[i]);
                    res.Add(arr[i + 1]);
                }
                else if (currentDiff == diff)
                {
                    res.Add(arr[i]);
                    res.Add(arr[i + 1]);
                }
            }

            return res;
        }

        public static void Test()
        {
            var og = new TreeNode(1);
            og.left = new TreeNode(2);
            og.right = new TreeNode(3);

            og.left.left = new TreeNode(4);
            og.left.right = new TreeNode(5);

            og.right.left = new TreeNode(6);
            og.right.right = new TreeNode(7);

            var s = new TreeNode(2);
            s.left = new TreeNode(4);
            s.right = new TreeNode(5);

            var result = HasSubTree(og, s);
        }

        public static ListNode RemoveNthFromEnd(int B)
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
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

            while (A != null)
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
            }
            else
            {
                while (runner.next != null)
                {
                    if (count == subtraction)
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

        public static int DistributeCady()
        {
            var A = new List<int> { 1, 2, 3 };
            //posso começar do segundo, se o anterior for menor e o posterior também, eu somo 4 no resultado 1 -> 2 -> 1

            //verifica um por um, vizinho de tras é < tu adiciona dois, vizinho da frente é maior que o de tras, adiciona 3

            // talvez um recursivo validando se é maior ou menor e somando ao resultado final

            int result = 0;
            int lastResult = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach(var x in dic)
            {
                int a = x.Value;
            }

            for (int i = 0; i < A.Count; i++)
            {
                if (i != 0)
                {
                    int current = A[i];
                    int sum = 1;
                    // checo anterior e posterior
                    if (A[i - 1] < current)
                    {
                        sum = sum + (lastResult - sum) + 1;
                    }

                    if (i < A.Count - 1)
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
