using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    Vector3 handpos;
    public Image image;
    private void Awake()
    {
        handpos = Input.mousePosition;
        handpos.y = handpos.y - 25f;
        transform.position = handpos;
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        handpos = Input.mousePosition;
        handpos.y = handpos.y - 25f;
        transform.position = handpos;

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            image.enabled = true;
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            image.enabled = false;
        }
    }
}
