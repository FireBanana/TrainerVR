using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuChoices, LevelChoices;

    public void OpenQuizInstructions()
    {
        SupplementScreenManager.ShowInstructions("You are about to enter the Quiz Section. You will be shown some MCQ's. Touch the box relevant to the choice that will be shown", "QuizScene", false, -1);
    }

    public void GoToCone()
    {
        SupplementScreenManager.ShowInstructions("This is a small level in where you'll navigate through some cones. After you make a right turn, zig-zag through the next cones and collect the objects, after which you can pass the finishing cones. Make sure to not hit the cones and reach the end!", "Park", true, 100, ScenarioManager.Scenario.Cones);
    }

    public void GoToTireChange()
    {
        SupplementScreenManager.ShowInstructions("You will learn to change a tire in this scenario. You will be provided a spare tire, a screw gun, and a jack with a twisting handle. Use them to change the tire.", "Park", true, 100, ScenarioManager.Scenario.ChangeTire);
    }

    public void GoToComplete()
    {
        SupplementScreenManager.ShowInstructions("In this scenario, you'll see some rings around the track. Go through them as quickly as you can.", "Park", true, 100, ScenarioManager.Scenario.Complete);
    }

    public void OpenLevels()
    {
        LevelChoices.SetActive(true);
        MenuChoices.SetActive(false);
    }

    public void CloseLevels ()
    {
        LevelChoices.SetActive(false);
        MenuChoices.SetActive(true);
    }
}
