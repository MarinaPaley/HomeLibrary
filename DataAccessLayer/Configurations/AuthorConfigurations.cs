// <copyright file="AuthorConfigurations.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Domain.Author"/>) в таблицу БД.
    /// </summary>
    internal sealed class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            _ = builder.HasKey(author => author.Id);

            _ = builder.Property(author => author.FamilyName)
               .HasMaxLength(50)
               .IsRequired();

            _ = builder.Property(author => author.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            _ = builder.Property(author => author.PatronicName)
                .HasMaxLength(50)
                .IsRequired(false);

            _ = builder.Property(author => author.DateBirth)
                .IsRequired(false);

            _ = builder.Property(author => author.DateDeath)
                .IsRequired(false);

            _ = builder.HasMany(author => author.Books)
                .WithMany(book => book.Authors);
        }
    }
}
