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

    public void InitializeValues()
    {
        for (int i = 0; i < _MovePlayerScript.AmountOfPlayers; i++)
        {
            _amountOfPistolAmmo[i].text = 0 + " / " + 0 + " Player " + (i+1);
            _amountOfShotgunAmmo[i].text = 0 + " / " + 0 + " Player " + (i+1);
            _amountOfSmgAmmo[i].text = 0 + " / " + 0 + " Player " + (i+1);
            _amountOfSniperAmmo[i].text = 0 + " / " + 0 + " Player " + (i+1);
        }
    }
    private void Update()
    {
        for (int i = 0; i < _MovePlayerScript.AmountOfPlayers; i++)
        {
            if (_MovePlayerScript.GetSelectedGun[i] != null)
            {
                if (_MovePlayerScript.GetSelectedGun[i].tag == "Pistol")
                {
                    _amountOfPistolAmmo[i].text = _MovePlayerScript.GetSelectedGun[i].AmmoInClip().ToString() + " / " + _MovePlayerScript.GetSelectedGun[i].FullClips().ToString() + " Player " + (i+1);
                }
                else if (_MovePlayerScript.GetSelectedGun[i].tag == "Shotgun")
                {
                    _amountOfShotgunAmmo[i].text = _MovePlayerScript.GetSelectedGun[i].AmmoInClip().ToString() + " / " + _MovePlayerScript.GetSelectedGun[i].FullClips().ToString() + " Player " + (i+1);
                    //Debug.Log("-------> " + _MovePlayerScript.GetSelectedGun[i].AmmoInClip().ToString());
                }
                else if (_MovePlayerScript.GetSelectedGun[i].tag == "Smg")
                {
                    _amountOfSmgAmmo[i].text = _MovePlayerScript.GetSelectedGun[i].AmmoInClip().ToString() + " / " + _MovePlayerScript.GetSelectedGun[i].FullClips().ToString() + " Player " + (i+1);
                }
                else if (_MovePlayerScript.GetSelectedGun[i].tag == "Sniper")
                {
                    _amountOfSniperAmmo[i].text = _MovePlayerScript.GetSelectedGun[i].AmmoInClip().ToString() + " / " + _MovePlayerScript.GetSelectedGun[i].FullClips().ToString() + " Player " + (i+1);
                }
            }
            _boxes[i].text = "Boxes: " + _playerscripts[i].CurrentBoxes.ToString();
            _scores[i].text = "Score: " + _playerscripts[i].Score.ToString();
            _hps[i].text = "HP: " + _playerscripts[i].HP.ToString();
        }
    }
}
