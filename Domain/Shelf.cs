// <copyright file="Shelf.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace Domain
{
    using Staff;

    /// <summary>
    /// Класс Полка.
    /// </summary>
    public sealed class Shelf : IEquatable<Shelf>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Shelf"/>.
        /// </summary>
        /// <param name="name"> Название полки.</param>
        /// <exception cref="ArgumentNullException"> Если название <see langword="null"/>.</exception>
        public Shelf(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название полки.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Книги.
        /// </summary>
        public ISet<Book> Books { get; set; } = new HashSet<Book>();

        /// <summary>
        /// Добавить книгу.
        /// </summary>
        /// <param name="book"> Книга. </param>
        /// <returns> Полка. </returns>
        /// <exception cref="ArgumentNullException"> Если книга <see langword="null"/>.</exception>
        public Shelf AddBook(Book book)
        {
            ArgumentNullException.ThrowIfNull(book);

            this.Books.Add(book);
            book.Shelf = this;
            return this;
        }

        /// <inheritdoc/>
        public bool Equals(Shelf? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Name == other.Name;
        }

        /// <inheritdoc/>
        public override string ToString() =>
            this.Books.Count == 0 ?
            $"{this.Name}"
            : $"{this.Name} {this.Books.Join()}";

        /// <inheritdoc/>
        public override int GetHashCode() => this.Name.GetHashCode();

        /// <summary>
        /// Убрать книгу с полки.
        /// </summary>
        /// <param name="book">Книга. </param>
        /// <returns> Полка.</returns>
        /// <exception cref="ArgumentNullException">Если книга <see langword="null"/>.</exception>
        internal Shelf RemoveBook(Book book)
        {
            ArgumentNullException.ThrowIfNull(book);

            this.Books.Remove(book);
            book.Shelf = null;
            return this;
        }
    }
}
