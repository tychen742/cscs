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
        Assert.AreEqual(res, 20);           // make sure the answers match
    }

    [TestMethod]
    public void Test_SubtractMethod()
    {
        BasicMath bm = new BasicMath();
        double res = bm.Subtract(10, 10);
        Assert.AreEqual(res, 0);
    }

    [TestMethod]
    public void Test_DivideMethod()
    {
        BasicMath bm = new BasicMath();
        double res = bm.divide(10, 5);
        Assert.AreEqual(res, 2);
    }

    [TestMethod]
    public void Test_MultiplyMethod()
    {
        BasicMath bm = new BasicMath();
        double res = bm.Multiply(10, 10);
        Assert.AreEqual(res, 100);
    }
}