using UnityEngine;
using System.Collections;
public class MovePlayerScript : MonoBehaviour
{
    private Camera[] _playerCameras;
    private GameObject[] _players = new GameObject[4];
    private int _amountOfPlayers = 0;
    private int _gamestate = 0;

    public GameObject[] Players
    {
        set { _players = value; }
    }
    public int AmountOfPlayers
    {
        set { _amountOfPlayers = value; }
    }
    public int Gamestate
    {
        set { _gamestate = value; }
    }
    public Camera[] PlayerCameras
    {
        set { _playerCameras = value; }
    }




    void Update()
    {
        switch (_gamestate)
        {
            case 1:
                Player1Movement();
                Player2Movement();
                if (_players[2] != null)
                    Player3Movement();
                if (_players[3] != null)
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

        _players[0].transform.Translate(new Vector3(playerV, playerH));
    }

    private void Player2Movement()
    {
        float playerH = Input.GetAxis("Player1_Horizontal");
        float playerV = Input.GetAxis("Player1_Vertical");
        _players[1].transform.Translate(new Vector3(playerV, playerH));
    }

    private void Player3Movement()
    {
        float playerH = Input.GetAxis("Player2_Horizontal");
        float playerV = Input.GetAxis("Player2_Vertical");
        _players[2].transform.Translate(new Vector3(playerV, playerH));
    }

    private void Player4Movement()
    {
        float playerH = Input.GetAxis("Player3_Horizontal");
        float playerV = Input.GetAxis("Player3_Vertical");
        _players[3].transform.Translate(new Vector3(playerV, playerH));
    }
}
