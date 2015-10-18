﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MovePlayerScript : MonoBehaviour
{
    public float slowingDownSpeed;
    private Camera[] _playerCameras;
    private GameObject[] _players = new GameObject[4];
    private Gun[,] _currentPlayerGuns = new Gun[4, 2];
    private Gun[] _selectedGun = new Gun[4];
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

        _players[0].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed), Space.World);
        _players[0].transform.LookAt(LookAtGameObject.transform);
        if (Input.GetButton("Player0_RightBumper"))
        {
            //_selectedGun[0].AllowedToShoot = true;
            GameObject.Instantiate(Resources.Load("Bullet"),transform.position,Quaternion.identity);
        }
        else if (Input.GetButtonUp("Player0_RightBumper"))
        {
            //_selectedGun[0].AllowedToShoot = false;
        }
    }

    private void Player2Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        LookAtGameObject1.transform.position = new Vector3(_players[1].transform.position.x + playerH2, _players[1].transform.position.y, _players[1].transform.position.z + -playerV2);

        _players[1].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed), Space.World);
        _players[1].transform.LookAt(LookAtGameObject1.transform);
        if (Input.GetButton("Player1_RightBumper"))
        {
            _selectedGun[1].AllowedToShoot = true;
        }
        else if (Input.GetButtonUp("Player1_RightBumper"))
        {
            _selectedGun[1].AllowedToShoot = false;
        }
    }

    private void Player3Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {
        LookAtGameObject2.transform.position = new Vector3(_players[2].transform.position.x + playerH2, _players[2].transform.position.y, _players[2].transform.position.z + -playerV2);

        _players[2].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed), Space.World);
        _players[2].transform.LookAt(LookAtGameObject2.transform);
        if (Input.GetButton("Player2_RightBumper"))
        {
            _selectedGun[2].AllowedToShoot = true;
        }
        else if (Input.GetButtonUp("Player2_RightBumper"))
        {
            _selectedGun[2].AllowedToShoot = false;
        }

    }

    private void Player4Movement(float playerH = 0, float playerV = 0, float playerH2 = 0, float playerV2 = 0)
    {

        LookAtGameObject3.transform.position = new Vector3(_players[3].transform.position.x + playerH2/2, _players[3].transform.position.y, _players[3].transform.position.z + -playerV2/2);

        _players[3].transform.Translate(new Vector3(playerH / slowingDownSpeed, 0, -playerV / slowingDownSpeed), Space.World);
        _players[3].transform.LookAt(LookAtGameObject3.transform);
        if (Input.GetButton("Player3_RightBumper"))
        {
            _selectedGun[3].AllowedToShoot = true;
        }
        else if (Input.GetButtonUp("Player3_RightBumper"))
        {
            _selectedGun[3].AllowedToShoot = false;
        }
    }

    public void GetGun(GameObject playerObject, Gun gunScript, int ammo)
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
                _currentPlayerGuns[player, i] = gunScript;
                _selectedGun[player] = gunScript;
                gunScript.SetAmmo(ammo);
                return;
            }
        }
        Destroy(gunScript.GetComponent<GameObject>());
        Debug.Log("No space for gun in inventory, Destroying Gun...");
    }
}
