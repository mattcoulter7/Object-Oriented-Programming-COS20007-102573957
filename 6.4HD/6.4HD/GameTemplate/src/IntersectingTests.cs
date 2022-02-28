using NUnit.Framework;
using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace TrafficController
{
    [TestFixture]
    public class IntersectingTests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [Test]
        public void RectangleIntersectionTL()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 180, 180, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 200, 200, 50, 50);

            Assert.IsTrue(rectangle1.IntersectsRectangle(rectangle2));
        }
        [Test]
        public void RectangleIntersectionTR()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 220, 180, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 200, 200, 50, 50);

            Assert.IsTrue(rectangle1.IntersectsRectangle(rectangle2));
        }
        [Test]
        public void RectangleIntersectionBL()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 180, 220, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 200, 200, 50, 50);

            Assert.IsTrue(rectangle1.IntersectsRectangle(rectangle2));
        }
        [Test]
        public void RectangleIntersectionBR()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 220, 220, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 200, 200, 50, 50);

            Assert.IsTrue(rectangle1.IntersectsRectangle(rectangle2));
        }
        [Test]
        public void RectangleInsideRectangleIntersects()
        {
            Rectangle rectangle1 = new Rectangle(Color.Blue, 200, 200, 50, 50);
            Rectangle rectangle2 = new Rectangle(Color.Blue, 150, 150, 100, 100);
            Assert.IsTrue(rectangle1.IntersectsRectangle(rectangle2));
        }
        [Test]
        public void RectangleIntersectsCircle()
        {

        }
        [Test]
        public void CircleIntersectsRectangle()
        {

        }
        [Test]
        public void CircleIntersectsCircle()
        {

        }
        [Test]
        public void LineIntersectsRectangle()
        {

        }
        [Test]
        public void LineIntersectsCircle()
        {

        }

    }
}