using UnityEngine;
using System.Collections;
public class MovePlayerScript : MonoBehaviour
{
    [SerializeField]
    private Camera _player1Camera;
    [SerializeField]
    private Camera _player2Camera;
    [SerializeField]
    private Camera _player3Camera;
    [SerializeField]
    private Camera _player4Camera;

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


    void Update()
    {
        switch (gameState)
        {
            case 1:
                Player1Movement();
                Player2Movement();
                if (players[2] != null)
                    Player3Movement();
                if (players[3] != null)
                    Player4Movement();
                break;
        }
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

    private void Player1Movement()
    {
        float playerH = Input.GetAxis("Player0_Horizontal");
        float playerV = Input.GetAxis("Player0_Vertical");

        float playerH2 = Input.GetAxis("Player0_Horizontal2");
        float playerV2 = Input.GetAxis("Player0_Vertical2");
        print(playerH2 + playerV2);

        players[0].transform.Translate(new Vector3(playerV, playerH));
    }

    private void Player2Movement()
    {
        float playerH = Input.GetAxis("Player1_Horizontal");
        float playerV = Input.GetAxis("Player1_Vertical");
        players[1].transform.Translate(new Vector3(playerV, playerH));
    }

    private void Player3Movement()
    {
        float playerH = Input.GetAxis("Player2_Horizontal");
        float playerV = Input.GetAxis("Player2_Vertical");
        players[2].transform.Translate(new Vector3(playerV, playerH));
    }

    private void Player4Movement()
    {
        float playerH = Input.GetAxis("Player3_Horizontal");
        float playerV = Input.GetAxis("Player3_Vertical");
        players[3].transform.Translate(new Vector3(playerV, playerH));
    }
}
