using Raylib_cs;
using static Raylib_cs.Raylib;
namespace HelloWorld;

class Program
{
  const int MaxLines = 100;
  public bool IsPaused = false;
  public void TogglePause()
  {
    IsPaused = !IsPaused;
  }
  public static void Main()
  {
    Program program = new Program();

    Random random = new Random();
    int[] numbers = new int[100];

    // Atribuir valores usando um loop
    for (int i = 0; i < numbers.Length; i++)
    {
      numbers[i] = random.Next(1, 100);
    }
    InitWindow(800, 480, "Algorithm Visualization");
    SetTargetFPS(60);
    while (!WindowShouldClose())
    {
      BeginDrawing();
      DrawText("Algorithm Visualization", 12, 12, 20, Color.Black);
      DrawText("Press SPACE to pause", GetScreenWidth() / 3, 12, 20, Color.Red);

      if (IsKeyPressed(KeyboardKey.Space))
      {
        program.TogglePause();
      }
      for (int i = 0; i < MaxLines; i++)
      {
        DrawLine(GetScreenWidth() / 5 + i, GetScreenHeight() - 10 - numbers[i], GetScreenWidth() / 5 + i, GetScreenHeight() - 10, Color.Blue);
      }
      ClearBackground(Color.White);
      if (program.IsPaused)
      {
        DrawText("Paused", 350, 200, 20, Color.Gray);
      }
      DrawFPS(GetScreenWidth() - 150, 12);
      EndDrawing();
    }

    CloseWindow();
  }
}
