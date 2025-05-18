namespace Test.DataStructures
{
    // TODO: Enhance tests
    // TODO: Test the changing of capacity
    // TODO: Add more testing
    public class TestDynamicArray
    {
        [Fact]
        public void Add_ShouldIncreaseCount()
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(10);
            dynamicArray.Add(20);
            dynamicArray.Add(30);

            Assert.Equal(3, dynamicArray.Count);
            Assert.Equal(10, dynamicArray.Get(0));
            Assert.Equal(20, dynamicArray.Get(1));
            Assert.Equal(30, dynamicArray.Get(2));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void Get_ShouldThrow_WhenIndexOutOfBound(int index)
        {
            var dynamicArray = new DynamicArray<string>(10);
            dynamicArray.Add("hello");

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.Get(index));
        }

        [Fact]
        public void Set_ShouldUpdateValue()
        {
            var dynamicArray = new DynamicArray<string>();
            dynamicArray.Add("Jose");
            var oldCount = dynamicArray.Count;

            dynamicArray.Set(0, "Cristian");
            var newCount = dynamicArray.Count;

            Assert.Equal(oldCount, newCount);
            Assert.Equal("Cristian", dynamicArray.Get(0));
        }

        [Fact]
        public void InsertAt_ShouldInsertCorrectly()
        {
            var dynamicArray = new DynamicArray<string>();
            dynamicArray.Add("Jose");
            dynamicArray.Add("Jessica");

            dynamicArray.InsertAt(1, "Cristian");

            Assert.Equal(3, dynamicArray.Count);
            Assert.Equal("Jose", dynamicArray.Get(0));
            Assert.Equal("Cristian", dynamicArray.Get(1));
            Assert.Equal("Jessica", dynamicArray.Get(2));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(3)]
        public void InsertAt_ShouldThrow_WhenOutOfRange(int index)
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.InsertAt(index, 23));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void RemoveAt_ShouldThrow_WhenOutOfRange(int index)
        {
            var dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicArray.RemoveAt(index));
        }

        [Fact]
        public void RemoveAt_ShouldRemoveCorrectly()
        {
            var dynamicArray = new DynamicArray<string>();
            dynamicArray.Add("Marcelo");
            dynamicArray.Add("Alison");
            dynamicArray.Add("Mateo");

            dynamicArray.RemoveAt(1);

            Assert.Equal(2, dynamicArray.Count);
            Assert.Equal("Marcelo", dynamicArray.Get(0));
            Assert.Equal("Mateo", dynamicArray.Get(1));
        }

        [Fact]
        public void DynamicArray_EnsureCapacity()
        {
            var dynamicArray = new DynamicArray<string>(1);
            dynamicArray.Add("Jose");
            dynamicArray.Add("Cristian");
            dynamicArray.Add("Jessica");
            // When
            var Capacity = dynamicArray.Capacity;
            // Then
            Assert.True(Capacity == 4);
        }

    }
}