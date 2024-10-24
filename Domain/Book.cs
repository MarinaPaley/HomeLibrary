// <copyright file="Book.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

using Staff;

namespace Domain
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Book : IEquatable<Book>
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// 
        /// </summary>
        public ISet<Author> Authors { get; set; } = new HashSet<Author>();

        /// <summary>
        /// 
        /// </summary>
        public Shelf Shelf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"> </param>
        /// <param name="shelf"> </param>
        /// <param name="authors"> </param>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// 
        /// </summary>
        /// <param name="title"> </param>
        /// <param name="shelf"> </param>
        /// <param name="authors"> </param>
        public Book(string title, Shelf shelf, params Author[] authors)
            : this(title, shelf, new HashSet<Author>(authors))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shelf"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool ChangeShelf(Shelf shelf)
        {
            if (shelf is null)
            {
                throw new ArgumentNullException(nameof(shelf));
            }

            _ = this.Shelf.RemoveBook(this);
            this.Shelf = shelf;
            _ = this.Shelf.AddBook(this);

            return true;
        }

        ///
        /// <inheritdoc/>
        public bool Equals(Book? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Title.Equals(other.Title);
        }

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
