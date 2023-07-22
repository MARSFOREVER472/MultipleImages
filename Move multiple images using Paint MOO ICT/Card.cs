using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Espacio de nombres asociado al proyecto.

namespace Move_multiple_images_using_Paint_MOO_ICT
{
    // Nombre de la clase a crear.
    internal class Card
    {
        // Vamos a declarar algunas variables.

        public Image fotoCarta; // Fotos de naipes importadas.
        public int ancho; // Ancho de la carta.
        public int altura; // Altura de la carta.
        public Point position = new Point(); // Posición de las cartas.
        public bool active = false; // No se ejecutará el juego por el momento.
        public Rectangle rectangulo; // La carta es de una forma rectangular.

        // Vamos a crear un constructor para esta clase.

        public Card(string ubicacionFoto)
        {
            fotoCarta = Image.FromFile(ubicacionFoto); // Ojo, las imágenes se deben importar mediante una carpeta comprimida.
            ancho = 65; // El ancho de la carta es de 65 cm.
            altura = 105; // La altura de la carta es de 105 cm.
            rectangulo = new Rectangle(position.X, position.Y, ancho, altura); // Crearemos un rectángulo para la base de una carta.
        }

    }
}
