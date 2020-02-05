using System.Collections.Generic;

namespace Server
{
    class Game
    {
        private Dictionary<Player, int> Scores { get; set; } = null;
        private List<Player> _players = null;

        public Game(List<Player> players)
        {
            _players = players;
        }
    }
}