using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Doctors (Name, Specialization, WorkDays) VALUES ( 'Ahmed Hassan', 'Cardiology', 'Sun-Mon-Tue-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ('Sara Ibrahim', 'Pediatrics', 'Mon-Tue-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ('Omar Khaled', 'Orthopedics', 'Sun-Tue-Thu');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ('Mona Adel', 'Neurology', 'Sat-Mon-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ('Mohamed Ali', 'Dermatology', 'Sat-Sun-Mon');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ('Youssef Nabil', 'Cardiology', 'Sun-Mon-Tue');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ('Hassan Mahmoud', 'ENT', 'Mon-Wed-Thu');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ('Nour Eldin', 'Dermatology', 'Sat-Sun-Tue');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ('Fatma Samir', 'Gynecology', 'Sun-Mon-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Mahmoud Tarek', 'Urology', 'Mon-Tue-Thu');

INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Ahmed Salah', 'Cardiology', 'Sun-Tue-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Ali Mostafa', 'Pediatrics', 'Sat-Mon-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Heba Yasser', 'Neurology', 'Sun-Mon-Tue');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Khaled Fathy', 'Orthopedics', 'Tue-Wed-Thu');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Nada Ashraf', 'Dermatology', 'Sat-Sun-Mon');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Yara Hany', 'Gynecology', 'Mon-Tue-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Mostafa Adel', 'ENT', 'Sun-Tue-Thu');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Salma Reda', 'Pediatrics', 'Sat-Mon-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Karim Essam', 'Urology', 'Sun-Tue-Wed');
INSERT INTO Doctors ( Name, Specialization, WorkDays) VALUES ( 'Ola Gamal', 'Cardiology', 'Mon-Wed-Thu');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRANCATE TABLE Doctors");
        }
    }
}
