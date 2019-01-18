using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {

	List<GameObject> objects = new List<GameObject>();

	[SerializeField]
	GameObject cube;

	int start = -20;
	int end = 20;

	float toScale(float value , int min, int max, int minScale, int maxScale)
	{
		float scaled = minScale + (float)(value - min)/(max-min) * (maxScale - minScale);
		return scaled;
	}


	public void clean(){
		foreach (var obj in objects)
			Destroy (obj);
		objects.Clear ();
	}

	public void add(float position){
		Vector3 newPosition = new Vector3 (2.5f, 0, toScale (position, 0, 400, start, end));
		GameObject obj = Instantiate (cube).gameObject;
		obj.transform.position = newPosition;
		objects.Add (obj);
	}

}
