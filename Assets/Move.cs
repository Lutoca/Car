using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	public float speed = 1.5f;	

	void Start () {
	
	}

	// Update is called once per frame



	void Update()
	{

		CheckKeys();

	}

	void CheckKeys()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			
		
			transform.position += Vector3.forward * speed;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.back * speed;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			
			transform.position += Vector3.right * speed;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.left * speed;
		}


	}
}