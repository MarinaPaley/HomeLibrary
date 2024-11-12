// <copyright file="Author.cs" company="Васильева М.А.">
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
        [Obsolete("For ORM only")]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        private Author()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        {
        }

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
            this.PatronicName = patronicName?.TrimOrNull();
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
            ArgumentNullException.ThrowIfNull(book);

            this.Books.Add(book);
            book.Authors.Add(this);
            return this;
        }

        /// <inheritdoc/>
        public bool Equals(Author? other)
        {
            return ReferenceEquals(this, other) || ((other is not null)
                    && (this.FirstName == other.FirstName)
                    && (this.FamilyName == other.FamilyName)
                    && (this.PatronicName == other.PatronicName)
                    && (this.DateBirth == other.DateBirth)
                    && (this.DateDeath == other.DateDeath));
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

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.PatronicName is null ?
                $"{this.FamilyName} {this.FirstName}"
                : $"{this.FamilyName} {this.FirstName} {this.PatronicName}";
        }
    }
}
