using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Text[] _amountOfPistolAmmo; //{0 - 4 = PLAYER ID}
    [SerializeField]
    private Text[] _boxes;
    [SerializeField]
    private Text[] _score;
    [SerializeField]
    private PlayerScript[] _playerscripts;
    [SerializeField]
    private MovePlayerScript _MovePlayerScript;
    private void Update()
    {
        for (int i = 0; i < _MovePlayerScript.AmountOfPlayers; i++)
        {
            if (_MovePlayerScript.GetSelectedGun[i] != null && _MovePlayerScript.GetSelectedGun[i].tag == "Pistol")
            {
                _amountOfPistolAmmo[i].text = _MovePlayerScript.GetSelectedGun[i].AmmoInClip().ToString() + " / " + _MovePlayerScript.GetSelectedGun[i].FullClips().ToString() + " Player " + i;

            }
            _boxes[i].text = "Boxes: " + _playerscripts[i].CurrentBoxes.ToString();
            _score[i].text = "Score: " + _playerscripts[i].Score.ToString();
        }
    }
}
