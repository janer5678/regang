using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickRight : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (GCscript.mapnumber == 2)
        {
            GCscript.mapnumber = 1;
        }
        else
        {
            GCscript.mapnumber = GCscript.mapnumber + 1;
        }
    }
}
