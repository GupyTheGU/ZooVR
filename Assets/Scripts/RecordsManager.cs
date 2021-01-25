using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsManager : MonoBehaviour
{
	public static RecordsManager instance;
	public AudioSource ActiveRecording;
	public bool primera;
	public GameObject guia;


	// Start is called before the first frame update
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		primera = true;
	}

	public static AudioSource newGrabacion(AudioClip grabacion, float volume = 1f, float pitch = 1f)
    {
		AudioSource source = CreateNewAudioSource(string.Format("AUDIO [{0}]", grabacion.name));
		source.clip = grabacion;
		source.volume = volume;
		source.pitch = pitch;
		source.Play();
		return source;

	}
    public static AudioSource CreateNewAudioSource(string _name)
    {
        AudioSource nuevo = new GameObject(_name).AddComponent<AudioSource>();
		nuevo.transform.SetParent(instance.guia.transform);
		return nuevo;
    }

	public void PlayRecording(AudioClip grabacion, float volume = 1f, float pitch = 1f)
	{

		if (!primera) 
        {
			if (ActiveRecording.clip != grabacion)
            {
				Destroy(ActiveRecording.gameObject);
				ActiveRecording = newGrabacion(grabacion, volume, pitch);
				Debug.Log("Destruccion de " + ActiveRecording.gameObject);
            }
            else
            {
				Debug.Log("Mismo animal");
				
			}

        }
        else
        {
			ActiveRecording = newGrabacion(grabacion, volume, pitch);
			primera = false;
		}
		
	}
}
