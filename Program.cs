public class Node{
    public object element;//data
    public Node link;//liên kết
    public Node(){
        this.element = null;
        this.link = null;
    }
    public Node(object element){
        this.element = element;
        this.link = null;
    }
}
public class LinkedList{
    public Node header;//Nút đầu
    public LinkedList(){
        header = new Node("header");
    }
    public Node Find(object ele){
        Node current = header;
        while(!current.element.Equals(ele) && current.link!= null)
            current = current.link;
        return current;
    }
    public void Insert(object newele, object after){
        Node current = Find(after);
        Node newNode = new Node(newele);
        newNode.link = current.link;
        current.link = newNode;
    }
    public Node FindPrev(object ele){
        Node current = header;
        while(!current.link.element.Equals(ele) && current.link!= null)
            current = current.link;
        return current;
    }
    public void Remove(object ele){
        Node current = FindPrev(ele);
        if(current.link!=null)
            current.link = current.link.link;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        list.Insert("Milk", "header");
        list.Insert("Bread", "Milk");
        list.Insert("Eggs", "Bread");
        ;
        list.Remove("Bread");
        ;
    }
}