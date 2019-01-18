using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Config : MonoBehaviour {


	public Dictionary<string, string> variables = new Dictionary<string, string>(){
		{"listenIp", "localhost"},
		{"listenPort", "7171"},
		{"requestIp", "localhost"},
		{"requestPort", "8989"},

	};

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void OnGUI()
	{
		string text = "";
		foreach (KeyValuePair<string,string> var in variables) {
			text += System.String.Format ("{0,-20} {1,-20}\n", var.Key, var.Value);
		}
		GUI.Box(new Rect(0, 0, 300, 200), text);
	}

	public void updateVariable(string key, string value){
		variables[key] = value;
	}

	public void listenIp(string value){
		variables ["listenIp"] = value;
	}

	public void listenPort(string value){
		variables ["listenPort"] = value;
	}

	public void requestIp(string value){
		variables ["requestIp"] = value;
	}

	public void requestPort(string value){
		variables ["requestPort"] = value;
	}

	public void start(){
		SceneManager.LoadScene("Scene", LoadSceneMode.Single);
	}

	public void addGUI(string text, string value){
		variables [text] = value;
	}

}
