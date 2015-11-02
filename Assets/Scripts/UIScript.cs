using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Text[] _amountOfPistolAmmo; //{0 - 4 = PLAYER ID}
    [SerializeField]
    private Text[] _amountOfShotgunAmmo;
    [SerializeField]
    private Text[] _amountOfSmgAmmo;
    [SerializeField]
    private Text[] _amountOfSniperAmmo;
    [SerializeField]
    private Text[] _boxes;
    [SerializeField]
    private Text[] _scores;
    [SerializeField]
    private Text[] _hps;
    [SerializeField]
    private PlayerScript[] _playerscripts;
    [SerializeField]
    private MovePlayerScript _MovePlayerScript;

    public void Update()
    {
        for (int i = 0; i < _MovePlayerScript.AmountOfPlayers; i++)
        {
            //for(int i2 = 0; i2 < 4; i2++)
            //if (_MovePlayerScript.GetSelectedGun[i] != null)
            {
                //if (_MovePlayerScript.CurrentPlayerGuns[i,i2])
                {
                    _amountOfPistolAmmo[i].color = Color.red;
                    _amountOfPistolAmmo[i].text = _MovePlayerScript.CurrentPlayerGuns[i,0].AmmoInClip().ToString() + " / " + _MovePlayerScript.CurrentPlayerGuns[i, 0].FullClips().ToString() + " Player " + (i+1);
                }
                //else if (_MovePlayerScript.GetSelectedGun[i].tag == "Shotgun")
                {
                    _amountOfShotgunAmmo[i].color = Color.green;
                    _amountOfShotgunAmmo[i].text = _MovePlayerScript.CurrentPlayerGuns[i, 1].AmmoInClip().ToString() + " / " + _MovePlayerScript.CurrentPlayerGuns[i, 1].FullClips().ToString() + " Player " + (i+1);
                    //Debug.Log("-------> " + _MovePlayerScript.GetSelectedGun[i].AmmoInClip().ToString());
                }
                //else if (_MovePlayerScript.GetSelectedGun[i].tag == "Smg")
                {
                    _amountOfSmgAmmo[i].color = Color.blue;
                    _amountOfSmgAmmo[i].text = _MovePlayerScript.CurrentPlayerGuns[i, 2].AmmoInClip().ToString() + " / " + _MovePlayerScript.CurrentPlayerGuns[i, 2].FullClips().ToString() + " Player " + (i+1);
                }
                //else if (_MovePlayerScript.GetSelectedGun[i].tag == "Sniper")
                {
                    _amountOfSniperAmmo[i].color = Color.yellow;
                    _amountOfSniperAmmo[i].text = _MovePlayerScript.CurrentPlayerGuns[i, 3].AmmoInClip().ToString() + " / " + _MovePlayerScript.CurrentPlayerGuns[i, 3].FullClips().ToString() + " Player " + (i+1);
                }
            }
            _boxes[i].text = "Boxes: " + _playerscripts[i].CurrentBoxes.ToString();
            _scores[i].text = "Score: " + _playerscripts[i].Score.ToString();
            _hps[i].text = "HP: " + _playerscripts[i].HP.ToString();
        }
    }
}
