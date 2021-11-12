# Práctica 4. Micrófono y cámara

----------
> Alejandro Peraza González
>
> Universidad de La Laguna
>
> 12 November 2021

## Interacción con la cámara

![Animation](https://user-images.githubusercontent.com/43573083/141443355-ee718fd6-448f-4b0d-9a5d-2ed1b4a2d37b.gif)

En la escena se dispone un cubo con el script [character_controller](scripts/character_controller.cs) que le permite moverse y un espejo con el script [CameraHandler](scripts/CameraHandler.cs).

El funcionamiento del movimiento del jugador está explicado en prácticas anteriores.

En cuanto al control de la cámara: 

```c#
using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour
{
    WebCamTexture webcamTexture;
    GameObject player;
    public float distanceThreshold = 5f;
    Texture initialTexture;
    
    void Awake()
    {
        initialTexture = GetComponent<Renderer>().material.mainTexture;
        player = GameObject.FindGameObjectWithTag("Player");
        webcamTexture = new WebCamTexture();
    }

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        float distance = Vector3.Distance(playerPos, transform.position);
        if (distance < distanceThreshold)
        {
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = webcamTexture;
            webcamTexture.Play();        
        } else 
        {
            webcamTexture.Stop();
            GetComponent<MeshRenderer>().material.mainTexture = initialTexture;
        }
    }
}
```

En el método `Awake` se recoge la textura inicial y se inicializan el jugador y la textura correspondiente a la cámara. 

En el método `Update` se calcula la distancia al jugador y si la distancia es menor al límite (puede ser cambiado por el usuario desde la GUI), se modifica la textura del objeto por la de la cámara y se reproduce usando `webcamTexture.Play()`. Cuando el jugador se aleja de nuevo, se detiene la cámara con `webcamTexture.Stop()` reestablece la textura inicial.
 
## Interacción con el micrófono

De nuevo en esta escena se tiene el jugador explicado en prácticas anteriores y una caja de música con la que podrá interactuar.

Por un lado se crea el script [JukeboxCollisionCreator](scripts/JukeboxCollisionCreator.cs)  para crear colisiones cuando el jugador entra en contacto con un objeto y se le asigna a la caja de música.

```c# 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeboxCollisionCreator : MonoBehaviour
{
    public delegate void jukebox();
    public static event jukebox jukeBoxCollision;

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            jukeBoxCollision();
        }
    }
}
```

En este script se utilizan un delegado y un evento el cual es lanzado en la colisión con el jugador. La suscripción a este evento se realiza en el script [MicrophoneHandler](scripts/MicrophoneHandler.cs).

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneHandler : MonoBehaviour
{
    AudioSource microphone;
    public float distanceThreshold = 5f;
    GameObject player;
    
    int collisionCount = 0;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        microphone = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        JukeboxCollisionCreator.jukeBoxCollision += audioRecorder;
    }


    void OnDisable()
    {
        JukeboxCollisionCreator.jukeBoxCollision -= audioRecorder;
    }

    // On the first collision, start recording, on the second collision, stop recording and on the third collision reproduce the recording
    void audioRecorder()
    {
        if (collisionCount == 0)
        {
            microphone.clip = Microphone.Start(null, true, 10, 44100);
        }
        else if (collisionCount == 1)
        {
            Microphone.End(null);
        }
        else if (collisionCount == 2)
        {
            microphone.loop = true;
            microphone.Play();
            collisionCount = -1;
        }
        collisionCount++;
    }
}
```

En el método `Awake` inicializamos el jugador y el micrófono y los métodos `OnEnable` y `OnDisable` se suscribe y desuscribe del evento mencionado respectivamente el método `audioRecorder`.

En `audioRecorder`, cuando se produce una primera colisión se comienza a grabar un clip de máximo 10 segundos mediante ` Microphone.Start(null, true, 10, 44100)`, en la siguiente colisión se para la grabación empleando `Microphone.End(null)`. Por último, en la siguiente colisión, se reproduce el clip grabado usando `microphone.Play()` que se puso previamente en bucle usando `microphone.loop = true;` y se reinicia el contador de colisiones para volver a comenzar.

