using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject _targetObject;
    [Range(1.0f,10.0f)]
    public float _followingDistance;
    [Range(1.0f, 10.0f)]
    public float _followingHeight;
    private Vector3 _targetPosition;
    private Vector3 _tempRot;
    [Range(0f,360f)]
    public float _rotationAmount;
    [SerializeField]
    private int _id;
    //[SerializeField]
    //private PlayerMovement _accelerationScript;
    private float _refocusTimer = 0;


    void Update()
    {
        _rotationAmount += Input.GetAxis("Player" + _id +"_Horizontal2") * Time.deltaTime * 100;

        if(Input.GetAxis("Player" + _id + "_Horizontal2") == 0)
        {
            if (_refocusTimer < 0.5)
            {
                _refocusTimer += Time.deltaTime;
            }
            else if (_refocusTimer >= 0.5)
            {
                if(Input.GetAxis("Player" + _id + "_Vertical") != 0)
                FocusOnPlayer();
            }
        }
        else
        {
            _refocusTimer = 0;
        }
        _targetPosition = new Vector3(_targetObject.transform.position.x + -Mathf.Cos((_rotationAmount / 360) * Mathf.PI * 2) * _followingDistance, _followingHeight, _targetObject.transform.position.z + -Mathf.Sin((_rotationAmount / 360) * Mathf.PI * 2) * _followingDistance);
        _tempRot = new Vector3(0, _rotationAmount, 0);

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, _targetPosition, Mathf.Clamp((Vector3.Distance(gameObject.transform.position, _targetPosition) * Time.deltaTime),0.007f,1));
        Quaternion tempRotQuat = Quaternion.Euler(_tempRot.x + 25, -_tempRot.y + 90, _tempRot.z);
        gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, tempRotQuat, Time.deltaTime * Vector3.Distance(gameObject.transform.position, _targetPosition) * 4);
    }

    public void FocusOnPlayer()
    {
        _rotationAmount = -_targetObject.transform.rotation.eulerAngles.y + 180;
    }
}
