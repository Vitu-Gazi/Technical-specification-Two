using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLine : MonoBehaviour
{
    public delegate void ForDestroyLine();
    public event ForDestroyLine DestroyLine;

    LineRenderer line;

    public GameObject OtherObj;
    Vector3[] vec = new Vector3[2];

    void Start ()
    {
        line = GetComponent<LineRenderer>();
        OtherObj.GetComponent<ForLine>().DestroyLine += () =>
        {
                Destroy(OtherObj);
        };
    }

    private void Update()
    {
        vec[0] = transform.position;
        vec[1] = OtherObj.transform.position;
        if (OtherObj != null)
        {
            line.SetPosition(0, vec[0]);
            line.SetPosition(1, vec[1]);
        }
        else if (OtherObj == null)
        {
            DestroyLine();
        }
    }

    private void OnDestroy()
    {
        DestroyLine();
    }
}
