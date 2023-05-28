using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBD
{
    public class Player
    {
        private String _player_id;
        private String _player_name;
        private String _player_region;
        private String _player_nick;
        private String _player_personagem_name;

        public String PlayerID
        {
            get { return _player_id; }
            set { _player_id = value; }
        }

        public String PlayerName
        {
            get { return _player_name; }
            set { _player_name = value; }   
        }

        public String PlayerRegion
        { 
            get { return _player_region; }
            set { _player_region = value; }
        }          

        public String PlayerNick
        {
            get { return _player_nick; }
            set { _player_nick = value; }
        }

        public String PlayerPersonagemName
        {
            get { return _player_personagem_name; }
            set { _player_personagem_name = value; }
        }


        public override string ToString()
        {
            return _player_id + " " + _player_name;
        }
    }
}
