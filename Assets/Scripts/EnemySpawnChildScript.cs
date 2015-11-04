    using UnityEngine;
using System.Collections;

public class EnemySpawnChildScript : MonoBehaviour
{
    public EnemySpawnScript _EnemySpawnScript;

    public EnemySpawnScript GetEnemySpawnScript { get { return _EnemySpawnScript; } }
    public State State { get { return m_State; } set { m_State = value; } }
    public GameObject Player { get { return m_Player; } set { m_Player = value; } }
    public bool CanSpawnCollider { set { m_CanSpawnCollider = value; } get { return m_CanSpawnCollider; } }

    private State m_State;
    private GameObject m_Player;
    private bool m_CanSpawnCollider;
    private void Start()
    {
        _EnemySpawnScript = transform.parent.transform.GetComponent<EnemySpawnScript>();
        m_State = new SpawnAllowed(this);
    }
    private void Update()
    {
    }
    private void OnTriggerStay(Collider coll)
    {
        if (m_State != null &&  m_CanSpawnCollider == true && coll.gameObject == m_Player)
        {
            m_State.OnTriggerStay();
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
    private float m_TimerStart,
                  m_TimerRestart;
    public SpawnAllowed(EnemySpawnChildScript enemySpawnChildScript)
    {
        spawn = enemySpawnChildScript;
        Start();
    }
    public void Start()
    {
        transform = spawn.transform;
        m_TimerStart = spawn._EnemySpawnScript.TimerStart;
        m_TimerRestart = spawn._EnemySpawnScript.TimerRestart;

    }
    public void Update()
    {

    }

    public void OnTriggerStay()
    {
        m_TimerStart -= Time.deltaTime;
        SpawnZombie();
    }
    private void SpawnZombie()
    {
        if (m_TimerStart <= 0)
        {
            foreach (GameObject go in spawn.GetEnemySpawnScript.GetZombies)
            {
                if (go.activeSelf == false)
                {
                    go.SetActive(true);
                    go.transform.position = transform.position;
                    go.GetComponent<ZombieScript>().SetTargetPlayer = spawn.Player;
                    m_TimerStart = m_TimerRestart;
                    return;
                }
            }
        }
    }
}