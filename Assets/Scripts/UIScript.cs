using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Text[] _TextAmmo = new Text[4]; //0 = pistol, 1 = Shotgun, 2 = Rifle en 3 = Sniper Rifle //De children volgorde van de canvasplayer Prefab moet Pistol - Shotgun - Rifle - SniperRifle zijn!
    [SerializeField]
    private MovePlayerScript _MovePlayerScript;                    
    private void Start()
    {
        _TextAmmo = transform.GetComponentsInChildren<Text>();
        _MovePlayerScript = GameObject.FindObjectOfType<MovePlayerScript>();
    }
    private void SetPistolText()
    {
        //_TextAmmo[0].text = _MovePlayerScript.GetSelectedGun[0].FullClips();
    }
}
