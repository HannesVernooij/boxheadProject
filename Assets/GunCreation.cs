using UnityEngine;
using System.Collections;


public interface IShootBehaviour
{
    void Shoot(GameObject gunPivotObject, BulletPool bulletPool, GameObject thisObject);
    void CalculateAmmo();
    void SetAmmo(int value);
    int FullClips();

    int AmmoInClip();
}

public class Pistol : IShootBehaviour
{
    private int _ammo;
    private int _ammoInClip;
    private int _amountOfFullClips;
    private int _clipSize = 6;
    private float _shootDelay = 0.2f;
    private int _bulletSpeed = 50;
    private float bulletDamage = 0.25f;
    private BulletPool _bulletPool;

    public int FullClips()
    {
        return _amountOfFullClips;
    }
    public int AmmoInClip()
    {
        return _ammoInClip;
    }

    public void SetBulletPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void SetAmmo(int value)
    {
        _ammo = value;
        CalculateAmmo();
    }

    public void CalculateAmmo()
    {
        _amountOfFullClips = (int)Mathf.Floor(_ammo / _clipSize);
        _ammoInClip = _ammo % _clipSize;
    }

    public void Shoot(GameObject gunPivotObject, BulletPool bulletPool, GameObject thisObject)
    {
        if (_shootDelay > 0)
        {
            _shootDelay -= Time.deltaTime;
        }
        else
        {
            _bulletPool.UseBullet(gunPivotObject.transform.position, gunPivotObject, _bulletSpeed, "PistolBullet");
            _ammo--;
            CalculateAmmo();
            _shootDelay = 0.2f;
        }
    }
}

public class Shotgun : IShootBehaviour
{
    public int _ammo;
    public int _ammoInClip;
    private int _amountOfFullClips;
    private int _clipSize = 6;
    private float _shootDelay = 0.2f;
    private int _bulletSpeed = 50;
    private float bulletDamage = 0.25f;
    private BulletPool _bulletPool;

    public int FullClips()
    {
        return _amountOfFullClips;
    }
    public int AmmoInClip()
    {
        return _ammoInClip;
    }

    public void SetBulletPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void SetAmmo(int value)
    {
        _ammo = value;
        CalculateAmmo();
    }

    public void CalculateAmmo()
    {
        _amountOfFullClips = (int)Mathf.Floor(_ammo / _clipSize);
        _ammoInClip = _ammo % _clipSize;
    }

    public void Shoot(GameObject gunPivotObject, BulletPool bulletPool, GameObject thisObject)
    {
        if (_shootDelay > 0)
        {
            _shootDelay -= Time.deltaTime;
        }
        else
        {
            _bulletPool.UseBullet(gunPivotObject.transform.position, gunPivotObject, _bulletSpeed, "PistolBullet");
            _ammo--;
            CalculateAmmo();
            _shootDelay = 0.2f;
        }
    }
}

public class Sniper : IShootBehaviour
{
    public int _ammo;
    public int _ammoInClip;
    private int _amountOfFullClips;
    private int _clipSize = 6;
    private float _shootDelay = 0.2f;
    private int _bulletSpeed = 50;
    private float bulletDamage = 0.25f;
    private BulletPool _bulletPool;

    public int FullClips()
    {
        return _amountOfFullClips;
    }
    public int AmmoInClip()
    {
        return _ammoInClip;
    }

    public void SetBulletPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void SetAmmo(int value)
    {
        _ammo = value;
        CalculateAmmo();
    }

    public void CalculateAmmo()
    {
        _amountOfFullClips = (int)Mathf.Floor(_ammo / _clipSize);
        _ammoInClip = _ammo % _clipSize;
    }

    public void Shoot(GameObject gunPivotObject, BulletPool bulletPool, GameObject thisObject)
    {
        if (_shootDelay > 0)
        {
            _shootDelay -= Time.deltaTime;
        }
        else
        {
            _bulletPool.UseBullet(gunPivotObject.transform.position, gunPivotObject, _bulletSpeed, "PistolBullet");
            _ammo--;
            CalculateAmmo();
            _shootDelay = 0.2f;
        }
    }
}


public class Smg : IShootBehaviour
{
    public int _ammo;
    public int _ammoInClip;
    private int _amountOfFullClips;
    private int _clipSize = 6;
    private float _shootDelay = 0.2f;
    private int _bulletSpeed = 50;
    private float bulletDamage = 0.25f;
    private BulletPool _bulletPool;
    public int FullClips()
    {
        return _amountOfFullClips;
    }
    public int AmmoInClip()
    {
        return _ammoInClip;
    }

    public void SetBulletPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    public void SetAmmo(int value)
    {
        _ammo = value;
        CalculateAmmo();
    }

    public void CalculateAmmo()
    {
        _amountOfFullClips = (int)Mathf.Floor(_ammo / _clipSize);
        _ammoInClip = _ammo % _clipSize;
    }

    public void Shoot(GameObject gunPivotObject, BulletPool bulletPool, GameObject thisObject)
    {
        if (_shootDelay > 0)
        {
            _shootDelay -= Time.deltaTime;
        }
        else
        {
            _bulletPool.UseBullet(gunPivotObject.transform.position, gunPivotObject, _bulletSpeed, "PistolBullet");
            _ammo--;
            CalculateAmmo();
            _shootDelay = 0.2f;
        }
    }
}

public class Gun : MonoBehaviour
{
    GameObject _gunPivotObject;
    BulletPool _bulletPool;
    private bool _allowedToShoot = false;
    IShootBehaviour _shootBehaviour;
    int[] _ammo = new int[2];

    public bool AllowedToShoot
    {
        set { _allowedToShoot = value; }
        get { return _allowedToShoot; }
    }
    public IShootBehaviour ShootBehaviour
    {
        set { _shootBehaviour = value; }
        get { return _shootBehaviour; }
    }

    void Start()
    {
        _gunPivotObject = gameObject.transform.Find("ShootPivot").gameObject;
    }

    void Update()
    {
        if (_allowedToShoot == true)
        {
            _shootBehaviour.Shoot(_gunPivotObject, _bulletPool, gameObject);
        }
    }

    public void SetAmmo(int value)
    {
        _shootBehaviour.SetAmmo(value);
    }

    public int FullClips()
    {
        return _shootBehaviour.FullClips();
    }
    public int AmmoInClip()
    {
        return _shootBehaviour.AmmoInClip();
    }
}
