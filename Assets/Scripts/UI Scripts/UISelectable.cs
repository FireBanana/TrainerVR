using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectable : MonoBehaviour
{
    public Selectable selectable;
    public void Select()
    {
        selectable.Select();
    }
}
