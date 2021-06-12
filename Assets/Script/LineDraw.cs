using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject currentLine;

    public LineRenderer lineRenderer;

    public List<Vector3> fingerPositions;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
           CreateLine();
        }

        if(Input.GetMouseButton(1))
        {
            Vector3 tempfingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 0.31f));
            UpdateLine(tempfingerPos);
            
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        fingerPositions.Clear();
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f,0f,0.31f)));
        fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, 0.31f)));
        lineRenderer.SetPosition(0 , fingerPositions[0]);
        lineRenderer.SetPosition(1 , fingerPositions[1]);

    }

    void UpdateLine(Vector3 newFingerPos)
    {
        fingerPositions.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
    }

}
