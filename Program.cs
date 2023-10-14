using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinario
{
    public Nodo Raiz;

    public ArbolBinario()
    {
        Raiz = null;
    }

    public void Insertar(int valor)
    {
        if (valor == -1)
        {
            // Permite la inserción infinita
            Console.WriteLine("Puede ingresar nodos infinitos. Ingrese 'X' para detener.");
            while (true)
            {
                Console.Write("Ingrese un número (o 'X' para detener, '0' para crear árbol vacío): ");
                string entrada = Console.ReadLine();

                if (entrada.ToUpper() == "X")
                {
                    break;
                }
                else if (entrada == "0")
                {
                    Raiz = null; // Crear un árbol vacío
                    Console.WriteLine("Árbol vacío creado.");
                    break;
                }
                else if (int.TryParse(entrada, out int numero))
                {
                    Raiz = InsertarRecursivamente(Raiz, numero);
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido, 'X' para detener o '0' para crear árbol vacío.");
                }
            }
        }
        else
        {
            int numeroDeNodos = valor;
            while (numeroDeNodos <= 0)
            {
                Console.Write("Ingrese un número positivo para el número de nodos (o -1 para inserción infinita): ");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    numeroDeNodos = num;
                }
                else if (num == -1)
                {
                    // Entra en el modo de inserción infinita
                    Console.WriteLine("Puede ingresar nodos infinitos. Ingrese 'X' para detener.");
                    while (true)
                    {
                        Console.Write("Ingrese un número (o 'X' para detener, '0' para crear árbol vacío): ");
                        string entrada = Console.ReadLine();

                        if (entrada.ToUpper() == "X")
                        {
                            break;
                        }
                        else if (entrada == "0")
                        {
                            Raiz = null; // Crear un árbol vacío
                            Console.WriteLine("Árbol vacío creado.");
                            break;
                        }
                        else if (int.TryParse(entrada, out int numero))
                        {
                            Raiz = InsertarRecursivamente(Raiz, numero);
                        }
                        else
                        {
                            Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido, 'X' para detener o '0' para crear árbol vacío.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Número no válido. Por favor, ingrese un número positivo o -1 para inserción infinita.");
                }
            }

            for (int i = 0; i < numeroDeNodos; i++)
            {
                Console.Write($"Ingrese el valor #{i + 1} (o 'X' para detener, '0' para crear árbol vacío): ");
                string entrada = Console.ReadLine();

                if (entrada.ToUpper() == "X")
                {
                    break;
                }
                else if (entrada == "0")
                {
                    Raiz = null; // Crear un árbol vacío
                    Console.WriteLine("Árbol vacío creado.");
                    break;
                }
                else if (int.TryParse(entrada, out int numero))
                {
                    Raiz = InsertarRecursivamente(Raiz, numero);
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido, 'X' para detener o '0' para crear árbol vacío.");
                }
            }
        }
    }

    private Nodo InsertarRecursivamente(Nodo nodo, int valor)
    {
        if (nodo == null)
        {
            nodo = new Nodo(valor);
        }
        else if (valor < nodo.Valor)
        {
            nodo.Izquierdo = InsertarRecursivamente(nodo.Izquierdo, valor);
        }
        else
        {
            nodo.Derecho = InsertarRecursivamente(nodo.Derecho, valor);
        }
        return nodo;
    }

    public void RecorridoInOrder(Nodo nodo)
    {
        if (nodo != null)
        {
            RecorridoInOrder(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            RecorridoInOrder(nodo.Derecho);
        }
    }

    public void RecorridoPreOrder(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            RecorridoPreOrder(nodo.Izquierdo);
            RecorridoPreOrder(nodo.Derecho);
        }
    }

    public void RecorridoPostOrder(Nodo nodo)
    {
        if (nodo != null)
        {
            RecorridoPostOrder(nodo.Izquierdo);
            RecorridoPostOrder(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    public void RealizarRecorridoInOrder()
    {
        RecorridoInOrder(Raiz);
        Console.WriteLine();
    }

    public void RealizarRecorridoPreOrder()
    {
        RecorridoPreOrder(Raiz);
        Console.WriteLine();
    }

    public void RealizarRecorridoPostOrder()
    {
        RecorridoPostOrder(Raiz);
        Console.WriteLine();
    }

    public int NumeroDeNodos()
    {
        return ContarNodos(Raiz);
    }

    private int ContarNodos(Nodo nodo)
    {
        if (nodo == null)
        {
            return 0;
        }
        return 1 + ContarNodos(nodo.Izquierdo) + ContarNodos(nodo.Derecho);
    }

    public int NumeroDeHojas()
    {
        return ContarHojas(Raiz);
    }

    private int ContarHojas(Nodo nodo)
    {
        if (nodo == null)
        {
            return 0;
        }
        if (nodo.Izquierdo == null && nodo.Derecho == null)
        {
            return 1;
        }
        return ContarHojas(nodo.Izquierdo) + ContarHojas(nodo.Derecho);
    }

    public int AlturaDelArbol()
    {
        return CalcularAltura(Raiz);
    }

    private int CalcularAltura(Nodo nodo)
    {
        if (nodo == null)
        {
            return 0;
        }
        int alturaIzquierda = CalcularAltura(nodo.Izquierdo);
        int alturaDerecha = CalcularAltura(nodo.Derecho);
        return 1 + Math.Max(alturaIzquierda, alturaDerecha);
    }

    public bool EsCompleto()
    {
        int altura = CalcularAltura(Raiz);
        return EsArbolCompleto(Raiz, altura, 0);
    }

    private bool EsArbolCompleto(Nodo nodo, int altura, int nivel)
    {
        if (nodo == null)
        {
            return altura == nivel + 1;
        }
        if (nodo.Izquierdo == null && nodo.Derecho == null)
        {
            return altura == nivel + 1;
        }
        if (EsArbolCompleto(nodo.Izquierdo, altura, nivel + 1) && EsArbolCompleto(nodo.Derecho, altura, nivel + 1))
        {
            return true;
        }
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();

        Console.WriteLine("Bienvenido al programa de árbol binario.");
        Console.WriteLine("Para insertar nodos, ingrese números positivos. Para detener, ingrese 'X'. Para crear un árbol vacío, ingrese '0'. Para inserción infinita, ingrese '-1' y deténgase con 'X'.");

        Console.Write("Ingrese un número positivo para el número de nodos (o -1 para inserción infinita): ");
        if (int.TryParse(Console.ReadLine(), out int num))
        {
            arbol.Insertar(num);
        }
        else
        {
            Console.WriteLine("Número no válido. Por favor, ingrese un número positivo o -1 para inserción infinita.");
        }

        while (true)
        {
            Console.WriteLine("Menú del árbol:");
            Console.WriteLine("1. Recorrido InOrder");
            Console.WriteLine("2. Recorrido PreOrder");
            Console.WriteLine("3. Recorrido PostOrder");
            Console.WriteLine("4. Número de nodos");
            Console.WriteLine("5. Número de hojas");
            Console.WriteLine("6. Altura del árbol");
            Console.WriteLine("7. Es un árbol completo");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Recorrido InOrder del árbol:");
                    arbol.RealizarRecorridoInOrder();
                    break;
                case "2":
                    Console.WriteLine("Recorrido PreOrder del árbol:");
                    arbol.RealizarRecorridoPreOrder();
                    break;
                case "3":
                    Console.WriteLine("Recorrido PostOrder del árbol:");
                    arbol.RealizarRecorridoPostOrder();
                    break;
                case "4":
                    Console.WriteLine($"Número de nodos: {arbol.NumeroDeNodos()}");
                    break;
                case "5":
                    Console.WriteLine($"Número de hojas: {arbol.NumeroDeHojas()}");
                    break;
                case "6":
                    Console.WriteLine($"Altura del árbol: {arbol.AlturaDelArbol()}");
                    break;
                case "7":
                    Console.WriteLine($"Es un árbol completo: {arbol.EsCompleto()}");
                    break;
                case "8":
                    return; // Salir del programa
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }
}
