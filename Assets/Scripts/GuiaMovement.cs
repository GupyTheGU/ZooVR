using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiaMovement : MonoBehaviour
{
    public List<GameObject> Hab;
    public List<GameObject> Animal;
    public List<Vector3> ruta;
    private int contador=0;
    private Vector3 objetivo;
    private Vector3 guiaPosicion;
    public bool ruteo = true;

    public static GuiaMovement sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }
    void Start()
    {
        planearRuta();
        guiaPosicion = this.transform.position;
        guiaPosicion.y = 0;
        objetivo = ruta[contador];
    }
    private void planearRuta()
    {
        foreach (GameObject habitat in Hab)
        {
            ruta.Add(new Vector3(habitat.transform.Find("Point").GetComponent<Transform>().position.x,
                0, habitat.transform.Find("Point").GetComponent<Transform>().position.z));
        }
    }
    public void recorrerRuta()
    {
            Vector3 dif = new Vector3();
            dif = guiaPosicion - ruta[contador];
            this.GetComponent<Rigidbody>().AddForce(-dif * 5);
            if (contador>=2)
            {
                ruteo = false;
            }
            else
            {
                contador++;
            }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Point")
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            guiaPosicion = this.GetComponent<Transform>().position;
            guiaPosicion.y = 0;
            if (ruteo)
            {
                objetivo = ruta[contador];
            }
        }
    }

    public bool inicio = true;
    public bool iniciodos = false;

    public void Accion()
    {
        if (!ruteo)
        {
            //Sacar Audios de final
            Debug.Log("SIAKABO");
            playRecording("Finla");
        }
        else if (inicio)
        {
            //Sacar Audio F
            Debug.Log("TUTO");
            inicio = false;
            iniciodos = true;
            playRecording("Inico_0");
        }
        else if (iniciodos)
        {
            iniciodos = false;
            playRecording("Inicio_1");
        }
        else
        {
            recorrerRuta();
        }
    }

    public void playRecording(string audioName, float volume = 1f, float pitch = 1f)
    {
        AudioClip song = Resources.Load<AudioClip>(string.Format("Audio/{0}", audioName));

        RecordsManager.instance.PlayRecording(song, volume, pitch);
    }
}
