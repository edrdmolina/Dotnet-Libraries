# Doubly Linked List

A Double Linked List written in C# using dotnet 6. Each method implemented is based on the JavaScript Array methods.

<br>

## Why?
<hr>
To sharpen my basic skills on the C# language and unit testing with xUnit using the dotnet framework.
The reason I chose JavaScript array methods is because JavaScript is already a language I am familiar with.

<br>

## Implementation
<hr>

The Double Linked List consist of 4 parts:

- Individual Nodes:
    - Each individual Node consists of 3 parts.
        - Value: the node stores string types.
        - Prev: stores a pointer to the node ahead of current node.
        - Next: stores a pointer to the node ahead of current node.

                // Node Constructor
                public Node(string value)
                {
                    this.value = value;
                    this.prev = null;
                    this.next = null;
                }

- Head Pointer:
    - stores a pointer to the node first in the list.
- Tail Pointer:
    - stores a pointer to the node last in the list.
- length value:
    - Keeps track of how many nodes are connected within the list.

            // Double Linked List Constructor
            public DoublyLinkedList()
            {
                this.length = 0;
                this.head = null;
                this.tail = null;
            }

## Methods
<hr>

## Push
Creates a new node and inserts it at the end of the list.

#### Syntax

    DoublyLinkedList.Push(string value);

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "World" -> <- "!" -> null

<br>

## Pop
Removes the last node in the list and returns the node.

#### Syntax

    DoublyLinkedList.Pop();

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "World" -> <- "!" -> null

    var poppedNode = newList.Pop() // Returns Node with "!" value.

    // newList now includes: null <- "Hello" -> <- "World" -> null

<br>

## Shift
Creates a new node and inserts it at the beginning of the list.

#### Syntax

    DoublyLinkedList.Shift(string value);

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Shift("Hello"); // Inserts value at the end of the list.
    newList.Shift("World"); // Inserts value at the end of the list.
    newList.Shift("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "!" -> <- "World" -> <- "Hello" -> null

<br>

## Unshift
Removes the first node in the list and returns the node.

#### Syntax

    DoublyLinkedList.Unshift();

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "World" -> <- "!" -> null

    var unshiftedNode = newList.Unshift() // Returns Node with "Hello" value.

    // newList now includes: null <- "World" -> <- "!" -> null

<br>

## FindByIndex
Returns Node located at the input index.

#### Syntax

    DoublyLinkedList.FindByIndex(int index);

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "World" -> <- "!" -> null

    var node = newList.FindByIndex(1) // Returns Node with "World" value.

<br>

## IndexOf
Returns index of Node with input value.

#### Syntax

    DoublyLinkedList.IndexOf(string value);

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "World" -> <- "!" -> null

    var index = newList.IndexOf("World") // Returns Node at index 1.

    var indexNotFound = newList.IndexOf("world") // Returns -1 indicating not found.

<br>

## CreateAndInsert
Creates a new Node and inserts the node into the list at the specified index.

#### Syntax

    DoublyLinkedList.CreateAndInsert(int index, string value);

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "World" -> <- "!" -> null

    newList.CreateAndInsert(1, "Doomed") // Creates Node with Doomed value and inserts into newList at index 1.

    // newList now includes: null <- "Hello" -> <- "Doomed -> <- "World" -> <- "!" -> null

<br>

## Insert
Inserts a given Node into the input index.

#### Syntax

    DoublyLinkedList.Insert(int index, Node node);

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "World" -> <- "!" -> null

    Node newNode = new Node("Doomed"); // Creates Node with Doomed value

    newList.Insert(1, newNode) // Inserts newNode into newList at index 1.

    // newList now includes: null <- "Hello" -> <- "Doomed -> <- "World" -> <- "!" -> null

<br>

## FindByIndexAndRemove
Removes Node at given index

#### Syntax

    DoublyLinkedList.FindByIndexAndRemove(int index);

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "World" -> <- "!" -> null

    newList.FindByIndexAndRemove(1) // Removes Node with value of World

    // newList now includes: null <- "Hello" -> <- "!" -> null

<br>

## Slice
Returns a new Double Linked List with a copy of Nodes with the given Start and end indexes while keeping the original list untouched.

#### Syntax

    DoublyLinkedList.Slice(int start = 0, int end = null);

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("Doomed"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    // newList now includes: null <- "Hello" -> <- "Doomed" -> <- "World" -> <- "!" -> null

    var copyOfList = newList.Slice() // Returns an identical copy of list.

    var copyOfList = newList.Slice(1) // Returns null <- "Doomed" -> <- "World" -> <- "!" -> null

    var copyOfList = newList.Slice(1, 2) // Returns null <- "Doomed" -> <- "World" -> null

<br>

## PrintList
Prints a table of the entire list in order from beginning to end to the Console.

#### Syntax

    DoublyLinkedList.PrintList();

#### Example

    var newList = new DoublyLinkedList(); // Returns an empty list.

    newList.Push("Hello"); // Inserts value at the end of the list.
    newList.Push("Doomed"); // Inserts value at the end of the list.
    newList.Push("World"); // Inserts value at the end of the list.
    newList.Push("!"); // Inserts value at the end of the list.

    newList.PrintList();

    /* Expected output to Console.

    Index   Value
    0       Hello
    1       Doomed
    2       World
    3       !
    
    */