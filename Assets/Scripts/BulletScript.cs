using UnityEngine;
using System.Collections;

public class BulletScript : PoolableObjects
{
    private int _damage;
    public override bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public override void SetActive(Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        transform.rotation = rot;
        gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        _damage = 0;
        gameObject.SetActive(false);
    }

    public void Update()
    {
        gameObject.transform.position += transform.forward * Time.deltaTime * 5;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SceneObject")
        {
            Deactivate();
        }
        else if (collision.collider.tag == "Player")
        {
            Debug.Log("HIT PLAYER");
            collision.collider.GetComponent<PlayerScript>().HP -= _damage;
            Deactivate();
        }
        else if (collision.collider.tag == "Zombie")
        {
            collision.collider.GetComponent<ZombieScript>().HP -= _damage;
            Deactivate();
        }
    }

    public override void SetDamage(int damage)
    {
        _damage = damage;
    }
}
