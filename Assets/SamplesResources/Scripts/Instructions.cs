using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {
    public GameObject inscruction;
    public GameObject display;
    public GameObject ownObject;
    Collider m_Collider,m_Collider2;

    // Use this for initialization
    void Start () {
        display.GetComponent<Collider>().enabled = false;
        if (inscruction != null)
            m_Collider = inscruction.GetComponent<Collider>();
        if (ownObject != null)
            m_Collider2 = ownObject.GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (m_Collider.bounds.Intersects(m_Collider2.bounds))
        {
            display.GetComponent<Collider>().enabled = true;
        }
        else
        {
            display.GetComponent<Collider>().enabled = false;
        }


    }
}
