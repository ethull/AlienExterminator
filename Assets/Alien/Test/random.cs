/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
using System.Linq;

class HelloWorld {
  static int[] path;
  static void Main() {
    Console.WriteLine("Hello World");
    System.Random rnd = new System.Random();
    path = Enumerable.Range(0, 6).OrderBy(c => rnd.Next()).ToArray();
    Console.WriteLine(path);
    foreach (var item in path) {
        Console.WriteLine(item);
    }
    
  }
}