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
            DateTime dateBirthDate = DateTime.Parse("28.09.1828");

            // act & assert
            Assert.DoesNotThrow(() => _ = new Author("Толстой", "Лев", "Николаевич", dateBirthDate));
        }
    }
}
