using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	int start = -20;
	int end = 20;

	float toScale(float value , int min, int max, int minScale, int maxScale)
	{
		float scaled = minScale + (float)(value - min)/(max-min) * (maxScale - minScale);
		return scaled;
	}

	public void updatePosition(string id, float position){
		GameObject.FindObjectOfType<Config> ().GetComponent<Config> ().addGUI ("carId", id);
		GameObject.FindObjectOfType<Config> ().GetComponent<Config> ().addGUI ("carPos", position.ToString());
		float realPosition = toScale (position, 0, 400, start, end);
		transform.position = new Vector3(transform.position.x, transform.position.y, realPosition);

	}

}
