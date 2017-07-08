using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetrap : MonoBehaviour {
    
    public Vector3 endPosition;
    public int time;
    public iTween.EaseType easyType;
    // Use this for initialization
    void Start () {
        Hashtable args = new Hashtable();
        args.Add("easeType", easyType);
        args.Add("time", time);
        args.Add("loopType", "pingPong");
        args.Add("position", endPosition);
        args.Add("islocal", true);

        iTween.MoveFrom(gameObject, args);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
