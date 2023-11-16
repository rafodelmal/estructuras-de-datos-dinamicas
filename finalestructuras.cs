//PROYECTO FINAL DE ESTRUCTURAS DE DATOS 
// DANIEL ALZATE ARIAS

// Recorrido iterativo en orden

using System;
using System.Collections.Generic;

public class BinaryTree
{
    public int Value { get; set; }
    public BinaryTree Parent { get; set; }
    public BinaryTree Left { get; set; }
    public BinaryTree Right { get; set; }

    public BinaryTree(int value, BinaryTree parent = null, BinaryTree left = null, BinaryTree right = null)
    {
        if (parent == null && (left != null || right != null))
        {
            throw new ArgumentException("El nodo padre no puede ser nulo.");
        }

        if (ValueAlreadyExists(parent, value))
        {
            throw new ArgumentException($"El valor {value} ya existe en el árbol.");
        }

        Value = value;
        Parent = parent;
        Left = left;
        Right = right;
    }

    private static bool ValueAlreadyExists(BinaryTree node, int value)
    {
        if (node == null)
        {
            return false;
        }

        if (node.Value == value)
        {
            return true;
        }

        return ValueAlreadyExists(node.Left, value) || ValueAlreadyExists(node.Right, value);
    }

    public void PrintTree()
    {
        PrintTree(this, "");
    }

    private void PrintTree(BinaryTree node, string indent, bool isLast = true)
    {
        if (node != null)
        {
            Console.Write(indent);

            if (isLast)
            {
                Console.Write("└─ ");
                indent += "   ";
            }
            else
            {
                Console.Write("├─ ");
                indent += "│  ";
            }

            Console.WriteLine($"{node.Value}");

            if (node.Left != null || node.Right != null)
            {
                PrintTree(node.Left, indent, node.Right == null);
                PrintTree(node.Right, indent, true);
            }
        }
    }
}

    public class TreeTraversal
{
    public static void InOrderTraversal(BinaryTree root, Action<BinaryTree> callback)
    {
        if (root == null)
        {
            throw new ArgumentNullException(nameof(root), "El árbol no puede ser nulo");
        }

        if (callback == null)
        {
            throw new ArgumentNullException(nameof(callback), "La función de devolución de llamada no puede ser nula");
        }

        Stack<BinaryTree> stack = new Stack<BinaryTree>();
        BinaryTree currentNode = root;

        try
        {
            while (currentNode != null || stack.Count > 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }

                currentNode = stack.Pop();
                callback(currentNode);
                currentNode = currentNode.Right;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error durante el recorrido del árbol: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Construyendo un Árbol Binario");

        int valorRaiz = ObtenerEntradaUsuario("Ingresa el valor para el nodo raíz:");

        BinaryTree raiz = new BinaryTree(valorRaiz);

        try
        {
            ConstruirArbol(raiz);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al construir el árbol: {ex.Message}");
            return;
        }

        Console.WriteLine("Recorrido en Orden:");
        TreeTraversal.InOrderTraversal(raiz, nodo => Console.WriteLine($"Callback({nodo.Value})"));

        Console.WriteLine("\nÁrbol Binario:");
        raiz.PrintTree();

        Console.ReadLine();
    }

    static void ConstruirArbol(BinaryTree nodoPadre)
    {
        Console.WriteLine($"Nodo Actual ({(nodoPadre.Parent != null ? "Padre= " + nodoPadre.Parent.Value : "Raíz")}) : {nodoPadre.Value}");

        if (PreguntarSiONo("¿Quieres agregar un hijo izquierdo?"))
        {
            int valorIzquierdo = ObtenerEntradaUsuario($"Ingresa el valor para el hijo izquierdo del nodo {nodoPadre.Value}:");

            try
            {
                nodoPadre.Left = new BinaryTree(valorIzquierdo, nodoPadre);
                ConstruirArbol(nodoPadre.Left);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error al agregar el hijo izquierdo: {ex.Message}");
            }
        }

        Console.WriteLine($"Callback({nodoPadre.Value})");

        if (PreguntarSiONo("¿Quieres agregar un hijo derecho?"))
        {
            int valorDerecho = ObtenerEntradaUsuario($"Ingresa el valor para el hijo derecho del nodo {nodoPadre.Value}:");

            try
            {
                nodoPadre.Right = new BinaryTree(valorDerecho, nodoPadre);
                ConstruirArbol(nodoPadre.Right);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error al agregar el hijo derecho: {ex.Message}");
            }
        }
    }


    static int ObtenerEntradaUsuario(string mensaje)
    {
        Console.WriteLine(mensaje);
        int entradaUsuario;

        while (!int.TryParse(Console.ReadLine(), out entradaUsuario))
        {
            Console.WriteLine("Entrada no válida. Por favor, ingresa un entero válido.");
        }

        return entradaUsuario;
    }

    static bool PreguntarSiONo(string mensaje)
    {
        Console.WriteLine($"{mensaje} (responde 's' para sí o 'n' para no):");

        string entradaUsuario = Console.ReadLine().ToLower();

        return entradaUsuario == "s" || entradaUsuario == "si";
    }
}
