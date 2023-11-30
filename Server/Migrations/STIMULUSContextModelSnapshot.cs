﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using STIMULUS_V2.Server.Data;

#nullable disable

namespace STIMULUS_V2.Server.Migrations
{
    [DbContext(typeof(STIMULUSContext))]
    partial class STIMULUSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Authentication.TokenInfo", b =>
                {
                    b.Property<int>("TokenInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TokenInfoId"), 1L, 1);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TokenInfoId");

                    b.ToTable("TokenInfo");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Authentication.Utilisateur", b =>
                {
                    b.Property<string>("Identifiant")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotDePasse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifiant");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Code", b =>
                {
                    b.Property<int>("CodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodeId"), 1L, 1);

                    b.Property<string>("Contenue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CodeId");

                    b.ToTable("Code");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Composant", b =>
                {
                    b.Property<int>("ComposantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComposantId"), 1L, 1);

                    b.Property<int>("Ordre")
                        .HasColumnType("int");

                    b.Property<int?>("PageId")
                        .HasColumnType("int");

                    b.Property<int>("Reference")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ComposantId");

                    b.HasIndex("PageId");

                    b.ToTable("Composant");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Cours", b =>
                {
                    b.Property<int>("CoursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoursId"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CoursId");

                    b.ToTable("Cours");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Exercice", b =>
                {
                    b.Property<int>("ExerciceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciceId"), 1L, 1);

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciceId");

                    b.ToTable("Exercice");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.FichierSauvegarde", b =>
                {
                    b.Property<int>("FichierSauvegardeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FichierSauvegardeId"), 1L, 1);

                    b.Property<string>("CodeDA")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Contenue")
                        .HasColumnType("varchar(8000)");

                    b.Property<int?>("ExerciceId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Version")
                        .HasColumnType("datetime2");

                    b.HasKey("FichierSauvegardeId");

                    b.HasIndex("CodeDA");

                    b.HasIndex("ExerciceId");

                    b.ToTable("FichierSauvegarde");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.FichierSource", b =>
                {
                    b.Property<int>("FichierSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FichierSourceId"), 1L, 1);

                    b.Property<int?>("ExerciceId")
                        .HasColumnType("int");

                    b.Property<string>("MiseEnSituation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FichierSourceId");

                    b.HasIndex("ExerciceId");

                    b.ToTable("FichierSource");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Graphe", b =>
                {
                    b.Property<int>("GrapheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GrapheId"), 1L, 1);

                    b.Property<int?>("GroupeId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("GrapheId");

                    b.HasIndex("GroupeId");

                    b.ToTable("Graphe");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Groupe", b =>
                {
                    b.Property<int>("GroupeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupeId"), 1L, 1);

                    b.Property<int?>("CoursId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCloture")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("Date");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfesseurId")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("GroupeId");

                    b.HasIndex("CoursId");

                    b.HasIndex("ProfesseurId");

                    b.ToTable("Groupe");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Groupe_Etudiant", b =>
                {
                    b.Property<int>("Groupe_EtudiantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Groupe_EtudiantId"), 1L, 1);

                    b.Property<string>("CodeDA")
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("GroupeId")
                        .HasColumnType("int");

                    b.HasKey("Groupe_EtudiantId");

                    b.HasIndex("CodeDA");

                    b.HasIndex("GroupeId");

                    b.ToTable("Groupe_Etudiant");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Largeur")
                        .HasColumnType("int");

                    b.Property<int>("Longueur")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Importance", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Pts")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("Importance");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Noeud", b =>
                {
                    b.Property<int>("NoeudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoeudId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Disponibilite")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GrapheId")
                        .HasColumnType("int");

                    b.Property<int?>("NoeudParentId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Obligatoire")
                        .HasColumnType("bit");

                    b.Property<decimal>("PosX")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("PosY")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("Rayon")
                        .HasColumnType("decimal(4,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("NoeudId");

                    b.HasIndex("GrapheId");

                    b.HasIndex("NoeudParentId");

                    b.ToTable("Noeud");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PageId"), 1L, 1);

                    b.Property<string>("ImportanceId")
                        .HasColumnType("char(3)");

                    b.Property<int?>("NoeudId")
                        .HasColumnType("int");

                    b.Property<int>("Ordre")
                        .HasColumnType("int");

                    b.HasKey("PageId");

                    b.HasIndex("ImportanceId");

                    b.HasIndex("NoeudId");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Page_Etudiant", b =>
                {
                    b.Property<int>("Page_EtudiantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Page_EtudiantId"), 1L, 1);

                    b.Property<string>("CodeDA")
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("Date");

                    b.Property<int?>("PageId")
                        .HasColumnType("int");

                    b.HasKey("Page_EtudiantId");

                    b.HasIndex("CodeDA");

                    b.HasIndex("PageId");

                    b.ToTable("Page_Etudiant");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Reference", b =>
                {
                    b.Property<int>("ReferenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReferenceId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReferenceId");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.TexteFormater", b =>
                {
                    b.Property<int>("TexteFormaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TexteFormaterId"), 1L, 1);

                    b.Property<string>("Contenue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TexteFormaterId");

                    b.ToTable("TexteFormater");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VideoId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Largeur")
                        .HasColumnType("int");

                    b.Property<int>("Longueur")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VideoId");

                    b.ToTable("Video");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Admin", b =>
                {
                    b.HasBaseType("STIMULUS_V2.Shared.Models.Authentication.Utilisateur");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Etudiant", b =>
                {
                    b.HasBaseType("STIMULUS_V2.Shared.Models.Authentication.Utilisateur");

                    b.ToTable("Etudiant", (string)null);
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Professeur", b =>
                {
                    b.HasBaseType("STIMULUS_V2.Shared.Models.Authentication.Utilisateur");

                    b.ToTable("Professeur", (string)null);
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Composant", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Page", "Page")
                        .WithMany()
                        .HasForeignKey("PageId");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.FichierSauvegarde", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Etudiant", "Etudiant")
                        .WithMany()
                        .HasForeignKey("CodeDA");

                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Exercice", "Exercice")
                        .WithMany()
                        .HasForeignKey("ExerciceId");

                    b.Navigation("Etudiant");

                    b.Navigation("Exercice");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.FichierSource", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Exercice", "Exercice")
                        .WithMany()
                        .HasForeignKey("ExerciceId");

                    b.Navigation("Exercice");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Graphe", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Groupe", "Groupe")
                        .WithMany()
                        .HasForeignKey("GroupeId");

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Groupe", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Cours", "Cours")
                        .WithMany()
                        .HasForeignKey("CoursId");

                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Professeur", "Professeur")
                        .WithMany()
                        .HasForeignKey("ProfesseurId");

                    b.Navigation("Cours");

                    b.Navigation("Professeur");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Groupe_Etudiant", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Etudiant", "Etudiant")
                        .WithMany()
                        .HasForeignKey("CodeDA");

                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Groupe", "Groupe")
                        .WithMany()
                        .HasForeignKey("GroupeId");

                    b.Navigation("Etudiant");

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Noeud", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Graphe", "Graphe")
                        .WithMany()
                        .HasForeignKey("GrapheId");

                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Noeud", "NoeudParent")
                        .WithMany()
                        .HasForeignKey("NoeudParentId");

                    b.Navigation("Graphe");

                    b.Navigation("NoeudParent");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Page", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Importance", "Importance")
                        .WithMany()
                        .HasForeignKey("ImportanceId");

                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Noeud", "Noeud")
                        .WithMany()
                        .HasForeignKey("NoeudId");

                    b.Navigation("Importance");

                    b.Navigation("Noeud");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Page_Etudiant", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Etudiant", "Etudiant")
                        .WithMany()
                        .HasForeignKey("CodeDA");

                    b.HasOne("STIMULUS_V2.Shared.Models.Entities.Page", "Page")
                        .WithMany()
                        .HasForeignKey("PageId");

                    b.Navigation("Etudiant");

                    b.Navigation("Page");
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Admin", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Authentication.Utilisateur", null)
                        .WithOne()
                        .HasForeignKey("STIMULUS_V2.Shared.Models.Entities.Admin", "Identifiant")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Etudiant", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Authentication.Utilisateur", null)
                        .WithOne()
                        .HasForeignKey("STIMULUS_V2.Shared.Models.Entities.Etudiant", "Identifiant")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("STIMULUS_V2.Shared.Models.Entities.Professeur", b =>
                {
                    b.HasOne("STIMULUS_V2.Shared.Models.Authentication.Utilisateur", null)
                        .WithOne()
                        .HasForeignKey("STIMULUS_V2.Shared.Models.Entities.Professeur", "Identifiant")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
