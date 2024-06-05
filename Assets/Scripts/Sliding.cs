using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 SlidePosition;
    private bool Slide = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsSliding();
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void IsSliding()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Slide == true)
            {
                Slide = false;
                anim.SetBool("Slide", false);
            }

            else
            {
                Slide = true;
                anim.SetBool("Slide", true);
            }
        }
    }

    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
