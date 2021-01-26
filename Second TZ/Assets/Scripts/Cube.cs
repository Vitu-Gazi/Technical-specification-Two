using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    Rigidbody rb;

    bool doubleClick, doubleClickTwo;

    LineRenderer line;
    [SerializeField]
    Vector3[] vec = new Vector3[100];

    [SerializeField]
    GameObject[] objs = new GameObject[100];

    public static bool FirstCube;
    public static GameObject FirstCubeObj;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vec[0] = gameObject.transform.position;
        objs[0] = gameObject;
        rb.velocity = Vector3.zero;
        if (doubleClick)
        {
            StartCoroutine(DoubleClick());
        }
        if (Input.GetMouseButtonDown(1) && enter)
        {
            if (FirstCube && FirstCubeObj != gameObject)
            {
                CreateObj(gameObject, FirstCubeObj);
                line = GetComponent<LineRenderer>();
                FirstCube = false;
                FirstCubeObj = null;
            }
            else if (!FirstCube)
            {
                FirstCube = true;
                FirstCubeObj = gameObject;
            }
            else if (FirstCube && FirstCubeObj == gameObject)
            {
                FirstCube = false;
                FirstCubeObj = null;
            }

        }
    }

    bool enter;
    private void OnMouseEnter()
    {
        enter = true;
    }
    private void OnMouseExit()
    {
        enter = false;
    }



    private void OnMouseDown()
    {
        if (!doubleClick)
        {
            doubleClick = true;
        }
        else if (doubleClick && doubleClickTwo)
        {
            ForLine[] l = GetComponentsInChildren<ForLine>();
            foreach (ForLine o in l)
            {
                Destroy(o.OtherObj);
            }
            Destroy(gameObject);
        }
    }
    private void OnMouseDrag()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }

    GameObject CreateObj (GameObject thatObj, GameObject otherObj)
    {
        int i = 0;
        foreach (Vector3 v in vec)
        {
            if (v == Vector3.zero || v == null)
            {
                GameObject t = Instantiate(obj, thatObj.GetComponentInChildren<Transform>().transform.position, new Quaternion());
                t.transform.parent = transform;
                objs[i] = t;
                GameObject w = Instantiate(obj, otherObj.GetComponentInChildren<Transform>().transform.position, new Quaternion());
                objs[i] = t;
                w.transform.parent = otherObj.transform;
                t.GetComponent<ForLine>().OtherObj = w;
                return w.GetComponent<ForLine>().OtherObj = t;
            }
            i++;
        }
        GameObject e = new GameObject();
        return e;
    }





    IEnumerator DoubleClick ()
    {
        doubleClickTwo = true;
        yield return new WaitForSeconds(0.5f);
        doubleClickTwo = false;
        doubleClick = false;
    }
}
