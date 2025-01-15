using Raylib_cs;

namespace HelloWorld;

class Program
{
  const int MaxLines = 100;

  public static void Main()
  {
    Raylib.InitWindow(800, 480, "Hello World");

    Random random = new Random();
    int[] numbers = new int[100];

    // Atribuir valores usando um loop
    for (int i = 0; i < numbers.Length; i++)
    {
      numbers[i] = random.Next(1, 100);
    }
    Console.WriteLine("numeros", numbers);

    while (!Raylib.WindowShouldClose())
    {
      Raylib.BeginDrawing();
      Raylib.ClearBackground(Color.White);

      Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);

      for (int i = 0; i < MaxLines; i++)
      {
        Console.WriteLine($"=== height === {i}");
        Raylib.DrawLine(110 + i, 600, 110 + i, 600 - numbers[i], Color.Blue);
      }

      Raylib.EndDrawing();
    }

    Raylib.CloseWindow();
  }
}
