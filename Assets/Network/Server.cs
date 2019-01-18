using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Net;
using System.Threading;


struct CarInfo{
	public CarInfo(string id, float position){
		this.id = id;
		this.position = position;
	}
	public string id;
	public float position;
}

public class Server : MonoBehaviour
{
	private HttpListener listener;
	private Thread listenerThread;
	LockFreeQueue<CarInfo> queue = new LockFreeQueue<CarInfo>();

	void Start ()
	{
		listener = new HttpListener ();
		string ip = GameObject.FindObjectOfType<Config> ().GetComponent<Config> ().variables["listenIp"];
		string port = GameObject.FindObjectOfType<Config> ().GetComponent<Config> ().variables["listenPort"];
		listener.Prefixes.Add ("http://"+ip+":"+port+"/");
		listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
		listener.Start ();
		listenerThread = new Thread (startListener);
		listenerThread.Start ();
		Debug.Log ("Server Started");
	}
	private void startListener ()
	{
		while (true) {               
			var result = listener.BeginGetContext (ListenerCallback, listener);
			result.AsyncWaitHandle.WaitOne ();
		}
	}
	private void ListenerCallback (IAsyncResult result)
	{				
		var context = listener.EndGetContext (result);		
		string carId = context.Request.QueryString.GetValues ("carId") [0];
		float position = 0;
		float.TryParse (context.Request.QueryString.GetValues ("position") [0], out position);

		queue.Enqueue (new CarInfo(carId, position));

		context.Response.Close ();
	}

	void Update(){
		CarInfo carInfo = new CarInfo();
		if (queue.Dequeue(out carInfo))
			GameObject.FindObjectOfType<Actor> ().GetComponent<Actor> ().updatePosition (carInfo.id, carInfo.position);
	}

}