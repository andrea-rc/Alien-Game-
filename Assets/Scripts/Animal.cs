using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movinDer;
    [SerializeField] GameManager gm;
    [SerializeField] float vida;
    
    float minX, maxX;
    float lento = 0;
    public bool poder = true;
    public bool timer = false;
    int contador = 0;
    int duracion = 2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(movinDer)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        if(transform.position.x > maxX - 0.3f)
        {
            movinDer = false;
        }
        else if (transform.position.x < minX + 0.3f)
        {
            movinDer = true;
        }

        if (poder == true)
        {
            BulletTime();
        }
        else
        {
            Time.timeScale = 1;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject disparo = collision.gameObject;
        if (disparo.tag == "Bala")
        {
            if (timer == true)
            { vida = 1; }
            vida--; 
            if (vida == 0)
            {
                gm.ReducirNumEnemies();
                Destroy(this.gameObject);
            }
              }
    }
    void BulletTime()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.unscaledTime >= lento && timer == false)

        {

            timer = true;
            Time.timeScale = 0.5f;
            lento = Time.unscaledTime + duracion;
            contador = contador + 1;
            if (contador > 3)
            {
                poder = false;
            }
        }

        if (Time.unscaledTime >= lento && timer == true)
        {
            
            Time.timeScale = 1;
            timer = false;
        }
    }



}

