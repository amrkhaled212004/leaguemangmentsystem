using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace demo
{// Base class for all entities
    public abstract class Entity
    {
        public int Id { get; set; }

    }
    // Class for representing a football team
    public class Team : Entity
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Match>matches { get; set; }
        public Player BestPlayer { get; set; }
    }
    public class Player : Entity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public int GoalsScored { get; set; }
    }
    public class Stadium : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int SeatCapacity { get; set; }
        public List<Match> Matches { get; set; }
    }
    // Class for representing a football team
    public class Referee : Entity
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public List<Match> MatchesToReferee { get; set; }
    }
    public class Match : Entity
    {
        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Stadium Stadium { get; set; }
        public Referee Referee { get; set; }
       
    }
    public class Admin
    {
        public List<Player> players {  get; set; } 

        private List<Team> teams {  get; set; } 
        private List<Stadium> stadiums {  get; set; }   
        private List<Referee> referees {  get; set; }   
        public string username { get; set; }
        public string password { get; set; }
       public List<string> username1 = new List<string>();

       public List<string> password1 = new List<string>();
        public void DisplayAllData()
        {
            Console.WriteLine("Which data would you like to display?");
            Console.WriteLine("1. Players");
            Console.WriteLine("2. Teams");
            Console.WriteLine("3. Stadiums");
            Console.WriteLine("4. Referees");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayers();
                    break;
                case "2":
                    DisplayTeams();
                    break;
                case "3":
                    DisplayStadiums();
                    break;
                case "4":
                    DisplayReferees();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void DisplayPlayers()
        {
            Console.WriteLine("Players:");
            foreach (var player in players)
            {
                Console.WriteLine($"ID: {player.Id}, Name: {player.Name}, Position: {player.Position}, Nationality: {player.Nationality}, Age: {player.Age}, Goals Scored: {player.GoalsScored}");
            }
        }

        private void DisplayTeams()
        {
            Console.WriteLine("Teams:");
            foreach (var team in teams)
            {
                Console.WriteLine($"ID: {team.Id}, Name: {team.Name}, Best Player: {team.BestPlayer?.Name}");
                Console.WriteLine("Players:");
                foreach (var player in team.Players)
                {
                    Console.WriteLine($"- {player.Name}");
                }
                Console.WriteLine("Matches:");
                foreach (var match in team.matches)
                {
                    Console.WriteLine($"- {match.HomeTeam.Name} vs {match.AwayTeam.Name}, Date: {match.Date}");
                }
            }
        }

        private void DisplayStadiums()
        {
            Console.WriteLine("Stadiums:");
            foreach (var stadium in stadiums)
            {
                Console.WriteLine($"ID: {stadium.Id}, Name: {stadium.Name}, Location: {stadium.Location}, Seat Capacity: {stadium.SeatCapacity}");
                Console.WriteLine("Matches:");
                foreach (var match in stadium.Matches)
                {
                    Console.WriteLine($"- {match.HomeTeam.Name} vs {match.AwayTeam.Name}, Date: {match.Date}");
                }
            }
        }

        private void DisplayReferees()
        {
            Console.WriteLine("Referees:");
            foreach (var referee in referees)
            {
                Console.WriteLine($"ID: {referee.Id}, Name: {referee.Name}, Nationality: {referee.Nationality}, Age: {referee.Age}");
                Console.WriteLine("Matches to Referee:");
                foreach (var match in referee.MatchesToReferee)
                {
                    Console.WriteLine($"- {match.HomeTeam.Name} vs {match.AwayTeam.Name}, Date: {match.Date}");
                }
            }
        }

        public void add_admin()
        {
            username1.Add("amr");
            password1.Add("4748");
        }
        public void admin_register(string username, string password)
        {
            if (username1.Contains(username))
            {
                Console.WriteLine("this username already exists please choose another username");
                return;
            }
            username1.Add(username);
            password1.Add(password);
            Console.WriteLine("registered succesfully");
        }
        public void admin_delete(string username)
        {
            if (username1.Contains(username))
            {
                int i = username1.IndexOf(username);
                password1.RemoveAt(i);
                username1.RemoveAt(i);
            }
            else
            {
                Console.WriteLine("username is not available");
                return;
            }

        }
        public void signout()
        {
            Console.Clear();
            Console.WriteLine("signed out succesfully");
        }
        public void signin(String username, string password)
        {
            if (!username1.Contains(username))
            {
                Console.WriteLine("username not available \n register first");
                return;
            }
            int i = username1.IndexOf(username);
            if (password1[i] == password)
            {
                Console.WriteLine("signed in succesfully");
                return;
            }
            else
                Console.WriteLine("wrong password please try again");



        }

        public Admin()
        {
            // Initialize lists
            players = new List<Player>();
            teams = new List<Team>();
            stadiums = new List<Stadium>();
            referees = new List<Referee>();
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        // Method to remove a player
        public void RemovePlayer(Player player)
        {
            players.Remove(player);
        }

        // Method to add a team
        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        // Method to remove a team
        public void RemoveTeam(Team team)
        {
            teams.Remove(team);
        }

        // Method to add a stadium
        public void AddStadium(Stadium stadium)
        {
            stadiums.Add(stadium);
        }

        // Method to remove a stadium
        public void RemoveStadium(Stadium stadium)
        {
            stadiums.Remove(stadium);
        }

        // Method to add a referee
        public void AddReferee(Referee referee)
        {
            referees.Add(referee);
        }

        // Method to remove a referee
        public void RemoveReferee(Referee referee)
        {
            referees.Remove(referee);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Player player = new Player();   
            Team team = new Team();
            Stadium stadium = new Stadium();
            Referee referee = new Referee(); 
            Admin admin = new Admin();
            Match match = new Match();
            
            
            admin.username1.Add("amr");
            admin.password1.Add("4748");
            

            
            
            
            Console.WriteLine("1- user\n2- admin");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine("enter name");
                    break;
                case 2:
                    //Console.WriteLine("enter name");
                    //string d = Console.ReadLine();
                   // Console.WriteLine("enter pass");
                   // string p = Console.ReadLine();
                   Console.WriteLine("1-register\n 2-signin"); 
                    int c= Convert.ToInt32(Console.ReadLine());
                   // Admin admin1 = new Admin();
                    if (c == 1)
                    {

                        
                        Console.WriteLine("enter name:");
                        string f = Console.ReadLine();
                        Console.WriteLine("enter pass:");
                        string x = Console.ReadLine();
                        admin.admin_register(f, x);
                    }
                    else if(c==2)
                    {
                        Console.WriteLine("enter name:");
                        string f = Console.ReadLine();
                        Console.WriteLine("enter pass:");
                        string x = Console.ReadLine();
                        admin.signin(f, x);


                    }
                    Console.WriteLine("1-add 2-delete 3-display");
                    int d = Convert.ToInt32(Console.ReadLine());
                   

                    if (d == 1)
                    {
                        Console.WriteLine("1-player\n 2-team\n 3-stadium \n 4-referee\n");
                        int g = Convert.ToInt32(Console.ReadLine());
                        switch (g)
                        {
                                case 1:
                               player.Name= Console.ReadLine();
                                player.Position = Console.ReadLine();
                                player.Nationality = Console.ReadLine();    

                                player.Age = Convert.ToInt32(Console.ReadLine());
                                player.GoalsScored=Convert.ToInt32(Console.ReadLine());
                                admin.AddPlayer(player);
                                admin.DisplayAllData();

                                break;
                                case 2: 
                                team.Name= Console.ReadLine();
                                player.Name = Console.ReadLine();
                                player.Position = Console.ReadLine();
                                player.Nationality = Console.ReadLine();

                                player.Age = Convert.ToInt32(Console.ReadLine());
                                player.GoalsScored = Convert.ToInt32(Console.ReadLine());


                                team.Players.Add(player); 
                              //  team.playerBestPlayer =Console.ReadLine();
                                admin.AddTeam(team); 
                                
                                break;  
                                case 3: 
                                stadium.Name= Console.ReadLine();
                                stadium.Location= Console.ReadLine();
                                stadium.SeatCapacity= Convert.ToInt32(Console.ReadLine());  
                                match.Date=Convert.ToDateTime(Console.ReadLine());
                                


                                admin.AddStadium(stadium);
                                break;
                                case 4: 
                                admin.AddReferee(referee);
                                break;  
                                
                            
                        }


                    }
                    else if(d==2)
                    {
                        Console.WriteLine("1-player\n 2-team\n 3-stadium \n 4-referee\n");
                        int g = Convert.ToInt32(Console.ReadLine());
                        switch (g)
                        {
                            case 1:
                                admin.RemovePlayer(player);
                                break;
                            case 2:
                                admin.RemoveTeam(team);
                                break;
                            case 3:
                                admin.RemoveStadium(stadium);
                                break;
                            case 4:
                                admin.RemoveReferee(referee);
                                break;


                        }




                    }
                    else if(d==3)
                    {
                        admin.DisplayAllData();



                    }
                    break;



                    
            }
                   /* Console.WriteLine("1-display\n2-edit\n3-delete\n4-add\n");
                    int b = Convert.ToInt32(Console.ReadLine());
                   
                    switch (b)
                    {
                        case 1:
                            Console.WriteLine("1-match\n2-team\n3-ref");
                            int c = Convert.ToInt32(Console.ReadLine());
                            switch (c)
                            {
                                case 1:
                                    Console.WriteLine();
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("1-match\n2-team\n3-ref");
                            break;
                        case 3:
                            Console.WriteLine("1-match\n2-team\n3-ref");
                            break;
                        case 4:
                            Console.WriteLine("1-match\n2-team\n3-ref");
                            break;

                         


                    }*/



                    
         }
    }
        
    
} 
