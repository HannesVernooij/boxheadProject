using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Text[] _AmountOfPistolAmmo; //{0 - 4 = PLAYER ID}
    [SerializeField]
    private MovePlayerScript _MovePlayerScript;                    
    private void Start()
    {
        _MovePlayerScript = GameObject.FindObjectOfType<MovePlayerScript>();
    }
    private void Update()
    {
        for (int i = 0; i < _MovePlayerScript.AmountOfPlayers; i++)
        {
            if(_MovePlayerScript.GetSelectedGun[i] != null && _MovePlayerScript.GetSelectedGun[i].tag == "Pistol")
            _AmountOfPistolAmmo[i].text = _MovePlayerScript.GetSelectedGun[i].AmmoInClip().ToString() +" / " + _MovePlayerScript.GetSelectedGun[i].FullClips().ToString() + " Player " + i;
        }
    }
}
