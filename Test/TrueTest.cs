using Microsoft.VisualStudio.TestTools.UnitTesting;

using hangul_utils;

namespace Test
{
    [TestClass]
    public class TrueTest
    {
        [TestMethod]
        public void TestHanguleBasis()
        {
            Assert.IsTrue("안녕하세요".KoreaContains("안녕하세요"), "기본적인 비교도 안됨");
        }

        [TestMethod]
        public void TestHanguleMore()
        {
            Assert.IsTrue("abc 헬로웇".KoreaContains("c ㅎ"), "기본적인 비교도 안됨");
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
        [TestMethod]
        public void TestHanguleComponentPElem2()
        {
            Assert.IsTrue("안녕하세요".KoreaContains("안녀하"), "기본적인 비교도 안됨");
        }

        [TestMethod]
        public void TestHanguleComponentPElem3()
        {
            Assert.IsTrue("테스트인 한국어 문법".KoreaContains("ㅌㅅㅌㅇ ㅎㄱㅇ ㅁㅂ"), "기본적인 비교도 안됨");
        }
    }
}
