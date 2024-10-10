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
        /// <param name="title"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Book( string title)
        {
            this.Title = title.TrimOrNull() ?? throw new ArgumentNullException(nameof(title));
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
            return this.Title;
        }
    }
}
