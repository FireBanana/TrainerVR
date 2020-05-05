using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class InstructionsManager
{
    public static string Instructions;
    public static string NextLevel;

   public static void ShowInstructions(string instructions, string nextLevel)
    {
        Instructions = instructions;
        NextLevel = nextLevel;
        SceneManager.LoadScene("Instructions");
    }
}
