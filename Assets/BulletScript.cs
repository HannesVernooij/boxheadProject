using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 50;
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
