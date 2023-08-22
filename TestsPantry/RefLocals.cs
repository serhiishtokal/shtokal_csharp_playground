using Newtonsoft.Json.Linq;

namespace TestsPantry
{
    public class RefLocals
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestRefLocals()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int index = 2;
            int newValue = 10;

            Console.WriteLine(string.Join(", ", numbers)); // Output: 1, 2, 3, 4, 5

            // Declare a ref local that holds a reference to the element at index
            ref int element = ref GetElement(numbers, index);
            element = newValue;


            Console.WriteLine(string.Join(", ", numbers)); // Output: 1, 2, 10, 4, 5

            Assert.That(newValue, Is.EqualTo(numbers[index]));
        }

        private ref int GetElement(int[] array, int index)
        {
            return ref array[index];
        }
    }
}