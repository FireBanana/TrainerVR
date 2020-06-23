using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SupplementScreenManager
{
    public static string Instructions;
    public static string NextLevel;

    public static string TimeToComplete, Score, ExtraInfo;

    public static void ShowInstructions(string instructions, string nextLevel, bool enableTimer, int timeAlloted, ScenarioManager.Scenario type = ScenarioManager.Scenario.FreeRoam)
    {
        Instructions = instructions;
        NextLevel = nextLevel;
        ScenarioManager.BaseTime = timeAlloted;
        ScenarioManager.EnableTimer = enableTimer;
        ScenarioManager.CurrentScenario = type;
        SceneManager.LoadScene("Instructions");
    }

    //serparate extraInfo with \n and formatted
    public static void ShowEnding(string time, string score, string nextLevel, string extraInfo)
    {
        TimeToComplete = time;
        Score = score;
        ExtraInfo = extraInfo;
        NextLevel = nextLevel;
        SceneManager.LoadScene("EndScreen");

    }
}
