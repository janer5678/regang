using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player3Movement2 : MonoBehaviour
{
    private int OnCharacter = 1;

    private bool Clear = true;


    void Update()
    {




        if ((OnCharacter == 1) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(-5.2f, 1.01f);
        }
        if ((OnCharacter == 2) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(-0.75f, 0.86f);
        }
        if ((OnCharacter == 3) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(3.89f, 0.95f);
        }
        if ((OnCharacter == 4) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(-5.21f, -0.63f);
        }

        if ((OnCharacter == 5) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(-0.82f, -0.79f);
        }

        if ((OnCharacter == 6) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(3.89f, -0.66f);
        }

        if ((OnCharacter == 7) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(-5.26f, -2.51f);
        }

        if ((OnCharacter == 8) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(-0.83f, -2.51f);
        }

        if ((OnCharacter == 9) && (Clear == true))
        {
            gameObject.transform.position = new Vector2(3.96f, -2.64f);
        }



        if (Input.GetKeyDown(KeyCode.L) && OnCharacter == 1)
        {
            OnCharacter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.L) && OnCharacter == 2)
        {
            OnCharacter = 3;
        }
        else if (Input.GetKeyDown(KeyCode.J) && OnCharacter == 2)
        {
            OnCharacter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.J) && OnCharacter == 3)
        {
            OnCharacter = 2;
        }


        else if (Input.GetKeyDown(KeyCode.L) && OnCharacter == 4)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.L) && OnCharacter == 5)
        {
            OnCharacter = 6;
        }


        else if (Input.GetKeyDown(KeyCode.J) && OnCharacter == 5)
        {
            OnCharacter = 4;
        }
        else if (Input.GetKeyDown(KeyCode.J) && OnCharacter == 6)
        {
            OnCharacter = 5;
        }

        else if (Input.GetKeyDown(KeyCode.K) && OnCharacter == 1)
        {
            OnCharacter = 4;
        }

        else if (Input.GetKeyDown(KeyCode.K) && OnCharacter == 4)
        {
            OnCharacter = 7;
        }
        
        else if (Input.GetKeyDown(KeyCode.L) && OnCharacter == 7)
        {
            OnCharacter = 8;
        }
        else if (Input.GetKeyDown(KeyCode.L) && OnCharacter == 8)
        {
            OnCharacter = 9;
        }
        else if (Input.GetKeyDown(KeyCode.J) && OnCharacter == 9)
        {
            OnCharacter = 8;
        }
        else if (Input.GetKeyDown(KeyCode.J) && OnCharacter == 8)
        {
            OnCharacter = 7;
        }

        else if (Input.GetKeyDown(KeyCode.I) && OnCharacter == 7)
        {
            OnCharacter = 4;
        }
        else if (Input.GetKeyDown(KeyCode.I) && OnCharacter == 4)
        {
            OnCharacter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.I) && OnCharacter == 5)
        {
            OnCharacter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.I) && OnCharacter == 8)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.K) && OnCharacter == 2)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.K) && OnCharacter == 5)
        {
            OnCharacter = 8;
        }

        else if (Input.GetKeyDown(KeyCode.K) && OnCharacter == 3)
        {
            OnCharacter = 6;
        }
        else if (Input.GetKeyDown(KeyCode.K) && OnCharacter == 6)
        {
            OnCharacter = 9;
        }
        else if (Input.GetKeyDown(KeyCode.I) && OnCharacter == 9)
        {
            OnCharacter = 6;
        }
        else if (Input.GetKeyDown(KeyCode.I) && OnCharacter == 6)
        {
            OnCharacter = 3;
        }

    }
}
