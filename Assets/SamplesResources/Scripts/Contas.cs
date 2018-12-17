using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contas : MonoBehaviour {

    public Transform shortText;

	// Use this for initialization
	void Start () {
        shortText.GetComponent<Text>().text = "YOYO ma men";
    }
	
	// Update is called once per frame
	void Update () {

        shortText.GetComponent<Text>().text = "YOYO ma men";
	    	
	}
}
