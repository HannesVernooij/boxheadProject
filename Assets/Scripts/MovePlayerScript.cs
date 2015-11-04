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
    [SerializeField]
    private Gun[] _currentPlayer1Guns = new Gun[4];
    [SerializeField]
    private Gun[] _currentPlayer2Guns = new Gun[4];
    [SerializeField]
    private Gun[] _currentPlayer3Guns = new Gun[4];
    [SerializeField]
    private Gun[] _currentPlayer4Guns = new Gun[4];
    [SerializeField]
    private SoundSystem _soundScript;
    [SerializeField]
    private Animator[] m_Animator;
    private Gun[,] _currentPlayerGuns = new Gun[4, 4];
    private Gun[] _selectedGun = new Gun[4];


    private int _amountOfPlayers = 0;
    private int _gamestate = 0;
    GameObject LookAtGameObject;
    GameObject LookAtGameObject1;
    GameObject LookAtGameObject2;
    GameObject LookAtGameObject3;
    bool tempthingy = true;
    int _damage = 0;
    int[] _selectedGunCounter = new int[4] { 0, 0, 0, 0 };

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


        for (int i = 0; i < 4; i++)
        {
            _currentPlayerGuns[0, i] = _currentPlayer1Guns[i];
            _currentPlayerGuns[1, i] = _currentPlayer2Guns[i];
            _currentPlayerGuns[2, i] = _currentPlayer3Guns[i];
            _currentPlayerGuns[3, i] = _currentPlayer4Guns[i];
        }

        defaultSlowingDownSpeed = slowingDownSpeed;


        Debug.Log(_currentPlayerGuns);

        //_uiScript.UpdateValues();  //ToDo
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            m_Animator[3].SetFloat("Speed", 1f);
        }
        else
        {
            m_Animator[3].SetFloat("Speed", 0f);
        }
    }
    void FixedUpdate()
    {
        if (tempthingy == true)
        {
            setGunAudioScriptAfterMonoBehavioursFuckedUpVariableRemoval();
            tempthingy = false;
        }

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

    private void setGunAudioScriptAfterMonoBehavioursFuckedUpVariableRemoval()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int i2 = 0; i2 < 4; i2++)
            {
                Debug.Log("SETTHINHG SHIT");
                if (_currentPlayerGuns[i, i2].gameObject.tag == "Pistol")
                {
                    _currentPlayerGuns[i, i2].ClipSize = 6;
                    _currentPlayerGuns[i, i2].ReloadSpeed = 0.4f;
                    _currentPlayerGuns[i, i2].ShootDelay = 0.2f;
                    _currentPlayerGuns[i, i2].Damage = 1;
                    _currentPlayerGuns[i, i2].Ammo(Random.Range(12, 50));
                    _currentPlayerGuns[i, i2]._tag = "Pistol";
                    _selectedGun[i] = _currentPlayerGuns[i, i2];
                }
                if (_currentPlayerGuns[i, i2].gameObject.tag == "Shotgun")
                {
                    _currentPlayerGuns[i, i2].ClipSize = 6;
                    _currentPlayerGuns[i, i2].ReloadSpeed = 0.5f;
                    _currentPlayerGuns[i, i2].ShootDelay = 0.2f;
                    _currentPlayerGuns[i, i2].Damage = 1;
                    _currentPlayerGuns[i, i2].Ammo(Random.Range(6, 20));
                    _currentPlayerGuns[i, i2]._tag = "Shotgun";
                }
                if (_currentPlayerGuns[i, i2].gameObject.tag == "Smg")
                {
                    _currentPlayerGuns[i, i2].ClipSize = 30;
                    _currentPlayerGuns[i, i2].ReloadSpeed = 0.5f;
                    _currentPlayerGuns[i, i2].ShootDelay = 0.2f;
                    _currentPlayerGuns[i, i2].Damage = 2;
                    _currentPlayerGuns[i, i2].Ammo(Random.Range(30, 90));
                    _currentPlayerGuns[i, i2]._tag = "Smg";
                }
                if (_currentPlayerGuns[i, i2].gameObject.tag == "Sniper")
                {
                    _currentPlayerGuns[i, i2].ClipSize = 6;
                    _currentPlayerGuns[i, i2].ReloadSpeed = 0.5f;
                    _currentPlayerGuns[i, i2].ShootDelay = 0.3f;
                    _currentPlayerGuns[i, i2].Damage = 9;
                    _currentPlayerGuns[i, i2].Ammo(Random.Range(6, 20));
                    _currentPlayerGuns[i, i2]._tag = "Sniper";
                }
            }
        }
    }
    private void Player1Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        int amountOfBoxes = _players[0].GetComponent<PlayerScript>().CurrentBoxes;
        slowingDownSpeed = defaultSlowingDownSpeed + (amountOfBoxes * 2);
        _players[0].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed));
        m_Animator[0].SetFloat("Speed", playerV + playerH);

        Vector3 LookDirection = new Vector3(_players[0].transform.position.x + playerV2 , _players[0].transform.position.y, _players[0].transform.position.z + playerH2);
        //Quaternion lookRotation = Quaternion.LookRotation(LookDirection.normalized);
        LookAtGameObject.transform.position = LookDirection; //Debug Visual
        _players[0].transform.LookAt(LookDirection);
        if (Input.GetButton("Player0_RightBumper") && _selectedGun[0] != null)
        {
            _selectedGun[0].Shoot();
        }
        if (Input.GetButtonDown("Player0_Y")) // switch guns
        {
            SwitchGun(0);
            Debug.Log("SWITCHING");
        }
    }

    private void Player2Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        int amountOfBoxes = _players[1].GetComponent<PlayerScript>().CurrentBoxes;
        slowingDownSpeed = defaultSlowingDownSpeed + (amountOfBoxes * 2);
        _players[1].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed));
        m_Animator[1].SetFloat("Speed", playerV + playerH);


        Vector3 LookDirection = new Vector3(_players[1].transform.position.x + playerV2, _players[1].transform.position.y, _players[1].transform.position.z + playerH2);
        LookAtGameObject1.transform.position = LookDirection;
        _players[1].transform.LookAt(LookDirection);

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
        int amountOfBoxes = _players[2].GetComponent<PlayerScript>().CurrentBoxes;
        slowingDownSpeed = defaultSlowingDownSpeed + (amountOfBoxes * 2);
        _players[2].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed));
        m_Animator[2].SetFloat("Speed", playerV + playerH);


        Vector3 LookDirection = new Vector3(_players[2].transform.position.x + playerV2, _players[2].transform.position.y, _players[2].transform.position.z + playerH2);
        LookAtGameObject1.transform.position = LookDirection;
        _players[2].transform.LookAt(LookDirection);
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

        int amountOfBoxes = _players[3].GetComponent<PlayerScript>().CurrentBoxes;
        slowingDownSpeed = defaultSlowingDownSpeed + (amountOfBoxes * 2);
        _players[3].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed));
        m_Animator[3].SetFloat("Speed", playerV + playerH);


        Vector3 LookDirection = new Vector3(_players[3].transform.position.x + playerV2, _players[3].transform.position.y, _players[3].transform.position.z + playerH2);
        LookAtGameObject1.transform.position = LookDirection;
        _players[3].transform.LookAt(LookDirection);
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
        _selectedGun[id].gameObject.SetActive(false);
        _selectedGunCounter[id] = (_selectedGunCounter[id] += 1);
        _selectedGunCounter[id] = _selectedGunCounter[id] % 4;
        Debug.Log(_selectedGunCounter[id]);
        _selectedGun[id] = _currentPlayerGuns[id, _selectedGunCounter[id]];
        _selectedGun[id].gameObject.SetActive(true);
    }

    public void SetGunColors()
    {
        for (int i = 0; i < 4; i++)
        {
            _currentPlayerGuns[i, 0].GetComponent<Renderer>().material.color = Color.red;
            _currentPlayerGuns[i, 1].GetComponent<Renderer>().material.color = Color.green;
            _currentPlayerGuns[i, 2].GetComponent<Renderer>().material.color = Color.blue;
            _currentPlayerGuns[i, 3].GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
}
