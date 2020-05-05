using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionsInitializer : MonoBehaviour
{
    public TextMeshPro Description;
    public GoToLevel goToLevel;
    void Start()
    {
        goToLevel.Level = InstructionsManager.NextLevel;
        Description.text = InstructionsManager.Instructions;
    }
}
