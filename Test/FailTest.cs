using Microsoft.VisualStudio.TestTools.UnitTesting;

using hangul_utils;

namespace Test
{
    [TestClass]
    public class FailTest
    {
        [TestMethod]
        public void TestHanguleBasis()
        {
            Assert.IsTrue("안녕하세요".KoreaContains("안녕하세요"), "기본적인 비교도 안됨");
        }

        [TestMethod]
        public void TestHanguleFirst()
        {
            Assert.IsTrue("안녕하세요".KoreaContains("안녕"), "기본적인 비교도 안됨");
        }

        [TestMethod]
        public void TestHanguleMiddle()
        {
            Assert.IsTrue("안녕하세요".KoreaContains("하세"), "기본적인 비교도 안됨");
        }

        [TestMethod]
        public void TestHanguleLast()
        {
            Assert.IsTrue("안녕하세요".KoreaContains("세요"), "기본적인 비교도 안됨");
        }
        [TestMethod]
        public void TestComponent()
        {
            Assert.IsTrue("안녕하세요".KoreaContains("ㅇㄴㅎㅅㅇ"), "기본적인 비교도 안됨");
        }
        [TestMethod]
        public void TestHanguleComponentPElem()
        {
            Assert.IsTrue("안녕하세요".KoreaContains("안ㄴ하"), "기본적인 비교도 안됨");
        }
    }
}
