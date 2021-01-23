# **Spaceship VR Game**

**Asignatura**: Interfaces Inteligentes

**Autores**:

* Aaron José Cabrera Martín
* Cristo Daniel Navarro Rodgríguez
* Daniel González Expósito
* Luciana Varela Díaz


## **Cuestiones importantes para el uso**

Jugar a este juego, o interactuar con el, es bastante sencillo. La forma de interactuar con los diversos objetos del juego es a través de la vista.
Disponemos de un puntero de color verde que se encuentra en medio de la pantalla y con él pulsaremos los distintos botones o realizaremos las tareas de los juegos.

El juego está dividido en diversas escenas. Una escena principial que nos sirve de hub para conectar con las otras y otras 4 escenas cada una conteniendo una prueba o minijuego a superar. Al pasar de una sala a otra se hará un "fade in" para entrar y un "fade out" para salir de una ventana negra. De esta manera conseguimos que la transición sea amigable pues los usuarios van a tener una pantalla pegada a sus ojos. 

Vamos a comentar cada uno de estos minijuegos. Muchos de ellos tienen las instrucciones justo detrás, en un panel.

### Simon

Si mira alrededor verá las instrucciones de este minijuego.

El objetivo de este juego es jugar al "simon dice". En frente suyo encontrará cuatro paneles de colores, un cartel en el que indica el nivel actual en el que se encuentra, así como dos paneles, uno para ver su puntuación y otro para salir de la sala. Además, a su derecha se encuentra un botón de Start. Cuando presionemos el botón de start el juego comienza. 
Comenzarán a sonar e iluminarse una secuencia de teclas. El objetivo es, una vez el patrón de sonidos ha terminado, repetirlo. Si fallamos volveremos a nivel 1 escuchando un sonido de decepción, si conseguimos repatir el patrón escucharemos unos aplausos y pasaremos al siguiente nivel. Por cada nivel extra la secuencia aumentará su longitud en uno, hasta llegar al nivel cinco. Cuando finalicemos el nivel cinco volvermeos a la sala principal y las luces de la puerta de este juego cambiarán de color.

### Lines & Spheres

Esta sala está compuesta por dos minijuegos que habrá que pasarse para completar la sala. Justo en el frente de la sala encontrará las instrucciones. 

En el minijuego de la izquierda deberá hacer que todas las **lineas** hagan "match", es decir que estén alineadas en la fila de en medio (ya que hay dos lineas tanto a la izquierda como a la derecha del todo que están fijas y no se pueden mover). Solo podremos hacer un movimiento a la vez al pasar la vista por encima de uno de los paneles. Una vez completado no podremos mover más el puzzle y veremos que cada línea bien colocada se ha ido poniendo de color blanco. Una vez completemos este puzzle escucharemos aplausos (si hemos completado los dos saldremos de la habitación habiéndola completado).

En la derecha tenemos el minijuego de las **esferas**, el objetivo de este minijuego es que los colores de las esferas inferiores sean iguales que los colores de las esferas superiores. Hay un truco para hacer este puzzle fácilmente, pero la gracia del mismo es descubrirlo. (No continue leyendo este párrafo al menos que esté atascado en el minijuego).
>! La pista para el minijuego consiste en que hay una esfera que cambia el color de todas. Otra esfera que cambia solo 3. Otra esfera que, de las anteriores 3, cambia solo 2. Y una última esfera que solo cambia el color de si misma. La cuestión es primero tocar la que cambia todas hasta ajustar el color de la misma, posteriormente ajustar el color de la que cambia 3, luego de la que cambia 2, y finalmente de la que se cambia solamente a ella misma.

### Math Puzzle

En esta escena podemos encontrar un minijuego matemático sencillo. Al entrar, detrás de usted puede ver las instrucciones del juego, además podrá observar justo delante de usted un PC con un texto que dice "Start", si mira hacia ese texto, éste desaparecerá, se activará la música y comenzará el minijuego. Para completar el minijuego debe resolver la ecuación de una sola incógnita que aparece a su izquierda. Una vez haya calculado el valor de la variable incógnita debe escribir la solución usando los cubos de la derecha. Estos cubos pueden activarse y desactivarse representando bits. 

>!Como indica en las pistas "debes escribir el resultado de manera que los ordenadores lo puedan entender", es decir debe escribir la solución en base binaria. 

Una vez escrita la solución, si lo ha hecho correctamente escuchará unos aplausos, la música se detendrá y volverá a la habitación principal. La puntuación obtenida dependerá de cuantos movimientos haya usado para escribir la solución en binario, si utiliza los movimientos mínimos para escribirlo obtendrá la máxima puntuación, 99.

