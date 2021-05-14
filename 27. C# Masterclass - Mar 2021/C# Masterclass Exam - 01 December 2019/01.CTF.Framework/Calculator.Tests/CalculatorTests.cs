namespace Calculator.Tests
{
    using CTF.Framework.Asserts;
    using CTF.Framework.Attributes;

    [CTFTestClassAttribute]
    public class CalculatorTests
    {
        [CTFTestMethodAttribute]
        public void ShouldReturnTrueWhenTwoIntegersAreEqual()
        {
            CTFAssert.AreEqual(1, 1);
        }

        [CTFTestMethodAttribute]
        public void ShouldReturnFalseWhenTwoIntegersNotAreEqual()
        {
            CTFAssert.AreEqual(1, 2);
        }

        [CTFTestMethodAttribute]
        public void ShouldReturnTrueWhenTwoIntegersAreNotEqual()
        {
            CTFAssert.AreNotEqual(1, 2);
        }

        [CTFTestMethodAttribute]
        public void ShouldReturnTrueWhenTwoStringsAreEqual()
        {
            CTFAssert.AreEqual("some text", "some text");
        }

        [CTFTestMethodAttribute]
        public void ShouldReturnTrueWhenTwoObjectsAreEqual()
        {
            var obj = new object();

            CTFAssert.AreEqual(obj, obj);
        }

        [CTFTestMethodAttribute]
        public void ShouldReturnTrueWhenTwoObjectsAreNotEqual()
        {
            var obj1 = new object();
            var obj2 = new object();

            CTFAssert.AreNotEqual(obj1, obj2);
        }
    }
}