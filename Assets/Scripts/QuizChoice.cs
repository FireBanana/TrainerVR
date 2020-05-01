using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuizChoice : Selectable
{
    public UnityEvent Callback;

    public override void Select()
    {
        Callback.Invoke();
    }
}
