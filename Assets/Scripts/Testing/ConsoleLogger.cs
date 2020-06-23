using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConsoleLogger : MonoBehaviour
{
    public GameObject Template;
    public static ConsoleLogger Instance;
    public Transform Parent;
    List<GameObject> logs = new List<GameObject>();
    int count = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Log(object item)
    {
        if(count > 50)
        {
            Destroy(logs[0]);
            logs.RemoveAt(0);
        }
        else
        {
            count++;
        }

        var newLog = Instantiate(Template);        
        newLog.SetActive(true);
        newLog.GetComponent<Text>().text = item.ToString();
        newLog.transform.parent = Parent;
        newLog.transform.localScale = Vector3.one;
        newLog.transform.localEulerAngles = Vector3.zero;
        newLog.transform.localPosition = Vector3.zero;
        logs.Add(newLog);
        
    }

}
