using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    private CharacterController playerController;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private GameObject PlayerObject;

    private float pushForce = 5f;
    public float reducedHeight = 0.8f;
    public float originalHeight = 1.8f;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        //originalHeight = playerController.height;
        playerRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(PerformSlide());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerController.height = originalHeight;
        }
    }

    IEnumerator PerformSlide()
    {
        GetComponent<Animator>().SetTrigger("Slide");
        playerController.height = reducedHeight;
        yield return new WaitForSeconds(1);
        playerController.height = originalHeight;
        
    }
}
