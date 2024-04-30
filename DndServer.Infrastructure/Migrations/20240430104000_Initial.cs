using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BackgroundInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundInstance", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BackgroundTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundTemplate", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInstance", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTemplate", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: true),
                    System = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceInstance", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTemplate", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SkillInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    SkillType = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    Passive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Recharge = table.Column<int>(type: "int", nullable: false),
                    Charges = table.Column<int>(type: "int", nullable: false),
                    System = table.Column<int>(type: "int", nullable: false),
                    Value_ItemType = table.Column<int>(type: "int", nullable: false),
                    Value_Language = table.Column<int>(type: "int", nullable: false),
                    Value_Type = table.Column<int>(type: "int", nullable: false),
                    Value_UseSpell = table.Column<string>(type: "longtext", nullable: false),
                    Value_AttackBonus_AccuracyBonus = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Advantage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_AttackBonus_DisAdvantage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_AttackBonus_Type = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Damage_DamageType = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Damage_Flat = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Damage_Heal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_AttackBonus_Damage_DamageRoll_Dice = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Damage_DamageRoll_Rolls = table.Column<int>(type: "int", nullable: false),
                    Value_Damage_DamageType = table.Column<int>(type: "int", nullable: false),
                    Value_Damage_Flat = table.Column<int>(type: "int", nullable: false),
                    Value_Damage_Heal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Damage_DamageRoll_Dice = table.Column<int>(type: "int", nullable: false),
                    Value_Damage_DamageRoll_Rolls = table.Column<int>(type: "int", nullable: false),
                    Value_Effect_Advantage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Effect_Competent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Effect_DisAdvantage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Effect_Dynamic = table.Column<int>(type: "int", nullable: false),
                    Value_Effect_Flat = table.Column<int>(type: "int", nullable: false),
                    Value_Effect_Mastery = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Effect_SaveRoll = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_PerLevel_Dynamic = table.Column<int>(type: "int", nullable: false),
                    Value_PerLevel_Flat = table.Column<int>(type: "int", nullable: false),
                    Value_Resistance_Flat = table.Column<int>(type: "int", nullable: true),
                    Value_Resistance_DamageType_value__ = table.Column<int>(type: "int", nullable: false),
                    Value_TypeVision_Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillInstance", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SkillTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    SkillType = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    Passive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Recharge = table.Column<int>(type: "int", nullable: false),
                    Charges = table.Column<int>(type: "int", nullable: false),
                    Hidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    System = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: true),
                    Value_ItemType = table.Column<int>(type: "int", nullable: false),
                    Value_Language = table.Column<int>(type: "int", nullable: false),
                    Value_Type = table.Column<int>(type: "int", nullable: false),
                    Value_UseSpell = table.Column<string>(type: "longtext", nullable: false),
                    Value_AttackBonus_AccuracyBonus = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Advantage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_AttackBonus_DisAdvantage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_AttackBonus_Type = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Damage_DamageType = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Damage_Flat = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Damage_Heal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_AttackBonus_Damage_DamageRoll_Dice = table.Column<int>(type: "int", nullable: false),
                    Value_AttackBonus_Damage_DamageRoll_Rolls = table.Column<int>(type: "int", nullable: false),
                    Value_Damage_DamageType = table.Column<int>(type: "int", nullable: false),
                    Value_Damage_Flat = table.Column<int>(type: "int", nullable: false),
                    Value_Damage_Heal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Damage_DamageRoll_Dice = table.Column<int>(type: "int", nullable: false),
                    Value_Damage_DamageRoll_Rolls = table.Column<int>(type: "int", nullable: false),
                    Value_Effect_Advantage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Effect_Competent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Effect_DisAdvantage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Effect_Dynamic = table.Column<int>(type: "int", nullable: false),
                    Value_Effect_Flat = table.Column<int>(type: "int", nullable: false),
                    Value_Effect_Mastery = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_Effect_SaveRoll = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Value_PerLevel_Dynamic = table.Column<int>(type: "int", nullable: false),
                    Value_PerLevel_Flat = table.Column<int>(type: "int", nullable: false),
                    Value_Resistance_Flat = table.Column<int>(type: "int", nullable: true),
                    Value_Resistance_DamageType_value__ = table.Column<int>(type: "int", nullable: false),
                    Value_TypeVision_Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTemplate", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    Components = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<int>(type: "int", nullable: false),
                    ActionTime_Concentrate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ActionTime_Time = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Damage_DamageType = table.Column<int>(type: "int", nullable: false),
                    Damage_Flat = table.Column<int>(type: "int", nullable: false),
                    Damage_Heal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Damage_DamageRoll_Dice = table.Column<int>(type: "int", nullable: false),
                    Damage_DamageRoll_Rolls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellInstance", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpellTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    Components = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    System = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: true),
                    ActionTime_Concentrate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ActionTime_Time = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Damage_DamageType = table.Column<int>(type: "int", nullable: false),
                    Damage_Flat = table.Column<int>(type: "int", nullable: false),
                    Damage_Heal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Damage_DamageRoll_Dice = table.Column<int>(type: "int", nullable: false),
                    Damage_DamageRoll_Rolls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellTemplate", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tracker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracker", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Wiki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wiki", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ObjectInstance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AttackType = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Rare = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MainCharacteristic = table.Column<int>(type: "int", nullable: false),
                    Equipped = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    System = table.Column<int>(type: "int", nullable: false),
                    Damage_DamageType = table.Column<int>(type: "int", nullable: false),
                    Damage_Flat = table.Column<int>(type: "int", nullable: false),
                    Damage_Heal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Damage_DamageRoll_Dice = table.Column<int>(type: "int", nullable: false),
                    Damage_DamageRoll_Rolls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectInstance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectInstance_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ObjectTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AttackType = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Rare = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MainCharacteristic = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    System = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: true),
                    Damage_DamageType = table.Column<int>(type: "int", nullable: false),
                    Damage_Flat = table.Column<int>(type: "int", nullable: false),
                    Damage_Heal = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Damage_DamageRoll_Dice = table.Column<int>(type: "int", nullable: false),
                    Damage_DamageRoll_Rolls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectTemplate_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BackgroundInstanceSkillInstance",
                columns: table => new
                {
                    BackgroundInstanceId = table.Column<int>(type: "int", nullable: false),
                    SkillInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundInstanceSkillInstance", x => new { x.BackgroundInstanceId, x.SkillInstanceId });
                    table.ForeignKey(
                        name: "FK_BackgroundInstanceSkillInstance_BackgroundInstance_Backgroun~",
                        column: x => x.BackgroundInstanceId,
                        principalTable: "BackgroundInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackgroundInstanceSkillInstance_SkillInstance_SkillInstanceId",
                        column: x => x.SkillInstanceId,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassInstanceSkillInstance",
                columns: table => new
                {
                    ClassInstanceId = table.Column<int>(type: "int", nullable: false),
                    SkillInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInstanceSkillInstance", x => new { x.ClassInstanceId, x.SkillInstanceId });
                    table.ForeignKey(
                        name: "FK_ClassInstanceSkillInstance_ClassInstance_ClassInstanceId",
                        column: x => x.ClassInstanceId,
                        principalTable: "ClassInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassInstanceSkillInstance_SkillInstance_SkillInstanceId",
                        column: x => x.SkillInstanceId,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConditionsSkillInstance",
                columns: table => new
                {
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    SkillInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionsSkillInstance", x => new { x.ConditionId, x.SkillInstanceId });
                    table.ForeignKey(
                        name: "FK_ConditionsSkillInstance_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConditionsSkillInstance_SkillInstance_SkillInstanceId",
                        column: x => x.SkillInstanceId,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceInstanceSkillInstance",
                columns: table => new
                {
                    RaceInstanceId = table.Column<int>(type: "int", nullable: false),
                    SkillInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceInstanceSkillInstance", x => new { x.RaceInstanceId, x.SkillInstanceId });
                    table.ForeignKey(
                        name: "FK_RaceInstanceSkillInstance_RaceInstance_RaceInstanceId",
                        column: x => x.RaceInstanceId,
                        principalTable: "RaceInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceInstanceSkillInstance_SkillInstance_SkillInstanceId",
                        column: x => x.SkillInstanceId,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BackgroundTemplateSkillTemplate",
                columns: table => new
                {
                    BackgroundTemplateId = table.Column<int>(type: "int", nullable: false),
                    SkillTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundTemplateSkillTemplate", x => new { x.BackgroundTemplateId, x.SkillTemplateId });
                    table.ForeignKey(
                        name: "FK_BackgroundTemplateSkillTemplate_BackgroundTemplate_Backgroun~",
                        column: x => x.BackgroundTemplateId,
                        principalTable: "BackgroundTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackgroundTemplateSkillTemplate_SkillTemplate_SkillTemplateId",
                        column: x => x.SkillTemplateId,
                        principalTable: "SkillTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassTemplateSkillTemplate",
                columns: table => new
                {
                    ClassTemplateId = table.Column<int>(type: "int", nullable: false),
                    SkillTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTemplateSkillTemplate", x => new { x.ClassTemplateId, x.SkillTemplateId });
                    table.ForeignKey(
                        name: "FK_ClassTemplateSkillTemplate_ClassTemplate_ClassTemplateId",
                        column: x => x.ClassTemplateId,
                        principalTable: "ClassTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassTemplateSkillTemplate_SkillTemplate_SkillTemplateId",
                        column: x => x.SkillTemplateId,
                        principalTable: "SkillTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RaceTemplateSkillTemplate",
                columns: table => new
                {
                    RaceTemplateId = table.Column<int>(type: "int", nullable: false),
                    SkillTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTemplateSkillTemplate", x => new { x.RaceTemplateId, x.SkillTemplateId });
                    table.ForeignKey(
                        name: "FK_RaceTemplateSkillTemplate_RaceTemplate_RaceTemplateId",
                        column: x => x.RaceTemplateId,
                        principalTable: "RaceTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaceTemplateSkillTemplate_SkillTemplate_SkillTemplateId",
                        column: x => x.SkillTemplateId,
                        principalTable: "SkillTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SkillInstanceSpellInstance",
                columns: table => new
                {
                    SkillInstanceId = table.Column<int>(type: "int", nullable: false),
                    SpellInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillInstanceSpellInstance", x => new { x.SkillInstanceId, x.SpellInstanceId });
                    table.ForeignKey(
                        name: "FK_SkillInstanceSpellInstance_SkillInstance_SkillInstanceId",
                        column: x => x.SkillInstanceId,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillInstanceSpellInstance_SpellInstance_SpellInstanceId",
                        column: x => x.SpellInstanceId,
                        principalTable: "SpellInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SkillTemplateSpellTemplate",
                columns: table => new
                {
                    SkillTemplateId = table.Column<int>(type: "int", nullable: false),
                    SpellTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTemplateSpellTemplate", x => new { x.SkillTemplateId, x.SpellTemplateId });
                    table.ForeignKey(
                        name: "FK_SkillTemplateSpellTemplate_SkillTemplate_SkillTemplateId",
                        column: x => x.SkillTemplateId,
                        principalTable: "SkillTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillTemplateSpellTemplate_SpellTemplate_SpellTemplateId",
                        column: x => x.SpellTemplateId,
                        principalTable: "SpellTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrackerUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Initiative = table.Column<double>(type: "double", nullable: false),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Icon = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrackerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackerUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackerUnit_Tracker_TrackerId",
                        column: x => x.TrackerId,
                        principalTable: "Tracker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    AddHp = table.Column<int>(type: "int", nullable: false),
                    MaxAttachments = table.Column<int>(type: "int", nullable: false),
                    SpellSlots = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnergySlots = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Ideology = table.Column<int>(type: "int", nullable: false),
                    System = table.Column<int>(type: "int", nullable: false),
                    ClassInstanceId = table.Column<int>(type: "int", nullable: false),
                    RaceInstanceId = table.Column<int>(type: "int", nullable: false),
                    BackgroundInstanceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Charisma = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Constitution = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Dexterity = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Intelligence = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Strength = table.Column<int>(type: "int", nullable: false),
                    Characteristics_Wisdom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_BackgroundInstance_BackgroundInstanceId",
                        column: x => x.BackgroundInstanceId,
                        principalTable: "BackgroundInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_ClassInstance_ClassInstanceId",
                        column: x => x.ClassInstanceId,
                        principalTable: "ClassInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_RaceInstance_RaceInstanceId",
                        column: x => x.RaceInstanceId,
                        principalTable: "RaceInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WikiPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WikiId = table.Column<int>(type: "int", nullable: false),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WikiPage_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WikiPage_Wiki_WikiId",
                        column: x => x.WikiId,
                        principalTable: "Wiki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "World",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    TrackerKey = table.Column<int>(type: "int", nullable: false),
                    WikiKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_World", x => x.Id);
                    table.ForeignKey(
                        name: "FK_World_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_World_Tracker_TrackerKey",
                        column: x => x.TrackerKey,
                        principalTable: "Tracker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_World_Wiki_WikiKey",
                        column: x => x.WikiKey,
                        principalTable: "Wiki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ObjectInstanceSkillInstance",
                columns: table => new
                {
                    ObjectInstanceId = table.Column<int>(type: "int", nullable: false),
                    SkillInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectInstanceSkillInstance", x => new { x.ObjectInstanceId, x.SkillInstanceId });
                    table.ForeignKey(
                        name: "FK_ObjectInstanceSkillInstance_ObjectInstance_ObjectInstanceId",
                        column: x => x.ObjectInstanceId,
                        principalTable: "ObjectInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectInstanceSkillInstance_SkillInstance_SkillInstanceId",
                        column: x => x.SkillInstanceId,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ObjectTemplateSkillTemplate",
                columns: table => new
                {
                    ObjectTemplateId = table.Column<int>(type: "int", nullable: false),
                    SkillTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTemplateSkillTemplate", x => new { x.ObjectTemplateId, x.SkillTemplateId });
                    table.ForeignKey(
                        name: "FK_ObjectTemplateSkillTemplate_ObjectTemplate_ObjectTemplateId",
                        column: x => x.ObjectTemplateId,
                        principalTable: "ObjectTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectTemplateSkillTemplate_SkillTemplate_SkillTemplateId",
                        column: x => x.SkillTemplateId,
                        principalTable: "SkillTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterConditions",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ConditionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterConditions", x => new { x.CharacterId, x.ConditionsId });
                    table.ForeignKey(
                        name: "FK_CharacterConditions_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterConditions_Conditions_ConditionsId",
                        column: x => x.ConditionsId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterNote",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterNote", x => new { x.CharacterId, x.NoteId });
                    table.ForeignKey(
                        name: "FK_CharacterNote_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterNote_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterObjectInstance",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    ObjectInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterObjectInstance", x => new { x.CharacterId, x.ObjectInstanceId });
                    table.ForeignKey(
                        name: "FK_CharacterObjectInstance_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterObjectInstance_ObjectInstance_ObjectInstanceId",
                        column: x => x.ObjectInstanceId,
                        principalTable: "ObjectInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterSkillInstance",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    SkillInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkillInstance", x => new { x.CharacterId, x.SkillInstanceId });
                    table.ForeignKey(
                        name: "FK_CharacterSkillInstance_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkillInstance_SkillInstance_SkillInstanceId",
                        column: x => x.SkillInstanceId,
                        principalTable: "SkillInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CharacterSpellInstance",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    SpellInstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSpellInstance", x => new { x.CharacterId, x.SpellInstanceId });
                    table.ForeignKey(
                        name: "FK_CharacterSpellInstance_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSpellInstance_SpellInstance_SpellInstanceId",
                        column: x => x.SpellInstanceId,
                        principalTable: "SpellInstance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorldLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WorldId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorldLinks_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorldLinks_World_WorldId",
                        column: x => x.WorldId,
                        principalTable: "World",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundInstanceSkillInstance_SkillInstanceId",
                table: "BackgroundInstanceSkillInstance",
                column: "SkillInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_BackgroundTemplateSkillTemplate_SkillTemplateId",
                table: "BackgroundTemplateSkillTemplate",
                column: "SkillTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_BackgroundInstanceId",
                table: "Character",
                column: "BackgroundInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_ClassInstanceId",
                table: "Character",
                column: "ClassInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_ImageId",
                table: "Character",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceInstanceId",
                table: "Character",
                column: "RaceInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterConditions_ConditionsId",
                table: "CharacterConditions",
                column: "ConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterNote_NoteId",
                table: "CharacterNote",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterObjectInstance_ObjectInstanceId",
                table: "CharacterObjectInstance",
                column: "ObjectInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkillInstance_SkillInstanceId",
                table: "CharacterSkillInstance",
                column: "SkillInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSpellInstance_SpellInstanceId",
                table: "CharacterSpellInstance",
                column: "SpellInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassInstanceSkillInstance_SkillInstanceId",
                table: "ClassInstanceSkillInstance",
                column: "SkillInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTemplateSkillTemplate_SkillTemplateId",
                table: "ClassTemplateSkillTemplate",
                column: "SkillTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionsSkillInstance_SkillInstanceId",
                table: "ConditionsSkillInstance",
                column: "SkillInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_ImageId",
                table: "Note",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectInstance_ImageId",
                table: "ObjectInstance",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectInstanceSkillInstance_SkillInstanceId",
                table: "ObjectInstanceSkillInstance",
                column: "SkillInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectTemplate_ImageId",
                table: "ObjectTemplate",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectTemplateSkillTemplate_SkillTemplateId",
                table: "ObjectTemplateSkillTemplate",
                column: "SkillTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceInstanceSkillInstance_SkillInstanceId",
                table: "RaceInstanceSkillInstance",
                column: "SkillInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceTemplateSkillTemplate_SkillTemplateId",
                table: "RaceTemplateSkillTemplate",
                column: "SkillTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillInstanceSpellInstance_SpellInstanceId",
                table: "SkillInstanceSpellInstance",
                column: "SpellInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTemplateSpellTemplate_SpellTemplateId",
                table: "SkillTemplateSpellTemplate",
                column: "SpellTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackerUnit_TrackerId",
                table: "TrackerUnit",
                column: "TrackerId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Login",
                table: "User",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WikiPage_ImageId",
                table: "WikiPage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_WikiPage_WikiId",
                table: "WikiPage",
                column: "WikiId");

            migrationBuilder.CreateIndex(
                name: "IX_World_ImageId",
                table: "World",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_World_TrackerKey",
                table: "World",
                column: "TrackerKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_World_WikiKey",
                table: "World",
                column: "WikiKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorldLinks_UserId",
                table: "WorldLinks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldLinks_WorldId",
                table: "WorldLinks",
                column: "WorldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackgroundInstanceSkillInstance");

            migrationBuilder.DropTable(
                name: "BackgroundTemplateSkillTemplate");

            migrationBuilder.DropTable(
                name: "CharacterConditions");

            migrationBuilder.DropTable(
                name: "CharacterNote");

            migrationBuilder.DropTable(
                name: "CharacterObjectInstance");

            migrationBuilder.DropTable(
                name: "CharacterSkillInstance");

            migrationBuilder.DropTable(
                name: "CharacterSpellInstance");

            migrationBuilder.DropTable(
                name: "ClassInstanceSkillInstance");

            migrationBuilder.DropTable(
                name: "ClassTemplateSkillTemplate");

            migrationBuilder.DropTable(
                name: "ConditionsSkillInstance");

            migrationBuilder.DropTable(
                name: "ObjectInstanceSkillInstance");

            migrationBuilder.DropTable(
                name: "ObjectTemplateSkillTemplate");

            migrationBuilder.DropTable(
                name: "RaceInstanceSkillInstance");

            migrationBuilder.DropTable(
                name: "RaceTemplateSkillTemplate");

            migrationBuilder.DropTable(
                name: "SkillInstanceSpellInstance");

            migrationBuilder.DropTable(
                name: "SkillTemplateSpellTemplate");

            migrationBuilder.DropTable(
                name: "TrackerUnit");

            migrationBuilder.DropTable(
                name: "WikiPage");

            migrationBuilder.DropTable(
                name: "WorldLinks");

            migrationBuilder.DropTable(
                name: "BackgroundTemplate");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "ClassTemplate");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "ObjectInstance");

            migrationBuilder.DropTable(
                name: "ObjectTemplate");

            migrationBuilder.DropTable(
                name: "RaceTemplate");

            migrationBuilder.DropTable(
                name: "SkillInstance");

            migrationBuilder.DropTable(
                name: "SpellInstance");

            migrationBuilder.DropTable(
                name: "SkillTemplate");

            migrationBuilder.DropTable(
                name: "SpellTemplate");

            migrationBuilder.DropTable(
                name: "World");

            migrationBuilder.DropTable(
                name: "BackgroundInstance");

            migrationBuilder.DropTable(
                name: "ClassInstance");

            migrationBuilder.DropTable(
                name: "RaceInstance");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Tracker");

            migrationBuilder.DropTable(
                name: "Wiki");
        }
    }
}
