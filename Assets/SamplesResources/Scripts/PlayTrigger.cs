using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTrigger : MonoBehaviour {

    public enum TriggerType
    {
        VR_TRIGGER,
        AR_TRIGGER
    }

    #region PUBLIC_MEMBER_VARIABLES
    public TriggerType triggerType = TriggerType.VR_TRIGGER;
    public float activationTime = 1.5f;
    public bool Focused { get; set; }
    public GameObject start;
    public GameObject quit;
    public GameObject intruc;
    public GameObject ownObject;
    #endregion // PUBLIC_MEMBER_VARIABLES


    #region PRIVATE_MEMBER_VARIABLES
    Collider m_Collider, m_Collider2, m_Collider3, m_Collider4;
    float mFocusedTime;
    TransitionManager mTransitionManager;
    Transform cameraTransform;
    #endregion // PRIVATE_MEMBER_VARIABLES


    void Start()
    {
        cameraTransform = Camera.main.transform;
        mTransitionManager = FindObjectOfType<TransitionManager>();
        if (start != null)
            m_Collider = start.GetComponent<Collider>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        if (ownObject != null)
            m_Collider2 = ownObject.GetComponent<Collider>();

        if (quit != null)
            m_Collider3 = quit.GetComponent<Collider>();

        if (intruc != null)
            m_Collider4 = intruc.GetComponent<Collider>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray cameraGaze = new Ray(cameraTransform.position, cameraTransform.forward);
        Physics.Raycast(cameraGaze, out hit, Mathf.Infinity);
        Focused = hit.collider && (hit.collider.gameObject == gameObject);

        if (m_Collider.bounds.Intersects(m_Collider2.bounds))
        {
            // Activate transition from AR to VR or vice versa
            bool goingBackToAR = (triggerType == TriggerType.AR_TRIGGER);
            mTransitionManager.Play(goingBackToAR);
            StartCoroutine(ResetAfter(0.3f * mTransitionManager.transitionDuration));
        }

        if (m_Collider3.bounds.Intersects(m_Collider2.bounds))
        {
            Application.Quit();
        }
        if (m_Collider4.bounds.Intersects(m_Collider2.bounds))
        {

        }

    }



    private void UpdateMaterials(bool focused)
    {
       

        float t = focused ? Mathf.Clamp01(mFocusedTime / activationTime) : 0;

        foreach (var rnd in GetComponentsInChildren<Renderer>())
        {
            if (rnd.material.shader.name.Equals("Custom/SurfaceScan"))
            {
                rnd.material.SetFloat("_ScanRatio", t);
            }
        }
    }



    private IEnumerator ResetAfter(float seconds)
    {
        Debug.Log("Resetting View trigger after: " + seconds);

        yield return new WaitForSeconds(seconds);

        Debug.Log("Resetting View trigger: " + name);

        // Reset variables
        mFocusedTime = 0;
        Focused = false;
        UpdateMaterials(false);
    }
 
    
}
