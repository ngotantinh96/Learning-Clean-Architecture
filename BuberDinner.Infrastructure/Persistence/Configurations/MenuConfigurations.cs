using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private static void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.DinnerIds, dinnerIdsBuilder =>
        {
            dinnerIdsBuilder.ToTable("MenuDinnerIds");

            dinnerIdsBuilder.WithOwner().HasForeignKey(nameof(MenuId));

            dinnerIdsBuilder.HasKey("Id");

            dinnerIdsBuilder.Property(x => x.Value)
                .HasColumnName(nameof(DinnerId))
                .ValueGeneratedNever();

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        });
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
         builder.OwnsMany(x => x.MenuReviewIds, menuReviewIdsBuilder =>
        {
            menuReviewIdsBuilder.ToTable("MenuReviewIds");

            menuReviewIdsBuilder.WithOwner().HasForeignKey(nameof(MenuId));

            menuReviewIdsBuilder.HasKey("Id");

            menuReviewIdsBuilder.Property(x => x.Value)
                .HasColumnName("ReviewId")
                .ValueGeneratedNever();

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        });
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(x => x.Sections, sectionBuilder =>
        {
            sectionBuilder.ToTable("MenuSections");

            sectionBuilder.WithOwner().HasForeignKey(nameof(MenuId));

            sectionBuilder.HasKey(nameof(MenuSection.Id), nameof(MenuId));

            sectionBuilder.Property(x => x.Id)
                .HasColumnName(nameof(MenuSectionId))
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Create(value)
                );

            sectionBuilder.Property(x => x.Name)
                .HasMaxLength(100);

            sectionBuilder.Property(x => x.Description)
                .HasMaxLength(100);

            ConfigureMenuItemsTable(sectionBuilder);

            builder.Metadata.FindNavigation(nameof(Menu.Sections))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        });
    }

    private static void ConfigureMenuItemsTable(OwnedNavigationBuilder<Menu, MenuSection> sectionBuilder)
    {
        sectionBuilder.OwnsMany(x => x.Items, itemBuilder =>
        {
            itemBuilder.ToTable("MenuItems");

            itemBuilder.WithOwner().HasForeignKey(nameof(MenuSectionId), nameof(MenuId));

            itemBuilder.HasKey(nameof(MenuItem.Id), nameof(MenuSectionId), nameof(MenuId));

            itemBuilder.Property(x => x.Id)
                .HasColumnName(nameof(MenuItemId))
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuItemId.Create(value)
                );

            itemBuilder.Property(x => x.Name)
                .HasMaxLength(100);

            itemBuilder.Property(x => x.Description)
                .HasMaxLength(100);
        });

        sectionBuilder.Navigation(s => s.Items).Metadata
            .SetField("_items");

        sectionBuilder.Navigation(s => s.Items)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value)
            );

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(100);

        builder.OwnsOne(x => x.AverageRating);

        builder.Property(x => x.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );   
    }
}