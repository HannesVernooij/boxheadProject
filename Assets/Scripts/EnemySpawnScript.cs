using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;
    [SerializeField]
    private GameObject[] m_ZombiePrefabs,
                         m_ZombieSpawnPoints;
    [SerializeField]
    private float m_Timer = 5;

    public GameObject ZombiesParent { get { return m_ZombiesEmtyGameObjectParent; } set { m_ZombiesEmtyGameObjectParent = value; } }
    public GameObject[] GetZombies { get { return zombies; } }                   
    public float Timer { get { return m_Timer; } set { m_Timer = value; } }

    private EnemySpawnChildScript[] _EnemySpawnChildScript;
    private GameObject m_ZombiesEmtyGameObjectParent;
    private GameObject[] zombies;
    private int m_ZombieSpawnLimit = 2;

    private void Start()
    {
        m_ZombieSpawnPoints = ZombieSpawnPointsSet();
        CreateZombiesPool();
    }
    private void Update()
    {
        SpawnZombieWithTimer(m_Timer -= Time.deltaTime);
    }
    private void SpawnZombieWithTimer(float timer)
    {
        if(m_Timer <= 0)
        {
            foreach (EnemySpawnChildScript script in _EnemySpawnChildScript)
            {
                if (script.CanSpawnPool == false)   //IK GA ETEN HALEN EN KOFFIE
                {
                    print(script);
                    script.CanSpawnPool = true;
                    m_Timer = 5;
                    return;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == m_Player)
        {
            foreach (EnemySpawnChildScript enemySpawnChildScript in _EnemySpawnChildScript)
            {
                enemySpawnChildScript.CanSpawnCollider = true;
            }
        }
    }
    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject == m_Player)
        {
            foreach (EnemySpawnChildScript enemySpawnChildScript in _EnemySpawnChildScript)
            {
                enemySpawnChildScript.CanSpawnCollider = false;
            }
        }
    }
    //
    private GameObject GettingTheChildSpawnZombieArea { get { return m_Player.transform.FindChild("ColliderSpawnZombieArea").gameObject; } }
    private GameObject[] ZombieSpawnPointsSet()
    {
        m_ZombieSpawnPoints = new GameObject[transform.childCount];
        _EnemySpawnChildScript = new EnemySpawnChildScript[transform.childCount];
        GameObject[] temp = new GameObject[m_ZombieSpawnPoints.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = transform.GetChild(i).gameObject;
            _EnemySpawnChildScript[i] = temp[i].AddComponent<EnemySpawnChildScript>();
            _EnemySpawnChildScript[i].Player = GettingTheChildSpawnZombieArea;
        }
        return temp;
    }
    //
    private void CreateZombiesPool()
    {
        GameObject zombiesParent = new GameObject("ZombiesParent");
        zombiesParent.transform.SetParent(transform);
        zombies = new GameObject[m_ZombieSpawnLimit];
        for (int i = 0; i < m_ZombieSpawnLimit; i++)
        {
            int r = Random.Range(0, 3);
            zombies[i] = Instantiate(m_ZombiePrefabs[r], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            zombies[i].transform.SetParent(zombiesParent.transform);
            zombies[i].SetActive(false);
        }
    }
    //
}