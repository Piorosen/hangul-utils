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
            Assert.IsFalse("안녕하세요".KoreaContains("치킨입니다"), "기본적인 비교도 안됨");
        }

        [TestMethod]
        public void TestHanguleFirst()
        {
            Assert.IsFalse("안녕하세요".KoreaContains("안김"), "기본적인 비교도 안됨");
        }

        [TestMethod]
        public void TestHanguleMiddle()
        {
            Assert.IsFalse("안녕하세요".KoreaContains("하ㄱ"), "기본적인 비교도 안됨");
        }

        [TestMethod]
        public void TestHanguleLast()
        {
            Assert.IsFalse("안녕하세요".KoreaContains("요ㅊ"), "기본적인 비교도 안됨");
        }
        [TestMethod]
        public void TestComponent()
        {
            Assert.IsFalse("안녕하세요".KoreaContains("ㅇㄴㅎㅅㄷ"), "기본적인 비교도 안됨");
        }
        [TestMethod]
        public void TestHanguleComponentPElem()
        {
            Assert.IsFalse("안녕하세요".KoreaContains("안ㄷ"), "기본적인 비교도 안됨");
        }


    }
}
