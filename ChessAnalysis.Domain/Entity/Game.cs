using ChessAnalysis.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnalysis.Domain.Entity
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Result { get; set; }
        public string Opening { get; set; }
        public DateTime Date { get; set; }

        public Game(int id, string name, int typeId)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
        }
    }

}
