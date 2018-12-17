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
    float attackRange = 7f;
    float lockTime = 2.0f;
    float running_time = 0f;

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


            running_time += Time.deltaTime * 1;

            if (running_time >= lockTime)
            {

                GameObject go = GameObject.Find("testeDestroy");
                Destroy(go.gameObject);
                running_time = 0f;

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



}
