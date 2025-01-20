using Raylib_cs;
using static Raylib_cs.Raylib;
namespace HelloWorld;

public class Line
{
  public int Height { get; set; }
  public bool IsActive { get; set; } = false;
  public bool IsSorted { get; set; } = false;
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
  private int MinIndex = 0;
  private int SortedIndex = 0;

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
      program.Lines.Add(new Line(random.Next(1, 450)));
    }

    InitWindow(1000, 580, "Selection Sort Visualization");
    InitAudioDevice();
    Sound sound = LoadSound("jump.wav");
    SetTargetFPS(60);

    while (!WindowShouldClose())
    {
      BeginDrawing();
      ClearBackground(Color.White);

      DrawText("Selection Sort Visualization", 12, 12, 20, Color.Black);
      DrawText("Press SPACE to pause", GetScreenWidth() / 3, 12, 20, Color.Red);
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
        program.StepSelectionSort();
      }

      for (int i = 0; i < program.Lines.Count; i++)
      {
        var line = program.Lines[i];
        Color lineColor;

        if (line.IsSorted)
        {
          lineColor = Color.Green;
          if (!line.IsActive)
          {
            PlaySound(sound);
            line.IsActive = true;
          }
        }
        else if (line.IsActive)
          lineColor = Color.Red;
        else
          lineColor = Color.Blue;

        DrawLine(
            GetScreenWidth() / 5 + i * 5,
            GetScreenHeight() - 10 - line.Height,
            GetScreenWidth() / 5 + i * 5,
            GetScreenHeight() - 10,
            lineColor
        );
      }
      EndDrawing();
    }

    UnloadSound(sound);
    CloseAudioDevice();
    CloseWindow();
  }

  public void StepSelectionSort()
  {
    if (SortedIndex < Lines.Count)
    {
      if (CurrentLineIndex > 0)
      {
        Lines[CurrentLineIndex - 1].IsActive = false;
      }
      Lines[CurrentLineIndex].IsActive = true;
      if (Lines[CurrentLineIndex].Height < Lines[MinIndex].Height)
      {
        MinIndex = CurrentLineIndex;
      }

      CurrentLineIndex++;

      if (CurrentLineIndex == Lines.Count)
      {
        (Lines[SortedIndex], Lines[MinIndex]) = (Lines[MinIndex], Lines[SortedIndex]);

        Lines[SortedIndex].IsSorted = true;

        SortedIndex++;
        CurrentLineIndex = SortedIndex;
        MinIndex = SortedIndex;
      }
    }
    else
    {
      IsPaused = true;
    }
  }
}
