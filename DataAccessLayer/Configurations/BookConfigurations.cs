// <copyright file="BookConfigurations.cs" company="��������� �.�.">
// Copyright (c) ��������� �.�.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// ������������ ������ ����������� �������� (<see cref="Domain.Book"/>) � ������� ��.
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