using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public GameObject EndingLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        EndingLayer.SetActive(true);
    }
}
