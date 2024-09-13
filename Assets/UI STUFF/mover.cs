using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{

    private int OnCharacter = 1;
    private float inputFloat = 0f;
    private bool Clear = true;

    public static bool done;

    public void SetInputFloatLeft(float direction)
    {
        inputFloat = direction;

        if (direction == 1 && done == false)
        {
            if (OnCharacter == 2)
            {
                OnCharacter = 1;
                done = true;
            }
            else if (OnCharacter == 3)
            {
                OnCharacter = 2;
                done = true;
            }
            else if (OnCharacter == 5)
            {
                OnCharacter = 4;
                done = true;
            }
            else if (OnCharacter == 6)
            {
                OnCharacter = 5;
                done = true;
            }
            else if (OnCharacter == 9)
            {
                OnCharacter = 8;
                done = true;
            }
            else if (OnCharacter == 8)
            {
                OnCharacter = 7;
                done = true;
            }

        }
        

    }
    
    public void SetInputFloatRight(float direction)
    {
        inputFloat = direction;
        
        if(direction == 1 && done == false)
        
        {

            if (OnCharacter == 1)
            {
                OnCharacter = 2;
                done = true;
            }
            else if (OnCharacter == 2)
            {
                OnCharacter = 3;
                done = true;
            }
            else if (OnCharacter == 4)
            {
                OnCharacter = 5;
                done = true;
            }
            else if (OnCharacter == 5)
            {
                OnCharacter = 6;
                done = true;
            }
            else if (OnCharacter == 7)
            {
                OnCharacter = 8;
                done = true;
            }
            else if (OnCharacter == 8)
            {
                OnCharacter = 9;
                done = true;
            }

        }
        


    }

    public void SetInputFloatUp(float direction)
    {
        inputFloat = direction;
        
        if(direction == 1 && done == false)
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
        

    }

    public void SetInputFloatDown(float direction)
    {
        inputFloat = direction;
        if(direction == 1 && done == false)
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

}
