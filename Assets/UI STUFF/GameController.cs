using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static int Player1char;
    public static int Player2char;

    public static int NumPlayers;

    public static bool blueSelected;
    public static bool redSelected;

    private void Update()
    {

        if (blueSelected == true && redSelected == true)
        {
            
            //some code here storing which players were selected or sending them to a non-mono behaviour script
            SceneManager.LoadScene("Map Selection");


        }
    }


}
