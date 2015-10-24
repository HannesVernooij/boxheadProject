using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private MovePlayerScript _movePlayerScript;
    [SerializeField]
    private ParticleSystem _objectiveParticles;
    private int _id;
    [SerializeField]
    private GameObject _gunPositionObject;
    private GameObject _controlObject;
    private float _boxLoadTimer = 0;
    private float _boxUnloadTimer = 0;
    private int _currentBoxes;
    private int _score = 0;
    public int CurrentBoxes
    {
        get { return _currentBoxes; }
    }
    public int Score
    {
        get { return _score; }
    }
    public int ID
    {
        set { _id = value; }
    }
    public void Start()
    {
        _objectiveParticles.enableEmission = false;
        _controlObject = _movePlayerScript.gameObject;
    }
    
    public void Update()
    {
        if(_id == 0)
        {
            Debug.Log(Vector3.Distance(gameObject.transform.position, _objectiveParticles.transform.position));
        }

        if(Vector3.Distance(gameObject.transform.position,_controlObject.transform.position) < 1.3f)
        {
            if(_boxLoadTimer < 1)
            {
                _boxLoadTimer += Time.deltaTime / 10;
            }
            else
            {
                _boxLoadTimer = 0;
                _currentBoxes++;
                _objectiveParticles.enableEmission = true;
            }
        }

        if (Vector3.Distance(gameObject.transform.position, _objectiveParticles.transform.position) < 1f && _currentBoxes > 0)
        {
            _objectiveParticles.startColor = Color.blue;

            if (_boxUnloadTimer < 1)
            {
                _boxUnloadTimer += (Time.deltaTime/2);
            }
            else
            {
                _boxUnloadTimer = 0;
                _currentBoxes--;
                _score++;
            }

        }
        else if(_currentBoxes <= 0)
        {
            _currentBoxes = 0;
            _objectiveParticles.startColor = Color.green;
            _objectiveParticles.enableEmission = false;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Pistol" || collider.tag == "Shotgun" || collider.tag == "Smg" || collider.tag == "Sniper")
        {
            _movePlayerScript.GetGun(gameObject, collider.GetComponent<Gun>(), 50, _id);
            collider.transform.parent = _gunPositionObject.transform;
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
