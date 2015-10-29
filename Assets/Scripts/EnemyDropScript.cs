using UnityEngine;
using System.Collections;

public class EnemyDropScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Guns;
    private ZombieScript _ZombieScript;
    private int dropChance = 0;
    private void Start()
    {
        _ZombieScript = gameObject.GetComponent<ZombieScript>();
    }
    void OnEnable()
    {
        dropChance = (int)Random.Range(0, 100f);
    }
    void OnDisable()
    {
        if (_ZombieScript != null && _ZombieScript.HP <= 0)
        {
            if (dropChance >= 0 && dropChance <= 20)
            {
                print("no drop");
            }
            else if (dropChance >= 21 && dropChance <= 50)//pistol
            {
                Instantiate(m_Guns[0], transform.position, Quaternion.identity);
            }
            else if (dropChance >= 51 && dropChance <= 60)//shotgun
            {
                Instantiate(m_Guns[1], transform.position, Quaternion.identity);
            }
            else if (dropChance >= 61 && dropChance <= 70)//smg
            {
                Instantiate(m_Guns[2], transform.position, Quaternion.identity);
            }
            else if (dropChance >= 71 && dropChance <= 100)//Sniper rife
            {
                Instantiate(m_Guns[3], transform.position, Quaternion.identity);
            }
        }
    }
}