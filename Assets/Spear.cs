using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {

	public float speed = 50;
	Vector3 target;
	Vector3 startPos;
	GameObject targetObject;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(targetObject != null)
		{
			target = targetObject.GetComponent<FishProperties>().currentPos;
			transform.LookAt(target);
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		}
		
	}

	public void setTarget(GameObject _target)
	{
		targetObject = _target;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Fish")
		{
			transform.position = startPos;
			transform.rotation = Quaternion.identity;
			targetObject = null;
		}
	}
}
