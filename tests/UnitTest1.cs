using compiler.front;

namespace tests
{
    
    public class UnitTest1
    {
        [Fact]
        public void TestScanner()
        {
            Scanner scanner = new Scanner("1*3+2");
            List<Token> tokens = scanner.scan();
            Assert.Equal(tokens.Count(), 5);
            
        }
    }
}