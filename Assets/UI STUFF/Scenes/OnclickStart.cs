using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnclickStart : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (GCscript.mapnumber == 1)
        {
            SceneManager.LoadScene("map2");
        }
        else if (GCscript.mapnumber == 2)
        {
            SceneManager.LoadScene("map3");
        }

    }
}
