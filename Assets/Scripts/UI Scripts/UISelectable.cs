using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectable : MonoBehaviour
{
    public UISelectable Selectable;

    public virtual void Select()
    {
        Selectable.Select();
    }
}
