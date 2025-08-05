using System;

namespace Ejercicio4_Abstract
{
    //Clase abstracta
    public abstract class AbstractSample
    {
        // mensaje que se manipulara
        private string message;

        // constructor que recibe un mensaje inicial
        public AbstractSample(string message)
        {
            this.message = message;
        }

        // metodo abstracto
        public abstract void PrintMessage(string msg);

        // metodo virtual, invierte mensaje recibido y lo almacena
        public virtual void InvertMessage(string msg)
        {
            char[] arr = msg.ToCharArray();
            Array.Reverse(arr);
            message = new string(arr);
            Console.WriteLine(message);
        }

        protected string GetMessage()
        {
            return message;
        }

        protected void SetMessage(string msg)
        {
            message = msg;
        }
    }

    // subclase que implementa PrintMessage imprimiendo el mensaje tal como esta
    public class MensajeNormal : AbstractSample
    {
        public MensajeNormal(string message) : base(message) { }

        public override void PrintMessage(string msg)
        {
            SetMessage(msg);               
            Console.WriteLine(GetMessage()); 
        }
    }

    // subclase que implementa PrintMessage invirtiendo mayusculas y minusculas
    
    public class MensajeConCambioDeCaso : AbstractSample
    {
        public MensajeConCambioDeCaso(string message) : base(message) { }

        public override void PrintMessage(string msg)
        {
            SetMessage(msg);
            string resultado = "";

            foreach (char c in GetMessage())
            {
                resultado += char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
            }

            Console.WriteLine(resultado); 
        }

        public override void InvertMessage(string msg)
        {
            
            char[] arr = msg.ToCharArray();
            Array.Reverse(arr);
            string invertido = new string(arr);

            string resultado = "";

            foreach (char c in invertido)
            {
                resultado += char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);
            }

            SetMessage(resultado);
            Console.WriteLine(GetMessage());
        }
    }

    // clase que representa al "gestor" que instancia y prueba ambas subclases
    public class GestorMensajes
    {
        public void Ejecutar()
        {
            // 🔸 Se crean dos objetos: uno de cada tipo
            AbstractSample normal = new MensajeNormal("Hola Mundo");
            AbstractSample cambioCaso = new MensajeConCambioDeCaso("Hola Mundo");

            // 🔸 Se invocan los métodos solicitados en la actividad
            Console.WriteLine("=== PrintMessage MensajeNormal ===");
            normal.PrintMessage("Hola Mundo");

            Console.WriteLine("=== PrintMessage MensajeConCambioDeCaso ===");
            cambioCaso.PrintMessage("Hola Mundo");

            Console.WriteLine("=== InvertMessage MensajeNormal ===");
            normal.InvertMessage("Hola Mundo");

            Console.WriteLine("=== InvertMessage MensajeConCambioDeCaso ===");
            cambioCaso.InvertMessage("Hola Mundo");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GestorMensajes gestor = new GestorMensajes();
            gestor.Ejecutar();
        }
    }
}