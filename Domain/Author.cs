// <copyright file="Author.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>
namespace Domain
{
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
            string? patronicName,
            DateOnly? dateBirth,
            DateOnly? dateDeath)
        {
            this.FirsName = firsName ?? throw new ArgumentNullException(nameof(firsName));
            this.FamilyName = familyName ?? throw new ArgumentNullException(nameof(familyName));
            this.PatronicName = patronicName;
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
        public DateOnly? DateBirth { get; }

        /// <summary>
        /// Дата смерти.
        /// </summary>
        public DateOnly? DateDeath { get; }

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
                && this.FamilyName == other.FamilyName;

            if (areEqual && this.PatronicName is not null)
            {
                areEqual = areEqual && this.PatronicName == other.PatronicName;
            }

            if (areEqual && this.DateBirth is not null)
            {
                areEqual = areEqual && this.DateBirth == other.DateBirth;
            }

            if (areEqual && other.DateDeath is not null)
            {
                areEqual = areEqual && this.DateDeath == other.DateDeath;
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
            var result = this.FirsName.GetHashCode() + this.FirsName.GetHashCode();
            if (this.PatronicName is not null)
            {
                result += this.PatronicName.GetHashCode();
            }

            if (this.DateBirth is not null)
            {
                result += this.DateBirth.GetHashCode();
            }

            if (this.DateDeath is not null)
            {
                result += this.DateDeath.GetHashCode();
            }

            return result;
        }
    }
}
