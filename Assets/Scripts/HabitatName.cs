using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabitatName : MonoBehaviour
{
    public GameObject Panel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player") {
            Panel.transform.Find("Nombre").gameObject.GetComponent<Text>().text = this.name;
            Panel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Panel.SetActive(false);
        }
    }
}
