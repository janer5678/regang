using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    private Vector2 Player1Spawn;
    private Vector2 Player2Spawn;
    private Vector2 Player3Spawn;

    private Vector2 spawnPoint1 = new Vector2(-5.9f, 0.65f);
    private Vector2 spawnPoint2 = new Vector2(-0.04f, 2.2f);
    private Vector2 spawnPoint3 = new Vector2(7.55f, 0.226f);
    private Vector2 spawnPoint4 = new Vector2(-0.17f, -2.59f);

    public GameObject[] Players;

    void Start()
    {


        List<Vector2> options = new List<Vector2> { spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4 };

        //set spawn for 1 
        int randomIndex = Random.Range(0, options.Count);

        Vector2 selectedOption = options[randomIndex];

        Player1Spawn = selectedOption;

        //set spawn for 2
        options.RemoveAt(randomIndex);

        int randomIndex2 = Random.Range(0, options.Count);

        Vector2 selectedOption2 = options[randomIndex2];

        Player2Spawn = selectedOption2;

        //set spawn 3 

        options.RemoveAt(randomIndex2);

        int randomIndex3 = Random.Range(0, options.Count);

        Vector2 selectedOption3 = options[randomIndex3];

        Player3Spawn = selectedOption3;



        if (StaticScript.player1character != 3)
        {
            Players[StaticScript.player1character - 1].SetActive(true);
        }
        if (StaticScript.player2character != 3)
        {
            Players[StaticScript.player2character - 1].SetActive(true);
        }
        if (StaticScript.player3character != 3)
        {
            Players[StaticScript.player3character - 1].SetActive(true);
        }

        if (StaticScript.player3character != 3 && StaticScript.player2character != 3 && StaticScript.player1character != 3)
        {
            Players[2].SetActive(false);
        }


        Players[StaticScript.player1character - 1].transform.position = Player1Spawn;
        Players[StaticScript.player2character - 1].transform.position = Player2Spawn;
        Players[StaticScript.player3character - 1].transform.position = Player3Spawn;
    }


}
