using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OpenQuizInstructions()
    {
        InstructionsManager.ShowInstructions("You are about to enter the Quiz Section. You will be shown some MCQ's. Touch the box relevant to the choice that will be shown", "QuizScene");
    }
}
