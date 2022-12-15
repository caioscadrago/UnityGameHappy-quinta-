using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player: MonoBehaviour
{
    public float Velocidade = 10f;
    private float Movimento;
    public float ForcaPulo = 50f;
    private Rigidbody2D rig;
    public bool TaVoando = true;
    private Animator animate;
    public Transform Respawn;
    public float AltMin =-16;
    public static int vida = 3;
    public static int coin = 0;

    [SerializeField] private AudioSource Jump;
    [SerializeField] private AudioSource Death;
    [SerializeField] private AudioSource Coinsfx;
    [SerializeField] private AudioSource Checkpoint;

    //variáveis para corrigir a moeda
    public bool coinfix = true;
    public int cointimer = 5;

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
        if(vida <0)
        {
            SceneManager.LoadScene("game over");
        }
        //faz valor do movimento
        Movimento = Input.GetAxis("Horizontal");

        //movimenta o personagem
        rig.velocity = new Vector2(Velocidade * Movimento, rig.velocity.y);

        //vira o sprite
        VirarSprite(Movimento);

        //pula
        Pulo();
        GoToMenu();


        if (this.animate.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            Debug.Log("idle encontrado");
        }
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



        if(transform.position.y < AltMin)
        {
            transform.position = Respawn.transform.position;
            Death.Play();
            vida -=1;
        }


        if(!coinfix)
        {
            cointimer-=1; //é a mesma coisa que cointimer = cointimer-1
            if (cointimer<=0)
            {
                coinfix=true;
            }
        }

    }


    void Pulo()
    {
        if(Input.GetButton("Jump") && !TaVoando)
        {
           rig.velocity = new Vector2(rig.velocity.x, ForcaPulo);
            animate.SetBool("Pulando", true);
            Jump.Play();
        }
    }

    void GoToMenu()
    {
        if(Input.GetButton("Cancel"))
        {
            vida =3;
            SceneManager.LoadScene("Menu");
            //código para mandar mensagem no console
            Debug.Log("bom dia");
            
        }
    }
    void OnCollisionEnter2D(Collision2D colide)
    {
    
      if(colide.gameObject.tag == "Enemy")
      {
         transform.position = Respawn.transform.position;
         Death.Play();
         vida-=1;
      }
      if(colide.gameObject.tag=="Next Level")
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
      }

    }
    private void OnTriggerEnter2D(Collider2D colide) 
    {
          if(colide.gameObject.tag=="coin"&&coinfix)
      {
        Destroy(colide.gameObject);
        coin +=1;
        Coinsfx.Play();
        coinfix = false;
        cointimer = 5;
      }
      if(colide.gameObject.tag=="Respawn")
      {
        Respawn.position=colide.transform.position;
        Checkpoint.Play();
        colide.gameObject.tag = "Untagged";
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