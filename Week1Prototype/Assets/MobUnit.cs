using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobUnit : MonoBehaviour
{
    public GameObject player;
    public List<Vector3> formation;
    public Vector3 formPosn;
    public List<Vector3> formationPosnList;
    public Rigidbody2D rigid;

    public float dawdle = 5f;
    private Vector3 playerOffset;
    
    private bool formationSwitch = false;
    private bool throwing = false;
    private Vector3 targetPosn;

    public float lerpDuration = .6f;
    private float elapsedFrames = 0;
    

    private void Start()
    {
        print("running start");
        playerOffset = new Vector3(player.transform.position.x + transform.position.x, player.transform.position.y + transform.position.y);
        dawdle = Random.Range(2.5f, 8f);//Mathf.Floor();
       

        formation[0] = playerOffset;
        formation[1] = formationPosnList[0] + player.transform.position;
        formation[2] = formationPosnList[1] + player.transform.position;
        print("Player Offset: " + playerOffset);
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        if (elapsedFrames < lerpDuration && formationSwitch)
        {
            rigid.MovePosition(Vector3.Lerp(transform.position, player.transform.position + playerOffset, elapsedFrames / lerpDuration));
            elapsedFrames += Time.deltaTime;
            
            if (elapsedFrames >= lerpDuration)
            {
                print("formation switch should end here");
                formationSwitch = false;
            }
        }
        else if (elapsedFrames < lerpDuration && throwing){
            
            rigid.MovePosition(Vector3.Lerp(transform.position, targetPosn + playerOffset, elapsedFrames / lerpDuration));
            elapsedFrames += Time.deltaTime;

            if (elapsedFrames >= lerpDuration)
            {
                print("throw should end here");
                
            }
        }
        else
        {
            rigid.MovePosition(player.transform.position + playerOffset + (new Vector3(hori * dawdle * -1, verti * dawdle * -1)) * Time.deltaTime);
        }
        
    }

    // PUBLIC FUNCTIONS ==============================================================================================================================

    public void makeFormation(int form)
    {
        playerOffset = formation[form];
        formationSwitch = true;
        elapsedFrames = 0;
    }

    public void throwMob(Vector3 posn)
    {
        print("MOUSE POSN AT: " + posn);
        print("MOB MOVING TOWARDS: " + (targetPosn + playerOffset));
        targetPosn = posn;
        throwing = true;
        elapsedFrames = 0;
    }
}
