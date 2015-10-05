using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    private int _bulletSpeed = 50;
    public int BuletSpeed
    {
        set { _bulletSpeed = value; }
    }
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _bulletSpeed;
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

    void OnCollisionEnter()
    {
        gameObject.transform.parent = gameObject.transform;
        SetActive(false);
    }
}
