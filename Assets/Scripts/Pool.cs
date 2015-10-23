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
        for(int i = 0; i < _poolSize; i++)
        {
            PoolableObjects temp = GameObject.Instantiate(_poolablePrefab) as PoolableObjects;
            temp.transform.parent = parentObject.transform;
            _poolArray[i] = temp;
            temp.Deactivate();
        }
    }
    
    public void CreateObject(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < _poolArray.Length; i++)
        {
            if (_poolArray[i].IsActive() == false)
            {
                _poolArray[i].SetActive(position, rotation);
                if(tag != "Untagged")
                {
                    Debug.Log(tag);
                }
                break;
            }
        }
    }
}
