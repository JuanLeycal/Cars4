using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool activo = false;
    int uCount = 0;
    [SerializeField] float vDesapari;

    [SerializeField] Sprite carroLleno;
    [SerializeField] Sprite carroVacio;
    SpriteRenderer spriteRenderer;

    [SerializeField] AudioSource bum;
    [SerializeField] AudioSource sas;
    [SerializeField] AudioSource pkt;
    [SerializeField] AudioSource end;

    void bumSound(AudioSource audio)
    {
        audio.Play();
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    IEnumerator endGame()
    {
        
            Debug.Log("Juego terminado");
            bumSound(end);
            yield return new WaitForSeconds(7);
            Application.Quit();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bumSound(bum);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Paquetaso" && activo == false)
        {
            Debug.Log("Paquetaso :)");
            activo = true;
            spriteRenderer.sprite = carroLleno;
            bumSound(sas);
            Destroy(collision.gameObject, vDesapari);
        }
        else if (collision.tag == "Paquetaso" && activo == true)
        {
            Debug.Log("Ya tienes un paquetazo :(");
        }


        if (collision.tag == "Cliente" && activo == true)
        {
            uCount++;
            if (uCount != 4)
            {
                Debug.Log("Cliente :)");
                activo = false;
                bumSound(pkt);
                spriteRenderer.sprite = carroVacio;
                
            }
            

            if (uCount == 4)
            {
                spriteRenderer.sprite = carroVacio;
                StartCoroutine(endGame());
            }
        }
        else if (collision.tag == "Cliente" && activo == false)
        {
            Debug.Log("No tienes paquetazo para el cliente :(");
        }

    }

}
