using UnityEngine;
using System.Collections;

public class BulletScript : PoolableObjects
{
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
        gameObject.SetActive(false);
    }

    public void Update()
    {
        gameObject.transform.position += Vector3.forward * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SceneObject")
        {
            Deactivate();
        }
    }
}
