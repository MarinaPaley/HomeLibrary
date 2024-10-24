// <copyright file="BookTests.cs" company="��������� �.�.">
// Copyright (c) ��������� �.�.. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Domain;

/// <summary>
/// ����� ��� ������ <see cref="Domain.Book"/>.
/// </summary>
[TestFixture]
public sealed class BookTests
{
    private static readonly Shelf Shelf = new ("�����");

    private static readonly ISet<Author> Authors = new HashSet<Author>() { new ("�������", "���"), };

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
        var book = new Book("����� � ���", Shelf, Authors);
        var shelf2 = new Shelf("������ �����");

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
        var book = new Book("����� � ���", Shelf, Authors);

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
        { new ("�������", "���") }, "���� ��������",
            "���� �������� ������� ���");

        yield return new TestCaseData(
            new HashSet<Author>()
        { new ("����", "����"), new ("������", "�������") }, "12 �������",
            "12 ������� ���� ����, ������ �������");

        yield return new TestCaseData(
            new HashSet<Author>()
        { new ("���������", "������"), new ("��������", "���������"), new ("����������", "����������") },
            "����",
            "���� ��������� ������, �������� ���������, ���������� ����������");
    }
}