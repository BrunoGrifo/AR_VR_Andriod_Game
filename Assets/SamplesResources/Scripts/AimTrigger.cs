using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTrigger : MonoBehaviour {
    float activationTime = 1.5f;
    public Material focusedMaterial;
    public Material nonFocusedMaterial;
    public bool Focused { get; set; }

    float mFocusedTime;
    bool mTriggered;

    Transform cameraTransform;
    // Use this for initialization
    void Start () {
        cameraTransform = Camera.main.transform;
        GetComponent<Renderer>().material = nonFocusedMaterial;
    }
	
	// Update is called nce per frame
	void Update () {
        RaycastHit hit;
        Ray cameraGaze = new Ray(cameraTransform.position, cameraTransform.forward);
        Physics.Raycast(cameraGaze, out hit, Mathf.Infinity);
        Focused = hit.collider && (hit.collider.gameObject.name == "testeDestroy");


        if (mTriggered)
            return;



        bool startAction = false || Input.GetMouseButtonUp(0);

        if (Focused)
        {
            GameObject go = GameObject.Find("testeDestroy");
            Destroy(go.gameObject);


            // Update the "focused state" time
            mFocusedTime += Time.deltaTime;
            if ((mFocusedTime > activationTime) || startAction)
            {
                // Debug.Log("Tocou");
                MakeConnection();

            }
        }
        else
        {
           // Debug.Log("Fora");
            // Reset the "focused state" time
            mFocusedTime = 0;
            Renderer meshRenderer = GetComponent<Renderer>();
            meshRenderer.material = focusedMaterial;
        }
    }

    private void MakeConnection()
    {
        mTriggered = true;
        mFocusedTime = 0;
        Renderer meshRenderer = GetComponent<Renderer>();
        meshRenderer.material = focusedMaterial;
    }
}
