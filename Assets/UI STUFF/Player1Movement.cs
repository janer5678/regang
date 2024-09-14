using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player1Movement : MonoBehaviour
{
    private int OnCharacter = 1;

    private bool Clear = true;

    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Slash))
        {

            if (OnCharacter != GameController.Player2char && OnCharacter != GameController.Player3char)
            {
                GameController.Player1char = OnCharacter;
                Clear = false;
                sp.color = new Color(.300f, .540f, 2.550f, .66f);
                GameController.blueSelected = true;
                StaticScript.player1character = OnCharacter;
            }
        }


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



        if (Input.GetKeyDown(KeyCode.RightArrow) && OnCharacter == 1)
        {
            OnCharacter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && OnCharacter == 2)
        {
            OnCharacter = 3;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && OnCharacter == 2)
        {
            OnCharacter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && OnCharacter == 3)
        {
            OnCharacter = 2;
        }


        else if (Input.GetKeyDown(KeyCode.RightArrow) && OnCharacter == 4)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && OnCharacter == 5)
        {
            OnCharacter = 6;
        }


        else if (Input.GetKeyDown(KeyCode.LeftArrow) && OnCharacter == 5)
        {
            OnCharacter = 4;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && OnCharacter == 6)
        {
            OnCharacter = 5;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && OnCharacter == 1)
        {
            OnCharacter = 4;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && OnCharacter == 4)
        {
            OnCharacter = 7;
        }
        
        else if (Input.GetKeyDown(KeyCode.RightArrow) && OnCharacter == 7)
        {
            OnCharacter = 8;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && OnCharacter == 8)
        {
            OnCharacter = 9;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && OnCharacter == 9)
        {
            OnCharacter = 8;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && OnCharacter == 8)
        {
            OnCharacter = 7;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && OnCharacter == 7)
        {
            OnCharacter = 4;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && OnCharacter == 4)
        {
            OnCharacter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && OnCharacter == 5)
        {
            OnCharacter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && OnCharacter == 8)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && OnCharacter == 2)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && OnCharacter == 5)
        {
            OnCharacter = 8;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && OnCharacter == 3)
        {
            OnCharacter = 6;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && OnCharacter == 6)
        {
            OnCharacter = 9;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && OnCharacter == 9)
        {
            OnCharacter = 6;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && OnCharacter == 6)
        {
            OnCharacter = 3;
        }

    }
}
