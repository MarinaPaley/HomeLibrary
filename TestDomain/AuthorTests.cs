// <copyright file="AuthorTests.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace TestDomain
{
    using System;
    using Domain;

    /// <summary>
    /// Тесты для клсса <see cref="Domain.Author"/>.
    /// </summary>
    public class AuthorTests
    {
        /// <summary>
        /// Тест на конструктор с правильными данными.
        /// </summary>
        [Test]
        public void Ctor_ValidData_Success()
        {
            // arrange
            var birthDate = new DateOnly(1828, 09, 28);
            var deathDate = new DateOnly(1910, 11, 7);

            // act & assert
            Assert.DoesNotThrow(() => _ = new Author("Толстой", "Лев", "Николаевич", birthDate, deathDate));
        }
    }
}
