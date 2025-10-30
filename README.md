# 🧠 AlgoMenuApp

**AlgoMenuApp** is a C# console application that lets you explore classic algorithms interactively — each with pseudocode, code implementation, visual ASCII diagrams, and explanations.

---

## 📋 Features

- 🔢 **Menu-driven interface** — Choose from 10 fundamental algorithms.  
- 🧩 **Pseudocode + C# Source** — Side-by-side presentation for learning.  
- 🎨 **Text-based diagrams** — ASCII illustrations for each algorithm.  
- 📖 **Step-by-step explanations** — Focused and technically accurate.  
- ⚙️ **Fully self-contained** — No dependencies beyond .NET SDK.

---

## 🚀 Algorithms Included

| # | Algorithm | Concept | Complexity |
|---|------------|----------|-------------|
| 1 | Reverse String | Two-pointer swap | O(n) |
| 2 | Factorial | Recursion | O(n) |
| 3 | Fibonacci | Naive recursion | O(2ⁿ) |
| 4 | Binary Search | Divide & conquer | O(log n) |
| 5 | Palindrome Check | Two-pointer compare | O(n) |
| 6 | Merge Sort | Recursive sort/merge | O(n log n) |
| 7 | Kadane’s Algorithm | Max subarray sum | O(n) |
| 8 | Two Sum | Hash lookup | O(n) |
| 9 | Reverse Linked List | Pointer reversal | O(n) |
| 10 | Tree Traversal (Inorder) | DFS traversal | O(n) |

---


=== Reverse String ===

Question: Reverse "HELLO"
Hook: Swap ends.

Pseudocode:
Reverse String → O(n)
i = 0; j = len - 1
while i < j:
swap(s[i], s[j])
i++; j--

Diagram:

Initial:
[H][E][L][L][O]
^ ^
i j

Swap:
[O][E][L][L][H]
^ ^
i j

Next:
[O][L][L][E][H]
^ ^
i j

Final:
[O][L][L][E][H]

Explanation:
Two pointers move toward the center, swapping each pair once → O(n) time, O(1) space.


---

## 🧩 Structure



AlgoMenuApp/
│
├── Program.cs # Main menu & algorithm runners
├── AlgoMenuApp.csproj # .NET 8 project file
└── README.md # This file


---

## 🛠️ Build & Run

### Requirements
- .NET 8 SDK or later  
- Command line terminal (Windows Terminal, PowerShell, etc.)

### Commands
```bash
dotnet build -c Release
dotnet run -c Release

🧠 Learning Purpose

This project is designed for:
Algorithm visualization and explanation
Study reinforcement for interviews or computer science courses
Clear demonstration of algorithmic logic in C#

📘 Future Enhancements

Interactive arrow-key navigation
Animated step execution
Export diagrams to .txt or .svg
Add data structures (stack, queue, graph, heap)

👨‍💻 Author

Gregg Steffensen BIT
Senior Full Stack Software Engineer
📍 Brisbane, Australia
🔗 LinkedIn Profile

🧾 License

MIT License © 2025 Gregg Steffensen
Use freely for learning, teaching, or personal projects.

## 🖼️ Example Output

AlgoMenuApp (.NET 8 Console)

Build:
  dotnet build

Run:
  dotnet run

Menu options run each algorithm with sample inputs and print results.
