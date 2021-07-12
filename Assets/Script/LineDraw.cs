using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;

    public List<Vector3> fingerPositions;
    
    public List<GameObject> lineColor;


    void Update()
    {
        if( Controller.mode == "sline" || Controller.mode == "bline")
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 tempfingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, Controller.zdistance));
                UpdateLine(tempfingerPos);
            }
            if(Input.GetMouseButtonUp(0))
            {
                Controller.zdistance -= 0.005f;
            }
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);

        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.sortingOrder = 4;
        lineRenderer.startColor = Controller.selectedColor;
        lineRenderer.endColor = Controller.selectedColor;
        if(Controller.mode == "sline")
        {
            lineRenderer.startWidth = 0.01f;
            lineRenderer.endWidth = 0.01f;
        }

        if(Controller.mode == "bline")
        {
            lineRenderer.startWidth = 0.03f;
            lineRenderer.endWidth = 0.03f;
        }

        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f,0f, Controller.zdistance)));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, Controller.zdistance)));
        lineRenderer.SetPosition(0 , fingerPositions[0]);
        lineRenderer.SetPosition(1 , fingerPositions[1]);

    }

    void UpdateLine(Vector3 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
    }


    public void thinLine()
    {
        Controller.mode = "sline";
    }
    public void thickLine()
    {
        Controller.mode = "bline";
    }

    public void Resetline()
    {
        foreach(GameObject go in lineColor)
        {
            Destroy(go);
        }
        lineColor.Clear();
        Controller.zdistance = 0;
    }
}
