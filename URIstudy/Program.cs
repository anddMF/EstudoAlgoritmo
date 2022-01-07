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

            for(int i = 0; i < list.Count; i++)
            {
                if(i > 0)
                {
                    if(list[i] != list[i - 1])
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
                if(i < list.Count - 2)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        int second = list[j];
                        if (firstNumber + list[j] == target)
                        {
                            // cadeia de ifs para acatar os parametros de 'indice mínimo'

                            // para a primeira alteração do index2
                            if(index2 == -1)
                            {
                                index1 = i;
                                index2 = j;
                            }

                            // a preferencia de na resposta é o menor index2
                            if(j < index2)
                            {
                                index1 = i;
                                index2 = j;
                            }

                            // se tiver mais de uma solução no indice 2, a diretiva é pegar o menor indice 1
                            if(j == index2)
                            {
                                if(i < index1)
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

            for(int i = 0; i < arr.Count; i++)
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
            for(int i = 0; i < s.Count; i++)
            {
                // percorri a lista usando um for e esse if para controlar 
                // o length dos elementos somados
                if(i - first >= m)
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

            for(int i = 0; i < ar.Count; i++)
            {
                // consulto se já existe no hs, se exister removo e incremento o contador de pares
                // se não existir, adiciono
                if (hs.Contains(ar[i]))
                {
                    hs.Remove(ar[i]);
                    result++;
                } else
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
            pagesFromBack =  (newN - newP) / 2;

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
            int a = (int)Math.Round(times,0) <= 0 ? 1 : (int)Math.Round(times, 0);
            if (a > 1)
                a--;

            string result = "";

            for(int i = 0; i < s.Length; i++)
            {
                // validação de maiúscula para manter o mesmo resultado
                bool isUppercase = Char.IsUpper(s[i]);
                char letter = Char.ToLower(s[i]);
                int index = arr.FindIndex(x => x == letter);

                if(index >= 0)
                {
                    int realIndex = index + (int)k;
                    // realIndex = realIndex > count - 1 ? realIndex - count * times : realIndex;

                    // funciona para transformar um indice muito elevado e acima do count 
                    // para um equivalento dentro dos 26 caracteres do alfabeto
                    if(realIndex > count - 1)
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
                } else
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
            for(int i = 0; i<arr.Count; i++)
            {
                totalSum += arr[i];
            }

            // essa atribuição parte da premissa de iniciar do index 1, já que não
            // tem uma subarray à esquerda do index 0. Mas o exercício considera como subarray, então 
            // é só colocar 0 aqui e no for um int j = 0
            leftSum = arr[0];
            for(int j = 1; j<arr.Count - 1; j++)
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
            string digit = "";

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

        // E48
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
