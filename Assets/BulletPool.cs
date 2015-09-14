using UnityEngine;
using System.Collections;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private BulletScript[] _bulletPool = new BulletScript[100];

    void Start()
    {
        GameObject temp;

        for(int i = 0; i < 100; i ++)
        {
            temp = GameObject.Instantiate(_prefab);
            _bulletPool[i] = temp.GetComponent<BulletScript>();
            _bulletPool[i].transform.parent = gameObject.transform;
            _bulletPool[i].SetActive(false);
        }
    }
    
    public void UseBullet(Vector3 startPosition, Quaternion rotation, GameObject fromObject)
    {
        for(int i = 0; i < _bulletPool.Length; i++)
        {
            if(_bulletPool[i].IsActive() == false)
            {
                _bulletPool[i].transform.position = startPosition;
                _bulletPool[i].transform.rotation = fromObject.transform.rotation;
                _bulletPool[i].SetActive(true);
                break;
            }
        }
    }
}
