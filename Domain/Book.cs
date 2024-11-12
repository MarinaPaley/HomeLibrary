// <copyright file="Book.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace Domain
{
    using Staff;

    /// <summary>
    /// Класс книга.
    /// </summary>
    public sealed class Book : IEquatable<Book>
    {
        [Obsolete("For ORM only")]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        private Book()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Domain.Book"/>.
        /// </summary>
        /// <param name="title"> Название. </param>
        /// <param name="shelf"> Полка.</param>
        /// <param name="authors"> Авторы.</param>
        /// <exception cref="ArgumentNullException"> Если название <see langword="null"/>. </exception>
        public Book(string title, Shelf shelf, ISet<Author> authors)
        {
            this.Title = title.TrimOrNull() ?? throw new ArgumentNullException(nameof(title));
            this.Shelf = shelf ?? throw new ArgumentNullException(nameof(shelf));
            this.Shelf.AddBook(this);
            this.Authors = authors;
            foreach (var author in authors)
            {
                _ = author.AddBook(this);
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Domain.Book"/>.
        /// </summary>
        /// <param name="title"> Название.</param>
        /// <param name="shelf"> Полка.</param>
        /// <param name="authors"> Авторы.</param>
        /// <exception cref="ArgumentNullException"> Если название <see langword="null"/>. </exception>
        public Book(string title, Shelf shelf, params Author[] authors)
            : this(title, shelf, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название книги.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Авторы книги.
        /// </summary>
        public ISet<Author> Authors { get; } = new HashSet<Author>();

        /// <summary>
        /// Полка.
        /// </summary>
        public Shelf Shelf { get; set; }

        /// <summary>
        /// Смена полки.
        /// </summary>
        /// <param name="shelf"> Полка.</param>
        /// <returns><see langword="true"/> если поменяли полку. </returns>
        /// <exception cref="ArgumentNullException"> Если полка <see langword="null"/>.</exception>
        public bool ChangeShelf(Shelf shelf)
        {
            ArgumentNullException.ThrowIfNull(shelf);

            _ = this.Shelf.RemoveBook(this);
            this.Shelf = shelf;
            _ = this.Shelf.AddBook(this);

            return true;
        }

        ///
        /// <inheritdoc/>
        public bool Equals(Book? other)
            => ReferenceEquals(this, other) || ((other is not null) && this.Title.Equals(other.Title));

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Book);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Title.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Title} {this.Authors.Join()}";
        }
    }
}
