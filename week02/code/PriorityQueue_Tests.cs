using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with varying priorities and dequeue.
    // Expected Result: Highest priority item is removed and returned.
    // Defect(s) Found: Dequeue does not remove the item; it only returns value. Also, comparison logic in loop is incorrect (misses last item).
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Low", 1);
        queue.Enqueue("Medium", 5);
        queue.Enqueue("High", 10);

        var result = queue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority. Dequeue should return the first one added.
    // Expected Result: FIFO among items with equal highest priority.
    // Defect(s) Found: Same as above plus incorrect handling of tie-breaking by order of arrival.
    public void TestPriorityQueue_EqualPriorityFIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("FirstHigh", 5);
        queue.Enqueue("SecondHigh", 5);
        queue.Enqueue("Low", 1);

        var result = queue.Dequeue();

        Assert.AreEqual("FirstHigh", result);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Exception thrown with specific message.
    // Defect(s) Found: None if exception is properly thrown.
    public void TestPriorityQueue_EmptyThrowsException()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple and Dequeue all to ensure queue behaves correctly.
    // Expected Result: Correct order based on priority and FIFO among equals.
    // Defect(s) Found: Item is not removed from list in Dequeue.
    public void TestPriorityQueue_CompleteDequeueSequence()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 2);
        queue.Enqueue("D", 3); 

        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("D", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
        Assert.AreEqual("A", queue.Dequeue());
    }
}