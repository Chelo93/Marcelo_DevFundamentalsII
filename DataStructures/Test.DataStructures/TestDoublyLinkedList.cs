namespace Test.DataStructures
{
    public class TestDoublyLinkedList
    {
        [Fact]
        public void AddFirst_ShouldInsertAtFront()
        {
            var list = new DoublyLinkedList<string>();
            list.AddFirst("Carlos");
            list.AddFirst("Sergio");
            list.AddFirst("Fabricio");

            var result = list.Get(0);

            Assert.Equal("Fabricio", result);
        }

        [Fact]
        public void AddLast_ShouldInsertAtEnd()
        {
            var list = new DoublyLinkedList<string>();
            list.AddLast("Carlos");
            list.AddLast("Sergio");
            list.AddLast("Fabricio");

            var result = list.Get(2);

            Assert.Equal("Fabricio", result);
        }

        [Fact]
        public void ToReversedArray_ShouldReturnCorrectReverseOrder()
        {
            // TODO: Complete the test
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            var array = list.ToReversedArray();
            Assert.Equal([3, 2, 1], array);
        }

        [Fact]
        public void Get_ShouldReturnCorrectElement()
        {
            // TODO: Complete the test
            var list = new DoublyLinkedList<char>();
            list.AddFirst('A');
            list.AddLast('B');
            list.AddLast('C');

            Assert.Equal('A', list.Get(0));
            Assert.Equal('B', list.Get(1));
            Assert.Equal('C', list.Get(2));
        }

        [Fact]
        public void Get_ShouldThrow_WhenIndexInvalid()
        {
            // TODO: Complete test
            var list = new DoublyLinkedList<char>();
            list.AddFirst('A');
            list.AddLast('B');
            list.AddLast('C');

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Get(-1));
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfValueExists()
        {
            // TODO: Complete test
            var list = new DoublyLinkedList<char>();
            list.AddFirst('A');
            list.AddLast('B');
            list.AddLast('C');
            Assert.True(list.Contains('B'));
        }

        [Fact]
        public void Remove_ShouldRemoveExistingValue()
        {
            // TODO: Complete test
            var list = new DoublyLinkedList<char>();
            list.AddFirst('A');
            list.AddLast('B');
            list.AddLast('C');

            var result = list.TryRemove('B');

            Assert.True(result);
            Assert.Equal(2, list.Count);
            Assert.Equal(['A', 'C'], list.ToArray());
        }

        [Fact]
        public void TryRemove_ShouldReturnFalseIfNotFound()
        {
            // TODO: Complete test
            var list = new DoublyLinkedList<char>();
            list.AddFirst('A');
            list.AddLast('B');
            list.AddLast('C');

            var result = list.TryRemove('D');

            Assert.False(result);
            Assert.Equal(3, list.Count);
            Assert.Equal(['A', 'B', 'C'], list.ToArray());
        }

        // OPTIONAL: Add more tests if wanted
        [Fact]
        public void ToArray_ShouldReturnCorrectOrder()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);

            var array = list.ToArray();
            Assert.Equal([1, 2, 3], array);
        }

        [Fact]
        public void InsertAt_ShouldInsertAtCorrectPosition()
        {
            var list = new DoublyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(3);
            list.AddLast(4);
            list.InsertAt(1, 2);

            var result = list.ToArray();
            Assert.Equal([1, 2, 3, 4], result);
        }

    }
}
