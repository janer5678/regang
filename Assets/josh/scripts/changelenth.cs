using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changelenth : MonoBehaviour
{
    
    private void Start()
    {
        

    }

    private void Update()
    {

        float x = player2.timer1 / 1000;
        
        gameObject.transform.localScale = new Vector2(x, 0.5f);
    }
}
