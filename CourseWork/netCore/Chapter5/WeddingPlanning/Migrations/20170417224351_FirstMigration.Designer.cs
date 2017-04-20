using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WeddingPlanning.Models;

namespace WeddingPlanning.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20170417224351_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("WeddingPlanning.Models.Guest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.Property<int>("user_id");

                    b.Property<int>("wedding_id");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.HasIndex("wedding_id");

                    b.ToTable("Guest");
                });

            modelBuilder.Entity("WeddingPlanning.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("First_Name");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Password");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WeddingPlanning.Models.Wedding", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bride_Name");

                    b.Property<string>("Groom_Name");

                    b.Property<DateTime>("Wedding_Date");

                    b.Property<DateTime>("created_at");

                    b.Property<DateTime>("updated_at");

                    b.Property<int>("user_id");

                    b.HasKey("id");

                    b.ToTable("Wedding");
                });

            modelBuilder.Entity("WeddingPlanning.Models.Guest", b =>
                {
                    b.HasOne("WeddingPlanning.Models.User", "User")
                        .WithMany("UserGuest")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WeddingPlanning.Models.Wedding", "Wedding")
                        .WithMany("WeddingGuest")
                        .HasForeignKey("wedding_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
