using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public GameObject _gunPivotObject;
    private Pool _bulletPool;
    private bool _allowedToShoot = false;
    private int _ammo = 0;
    private int _clipSize = 0;
    private int _amountOfFullClips = 0;
    private int _ammoInClip = 0;
    private float _shootDelay = 0;
    private float _remainingDelay;
    private float _reloadSpeed;

    public float ReloadSpeed
    {
        set { _reloadSpeed = value; }
    }

    public float ShootDelay
    {
        set
        {
            _shootDelay = value;
            _remainingDelay = value;
        }
    }
    public int ClipSize
    {
        set { _clipSize = value; }
    }

    void Start()
    {
        _gunPivotObject = transform.Find("ShootPivot").gameObject;
        _bulletPool = GameObject.Find("BulletPool").GetComponent<Pool>();
    }

    public void Ammo(int value)
    {
        _ammo = value;
        CalculateAmmo();
    }
    public int Ammo()
    {
        return _ammo;
    }

    public void CalculateAmmo()
    {
        _amountOfFullClips = (int)Mathf.Floor(_ammo / _clipSize);
        _ammoInClip = _ammo % _clipSize;
    }
    void Update()
    {
        if (_remainingDelay >= 0)
        {
            _remainingDelay -= Time.deltaTime;
        }
    }

    public void Shoot()
    {

        if (_remainingDelay <= 0 && _ammo > 0)
        {
            _bulletPool.CreateObject(_gunPivotObject.transform.position, _gunPivotObject.transform.rotation);
            _ammo--;
            CalculateAmmo();
            _remainingDelay = _shootDelay;
        }
    }

    public int FullClips()
    {
        return _amountOfFullClips;
    }
    public int AmmoInClip()
    {
        return _ammoInClip;
    }
}
