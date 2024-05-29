namespace ApiGames.Models
{
    public class User
    {
        public long Id { get; set; } 
        public string Name { get; set; }
        public string Mail { get; set; }
        public Library Library { get; set; }

        public Wishlist Wishlist { get; set; }  

        public User() { }

        public User(long id, string name, string mail, Library library, Wishlist wishlist)
        {
            Id = id;
            Name = name;
            Mail = mail;
            Library = library;
            Wishlist = wishlist;
        }
    }
}
