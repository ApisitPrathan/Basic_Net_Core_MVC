using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicASPTutorail.Models
{
    public class Student
    {
        [Key] // set เป็น PK
        public int Id { get; set; }


        [Required(ErrorMessage = "กรุณาป้อนชื่อนักเรียน")] // สร้าง ErrorMessage 
        [DisplayName("ชื่อนักเรียน")] // ตั้งค่าให้ Display ที่ views ชื่อนักเรียน
        public string Name { get; set; } // ชื่อผูกกับ column Database


        [DisplayName("คะแนนสอบ")] // ตั้งค่าให้ Display ที่ views คะแนนสอบ
        [Range(0,100,ErrorMessage = "กรุณาป้อนคะแนนอยู่ในช่วง 0-100")] // สร้าง ErrorMessage 
        public int Score { get; set; } // ชื่อผูกกับ column Database
    }
}
