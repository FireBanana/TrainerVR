using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : Selectable
{
    public string Level;

    public override void Select()
    {
        SceneManager.LoadScene(Level);
    }
}
