using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_GRAM.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Capture = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserComment = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    PostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Post_PostID",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "ID", "Author", "Capture", "ImageURL", "Title" },
                values: new object[] { 1, "Jimmy", "Snow day", "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg", "Street Coral View" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "ID", "Author", "Capture", "ImageURL", "Title" },
                values: new object[] { 2, "Bob", "Snow", "https://www.andersonsobelcosmetic.com/wp-content/uploads/2016/12/what-to-do-in-Seattle-for-the-holidays-family-activities-1024x684.jpg", "Snow on Top" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "ID", "Author", "Capture", "ImageURL", "Title" },
                values: new object[] { 3, "Peter", "Sun Set", "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg", "View Needle" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "PostID", "User", "UserComment" },
                values: new object[] { 1, 1, "Jimmy", "Beautiul Seattle" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "PostID", "User", "UserComment" },
                values: new object[] { 2, 2, "Bob", "Beautiul Seattle" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "PostID", "User", "UserComment" },
                values: new object[] { 3, 3, "Peter", "The View is Amazon Amazing!" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Post");
        }
    }
}
