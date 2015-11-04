using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour
{
    private NavMeshAgent m_NMA;
    private GameObject m_TargetPlayer;
    private Animator m_Animator;
    private int _hp = 10;
    public int HP
    {
        set { _hp = value; }
        get { return _hp; }
    }

    public GameObject SetTargetPlayer { set { m_TargetPlayer = value; } }

    private void Awake()
    {
        m_NMA = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        m_NMA.enabled = false;
    }
    private void OnEnable()
    {
        if (m_NMA != null)
        {
            StartCoroutine(EnableNavMeshAgent());
            _hp = 10;
        }
    }
    private void OnDisable()
    {
        if (m_NMA != null)
            m_NMA.enabled = false;
    }
    private IEnumerator EnableNavMeshAgent()
    {
        yield return new WaitForSeconds(1f);
        m_NMA.enabled = true;
    }
    private void Update()
    {
        if (m_NMA.enabled == true)
        {
            m_NMA.SetDestination(m_TargetPlayer.transform.position);
            m_Animator.SetBool("IsWalking", true);
        }
        else
        {
            m_Animator.SetBool("IsWalking", false);
        }
        if (m_NMA.isOnOffMeshLink == true)
        {
            m_NMA.speed = 0.4f;
        }else { m_NMA.speed = 1f; }
        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
