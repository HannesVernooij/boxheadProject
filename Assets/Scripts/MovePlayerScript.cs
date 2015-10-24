using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MovePlayerScript : MonoBehaviour
{
    public float slowingDownSpeed;
    private Camera[] _playerCameras;
    private float defaultSlowingDownSpeed;
    private GameObject[] _players = new GameObject[4];
    private Gun[,] _currentPlayerGuns = new Gun[4, 2];
    private Gun[] _selectedGun = new Gun[4];
    private int _amountOfPlayers = 0;
    private int _gamestate = 0;
    GameObject LookAtGameObject;
    GameObject LookAtGameObject1;
    GameObject LookAtGameObject2;
    GameObject LookAtGameObject3;
    int _damage = 0;
    int selectedGunCounter = 0;

    public Gun[,] CurrentPlayerGuns
    {
        set { _currentPlayerGuns = value; }
        get { return _currentPlayerGuns; }
    }
    public GameObject[] Players
    {
        set { _players = value; }
        get { return _players; }

    }
    public int AmountOfPlayers
    {
        set { _amountOfPlayers = value; }
        get { return _amountOfPlayers; }
    }
    public int Gamestate
    {
        set { _gamestate = value; }
    }
    public Camera[] PlayerCameras
    {
        set { _playerCameras = value; }
    }
    public Gun[] GetSelectedGun
    {
        get { return _selectedGun; }
    }
    void Start()
    {
        LookAtGameObject = GameObject.FindGameObjectWithTag("LookAtCube");
        LookAtGameObject1 = GameObject.FindGameObjectWithTag("LookAtCube1");
        LookAtGameObject2 = GameObject.FindGameObjectWithTag("LookAtCube2");
        LookAtGameObject3 = GameObject.FindGameObjectWithTag("LookAtCube3");
        defaultSlowingDownSpeed = slowingDownSpeed;
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
        LookAtGameObject.transform.position = new Vector3(_players[0].transform.position.x + playerH2, _players[0].transform.position.y, _players[0].transform.position.z + -playerV2);
        int amountOfBoxes = _players[0].GetComponent<PlayerScript>().CurrentBoxes;
        slowingDownSpeed = defaultSlowingDownSpeed + (amountOfBoxes * 2);
        _players[0].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed), Space.World);
        _players[0].transform.LookAt(LookAtGameObject.transform);
        if (Input.GetButton("Player0_RightBumper") && _selectedGun[0] != null)
        {
            _selectedGun[0].Shoot();
        }
        if (Input.GetButtonDown("Player0_Y")) // switch guns
        {
            int other;
            Debug.Log(_selectedGun[0] + " " + _currentPlayerGuns[0, selectedGunCounter]);

            other = (selectedGunCounter == 0 ? 1 : 0);

            if (_selectedGun[0] != null)
            {
                _selectedGun[0].gameObject.SetActive(false);
            }
            if (_currentPlayerGuns[0, other] != null)
            {
                _currentPlayerGuns[0, other].gameObject.SetActive(true);
            }
            selectedGunCounter = other;
            _selectedGun[0] = _currentPlayerGuns[0, selectedGunCounter];
            Debug.Log(selectedGunCounter);
        }
        if (Input.GetButtonDown("Player0_B") && _selectedGun[0] != null) // delete selected gun
        {
            Destroy(_selectedGun[0].gameObject);
            _selectedGun[0] = null;
            selectedGunCounter = (selectedGunCounter++) % 2;
            Debug.Log(selectedGunCounter);
            Debug.Log(CurrentPlayerGuns[0, selectedGunCounter]);
        }
    }

    private void Player2Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        LookAtGameObject1.transform.position = new Vector3(_players[1].transform.position.x + playerH2, _players[1].transform.position.y, _players[1].transform.position.z + -playerV2);
        int amountOfBoxes = _players[1].GetComponent<PlayerScript>().CurrentBoxes;
        slowingDownSpeed = defaultSlowingDownSpeed + (amountOfBoxes * 2);
        _players[1].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed), Space.World);
        _players[1].transform.LookAt(LookAtGameObject1.transform);
        if (Input.GetButton("Player1_RightBumper") && _selectedGun[1] != null)
        {
            _selectedGun[1].Shoot();
        }
        if (Input.GetButtonDown("Player1_Y"))
        {
            int other = (selectedGunCounter == 0 ? 1 : 0);

            if (_currentPlayerGuns[1, other] != null)
            {
                _currentPlayerGuns[1, other].gameObject.SetActive(true);
                _selectedGun[1].gameObject.SetActive(false);
                selectedGunCounter = other;
                _selectedGun[1] = _currentPlayerGuns[1, selectedGunCounter];
            }
        }
    }

    private void Player3Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        LookAtGameObject2.transform.position = new Vector3(_players[2].transform.position.x + playerH2, _players[2].transform.position.y, _players[2].transform.position.z + -playerV2);
        int amountOfBoxes = _players[2].GetComponent<PlayerScript>().CurrentBoxes;
        slowingDownSpeed = defaultSlowingDownSpeed + (amountOfBoxes * 2);
        _players[2].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed), Space.World);
        _players[2].transform.LookAt(LookAtGameObject2.transform);
        if (Input.GetButton("Player2_RightBumper") && _selectedGun[2] != null)
        {
            _selectedGun[2].Shoot();
        }
        if (Input.GetButtonDown("Player2_Y"))
        {
            int other = (selectedGunCounter == 0 ? 1 : 0);

            if (_currentPlayerGuns[2, other] != null)
            {
                _currentPlayerGuns[2, other].gameObject.SetActive(true);
                _selectedGun[2].gameObject.SetActive(false);
                selectedGunCounter = other;
                _selectedGun[2] = _currentPlayerGuns[2, selectedGunCounter];
            }
        }
    }

    private void Player4Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {

        LookAtGameObject3.transform.position = new Vector3(_players[3].transform.position.x + playerH2 / 2, _players[3].transform.position.y, _players[3].transform.position.z + -playerV2 / 2);
        int amountOfBoxes = _players[3].GetComponent<PlayerScript>().CurrentBoxes;
        slowingDownSpeed = defaultSlowingDownSpeed + (amountOfBoxes * 2);
        _players[3].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed), Space.World);
        _players[3].transform.LookAt(LookAtGameObject3.transform);
        if (Input.GetButton("Player3_RightBumper") && _selectedGun[3] != null)
        {
            _selectedGun[3].Shoot();
        }
        if (Input.GetButtonDown("Player3_Y"))
        {
            int other = (selectedGunCounter == 0 ? 1 : 0);

            if (_currentPlayerGuns[3, other] != null)
            {
                _currentPlayerGuns[3, other].gameObject.SetActive(true);
                _selectedGun[3].gameObject.SetActive(false);
                selectedGunCounter = other;
                _selectedGun[3] = _currentPlayerGuns[3, selectedGunCounter];
            }
        }
    }


    public void GetGun(GameObject playerObject, Gun gunScript, int ammo, int id)
    {
        int player = -1;

        for (int i = 0; i < _players.Length; i++)
        {
            if (_players[i] == playerObject)
            {
                player = i;
            }
        }

        if (player == -1)
        {
            Debug.Log("ERROR, Player not found.");
            return;
        }

        for (int i = 0; i < _currentPlayerGuns.GetLength(1); i++)
        {
            if (_currentPlayerGuns[player, i] == null)
            {
                if (_selectedGun[player] != null)
                {
                    if (gunScript.gameObject.tag != _selectedGun[player].gameObject.tag)
                    {
                        _selectedGun[player].gameObject.SetActive(false);
                        _currentPlayerGuns[player, i] = gunScript;
                        _selectedGun[player] = gunScript;

                    }
                    else
                    {
                        _selectedGun[player].Ammo(ammo + _selectedGun[player].Ammo());
                        Destroy(gunScript.gameObject);
                    }
                }
                else
                {
                    _currentPlayerGuns[player, i] = gunScript;
                    _selectedGun[player] = gunScript;
                }
                return;
            }
        }
        Destroy(gunScript.gameObject);
        Debug.Log("No space for gun in inventory, Destroying Gun...");
    }
}
