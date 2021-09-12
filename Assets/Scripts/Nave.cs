using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject bala2;
    [SerializeField] GameObject disparador;
    [SerializeField] float fireRate;


    float minX, maxY, minY, maxX;
    float nextFire = 0;
    float nextRafaga = 0;
    bool cambiarBala = true;
    public bool gamePaused = false;


    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSupDer.x - 0.6f;
        maxY = esquinaSupDer.y - 0.6f;
        minX = esquinaInfIzq.x + 0.6f;

        Vector2 puntox = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));
        minY = puntox.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            Movimiento();
      
            if (cambiarBala)
                Disparo();
            else
                DisparoRafaga();

            if (Input.GetKeyDown(KeyCode.Z))
                cambiarBala = cambiarBala ? false : true;
        }
    }


    void Movimiento()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, dirV * Time.deltaTime * speed);
        transform.Translate(movimiento);

        if (transform.position.x > maxX)
            transform.position = new Vector2(maxX, transform.position.y);

        if (transform.position.x < minX)
            transform.position = new Vector2(minX, transform.position.y);

        if (transform.position.y > maxY)
            transform.position = new Vector2(transform.position.x, maxY);

        if (transform.position.y < minY)
            transform.position = new Vector2(transform.position.x, minY);
    }

    void Disparo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(bala, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    void DisparoRafaga()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextRafaga)
        {
            Instantiate(bala2, transform.position, transform.rotation);
            nextRafaga = Time.time + (fireRate / 3);
        }
    }
    
}
   
   
    




