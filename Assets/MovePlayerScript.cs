using UnityEngine;
using System.Collections;
public class MovePlayerScript : MonoBehaviour
{
    private Camera[] _playerCameras;
    private GameObject[] _players = new GameObject[4];
    private GameObject[][] _gunSlots = new GameObject[][]
        {
        new GameObject[2],
        new GameObject[2],
        new GameObject[2],
        new GameObject[2]
        };
    private int _amountOfPlayers = 0;
    private int _gamestate = 0;
    GameObject LookAtGameObject;
    GameObject LookAtGameObject1;
    GameObject LookAtGameObject2;
    GameObject LookAtGameObject3;

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


    void Start()
    {
        LookAtGameObject = GameObject.FindGameObjectWithTag("LookAtCube");
        LookAtGameObject1 = GameObject.FindGameObjectWithTag("LookAtCube1");
        LookAtGameObject2 = GameObject.FindGameObjectWithTag("LookAtCube2");
        LookAtGameObject3 = GameObject.FindGameObjectWithTag("LookAtCube3");
    }

    void FixedUpdate()
    {
        switch (_gamestate)
        {
            case 1:
                Player1Movement(playerH: Input.GetAxis("Player0_Horizontal"), playerV: Input.GetAxis("Player0_Vertical"), playerH2: Input.GetAxis("Player0_Horizontal2"), playerV2: Input.GetAxis("Player0_Vertical2"));
                Player2Movement(playerH: Input.GetAxis("Player1_Horizontal"), playerV: Input.GetAxis("Player1_Vertical"), playerH2: Input.GetAxis("Player1_Horizontal2"), playerV2: Input.GetAxis("Player1_Vertical2"));
                if (_players[2] != null)
                    Player3Movement(playerH: Input.GetAxis("Player2_Horizontal"), playerV: Input.GetAxis("Player2_Vertical"), playerH2: Input.GetAxis("Player2_Horizontal2"), playerV2: Input.GetAxis("Player2_Vertical2"));
                if (_players[3] != null)
                    Player4Movement(playerH: Input.GetAxis("Player3_Horizontal"), playerV: Input.GetAxis("Player3_Vertical"), playerH2: Input.GetAxis("Player3_Horizontal2"), playerV2: Input.GetAxis("Player3_Vertical2"));
                break;
        }
    }




    private void Player1Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        //Bewegen
        LookAtGameObject.transform.position = new Vector3(_players[0].transform.position.x + playerH2 * 2, _players[0].transform.position.y, _players[0].transform.position.z + -playerV2 * 2);

        _players[0].transform.Translate(new Vector3(playerH / 6, 0, -playerV / 6), Space.World);
        _players[0].transform.LookAt(LookAtGameObject.transform);


    }

    private void Player2Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        LookAtGameObject1.transform.position = new Vector3(_players[1].transform.position.x + playerH2 * 2, _players[1].transform.position.y, _players[1].transform.position.z + -playerV2 * 2);

        _players[1].transform.Translate(new Vector3(playerH / 6, 0, -playerV / 6), Space.World);
        _players[1].transform.LookAt(LookAtGameObject1.transform);

    }

    private void Player3Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        LookAtGameObject2.transform.position = new Vector3(_players[2].transform.position.x + playerH2 * 2, _players[2].transform.position.y, _players[2].transform.position.z + -playerV2 * 2);

        _players[2].transform.Translate(new Vector3(playerH / 6, 0, -playerV / 6), Space.World);
        _players[2].transform.LookAt(LookAtGameObject2.transform);


    }

    private void Player4Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {

        LookAtGameObject3.transform.position = new Vector3(_players[3].transform.position.x + playerH2 * 2, _players[3].transform.position.y, _players[3].transform.position.z + -playerV2 * 2);

        _players[3].transform.Translate(new Vector3(playerH / 6, 0, -playerV / 6), Space.World);
        _players[3].transform.LookAt(LookAtGameObject3.transform);

    }
}
