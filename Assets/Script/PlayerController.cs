using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float STEP = 5.0f;

    void Update()
    {
        //右向きに等速で進む
        this.transform.position += new Vector3(STEP * Time.deltaTime, 0, 0);
    }
}
