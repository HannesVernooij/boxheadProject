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

    public GameObject[] players = new GameObject[4];


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
