using Kpi.lab1;
using NUnit.Framework;

namespace Kpi.lab2;

 [TestFixture]
    public class CustomQueueTests
    {
        [Test]
        public void NewQueue_IsEmpty()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            Assert.That(queue.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Add_SingleItem()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            queue.Add(5);

            Assert.That(queue.Count(), Is.EqualTo(1));
            Assert.IsTrue(queue.Contains(5));
        }

        [Test]
        public void Add_MultipleItems()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            queue.Add(3);
            queue.Add(7);
            queue.Add(10);

            Assert.That(queue.Count(), Is.EqualTo(3));
            Assert.IsTrue(queue.Contains(3));
            Assert.IsTrue(queue.Contains(7));
            Assert.IsTrue(queue.Contains(10));
        }

        [Test]
        public void Remove_SingleItem()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Add("Apple");

            queue.Remove("Apple");

            Assert.That(queue.Count(), Is.EqualTo(0));
            Assert.IsFalse(queue.Contains("Apple"));
        }

        [Test]
        public void Remove_MultipleItems()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Add("Orange");
            queue.Add("Banana");
            queue.Add("Grapes");

            queue.Remove("Banana");
            queue.Remove("Grapes");

            Assert.That(queue.Count(), Is.EqualTo(1));
            Assert.IsTrue(queue.Contains("Orange"));
            Assert.IsFalse(queue.Contains("Banana"));
            Assert.IsFalse(queue.Contains("Grapes"));
        }

        [Test]
        public void Clear_EmptyQueue()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            queue.Clear();

            Assert.That(queue.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Peek_EmptyQueue_ThrowsException()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void Peek_NonEmptyQueue_ReturnsFirstItem()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Add(5);
            queue.Add(10);

            var peekedItem = queue.Peek();

            Assert.That(peekedItem, Is.EqualTo(5));
            Assert.That(queue.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Contains_ExistingItem_ReturnsTrue()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Add("Test");

            Assert.IsTrue(queue.Contains("Test"));
        }

        [Test]
        public void Contains_NonExistingItem_ReturnsFalse()
        {
            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Add("Sample");

            Assert.IsFalse(queue.Contains("Test"));
        }

        [Test]
        public void Count_EmptyQueue()
        {
            CustomQueue<int> queue = new CustomQueue<int>();

            Assert.That(queue.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Count_NonEmptyQueue()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Add(3);
            queue.Add(7);

            Assert.That(queue.Count(), Is.EqualTo(2));
        }

        [Test]
        public void ElementAt_ExistingIndex()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Add(1);
            queue.Add(2);
            queue.Add(3);

            var element = queue.ElementAt(1);

            Assert.That(element, Is.EqualTo(2));
        }

        [Test]
        public void ElementAt_OutOfRangeIndex_ThrowsException()
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Add(1);
            queue.Add(2);
            queue.Add(3);

            Assert.Throws<IndexOutOfRangeException>(() => queue.ElementAt(3));
        }
    }