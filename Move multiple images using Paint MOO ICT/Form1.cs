namespace Move_multiple_images_using_Paint_MOO_ICT
{
    public partial class Form1 : Form
    {
        // Procedemos a crear las variables.

        List<Card> cartas = new List<Card>(); // Variable para las cartas mediante listas.
        Card CartaSeleccionada; // Selección de cualquier carta del mazo.
        int indexValue; // Valor del índice.
        int xPosition = 5; // La posición en x es 5.
        List<string> imageLocation = new List<string>(); // La ubicación de cualquier foto se posicionan mediante listas.
        int numCarta = -1; // Valor del número de la carta por defecto.
        int cartasTotales = 0; // Número de cartas totales del mazo.
        int lineaAnimacion = 0; // Se inicializa el valor de esta variable.

        // Método de la interfaz visual del juego.
        public Form1()
        {
            InitializeComponent(); // Llamado del método inicial.
            SetUpApp(); // Llamado del método a ejecutar.
        }

        // Método que funcionaliza la aplicación.

        private void SetUpApp()
        {
            // Crearemos un algoritmo para que pueda compatibilizar la ejecución de la app con las fotos importadas.

            imageLocation = Directory.GetFiles("cards", "*.png").ToList(); // Se visualizarán las fotos ya importadas desde un directorio descargado.
            cartasTotales = imageLocation.Count; // Se contabilizarán las cartas en la app.

            // Crearemos un ciclo for para generar cartas mediante fotos ya importadas.

            for (int i = 0; i < cartasTotales; i++)
            {
                HacerCartas(); // Genera un llamado a este método.
            }

            // Pero aún no acaba aquí...

            label1.Text = "Card " + (numCarta + 1) + " of " + cartasTotales; // Texto completo que se muestra en la parte de abajo de la interfaz en amarillo.
        }

        // Método privado que hace las cartas.

        private void HacerCartas()
        {
            // Algoritmo más dificultoso para posicionar cartas.

            numCarta++; // Se incrementan el número de las cartas.
            xPosition += 55; // Posición en X por defecto.
            Card nuevaCarta = new Card(imageLocation[numCarta]); // Nueva variable para generar nuevas cartas.
            nuevaCarta.position.X = xPosition; // Se entregó un valor por defecto en la variable anterior.
            nuevaCarta.position.Y = 300; // La nueva carta generada en la posición en Y es de 300.
            nuevaCarta.rectangulo.X = nuevaCarta.position.X; // La nueva carta generada estará en la posición en X.
            nuevaCarta.rectangulo.Y = nuevaCarta.position.Y; // La nueva carta generada estará en la posición en Y.
            cartas.Add(nuevaCarta); // Se añadirán las cartas ya generadas.
        }

        // Método que se ejecuta al bajar el mouse.

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            // Definiremos mediante un algoritmo sencillo utilizando esta función al seleccionar una nueva carta.

            // Primero crearemos algunas variables.

            Point posicionMouse = new Point(e.X, e.Y); // Posición del mouse.

            // Crearemos un foreach para cada nueva carta que se genere y que aparezca en el tablero.

            foreach (Card newCard in cartas)
            {
                if (CartaSeleccionada == null) // Si no se ha seleccionado una carta.
                {
                    if (newCard.rectangulo.Contains(posicionMouse)) // Si se generó un rectángulo hacia la carta mediante un contenedor del mouse.
                    {
                        CartaSeleccionada = newCard; // Selecciona una nueva carta.
                        newCard.active = true; // Se activará esta función para la carta nueva que se genera.
                        indexValue = cartas.IndexOf(newCard); // Al generar una nueva carta, el valor del índice se incrementa en +1.
                        label1.Text = "Card " + (indexValue + 1) + " of " + cartasTotales; // " Card (1, 2, 3, 4, 5, ...) of 13 ".
                    }
                }
            }
        }

        // Método que se ejecuta al mover el mouse.
        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            // Apoyaremos en este método mediante un algoritmo de posiciones en X e Y.

            if (CartaSeleccionada != null) // Si la carta ya está seleccionada.
            {
                CartaSeleccionada.position.X = e.X - (CartaSeleccionada.ancho / 2); // Posición según el ancho de la carta.
                CartaSeleccionada.position.Y = e.Y - (CartaSeleccionada.altura / 2); // Posición según la altura de la carta.

            }
        }

        // Método que se ejecuta al subir el mouse.
        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            // EN INSTANTES...
        }

        // Método tal como su nombre lo indica, se hace con Paint.
        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            // EN INSTANTES...
        }

        // Método funcional en base al temporizador del juego.
        private void FormTimerEvent(object sender, EventArgs e)
        {
            // EN INSTANTES...
        }
    }
}