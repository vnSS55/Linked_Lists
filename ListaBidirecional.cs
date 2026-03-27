using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lista_musicas
{
    public class Node
    {
        public string Value;
        public Node Next;
        public Node Previous;

        public Node(string v)
        {
            // stores the node data (in this case, a string). It's the content the list stores and manages
            Value = v;
            // Reference to the next node in the list. If the node is the last one, this field is null
            Next = null;
            // Reference to the previous node in the list. If the node is the first one, this field is null
            Previous = null;
        }
    }

    public class DoublyLinkedList
    {
        // Reference to the first node in the list (head -> tail) using Next
        private Node head; // Start of the list
        // Reference to the last node in the list (tail -> head) using Previous
        private Node tail; // End of the list
        public Node current;

        public DoublyLinkedList()
        {
            // both null, means empty list
            head = null; // empty list
            tail = null; // empty list
        }

        public void Insert(string value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            current = newNode; // Sets the new node as the current one
        }

        // gets the current song
        public string Musica_atual()
        {
            if (head == null)
            {
                return "No songs in the playlist.";
            }
            return head.Value;
        }

        // moves to the next song
        public void Proxima_musica()
        {
            if (head != null && head.Next != null)
            {
                head = head.Next;
            }
        }

        // goes back to the previous song
        public void Musica_anterior()
        {
            if (head != null && head.Previous != null)
            {
                head = head.Previous;
            }
        }

        // deletes a song
        public void Deletar(string value)
        {
            Node currentNode = head;

            // searches for the node with the value
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    // Adjusts the previous reference
                    if (currentNode.Previous != null)
                        currentNode.Previous.Next = currentNode.Next;
                    else
                        head = currentNode.Next; // node was the first one

                    // Adjusts the next reference
                    if (currentNode.Next != null)
                        currentNode.Next.Previous = currentNode.Previous;
                    else
                        tail = currentNode.Previous; // node was the last one

                    // Adjusts current pointer if it's pointing to this node
                    if (this.current == currentNode)
                        this.current = currentNode.Next ?? currentNode.Previous;

                    return; // exits the function after removing
                }
                currentNode = currentNode.Next;
            }
        }
    }
}