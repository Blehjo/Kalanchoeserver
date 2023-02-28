﻿// <auto-generated />
using System;
using KalanchoeAI_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KalanchoeAIBackend.Migrations
{
    [DbContext(typeof(KalanchoeAIDatabaseContext))]
    [Migration("20230227231749_UpdatedModels")]
    partial class UpdatedModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Channel", b =>
                {
                    b.Property<int>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommunityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ChannelId");

                    b.HasIndex("CommunityId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.ChannelComment", b =>
                {
                    b.Property<int>("ChannelCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChannelCommentValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ChannelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChannelCommentId");

                    b.HasIndex("ChannelId");

                    b.HasIndex("UserId");

                    b.ToTable("ChannelComments");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.ChatComment", b =>
                {
                    b.Property<int>("ChatCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChatId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChatValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.HasKey("ChatCommentId");

                    b.HasIndex("ChatId");

                    b.ToTable("ChatComments");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentValue")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Community", b =>
                {
                    b.Property<int>("CommunityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MediaLink")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CommunityId");

                    b.HasIndex("UserId");

                    b.ToTable("Communities");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Follower", b =>
                {
                    b.Property<int>("FollowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FollowerUser")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FollowerId");

                    b.HasIndex("UserId");

                    b.ToTable("Followers");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommunityId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MemberId");

                    b.HasIndex("CommunityId");

                    b.HasIndex("UserId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.MessageComment", b =>
                {
                    b.Property<int>("MessageCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("MessageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MessageValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MessageCommentId");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageComments");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("NoteValue")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PanelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NoteId");

                    b.HasIndex("PanelId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Panel", b =>
                {
                    b.Property<int>("PanelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PanelId");

                    b.HasIndex("UserId");

                    b.ToTable("Panels");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("MediaLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Saved", b =>
                {
                    b.Property<int>("SavedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SavedId");

                    b.HasIndex("UserId");

                    b.ToTable("Saved");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Channel", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.Community", "Community")
                        .WithMany("Channels")
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Community");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.ChannelComment", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.Channel", "Channel")
                        .WithMany("ChannelComments")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("ChannelComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Chat", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.ChatComment", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.Chat", "Chat")
                        .WithMany("ChatComments")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Comment", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Community", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("Communities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Follower", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("Followers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Member", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.Community", "Community")
                        .WithMany("Members")
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("Members")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Community");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Message", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.MessageComment", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.Message", "Message")
                        .WithMany("MessageComments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Note", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.Panel", "Panel")
                        .WithMany("Notes")
                        .HasForeignKey("PanelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Panel");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Panel", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("Panels")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Post", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Saved", b =>
                {
                    b.HasOne("KalanchoeAI_Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Channel", b =>
                {
                    b.Navigation("ChannelComments");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Chat", b =>
                {
                    b.Navigation("ChatComments");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Community", b =>
                {
                    b.Navigation("Channels");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Message", b =>
                {
                    b.Navigation("MessageComments");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Panel", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("KalanchoeAI_Backend.Models.User", b =>
                {
                    b.Navigation("ChannelComments");

                    b.Navigation("Chats");

                    b.Navigation("Comments");

                    b.Navigation("Communities");

                    b.Navigation("Followers");

                    b.Navigation("Members");

                    b.Navigation("Messages");

                    b.Navigation("Panels");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
