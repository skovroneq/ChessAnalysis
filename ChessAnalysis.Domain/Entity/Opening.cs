using ChessAnalysis.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAnalysis.Domain.Entity
{
    public class Opening : BaseEntity
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }

        public Opening(int id, string name, int typeId)
        {
            Id = id;
            Name = name;
            TypeId = typeId;
        }
    }

}

