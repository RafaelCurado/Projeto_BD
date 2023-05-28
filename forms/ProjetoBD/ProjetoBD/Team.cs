using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBD
{
    public class Team
    {

        private String _team_id;
        private String _team_name;
        private String _team_country;
        private String _team_player1;
        private String _team_player2;
        private String _team_player3;
        private String _team_player4;
        private String _team_player5;

        public String TeamID
        { 
            get { return _team_id; } 
            set { _team_id = value; }
        }

        public String TeamName
        { 
            get { return _team_name; } 
            set { _team_name = value; } 
        }          

        public String TeamCountry
        { 
            get { return _team_country; } 
            set { _team_country = value; } 
        }

        public String TeamPlayer1
        { 
            get { return _team_player1; } 
            set { _team_player1 = value;}
        }       
        public String TeamPlayer2
        {
            get { return _team_player2; }
            set { _team_player2 = value; }
        }

        public String TeamPlayer3
        {
            get { return _team_player3; }
            set { _team_player3 = value; }
        }

        public String TeamPlayer4
        {
            get { return _team_player4; }
            set { _team_player4 = value; }
        }

        public String TeamPlayer5
        {
            get { return _team_player5; }
            set { _team_player5 = value; }
        }


        public override string ToString()
        {
            return _team_id + " " + _team_name + " From: " + _team_country;
        }
    }
}
