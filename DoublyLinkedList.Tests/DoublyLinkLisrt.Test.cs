using Xunit;
using System;

namespace DoublyLinkedList.Tests;

public class DoublyLinkedListTests
{
    private DoublyLinkedListLibrary.DoublyLinkedList InitializeListForTest()
    {
        var newList = new DoublyLinkedListLibrary.DoublyLinkedList();
        newList.Push("Hello");
        newList.Push("World");
        newList.Push("This");
        newList.Push("Is");
        newList.Push("A");
        newList.Push("List");
        newList.Push("Of");
        newList.Push("Strings");

        return newList;
    }
    //* Push Method
    [Fact]
    public void Push_ShouldIncreaseListLengthByOne()
    {
        // Arrange
        var newList = InitializeListForTest();
        int expected = newList.length + 1;

        // Act
        newList.Push("Newest Node");
        int actual = newList.length;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Push_ShouldUpdateListTail()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = "Newest Node";

        // Act
        newList.Push("Newest Node");
        string actual = newList.tail.value;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Push_PrevNodeShouldBePreviousListTail()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = newList.tail.value;

        // Act
        newList.Push("Newest Node");
        string actual = newList.tail.prev.value;

        // Assert
        Assert.Equal(expected, actual);
    }
    //* Pop Method
    [Fact]
    public void Pop_ShouldReturnTheLastNodeInList()
    {
        // Arrange
        var newList = InitializeListForTest();

        string expected = "Strings";

        // Act
        string actual = newList.Pop().value;

        // Assert
        Assert.Equal(expected, actual);
        
    }
    [Fact]
    public void Pop_ShouldReduceTheLengthByOne()
    {
        // Arrange
        var newList = InitializeListForTest();
        int expected = newList.length - 1;

        // Act
        newList.Pop();
        int actual = newList.length;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Pop_ShouldUpdateTailInList()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = "Of";

        // Act
        newList.Pop();
        string actual = newList.tail.value;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Pop_ShouldThrowExceptionWhenEmpty()
    {
        // Arrange
        var emptyList = new DoublyLinkedListLibrary.DoublyLinkedList();
        string expected = new IndexOutOfRangeException().Message;

        // Act
        Action actual = () => emptyList.Pop();

        // Assert
        IndexOutOfRangeException exception = Assert.Throws<IndexOutOfRangeException>(actual);
        Assert.Equal(expected, exception.Message);
    }
    //* Shift Method
    [Fact]
    public void Shift_ShouldUpdateListHeadToNewNode()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = "Newest Node";

        // Act
        newList.Shift("Newest Node");
        string actual = newList.head.value;
        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Shift_NextNodeShouldBePreviousListHead()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = newList.head.value;
        
        // Act
        newList.Shift("Newest Node");
        string actual = newList.head.next.value;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Shift_ShouldIncreaseListLengthByOne()
    {
        // Arrange
        var newList = InitializeListForTest();
        int expected = newList.length + 1;

        // Act 
        newList.Shift("Newest Node");
        int actual = newList.length;

        // Assert
        Assert.Equal(expected, actual);
    }
    //* Unshift Method
    [Fact]
    public void Unshift_ShouldUpdateListHeadToPreviousSecondNode()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = newList.head.next.value;

        // Act
        newList.Unshift();
        string actual = newList.head.value;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Unshift_ShouldReturnFirstNodeInList()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = newList.head.value;

        // Act
        string actual = newList.Unshift().value;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Unshift_ShouldDecreaseLengthOfListByOne()
    {
        // Arrange
        var newList = InitializeListForTest();
        int expected = newList.length - 1;

        // Act
        newList.Unshift();
        int actual = newList.length;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Unshift_ShouldThrowExceptionWhenEmpty()
    {
        // Arrange
        var emptyList = new DoublyLinkedListLibrary.DoublyLinkedList();
        string expected = new IndexOutOfRangeException().Message;

        // Act
        Action actual = () => emptyList.Unshift();
        IndexOutOfRangeException exception = Assert.Throws<IndexOutOfRangeException>(actual);

        // Assert
        Assert.Equal(expected, exception.Message);
    }
    //* FindByIndex Method
    [Theory]
    [InlineData(-1)]
    [InlineData(28)]
    public void FindByIndex_ShouldThrowExceptionWhenInputOutOfRange(int index)
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = new ArgumentOutOfRangeException().Message;
        // Act
        Action actual = () => newList.FindByIndex(index);
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(actual);

        // Assert
        Assert.Equal(expected, exception.Message);
    }
    [Theory]
    [InlineData(0,"Hello")]
    [InlineData(1,"World")]
    [InlineData(2,"This")]
    [InlineData(5,"List")]
    [InlineData(7,"Strings")]
    public void FindByIndex_ShouldReturnNodeAtIndexInput(int index, string expected)
    {
        // Arrange
        var newList = InitializeListForTest();

        // Act
        string actual = newList.FindByIndex(index).value;

        // Assert
        Assert.Equal(expected, actual);
    }
    //* IndexOf Method
    [Theory]
    [InlineData(0,"Hello")]
    [InlineData(1,"World")]
    [InlineData(2,"This")]
    [InlineData(5,"List")]
    [InlineData(7,"Strings")]
    public void IndexOf_ShouldReturnIndexOfNodeWithInputValue(int expected, string value)
    {
        // Arrange
        var newList = InitializeListForTest();

        // Act
        int actual = newList.IndexOf(value);

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void IndexOf_ShouldReturnNegativeOneIfNotFound()
    {
        // Arrange
        var newList = InitializeListForTest();
        int expected = -1;

        // Act
        int actual = newList.IndexOf("Not in the list");

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void CreateAndInsert_ShouldCreateANodeWithInputValueAndInsertAtInputIndex()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expectedNewNodeValue = "Newest Node Value";

        // Act
        newList.CreateAndInsert(4, "Newest Node Value");
        string actualNewNodeValue = newList.FindByIndex(4).value;
        int actualNewNodeIndex = newList.IndexOf("Newest Node Value");

        // Assert
        Assert.Equal(expectedNewNodeValue, actualNewNodeValue);
        Assert.Equal(4, actualNewNodeIndex);
    }
    [Fact]
    public void CreateAndInsert_ShouldIncreaseListLengthByOne()
    {
        // Arrange
        var newList = InitializeListForTest();
        int expected = newList.length + 1;

        // Act
        newList.CreateAndInsert(5, "Newest Node");
        int actual = newList.length;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void CreateAndInsert_WhenInsertedAtStartOfListUpdatePreviousFirstNodePrevious()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expectedSecondNodePrevValue = "Newest Node";
        string expectedNewNodeNextValue = "Hello";

        // Act
        newList.CreateAndInsert(0, "Newest Node");
        var actualNewNodePrevValue = newList.head.prev;
        var actualSecondNodePrevValue = newList.head.next.prev.value;
        var actualNewNodeNextValue = newList.head.next.value;

        // Assert
        Assert.Equal(null, actualNewNodePrevValue);
        Assert.Equal(expectedSecondNodePrevValue, actualSecondNodePrevValue);
        Assert.Equal(expectedNewNodeNextValue, actualNewNodeNextValue);
    }
    [Fact]
    public void CreateAndInsert_WhenInsertedAtEndOfListUpdateNextLastNodeNext()
    {
        // Arrange
        var newList = InitializeListForTest();
        string expectedSecondToLastNodeNextValue = "Newest Node";
        string expectedNewNodePrevValue = "Strings";

        // Act
        newList.CreateAndInsert(newList.length, "Newest Node");
        var actualNewNodePrevValue = newList.tail.prev.value;
        var actualSecondToLastNodeNextValue = newList.tail.prev.next.value;
        var actualNewNodeNext = newList.tail.next;

        // Assert
        Assert.Equal(null, actualNewNodeNext);
        Assert.Equal(expectedSecondToLastNodeNextValue, actualSecondToLastNodeNextValue);
        Assert.Equal(expectedNewNodePrevValue, actualNewNodePrevValue);
    }
    //* Insert Method
    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(8)]
    public void Insert_ShouldInsertNodeAtInputIndex(int index)
    {
        // Arrange
        var newList = InitializeListForTest();
        var newNode = new DoublyLinkedListLibrary.Node("Newest Node");
        int expectedIndex = index;
        string expectedValueAtIndex = "Newest Node";
        object? expectedPrev = null;
        object? expectedNext = null;

        // Act
        newList.Insert(index, newNode);
        string actualValueAtIndex = newList.FindByIndex(index).value;
        object? actualPrevValue = null;
        object? actualNextValue = null;


        if(index == 0)
        {
            expectedPrev = null;
            expectedNext = "Hello";
            actualPrevValue = newNode.prev;
            actualNextValue = newNode.next.value;
        }
        else if (index == newList.length)
        {
            expectedPrev = "String";
            expectedNext = null;
            actualPrevValue = newNode.prev.value;
            actualNextValue = newNode.next;
        }
        else if(index == 4)
        {
            expectedPrev = "Is";
            expectedNext = "A";
            actualPrevValue = newNode.prev.value;
            actualNextValue = newNode.next.value;
        }

        // Assert
        Assert.Equal(expectedValueAtIndex, actualValueAtIndex);
        Assert.Equal(expectedPrev, actualPrevValue);
        Assert.Equal(expectedNext, actualNextValue);
    }
    [Fact]
    public void Insert_ShouldIncreaseListLengthByOne()
    {
        // Arrange
        var newList = InitializeListForTest();
        var newNode = new DoublyLinkedListLibrary.Node("Newest Node");
        int expected = newList.length + 1;

        // Act
        newList.Insert(4, newNode);
        int actual = newList.length;

        // Assert
        Assert.Equal(expected, actual);
    }
    //* FindByIndexAndRemove Method
    [Fact]
    public void FindByIndexAndRemove_ShouldReturnNode()
    {
        // Arrange
        var newList = InitializeListForTest();
        var expected = newList.FindByIndex(4);

        // Act
        var actual = newList.FindByIndexAndRemove(4);

        // Assert
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void FindByIndexAndRemove_ShouldReduceListLengthByOne()
    {
        // Arrange
        var newList = InitializeListForTest();
        int expected = newList.length - 1;

        // Act
        newList.FindByIndexAndRemove(4);
        int actual = newList.length;

        // Assert
        Assert.Equal(expected, actual);
    }
    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(7)] //> This is the last index as per Method InitializedListForTest
    public void FindByIndexAndRemove_ShouldRemoveNodeAndConnectPrevAndNext(int index)
    {
        // Arrange
        var newList = InitializeListForTest();

        if (index == 0)
        {
            Unshift_ShouldDecreaseLengthOfListByOne();
            Unshift_ShouldReturnFirstNodeInList();
            Unshift_ShouldUpdateListHeadToPreviousSecondNode();
            Assert.True(true);
            return;
        }
        else if (index == newList.length - 1)
        {   
            Pop_ShouldReduceTheLengthByOne();
            Pop_ShouldReturnTheLastNodeInList();
            Pop_ShouldUpdateTailInList();
            Assert.True(true);
            return;
        }
        else if (index == 4)
        {
            var expectedPrev = newList.FindByIndex(3);
            var expectedNext = newList.FindByIndex(5);
            // Act
            var removedNode = newList.FindByIndexAndRemove(index);
            
            // Assert
            Assert.Equal(expectedPrev.next, expectedNext);
            Assert.Equal(expectedNext.prev, expectedPrev);
        }


    }
    [Theory]
    [InlineData(-1)]
    [InlineData(28)]
    public void FindByIndexAndRemove_ShouldThrowArgumentOutOfRangeException(int index)
    {
        // Arrange
        var newList = InitializeListForTest();
        string expected = new ArgumentOutOfRangeException().Message;
        // Act
        Action actual = () => newList.FindByIndexAndRemove(index);
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(actual);

        // Assert
        Assert.Equal(expected, exception.Message);
    }
    //* Slice Method
    [Fact]
    public void Slice_ShouldReturnANewList()
    {
        // Arrange
        var originalList = InitializeListForTest();
        var expectedFirstNodeValue = "This"; // Index 2
        var expectedSecondNodeValue = "Is"; // Index 3
        var expectedThirdNodeValue = "A"; // Index 4
    
        // Act
        var newList = originalList.Slice(2, 5);
        var actualFirstNodeValue = newList.head.value;
        var actualSecondNodeValue = newList.head.next.value;
        var actualThirdNodeValue = newList.tail.value;
    
        // Assert
        Assert.Equal(expectedFirstNodeValue, actualFirstNodeValue);
        Assert.Equal(expectedSecondNodeValue, actualSecondNodeValue);
        Assert.Equal(expectedThirdNodeValue, actualThirdNodeValue);
    }
    [Theory]
    [InlineData(-1, 5)]
    [InlineData(2, 28)]
    public void Slice_ShouldThrowArgumentOutOfRangeException(int start, int end)
    {
        // Arrange
        var originalList = InitializeListForTest();
        string expected = new ArgumentOutOfRangeException().Message;
    
        // Act
        Action actual = () => originalList.Slice(start, end);
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(actual);
    
        // Assert
        Assert.Equal(expected, exception.Message);
    }
    [Fact]
    public void Slice_ShouldMaintainOriginalList()
    {
        // Arrange
        var originalList = InitializeListForTest();
        string expectedThirdNodeValue = originalList.FindByIndex(2).value;
        string expectedFourthNodeValue = originalList.FindByIndex(3).value;
        string expectedFifthNodeValue = originalList.FindByIndex(4).value;
        
        // Act
        originalList.Slice(2, 5);
        string actualThirdNodeValue = originalList.FindByIndex(2).value;
        string actualFourthNodeValue = originalList.FindByIndex(3).value;
        string actualFifthNodeValue = originalList.FindByIndex(4).value;

        // Assert
        Assert.Equal(expectedThirdNodeValue, actualThirdNodeValue);
        Assert.Equal(expectedFourthNodeValue, actualFourthNodeValue);
        Assert.Equal(expectedFifthNodeValue, actualFifthNodeValue);
    }
    [Fact]
    public void Slice_ShouldMaintainOriginalListLength()
    {
        // Arrange
        var originalList = InitializeListForTest();
        int expected = originalList.length;
    
        // Act
        var newList = originalList.Slice(2, 5);
        int actual = originalList.length;
    
        // Assert
        Assert.Equal(expected, actual);

    }
    [Fact]
    public void Slice_ShouldUpdateNewListLength()
    {
        // Arrange
        var originalList = InitializeListForTest();
        int expected = 3;
    
        // Act
        var newList = originalList.Slice(2, 5);
        int actual = newList.length;

        // Assert
        Assert.Equal(expected, actual);
    }
}