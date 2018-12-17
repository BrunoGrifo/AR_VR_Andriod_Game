using System.Collections;
using System;
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

    public Transform R1;
    public Transform R2;
    public Transform R3;
    public Transform R4;
    public Transform R5;
    public Transform R6;
    public Transform R7;

    Collider m_Collider;

    Transform cameraTransform;
    public bool Focused { get; set; }



    float lockTime = 2.0f;
    float running_time = 0f;

    bool startGame = false;
    List<Transform> Rs;
    List<GameObject> As;

    bool next=true;
    private static System.Random random;
    private static object syncObj = new object();






    void Start () {
        cameraTransform = Camera.main.transform;
        hide(false);
        Rs = new List<Transform>();
        As = new List<GameObject>();
        Rs.Add(R1);
        Rs.Add(R2);
        Rs.Add(R3);
        Rs.Add(R4);
        Rs.Add(R5);
        Rs.Add(R6);
        Rs.Add(R7);
        As.Add(A1);
        As.Add(A2);
        As.Add(A3);
        As.Add(A4);
        As.Add(A5);
        As.Add(A6);
        As.Add(A7);
        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray cameraGaze = new Ray(cameraTransform.position, cameraTransform.forward);
        Physics.Raycast(cameraGaze, out hit, Mathf.Infinity);
        string act;
        int a, b,result,indexCorrect;


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
                    running_time = 0;

                }

            }
            else
            {
                running_time = 0;
            }
        }
        else
        {
            if (next)
            {
                a = randomN(1,20);
                b = randomN(1,20);
                shortText.GetComponent<Text>().text = a.ToString() + " + "+ b.ToString() + " = ?";
                result = soma(a, b);
                indexCorrect = randomN(0, 6);
                fillTargets(indexCorrect, result);
                next = false;
            }

            if (hit.collider && (hit.collider.gameObject == A1))
            {
                act = "A1";
                running_time += Time.deltaTime * 1;
                if (running_time >= lockTime)
                {

                }
                running_time = 0;

            }
            if (hit.collider && (hit.collider.gameObject == A2))
            {
                act = "A2";
                running_time += Time.deltaTime * 1;
                if (running_time >= lockTime)
                {

                }
                running_time = 0;
            }
            if (hit.collider && (hit.collider.gameObject == A3))
            {
                act = "A3";
                running_time += Time.deltaTime * 1;
                if (running_time >= lockTime)
                {

                }
                running_time = 0;
            }
            if (hit.collider && (hit.collider.gameObject == A4))
            {
                act = "A4";
                running_time += Time.deltaTime * 1;
                if (running_time >= lockTime)
                {

                }
                running_time = 0;
            }
            if (hit.collider && (hit.collider.gameObject == A5))
            {
                act = "A5";
                running_time += Time.deltaTime * 1;
                if (running_time >= lockTime)
                {

                }
                running_time = 0;
            }
            if (hit.collider && (hit.collider.gameObject == A6))
            {
                act = "A6";
                running_time += Time.deltaTime * 1;
                if (running_time >= lockTime)
                {

                }
                running_time = 0;
            }
            if (hit.collider && (hit.collider.gameObject == A7))
            {
                act = "A7";
                running_time += Time.deltaTime * 1;
                if (running_time >= lockTime)
                {

                }
                running_time = 0;
            }
        }


    }

    void fillTargets(int index, int result)
    {
        int i = 0;
        foreach(Transform x in Rs)
        {

            if (i == index)
            {
                x.GetComponent<Text>().text = result.ToString();
            }
            else
            {
                x.GetComponent<Text>().text = generateError(result).ToString();
            }
            i++;
        }
    }

    int randomN(int min,int max)
    {
        int a;
        a = random.Next(min, max);
        return a;
    }

    int generateError(int a)
    {
        a= a + random.Next(1, 10);
        return a;
    }

    int soma(int a,int b)
    {
        return a + b;

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
     }

 private static void InitRandomNumber(int seed)
    {
        random = new System.Random(seed);
    }
    private static int GenerateRandomNumber(int max)
    {
        lock (syncObj)
        {
            if (random == null)
                random = new System.Random(); // Or exception...
            return random.Next(max);
        }
    }       
         
     */

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
