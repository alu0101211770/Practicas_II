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

