// <copyright file="Author.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace Domain
{
    /// <summary>
    /// Класс Автор.
    /// </summary>
    public class Author : IEquatable<Author>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Author"/>.
        /// </summary>
        /// <param name="firsName"> Имя. </param>
        /// <param name="familyName"> Фамилия.</param>
        /// <param name="patronicName"> Отчество. </param>
        /// <param name="bithData"> дата рождения.</param>
        /// <exception cref="ArgumentNullException"> Если ФИО <see langword="null"/>. </exception>
        public Author(string familyName, string firsName, string? patronicName, DateTime bithData)
        {
            this.FirsName = firsName ?? throw new ArgumentNullException(nameof(firsName));
            this.FamilyName = familyName ?? throw new ArgumentNullException(nameof(familyName));
            this.PatronicName = patronicName;
            this.BithData = bithData;
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirsName { get; }

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
        public DateTime BithData { get; }

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

            var areEqual = this.FirsName == other.FirsName
                && this.FamilyName == other.FamilyName
                && this.BithData == other.BithData;

            if (areEqual && this.PatronicName is not null)
            {
                areEqual = areEqual && this.PatronicName == other.PatronicName;
            }

            return areEqual;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Author);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var result = this.FirsName.GetHashCode() + this.FirsName.GetHashCode() 
                + this.BithData.GetHashCode();
            if (this.PatronicName is not null)
            {
                result += this.PatronicName.GetHashCode();
            }

            return result;
        }
    }
}
