using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;//largura da nossa imagem

    private float StartPos;//posição inicial da imagem

    private Transform cam;//pegar a posição da camera


    public float ParallaxEffect;//o valor do parallax

    // Start is called before the first frame update
    void Start()
    {
        StartPos=transform.position.x;
        cam=Camera.main.transform;
        length=GetComponent<SpriteRenderer>().bounds.size.x;//define o length a partir do tamanho da imagem do sprite renderer
    }

    // Update is called once per frame
    void Update()
    {
        float RePos=cam.transform.position.x*(1-ParallaxEffect);
        float Distance = cam.transform.position.x*ParallaxEffect;
        transform.position=new Vector3(StartPos+Distance,transform.position.y,transform.position.z);

        if(RePos>StartPos+length)
        {
            StartPos+=length;
        }
        else if (RePos<StartPos-length)
        {
            StartPos-=length;
        }
    }
}
