using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player2Movement1 : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (OnCharacter != GameController.Player1char &&  OnCharacter != GameController.Player3char)
            {
                GameController.Player2char = OnCharacter;
                Clear = false;
                sp.color = new Color(1f, 0.03272728f, 0f, .8f);
                GameController.redSelected = true;
                StaticScript.player2character = OnCharacter;
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



        if (Input.GetKeyDown(KeyCode.D) && OnCharacter == 1)
        {
            OnCharacter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.D) && OnCharacter == 2)
        {
            OnCharacter = 3;
        }
        else if (Input.GetKeyDown(KeyCode.A) && OnCharacter == 2)
        {
            OnCharacter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A) && OnCharacter == 3)
        {
            OnCharacter = 2;
        }


        else if (Input.GetKeyDown(KeyCode.D) && OnCharacter == 4)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.D) && OnCharacter == 5)
        {
            OnCharacter = 6;
        }


        else if (Input.GetKeyDown(KeyCode.A) && OnCharacter == 5)
        {
            OnCharacter = 4;
        }
        else if (Input.GetKeyDown(KeyCode.A) && OnCharacter == 6)
        {
            OnCharacter = 5;
        }

        else if (Input.GetKeyDown(KeyCode.S) && OnCharacter == 1)
        {
            OnCharacter = 4;
        }

        else if (Input.GetKeyDown(KeyCode.S) && OnCharacter == 4)
        {
            OnCharacter = 7;
        }
        
        else if (Input.GetKeyDown(KeyCode.D) && OnCharacter == 7)
        {
            OnCharacter = 8;
        }
        else if (Input.GetKeyDown(KeyCode.D) && OnCharacter == 8)
        {
            OnCharacter = 9;
        }
        else if (Input.GetKeyDown(KeyCode.A) && OnCharacter == 9)
        {
            OnCharacter = 8;
        }
        else if (Input.GetKeyDown(KeyCode.A) && OnCharacter == 8)
        {
            OnCharacter = 7;
        }
        else if (Input.GetKeyDown(KeyCode.W) && OnCharacter == 7)
        {
            OnCharacter = 4;
        }
        else if (Input.GetKeyDown(KeyCode.W) && OnCharacter == 4)
        {
            OnCharacter = 1;
        }
        else if (Input.GetKeyDown(KeyCode.W) && OnCharacter == 5)
        {
            OnCharacter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.W) && OnCharacter == 8)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.S) && OnCharacter == 2)
        {
            OnCharacter = 5;
        }
        else if (Input.GetKeyDown(KeyCode.S) && OnCharacter == 5)
        {
            OnCharacter = 8;
        }

        else if (Input.GetKeyDown(KeyCode.S) && OnCharacter == 3)
        {
            OnCharacter = 6;
        }
        else if (Input.GetKeyDown(KeyCode.S) && OnCharacter == 6)
        {
            OnCharacter = 9;
        }
        else if (Input.GetKeyDown(KeyCode.W) && OnCharacter == 9)
        {
            OnCharacter = 6;
        }
        else if (Input.GetKeyDown(KeyCode.W) && OnCharacter == 6)
        {
            OnCharacter = 3;
        }

    }
}
