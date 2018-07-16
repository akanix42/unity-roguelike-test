using System.Collections.Generic;

public class GameBoardElementPosition
{
  private static Dictionary<int, GameBoardElementPosition[][]> positions =
    new Dictionary<int, GameBoardElementPosition[][]>();

  public static GameBoardElementPosition Create(int levelId, int x, int y)
  {
    GameBoardElementPosition[][] levelPositions;
    if (positions.TryGetValue(levelId, out levelPositions))
      return levelPositions[x][y];

    var level = Contexts.sharedInstance.level.GetEntityWithLevel(levelId).level;
    levelPositions = new GameBoardElementPosition[level.columns][];
    for (var col = 0; col < levelPositions.Length; col++)
    {
      var rows = levelPositions[col] = new GameBoardElementPosition[level.rows];
      for (var row = 0; row < rows.Length; row++)
      {
        rows[row] = new GameBoardElementPosition(levelId, col, row);
      }
    }

    positions.Add(levelId, levelPositions);
    return levelPositions[x][y];
  }

  private GameBoardElementPosition(int levelId, int x, int y)
  {
    this.levelId = levelId;
    this.x = x;
    this.y = y;
  }

  public readonly int levelId;
  public readonly int x;
  public readonly int y;
}