using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

	Rigidbody rb;
	FishProperties property;
	[Range(200,1000)]
	float moveSpeed = 400;

	public GameObject spearObject;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		property = GetComponent<FishProperties>();
		property.startPos = transform.position;
		property.currentPos = transform.position;
		rb.AddForce(new Vector3(0, 0, -GetComponent<FishProperties>().moveSpeed));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		// Infinite movement
		ResetPosition();
		property.currentPos = transform.position;
		// Hit
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.tag == "Fish")
				{
					//Debug.Log("Kill Fish");
					spearObject.GetComponent<Spear>().setTarget(hit.transform.gameObject);
				}
				else
				{
					Debug.Log(hit.transform.name);
				}
			}
		}

		
	}

	void ResetPosition()
	{
		if (transform.position.z < Camera.main.transform.position.z)
		{
			transform.position = new Vector3(property.startPos.x, property.startPos.y, property.startPos.z);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Spear")
		{
			transform.position = new Vector3(property.startPos.x, property.startPos.y, property.startPos.z);
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.AddForce(new Vector3(0, 0, -GetComponent<FishProperties>().moveSpeed));
		}
	}
}
