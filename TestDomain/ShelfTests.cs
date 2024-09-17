// <copyright file="ShelfTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace TestDomain
{
    using Domain;

    /// <summary>
    /// Тесты для клсса <see cref="Domain.Shelf"/>.
    /// </summary>
    public class ShelfTests
    {
        /// <summary>
        /// Тест на ToString().
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var expected = "Тестовая полка";
            var shelf = new Shelf(expected);

            // act
            var actual = shelf.ToString();

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Тест на конструктор с параметром <see langword="null"/>.
        /// </summary>
        [Test]
        public void Ctor_NullName_ExpectedException()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new Shelf(null!));
        }
    }
}