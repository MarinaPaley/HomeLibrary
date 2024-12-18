﻿// <copyright file="Author.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace Domain
{
    using Staff;

    /// <summary>
    /// Класс Автор.
    /// </summary>
    public sealed class Author : IEquatable<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="firsName"> Имя. </param>
        /// <param name="familyName"> Фамилия. </param>
        /// <param name="patronicName"> Отчество. </param>
        /// <param name="dateBirth"> Дата рождения. </param>
        /// <param name="dateDeath"> Дата смерти. </param>
        /// <exception cref="ArgumentNullException"> Если ФИО <see langword="null"/>. </exception>
        public Author(
            string familyName,
            string firsName,
            string? patronicName = null,
            DateOnly? dateBirth = null,
            DateOnly? dateDeath = null)
        {
            this.FirstName = firsName.TrimOrNull() ?? throw new ArgumentNullException(nameof(firsName));
            this.FamilyName = familyName.TrimOrNull() ?? throw new ArgumentNullException(nameof(familyName));
            this.PatronicName = patronicName is not null ? patronicName.TrimOrNull() : null;
            this.DateBirth = dateBirth;
            this.DateDeath = dateDeath;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FamilyName { get; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? PatronicName { get; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateOnly? DateBirth { get; }

        /// <summary>
        /// Дата смерти.
        /// </summary>
        public DateOnly? DateDeath { get; }

        /// <summary>
        /// Книги.
        /// </summary>
        public ISet<Book> Books { get; } = new HashSet<Book>();

        /// <summary>
        /// Добавляем книгу автору.
        /// </summary>
        /// <param name="book"> Книга. </param>
        /// <returns> Автор. </returns>
        /// <exception cref="ArgumentNullException"> Если книга <see langword="null"/>. </exception>
        public Author AddBook(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            this.Books.Add(book);
            book.Authors.Add(this);
            return this;
        }

        /// <inheritdoc/>
        public bool Equals(Author? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.FirstName != other.FirstName
               || this.FamilyName != other.FamilyName)
            {
                return false;
            }

            if (((this.PatronicName is not null) && (other.PatronicName is null))
                || ((this.PatronicName is null) && (other.PatronicName is not null))
                || ((this.PatronicName is not null) && (this.PatronicName != other.PatronicName)))
            {
                return false;
            }

            if (((this.DateBirth is not null) && (other.DateBirth is null))
                || ((this.DateBirth is null) && (other.DateBirth is not null))
                || ((this.DateBirth is not null) && (this.DateBirth != other.DateBirth)))
            {
                return false;
            }

            if (((this.DateDeath is not null) && (other.DateDeath is null))
                || ((this.DateDeath is null) && (other.DateDeath is not null))
                || ((this.DateDeath is not null) && (this.DateDeath != other.DateDeath)))
            {
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Author);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(
                this.FamilyName,
                this.FirstName,
                this.PatronicName,
                this.DateBirth,
                this.DateDeath);
        }
    }
}
