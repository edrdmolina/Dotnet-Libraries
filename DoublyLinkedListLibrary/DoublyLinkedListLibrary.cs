namespace DoublyLinkedListLibrary
{
    public class Node
    {
        public string value { get; set; }
        public Node prev { get; set; }
        public Node next { get; set; }

        public Node(string value)
        {
            this.value = value;
            this.prev = null;
            this.next = null;
        }
    }
    public class DoublyLinkedList
    {
        public int length { get; set; }
        public Node head { get; set; }
        public Node tail { get; set; }

        public DoublyLinkedList()
        {
            this.length = 0;
            this.head = null;
            this.tail = null;
        }
        public void PrintList()
        {
            Console.WriteLine("Index\tValue");

            Node currentNode = this.head;

            for(int i = 0; i < this.length; i++)
            {
                Console.WriteLine($"{i}\t{currentNode.value}");
                currentNode = currentNode.next;
            }
        }
        public void Push(string val)
        {   
            Node newNode = new Node(val);

            if (this.length == 0)
            {
                this.head = newNode;
            } 
            else
            {
                Node lastNode = this.tail;
                lastNode.next = newNode;
                newNode.prev = lastNode;
            }
            
            this.tail = newNode;
            this.length++;
            return;
        }
        public Node Pop()
        {
            if (this.length == 0) throw new IndexOutOfRangeException();
            Node last = this.tail;

            this.tail = last.prev;
            this.tail.next = null;
            last.prev = null;

            this.length--;
            return last;
        }
        public void Shift(string val)
        {
            Node newNode = new Node(val);

            if (this.length == 0)
            {
                this.tail = newNode;
            }
            else
            {
                Node firstNode = this.head;
                firstNode.prev = newNode;
                newNode.next = firstNode;
            }
            this.length++;
            this.head = newNode;
            return;
        }
        public Node Unshift()
        {
            if (this.length == 0) throw new IndexOutOfRangeException();

            Node first = this.head;

            this.head = first.next;
            this.head.prev = null;
            first.next = null;

            this.length--;
            return first;
        }
        public Node FindByIndex(int index)
        {
            if (index >= this.length || index < 0) throw new ArgumentOutOfRangeException();
            
            int middleIndex = this.length / 2;

            Node node = null;

            if (index <= middleIndex)
            {
                node = this.head;
                for(int i = 0; i < index; i++)
                {
                    node = node.next;
                }
            }
            else{
                node = this.tail;
                for (int i = this.length - 1; i > index; i--)
                {
                    node = node.prev;
                }
            }
            return node;
        }
        public int IndexOf(string value)
        {
            int index = 0;

            Node currentNode = this.head;

            while(index <= this.length)            
            {
                if (currentNode.value == value) break;
                if (currentNode == this.tail && currentNode.value != value) return -1;
                currentNode = currentNode.next;
                index++;
            }
            return index;
        }
        public void CreateAndInsert(int index, string value)
        {
            if (index < 0 || index > this.length) throw new ArgumentOutOfRangeException();
            if (index == this.length)
            {
                Push(value);
                return;
            }
            if (index == 0)
            {
                Shift(value);
                return;
            }

            Node newNode = new Node(value);

            Node currentNode = FindByIndex(index);

            newNode.next = currentNode;
            newNode.prev = currentNode.prev;
            currentNode.prev.next = newNode;

            this.length++;
            return;
        }
        public void Insert(int index, Node newNode)
        {
            if (index < 0 || index > this.length) throw new ArgumentOutOfRangeException();
            if (index == this.length)
            {
                if (this.length == 0)
                {
                    this.head = newNode;
                } 
                else
                {
                    Node lastNode = this.tail;
                    lastNode.next = newNode;
                    newNode.prev = lastNode;
                }
                
                this.tail = newNode;
                this.length++;
                return;
            }
            if (index == 0)
            {
                if (this.length == 0)
                {
                    this.tail = newNode;
                }
                else
                {
                    Node firstNode = this.head;
                    firstNode.prev = newNode;
                    newNode.next = firstNode;
                }
                this.length++;
                this.head = newNode;
                return;
            }

            Node currentNode = FindByIndex(index);

            newNode.next = currentNode;
            newNode.prev = currentNode.prev;
            currentNode.prev.next = newNode;

            this.length++;
            return;
        }
        public Node FindByIndexAndRemove(int index)
        {
            if (index == 0) return Unshift();
            if (index == this.length - 1) return Pop();
            if (index < 0 || index >= this.length)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node node = FindByIndex(index);
            Node prev = node.prev;
            Node next = node.next;
            prev.next = next;
            next.prev = prev;
            node.prev = null;
            node.next = null;

            this.length--;
            return node;
        }
        //TODO Slice Method
        public DoublyLinkedList Slice(int start = 0, int? end = null)
        {   
            DoublyLinkedList newList = new DoublyLinkedList();

            if(end == null) end = this.length;

            while(start < end)
            {
                string currentValue = this.FindByIndex(start).value;
                newList.Push(currentValue);
                start++;
            }

            return newList;
            
        }

        //TODO Splice Method
    }
}