using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCscript : MonoBehaviour
{
    public static int mapnumber = 1;

    public GameObject MovingFloorMap;
    public GameObject PipeMap;


    private void Update()
    {

        if (mapnumber == 1)
        {
            MovingFloorMap.SetActive(true);
            PipeMap.SetActive(false);
        }
        else if (mapnumber == 2)
        {
            PipeMap.SetActive(true);
            MovingFloorMap.SetActive(false);
        }

    }
}
