using UnityEngine;
using System.Collections;

public class EnemyDropScript : MonoBehaviour
{
    private int dropChance = 0;
    void OnEnable()
    {
        if (gameObject.transform.tag == "zombieNormal")
        {
            dropChance = (int)Random.Range(0f, 79);
        }
        else
        {
            dropChance = (int)Random.Range(80f, 100f);
        }
    }
    void Update()
    {

    }
    void OnDisable()
    {
        if (dropChance >= 0 && dropChance <= 20)
        {
            print("no drop");
        }
        else if (dropChance >= 21 && dropChance <= 60)
        {
            Instantiate(GameObject.CreatePrimitive(PrimitiveType.Sphere), transform.position, transform.rotation);
        }
        else if (dropChance >= 61 && dropChance <= 80)
        {
            Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cylinder), transform.position, transform.rotation);
        }
        else if (dropChance >= 81 && dropChance <= 100)
        {
            Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), transform.position, transform.rotation);
        }
    }
}
