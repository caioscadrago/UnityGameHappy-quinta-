using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PéDoPlayer : MonoBehaviour
{



 public static bool Tavoando = true;
    // Start is called before the first frame update
        
    void OnTriggerEnter2D(Collider2D colide)
    {
       if(colide.gameObject.tag == "Chao")
       {
           Tavoando = false;
       } 
      
    }
    void OnTriggerExit2D(Collider2D colide)
    {
       if(colide.gameObject.tag == "Chao")
       {
           Tavoando = true;
           
       } 
    }
    

}

