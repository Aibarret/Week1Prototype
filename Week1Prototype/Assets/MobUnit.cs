using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobUnit : MonoBehaviour
{
    public GameObject player;
    public List<Vector3> formation;
    public Vector3 formPosn;
    public List<Vector3> formationPosnList;

    private float dawdle = 5f;
    private Vector3 playerOffset;
    

    private void Start()
    {
        print("running start");
        playerOffset = new Vector3(player.transform.position.x + transform.position.x, player.transform.position.y + transform.position.y);
        dawdle = Random.Range(2f, 8f);

        formation[0] = playerOffset;
        formation[1] = formationPosnList[0] + player.transform.position;
        formation[2] = formationPosnList[1] + player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        transform.position = player.transform.position + playerOffset + new Vector3(hori * dawdle * -1, verti * dawdle * -1) * Time.deltaTime;
    }

    public void makeFormation(int form)
    {
        print("doot");
        playerOffset = formation[form];
    }
}
