using System.ComponentModel;

public class Node
{
    public object element;//data
    public Node link;//liên kết
    public Node()
    {
        this.element = null;
        this.link = null;
    }
    public Node(object element)
    {
        this.element = element;
        this.link = null;
    }
}
public class LinkedList
{
    public Node header;//Nút đầu
    public LinkedList()
    {
        header = new Node("header");
    }
    public Node Find(object ele)
    {
        Node current = header;
        while (!current.element.Equals(ele) && current.link != null)
            current = current.link;
        return current;
    }
    public void Insert(object newele, object after)
    {
        Node current = Find(after);
        Node newNode = new Node(newele);
        newNode.link = current.link;
        current.link = newNode;
    }
    public Node FindPrev(object ele)
    {
        Node current = header;
        while (!current.link.element.Equals(ele) && current.link != null)
            current = current.link;
        return current;
    }
    public void Remove(object ele)
    {
        Node current = FindPrev(ele);
        if (current.link != null)
            current.link = current.link.link;
    }
    public void Swap(object o1, object o2)
    {
        object n1 = FindPrev(o1).element;
        object n2 = FindPrev(o2).element;
        Remove(o1);
        Remove(o2);
        Insert(o1, n2);
        Insert(o2, n1);
    }
    public void Sort()
    {
    Begin:
        Node current = header.link;
        while (current.link != null)
        {
            Node current2 = current.link;
            while (current2 != null)
            {
                if ((int)current.element > (int)current2.element)
                {
                    Swap(current2.element, current.element);
                    goto Begin;
                }
                current2 = current2.link;
            }
            current = current.link;
        }
    }
}
class Book
{
    public string title, author;
    public long price;
    public Book(string title, string author, long price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }
    override public string ToString()
    {
        return $"[Book: {title}, {author}, {price}]";
    }
}
public class Node2
{
    public object element;
    public Node2 flink, blink;
    public Node2()
    {
        element = null;
        flink = blink = null;
    }
    public Node2(object element)
    {
        this.element = element;
        flink = blink = null;
    }

}
public class DoubleLinkedList
{
    public Node2 header;
    public DoubleLinkedList()
    {
        header = new Node2("Header");
    }
    private Node2 Find(object element)
    {
        Node2 current = new Node2();
        current = header;
        while (current.element != element)
        {
            current = current.flink;
        }
        return current;
    }
    public void Insert(object newelement, object afterelement)
    {
        Node2 current = new Node2();
        Node2 newnode = new Node2(newelement);
        current = Find(afterelement);
        newnode.flink = current.flink;
        newnode.blink = current;
        current.flink = newnode;
    }
    public void Remove(object element)
    {
        Node2 current = Find(element);
        if (current.flink != null)
        {
            current.blink.flink = current.flink;
            current.flink.blink = current.blink;
            current.flink = null;
            current.blink = null;
        }
    }
    private Node2 FindLast()
    {
        Node2 current = new Node2();
        current = header;
        while (!(current.flink == null))
            current = current.flink;
        return current;
    }
    public void Print()
    {
        Node2 current = new Node2();
        current = FindLast();
        while (!(current.blink == null))
        {
            Console.WriteLine(current.element as Book);
            current = current.blink;
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        /*LinkedList list = new LinkedList();
        list.Insert("Milk", "header");
        list.Insert("Bread", "Milk");
        list.Insert("Eggs", "Bread");
        ;
        //list.Remove("Bread");
        list.Swap("Milk", "Eggs");
        ;*/
        /*LinkedList list2 = new LinkedList();
        list2.Insert(9, "header");
        list2.Insert(5, 9);
        list2.Insert(7, 5);
        list2.Insert(3, 7);
        ;
        list2.Sort();
        ;*/
        DoubleLinkedList list3 = new DoubleLinkedList();
        Book b1 = new Book( "Gone with the Wind",
                            "Magarette Michele",
                            100000);
        list3.Insert(b1, "Header");
        Book b2 = new Book( "Kieu's Story",
                            "Nguyen Du",
                            120000);
        list3.Insert(b2, b1);
        list3.Print();
    }
}