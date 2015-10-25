    using UnityEngine;
using System.Collections;

public class EnemySpawnChildScript : MonoBehaviour
{
    [SerializeField]
    private EnemySpawnScript _EnemySpawnScript;

    public EnemySpawnScript GetEnemySpawnScript { get { return _EnemySpawnScript; } }
    public State State { get { return m_State; } set { m_State = value; } }
    public GameObject Player { get { return m_Player; } set { m_Player = value; } }
    public bool CanSpawnCollider { set { m_CanSpawnCollider = value; } get { return m_CanSpawnCollider; } }
    public bool CanSpawnPool { set { m_canSpawnPool = value; } get { return m_canSpawnPool; } }

    private State m_State;
    private GameObject m_Player;
    private bool m_CanSpawnCollider;
    private bool m_canSpawnPool;

    private void Start()
    {
        _EnemySpawnScript = transform.parent.transform.GetComponent<EnemySpawnScript>();
        m_State = new SpawnAllowed(this, transform);
    }
    private void Update()
    {
    }
    private void OnTriggerStay(Collider coll)
    {
        if (m_State != null && m_canSpawnPool == true && m_CanSpawnCollider == true && coll.gameObject == m_Player)
        {
            m_State.OnTriggerStay();
            m_canSpawnPool = false;
        }

    }
}
public interface State
{
    void Update();
    void OnTriggerStay();
    void Start();
}

public class SpawnAllowed : State
{
    private EnemySpawnChildScript spawn;
    private Transform transform;
    public SpawnAllowed(EnemySpawnChildScript enemySpawnChildScript, Transform parentTransform)
    {
        spawn = enemySpawnChildScript;
        transform = parentTransform;
    }
    public void Start()
    {

    }
    public void Update()
    {

    }

    public void OnTriggerStay()
    {
        SpawnZombie();
    }
    private void SpawnZombie()
    {
        foreach (GameObject go in spawn.GetEnemySpawnScript.GetZombies)
        {
            if (go.activeSelf == false)
            {
                go.SetActive(true);
                go.transform.position = transform.position;
                go.GetComponent<ZombieScript>().SetTargetPlayer = spawn.Player;
                return;
            }
        }
    }
}