using UnityEngine;
using System.Collections;


public class Pool : MonoBehaviour
{
    [SerializeField]
    private string PoolName;
    [SerializeField]
    private PoolableObjects _poolablePrefab;
    [SerializeField]
    private int _poolSize;
    public int PoolSize
    {
        get { return _poolSize; }
    }
    private PoolableObjects[] _poolArray;

    public void Start()
    {
        GameObject parentObject = GameObject.Instantiate(new GameObject());
        parentObject.name = PoolName;
        _poolArray = new PoolableObjects[_poolSize];
        for (int i = 0; i < _poolSize; i++)
        {
            PoolableObjects temp = GameObject.Instantiate(_poolablePrefab) as PoolableObjects;
            temp.transform.parent = parentObject.transform;
            _poolArray[i] = temp;
            temp.Deactivate();
        }
    }

    public void CreateObject(Vector3 position, Quaternion rotation, int damage, string weaponTag)
    {
        switch (weaponTag)
        {
            case "Shotgun":
                ShootFreeObject(position, (rotation * Quaternion.Euler(0, rotation.y - 15, 0)), damage);
                ShootFreeObject(position, (rotation * Quaternion.Euler(0, rotation.y - 0, 0)), damage);
                ShootFreeObject(position, (rotation * Quaternion.Euler(0, rotation.y + 15, 0)), damage);
                break;

            default:
                ShootFreeObject(position, (rotation * Quaternion.Euler(0, rotation.y - 0, 0)), damage);
                break;
        }

    }

    private void ShootFreeObject(Vector3 position, Quaternion rotation, int damage)
    {
        for (int i = 0; i < _poolArray.Length; i++)
        {
            if (_poolArray[i].IsActive() == false)
            {
                _poolArray[i].SetActive(position, rotation);
                _poolArray[i].SetDamage(damage);
                break;
            }
        }
    }
}
