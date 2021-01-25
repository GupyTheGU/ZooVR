using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bioma : MonoBehaviour
{
    public string grabacion;
    public string nombre;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playRecording(string audioName, float volume = 1f, float pitch = 1f)
    {
        AudioClip song = Resources.Load<AudioClip>(string.Format("Audio/{0}", audioName));

        RecordsManager.instance.PlayRecording(song, volume, pitch);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("esta colisionando");
        if (other.gameObject.tag == "Guia")
        {
            playRecording(grabacion);

        }
    }
}
