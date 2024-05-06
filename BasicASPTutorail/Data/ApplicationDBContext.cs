using BasicASPTutorail.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicASPTutorail.Data
{
    public class ApplicationDBContext : DbContext
    {
        //สร้าง Contructor ที่ส่งค่า options ไป set ที่ Contructor ของ class แม่ DbContext
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options){ 
            
        }
        // DbSet คือคำสั่งให้สร้างตาราง ตาม Model Student ใน SQL server ใน database ชื่อ StudentDB ตาม Connection String
        public DbSet<Student> Students { get; set; } 
    }
}
