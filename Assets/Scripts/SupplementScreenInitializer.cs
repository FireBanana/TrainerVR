using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SupplementScreenInitializer : MonoBehaviour
{
    public TextMeshPro Description;
    public GoToLevel goToLevel;
    void Start()
    {
        goToLevel.Level = SupplementScreenManager.NextLevel;
        Description.text = SupplementScreenManager.Instructions;
    }
}
