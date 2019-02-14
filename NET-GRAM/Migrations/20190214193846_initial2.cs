using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_GRAM.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "ID", "Author", "Capture", "ImageURL", "Title" },
                values: new object[] { 1, "Jimmy", "Snow day", "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg", "Chace's Pancake Coral" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "ID", "Author", "Capture", "ImageURL", "Title" },
                values: new object[] { 2, "Bob", "Snow", "https://images.pexels.com/photos/688660/pexels-photo-688660.jpeg", "Chace's Pancake Coral" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
