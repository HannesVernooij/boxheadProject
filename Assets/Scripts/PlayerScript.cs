using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private MovePlayerScript _movePlayerScript;
    private int _id;
    [SerializeField]
    private GameObject _GunPositionObject;
    public int ID
    {
        set { _id = value; }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Pistol" || collider.tag == "Shotgun" || collider.tag == "Smg" || collider.tag == "Sniper")
        {
            _movePlayerScript.GetGun(gameObject, collider.GetComponent<Gun>(), 50, _id);
            collider.transform.parent = _GunPositionObject.transform;
            collider.transform.localPosition = Vector3.zero;
            collider.transform.rotation = Quaternion.Euler(270, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
            Gun gunScript = collider.GetComponent<Gun>();
            switch (collider.tag)
            {
                case "Pistol":
                    gunScript.ClipSize = 6;
                    gunScript.ShootDelay = 1f;
                    gunScript.ReloadSpeed = 2f;
                    gunScript.Ammo(Random.Range(12, 50));
                    break;

                case "Shotgun":
                    gunScript.ClipSize = 2;
                    gunScript.ShootDelay = 0.5f;
                    gunScript.ReloadSpeed = 4f;
                    gunScript.Ammo(Random.Range(6, 20));
                    break;

                case "Smg":
                    gunScript.ClipSize = 30;
                    gunScript.ShootDelay = 0.2f;
                    gunScript.ReloadSpeed = 2f;
                    gunScript.Ammo(Random.Range(30, 90));
                    break;

                case "Sniper":
                    gunScript.ClipSize = 6;
                    gunScript.ShootDelay = 2f;
                    gunScript.ReloadSpeed = 4f;
                    gunScript.Ammo(Random.Range(6, 20));
                    break;

            }
        }
    }

}
