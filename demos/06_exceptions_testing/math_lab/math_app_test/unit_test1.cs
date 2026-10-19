using SomeMath;             ///// we want to talk to the BasicMath class

namespace MathAppTest;      ///// generated when creating project

[TestClass]                 ///// specify the UNIT (class) to be tested
public class UnitTest1
{
    [TestMethod]            ///// specify the UNIT (method) to be tested
    public void Test_AddMethod()
    {
        BasicMath bm = new BasicMath();     // create instance
        double res = bm.Add(10, 10);        // run the method
        Assert.AreEqual(20, res);           // make sure the answers match
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
