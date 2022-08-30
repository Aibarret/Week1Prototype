using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public List<GameObject> mob;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            int count = 0;
            while (count < mob.Count)
            {
                mob[count].GetComponent<MobUnit>().makeFormation(0);
                count++;
            }
        }

        if (Input.GetKey(KeyCode.X))
        {
            int count = 0;
            while (count < mob.Count)
            {
                mob[count].GetComponent<MobUnit>().makeFormation(1);
                count++;
            }
        }

        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        transform.position += new Vector3(hori * speed, verti * speed, 0) * Time.deltaTime;
    }
}
