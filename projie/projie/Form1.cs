using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace projie
{

    public partial class Form1 : Form
    { //initialize all the things
        public static System.Random random = new System.Random();
        public class item
        { //parent class: all child classes share these properties
            public string title;
            public double rating;
            public bool available;
            public int waitlist;
        }
        class game : item
        { //Game class
            public string platform;
            public bool online;
            public game(string gtitle, double grating, int gwaitlist, string gplatform, bool gonline)
            {
                title = gtitle;
                rating = grating;
                waitlist = gwaitlist;
                platform = gplatform;
                online = gonline;
                if (waitlist <= 1)
                {
                    available = true;
                }
                else
                {
                    available = false;
                }
            }
        }
        //list of all games
        List<game> games = new List<game>();
        class book : item
        { //Book class
            public string author;
            public int pages;
            public book(string gtitle, double grating, int gwaitlist, string gauthor, int gpages)
            {
                title = gtitle;
                rating = grating;
                waitlist = gwaitlist;
                author = gauthor;
                pages = gpages;
                if (waitlist <= 1)
                {
                    available = true;
                }
                else
                {
                    available = false;
                }
            }
        }
        //list of all books
        List<book> books = new List<book>();
        class movie : item
        { //Movie class
            public string director;
            public double length;
            public movie(string gtitle, double grating, int gwaitlist, string gdirector, double glength)
            {
                title = gtitle;
                rating = grating;
                waitlist = gwaitlist;
                director = gdirector;
                length = glength;
                if (waitlist <= 1)
                {
                    available = true;
                }
                else
                {
                    available = false;
                }
            }
        }
        //list of all movies
        List<movie> movies = new List<movie>();
        public Form1()
        { //initialize a bunch of default items
            InitializeComponent();
            creategame("Metal Gear Solid", 4.5, 0, "Playstation 1", false);
            creategame("Hollow Knight", 5, 0, "PC", false);
            creategame("Dark souls 2", 3.5, 3, "Xbox 360", true);
            createbook("The Shining", 5, 7, "Stephen King", 447);
            createbook("Ghost of Spirit Bear", 1.5, 0, "Ben Mikekakemakelensen", 336);
            createbook("The Great Gatsby", 2.5, 2, "F. Scott Fitzgerald", 225);
            createmovie("The Shining", 4.5, 3, "Stanley Kubrick", 2.26);
            createmovie("The Room", 5, 12349, "Tommy Wiseau", 1.39);
            createmovie("The Incredible Bulk", 1, 0, "Lewis Schoenbrun", 1.16);
        }

        private void button1_Click(object sender, EventArgs e)
        { //print all games, looping through the title properties of all games in the game list
            label2.Text = "";
            for (int i = 0; i < games.Count; i++)
            {
                label2.Text += games[i].title + "\n";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        { //print all movies, same method as above
            label2.Text = "";
            for (int i = 0; i < movies.Count; i++)
            {
                label2.Text += movies[i].title + "\n";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        { //yea buddy books amarite
            label2.Text = "";
            for (int i = 0; i < books.Count; i++)
            {
                label2.Text += books[i].title + "\n";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        { //random funni messages
            label2.Text = "";
            int rando = random.Next(1, 3);
            if (rando == 1)
            {
                label2.Text = "Return your books on time or I will return you to the void";
            }
            else
            {
                label2.Text = "Take out your home reading or i will take out your spine";
            }
        }//method used to create games and add them to the list
        public void creategame(string gtitle, double grating, int gwaitlist, string gplatform, bool gonline)
        {
            game newgame = new game(gtitle, grating, gwaitlist, gplatform, gonline);
            games.Add(newgame);
        }//method used to create books and add em to the list
        public void createbook(string gtitle, double grating, int gwaitlist, string gauthor, int gpages)
        {
            book newbook = new book(gtitle, grating, gwaitlist, gauthor, gpages);
            books.Add(newbook);
        }//methd us'd t'create muvies n add em ta th'list
        public void createmovie(string gtitle, double grating, int gwaitlist, string gdirector, double glength)
        {
            movie newmovie = new movie(gtitle, grating, gwaitlist, gdirector, glength);
            movies.Add(newmovie);
        }
        //show donate menu
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        { //donate a game
            textBox4.Visible = true;
            checkBox1.Visible = true;
            label5.Text = "Platform";
            button9.Visible = true;
            button7.Visible = false;
            button8.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        { //donate a movie
            textBox4.Visible = true;
            textBox3.Visible = true;
            label5.Text = "Director";
            label6.Text = "Length (Hours.Minutes)";
            button10.Visible = true;
            button6.Visible = false;
            button8.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        { //donair a book
            textBox4.Visible = true;
            textBox3.Visible = true;
            label5.Text = "Author";
            label6.Text = "Length (Pages)";
            button11.Visible = true;
            button6.Visible = false;
            button7.Visible = false;
        }

        public void resetbox2()
        { //reset box 2
            label5.Text = "";
            label6.Text = "";
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            textBox4.Text = "";
            textBox3.Text = "";
            textBox3.Visible = false;
            textBox4.Visible = false;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            checkBox1.Checked = false;
            checkBox1.Visible = false;
            groupBox2.Visible = false; 
        }

        private void button9_Click(object sender, EventArgs e)
        { //if a required feild is missing, don't let them create the game
            if (textBox2.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                label7.Text = "Missing input!";
            }
            else
            { //create game
                creategame(textBox2.Text, Convert.ToDouble(numericUpDown1.Value), 0, textBox3.Text, checkBox1.Checked);
                resetbox2();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        { //same as above with movies
            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                label7.Text = "Missing input!";
            }
            else
            {
                createmovie(textBox2.Text, Convert.ToDouble(numericUpDown1.Value), 0, textBox4.Text, Convert.ToDouble(textBox3.Text));
                resetbox2();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        { //create book, I allowed them to skip some feilds 
            createbook(textBox2.Text, Convert.ToDouble(numericUpDown1.Value), 0, textBox4.Text, Convert.ToInt32(textBox3.Text));
            resetbox2();
        }

        private void button5_Click(object sender, EventArgs e)
        { //function to search
            label10.Text = "Title: ";
            label11.Text = "Rating: ";
            label12.Text = "";
            if (textBox1.Text.Length == 0)
            { //if no name is entered to search
                label9.Text = "No name entered!";
            } else
            { //search for games
                if(radioButton1.Checked)
                {
                    search("game", textBox1.Text);
                } else if (radioButton2.Checked)
                { //search for movies
                    search("movie", textBox1.Text);
                } else
                { //search for books
                    search("livretomeexperience", textBox1.Text);
                }
            }
        }
        public void search(string clasz, string input)
        { //search method.
            bool found = false;
            if (clasz == "game")
            {
                for (int i = 0; i < games.Count; i++)
                {
                    if (input == games[i].title)
                    {
                        displaysearchedgame(i);
                        found = true;
                    }
                }
            } else if (clasz == "movie")
            {
                for (int i = 0; i < movies.Count; i++)
                {
                    if (input == movies[i].title)
                    {
                        displaysearchedmovie(i);
                        found = true;
                    }
                }
            } else {
                for (int i = 0; i < books.Count; i++)
                {
                    if (input == books[i].title)
                    {
                        displaysearchedbook(i);
                        found = true;
                    }
                }
            }
            if (!found)
            {
                label9.Text = "Not found!";
            }
        }
        public void displaysearchedgame(int i)
        { //display searched game
            groupBox1.Visible = true;
            label10.Text += games[i].title;
            label11.Text += games[i].rating + "/5";
            label12.Text += "Available on " + games[i].platform;
            if (games[i].online)
            {
                label12.Text += "Supports online play\n";
            } 
            checkavailable(games[i].available, games[i].waitlist);
        }
        public void displaysearchedmovie(int i)
        { // display searched movie
            groupBox1.Visible = true;
            label10.Text += movies[i].title;
            label11.Text += movies[i].rating + "/5";
            label12.Text += "Director: " + movies[i].director + "\nLength(Hours.Minutes): " + movies[i].length;
            checkavailable(movies[i].available, movies[i].waitlist);
        }
        public void displaysearchedbook (int i)
        { //display searched book
            groupBox1.Visible = true;
            label10.Text += books[i].title;
            label11.Text += books[i].rating + "/5";
            label12.Text += "Author: " + books[i].author + "\nLength(Pages): " + books[i].pages;
            checkavailable(books[i].available, books[i].waitlist);
        }
        public void checkavailable(bool available, int waitlist)
        { //function used by all to print availability/waitlist
            if(available)
            {
                label12.Text += "\nNow available!";
            } else
            {
                label12.Text += "\nNot currently available. \n" + waitlist + " people have this on hold.";
            }
        }
    }
}
