using Generics;

namespace Test.Generics
{
    public class TestSafeBox
    {

        [Fact]
        public void SafeBox_ShoudAddValueInt()
        {
            var TsafeBox = new SafeBox<int>(10);
            Assert.Equal(10, TsafeBox.Value);
        }

        [Fact]
         public void SafeBox_ShoudAddValueString()
        {
            var TsafeBox = new SafeBox<string>("Hello");
            Assert.Equal("Hello", TsafeBox.Value);
        }

        
        [Fact]
         public void SafeBox_ShoudAddValueBool()
        {
            var TsafeBox = new SafeBox<bool>(true);
            Assert.True(TsafeBox.Value);
        }
    

        [Fact]
        public void SafeBox_ShouldThrowIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SafeBox<string>(null));
        }
    }
}
