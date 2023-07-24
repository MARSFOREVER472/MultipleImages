namespace Move_multiple_images_using_Paint_MOO_ICT
{
    public partial class Form1 : Form
    {
        // Procedemos a crear las variables.

        List<Card> cartas = new List<Card>(); // Variable para las cartas mediante listas.
        Card CartaSeleccionada; // Selecci�n de cualquier carta del mazo.
        int indexValue; // Valor del �ndice.
        int xPosition = 5; // La posici�n en x es 5.
        List<string> imageLocation = new List<string>(); // La ubicaci�n de cualquier foto se posicionan mediante listas.
        int numCarta = -1; // Valor del n�mero de la carta por defecto.
        int cartasTotales = 0; // N�mero de cartas totales del mazo.
        int lineaAnimacion = 0; // Se inicializa el valor de esta variable.

        // M�todo de la interfaz visual del juego.
        public Form1()
        {
            InitializeComponent(); // Llamado del m�todo inicial.
            SetUpApp(); // Llamado del m�todo a ejecutar.
        }

        // M�todo que funcionaliza la aplicaci�n.

        private void SetUpApp()
        {
            // Crearemos un algoritmo para que pueda compatibilizar la ejecuci�n de la app con las fotos importadas.

            imageLocation = Directory.GetFiles("cards", "*.png").ToList(); // Se visualizar�n las fotos ya importadas desde un directorio descargado.
            cartasTotales = imageLocation.Count; // Se contabilizar�n las cartas en la app.

            // Crearemos un ciclo for para generar cartas mediante fotos ya importadas.

            for (int i = 0; i < cartasTotales; i++)
            {
                HacerCartas(); // Genera un llamado a este m�todo.
            }

            // Pero a�n no acaba aqu�...

            label1.Text = "Card " + (numCarta + 1) + " of " + cartasTotales; // Texto completo que se muestra en la parte de abajo de la interfaz en amarillo.
        }

        // M�todo privado que hace las cartas.

        private void HacerCartas()
        {
            // Algoritmo m�s dificultoso para posicionar cartas.

            numCarta++; // Se incrementan el n�mero de las cartas.
            xPosition += 50; // Posici�n en X por defecto.
            Card nuevaCarta = new Card(imageLocation[numCarta]); // Nueva variable para generar nuevas cartas.
            nuevaCarta.position.X = xPosition; // Se entreg� un valor por defecto en la variable anterior.
            nuevaCarta.position.Y = 300; // La nueva carta generada en la posici�n en Y es de 300.
            nuevaCarta.rectangulo.X = nuevaCarta.position.X; // La nueva carta generada estar� en la posici�n en X.
            nuevaCarta.rectangulo.Y = nuevaCarta.position.Y; // La nueva carta generada estar� en la posici�n en Y.
            cartas.Add(nuevaCarta); // Se a�adir�n las cartas ya generadas.
        }

        // M�todo que se ejecuta al bajar el mouse.

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            // Definiremos mediante un algoritmo sencillo utilizando esta funci�n al seleccionar una nueva carta.

            // Primero crearemos algunas variables.

            Point posicionMouse = new Point(e.X, e.Y); // Posici�n del mouse.

            // Crearemos un foreach para cada nueva carta que se genere y que aparezca en el tablero.

            foreach (Card newCard in cartas)
            {
                if (CartaSeleccionada == null) // Si no se ha seleccionado una carta.
                {
                    if (newCard.rectangulo.Contains(posicionMouse)) // Si se gener� un rect�ngulo hacia la carta mediante un contenedor del mouse.
                    {
                        CartaSeleccionada = newCard; // Selecciona una nueva carta.
                        newCard.active = true; // Se activar� esta funci�n para la carta nueva que se genera.
                        indexValue = cartas.IndexOf(newCard); // Al generar una nueva carta, el valor del �ndice se incrementa en +1.
                        label1.Text = "Card " + (indexValue + 1) + " of " + cartasTotales; // " Card (1, 2, 3, 4, 5, ...) of 13 ".
                    }
                }
            }
        }

        // M�todo que se ejecuta al mover el mouse.
        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            // Apoyaremos en este m�todo mediante un algoritmo de posiciones en X e Y.

            if (CartaSeleccionada != null) // Si la carta ya est� seleccionada.
            {
                CartaSeleccionada.position.X = e.X - (CartaSeleccionada.ancho / 2); // Posici�n seg�n el ancho de la carta.
                CartaSeleccionada.position.Y = e.Y - (CartaSeleccionada.altura / 2); // Posici�n seg�n la altura de la carta.

            }
        }

        // M�todo que se ejecuta al subir el mouse.
        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            // Crearemos un algoritmo simple mediante un foreach para esta acci�n.

            foreach (Card tempCarta in cartas)
            {
                tempCarta.active = false; // No se generar� esta l�nea de c�digo por defecto.
            }
            CartaSeleccionada = null; // La carta seleccionada no est� incluida o no existe.
            lineaAnimacion = 0; // Valor por defecto.
        }

        // M�todo tal como su nombre lo indica, se hace con Paint.
        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            // Se har� una ilustraci�n para las cartas importadas mediante un foreach.

            foreach (Card carta in cartas)
            {
                e.Graphics.DrawImage(carta.fotoCarta, carta.position.X, carta.position.Y, carta.ancho,
                    carta.altura);

                // Ahora pasaremos dentro de este ciclo a dibujar y colorear las cartas de un color distinto.

                Pen outline; // Tipo de l�piz en la cual podremos dibujar.

                if (carta.active) // Si la funci�n de la carta est� activada.
                {
                    outline = new Pen(Color.Orange, lineaAnimacion); // El color de este estilo es naranja.
                }
                else // En caso contrario �sta ser� transparente.
                {
                    outline = new Pen(Color.Transparent, 1);
                }

                // Con esto dibujaremos un rect�ngulo para la carta.

                e.Graphics.DrawRectangle(outline, carta.rectangulo);
            }

            // Si la carta ya est� elegida.

            if (CartaSeleccionada != null)
            {
                e.Graphics.DrawImage(CartaSeleccionada.fotoCarta, CartaSeleccionada.position.X, CartaSeleccionada.position.Y, 
                    CartaSeleccionada.ancho, CartaSeleccionada.altura); // Se dibuja una carta ya existente con sus par�metros respectivos.
            }
        }

        // M�todo funcional en base al temporizador del juego.
        private void FormTimerEvent(object sender, EventArgs e)
        {
            // Usaremos el mismo algoritmo mediante un foreach.

            foreach (Card carta in cartas)
            {
                carta.rectangulo.X = carta.position.X; // La posici�n en X ser� el ancho del rect�ngulo.
                carta.rectangulo.Y = carta.position.Y; // La posici�n en Y ser� la altura del rect�ngulo.
            }

            if (CartaSeleccionada != null) // Si ya se eligi� la carta.
            {
                if (lineaAnimacion < 10) // Si es que se cumple con esta condici�n.
                {
                    lineaAnimacion++; // Va a haber animaci�n lineal con las cartas.
                }
            }

            this.Invalidate(); // Par�metros incorrectos.
        }
    }
}