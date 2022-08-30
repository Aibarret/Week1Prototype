using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            // Start tweening
        }

        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        transform.position += new Vector3(hori * speed, verti * speed, 0) * Time.deltaTime;
    }
}
