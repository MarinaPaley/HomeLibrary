// <copyright file="BookConfigurations.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Domain.Book"/>) в таблицу БД.
    /// </summary>
    internal sealed class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            _ = builder.HasKey(book => book.Id);
            _ = builder.Property(book => book.Title)
                .HasMaxLength(100)
                .IsRequired();

            _ = builder.HasMany(book => book.Authors)
                .WithMany(author => author.Books);

            _ = builder.HasOne(book => book.Shelf)
                .WithMany(shelf => shelf.Books);
        }
    }
}