﻿using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour
{
    [SerializeField]
    MovePlayerScript _movePlayerScript;
    [SerializeField]
    private Camera[] _playerCameras;

    private int _amountOfPlayers = 0;
    private int _gamestate = 0;
    private Vector3[] _spawnPos = new Vector3[4];
    private Color[] _playerColor = new Color[4];
    private GameObject[] _players = new GameObject[4];

    void Start()
    {
        _spawnPos[0] = new Vector3(-12, 16.167f, -0.5f);
        _spawnPos[1] = new Vector3(12, 16.167f, -0.5f);
        _spawnPos[2] = new Vector3(-2.87f, -3.44f, -0.68f);
        _spawnPos[3] = new Vector3(6.13f, -3.44f, -0.68f);
        _playerColor[0] = Color.red;
        _playerColor[1] = Color.blue;
        _playerColor[2] = Color.green;
        _playerColor[3] = Color.yellow;
    }

    void OnGUI()
    {
        if (_amountOfPlayers == 0)
        {
            if (GUI.Button(new Rect(10, 10, 100, 30), "2 players"))
            {
                _amountOfPlayers = 2;
                _playerCameras[0].rect = new Rect(0f,    0, 0.49f, 1);
                _playerCameras[1].rect = new Rect(0.51f, 0, 0.49f, 1);
                _playerCameras[2].enabled = false;
                _playerCameras[3].enabled = false;
            }

            if (GUI.Button(new Rect(10, 40, 100, 30), "3 players"))
            {
                _amountOfPlayers = 3;
                _playerCameras[0].rect = new Rect(0,     0.51f,     0.49f, 0.49f);
                _playerCameras[1].rect = new Rect(0.51f, 0.51f,     0.49f, 0.49f);
                _playerCameras[2].rect = new Rect(0,     0,         1,     0.49f);
                _playerCameras[3].enabled = false;
            }

            if (GUI.Button(new Rect(10, 70, 100, 30), "4 players"))
            {
                _amountOfPlayers = 4;
                _playerCameras[0].rect = new Rect(0,     0.51f, 0.49f, 0.49f);
                _playerCameras[1].rect = new Rect(0.51f, 0.51f, 0.49f, 0.49f);
                _playerCameras[2].rect = new Rect(0,     0,     0.49f, 0.49f);
                _playerCameras[3].rect = new Rect(0.51f, 0,     0.49f, 0.49f);
            }
        }
        else if (_gamestate == 0)
        {
            GameObject temp;
            for (int i = 0; i < _amountOfPlayers; i++)
            {
                temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.position = _spawnPos[i];
                temp.name = "Player " + (i + 1);
                _players[i] = temp;
                temp.GetComponent<Renderer>().material.color = _playerColor[i];
            }
            _gamestate = 1;
        }
        if (_gamestate == 1)
        {
            _movePlayerScript.AmountOfPlayers = _amountOfPlayers;
            _movePlayerScript.Players = _players;
            _movePlayerScript.Gamestate = _gamestate;
            _movePlayerScript.PlayerCameras = _playerCameras;
        }
    }

}