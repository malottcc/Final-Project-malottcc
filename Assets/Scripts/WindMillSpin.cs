using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillSpin : MonoBehaviour
{

    public float rotateSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
    }
}
