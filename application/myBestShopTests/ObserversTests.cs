using Microsoft.VisualStudio.TestTools.UnitTesting;
using myBestShop.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBestShopTests
{
    [TestClass]
    public class ObserversTests
    {
        class TestObserver_1 : Observer
        {
            public static string TAG = "observer_test_tag_1";
            public static string Answer = "Result complete";
            public void handleResult<ResultT>(Result<ResultT> result) where ResultT : class
            {
                if (result == null || result.isLoading || result.isError)
                {
                    Assert.Fail("Inappropriate result");
                    return;
                }

                Assert.IsTrue(result.data.Equals("Result complete"));
            }
        }

        class TestObserver_2 : Observer
        {
            public static string TAG = "observer_test_tag_2";
            public static string Answer = "Result complete";
            public void handleResult<ResultT>(Result<ResultT> result) where ResultT : class
            {
                if (result == null || result.isLoading || result.isError)
                {
                    Assert.Fail("Inappropriate result");
                    return;
                }

                Assert.IsFalse(result.data.Equals(Answer));
            }
        }

        class TestObserver_3 : Observer
        {
            public static string TAG = "observer_test_tag_3";
            public static string Answer = "Result complete";
            public void handleResult<ResultT>(Result<ResultT> result) where ResultT : class
            {
                if (result == null || result.isLoading != true)
                {
                    Assert.Fail("Inappropriate result on TestObserver_3");
                }
            }
        }

        class _User
        {
            public int id;
            public _User(int id)
            {
                this.id = id;
            }
        }

        class TestObserver_4 : Observer
        {
            public static string TAG = "observer_test_tag_4";
            public static string Answer = "Result complete";
            public void handleResult<ResultT>(Result<ResultT> result) where ResultT : class
            {
                if (result == null || result.isLoading || result.isError)
                {
                    Assert.Fail("Inappropriate status");
                }

                Assert.AreEqual(new _User(5).ToString(), result.data.ToString());
            }
        }

        [TestMethod]
        public void Observer_testStringObserver()
        {
            ObservableStorage.initialize();
            var observer = new TestObserver_1();
            var observable = new Observable<String>();
            observable.addObserver(observer, TestObserver_1.TAG);

            observable.notify(new Result<string> { data = TestObserver_1.Answer, exception = null, isLoading = false }, TestObserver_1.TAG);
        }

        [TestMethod]
        public void Observer_testStringObserver_notEquals()
        {
            ObservableStorage.initialize();
            var observer = new TestObserver_2();
            var observable = new Observable<String>();
            observable.addObserver(observer, TestObserver_2.TAG);

            observable.notify(new Result<string> { data = TestObserver_2.Answer, exception = null, isLoading = false }, "Not appropriate string");
        }

        [TestMethod]
        public void Observer_testObserver_loading()
        {
            ObservableStorage.initialize();
            var observer = new TestObserver_3();
            var observable = new Observable<String>();
            observable.addObserver(observer, TestObserver_3.TAG);

            observable.notify(new Result<string> { data = TestObserver_3.Answer, exception = null, isLoading = true }, TestObserver_3.TAG);
        }

        [TestMethod]
        public void Observer_testObserver_complexObject()
        {
            ObservableStorage.initialize();
            var observer = new TestObserver_4();
            var observable = new Observable<_User>();
            observable.addObserver(observer, TestObserver_4.TAG);

            observable.notify(new Result<_User> { data = new _User(5), exception = null, isLoading = false }, TestObserver_4.TAG);
        }
    }
}
