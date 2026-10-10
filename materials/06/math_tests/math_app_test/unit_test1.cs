using SomeMath;

namespace MathAppTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Test_AddMethod()
    {
        BasicMath bm = new BasicMath();
        double res = bm.Add(10, 10);
        Assert.AreEqual(20, res);
    }

    [TestMethod]
    public void Test_SubtractMethod()
    {
        BasicMath bm = new BasicMath();
        double res = bm.Subtract(10, 10);
        Assert.AreEqual(0, res);
    }

    [TestMethod]
    public void Test_DivideMethod()
    {
        BasicMath bm = new BasicMath();
        double res = bm.Divide(10, 5);
        Assert.AreEqual(2, res);
    }

    [TestMethod]
    public void Test_MultiplyMethod()
    {
        BasicMath bm = new BasicMath();
        double res = bm.Multiply(10, 10);
        Assert.AreEqual(100, res);
    }
}
