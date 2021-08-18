using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_CommentOwnerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_PostOwnerId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_ProfileId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_ReactionOwnerId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Posts_PostId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_ReactionOwnerId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostOwnerId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentOwnerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReactionOwnerId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostOwnerId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CommentOwnerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Reactions",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Comments",
                newName: "ProfileId");

            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "Reactions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId1",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PostId1",
                table: "Reactions",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ProfileId",
                table: "Reactions",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId1",
                table: "Comments",
                column: "PostId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProfileId",
                table: "Comments",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId1",
                table: "Comments",
                column: "PostId1",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Profiles_ProfileId",
                table: "Comments",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_ProfileId",
                table: "Posts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Posts_PostId",
                table: "Reactions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Posts_PostId1",
                table: "Reactions",
                column: "PostId1",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Profiles_ProfileId",
                table: "Reactions",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Profiles_ProfileId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_ProfileId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Posts_PostId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Posts_PostId1",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Profiles_ProfileId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_PostId1",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_ProfileId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProfileId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Reactions",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Comments",
                newName: "OwnerId");

            migrationBuilder.AddColumn<string>(
                name: "ReactionOwnerId",
                table: "Reactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostOwnerId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentOwnerId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ReactionOwnerId",
                table: "Reactions",
                column: "ReactionOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostOwnerId",
                table: "Posts",
                column: "PostOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentOwnerId",
                table: "Comments",
                column: "CommentOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_CommentOwnerId",
                table: "Comments",
                column: "CommentOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_PostOwnerId",
                table: "Posts",
                column: "PostOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_ProfileId",
                table: "Posts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_ReactionOwnerId",
                table: "Reactions",
                column: "ReactionOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Posts_PostId",
                table: "Reactions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
