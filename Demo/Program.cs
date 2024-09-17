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
            Console.WriteLine(shelf);
        }
    }
}