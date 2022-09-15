using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public List<GameObject> mob;

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        //Default Formation
        if (Input.GetKey(KeyCode.Z))
        {
            int count = 0;
            while (count < mob.Count)
            {
                mob[count].GetComponent<MobUnit>().makeFormation(0);
                count++;
            }
        }
        //Hand Formation
        if (Input.GetKey(KeyCode.X))
        {
            int count = 0;
            while (count < mob.Count)
            {
                mob[count].GetComponent<MobUnit>().makeFormation(1);
                count++;
            }
        }
        //Lance Formation
        if (Input.GetKey(KeyCode.C))
        {
            int count = 0;
            while (count < mob.Count)
            {
                mob[count].GetComponent<MobUnit>().makeFormation(2);
                count++;
            }
        }

        if (Input.GetMouseButtonDown(0)){
            
            int count = 0;
            while (count < mob.Count)
            {
                mob[count].GetComponent<MobUnit>().throwMob(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                count++;
            }
        }

        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        transform.position += new Vector3(hori * speed, verti * speed, 0) * Time.deltaTime;
    }

    
}
