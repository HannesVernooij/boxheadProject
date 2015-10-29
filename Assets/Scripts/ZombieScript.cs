using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour
{
    private NavMeshAgent m_NMA;
    private GameObject m_TargetPlayer;
    private int _hp = 10;
    public int HP
    {
        set { _hp = value; }
        get { return _hp; }
    }

    public GameObject SetTargetPlayer { set { m_TargetPlayer = value; } }

    private void Start()
    {
        m_NMA = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        if (m_NMA != null)
        {
            m_NMA.enabled = true;
            _hp = 10;
        }
    }
    private void OnDisable()
    {
        if (m_NMA != null)
            m_NMA.enabled = false;
    }
    private void Update()
    {
        m_NMA.SetDestination(m_TargetPlayer.transform.position);
        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
