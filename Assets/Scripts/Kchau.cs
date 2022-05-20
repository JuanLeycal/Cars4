using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kchau : MonoBehaviour

{
    [SerializeField] float steerSpeed;
    [SerializeField] float speed;
    [SerializeField] float reverseSpeed;

    [SerializeField] float vBoost;

    [SerializeField] AudioSource fiaun;

    void bumSound(AudioSource audio)
    {
        audio.Play();
    }


    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float reverseAmount = Input.GetAxis("Vertical") * reverseSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);

        if(Input.GetAxis("Vertical") * speed < 0)
        {
            transform.Translate(0, reverseAmount, 0);
        }
        if (Input.GetAxis("Vertical") * speed > 0)
        {
            transform.Translate(0, speedAmount, 0);
        }
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Boost")
        {
            speed =  speed + vBoost;         
            Debug.Log("Boost");
            bumSound(fiaun);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            speed = speed - vBoost;
            
        }
    }
}
