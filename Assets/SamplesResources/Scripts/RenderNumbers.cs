using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderNumbers : MonoBehaviour {

    public class scriptCube
    {
        static GameObject addSide(int size, string text)
        {
            GameObject mainObj = new GameObject();
            Canvas canvasObj = mainObj.AddComponent<Canvas>();
            canvasObj.renderMode = RenderMode.WorldSpace;

            GameObject childObj2 = new GameObject();
            RawImage rawimageObj = childObj2.AddComponent<RawImage>();
            rawimageObj.rectTransform.SetSizeWithCurrentAnchors
                 (RectTransform.Axis.Horizontal, size);
            rawimageObj.rectTransform.SetSizeWithCurrentAnchors
                 (RectTransform.Axis.Vertical, size);
            rawimageObj.color = Color.yellow;
            childObj2.transform.SetParent(mainObj.transform, false);

            GameObject childObj1 = new GameObject();
            Text textObj = childObj1.AddComponent<Text>();
            textObj.font = (Font)Resources.GetBuiltinResource
                (typeof(Font), "Arial.ttf"); ;
            textObj.text = text;
            textObj.alignment = TextAnchor.MiddleCenter;
            textObj.enabled = true;
            textObj.fontSize = (int)(size * 0.02);
            textObj.color = Color.black;
            textObj.rectTransform.SetSizeWithCurrentAnchors
                (RectTransform.Axis.Horizontal, size);
            textObj.rectTransform.SetSizeWithCurrentAnchors
                (RectTransform.Axis.Vertical, size);
            childObj1.transform.SetParent(mainObj.transform, false);

            return mainObj;
        }

        public static GameObject createCube(string name, int size)
        {

            GameObject mainObj = GameObject.Find("testeN"); ;
            mainObj.name = name;

            GameObject side1 = addSide(size, "1");
            side1.transform.SetParent(mainObj.transform);
            side1.transform.position = new Vector3(0, 0, -size / 1);
            side1.transform.rotation = Quaternion.Euler(0, 0, 0);

            GameObject side2 = addSide(size, "6");
            side2.transform.SetParent(mainObj.transform);
            side2.transform.position = new Vector3(0, 0, size / 2);
            side2.transform.rotation = Quaternion.Euler(0, 180, 0);

            GameObject side3 = addSide(size, "3");
            side3.transform.SetParent(mainObj.transform);
            side3.transform.position = new Vector3(0, -size / 2, 0);
            side3.transform.rotation = Quaternion.Euler(90, 0, 0);

            GameObject side4 = addSide(size, "4");
            side4.transform.SetParent(mainObj.transform);
            side4.transform.position = new Vector3(0, size / 2, 0);
            side4.transform.rotation = Quaternion.Euler(90, 0, 0);

            GameObject side5 = addSide(size, "2");
            side5.transform.SetParent(mainObj.transform);
            side5.transform.position = new Vector3(-size / 2, 0, 0);
            side5.transform.rotation = Quaternion.Euler(0, 90, 0);

            GameObject side6 = addSide(size, "5");
            side6.transform.SetParent(mainObj.transform);
            side6.transform.position = new Vector3(size / 2, 0, 0);
            side6.transform.rotation = Quaternion.Euler(0, 270, 0);

            mainObj.transform.rotation = Quaternion.Euler(45, 45, 45);

            return mainObj;
        }
    }

   

    void Start()
    {
        scriptCube scriptcube = new scriptCube();
        GameObject cube = scriptCube.createCube("testeN", 10);
    }
    private GameObject target;
    void Update()
    {
        target = GameObject.Find("testeN");
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
    }

}






