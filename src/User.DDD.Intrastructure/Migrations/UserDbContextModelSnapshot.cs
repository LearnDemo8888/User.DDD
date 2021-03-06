// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using User.DDD.Intrastructure;

#nullable disable

namespace User.DDD.Intrastructure.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("User.DDD.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.ToTable("T_Users", (string)null);
                });

            modelBuilder.Entity("User.DDD.Domain.Entities.UserAccessFail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LockEnd")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isLockOut")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsLockOut");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("T_UserAccessFails", (string)null);
                });

            modelBuilder.Entity("User.DDD.Domain.Entities.UserLoginHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Messsage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("T_UserLoginHistorys", (string)null);
                });

            modelBuilder.Entity("User.DDD.Domain.Entities.User", b =>
                {
                    b.OwnsOne("User.DDD.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .IsUnicode(true)
                                .HasColumnType("TEXT");

                            b1.Property<int>("RegionCode")
                                .HasColumnType("INTEGER");

                            b1.HasKey("UserId");

                            b1.ToTable("T_Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });

            modelBuilder.Entity("User.DDD.Domain.Entities.UserAccessFail", b =>
                {
                    b.HasOne("User.DDD.Domain.Entities.User", "User")
                        .WithOne("Access")
                        .HasForeignKey("User.DDD.Domain.Entities.UserAccessFail", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("User.DDD.Domain.Entities.User", b =>
                {
                    b.Navigation("Access")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
