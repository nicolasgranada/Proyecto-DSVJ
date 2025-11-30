using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public static class GameSettings
{
    public static Difficulty currentDifficulty = Difficulty.Easy;
}
