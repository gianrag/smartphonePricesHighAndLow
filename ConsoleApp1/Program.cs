using System.Collections;
using System.Xml.Linq;

//Classe padre (SuperClass)
class Telefono
{
   //Attributi
   public string Numero {  get; set; }

   //Metodo per descriviere il telefono
   public virtual void Descrivi()
    {
        Console.WriteLine($"Numero telefono = {Numero}");
    }

}

//Classe figlia (SubClass)
class Smartphone: Telefono
{
    //Attributi
    public string Marca { get; set; }
    public double Costo { get; set; }

    //Metodo per descriviere il telefono
    public override void Descrivi()
    {
        Console.WriteLine($"Numero telefono = {Numero}, marca {Marca} e costo {Costo}");
    }

}

class Program
{
    static void Main(string[] args)
    {
        // Array da memorizzare 3 smarthone, creazione dei cellari
        Smartphone[] cellulari = new Smartphone[3];

        for (int i = 0; i < 3; i++)
        {
            cellulari[i] = new Smartphone(); // creo nuovo oggetto smartphone

            Console.WriteLine($"Inserisci i dettagli per il cellulare {i + 1}");

            Console.Write("Numero di telefono: ");
            cellulari[i].Numero = Console.ReadLine(); //leggo l'input dell'utente

            Console.Write("Marca: ");
            cellulari[i].Marca = Console.ReadLine(); //leggo l'input dell'utente

            Console.Write("Costo: ");
            cellulari[i].Costo = Double.Parse(Console.ReadLine()); //leggo l'input dell'utente ma questo è un numero quindi da string diventa un double grazie al parse

            //Descrizione Completa del cellulare
            cellulari[i].Descrivi();
        }

        //trovare telefono più costoso, meno costoso e calcolare costo medio.
        Smartphone celPiuCostoso = cellulari[0];
        Smartphone celMenoCostoso = cellulari[0];
        double costoTotale = 0;

        foreach (Smartphone cellulareSingolo in cellulari) { 

            if (cellulareSingolo.Costo > celPiuCostoso.Costo)
            {
                celPiuCostoso = cellulareSingolo;
            } 

            if (cellulareSingolo.Costo < celMenoCostoso.Costo)
            {
                celMenoCostoso = cellulareSingolo;
            }

            //per ogni iterazione faccio la somma e la salvo dentro la variabile (costoTotale) che ho creato fuori del ciclo
            costoTotale += cellulareSingolo.Costo;
        }

        double costoMedio = costoTotale / cellulari.Length;

        Console.WriteLine("\n---Risultati---");
        Console.WriteLine($"Il telefono della marca {celPiuCostoso.Marca} è più costoso con il prezzo di {celPiuCostoso.Costo} euro");
        Console.WriteLine($"Il telefono della marca {celMenoCostoso.Marca} è meno costoso con il prezzo di {celMenoCostoso.Costo} euro");
        Console.WriteLine($"Il costo medio dei telefoni è: {costoMedio} euro");

    }
}