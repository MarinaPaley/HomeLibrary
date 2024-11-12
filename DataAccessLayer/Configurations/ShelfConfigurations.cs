// <copyright file="ShelfConfigurations.cs" company="Васильева М.А.">
// Copyright (c) Васильева М.А.. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Конфигурация правил отображения сущности (<see cref="Domain.Shelf"/>) в таблицу БД.
    /// </summary>
    internal sealed class ShelfConfigurations : IEntityTypeConfiguration<Shelf>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            _ = builder.HasKey(shelf => shelf.Id);

            _ = builder.Property(shelf => shelf.Name)
                .HasMaxLength(25)
                .IsRequired();

            _ = builder.HasMany(shelf => shelf.Books)
                .WithOne(book => book.Shelf);
        }
    }
}
