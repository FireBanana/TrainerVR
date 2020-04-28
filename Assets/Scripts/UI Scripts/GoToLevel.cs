using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : UISelectable
{
    public string Level;

    public override void Select()
    {
        SceneManager.LoadScene(Level);
    }
}
