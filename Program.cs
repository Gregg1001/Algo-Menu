using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoMenuApp
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== Algorithm Menu ===\n");
                Console.WriteLine("1) Reverse String (diagram)");
                Console.WriteLine();
                Console.WriteLine("2) Factorial (diagram)");
                Console.WriteLine();
                Console.WriteLine("3) Fibonacci (diagram)");
                Console.WriteLine();
                Console.WriteLine("4) Binary Search (diagram)");
                Console.WriteLine();
                Console.WriteLine("5) Palindrome Check (diagram)");
                Console.WriteLine();
                Console.WriteLine("6) Merge Sort (diagram)");
                Console.WriteLine();
                Console.WriteLine("7) Kadane's Max Subarray (diagram)");
                Console.WriteLine();
                Console.WriteLine("8) Two Sum (diagram)");
                Console.WriteLine();
                Console.WriteLine("9) Reverse Linked List (diagram)");
                Console.WriteLine();
                Console.WriteLine("10) Tree Traversal Inorder (diagram)");
                Console.WriteLine();
                Console.WriteLine("0) Exit\n");
                Console.Write("Select: ");

                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == "0") break;

                switch (input)
                {
                    case "1": RunReverseString(); break;
                    case "2": RunFactorial(); break;
                    case "3": RunFibonacci(); break;
                    case "4": RunBinarySearch(); break;
                    case "5": RunPalindrome(); break;
                    case "6": RunMergeSort(); break;
                    case "7": RunKadane(); break;
                    case "8": RunTwoSum(); break;
                    case "9": RunReverseLinkedList(); break;
                    case "10": RunTreeTraversal(); break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey(intercept: true);
            }
        }

        // ---------- UI helpers ----------
        static void Title(string t)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(t);
            Console.ResetColor();
            Console.WriteLine();
        }
        static void Question(string q) { Console.WriteLine($"Question: {q}\n"); }
        static void Hook(string h) { Console.WriteLine($"Hook: {h}\n"); }
        static void Explain(string e) { Console.WriteLine("Explanation:"); Console.WriteLine(e + "\n"); }
        static void Block(string label, string content)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{label}:");
            Console.ResetColor();
            Console.WriteLine(content + "\n");
        }

        // ---------- Pseudocode ----------
        const string PseudoReverseString =
@"Reverse String → O(n)
i = 0; j = len - 1
while i < j:
  swap(s[i], s[j])
  i++; j--";

        const string PseudoFactorial =
@"Factorial → O(n)
fact(n):
  if n <= 1: return 1
  return n * fact(n - 1)";

        const string PseudoFibonacci =
@"Fibonacci (naive) → O(2^n)
fib(n):
  if n <= 1: return n
  return fib(n - 1) + fib(n - 2)";

        const string PseudoBinarySearch =
@"Binary Search → O(log n)
while low <= high:
  mid = (low + high) // 2
  if arr[mid] == target: return mid
  elif arr[mid] < target: low = mid + 1
  else: high = mid - 1";

        const string PseudoPalindrome =
@"Palindrome → O(n)
i = 0; j = len - 1
while i < j:
  if s[i] != s[j]: return false
  i++; j--
return true";

        const string PseudoMergeSort =
@"Merge Sort → O(n log n)
mergeSort(a):
  if len(a) <= 1: return a
  mid = len(a)//2
  L = mergeSort(a[:mid])
  R = mergeSort(a[mid:])
  return merge(L, R)";

        const string PseudoKadane =
@"Kadane → O(n)
best = cur = a[0]
for x in a[1:]:
  cur = max(x, cur + x)
  best = max(best, cur)
return best";

        const string PseudoTwoSum =
@"Two Sum → O(n)
map = {} // value -> index
for i, x in enumerate(a):
  if target - x in map: return [map[target-x], i]
  map[x] = i
return []";

        const string PseudoReverseList =
@"Reverse Linked List → O(n)
prev = null; cur = head
while cur:
  next = cur.next
  cur.next = prev
  prev = cur
  cur = next
