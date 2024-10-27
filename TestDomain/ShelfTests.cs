// <copyright file="ShelfTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace TestDomain
{
    using System;
    using System.Xml.Linq;
    using Domain;

    /// <summary>
    /// Тесты для клсса <see cref="Domain.Shelf"/>.
    /// </summary>
    public sealed class ShelfTests
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

        /// <summary>
        /// Тесты на метод Equals.
        /// </summary>
        /// <param name="name1"> Название первой полки. </param>
        /// <param name="name2"> Название второй полки. </param>
        /// <param name="expected"> Результат метода Equals.</param>
        [TestCase("1", "1", true)]
        [TestCase("1", "2", false)]
        public void Equals_ValidData_Success(string name1, string name2, bool expected)
        {
            // arrange
            var shelf1 = new Shelf(name1);
            var shelf2 = new Shelf(name2);

            // act
            var actual = shelf1.Equals(shelf2);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddBook_ValidData_Success()
        {
            // arrange
            var shelf = new Shelf("Первая полка");
            var author = new Author("Толстой", "Лев");
            var expected = 1;

            // act
            var book = new Book("Война и мир", shelf, author); // AddShelf(book)
            var actual = shelf.Books.Count;

            // assert
            Assert.That(actual == expected, Is.True);
        }
    }
}