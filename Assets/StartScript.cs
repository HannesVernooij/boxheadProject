using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour 
{
    int amountOfPlayers = 0;
    int gameState = 0;
    Vector3[] spawnPos = new Vector3[4];
    Color[] playerColor = new Color[4];

    public GameObject[] players = new GameObject[4];

    void Start()
    {
        spawnPos[0] = new Vector3(-12, 16.167f, -0.5f);
        spawnPos[1] = new Vector3(12, 16.167f, -0.5f);
        spawnPos[2] = new Vector3(-2.87f, -3.44f, -0.68f);
        spawnPos[3] = new Vector3(6.13f, -3.44f, -0.68f);
        playerColor[0] = Color.red;
        playerColor[1] = Color.blue;
        playerColor[2] = Color.green;
        playerColor[3] = Color.yellow;
    }

    void OnGUI()
    {
        if (amountOfPlayers == 0)
        {
            if (GUI.Button(new Rect(10, 10, 100, 30), "2 players"))
            {
                amountOfPlayers = 2;
            }

            if (GUI.Button(new Rect(10, 40, 100, 30), "3 players"))
            {
                amountOfPlayers = 3;
            }

            if (GUI.Button(new Rect(10, 70, 100, 30), "4 players"))
            {
                amountOfPlayers = 4;
            }
        }
        else if (gameState == 0)
        {
            GameObject temp;
            for (int i = 0; i < amountOfPlayers; i++)
            {
                temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.position = spawnPos[i];
                temp.name = "Player " + (i + 1);
                players[i] = temp;
                temp.GetComponent<Renderer>().material.color = playerColor[i];
            }
            gameState = 1;
        }
        if (gameState == 1)
        {

        }
    }

}
