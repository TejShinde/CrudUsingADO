using System .Data .SqlClient;

namespace CrudUsingADO .Models
    {
    public class StudentCrud
        {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public StudentCrud ( IConfiguration configuration )
            {
            this .configuration = configuration;
            con = new SqlConnection(this .configuration .GetConnectionString("DefaultConnection"));
            }

        public List<Student> GetStudents ()
            {
            List<Student> students = new List<Student>();
            cmd = new SqlCommand("SELECT * FROM student" , con);
            con .Open();
            dr = cmd .ExecuteReader();
            if ( dr .HasRows )
                {
                while ( dr .Read() )
                    {
                    Student student = new Student();
                    student .StudentId = Convert .ToInt32(dr["studentid"]);
                    student .Name = dr["name"] .ToString();
                    student .Email = dr["email"] .ToString();
                    student .Grade = dr["grade"] .ToString();
                    students .Add(student);
                    }
                }
            con .Close();
            return students;
            }

        public Student GetStudentById ( int id )
            {
            Student student = new Student();
            cmd = new SqlCommand("SELECT * FROM student WHERE studentid = @id" , con);
            cmd .Parameters .AddWithValue("@id" , id);
            con .Open();
            dr = cmd .ExecuteReader();
            if ( dr .HasRows )
                {
                while ( dr .Read() )
                    {
                    student .StudentId = Convert .ToInt32(dr["studentid"]);
                    student .Name = dr["name"] .ToString();
                    student .Email = dr["email"] .ToString();
                    student .Grade = dr["grade"] .ToString();
                    }
                }
            con .Close();
            return student;
            }

        public int AddStudent ( Student student )
            {
            int result = 0;
            string qry = "INSERT INTO student (name, email, grade) VALUES (@name, @email, @grade)";
            cmd = new SqlCommand(qry , con);
            cmd .Parameters .AddWithValue("@name" , student .Name);
            cmd .Parameters .AddWithValue("@email" , student .Email);
            cmd .Parameters .AddWithValue("@grade" , student .Grade);
            con .Open();
            result = cmd .ExecuteNonQuery();
            con .Close();
            return result;
            }

        public int UpdateStudent ( Student student )
            {
            int result = 0;
            string qry = "UPDATE student SET name = @name, email = @email, grade = @grade WHERE studentid = @id";
            cmd = new SqlCommand(qry , con);
            cmd .Parameters .AddWithValue("@name" , student .Name);
            cmd .Parameters .AddWithValue("@email" , student .Email);
            cmd .Parameters .AddWithValue("@grade" , student .Grade);
            cmd .Parameters .AddWithValue("@id" , student .StudentId);
            con .Open();
            result = cmd .ExecuteNonQuery();
            con .Close();
            return result;
            }

        public int DeleteStudent ( int id )
            {
            int result = 0;
            string qry = "DELETE FROM student WHERE studentid = @id";
            cmd = new SqlCommand(qry , con);
            cmd .Parameters .AddWithValue("@id" , id);
            con .Open();
            result = cmd .ExecuteNonQuery();
            con .Close();
            return result;
            }
        }
    }
