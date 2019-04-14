using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(speed* Time.deltaTime, speed* Time.deltaTime, speed* Time.deltaTime);
        }
}
