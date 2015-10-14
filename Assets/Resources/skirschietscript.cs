using UnityEngine;
using System.Collections;

public class skirschietscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += transform.forward * Time.deltaTime * 5;
	}
}
