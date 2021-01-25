using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject hablarUI;
    public GameObject moverUI;
    private bool hablar = false;
    public bool isTalking = false;
    public static PlayerController sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }
    void Update()
    {
        if (hablar&&!isTalking)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                Debug.Log("Habla");
                GuiaMovement.sharedInstance.Accion();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name== "GuiaBox")
        {
            hablarUI.SetActive(true);
            hablar = true;
        }
        if (other.gameObject.name == "Start")
        {
            moverUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GuiaBox")
        {
            hablarUI.SetActive(false);
            hablar = false;
        }
        if (other.gameObject.name == "Start")
        {
            moverUI.SetActive(false);
        }
    }
}
