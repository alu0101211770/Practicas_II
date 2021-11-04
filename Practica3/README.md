# Práctica 3. Delegados, eventos

----------
> Alejandro Peraza González
>
> Universidad de La Laguna
>
> 04 November 2021

## Cuando el jugador colisiona con un objeto de tipo B, el objeto A mostrará un texto en una UI de Unity.

![4 1](https://user-images.githubusercontent.com/43573083/140407514-58b33e8d-caf8-40aa-9220-abba59359c71.gif)

## Cuando toca el objeto A se incrementará la fuerza del objeto B
![4 2](https://user-images.githubusercontent.com/43573083/140407540-5986c2b3-5ee9-4da8-bf3c-d9b77dd73d24.gif)

## Cuando el jugador se aproxima a los cilindros de tipo A, los cilindros de tipo B cambian su color

Para cambiar los colores de los cilindros de manera que sea lineal, tomo el color inicial y mientras el jugador se mantiene cerca de un cilindro de tipo A, el color va siendo modificando con un valor aleatorio entre (0.9 y 1.1) pareciendo que el nuevo color al que se cambia es muy cercano al anterior.

![4 3](https://user-images.githubusercontent.com/43573083/140407561-f255bed5-1819-47ab-a528-b47708f743c5.gif)

## Cuando el jugador se aproxima a los cilindros de tipo A, las esferas se orientan hacia un objetivo ubicado en la escena

![4 4](https://user-images.githubusercontent.com/43573083/140407592-ffac7220-46d6-4903-8c7a-f73837eae475.gif)

## Se utiliza Debug.DrawRay

![4 5](https://user-images.githubusercontent.com/43573083/140407608-fd493e8f-1f26-4dad-b8eb-9c01bd2203b1.gif)
