using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Player3Movement2 : MonoBehaviour
{
    //private PlayerInput playerInput;

    private int OnCharacter = 1;

    private bool Clear = true;

    //private InputDevice player1Device;

    private SpriteRenderer sp;

    PlayerControls controls;


    private int playerindex;

    void Awake()
    {
        //playerInput = GetComponent<PlayerInput>();
        sp = GetComponent<SpriteRenderer>();

        controls = new PlayerControls();


        //player1Device = Gamepad.all[0]; // Assign the first connected gamepad to Player 1

        


        controls.Gameplay.Left.performed += ctx => LeftPress(); ;
        controls.Gameplay.Right.performed += ctx => RightPress(); ;
        controls.Gameplay.Up.performed += ctx => UpPress(); ;
        controls.Gameplay.Down.performed += ctx => DownPress(); 
        controls.Gameplay.Y.performed += ctx => YPress(); 

    }

    private void YPress()
    {
        if (OnCharacter != GameController.Player2char && OnCharacter != GameController.Player1char)
            {
                GameController.Player3char = OnCharacter;
                Clear = false;
                sp.color = new Color(0.1665313f, 1f, 0f, .8f);
                GameController.yellowSelected = true;
                StaticScript.player3character = OnCharacter;
            }

    }


    private void LeftPress()
    {
        if (OnCharacter == 2)
        {
            OnCharacter = 1;
        }
        else if (OnCharacter == 3)
        {
            OnCharacter = 2;
        }
        else if (OnCharacter == 5)
        {
            OnCharacter = 4;
        }
        else if (OnCharacter == 6)
        {
            OnCharacter = 5;
        }
        else if (OnCharacter == 9)
        {
            OnCharacter = 8;
        }
        else if (OnCharacter == 8)
        {
            OnCharacter = 7;
        }

    }

    private void RightPress()
    {
        if (OnCharacter == 1)
        {
            OnCharacter = 2;
        }
        else if (OnCharacter == 2)
        {
            OnCharacter = 3;
        }
        else if (OnCharacter == 4)
        {
            OnCharacter = 5;
        }
        else if (OnCharacter == 5)
        {
            OnCharacter = 6;
        }
        else if (OnCharacter == 7)
        {
            OnCharacter = 8;
        }
        else if (OnCharacter == 8)
        {
            OnCharacter = 9;
        }





    }


    private void UpPress()
    {


        if (OnCharacter == 7)
        {
            OnCharacter = 4;
        }
        else if (OnCharacter == 4)
        {
            OnCharacter = 1;
        }
        else if (OnCharacter == 5)
        {
            OnCharacter = 2;
        }
        else if (OnCharacter == 8)
        {
            OnCharacter = 5;
        }
        else if (OnCharacter == 9)
        {
            OnCharacter = 6;
        }
        else if (OnCharacter == 6)
        {
            OnCharacter = 3;
        }


    }

    private void DownPress()
    {
        

        if (OnCharacter == 1)
        {
            OnCharacter = 4;
        }
        else if (OnCharacter == 4)
        {
            OnCharacter = 7;
        }
        else if (OnCharacter == 2)
        {
            OnCharacter = 5;
        }
        else if (OnCharacter == 5)
        {
            OnCharacter = 8;
        }
        else if (OnCharacter == 3)
        {
            OnCharacter = 6;
        }
        else if (OnCharacter == 6)
        {
            OnCharacter = 9;
        }

    }


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







        



    }


    void OnEnable ()
    {
        controls.Gameplay.Enable();

  
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }








}
