using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

[System.Serializable]
public class Object{
	public string carId;
	public string objectId;
	public float objectDistance;
}

[System.Serializable]
public class Map
{
	public Object[] objects;

}
	

public class Client : MonoBehaviour {



	void Start() {
		StartCoroutine(GetText());
	}

	IEnumerator GetText() {
		while (true) {
			string ip = GameObject.FindObjectOfType<Config> ().GetComponent<Config> ().variables["requestIp"];
			string port = GameObject.FindObjectOfType<Config> ().GetComponent<Config> ().variables["requestPort"];
			UnityWebRequest www = UnityWebRequest.Get ("http://"+ip+":"+port+"/car2car/app/objects/json");
			yield return www.SendWebRequest ();

			if (www.isNetworkError || www.isHttpError) {
				Debug.Log (www.error);
			} else {
				string answers = www.downloadHandler.text;
				Map map = JsonUtility.FromJson<Map> (www.downloadHandler.text);
				GameObject.FindObjectOfType<Environment> ().GetComponent<Environment> ().clean ();
				foreach (var obj in map.objects) {
					GameObject.FindObjectOfType<Environment> ().GetComponent<Environment> ().add (obj.objectDistance);
				}
			}
			yield return new WaitForSeconds (0.5f);
		}
	}
}