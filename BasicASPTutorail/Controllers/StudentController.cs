using BasicASPTutorail.Data;
using BasicASPTutorail.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace BasicASPTutorail.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;


        public StudentController(ApplicationDBContext db)
        { // เมื่อเรียกใช้ controller Student ให้ เรียก contructor เพื่อเชื่อมต่อ database เลย
            _db = db;
        }
        public IActionResult Index()
        {
            // การ select ตาราง Students มาจาก Database โดยผ่าน DBContext ที่ผูกไว้
            IEnumerable<Student> listStudent = _db.Students; //IEnumerable คือการเก็บกลุ่ม obj มากกว่า 1 ก้อน
           return View(listStudent);


            ///*ข้อมูลตัวอย่าง*/
            //Student student = new Student();
            //student.Id = 1;
            //student.Name = "a";
            //student.Score = 100;

            //var student2 = new Student();
            //student2.Id = 2;
            //student2.Name = "b";
            //student2.Score = 50;

            //var student3 = new Student();
            //student3.Id = 3;
            //student3.Name = "c";
            //student3.Score = 20;


            //List<Student> listStudents = new List<Student>() { 
            //    new Student() { Id = 1, Name = "a" ,Score = 100},
            //    new Student() { Id = 1, Name = "a" ,Score = 100},
            //    new Student() { Id = 1, Name = "a" ,Score = 100}
            //};
            //listStudents.Add(student);
            //listStudents.Add(student2);
            //listStudents.Add(student3);
            //return View(listStudents);
            ///*ข้อมูลตัวอย่าง*/

        }

        // GET
        public IActionResult Create() 
        {
            return View();
        
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] // ต้องประกาศเสมอ เมื่อส่งค่าผ่าน Post
        public IActionResult Create(Student obj) 
        {
            if (ModelState.IsValid) //ตรวจสอบความถูกต้องของข้อมูลตามโครงสร้าง Model Student
            {
                // _db คือการอ้างถึง DBContext ที่เชื่อมกันไว้แล้ว
                _db.Students.Add(obj); // add ข้อมูล obj Student ผ่าน DbSet ลงในฐานข้อมูล
                _db.SaveChanges();
                return RedirectToAction("Index"); // Redirect ไปที่ controller Student action Index
            }
            else { 
                return View(obj); // ส่งข้อมูล obj ไปแสดงที่ View Create.cshtml
            }
        }
        // GET
        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
                return NotFound();
            else { 
               var obj = _db.Students.Find(id); // Find คือคำสั่งที่ใช้ค้นหาที่ PK โดยส่ง id ไปเช็ค
                if(obj == null)
                    return NotFound();
                return View(obj); //ส่ง obj ไปที่ view Edit.cshtml
            }
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken] // ต้องประกาศเสมอ เมื่อส่งค่าผ่าน Post
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid) //ตรวจสอบความถูกต้องของข้อมูลตามโครงสร้าง Model Student
            {
                // _db คือการอ้างถึง DBContext ที่เชื่อมกันไว้แล้ว
                _db.Students.Update(obj); // add ข้อมูล obj Student ผ่าน DbSet ลงในฐานข้อมูล
                _db.SaveChanges(); //บันทึกรายการล่าสุด
                return RedirectToAction("Index"); // Redirectไปที่ controller Student action Index
            }
            else
            {
                return View(obj); //ส่งข้อมูลไปแสดงที่ View Edit.cshtml
            }
        }
        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            else
            {
                var obj = _db.Students.Find(id); // Find คือคำสั่งที่ใช้ค้นหาที่ PK โดยส่ง id ไปเช็ค
                if (obj == null)
                    return NotFound();
                else
                {
                    _db.Students.Remove(obj); // ลบข้อมูล obj ในฐานข้อมูล
                    _db.SaveChanges(); //บันทึกรายการล่าสุด
                }
                return RedirectToAction("Index"); // Redirectไปที่ controller Student action Index
            }
        }
    }
}
