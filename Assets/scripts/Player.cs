using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public float Velocidade = 10f;
    private float Movimento;
    public float ForcaPulo = 50f;
    private Rigidbody2D rig;
    public bool TaVoando = true;
    public Rigidbody2D criar;

    private Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        //Selecionar rigidbody do objeto
        rig = GetComponent<Rigidbody2D>();
        //selecionar animator do objeto
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //faz valor do movimento
        Movimento = Input.GetAxis("Horizontal");

        //movimenta o personagem
        rig.velocity = new Vector2(Velocidade * Movimento, rig.velocity.y);

        //vira o sprite
        VirarSprite(Movimento);

        //pula
        Pulo();

        TaVoando= PéDoPlayer.Tavoando;

        if(!TaVoando)
        {
            animate.SetBool("Pulando", false);
        }

        if(Movimento!=0)
        {
            animate.SetBool("Correndo", true);
        }
        else
        {
            animate.SetBool("Correndo", false);
        }



        if(transform.position.y < -16)
        {
            transform.position = new Vector3(-9,5,0);
        }


        //cria objeto
        if(Input.GetButton("Fire1"))
        {
            //Rigidbody2D criarclone= (Rigidbody2D) Instantiate(criar, gameObject.transform.position, gameObject.transform.rotation);
        }


    }


    void Pulo()
    {
        if(Input.GetButton("Jump") && !TaVoando)
        {
           rig.velocity = new Vector2(rig.velocity.x, ForcaPulo);
            animate.SetBool("Pulando", true);
        }
    }

    void OnCollisionEnter2D(Collision2D colide)
    {
    
      if(colide.gameObject.tag == "Enemy")
      {
          Destroy(gameObject);
      }

    }
   
    void VirarSprite (float DirecaoMovimento)
    {
        if(DirecaoMovimento>0)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);

        }
        if(DirecaoMovimento<0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
            
        }
    }




}













//int  inteiro = 0, 1, 2, 3, 4, 5...  float = 0,1 0,2 0,3   bool = true ou false (verdadeiro ouu falso)