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
            var book1 = new Book("1");
            var book2 = new Book("2");

            _ = shelf.AddBook(book1)
                     .AddBook(book2);

            Console.WriteLine(shelf);
        }
    }
}