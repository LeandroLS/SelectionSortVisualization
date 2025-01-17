using Raylib_cs;
using static Raylib_cs.Raylib;
namespace HelloWorld;

public class Line
{
  public int Height { get; set; }
  public bool IsActive { get; set; } = false;
  public Line(int height)
  {
    Height = height;
  }
}
class Program
{
  public const int MaxLines = 100;
  public bool IsPaused = false;
  public List<Line> Lines { get; set; } = new List<Line>();
  private int CurrentLineIndex = 0;
  public void TogglePause()
  {
    IsPaused = !IsPaused;
  }
  public static void Main()
  {
    Program program = new Program();
    Random random = new Random();

    for (int i = 0; i < MaxLines; i++)
    {
      program.Lines.Add(new Line(random.Next(1, 100)));
    }
    InitWindow(800, 480, "Algorithm Visualization");
    SetTargetFPS(10);
    while (!WindowShouldClose())
    {
      Console.WriteLine($"current index {program.CurrentLineIndex}");
      Console.WriteLine($"program.IsPaused {program.IsPaused}");
      BeginDrawing();
      DrawText("Algorithm Visualization", 12, 12, 20, Color.Black);
      DrawText("Press SPACE to pause", GetScreenWidth() / 3, 12, 20, Color.Red);
      ClearBackground(Color.White);
      DrawFPS(GetScreenWidth() - 150, 12);
      if (IsKeyPressed(KeyboardKey.Space))
      {
        program.TogglePause();
      }
      if (program.IsPaused)
      {
        DrawText("Paused", 350, 200, 20, Color.Gray);
      }
      else
      {
        if (program.CurrentLineIndex > 0)
        {
          program.Lines[program.CurrentLineIndex - 1].IsActive = false;
        }
        program.Lines[program.CurrentLineIndex].IsActive = true;
        program.CurrentLineIndex = program.CurrentLineIndex + 1;
        for (int i = 0; i < program.Lines.Count(); i++)
        {
          DrawLine(
            GetScreenWidth() / 5 + i,
            GetScreenHeight() - 10 - program.Lines[i].Height,
            GetScreenWidth() / 5 + i, GetScreenHeight() - 10,
            program.Lines[i].IsActive ? Color.Red : Color.Blue
          );
        }
        if (program.CurrentLineIndex == MaxLines)
        {
          program.Lines.Last().IsActive = false;
          program.CurrentLineIndex = 0;
          program.IsPaused = true;
        }
      }
      EndDrawing();
    }
    CloseWindow();
  }
}
