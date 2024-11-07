// <copyright file="BookTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Domain;

/// <summary>
/// Тесты для класса <see cref="Domain.Book"/>.
/// </summary>
[TestFixture]
public sealed class BookTests
{
    private static readonly Shelf Shelf = new ("Полка");

    private static readonly ISet<Author> Authors = new HashSet<Author>() { new ("Толстой", "Лев"), };

    [Test]
    public void Ctor_NullTitle_ExpectedArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => _ = new Book(null!, Shelf, Authors));
    }

    [Test]
    public void ChangeShelf_ValidData_Bool()
    {
        // arrange
        var book = new Book("Война и мир", Shelf, Authors);
        var shelf2 = new Shelf("Вторая полка");

        // act
        var result = book.ChangeShelf(shelf2);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True);
            Assert.That(Shelf.Books.Contains(book), Is.False);
        });
    }

    [Test]
    public void ChangeShelf_NullShelf_ExpectedException()
    {
        // arrange
        var book = new Book("Война и мир", Shelf, Authors);

        // act & assert
        Assert.Throws<ArgumentNullException>(() => book.ChangeShelf(null!));
    }

    [TestCaseSource(nameof(ValidAuthors))]
    public void ToString_AuthorCollection_Success(ISet<Author> authors, string title, string expected)
    {
        // arrange
        var book = new Book(title, Shelf, authors);

        // act
        var actual = book.ToString();

        // assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> ValidAuthors()
    {
        yield return new TestCaseData(
            new HashSet<Author>()
        { new ("Толстой", "Лев") }, "Анна Каренина",
            "Анна Каренина Толстой Лев");

        yield return new TestCaseData(
            new HashSet<Author>()
        { new ("Ильф", "Илья"), new ("Петров", "Евгений") }, "12 стульев",
            "12 стульев Ильф Илья, Петров Евгений");

        yield return new TestCaseData(
            new HashSet<Author>()
        { new ("Васильева", "Марина"), new ("Балакина", "Екатерина"), new ("Филипченко", "Константин") },
            "ИОСУ",
            "ИОСУ Васильева Марина, Балакина Екатерина, Филипченко Константин");
    }
}