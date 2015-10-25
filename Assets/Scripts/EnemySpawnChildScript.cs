using UnityEngine;
using System.Collections;

public class EnemySpawnChildScript : MonoBehaviour
{
    [SerializeField]
    private EnemySpawnScript _EnemySpawnScript;

    public EnemySpawnScript GetEnemySpawnScript { get { return _EnemySpawnScript; } }
    public State State { get { return m_State; } set { m_State = value; } }
    public GameObject Player { get { return m_Player; } set { m_Player = value; } }
    public bool SetCanSpawn { set { m_CanSpawn = value; } }

    private State m_State;
    private GameObject m_Player;
    private bool m_CanSpawn;
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
        if (m_State != null && m_CanSpawn == true && coll.gameObject == m_Player && _EnemySpawnScript.GetZombieSpawnLimit >= 0)
        {
            m_State.OnTriggerStay();
            print(transform.name + " " + coll.gameObject.transform.parent);

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
    private float timer = 10;
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
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnZombie();
            spawn.GetEnemySpawnScript.GetZombieSpawnLimit -= 1;
            timer = 10;
        }
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