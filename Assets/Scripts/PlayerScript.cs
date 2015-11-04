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
    [SerializeField]
    UIScript _uiScript;
    private Vector3 _startPosition;
    private GameObject _controlObject;
    private float _boxLoadTimer = 0;
    private float _boxUnloadTimer = 0;
    private int _currentBoxes;
    private int _score = 0;
    private int _hp = 10;
    private float _tempDamageCounter;

    public int HP
    {
        set { _hp = value; }
        get { return _hp; }
    }
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
        _startPosition = gameObject.transform.position;
    }

    public void Update()
    {
        if (_hp <= 0)
        {
            _hp = 10;
            gameObject.transform.position = _startPosition;
            _movePlayerScript.AddBox(_currentBoxes);
            _currentBoxes = 0;
        }

        if (Vector3.Distance(gameObject.transform.position, _controlObject.transform.position) < 1.3f)
        {
            if (_boxLoadTimer < 1)
            {
                _boxLoadTimer += Time.deltaTime / 10;
            }
            else
            {
                _boxLoadTimer = 0;
                _currentBoxes += _movePlayerScript.GetBox();
                _objectiveParticles.enableEmission = true;
            }
        }

        if (Vector3.Distance(gameObject.transform.position, _objectiveParticles.transform.position) < 1f && _currentBoxes > 0)
        {
            _objectiveParticles.startColor = Color.blue;

            if (_boxUnloadTimer < 1)
            {
                _boxUnloadTimer += (Time.deltaTime / 2);
            }
            else
            {
                _boxUnloadTimer = 0;
                _currentBoxes--;
                _score++;
            }

        }
        else if (_currentBoxes <= 0)
        {
            _currentBoxes = 0;
            _objectiveParticles.startColor = Color.green;
            _objectiveParticles.enableEmission = false;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Pistol")
        {
            _movePlayerScript.CurrentPlayerGuns[_id, 0].Ammo(Random.Range(12, 50));
            Destroy(collider.gameObject);
        }
        if (collider.tag == "Shotgun")
        {
            _movePlayerScript.CurrentPlayerGuns[_id, 1].Ammo(Random.Range(6, 20));
            Destroy(collider.gameObject);
        }
        if (collider.tag == "Smg")
        {
            _movePlayerScript.CurrentPlayerGuns[_id, 2].Ammo(Random.Range(30, 90));
            Destroy(collider.gameObject);
        }
        if (collider.tag == "Sniper")
        {
            _movePlayerScript.CurrentPlayerGuns[_id, 3].Ammo(Random.Range(6, 20));
            Destroy(collider.gameObject);
        }
        //_uiScript.UpdateValues();  //ToDo
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            _tempDamageCounter += Time.deltaTime;

            if (_tempDamageCounter > 1)
            {
                _hp--;
                _tempDamageCounter = 0;
            }
        }
    }

}
