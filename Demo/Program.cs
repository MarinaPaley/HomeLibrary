// <copyright file="Program.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace Demo
{
    using System;
    using Domain;

    /// <summary>
    /// Точка входа.
    /// </summary>
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var shelf = new Shelf("Первая полка");
            var author = new Author("Толстой", "Лев");
            var book1 = new Book("Война и мир", shelf, author);
            var book2 = new Book("Анна Каренина", shelf, author);

            _ = shelf.AddBook(book1)
                     .AddBook(book2);

            Console.WriteLine(shelf);
            Console.WriteLine("--------");

            var shelf2 = new Shelf("Вторая полка");
            book2.ChangeShelf(shelf2);
            Console.WriteLine(shelf);
            Console.WriteLine(shelf2);
        }
    }
}