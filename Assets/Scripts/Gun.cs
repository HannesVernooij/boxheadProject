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
    private int _damage = 0;
    public string _tag;
    public int _id;
    public SoundSystem _soundScript;

    public string WeaponTag
    {
        set { _tag = value; }
    }

    public int Damage
    {
        set { _damage = value; }
    }

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
        set { _clipSize = value + 1; }
    }

    void Start()
    {
        Debug.Log("OMG YOU CREATED ME");
        _gunPivotObject = transform.Find("ShootPivot").gameObject;
        _bulletPool = GameObject.Find("BulletPool").GetComponent<Pool>();
        _soundScript = GameObject.Find("SoundsParent").GetComponent<SoundSystem>();
    }

    public void Ammo(int value)
    {
        _ammo += value;
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
        Debug.Log(_tag);
        if (_remainingDelay >= 0)
        {
            _remainingDelay -= Time.deltaTime;
        }
        if (_ammoInClip == 0 && _amountOfFullClips > 0)
        {
            _soundScript.Reload(_id, _tag);
            _remainingDelay += _reloadSpeed;
            _ammo--;
            CalculateAmmo();
        }
    }

    public void Shoot()
    {
        if (_remainingDelay <= 0 && _ammo > 0)
        {
            _soundScript.Shoot(_id, _tag);
            _bulletPool.CreateObject(_gunPivotObject.transform.position, _gunPivotObject.transform.rotation, _damage, gameObject.tag);
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
