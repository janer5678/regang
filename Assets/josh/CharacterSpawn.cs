using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    private Vector2 Player1Spawn;
    private Vector2 Player2Spawn;

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

        print(StaticScript.player1character);

        Players[StaticScript.player1character - 1].SetActive(true);
        Players[StaticScript.player2character - 1].SetActive(true);

        Players[StaticScript.player1character - 1].transform.position = Player1Spawn;

        Players[StaticScript.player2character - 1].transform.position = Player2Spawn;
    }


}