return prev";

        const string PseudoInorder =
@"Inorder Traversal → O(n)
inorder(node):
  if node == null: return
  inorder(node.left)
  visit(node.val)
  inorder(node.right)";

        // ---------- Code Snippets ----------
        const string CodeReverseString =
@"public static string ReverseString(string s) {
  var a = s.ToCharArray();
  int i = 0, j = a.Length - 1;
  while (i < j) { (a[i], a[j]) = (a[j], a[i]); i++; j--; }
  return new string(a);
}";

        const string CodeFactorial =
@"public static long Factorial(int n) {
  if (n <= 1) return 1;
  return n * Factorial(n - 1);
}";

        const string CodeFibonacci =
@"public static long Fibonacci(int n) {
  if (n <= 1) return n;
  return Fibonacci(n - 1) + Fibonacci(n - 2);
}";

        const string CodeBinarySearch =
@"public static int BinarySearch(int[] arr, int x) {
  int low = 0, high = arr.Length - 1;
  while (low <= high) {
    int mid = low + ((high - low) / 2);
    if (arr[mid] == x) return mid;
    if (arr[mid] < x) low = mid + 1;
    else high = mid - 1;
  }
  return -1;
}";

        const string CodePalindrome =
@"public static bool IsPalindrome(string s) {
  int i = 0, j = s.Length - 1;
  while (i < j) {
    if (s[i] != s[j]) return false;
    i++; j--;
  }
  return true;
}";

        const string CodeMergeSort =
@"public static int[] MergeSort(int[] arr) {
  if (arr.Length <= 1) return arr;
  int mid = arr.Length / 2;
  var left = MergeSort(arr.Take(mid).ToArray());
  var right = MergeSort(arr.Skip(mid).ToArray());
  return Merge(left, right);
}
static int[] Merge(int[] L, int[] R) {
  var res = new int[L.Length + R.Length];
  int i = 0, j = 0, k = 0;
  while (i < L.Length && j < R.Length)
    res[k++] = (L[i] <= R[j]) ? L[i++] : R[j++];
  while (i < L.Length) res[k++] = L[i++];
  while (j < R.Length) res[k++] = R[j++];
  return res;
}";

        const string CodeKadane =
@"public static int MaxSubarraySum(int[] a) {
  int cur = a[0], best = a[0];
  for (int i = 1; i < a.Length; i++) {
    cur = Math.Max(a[i], cur + a[i]);
    best = Math.Max(best, cur);
  }
  return best;
}";

        const string CodeTwoSum =
@"public static int[] TwoSum(int[] a, int target) {
  var map = new Dictionary<int, int>();
  for (int i = 0; i < a.Length; i++) {
    int need = target - a[i];
    if (map.TryGetValue(need, out int j)) return new[] { j, i };
    map[a[i]] = i;
  }
  return Array.Empty<int>();
}";

        const string CodeReverseList =
@"public static ListNode ReverseList(ListNode head) {
  ListNode prev = null, cur = head;
  while (cur != null) {
    var next = cur.next;
    cur.next = prev;
    prev = cur;
    cur = next;
  }
  return prev;
}";

        const string CodeInorder =
