using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject[] Cubes;


    System.Random r = new System.Random();

    private void OnMouseDown()
    {
        GameObject obj = Instantiate(Cubes[r.Next(Cubes.Length)], new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), new Quaternion());
    }
}
