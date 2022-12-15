using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooMovement : MonoBehaviour
{

    [SerializeField]private Transform player;
    private Rigidbody2D rig;
    public float speed= 3;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y>player.transform.position.y)
        {
            rig.velocity = new Vector2(rig.velocity.x,-speed);
        }
        else if(gameObject.transform.position.y<player.transform.position.y)
        {
            rig.velocity = new Vector2(rig.velocity.x,speed);
        }
        else
        {
            rig.velocity = new Vector2(rig.velocity.x,0);
        }
        if(gameObject.transform.position.x>player.transform.position.x)
        {
            gameObject.transform.localScale =new Vector3(1,1,1);
            rig.velocity = new Vector2(-speed,rig.velocity.y);
        }
        else if(gameObject.transform.position.x<player.transform.position.x)
        {
            gameObject.transform.localScale =new Vector3(-1,1,1);
            rig.velocity = new Vector2(speed,rig.velocity.y);
        }
        else 
        {
            rig.velocity = new Vector2(0,rig.velocity.y);
        }
    }
}