### Shoot Practice

En este minijuego disponemos de las instrucciones en la parte trasera de la sala. Para comenzarlo debemos activar el botón de start situado por la parte superior de la sala. Una vez hecho comenzará a sonar una música e irán apareciendo enemigos por toda la habitación a los que debemos disparar para conseguir puntos. Para dispararlos simplemente debemos pasar la mirada por encima (punto verde en mitad de la pantalla). Se han incluido varios recursos visuales y sonoros (música, pistola, sonido de disparo, etc) para que este minijuego sea satisfactorio. Una vez conseguido los 18 puntos se hará un fadeout de la música y abandonaremos la sala correctamene habiéndola completado.

### Final

Una vez nos hayamos pasados todos los minijuegos, aparecerán fuegos artificiales que podremos ver a través de las ventanas y sonará una música de victoria. ¡Felicidades por superar el juego!

## **Hitos de programación logrados relacionándolos con los contenidos que se han impartido**

Primero nos gustaría destacar nuestra **programación usando difernetes escenas**. Para ello hemos hecho uso del diseño de **"Game Controller"** que vimos en clase. 

En nuestro caso lo hemos llamado **SceneManagerScript**, este script hace uso exclusivo de funciones estáticas, pero como debe estar asociado un gameObject hemos hecho lo que se vió en clase y le hemos activado ``DontDestroyOnLoad(this);` Además de comprar si existe o no previamente una instancia de SceneManagerScript. Todo esto se puede ver en la función start del script y con ello conseguimos que el SceneManagerScript esté presente en todas las escenas de nuestro juego, además de que siempre exista una única instancia de SceneManagerScript. Este script gestiona toda la lógica de cambiar de una escena a otra de manera suave (Fade in & Fade out) Así como, en la escena main o el hub, cambiar las luces de cada minijuego dependiendo de si se han completado o no.

Además disponemos de **GameInfo**, (cuyo comportamiento es similar a SceneManagerScript, solo hay una instancia y existe en todas las escenas). Este script mantiene el score de los minijuegos así como si han sido completados o no. Además en cada escena de un minijuego existe una consola "output" que muestra el score de cada minijuego. Este script se encarga de actualizar y mostrar el score del minijuego en estas consolas.


Por otro lado, disponemos de una clara programación orientada a eventos, sobretodo con los eventos de VR, practicamente la totalidad de la interacción del usuario con el juego se basa en eventos cuando pasa la mirada por encima de los GameObjects.


Por último hemos usado **el patrón delegate** Concretamente lo hemos utilizado para disparar un evento cuando todos los minijuegos han sido completados. Cuando se lanza este evento empiezan a lanzarse fuegos artificiales y una música de victoria empieza a sonar.

## **Aspectos que destacarías en la aplicación. Especificar si se han incluido sensores de los que se han trabajado en interfaces multimodales.**

Sin duda lo que más destacaría es la facilidad de uso. La transición suave entre escenas, el uso del sonido y como se apaga de manera suave al cambiar de escena.

Creemos que los juegos son sencillos, agradables y entretenidos. Creemos que es una aplicación ideal para probar cuando tenemos las cardboard

Respecto a los sensores, obviamente el VR hace uso del giroscopio y del acelerómetro, así que descartamos estos sensores pues no aportaban mucho a nuestros juegos. El GPS no le hemos visto gran utilidad. Nos planteamos el uso de la voz para interactuar con algún videojuego pero no creemos que sea lo suficientemente robusto y fiable. Mucha gente no le gusta hablar mientras juega y menos con un dipositivo móvil en público, además de que deberíamos depender de software no intregado completamente en unity. La cámara la descartamos finalmente pues aumentaría el consumo de batería y de recursos del dispositivo móvil sin ganar verdaderemente mucho. Pues nuestro juego se puede jugar estando completamente estático, es más no hace falta realmente ni estar de pie.

Finalmente hemos optado por **usar el compás**. El motivo para usarlo es que en el lobby uno se puede perder, y no recordar hacia donde está mirando, pues entramos y salimos bastante de esta sala y no tiene ninguan dirección privilegiada para orientarnos. Por lo que hemos optado por añadir un compás a la interfaz del lobby, de esta manera el usuario se podrá orientar para ir a una sala u otra además de saber hacia que lado está mirando en el mundo real.


## **Gif animado de ejecución**