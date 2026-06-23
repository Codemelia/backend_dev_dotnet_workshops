namespace AdoSqlWorkshop.Models
{
    public class Lecturer
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        public Lecturer() { }
        public Lecturer(int Id, string FirstName, string LastName, string Username)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Username = Username;
        }

    }
}
