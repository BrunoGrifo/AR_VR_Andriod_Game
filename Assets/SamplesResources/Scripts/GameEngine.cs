using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {
    public GameObject A1;
    public GameObject A2;
    public GameObject A3;
    public GameObject A4;
    public GameObject A5;
    public GameObject A6;
    public GameObject A7;

    public GameObject startButton;
    public Transform shortText;

    Collider m_Collider;
    private bool show = true;

    Transform cameraTransform;
    public bool Focused { get; set; }



    float attackRange = 7f;
    float lockTime = 2.0f;
    float running_time = 0f;

    bool startGame = false;












    void Start () {
        cameraTransform = Camera.main.transform;
        hide(false);

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray cameraGaze = new Ray(cameraTransform.position, cameraTransform.forward);
        Physics.Raycast(cameraGaze, out hit, Mathf.Infinity);

        if (!startGame)
        {
            Focused = hit.collider && (hit.collider.gameObject.name == "testeN");

            if (Focused)
            {
                running_time += Time.deltaTime * 1;

                if (running_time >= lockTime)
                {

                    shortText.GetComponent<Text>().text = "Start!!!";
                    GameObject go = startButton;
                    Destroy(go.gameObject);
                    hide(true);
                    startGame = true;

                }
            }
        }
        else
        {
            if (hit.collider.gameObject.name == "A3")
            {
                GameObject go = A3;
                Destroy(go.gameObject);
            }
        }


    }



    /* public void ShowAndHide()
     {
         if (!show==false)
         {
             InfoPanel.SetActive(true);
             show = true;
         }
         else
         {
             InfoPanel.SetActive(false);
             show = false;
         }
     }*/

    void hide(bool x)
    {
        A1.SetActive(x);
        A2.SetActive(x);
        A3.SetActive(x);
        A4.SetActive(x);
        A5.SetActive(x);
        A6.SetActive(x);
        A7.SetActive(x);
    }
}