@"public static void Inorder(TreeNode n, Action<int> visit) {
  if (n == null) return;
  Inorder(n.left, visit);
  visit(n.val);
  Inorder(n.right, visit);
}";

        // ---------- Diagrams ----------
        static void DiagramReverseString()
        {
            Console.WriteLine("Diagram:\n");
            Console.WriteLine("Initial:");
            Console.WriteLine("[H][E][L][L][O]");
            Console.WriteLine(" ^           ^");
            Console.WriteLine(" i           j\n");
            Console.WriteLine("Swap:");
            Console.WriteLine("[O][E][L][L][H]");
            Console.WriteLine("   ^       ^");
            Console.WriteLine("   i       j\n");
            Console.WriteLine("Next:");
            Console.WriteLine("[O][L][L][E][H]");
            Console.WriteLine("     ^   ^");
            Console.WriteLine("     i   j\n");
            Console.WriteLine("Final:");
            Console.WriteLine("[O][L][L][E][H]\n");
        }

        static void DiagramFactorial()
        {
            Console.WriteLine("Diagram (n = 4):\n");
            Console.WriteLine("fact(4)");
            Console.WriteLine("  4 * fact(3)");
            Console.WriteLine("      3 * fact(2)");
            Console.WriteLine("          2 * fact(1)");
            Console.WriteLine("              1");
            Console.WriteLine("          = 2");
            Console.WriteLine("      = 6");
            Console.WriteLine("  = 24\n");
        }

        static void DiagramFibonacci()
        {
            Console.WriteLine("Diagram (n = 5):\n");
            Console.WriteLine("fib(5)");
            Console.WriteLine(" ├─ fib(4)");
            Console.WriteLine(" │   ├─ fib(3)");
            Console.WriteLine(" │   │   ├─ fib(2) -> 1");
            Console.WriteLine(" │   │   └─ fib(1) -> 1");
            Console.WriteLine(" │   └─ fib(2) -> 1");
            Console.WriteLine(" └─ fib(3)");
            Console.WriteLine("     ├─ fib(2) -> 1");
            Console.WriteLine("     └─ fib(1) -> 1");
            Console.WriteLine("Total calls explode (2^n)\n");
        }

        static void DiagramBinarySearch()
        {
            Console.WriteLine("Diagram (target=23):\n");
            Console.WriteLine("[ 1][ 3][ 5][ 7][ 9][11][15][23][42][56][78][99]");
            Console.WriteLine("  L                 M                 H");
            Console.WriteLine(" low=0            mid=5            high=11  a[mid]=11 < 23  => low = mid+1\n");
            Console.WriteLine("[ 1][ 3][ 5][ 7][ 9][11][15][23][42][56][78][99]");
            Console.WriteLine("                      L     M            H");
            Console.WriteLine("                    low=6 mid=8       high=11  a[mid]=42 > 23  => high = mid-1\n");
            Console.WriteLine("[ 1][ 3][ 5][ 7][ 9][11][15][23][42][56][78][99]");
            Console.WriteLine("                      L  M H");
            Console.WriteLine("                    low=6 8 10  mid=8  a[mid]=42 > 23 => high=7\n");
            Console.WriteLine("[ 1][ 3][ 5][ 7][ 9][11][15][23][42][56][78][99]");
            Console.WriteLine("                      L M/H");
            Console.WriteLine("                    low=6 mid=7 high=7  a[mid]=23 == target ✔\n");
        }

        static void DiagramPalindrome()
        {
            Console.WriteLine("Diagram (\"racecar\"):\n");
            Console.WriteLine("[r][a][c][e][c][a][r]");
            Console.WriteLine(" ^                   ^");
            Console.WriteLine(" i                   j  r == r ✓\n");
            Console.WriteLine("[r][a][c][e][c][a][r]");
            Console.WriteLine("    ^             ^");
            Console.WriteLine("    i             j  a == a ✓\n");
            Console.WriteLine("[r][a][c][e][c][a][r]");
            Console.WriteLine("       ^       ^");
            Console.WriteLine("       i       j  c == c ✓\n");
            Console.WriteLine("Center reached → palindrome true\n");
        }

        static void DiagramMergeSort()
        {
            Console.WriteLine("Diagram:\n");
            Console.WriteLine("Split:");
            Console.WriteLine("[5 1 9 3 7 2 8 6 4]");
            Console.WriteLine("   /             \\");
            Console.WriteLine("[5 1 9 3]     [7 2 8 6 4]");
            Console.WriteLine(" /    \\         /      \\");
            Console.WriteLine("[5 1] [9 3]   [7 2]  [8 6 4]");
            Console.WriteLine(" / \\   / \\     / \\     /   \\");
            Console.WriteLine("[5][1][9][3] [7][2] [8][6 4]");
            Console.WriteLine("\nMerge:");
            Console.WriteLine("[5][1] -> [1 5]    [9][3] -> [3 9]");
            Console.WriteLine("[7][2] -> [2 7]    [6][4] -> [4 6]");
            Console.WriteLine("[8][4 6] -> [4 6 8]");
            Console.WriteLine("[1 5] + [3 9] -> [1 3 5 9]");
            Console.WriteLine("[2 7] + [4 6 8] -> [2 4 6 7 8]");
            Console.WriteLine("[1 3 5 9] + [2 4 6 7 8] -> [1 2 3 4 5 6 7 8 9]\n");
        }

        static void DiagramKadane()
        {
            Console.WriteLine("Diagram (a = [-2,1,-3,4,-1,2,1,-5,4]):\n");
            Console.WriteLine(" idx:  0  1  2  3   4  5  6   7  8");
            Console.WriteLine(" val: -2  1 -3  4  -1  2  1  -5  4");
            Console.WriteLine(" cur: -2  1 -2  4   3  5  6   1  5");
            Console.WriteLine("best: -2  1  1  4   4  5  6   6  6");
            Console.WriteLine("\nMax subarray sum = 6 (subarray [4,-1,2,1])\n");
        }

        static void DiagramTwoSum()
        {
            Console.WriteLine("Diagram (a=[2,7,11,15], target=9):\n");
            Console.WriteLine("i=0, x=2, need=7  map={}        → store 2:0");
            Console.WriteLine("i=1, x=7, need=2  map={2:0}     → found need=2 at 0  => [0,1]\n");
            Console.WriteLine("Indices [0,1] -> 2+7 = 9\n");
        }

        static void DiagramReverseLinkedList()
        {
            Console.WriteLine("Diagram:\n");
            Console.WriteLine("Initial:");
            Console.WriteLine("[1] -> [2] -> [3] -> [4] -> [5] -> null");
            Console.WriteLine("prev  cur   next\n");
            Console.WriteLine("Iter1: next=2; cur.next=prev(null)");
            Console.WriteLine("[1]   [2] -> [3] -> [4] -> [5]");
            Console.WriteLine(" ^");
            Console.WriteLine("prev  cur\n");
            Console.WriteLine("Iter2: next=3; cur.next=prev(1)");
            Console.WriteLine("[2] -> [1]   [3] -> [4] -> [5]");
            Console.WriteLine("        ^");
            Console.WriteLine("       prev   cur\n");
            Console.WriteLine("... continue ...\n");
            Console.WriteLine("Final:");
            Console.WriteLine("null <- [1] <- [2] <- [3] <- [4] <- [5]");
            Console.WriteLine("                         prev\n");
        }

        static void DiagramInorder()
        {
            Console.WriteLine("Diagram (BST):\n");
            Console.WriteLine("      4");
            Console.WriteLine("    /   \\");
            Console.WriteLine("   2     6");
            Console.WriteLine("  / \\   / \\");
            Console.WriteLine(" 1   3 5   7\n");
            Console.WriteLine("Inorder (LNR): visit 1,2,3,4,5,6,7");
            Console.WriteLine("Call stack shape follows the left edge first, then unwinds.\n");
        }

        // ---------- Runners ----------
        static void RunReverseString()
        {
            Title("=== Reverse String ===");
            string s = "HELLO";
            Question($"Reverse \"{s}\"");
            Hook("Swap ends.");
            Block("Pseudocode", PseudoReverseString);
            DiagramReverseString();
            Explain("Two pointers move toward the center, swapping each pair once → O(n) time, O(1) space.");
            Block("C# Code", CodeReverseString);
            Console.WriteLine($"Answer: {Algos.ReverseString(s)}\n");
        }

        static void RunFactorial()
        {
            Title("=== Factorial ===");
            int n = 4;
            Question($"Compute {n}!");
            Hook("Self-multiply.");
            Block("Pseudocode", PseudoFactorial);
            DiagramFactorial();
            Explain("Linear recursion depth n; multiply down to base case 1 → O(n) time, O(n) stack.");
            Block("C# Code", CodeFactorial);
            Console.WriteLine($"Answer: {Algos.Factorial(n)}\n");
        }

        static void RunFibonacci()
        {
            Title("=== Fibonacci (Naive) ===");
            int n = 5;
            Question($"Compute fib({n})");
            Hook("Two steps back.");
            Block("Pseudocode", PseudoFibonacci);
            DiagramFibonacci();
            Explain("Naive recursion duplicates work; exponential calls → O(2^n) time. Memoization fixes this.");
            Block("C# Code", CodeFibonacci);
            Console.WriteLine($"Answer: {Algos.Fibonacci(n)}\n");
        }

        static void RunBinarySearch()
        {
            Title("=== Binary Search ===");
            int[] arr = { 1, 3, 5, 7, 9, 11, 15, 23, 42, 56, 78, 99 };
            int target = 23;
            Question($"Find index of {target} in [{string.Join(", ", arr)}]");
            Hook("Middle test.");
            Block("Pseudocode", PseudoBinarySearch);
            DiagramBinarySearch();
            Explain("Halves the search space each step → O(log n) time with O(1) space.");
            Block("C# Code", CodeBinarySearch);
            Console.WriteLine($"Answer: {Algos.BinarySearch(arr, target)}\n");
        }

        static void RunPalindrome()
        {
            Title("=== Palindrome Check ===");
            string s = "racecar";
            Question($"Is \"{s}\" a palindrome?");
            Hook("Mirror test.");
            Block("Pseudocode", PseudoPalindrome);
            DiagramPalindrome();
            Explain("Compare symmetric positions; first mismatch fails → O(n) time, O(1) space.");
            Block("C# Code", CodePalindrome);
            Console.WriteLine($"Answer: {Algos.IsPalindrome(s)}\n");
        }

        static void RunMergeSort()
        {
            Title("=== Merge Sort ===");
            int[] a = { 5, 1, 9, 3, 7, 2, 8, 6, 4 };
            Question($"Sort [{string.Join(", ", a)}]");
            Hook("Split & merge.");
            Block("Pseudocode", PseudoMergeSort);
            DiagramMergeSort();
            Explain("Divide array, sort halves, merge in linear time per level → O(n log n) time, O(n) extra.");
            Block("C# Code", CodeMergeSort);
            Console.WriteLine($"Answer: [{string.Join(", ", Algos.MergeSort(a))}]\n");
        }

        static void RunKadane()
        {
            Title("=== Kadane's Max Subarray ===");
            int[] a = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            Question($"Max subarray sum in [{string.Join(", ", a)}]");
            Hook("Carry best sum.");
            Block("Pseudocode", PseudoKadane);
            DiagramKadane();
            Explain("cur keeps best sum ending here; best tracks global max → O(n) time, O(1) space.");
            Block("C# Code", CodeKadane);
            Console.WriteLine($"Answer: {Algos.MaxSubarraySum(a)}\n");
        }

        static void RunTwoSum()
        {
            Title("=== Two Sum ===");
            int[] a = { 2, 7, 11, 15 }; int target = 9;
            Question($"Two indices in [{string.Join(", ", a)}] adding to {target}");
            Hook("Need complement.");
            Block("Pseudocode", PseudoTwoSum);
            DiagramTwoSum();
            Explain("Hash map stores seen values; lookup complement in O(1) → O(n) time, O(n) space.");
            Block("C# Code", CodeTwoSum);
            var ans = Algos.TwoSum(a, target);
            Console.WriteLine(ans.Length == 2
                ? $"Answer: [{ans[0]}, {ans[1]}] -> {a[ans[0]]}+{a[ans[1]]}={target}\n"
                : "Answer: none\n");
        }

        static void RunReverseLinkedList()
        {
            Title("=== Reverse Linked List ===");
            var head = new ListNode(1,
                        new ListNode(2,
                        new ListNode(3,
                        new ListNode(4,
                        new ListNode(5)))));
            Question("Reverse 1→2→3→4→5");
            Hook("Point backwards.");
            Block("Pseudocode", PseudoReverseList);
            DiagramReverseLinkedList();
            Explain("Iterate once flipping next pointers → O(n) time, O(1) space.");
            Block("C# Code", CodeReverseList);
            var rev = Algos.ReverseList(head);
            Console.WriteLine($"Answer: {ListAsString(rev)}\n");
        }

        static void RunTreeTraversal()
        {
            Title("=== Inorder Traversal ===");
            var root =
              new TreeNode(4,
                new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                new TreeNode(6, new TreeNode(5), new TreeNode(7)));

            Question("Print nodes in LNR order");
            Hook("Left → Node → Right.");
            Block("Pseudocode", PseudoInorder);
            DiagramInorder();
            Explain("Recursively visit left subtree, then node, then right; for BSTs yields sorted keys.");
            Block("C# Code", CodeInorder);

            Console.Write("Answer: ");
            bool first = true;
            Algos.Inorder(root, v => { if (!first) Console.Write(", "); Console.Write(v); first = false; });
            Console.WriteLine("\n");
        }

        // ---------- Util ----------
        static string ListAsString(ListNode head)
        {
            var parts = new List<string>();
            var cur = head;
            while (cur != null) { parts.Add(cur.val.ToString()); cur = cur.next; }
            return string.Join(" -> ", parts);
        }
    }

    // ---------- Algorithms ----------
    public static class Algos
    {
        public static string ReverseString(string s)
        {
            var a = s.ToCharArray();
            int i = 0, j = a.Length - 1;
            while (i < j) { (a[i], a[j]) = (a[j], a[i]); i++; j--; }
            return new string(a);
        }

        public static long Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }

        public static long Fibonacci(int n)
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static int BinarySearch(int[] arr, int x)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + ((high - low) / 2);
                if (arr[mid] == x) return mid;
                if (arr[mid] < x) low = mid + 1;
                else high = mid - 1;
            }
            return -1;
        }

        public static bool IsPalindrome(string s)
        {
            int i = 0, j = s.Length - 1;
            while (i < j)
            {
                if (s[i] != s[j]) return false;
                i++; j--;
            }
            return true;
        }

        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;
            int mid = arr.Length / 2;
            var left = MergeSort(arr.Take(mid).ToArray());
            var right = MergeSort(arr.Skip(mid).ToArray());
            return Merge(left, right);
        }

        static int[] Merge(int[] L, int[] R)
        {
            var res = new int[L.Length + R.Length];
            int i = 0, j = 0, k = 0;
            while (i < L.Length && j < R.Length)
                res[k++] = (L[i] <= R[j]) ? L[i++] : R[j++];
            while (i < L.Length) res[k++] = L[i++];
            while (j < R.Length) res[k++] = R[j++];
            return res;
        }

        public static int MaxSubarraySum(int[] a)
        {
            int cur = a[0], best = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                cur = Math.Max(a[i], cur + a[i]);
                best = Math.Max(best, cur);
            }
            return best;
        }

        public static int[] TwoSum(int[] a, int target)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                int need = target - a[i];
                if (map.TryGetValue(need, out int j)) return new[] { j, i };
                map[a[i]] = i;
            }
            return Array.Empty<int>();
        }

        public static ListNode ReverseList(ListNode head)
        {
            ListNode prev = null, cur = head;
            while (cur != null)
            {
                var next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }
            return prev;
        }

        public static void Inorder(TreeNode n, Action<int> visit)
        {
            if (n == null) return;
            Inorder(n.left, visit);
            visit(n.val);
            Inorder(n.right, visit);
        }
    }

    // ---------- Structures ----------
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int v = 0, ListNode n = null) { val = v; next = n; }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left, right;
        public TreeNode(int v = 0, TreeNode l = null, TreeNode r = null) { val = v; left = l; right = r; }
    }
}
