using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebApplication2.Migrations
{
	public partial class Inital01 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "book",
				columns: table => new
				{
					book_id = table.Column<uint>(type: "int(12) unsigned zerofill", nullable: false, comment: "图书序号")
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					book_code = table.Column<string>(type: "varchar(24)", nullable: false, comment: "图书编号或条码号")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					book_name = table.Column<string>(type: "varchar(32)", nullable: false, comment: "书名")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					book_isbn = table.Column<string>(type: "varchar(16)", nullable: true, comment: "ISBN 书号")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					book_clccode = table.Column<string>(type: "varchar(16)", nullable: true, comment: "CLC 分类号")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					book_status_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: true, comment: "图书状态ID"),
					book_author = table.Column<string>(type: "varchar(16)", nullable: false, comment: "作者")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					book_publisher = table.Column<string>(type: "varchar(32)", nullable: true, comment: "出版社")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					book_press_date = table.Column<DateTime>(type: "date", nullable: false, comment: "出版日期"),
					book_language_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: true, comment: "语言ID"),
					book_pages = table.Column<uint>(nullable: true, comment: "页数"),
					book_price = table.Column<decimal>(type: "decimal(8,2)", nullable: true, comment: "价格"),
					book_purchase_date = table.Column<DateTime>(type: "date", nullable: true, comment: "入馆时间"),
					book_brief = table.Column<string>(type: "text", nullable: true, comment: "内容简介")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					book_cover = table.Column<string>(type: "varchar(64)", nullable: true, comment: "封面")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_book", x => x.book_id);
				});

			migrationBuilder.CreateTable(
				name: "book_language",
				columns: table => new
				{
					language_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: false),
					language_name = table.Column<string>(type: "varchar(16)", nullable: false, comment: "语言类型")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin")
				},
				constraints: table =>
				{
					table.PrimaryKey("PRIMARY", x => x.language_id);
				});

			migrationBuilder.CreateTable(
				name: "book_status",
				columns: table => new
				{
					status_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: false),
					status_name = table.Column<string>(type: "varchar(16)", nullable: false, comment: "图书状态")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin")
				},
				constraints: table =>
				{
					table.PrimaryKey("PRIMARY", x => x.status_id);
				});

			migrationBuilder.CreateTable(
				name: "borrow",
				columns: table => new
				{
					id = table.Column<uint>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					reader_id = table.Column<uint>(nullable: false),
					book_id = table.Column<uint>(nullable: false),
					borrow_continue_times = table.Column<uint>(nullable: true, defaultValueSql: "'0'", comment: "续借次数"),
					lend_date = table.Column<DateTime>(type: "date", nullable: true, comment: "借书日期"),
					expect_return_date = table.Column<DateTime>(type: "date", nullable: true, comment: "应还日期"),
					delay_days = table.Column<int>(nullable: true, comment: "超时天数"),
					delay_expense = table.Column<decimal>(type: "decimal(8,2)", nullable: true, comment: "超时产生金额"),
					fine_expense = table.Column<decimal>(type: "decimal(16,2)", nullable: true, comment: "罚款金额"),
					lend_operator_id = table.Column<uint>(nullable: true, comment: "借书操作员"),
					return_operator_id = table.Column<int>(nullable: true, comment: "还书操作员")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_borrow", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "reader",
				columns: table => new
				{
					reader_id = table.Column<uint>(type: "int(8) unsigned zerofill", nullable: false, comment: "读者ID")
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					reader_name = table.Column<string>(type: "varchar(16)", nullable: false, comment: "读者姓名")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					reader_password = table.Column<string>(type: "varchar(128)", nullable: false, comment: "密码")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					reader_type_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: false, comment: "读者类别"),
					reader_roles_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: false, defaultValueSql: "'0000'", comment: "角色权限"),
					reader_status_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: true, comment: "读者状态"),
					reader_borrow_quantity = table.Column<uint>(nullable: true, defaultValueSql: "'0'", comment: "借阅数量"),
					reader_gender_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: true, comment: "性别"),
					reader_phonenumber = table.Column<string>(type: "varchar(16)", nullable: true, comment: "电话号码")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					reader_email = table.Column<string>(type: "varchar(32)", nullable: true, comment: "电子邮件")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					reader_department = table.Column<string>(type: "varchar(16)", nullable: true, comment: "单位")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					reader_register_date = table.Column<DateTime>(type: "date", nullable: true, comment: "注册日期"),
					reader_photo = table.Column<byte[]>(type: "blob", nullable: true, comment: "读者照片")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_reader", x => x.reader_id);
				});

			migrationBuilder.CreateTable(
				name: "reader_gender",
				columns: table => new
				{
					gender_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: false),
					gender_name = table.Column<string>(type: "varchar(16)", nullable: false, comment: "性别")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin")
				},
				constraints: table =>
				{
					table.PrimaryKey("PRIMARY", x => x.gender_id);
				});

			migrationBuilder.CreateTable(
				name: "reader_role",
				columns: table => new
				{
					role_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: false),
					role_name = table.Column<string>(type: "varchar(16)", nullable: false, comment: "角色权限")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin")
				},
				constraints: table =>
				{
					table.PrimaryKey("PRIMARY", x => x.role_id);
				});

			migrationBuilder.CreateTable(
				name: "reader_status",
				columns: table => new
				{
					status_id_r = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: false),
					status_name = table.Column<string>(type: "varchar(16)", nullable: false, comment: "状态")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin")
				},
				constraints: table =>
				{
					table.PrimaryKey("PRIMARY", x => x.status_id_r);
				});

			migrationBuilder.CreateTable(
				name: "reader_type",
				columns: table => new
				{
					type_id = table.Column<ushort>(type: "smallint(4) unsigned zerofill", nullable: false),
					type_name = table.Column<string>(type: "varchar(16)", nullable: false, comment: "类型")
						.Annotation("MySql:CharSet", "utf8mb4")
						.Annotation("MySql:Collation", "utf8mb4_bin"),
					type_borrow_quantity = table.Column<int>(nullable: true, comment: "可借书数量"),
					type_borrow_days = table.Column<int>(nullable: true, comment: "可借书天数"),
					type_borrow_continue_times = table.Column<int>(nullable: true, comment: "可续借次数"),
					type_timeout_expense = table.Column<decimal>(type: "decimal(8,2)", nullable: true, comment: "超时费用"),
					type_expiration_date = table.Column<DateTime>(type: "date", nullable: true, comment: "借书许可到期日期")
				},
				constraints: table =>
				{
					table.PrimaryKey("PRIMARY", x => x.type_id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "book");

			migrationBuilder.DropTable(
				name: "book_language");

			migrationBuilder.DropTable(
				name: "book_status");

			migrationBuilder.DropTable(
				name: "borrow");

			migrationBuilder.DropTable(
				name: "reader");

			migrationBuilder.DropTable(
				name: "reader_gender");

			migrationBuilder.DropTable(
				name: "reader_role");

			migrationBuilder.DropTable(
				name: "reader_status");

			migrationBuilder.DropTable(
				name: "reader_type");
		}
	}
}
