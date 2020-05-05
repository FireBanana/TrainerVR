using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoToFunction : Selectable
{
    public UnityEvent Function;
    public override void Select()
    {
        Function.Invoke();
    }
}
