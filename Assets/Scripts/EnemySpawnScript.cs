using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Player;
    [SerializeField]
    private GameObject[] m_ZombieAssets,
                         m_ZombieSpawnPoints;

    public GameObject ZombiesParent { get { return m_ZombiesEmtyGameObjectParent; } set { m_ZombiesEmtyGameObjectParent = value; } }
    public GameObject[] GetZombies { get { return zombies; } }                   
    public int GetZombieSpawnLimit { get { return m_ZombieSpawnLimit; } set { m_ZombieSpawnLimit = value; } }

    private EnemySpawnChildScript[] _EnemySpawnChildScript;
    private GameObject m_ZombiesEmtyGameObjectParent;
    private GameObject[] zombies;
    private int m_ZombieSpawnLimit = 30;

    private void Start()
    {
        m_ZombieSpawnPoints = ZombieSpawnPointsSet();
        CreateZombiesPool();
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == m_Player)
        {
            foreach (EnemySpawnChildScript enemySpawnChildScript in _EnemySpawnChildScript)
            {
                enemySpawnChildScript.SetCanSpawn = true;
            }
        }
    }
    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject == m_Player)
        {
            foreach (EnemySpawnChildScript enemySpawnChildScript in _EnemySpawnChildScript)
            {
                enemySpawnChildScript.SetCanSpawn = false;
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
            _EnemySpawnChildScript[i].SetPlayer = GettingTheChildSpawnZombieArea;
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
            zombies[i] = new GameObject("zombie" + i);
            zombies[i].transform.SetParent(zombiesParent.transform);
            AddingComponentsToZombies(zombies[i]);
            zombies[i].SetActive(false);
        }
    }
    private void AddingComponentsToZombies(GameObject zombie)
    {
        int r = Random.Range(0, 3);
        GameObject randomZombieAsset = m_ZombieAssets[r];

        MeshFilter MF = zombie.AddComponent<MeshFilter>();
        MeshRenderer MR = zombie.AddComponent<MeshRenderer>();

        MF.mesh = randomZombieAsset.GetComponent<MeshFilter>().sharedMesh;
        MR.material = randomZombieAsset.GetComponent<MeshRenderer>().sharedMaterial;

        zombie.transform.rotation = randomZombieAsset.transform.rotation;
    }
    //
}