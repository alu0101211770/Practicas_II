# Práctica 2. Introducción a los scripts en Unity

----------
> Alejandro Peraza González
>
> Universidad de La Laguna
>
> 22 October 2021

## Ejercicio 1.

a. Ninguno de los objetos será físico.

Cuando un objeto no es físico, no se ve afectado por el bucle de físicas manteniéndose flotando en el aire.

b. La esfera tiene físicas el cubo no.

Para añadir físicas, se añade el componente RigidBody. Al hacerlo, la esfera cae hasta colisionar con el plano mientras que el cubo se mantiene en el aire.

c. La esfera y el cubo tienen físicas.

Ambos caen hasta el plano. Si se coloca uno sobre otro, se chocan, no atraviesan.

d. La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo.

La masa de la esfera cambia y, por ejemplo, rebota más al caer sobre el cubo.

e. La esfera tiene físicas y el cubo es de tipo IsTrigger.

Cuando se habilita IsTrigger, el collider es utilizado para activar eventos, pero no se toma cuenta en el bucle de físicas de unity. Al activarlo, la esfera atraviesa el cubo.

f. La esfera tiene físicas y el cubo es de tipo IsTrigger y tiene físicas.

Ahora el cubo cae en el eje y, pero atraviesa el plano.

g. La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo, se impide la rotación del cubo sobre el plano XZ.

Cuando el cubo cae sobre el borde de la esfera, en lugar de girar naturalmente, la esfera es desplazada y el cubo simplemente sigue bajando en el eje y.

## Ejercicio 2

Para controlar el movimiento de un objeto, he usado inicialmente los métodos `Translate` y `Rotate` de transform, pero se me ha hecho saber que este tipo de cosas se debe realizar dentro del bucle físico, por lo tanto he tenido que acceder a los métodos de rigidBody `MovePosition` y `MoveRotation`.

Para [MovePosition](https://docs.unity3d.com/ScriptReference/Rigidbody.MovePosition.html), he seguido la documentación de unity pero para lograr que se acceda al sistema de coordenadas local, he hecho uso del método `TransformDirection` de transform, consiguiendo el funcionamiento que deseaba.

Por otro lado, para [MoveRotation](https://docs.unity3d.com/ScriptReference/Rigidbody.MoveRotation.html) he realizado lo que se indica en la documentación creando un Quaternion para la rotación.

```c#
void FixedUpdate() {
    float translation = Input.GetAxis(verticalAxis) * speed;
    float rotation = Input.GetAxis(horizontalAxis) * rotationSpeed;

    Vector3 deltaPosition = transform.TransformDirection(translation * Vector3.forward * Time.fixedDeltaTime);
    Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotation * Time.fixedDeltaTime);     

    rigidBody.MovePosition(transform.position + deltaPosition);

    rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
}
```

## Ejercicio 3

### Ejercicio 3.1

Para este ejercicio, he separado el comportamiento en dos, desarrollando un script para que los cilindros aumenten al colisionar con el jugador y para que se aumente la puntuación. He probado a colocar la puntuación en un canvas como texto, pero no he logrado que se mantenga en la posición que quería, tal vez se deba a la versión de unity que he utilizado.

Ya que no se requiere del bucle de físicas, he desarrollado el código necesario en métodos Update.

![3 1](https://user-images.githubusercontent.com/43573083/139315846-2b4c2470-5bfc-4b5e-8934-e71f23021388.gif)

### Ejercicio 3.2

Para este apartado he desarrollado un nuevo script en el que se le añade a los cilindros que, cuando se pulsa espacio, si el jugador está a una mínima distancia, este ejerce una fuerza de repulsión proporcional a la distancia respecto al cilindro.

![3 2](https://user-images.githubusercontent.com/43573083/139315860-779aed5f-01cb-42ca-bfb5-e1b218e65e7c.gif)

### Ejercicio 3.3

Ya que lo que realicé en el apartado anterior variaba con la distancia, el código que utilicé es el mismo pero sin la condición de presionar espacio.

![3 3](https://user-images.githubusercontent.com/43573083/139315877-e7fa91ca-2f1c-435b-a1b1-bcdb71dbe41a.gif)

### Ejercicio 3.4

Para este apartado creé dos nuevos ejes virtuales y utilicé el mismo script que tenía para mi jugador, simplemente cambié los parámetros del script para indicar los nuevos ejes virtuales.

![image](https://user-images.githubusercontent.com/43573083/139317885-1c81fb04-eabc-48fe-be01-8c14329478d0.png)

![image](https://user-images.githubusercontent.com/43573083/139318003-6df04196-257d-4886-bf87-0b59cc134269.png)

![3 4](https://user-images.githubusercontent.com/43573083/139315887-b2e0b3fd-de3d-47fe-81c0-d306cdbb85d6.gif)

### Ejercicio 3.5

Para este último apartado, implementé lo siguiente:

```c#
void Update() {
    float sphere_distance = distance_threshold_spheres;
    if (spheres != null && spheres.Length != 0) {
        foreach (GameObject sphere in spheres) {
            float current_distance = Vector3.Distance(sphere.transform.position, transform.position);
            if (current_distance <= distance_threshold_spheres)
                sphere_distance = Mathf.Min(sphere_distance, current_distance);
        }
    }
    float player_distance = Mathf.Min(Vector3.Distance(player.transform.position, transform.position), distance_threshold_player);
    sphere_distance /= distance_threshold_spheres;
    player_distance /= distance_threshold_player;
    float difference = Mathf.Abs(sphere_distance - player_distance);
    if (sphere_distance < player_distance) {
        transform.localScale = (1 - difference) * scale;
    } else {
        transform.localScale = (1 + difference) * scale;
    }
}
```


Inicialmente obtengo la esfera más cercana si es que hay alguna lo suficientemente cerca, luego el mínimo entre la distancia al jugador y el umbral. Pongo estas dos distancias en valores entre 0 y 1 (ya que sé que van a ser menores que los umbrales correspondientes) y calculo el valor absoluto de la diferencia, lo que representa por así decirlo la fuerza que se aplicaría en valor absoluto. Si la distancia de la esfera hasta el cubo es menor que la del jugador, entonces el cubo se hará más grande y más pequeño en caso contrario.

![3 5](https://user-images.githubusercontent.com/43573083/139319718-e0970cae-8ab0-4b82-924a-f12e3a4347dd.gif)
