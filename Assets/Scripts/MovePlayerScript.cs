using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MovePlayerScript : MonoBehaviour
{
    [SerializeField]
    private UIScript _uiScript;
    public float slowingDownSpeed;
    private Camera[] _playerCameras;
    private float defaultSlowingDownSpeed;
    private GameObject[] _players = new GameObject[4];
    private Gun[] _currentPlayer1Guns = new Gun[4];
    private Gun[] _currentPlayer2Guns = new Gun[4];
    private Gun[] _currentPlayer3Guns = new Gun[4];
    private Gun[] _currentPlayer4Guns = new Gun[4];
    private Gun[,] _currentPlayerGuns;
    private Gun[] _selectedGun = new Gun[4];
    private int _amountOfPlayers = 0;
    private int _gamestate = 0;
    GameObject LookAtGameObject;
    GameObject LookAtGameObject1;
    GameObject LookAtGameObject2;
    GameObject LookAtGameObject3;
    int _damage = 0;
    int[] _selectedGunCounter = new int[] { 0, 0, 0, 0 };
    List<Gun> _gunList = new List<Gun>();

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
        AddGunRange(_currentPlayer2Guns);
        AddGunRange(_currentPlayer3Guns);
        AddGunRange(_currentPlayer4Guns);
        defaultSlowingDownSpeed = slowingDownSpeed;

        foreach(Gun Object in CurrentPlayerGuns)
        {
            if(Object.gameObject.tag == "Pistol") { Object.Ammo(Random.Range(12, 50)); }
            if(Object.gameObject.tag == "Shotgun") { Object.Ammo(Random.Range(6, 20)); }
            if(Object.gameObject.tag == "Smg") { Object.Ammo(Random.Range(30, 90)); }
            if (Object.gameObject.tag == "Sniper") { Object.Ammo(Random.Range(6, 20)); }
        }
    }

    private void AddGunRange(Gun[] gunArray)
    {
        for(int i = 0; i < gunArray.Length - 1; i++)
        {
            _gunList.Add(gunArray[i]);
        }
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
        SwitchGun(0);
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

    if (Input.GetButtonDown("Player1_Y")) // switch guns
    {
        SwitchGun(1);
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

    if (Input.GetButtonDown("Player2_Y")) // switch guns
    {
        SwitchGun(2);
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
    if (Input.GetButtonDown("Player3_Y")) // switch guns
    {
        SwitchGun(3);
    }
}



//public void ClearGuns(int id)
//{
//    for(int i = 0; i < CurrentPlayerGuns; i++)
//}

public void SwitchGun(int id)
{
    _selectedGun[id].enabled = false;
    _selectedGunCounter[id] = (_selectedGunCounter[id]++) % 5;
    _selectedGun[id] = _currentPlayerGuns[id, _selectedGunCounter[id]];
    _selectedGun[id].enabled = true;
}
}
