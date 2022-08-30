using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobUnit : MonoBehaviour
{
    private float dawdle = 5f;
    public GameObject player;
    private Vector3 playerOffset;

    private void Start()
    {
        playerOffset = new Vector3(player.transform.position.x + transform.position.x, player.transform.position.y + transform.position.y);
        dawdle = Random.Range(1f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        transform.position = player.transform.position + playerOffset + new Vector3(hori * dawdle * -1, verti * dawdle * -1) * Time.deltaTime;
    }
}
