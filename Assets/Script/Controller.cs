﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject LookPos;
    public GameObject Character;
    public GameObject ObjectTatoo;
    public GameObject camera;
    public GameObject TattoColor;
    public GameObject CameraLastPos;
    public GameObject Tatto;
    public Material materialLine;
    public GameObject Fill;
    public GameObject Line;
    public GameObject FillPrefab;
    public GameObject TattoMachine;
    public GameObject MainUi;

    public static Color selectedColor = Color.black;
    public static string mode;
    float zdistance;
    void Start()
    {
        mode = "fill";
        zdistance = 1.45f;
        StartCoroutine(LookatPos());   
    }
    
    IEnumerator LookatPos()
    {
        yield return new WaitForSeconds(0.5f);
        LeanTween.rotate(Character, new Vector3(0, 180f, 0), 0.5f);
        yield return new WaitForSeconds(3f);
        LeanTween.move(camera,CameraLastPos.transform.position, 0.5f);
        yield return new WaitForSeconds(0.4f);
        Character.SetActive(false);
        // ObjectTatoo.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Tatto.SetActive(true);
        TattoMachine.SetActive(true);
        MainUi.SetActive(true);
    }


    private void Update()
    {
        if(mode == "fill")
        {
            if (Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
            {
                CreateFill();
            }

            if (Input.GetMouseButton(0) && !IsPointerOverUIObject())
            {

                Fill.transform.localScale = Fill.transform.localScale * 1.05f;
            }
        }

        TattoMachine.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(20f, 20f, 1.4f));
    }

    public void ChangeColor(Image spriteColor)
    {

        selectedColor = spriteColor.color;
    }


    void CreateFill()
    {
        Fill = Instantiate(FillPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, zdistance)), Quaternion.identity);
        Fill.GetComponent<SpriteRenderer>().color = selectedColor;
        zdistance -= 0.01f;
    }



    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void FillMode()
    {
        mode = "fill";

    }

}
