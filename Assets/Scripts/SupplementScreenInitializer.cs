using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class SupplementScreenInitializer : MonoBehaviour
{
    public TextMeshPro Description;
    public GoToLevel goToLevel;
    public bool isInstruction;

    void Start()
    {
        if (isInstruction)
        {
            goToLevel.Level = SupplementScreenManager.NextLevel;
            Description.text = SupplementScreenManager.Instructions;
        }
        else
        {
            var builder = new StringBuilder();
            builder.Append("Your progress is:\n\n")
                .Append($"Time: {SupplementScreenManager.TimeToComplete}\n")
                .Append(SupplementScreenManager.ExtraInfo)
                .Append($"Score: {SupplementScreenManager.Score}\n");

            Description.text = builder.ToString();
        }
    }
}
