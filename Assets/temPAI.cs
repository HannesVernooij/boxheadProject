using UnityEngine;
using System.Collections;

public class temPAI : MonoBehaviour {
    [SerializeField]
    private NavMeshAgent _navMeshAgent;
    public GameObject target;

	// Use this for initialization
	void Start () {
        _navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        _navMeshAgent.destination = target.transform.position;
	}
}
