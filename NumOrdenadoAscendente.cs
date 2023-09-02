using System;

class Nodo
{
    public int valor;
    public Nodo? proximo;

    public Nodo(int valor)
    {
        this.valor = valor;
        this.proximo = null;
    }

    public static Nodo AgregarNodoALista(Nodo lista, Nodo valorIngresado)
    {
        if (lista == null)
        {
            return valorIngresado;
        }
        if (valorIngresado.valor == lista.valor)
        {
            Console.WriteLine("No se puede agregar el elemento, ya se encuentra en los nodos");
            return lista;
        }

        if (valorIngresado.valor < lista.valor)
        {
            valorIngresado.proximo = lista;
            return valorIngresado;
        }

        Nodo actual = lista;
        while (actual.proximo != null && valorIngresado.valor > actual.proximo.valor)
        {
            actual = actual.proximo;
        }

        valorIngresado.proximo = actual.proximo;
        actual.proximo = valorIngresado;

        return lista;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Nodo lista = null;

        do
        {
            Console.WriteLine("Ingrese números separados por comas para crear la lista:");
            string entrada = Console.ReadLine();
            string[] numeros = entrada.Split(',');

            foreach (string numero in numeros)
            {
                if (int.TryParse(numero, out int valor))
                {
                    lista = Nodo.AgregarNodoALista(lista, new Nodo(valor));
                }
                else
                {
                    Console.WriteLine($"No se pudo analizar '{numero}' como un número.");
                }
            }

            ImprimirLista(lista);

            Console.WriteLine("¿Desea volver a jugar? (Sí/No):");
        } while (Console.ReadLine().Trim().Equals("Sí", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Hasta luego.");
    }

    static void ImprimirLista(Nodo lista)
    {
        Nodo actual = lista;
        while (actual != null)
        {
            Console.Write(actual.valor + " , ");
            actual = actual.proximo;
        }
        Console.WriteLine("null");
    }
}

