using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject moveplatform;
    public float minYPosition = 117.8f; // Minimalna pozycja Y, na jak¹ mo¿e opaœæ platforma
    public float elevatorSpeed = 2.0f;   // Szybkoœæ poruszania siê windy
    private bool isPlayerOnElevator = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerOnElevator)
        {
            moveplatform.transform.position += moveplatform.transform.up * elevatorSpeed * Time.deltaTime;
        }
        else
        {
            // Dodaj kod tutaj, aby platforma wraca³a na dó³, ale z ograniczeniem minYPosition
            if (moveplatform.transform.position.y > minYPosition)
            {
                moveplatform.transform.position -= moveplatform.transform.up * elevatorSpeed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnElevator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnElevator = false;
        }
    }
}
